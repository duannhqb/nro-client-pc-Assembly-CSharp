using System;

// Token: 0x020000BA RID: 186
public class ServerListScreen : mScreen, IActionListener
{
	// Token: 0x06000916 RID: 2326 RVA: 0x00087F98 File Offset: 0x00086198
	public ServerListScreen()
	{
		int num = 4;
		int num2 = num * 32 + 23 + 33;
		if (num2 >= GameCanvas.w)
		{
			num--;
			num2 = num * 32 + 23 + 33;
		}
		this.initCommand();
		if (!GameCanvas.isTouch)
		{
			ServerListScreen.selected = 0;
			this.processInput();
		}
		GameScr.loadCamera(true, -1, -1);
		GameScr.cmx = 100;
		GameScr.cmy = 200;
		if (this.cmdCallHotline == null)
		{
			this.cmdCallHotline = new Command("Gọi cho Thomas/", this, 13, null);
			this.cmdCallHotline.x = GameCanvas.w - 75;
			if (mSystem.clientType == 1 && !GameCanvas.isTouch)
			{
				this.cmdCallHotline.y = GameCanvas.h - 20;
			}
			else
			{
				int num3 = 2;
				this.cmdCallHotline.y = num3 + 6;
			}
		}
		ServerListScreen.cmdUpdateServer = new Command();
		ServerListScreen.cmdUpdateServer.actionChat = delegate(string str)
		{
			string text = str;
			string text2 = str;
			if (text == null)
			{
				text = ServerListScreen.linkDefault;
				return;
			}
			if (text == null && text2 != null)
			{
				if (text2.Equals(string.Empty) || text2.Length < 20)
				{
					text2 = ServerListScreen.linkDefault;
				}
				ServerListScreen.getServerList(text2);
			}
			if (text != null && text2 == null)
			{
				if (text.Equals(string.Empty) || text.Length < 20)
				{
					text = ServerListScreen.linkDefault;
				}
				ServerListScreen.getServerList(text);
			}
			if (text != null && text2 != null)
			{
				if (text.Length > text2.Length)
				{
					ServerListScreen.getServerList(text);
				}
				else
				{
					ServerListScreen.getServerList(text2);
				}
			}
		};
		this.setLinkDefault(mSystem.LANGUAGE);
	}

	// Token: 0x06000917 RID: 2327 RVA: 0x000880BC File Offset: 0x000862BC
	public static void createDeleteRMS()
	{
		if (ServerListScreen.cmdDeleteRMS == null)
		{
			if (GameCanvas.serverScreen == null)
			{
				GameCanvas.serverScreen = new ServerListScreen();
			}
			ServerListScreen.cmdDeleteRMS = new Command(string.Empty, GameCanvas.serverScreen, 14, null);
			ServerListScreen.cmdDeleteRMS.x = GameCanvas.w - 78;
			ServerListScreen.cmdDeleteRMS.y = GameCanvas.h - 26;
		}
	}

	// Token: 0x06000918 RID: 2328 RVA: 0x00088124 File Offset: 0x00086324
	private void initCommand()
	{
		this.nCmdPlay = 0;
		string text = Rms.loadRMSString("acc");
		if (text == null)
		{
			if (Rms.loadRMS("userAo" + ServerListScreen.ipSelect) != null)
			{
				this.nCmdPlay = 1;
			}
		}
		else if (text.Equals(string.Empty))
		{
			if (Rms.loadRMS("userAo" + ServerListScreen.ipSelect) != null)
			{
				this.nCmdPlay = 1;
			}
		}
		else
		{
			this.nCmdPlay = 1;
		}
		this.cmd = new Command[(mGraphics.zoomLevel <= 1) ? (4 + this.nCmdPlay) : (3 + this.nCmdPlay)];
		int num = GameCanvas.hh - 15 * this.cmd.Length + 28;
		for (int i = 0; i < this.cmd.Length; i++)
		{
			switch (i)
			{
			case 0:
				this.cmd[0] = new Command(string.Empty, this, 3, null);
				if (text == null)
				{
					this.cmd[0].caption = mResources.playNew;
					if (Rms.loadRMS("userAo" + ServerListScreen.ipSelect) != null)
					{
						this.cmd[0].caption = mResources.choitiep;
					}
				}
				else if (text.Equals(string.Empty))
				{
					this.cmd[0].caption = mResources.playNew;
					if (Rms.loadRMS("userAo" + ServerListScreen.ipSelect) != null)
					{
						this.cmd[0].caption = mResources.choitiep;
					}
				}
				else
				{
					this.cmd[0].caption = mResources.playAcc + ": " + text;
					if (this.cmd[0].caption.Length > 23)
					{
						this.cmd[0].caption = this.cmd[0].caption.Substring(0, 23);
						Command command = this.cmd[0];
						command.caption += "...";
					}
				}
				break;
			case 1:
				if (this.nCmdPlay == 1)
				{
					this.cmd[1] = new Command(string.Empty, this, 10100, null);
					this.cmd[1].caption = mResources.playNew;
				}
				else
				{
					this.cmd[1] = new Command(mResources.change_account, this, 7, null);
				}
				break;
			case 2:
				if (this.nCmdPlay == 1)
				{
					this.cmd[2] = new Command(mResources.change_account, this, 7, null);
				}
				else
				{
					this.cmd[2] = new Command(string.Empty, this, 17, null);
				}
				break;
			case 3:
				if (this.nCmdPlay == 1)
				{
					this.cmd[3] = new Command(string.Empty, this, 17, null);
				}
				else
				{
					this.cmd[3] = new Command(mResources.option, this, 8, null);
				}
				break;
			case 4:
				this.cmd[4] = new Command(mResources.option, this, 8, null);
				break;
			}
			this.cmd[i].y = num;
			this.cmd[i].setType();
			this.cmd[i].x = (GameCanvas.w - this.cmd[i].w) / 2;
			num += 30;
		}
	}

	// Token: 0x06000919 RID: 2329 RVA: 0x000079AF File Offset: 0x00005BAF
	public static void doUpdateServer()
	{
		if (ServerListScreen.cmdUpdateServer == null && GameCanvas.serverScreen == null)
		{
			GameCanvas.serverScreen = new ServerListScreen();
		}
		Net.connectHTTP2(ServerListScreen.linkDefault, ServerListScreen.cmdUpdateServer);
	}

	// Token: 0x0600091A RID: 2330 RVA: 0x00088494 File Offset: 0x00086694
	public static void getServerList(string str)
	{
		ServerListScreen.lengthServer = new int[3];
		string[] array = Res.split(str.Trim(), ",", 0);
		Res.outz("tem leng= " + array.Length);
		mResources.loadLanguague(sbyte.Parse(array[array.Length - 2]));
		ServerListScreen.nameServer = new string[array.Length - 2];
		ServerListScreen.address = new string[array.Length - 2];
		ServerListScreen.port = new short[array.Length - 2];
		ServerListScreen.language = new sbyte[array.Length - 2];
		ServerListScreen.hasConnected = new bool[2];
		for (int i = 0; i < array.Length - 2; i++)
		{
			string[] array2 = Res.split(array[i].Trim(), ":", 0);
			ServerListScreen.nameServer[i] = array2[0];
			ServerListScreen.address[i] = array2[1];
			ServerListScreen.port[i] = short.Parse(array2[2]);
			ServerListScreen.language[i] = sbyte.Parse(array2[3].Trim());
			ServerListScreen.lengthServer[(int)ServerListScreen.language[i]]++;
		}
		ServerListScreen.serverPriority = sbyte.Parse(array[array.Length - 1]);
		ServerListScreen.saveIP();
		GameCanvas.endDlg();
	}

	// Token: 0x0600091B RID: 2331 RVA: 0x000885C0 File Offset: 0x000867C0
	public override void paint(mGraphics g)
	{
		if (!ServerListScreen.loadScreen)
		{
			g.setColor(0);
			g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
			if (!ServerListScreen.bigOk)
			{
			}
		}
		else
		{
			GameCanvas.paintBGGameScr(g);
		}
		int num = 2;
		mFont.tahoma_7_white.drawString(g, string.Concat(new object[]
		{
			"v",
			GameMidlet.VERSION,
			"(",
			mGraphics.zoomLevel,
			")"
		}), GameCanvas.w - 2, num + 15, 1, mFont.tahoma_7_grey);
		if (!ServerListScreen.isGetData || ServerListScreen.loadScreen)
		{
			if (mSystem.clientType == 1 && !GameCanvas.isTouch)
			{
				mFont.tahoma_7_white.drawString(g, ServerListScreen.linkweb, GameCanvas.w - 2, GameCanvas.h - 15, 1, mFont.tahoma_7_grey);
			}
			else
			{
				mFont.tahoma_7_white.drawString(g, ServerListScreen.linkweb, GameCanvas.w - 2, num, 1, mFont.tahoma_7_grey);
			}
		}
		else
		{
			mFont.tahoma_7_white.drawString(g, ServerListScreen.linkweb, GameCanvas.w - 2, num, 1, mFont.tahoma_7_grey);
		}
		int num2 = (GameCanvas.w < 200) ? 160 : 180;
		if (ServerListScreen.cmdDeleteRMS != null)
		{
			mFont.tahoma_7_white.drawString(g, mResources.xoadulieu, GameCanvas.w - 2, GameCanvas.h - 15, 1, mFont.tahoma_7_grey);
		}
		if (GameCanvas.currentDialog == null)
		{
			if (!ServerListScreen.loadScreen)
			{
				if (!ServerListScreen.bigOk)
				{
					g.drawImage(LoginScr.imgTitle, GameCanvas.hw, GameCanvas.hh - 32, 3);
					if (!ServerListScreen.isGetData)
					{
						mFont.tahoma_7b_white.drawString(g, mResources.taidulieudechoi, GameCanvas.hw, GameCanvas.hh + 24, 2);
						if (ServerListScreen.cmdDownload != null)
						{
							ServerListScreen.cmdDownload.paint(g);
						}
					}
					else
					{
						if (ServerListScreen.cmdDownload != null)
						{
							ServerListScreen.cmdDownload.paint(g);
						}
						mFont.tahoma_7b_white.drawString(g, mResources.downloading_data + ServerListScreen.percent + "%", GameCanvas.w / 2, GameCanvas.hh + 24, 2);
						GameScr.paintOngMauPercent(GameScr.frBarPow20, GameScr.frBarPow21, GameScr.frBarPow22, (float)(GameCanvas.w / 2 - 50), (float)(GameCanvas.hh + 45), 100, 100f, g);
						GameScr.paintOngMauPercent(GameScr.frBarPow0, GameScr.frBarPow1, GameScr.frBarPow2, (float)(GameCanvas.w / 2 - 50), (float)(GameCanvas.hh + 45), 100, (float)ServerListScreen.percent, g);
					}
				}
			}
			else
			{
				int num3 = GameCanvas.hh - 15 * this.cmd.Length - 15;
				if (num3 < 25)
				{
					num3 = 25;
				}
				if (LoginScr.imgTitle != null)
				{
					g.drawImage(LoginScr.imgTitle, GameCanvas.hw, num3, 3);
				}
				for (int i = 0; i < this.cmd.Length; i++)
				{
					this.cmd[i].paint(g);
				}
				g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
				if (ServerListScreen.testConnect == -1)
				{
					if (GameCanvas.gameTick % 20 > 10)
					{
						g.drawRegion(GameScr.imgRoomStat, 0, 14, 7, 7, 0, (GameCanvas.w - mFont.tahoma_7b_dark.getWidth(this.cmd[2 + this.nCmdPlay].caption) >> 1) - 10, this.cmd[2 + this.nCmdPlay].y + 10, 0);
					}
				}
				else
				{
					g.drawRegion(GameScr.imgRoomStat, 0, ServerListScreen.testConnect * 7, 7, 7, 0, (GameCanvas.w - mFont.tahoma_7b_dark.getWidth(this.cmd[2 + this.nCmdPlay].caption) >> 1) - 10, this.cmd[2 + this.nCmdPlay].y + 9, 0);
				}
			}
		}
		base.paint(g);
	}

	// Token: 0x0600091C RID: 2332 RVA: 0x000889B4 File Offset: 0x00086BB4
	public void selectServer()
	{
		ServerListScreen.flagServer = 30;
		GameCanvas.startWaitDlg(mResources.PLEASEWAIT);
		if (Session_ME.gI().isConnected())
		{
			Session_ME.gI().close();
		}
		GameMidlet.IP = ServerListScreen.address[ServerListScreen.ipSelect];
		GameMidlet.PORT = (int)ServerListScreen.port[ServerListScreen.ipSelect];
		if ((int)ServerListScreen.language[ServerListScreen.ipSelect] != (int)mResources.language)
		{
			mResources.loadLanguague(ServerListScreen.language[ServerListScreen.ipSelect]);
		}
		LoginScr.serverName = ServerListScreen.nameServer[ServerListScreen.ipSelect];
		this.initCommand();
		GameCanvas.connect();
	}

	// Token: 0x0600091D RID: 2333 RVA: 0x00088A50 File Offset: 0x00086C50
	public override void update()
	{
		if (ServerListScreen.waitToLogin)
		{
			ServerListScreen.tWaitToLogin++;
			if (ServerListScreen.tWaitToLogin == 50)
			{
				GameCanvas.serverScreen.selectServer();
			}
			if (ServerListScreen.tWaitToLogin == 100)
			{
				if (GameCanvas.loginScr == null)
				{
					GameCanvas.loginScr = new LoginScr();
				}
				GameCanvas.loginScr.doLogin();
				Service.gI().finishUpdate();
				ServerListScreen.waitToLogin = false;
			}
		}
		if (ServerListScreen.flagServer > 0)
		{
			ServerListScreen.flagServer--;
			if (ServerListScreen.flagServer == 0)
			{
				GameCanvas.endDlg();
			}
		}
		for (int i = 0; i < this.cmd.Length; i++)
		{
			if (i == ServerListScreen.selected)
			{
				this.cmd[i].isFocus = true;
			}
			else
			{
				this.cmd[i].isFocus = false;
			}
		}
		GameScr.cmx++;
		if (!ServerListScreen.loadScreen && (ServerListScreen.bigOk || ServerListScreen.percent == 100))
		{
			ServerListScreen.cmdDownload = null;
		}
		base.update();
	}

	// Token: 0x0600091E RID: 2334 RVA: 0x000079DE File Offset: 0x00005BDE
	private void processInput()
	{
		if (ServerListScreen.loadScreen)
		{
			this.center = new Command(string.Empty, this, this.cmd[ServerListScreen.selected].idAction, null);
		}
		else
		{
			this.center = ServerListScreen.cmdDownload;
		}
	}

	// Token: 0x0600091F RID: 2335 RVA: 0x00007A1D File Offset: 0x00005C1D
	public static void updateDeleteData()
	{
		if (ServerListScreen.cmdDeleteRMS != null && ServerListScreen.cmdDeleteRMS.isPointerPressInside())
		{
			ServerListScreen.cmdDeleteRMS.performAction();
		}
	}

	// Token: 0x06000920 RID: 2336 RVA: 0x00088B68 File Offset: 0x00086D68
	public override void updateKey()
	{
		if (GameCanvas.isTouch)
		{
			ServerListScreen.updateDeleteData();
			if (this.cmdCallHotline != null && this.cmdCallHotline.isPointerPressInside())
			{
				this.cmdCallHotline.performAction();
			}
			if (!ServerListScreen.loadScreen)
			{
				if (ServerListScreen.cmdDownload != null && ServerListScreen.cmdDownload.isPointerPressInside())
				{
					ServerListScreen.cmdDownload.performAction();
				}
				base.updateKey();
				return;
			}
			for (int i = 0; i < this.cmd.Length; i++)
			{
				if (this.cmd[i] != null && this.cmd[i].isPointerPressInside())
				{
					this.cmd[i].performAction();
				}
			}
		}
		else if (ServerListScreen.loadScreen)
		{
			if (GameCanvas.keyPressed[8])
			{
				int num = (mGraphics.zoomLevel <= 1) ? 4 : 2;
				GameCanvas.keyPressed[8] = false;
				ServerListScreen.selected++;
				if (ServerListScreen.selected > num)
				{
					ServerListScreen.selected = 0;
				}
				this.processInput();
			}
			if (GameCanvas.keyPressed[2])
			{
				int num2 = (mGraphics.zoomLevel <= 1) ? 4 : 2;
				GameCanvas.keyPressed[2] = false;
				ServerListScreen.selected--;
				if (ServerListScreen.selected < 0)
				{
					ServerListScreen.selected = num2;
				}
				this.processInput();
			}
		}
		if (ServerListScreen.isWait)
		{
			return;
		}
		base.updateKey();
	}

	// Token: 0x06000921 RID: 2337 RVA: 0x00088CD8 File Offset: 0x00086ED8
	public static void saveIP()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeByte(mResources.language);
			dataOutputStream.writeByte((sbyte)ServerListScreen.nameServer.Length);
			for (int i = 0; i < ServerListScreen.nameServer.Length; i++)
			{
				dataOutputStream.writeUTF(ServerListScreen.nameServer[i]);
				dataOutputStream.writeUTF(ServerListScreen.address[i]);
				dataOutputStream.writeShort(ServerListScreen.port[i]);
				dataOutputStream.writeByte(ServerListScreen.language[i]);
			}
			dataOutputStream.writeByte(ServerListScreen.serverPriority);
			Rms.saveRMS("NRlink2", dataOutputStream.toByteArray());
			dataOutputStream.close();
			SplashScr.loadIP();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000922 RID: 2338 RVA: 0x00088D94 File Offset: 0x00086F94
	public static bool allServerConnected()
	{
		for (int i = 0; i < 2; i++)
		{
			if (!ServerListScreen.hasConnected[i])
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06000923 RID: 2339 RVA: 0x00088DC4 File Offset: 0x00086FC4
	public static void loadIP()
	{
		sbyte[] array = Rms.loadRMS("NRlink2");
		if (array == null)
		{
			ServerListScreen.getServerList(ServerListScreen.linkDefault);
			return;
		}
		DataInputStream dataInputStream = new DataInputStream(array);
		if (dataInputStream == null)
		{
			return;
		}
		try
		{
			ServerListScreen.lengthServer = new int[3];
			mResources.loadLanguague(dataInputStream.readByte());
			sbyte b = dataInputStream.readByte();
			ServerListScreen.nameServer = new string[(int)b];
			ServerListScreen.address = new string[(int)b];
			ServerListScreen.port = new short[(int)b];
			ServerListScreen.language = new sbyte[(int)b];
			for (int i = 0; i < (int)b; i++)
			{
				ServerListScreen.nameServer[i] = dataInputStream.readUTF();
				ServerListScreen.address[i] = dataInputStream.readUTF();
				ServerListScreen.port[i] = dataInputStream.readShort();
				ServerListScreen.language[i] = dataInputStream.readByte();
				ServerListScreen.lengthServer[(int)ServerListScreen.language[i]]++;
			}
			ServerListScreen.serverPriority = dataInputStream.readByte();
			dataInputStream.close();
			SplashScr.loadIP();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000924 RID: 2340 RVA: 0x00088ED8 File Offset: 0x000870D8
	public override void switchToMe()
	{
		GameCanvas.connect();
		GameScr.cmy = 0;
		GameScr.cmx = 0;
		this.initCommand();
		ServerListScreen.isWait = false;
		GameCanvas.loginScr = null;
		string text = Rms.loadRMSString("ResVersion");
		int num = (text == null || !(text != string.Empty)) ? -1 : int.Parse(text);
		if (num > 0)
		{
			ServerListScreen.loadScreen = true;
			GameCanvas.loadBG(0);
		}
		ServerListScreen.bigOk = true;
		this.cmd[2 + this.nCmdPlay].caption = mResources.server + ": " + ServerListScreen.nameServer[ServerListScreen.ipSelect];
		this.center = new Command(string.Empty, this, this.cmd[ServerListScreen.selected].idAction, null);
		this.cmd[1 + this.nCmdPlay].caption = mResources.change_account;
		if (this.cmd.Length == 4 + this.nCmdPlay)
		{
			this.cmd[3 + this.nCmdPlay].caption = mResources.option;
		}
		mSystem.resetCurInapp();
		base.switchToMe();
	}

	// Token: 0x06000925 RID: 2341 RVA: 0x00088FF4 File Offset: 0x000871F4
	public void switchToMe2()
	{
		GameScr.cmy = 0;
		GameScr.cmx = 0;
		this.initCommand();
		ServerListScreen.isWait = false;
		GameCanvas.loginScr = null;
		string text = Rms.loadRMSString("ResVersion");
		int num = (text == null || !(text != string.Empty)) ? -1 : int.Parse(text);
		if (num > 0)
		{
			ServerListScreen.loadScreen = true;
			GameCanvas.loadBG(0);
		}
		ServerListScreen.bigOk = true;
		this.cmd[2 + this.nCmdPlay].caption = mResources.server + ": " + ServerListScreen.nameServer[ServerListScreen.ipSelect];
		this.center = new Command(string.Empty, this, this.cmd[ServerListScreen.selected].idAction, null);
		this.cmd[1 + this.nCmdPlay].caption = mResources.change_account;
		if (this.cmd.Length == 4 + this.nCmdPlay)
		{
			this.cmd[3 + this.nCmdPlay].caption = mResources.option;
		}
		mSystem.resetCurInapp();
		base.switchToMe();
	}

	// Token: 0x06000926 RID: 2342 RVA: 0x00003984 File Offset: 0x00001B84
	public void connectOk()
	{
	}

	// Token: 0x06000927 RID: 2343 RVA: 0x0008910C File Offset: 0x0008730C
	public void cancel()
	{
		if (GameCanvas.serverScreen == null)
		{
			GameCanvas.serverScreen = new ServerListScreen();
		}
		ServerListScreen.demPercent = 0;
		ServerListScreen.percent = 0;
		ServerListScreen.stopDownload = true;
		GameCanvas.serverScreen.show2();
		ServerListScreen.isGetData = false;
		ServerListScreen.cmdDownload.isFocus = true;
		this.center = new Command(string.Empty, this, 2, null);
	}

	// Token: 0x06000928 RID: 2344 RVA: 0x00089170 File Offset: 0x00087370
	public void perform(int idAction, object p)
	{
		Res.outz("perform " + idAction);
		if (idAction == 1000)
		{
			GameCanvas.connect();
		}
		if (idAction == 1 || idAction == 4)
		{
			this.cancel();
		}
		if (idAction == 2)
		{
			ServerListScreen.stopDownload = false;
			ServerListScreen.cmdDownload = new Command(mResources.huy, this, 4, null);
			ServerListScreen.cmdDownload.x = GameCanvas.w / 2 - mScreen.cmdW / 2;
			ServerListScreen.cmdDownload.y = GameCanvas.hh + 65;
			this.right = null;
			if (!GameCanvas.isTouch)
			{
				ServerListScreen.cmdDownload.x = GameCanvas.w / 2 - mScreen.cmdW / 2;
				ServerListScreen.cmdDownload.y = GameCanvas.h - mScreen.cmdH - 1;
			}
			this.center = new Command(string.Empty, this, 4, null);
			if (!ServerListScreen.isGetData)
			{
				Service.gI().getResource(1, null);
				if (!GameCanvas.isTouch)
				{
					ServerListScreen.cmdDownload.isFocus = true;
					this.center = new Command(string.Empty, this, 4, null);
				}
				ServerListScreen.isGetData = true;
			}
		}
		if (idAction == 3)
		{
			Res.outz("toi day");
			if (GameCanvas.loginScr == null)
			{
				GameCanvas.loginScr = new LoginScr();
			}
			GameCanvas.loginScr.switchToMe();
			bool flag = Rms.loadRMSString("acc") != null && !Rms.loadRMSString("acc").Equals(string.Empty);
			bool flag2 = Rms.loadRMSString("userAo" + ServerListScreen.ipSelect) != null && !Rms.loadRMSString("userAo" + ServerListScreen.ipSelect).Equals(string.Empty);
			if (!flag && !flag2)
			{
				GameCanvas.connect();
				string text = Rms.loadRMSString("userAo" + ServerListScreen.ipSelect);
				if (text == null || text.Equals(string.Empty))
				{
					Service.gI().login2(string.Empty);
				}
				else
				{
					GameCanvas.loginScr.isLogin2 = true;
					GameCanvas.connect();
					Service.gI().setClientType();
					Service.gI().login(text, string.Empty, GameMidlet.VERSION, 1);
				}
				if (Session_ME.connected)
				{
					GameCanvas.startWaitDlg();
				}
				else
				{
					GameCanvas.startOKDlg(mResources.maychutathoacmatsong);
				}
			}
			else
			{
				GameCanvas.loginScr.doLogin();
			}
			LoginScr.serverName = ServerListScreen.nameServer[ServerListScreen.ipSelect];
		}
		if (idAction == 10100)
		{
			if (GameCanvas.loginScr == null)
			{
				GameCanvas.loginScr = new LoginScr();
			}
			GameCanvas.loginScr.switchToMe();
			GameCanvas.connect();
			Service.gI().login2(string.Empty);
			Res.outz("tao user ao");
			GameCanvas.startWaitDlg();
			LoginScr.serverName = ServerListScreen.nameServer[ServerListScreen.ipSelect];
		}
		if (idAction == 5)
		{
			ServerListScreen.doUpdateServer();
			if (ServerListScreen.nameServer.Length == 1)
			{
				return;
			}
			MyVector myVector = new MyVector(string.Empty);
			for (int i = 0; i < ServerListScreen.nameServer.Length; i++)
			{
				myVector.addElement(new Command(ServerListScreen.nameServer[i], this, 6, null));
			}
			GameCanvas.menu.startAt(myVector, 0);
			if (!GameCanvas.isTouch)
			{
				GameCanvas.menu.menuSelectedItem = ServerListScreen.ipSelect;
			}
		}
		if (idAction == 6)
		{
			ServerListScreen.ipSelect = GameCanvas.menu.menuSelectedItem;
			this.selectServer();
		}
		if (idAction == 7)
		{
			if (GameCanvas.loginScr == null)
			{
				GameCanvas.loginScr = new LoginScr();
			}
			GameCanvas.loginScr.switchToMe();
		}
		if (idAction == 8)
		{
			bool flag3 = Rms.loadRMSInt("lowGraphic") == 1;
			MyVector myVector2 = new MyVector("cau hinh");
			myVector2.addElement(new Command(mResources.cauhinhthap, this, 9, null));
			myVector2.addElement(new Command(mResources.cauhinhcao, this, 10, null));
			GameCanvas.menu.startAt(myVector2, 0);
			if (flag3)
			{
				GameCanvas.menu.menuSelectedItem = 0;
			}
			else
			{
				GameCanvas.menu.menuSelectedItem = 1;
			}
		}
		if (idAction == 9)
		{
			Rms.saveRMSInt("lowGraphic", 1);
			GameCanvas.startOK(mResources.plsRestartGame, 8885, null);
		}
		if (idAction == 10)
		{
			Rms.saveRMSInt("lowGraphic", 0);
			GameCanvas.startOK(mResources.plsRestartGame, 8885, null);
		}
		if (idAction == 11)
		{
			if (GameCanvas.loginScr == null)
			{
				GameCanvas.loginScr = new LoginScr();
			}
			GameCanvas.loginScr.switchToMe();
			string text2 = Rms.loadRMSString("userAo" + ServerListScreen.ipSelect);
			if (text2 == null || text2.Equals(string.Empty))
			{
				Service.gI().login2(string.Empty);
			}
			else
			{
				GameCanvas.loginScr.isLogin2 = true;
				GameCanvas.connect();
				Service.gI().setClientType();
				Service.gI().login(text2, string.Empty, GameMidlet.VERSION, 1);
			}
			GameCanvas.startWaitDlg(mResources.PLEASEWAIT);
			Res.outz("tao user ao");
		}
		if (idAction == 12)
		{
			GameMidlet.instance.exit();
		}
		if (idAction == 13 && (!ServerListScreen.isGetData || ServerListScreen.loadScreen))
		{
			switch (mSystem.clientType)
			{
			case 1:
				mSystem.callHotlineJava();
				break;
			case 3:
			case 5:
				mSystem.callHotlineIphone();
				break;
			case 4:
				mSystem.callHotlinePC();
				break;
			case 6:
				mSystem.callHotlineWindowsPhone();
				break;
			}
		}
		if (idAction == 14)
		{
			Command cmdYes = new Command(mResources.YES, GameCanvas.serverScreen, 15, null);
			Command cmdNo = new Command(mResources.NO, GameCanvas.serverScreen, 16, null);
			GameCanvas.startYesNoDlg(mResources.deletaDataNote, cmdYes, cmdNo);
		}
		if (idAction == 15)
		{
			Rms.clearAll();
			GameCanvas.startOK(mResources.plsRestartGame, 8885, null);
		}
		if (idAction == 16)
		{
			InfoDlg.hide();
			GameCanvas.currentDialog = null;
		}
		if (idAction == 17)
		{
			if (GameCanvas.serverScr == null)
			{
				GameCanvas.serverScr = new ServerScr();
			}
			GameCanvas.serverScr.switchToMe();
		}
	}

	// Token: 0x06000929 RID: 2345 RVA: 0x000897C4 File Offset: 0x000879C4
	public void init()
	{
		if (!ServerListScreen.loadScreen)
		{
			ServerListScreen.cmdDownload = new Command(mResources.taidulieu, this, 2, null);
			ServerListScreen.cmdDownload.isFocus = true;
			ServerListScreen.cmdDownload.x = GameCanvas.w / 2 - mScreen.cmdW / 2;
			ServerListScreen.cmdDownload.y = GameCanvas.hh + 45;
			if (ServerListScreen.cmdDownload.y > GameCanvas.h - 26)
			{
				ServerListScreen.cmdDownload.y = GameCanvas.h - 26;
			}
		}
		if (!GameCanvas.isTouch)
		{
			ServerListScreen.selected = 0;
			this.processInput();
		}
	}

	// Token: 0x0600092A RID: 2346 RVA: 0x00089864 File Offset: 0x00087A64
	public void show2()
	{
		GameScr.cmx = 0;
		GameScr.cmy = 0;
		this.initCommand();
		ServerListScreen.loadScreen = false;
		ServerListScreen.percent = 0;
		ServerListScreen.bigOk = false;
		ServerListScreen.isGetData = false;
		ServerListScreen.p = 0;
		ServerListScreen.demPercent = 0;
		ServerListScreen.strWait = mResources.PLEASEWAIT;
		this.init();
		base.switchToMe();
	}

	// Token: 0x0600092B RID: 2347 RVA: 0x000898C0 File Offset: 0x00087AC0
	public void setLinkDefault(sbyte language)
	{
		if ((int)language == 2)
		{
			if (mSystem.clientType == 1)
			{
				ServerListScreen.linkDefault = ServerListScreen.javaIn;
			}
			else
			{
				ServerListScreen.linkDefault = ServerListScreen.smartPhoneIn;
			}
		}
		else if ((int)language == 1)
		{
			ServerListScreen.linkDefault = ServerListScreen.javaE;
			if (mSystem.clientType == 1)
			{
				ServerListScreen.linkDefault = ServerListScreen.javaE;
			}
			else
			{
				ServerListScreen.linkDefault = ServerListScreen.smartPhoneE;
			}
		}
		else
		{
			ServerListScreen.linkDefault = ServerListScreen.javaVN;
			if (mSystem.clientType == 1)
			{
				ServerListScreen.linkDefault = ServerListScreen.javaVN;
			}
			else
			{
				ServerListScreen.linkDefault = ServerListScreen.smartPhoneVN;
			}
		}
	}

	// Token: 0x04001088 RID: 4232
	public static string[] nameServer;

	// Token: 0x04001089 RID: 4233
	public static string[] address;

	// Token: 0x0400108A RID: 4234
	public static sbyte serverPriority;

	// Token: 0x0400108B RID: 4235
	public static bool[] hasConnected;

	// Token: 0x0400108C RID: 4236
	public static short[] port;

	// Token: 0x0400108D RID: 4237
	public static int selected;

	// Token: 0x0400108E RID: 4238
	public static bool isWait;

	// Token: 0x0400108F RID: 4239
	public static Command cmdUpdateServer;

	// Token: 0x04001090 RID: 4240
	public static sbyte[] language;

	// Token: 0x04001091 RID: 4241
	private Command[] cmd;

	// Token: 0x04001092 RID: 4242
	private Command cmdCallHotline;

	// Token: 0x04001093 RID: 4243
	private int nCmdPlay;

	// Token: 0x04001094 RID: 4244
	public static Command cmdDeleteRMS;

	// Token: 0x04001095 RID: 4245
	private int lY;

	// Token: 0x04001096 RID: 4246
	public static string smartPhoneVN = "Nro CITY:20.235.67.32:14445:0,0,0";

	// Token: 0x04001097 RID: 4247
	public static string javaVN = "Nro CITY:20.235.67.32:14445:0,0,0";

	// Token: 0x04001098 RID: 4248
	public static string smartPhoneIn;

	// Token: 0x04001099 RID: 4249
	public static string javaIn = "Nro CITY:20.235.67.32:14445:0,0,0";

	// Token: 0x0400109A RID: 4250
	public static string smartPhoneE = "Nro CITY:20.235.67.32:14445:0,0,0";

	// Token: 0x0400109B RID: 4251
	public static string javaE = "Universe 1:54.179.255.27:14445:1,1,0";

	// Token: 0x0400109C RID: 4252
	public static string linkGetHost = "http://sv1.ngocrongonline.com/game/ngocrong031_t.php";

	// Token: 0x0400109D RID: 4253
	public static string linkDefault = ServerListScreen.javaVN;

	// Token: 0x0400109E RID: 4254
	public const sbyte languageVersion = 2;

	// Token: 0x0400109F RID: 4255
	public new int keyTouch = -1;

	// Token: 0x040010A0 RID: 4256
	private int tam;

	// Token: 0x040010A1 RID: 4257
	public static bool stopDownload;

	// Token: 0x040010A2 RID: 4258
	public static string linkweb = "http://ngocrongonline.com";

	// Token: 0x040010A3 RID: 4259
	public static bool waitToLogin;

	// Token: 0x040010A4 RID: 4260
	public static int tWaitToLogin;

	// Token: 0x040010A5 RID: 4261
	public static int[] lengthServer = new int[3];

	// Token: 0x040010A6 RID: 4262
	public static int ipSelect;

	// Token: 0x040010A7 RID: 4263
	public static int flagServer;

	// Token: 0x040010A8 RID: 4264
	public static bool bigOk;

	// Token: 0x040010A9 RID: 4265
	public static int percent;

	// Token: 0x040010AA RID: 4266
	public static string strWait;

	// Token: 0x040010AB RID: 4267
	public static int nBig;

	// Token: 0x040010AC RID: 4268
	public static int nBg;

	// Token: 0x040010AD RID: 4269
	public static int demPercent;

	// Token: 0x040010AE RID: 4270
	public static int maxBg;

	// Token: 0x040010AF RID: 4271
	public static bool isGetData = false;

	// Token: 0x040010B0 RID: 4272
	public static Command cmdDownload;

	// Token: 0x040010B1 RID: 4273
	private Command cmdStart;

	// Token: 0x040010B2 RID: 4274
	public string dataSize;

	// Token: 0x040010B3 RID: 4275
	public static int p;

	// Token: 0x040010B4 RID: 4276
	public static int testConnect = -1;

	// Token: 0x040010B5 RID: 4277
	public static bool loadScreen;
}
