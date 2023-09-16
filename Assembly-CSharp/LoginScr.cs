using System;

// Token: 0x020000AD RID: 173
public class LoginScr : mScreen, IActionListener
{
	// Token: 0x06000756 RID: 1878 RVA: 0x00065DD0 File Offset: 0x00063FD0
	public LoginScr()
	{
		this.yLog = GameCanvas.hh - 30;
		TileMap.bgID = (int)((sbyte)(mSystem.currentTimeMillis() % 9L));
		if (TileMap.bgID == 5 || TileMap.bgID == 6)
		{
			TileMap.bgID = 4;
		}
		GameScr.loadCamera(true, -1, -1);
		GameScr.cmx = 100;
		GameScr.cmy = 200;
		Main.closeKeyBoard();
		if (GameCanvas.h > 200)
		{
			this.defYL = GameCanvas.hh - 80;
		}
		else
		{
			this.defYL = GameCanvas.hh - 65;
		}
		this.resetLogo();
		int num = (GameCanvas.w < 200) ? 140 : 160;
		this.wC = num;
		this.yt = GameCanvas.hh - mScreen.ITEM_HEIGHT - 5;
		if (GameCanvas.h <= 160)
		{
			this.yt = 20;
		}
		this.tfUser = new TField();
		this.tfUser.y = GameCanvas.hh - mScreen.ITEM_HEIGHT - 9;
		this.tfUser.width = this.wC;
		this.tfUser.height = mScreen.ITEM_HEIGHT + 2;
		this.tfUser.isFocus = true;
		this.tfUser.setIputType(TField.INPUT_TYPE_ANY);
		this.tfUser.name = (((int)mResources.language != 2) ? (mResources.phone + "/") : string.Empty) + mResources.email;
		this.tfPass = new TField();
		this.tfPass.y = GameCanvas.hh - 4;
		this.tfPass.setIputType(TField.INPUT_TYPE_PASSWORD);
		this.tfPass.width = this.wC;
		this.tfPass.height = mScreen.ITEM_HEIGHT + 2;
		this.yt += 35;
		this.isCheck = true;
		int num2 = Rms.loadRMSInt("check");
		if (num2 == 1)
		{
			this.isCheck = true;
		}
		else if (num2 == 2)
		{
			this.isCheck = false;
		}
		this.tfUser.setText(Rms.loadRMSString("acc"));
		this.tfPass.setText(Rms.loadRMSString("pass"));
		if (this.cmdCallHotline == null)
		{
			this.cmdCallHotline = new Command("Gọi hotline", this, 13, null);
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
		this.focus = 0;
		this.cmdLogin = new Command((GameCanvas.w <= 200) ? mResources.login2 : mResources.login, GameCanvas.instance, 888393, null);
		this.cmdCheck = new Command(mResources.remember, this, 2001, null);
		this.cmdRes = new Command(mResources.register, this, 2002, null);
		this.cmdBackFromRegister = new Command(mResources.CANCEL, this, 10021, null);
		this.left = (this.cmdMenu = new Command(mResources.MENU, this, 2003, null));
		this.freeAreaHeight = this.tfUser.y - 2 * this.tfUser.height;
		if (GameCanvas.isTouch)
		{
			this.cmdLogin.x = GameCanvas.w / 2 + 8;
			this.cmdMenu.x = GameCanvas.w / 2 - mScreen.cmdW - 8;
			if (GameCanvas.h >= 200)
			{
				this.cmdLogin.y = this.yLog + 110;
				this.cmdMenu.y = this.yLog + 110;
			}
			this.cmdBackFromRegister.x = GameCanvas.w / 2 + 3;
			this.cmdBackFromRegister.y = this.yLog + 110;
			this.cmdRes.x = GameCanvas.w / 2 - 84;
			this.cmdRes.y = this.cmdMenu.y;
		}
		this.wP = 170;
		this.hP = ((!this.isRes) ? 100 : 110);
		this.xP = GameCanvas.hw - this.wP / 2;
		this.yP = this.tfUser.y - 15;
		int num4 = 4;
		int num5 = num4 * 32 + 23 + 33;
		if (num5 >= GameCanvas.w)
		{
			num4--;
			num5 = num4 * 32 + 23 + 33;
		}
		this.xLog = GameCanvas.w / 2 - num5 / 2;
		this.yLog = GameCanvas.hh - 30;
		this.lY = ((GameCanvas.w < 200) ? (this.tfUser.y - 30) : (this.yLog - 30));
		this.tfUser.x = this.xLog + 10;
		this.tfUser.y = this.yLog + 20;
		this.cmdOK = new Command(mResources.OK, this, 2008, null);
		this.cmdOK.x = GameCanvas.w / 2 - 84;
		this.cmdOK.y = this.cmdLogin.y;
		this.cmdFogetPass = new Command(mResources.forgetPass, this, 1003, null);
		this.cmdFogetPass.x = GameCanvas.w / 2 + 3;
		this.cmdFogetPass.y = this.cmdLogin.y;
		this.center = this.cmdOK;
		this.left = this.cmdFogetPass;
	}

	// Token: 0x06000757 RID: 1879 RVA: 0x000663F4 File Offset: 0x000645F4
	public static void getServerLink()
	{
		try
		{
			if (!LoginScr.isTryGetIPFromWap)
			{
				Command command = new Command();
				ActionChat actionChat = delegate(string str)
				{
					try
					{
						if (str == null)
						{
							return;
						}
						if (str == string.Empty)
						{
							return;
						}
						Rms.saveIP(str);
						if (!str.Contains(":"))
						{
							return;
						}
						int num = str.IndexOf(":");
						string text = str.Substring(0, num);
						string s = str.Substring(num + 1);
						GameMidlet.IP = text;
						GameMidlet.PORT = int.Parse(s);
						Session_ME.gI().connect(text, int.Parse(s));
						LoginScr.isTryGetIPFromWap = true;
					}
					catch (Exception ex)
					{
					}
				};
				command.actionChat = actionChat;
				Net.connectHTTP(ServerListScreen.linkGetHost, command);
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000758 RID: 1880 RVA: 0x00066464 File Offset: 0x00064664
	public override void switchToMe()
	{
		this.isRegistering = false;
		SoundMn.gI().stopAll();
		this.tfUser.isFocus = true;
		this.tfPass.isFocus = false;
		if (GameCanvas.isTouch)
		{
			this.tfUser.isFocus = false;
		}
		GameCanvas.loadBG(0);
		base.switchToMe();
	}

	// Token: 0x06000759 RID: 1881 RVA: 0x000664BC File Offset: 0x000646BC
	public void setUserPass()
	{
		string text = Rms.loadRMSString("acc");
		if (text != null && !text.Equals(string.Empty))
		{
			this.tfUser.setText(text);
		}
		string text2 = Rms.loadRMSString("pass");
		if (text2 != null && !text2.Equals(string.Empty))
		{
			this.tfPass.setText(text2);
		}
	}

	// Token: 0x0600075A RID: 1882 RVA: 0x00003984 File Offset: 0x00001B84
	public void updateTfWhenOpenKb()
	{
	}

	// Token: 0x0600075B RID: 1883 RVA: 0x00066524 File Offset: 0x00064724
	protected void doMenu()
	{
		MyVector myVector = new MyVector();
		myVector.addElement(new Command(mResources.registerNewAcc, this, 2004, null));
		if (!this.isLogin2)
		{
			myVector.addElement(new Command(mResources.selectServer, this, 1004, null));
		}
		myVector.addElement(new Command(mResources.forgetPass, this, 1003, null));
		myVector.addElement(new Command(mResources.website, this, 1005, null));
		if (Main.isPC)
		{
			myVector.addElement(new Command(mResources.EXIT, GameCanvas.instance, 8885, null));
		}
		GameCanvas.menu.startAt(myVector, 0);
	}

	// Token: 0x0600075C RID: 1884 RVA: 0x000665D0 File Offset: 0x000647D0
	protected void doRegister()
	{
		if (this.tfUser.getText().Equals(string.Empty))
		{
			GameCanvas.startOKDlg(mResources.userBlank);
			return;
		}
		char[] array = this.tfUser.getText().ToCharArray();
		if (this.tfPass.getText().Equals(string.Empty))
		{
			GameCanvas.startOKDlg(mResources.passwordBlank);
			return;
		}
		if (this.tfUser.getText().Length < 5)
		{
			GameCanvas.startOKDlg(mResources.accTooShort);
			return;
		}
		int num = 0;
		string text = null;
		if ((int)mResources.language == 2)
		{
			if (this.tfUser.getText().IndexOf("@") == -1 || this.tfUser.getText().IndexOf(".") == -1)
			{
				text = mResources.emailInvalid;
			}
			num = 0;
		}
		else
		{
			try
			{
				long num2 = long.Parse(this.tfUser.getText());
				if (this.tfUser.getText().Length < 8 || this.tfUser.getText().Length > 12 || (!this.tfUser.getText().StartsWith("0") && !this.tfUser.getText().StartsWith("84")))
				{
					text = mResources.phoneInvalid;
				}
				num = 1;
			}
			catch (Exception ex)
			{
				if (this.tfUser.getText().IndexOf("@") == -1 || this.tfUser.getText().IndexOf(".") == -1)
				{
					text = mResources.emailInvalid;
				}
				num = 0;
			}
		}
		if (text != null)
		{
			GameCanvas.startOKDlg(text);
		}
		else
		{
			GameCanvas.msgdlg.setInfo(string.Concat(new string[]
			{
				mResources.plsCheckAcc,
				(num != 1) ? (mResources.email + ": ") : (mResources.phone + ": "),
				this.tfUser.getText(),
				"\n",
				mResources.password,
				": ",
				this.tfPass.getText()
			}), new Command(mResources.ACCEPT, this, 4000, null), null, new Command(mResources.NO, GameCanvas.instance, 8882, null));
		}
		GameCanvas.currentDialog = GameCanvas.msgdlg;
	}

	// Token: 0x0600075D RID: 1885 RVA: 0x00066840 File Offset: 0x00064A40
	protected void doRegister(string user)
	{
		this.isFAQ = false;
		GameCanvas.startWaitDlg(mResources.CONNECTING);
		GameCanvas.connect();
		GameCanvas.startWaitDlg(mResources.REGISTERING);
		this.passRe = this.tfPass.getText();
		Service.gI().requestRegister(user, this.tfPass.getText(), Rms.loadRMSString("userAo" + ServerListScreen.ipSelect), Rms.loadRMSString("passAo" + ServerListScreen.ipSelect), GameMidlet.VERSION);
		Rms.saveRMSString("acc", user);
		Rms.saveRMSString("pass", this.tfPass.getText());
		this.t = 20;
		this.isRegistering = true;
	}

	// Token: 0x0600075E RID: 1886 RVA: 0x000668FC File Offset: 0x00064AFC
	public void doViewFAQ()
	{
		if (!this.listFAQ.Equals(string.Empty) || !this.listFAQ.Equals(string.Empty))
		{
		}
		if (!Session_ME.connected)
		{
			this.isFAQ = true;
			GameCanvas.connect();
		}
		GameCanvas.startWaitDlg();
	}

	// Token: 0x0600075F RID: 1887 RVA: 0x00066950 File Offset: 0x00064B50
	protected void doSelectServer()
	{
		MyVector myVector = new MyVector();
		if (LoginScr.isLocal)
		{
			myVector.addElement(new Command("Server LOCAL", this, 20004, null));
		}
		myVector.addElement(new Command("Server Bokken", this, 20001, null));
		myVector.addElement(new Command("Server Shuriken", this, 20002, null));
		myVector.addElement(new Command("Server Tessen (mới)", this, 20003, null));
		GameCanvas.menu.startAt(myVector, 0);
		if (this.loadIndexServer() != -1 && !GameCanvas.isTouch)
		{
			GameCanvas.menu.menuSelectedItem = this.loadIndexServer();
		}
	}

	// Token: 0x06000760 RID: 1888 RVA: 0x00006F6A File Offset: 0x0000516A
	protected void saveIndexServer(int index)
	{
		Rms.saveRMSInt("indServer", index);
	}

	// Token: 0x06000761 RID: 1889 RVA: 0x00006F77 File Offset: 0x00005177
	protected int loadIndexServer()
	{
		return Rms.loadRMSInt("indServer");
	}

	// Token: 0x06000762 RID: 1890 RVA: 0x000669FC File Offset: 0x00064BFC
	public void doLogin()
	{
		string text = Rms.loadRMSString("acc");
		string text2 = Rms.loadRMSString("pass");
		if (text != null && !text.Equals(string.Empty))
		{
			this.isLogin2 = false;
		}
		else if (Rms.loadRMSString("userAo" + ServerListScreen.ipSelect) != null && !Rms.loadRMSString("userAo" + ServerListScreen.ipSelect).Equals(string.Empty))
		{
			this.isLogin2 = true;
		}
		else
		{
			this.isLogin2 = false;
		}
		if ((text == null || text.Equals(string.Empty)) && this.isLogin2)
		{
			text = Rms.loadRMSString("userAo" + ServerListScreen.ipSelect);
			text2 = "a";
		}
		if (text == null || text2 == null || GameMidlet.VERSION == null || text.Equals(string.Empty))
		{
			return;
		}
		if (text2.Equals(string.Empty))
		{
			this.focus = 1;
			this.tfUser.isFocus = false;
			this.tfPass.isFocus = true;
			if (!GameCanvas.isTouch)
			{
				this.right = this.tfPass.cmdClear;
			}
			return;
		}
		GameCanvas.connect();
		Res.outz(string.Concat(new object[]
		{
			"ccccccc ",
			text,
			" ",
			text2,
			" ",
			GameMidlet.VERSION,
			" ",
			(!this.isLogin2) ? 0 : 1
		}));
		Service.gI().login(text, text2, GameMidlet.VERSION, (!this.isLogin2) ? 0 : 1);
		if (Session_ME.connected)
		{
			GameCanvas.startWaitDlg();
		}
		else
		{
			GameCanvas.startOKDlg(mResources.maychutathoacmatsong);
		}
		this.focus = 0;
		if (!this.isLogin2)
		{
			this.actRegisterLeft();
		}
	}

	// Token: 0x06000763 RID: 1891 RVA: 0x00066C08 File Offset: 0x00064E08
	public void savePass()
	{
		if (this.isCheck)
		{
			Rms.saveRMSInt("check", 1);
			Rms.saveRMSString("acc", this.tfUser.getText().ToLower().Trim());
			Rms.saveRMSString("pass", this.tfPass.getText().ToLower().Trim());
		}
		else
		{
			Rms.saveRMSInt("check", 2);
			Rms.saveRMSString("acc", string.Empty);
			Rms.saveRMSString("pass", string.Empty);
		}
	}

	// Token: 0x06000764 RID: 1892 RVA: 0x00066C98 File Offset: 0x00064E98
	public override void update()
	{
		if (Main.isWindowsPhone && this.isRegistering)
		{
			if (this.t < 0)
			{
				GameCanvas.endDlg();
				Session_ME.gI().close();
				GameCanvas.serverScreen.switchToMe();
				this.isRegistering = false;
			}
			else
			{
				this.t--;
			}
		}
		if (LoginScr.timeLogin > 0)
		{
			GameCanvas.startWaitDlg();
			LoginScr.currTimeLogin = mSystem.currentTimeMillis();
			if (LoginScr.currTimeLogin - LoginScr.lastTimeLogin >= 1000L)
			{
				LoginScr.timeLogin -= 1;
				if (LoginScr.timeLogin == 0)
				{
					Session_ME.gI().close();
					GameCanvas.loginScr.doLogin();
				}
				LoginScr.lastTimeLogin = LoginScr.currTimeLogin;
			}
		}
		if (this.isLogin2 && !this.isRes)
		{
			this.tfUser.name = (((int)mResources.language != 2) ? (mResources.phone + "/") : string.Empty) + mResources.email;
			this.tfPass.name = mResources.password;
			this.tfUser.isPaintCarret = false;
			this.tfPass.isPaintCarret = false;
			this.tfUser.update();
			this.tfPass.update();
		}
		else
		{
			this.tfUser.name = (((int)mResources.language != 2) ? (mResources.phone + "/") : string.Empty) + mResources.email;
			this.tfPass.name = mResources.password;
			this.tfUser.update();
			this.tfPass.update();
		}
		if (TouchScreenKeyboard.visible)
		{
			mGraphics.addYWhenOpenKeyBoard = 50;
		}
		for (int i = 0; i < Effect2.vEffect2.size(); i++)
		{
			Effect2 effect = (Effect2)Effect2.vEffect2.elementAt(i);
			effect.update();
		}
		if (LoginScr.isUpdateAll && !LoginScr.isUpdateData && !LoginScr.isUpdateItem && !LoginScr.isUpdateMap && !LoginScr.isUpdateSkill)
		{
			LoginScr.isUpdateAll = false;
			mSystem.gcc();
			Service.gI().finishUpdate();
		}
		GameScr.cmx++;
		if (GameScr.cmx > GameCanvas.w * 3 + 100)
		{
			GameScr.cmx = 100;
		}
		if (ChatPopup.currChatPopup != null)
		{
			return;
		}
		GameCanvas.debug("LGU1", 0);
		GameCanvas.debug("LGU2", 0);
		GameCanvas.debug("LGU3", 0);
		this.updateLogo();
		GameCanvas.debug("LGU4", 0);
		GameCanvas.debug("LGU5", 0);
		if (this.g >= 0)
		{
			this.ylogo += this.dir * this.g;
			this.g += this.dir * this.v;
			if (this.g <= 0)
			{
				this.dir *= -1;
			}
			if (this.ylogo > 0)
			{
				this.dir *= -1;
				this.g -= 2 * this.v;
			}
		}
		GameCanvas.debug("LGU6", 0);
		if (this.tipid >= 0 && GameCanvas.gameTick % 100 == 0)
		{
			this.doChangeTip();
		}
		if (this.isLogin2 && !this.isRes)
		{
			this.tfUser.isPaintCarret = false;
			this.tfPass.isPaintCarret = false;
			this.tfUser.update();
			this.tfPass.update();
		}
		else
		{
			this.tfUser.name = (((int)mResources.language != 2) ? (mResources.phone + "/") : string.Empty) + mResources.email;
			this.tfPass.name = mResources.password;
			this.tfUser.update();
			this.tfPass.update();
		}
		if (GameCanvas.isTouch)
		{
			if (this.isRes)
			{
				this.center = this.cmdRes;
				this.left = this.cmdBackFromRegister;
			}
			else
			{
				this.center = this.cmdOK;
				this.left = this.cmdFogetPass;
			}
		}
		else if (this.isRes)
		{
			this.center = this.cmdRes;
			this.left = this.cmdBackFromRegister;
		}
		else
		{
			this.center = this.cmdOK;
			this.left = this.cmdFogetPass;
		}
		if (!Main.isPC && !TouchScreenKeyboard.visible && !Main.isMiniApp && !Main.isWindowsPhone)
		{
			string text = this.tfUser.getText().ToLower().Trim();
			string text2 = this.tfPass.getText().ToLower().Trim();
			if (!text.Equals(string.Empty) && !text2.Equals(string.Empty))
			{
				this.doLogin();
			}
			Main.isMiniApp = true;
		}
		this.updateTfWhenOpenKb();
	}

	// Token: 0x06000765 RID: 1893 RVA: 0x000671BC File Offset: 0x000653BC
	private void doChangeTip()
	{
		this.tipid++;
		if (this.tipid >= mResources.tips.Length)
		{
			this.tipid = 0;
		}
		if (GameCanvas.currentDialog == GameCanvas.msgdlg && GameCanvas.msgdlg.isWait)
		{
			GameCanvas.msgdlg.setInfo(mResources.tips[this.tipid]);
		}
	}

	// Token: 0x06000766 RID: 1894 RVA: 0x00006F83 File Offset: 0x00005183
	public void updateLogo()
	{
		if (this.defYL != this.yL)
		{
			this.yL += this.defYL - this.yL >> 1;
		}
	}

	// Token: 0x06000767 RID: 1895 RVA: 0x00067224 File Offset: 0x00065424
	public override void keyPress(int keyCode)
	{
		if (this.tfUser.isFocus)
		{
			this.tfUser.keyPressed(keyCode);
		}
		else if (this.tfPass.isFocus)
		{
			this.tfPass.keyPressed(keyCode);
		}
		base.keyPress(keyCode);
	}

	// Token: 0x06000768 RID: 1896 RVA: 0x00006FB2 File Offset: 0x000051B2
	public override void unLoad()
	{
		base.unLoad();
	}

	// Token: 0x06000769 RID: 1897 RVA: 0x00067278 File Offset: 0x00065478
	public override void paint(mGraphics g)
	{
		GameCanvas.debug("PLG1", 1);
		GameCanvas.paintBGGameScr(g);
		GameCanvas.debug("PLG2", 2);
		int num = this.tfUser.y - 50;
		if (GameCanvas.h <= 220)
		{
			num += 5;
		}
		mFont.tahoma_7_white.drawString(g, "v" + GameMidlet.VERSION, GameCanvas.w - 2, 17, 1, mFont.tahoma_7_grey);
		if (mSystem.clientType == 1 && !GameCanvas.isTouch)
		{
			mFont.tahoma_7_white.drawString(g, ServerListScreen.linkweb, GameCanvas.w - 2, GameCanvas.h - 15, 1, mFont.tahoma_7_grey);
		}
		else
		{
			mFont.tahoma_7_white.drawString(g, ServerListScreen.linkweb, GameCanvas.w - 2, 2, 1, mFont.tahoma_7_grey);
		}
		if (ChatPopup.currChatPopup != null)
		{
			return;
		}
		if (ChatPopup.serverChatPopUp != null)
		{
			return;
		}
		if (GameCanvas.currentDialog == null)
		{
			int h = 105;
			int w = (GameCanvas.w < 200) ? 160 : 180;
			PopUp.paintPopUp(g, this.xLog, this.yLog - 10, w, h, -1, true);
			if (GameCanvas.h > 160 && LoginScr.imgTitle != null)
			{
				g.drawImage(LoginScr.imgTitle, GameCanvas.hw, num, 3);
			}
			GameCanvas.debug("PLG4", 1);
			int num2 = 4;
			int num3 = num2 * 32 + 23 + 33;
			if (num3 >= GameCanvas.w)
			{
				num2--;
				num3 = num2 * 32 + 23 + 33;
			}
			this.xLog = GameCanvas.w / 2 - num3 / 2;
			this.tfUser.x = this.xLog + 10;
			this.tfUser.y = this.yLog + 20;
			this.tfPass.x = this.xLog + 10;
			this.tfPass.y = this.yLog + 55;
			this.tfUser.paint(g);
			this.tfPass.paint(g);
			if (GameCanvas.w < 176)
			{
				mFont.tahoma_7b_green2.drawString(g, mResources.acc + ":", this.tfUser.x - 35, this.tfUser.y + 7, 0);
				mFont.tahoma_7b_green2.drawString(g, mResources.pwd + ":", this.tfPass.x - 35, this.tfPass.y + 7, 0);
				mFont.tahoma_7b_green2.drawString(g, mResources.server + ":" + LoginScr.serverName, GameCanvas.w / 2, this.tfPass.y + 32, 2);
			}
		}
		base.paint(g);
	}

	// Token: 0x0600076A RID: 1898 RVA: 0x00067544 File Offset: 0x00065744
	public override void updateKey()
	{
		if (GameCanvas.isTouch)
		{
			if (this.cmdCallHotline != null && this.cmdCallHotline.isPointerPressInside())
			{
				this.cmdCallHotline.performAction();
			}
		}
		else if (mSystem.clientType == 1 && GameCanvas.keyPressed[13])
		{
			GameCanvas.keyPressed[13] = false;
			this.cmdCallHotline.performAction();
		}
		if (LoginScr.isContinueToLogin)
		{
			return;
		}
		if (!GameCanvas.isTouch)
		{
			if (this.tfUser.isFocus)
			{
				this.right = this.tfUser.cmdClear;
			}
			else
			{
				this.right = this.tfPass.cmdClear;
			}
		}
		if (GameCanvas.keyPressed[(!Main.isPC) ? 2 : 21])
		{
			this.focus--;
			if (this.focus < 0)
			{
				this.focus = 1;
			}
		}
		else if (GameCanvas.keyPressed[(!Main.isPC) ? 8 : 22] || GameCanvas.keyPressed[16])
		{
			this.focus++;
			if (this.focus > 1)
			{
				this.focus = 0;
			}
		}
		if (GameCanvas.keyPressed[(!Main.isPC) ? 2 : 21] || GameCanvas.keyPressed[(!Main.isPC) ? 8 : 22] || GameCanvas.keyPressed[16])
		{
			GameCanvas.clearKeyPressed();
			if (!this.isLogin2 || this.isRes)
			{
				if (this.focus == 1)
				{
					this.tfUser.isFocus = false;
					this.tfPass.isFocus = true;
				}
				else if (this.focus == 0)
				{
					this.tfUser.isFocus = true;
					this.tfPass.isFocus = false;
				}
				else
				{
					this.tfUser.isFocus = false;
					this.tfPass.isFocus = false;
				}
			}
		}
		if (GameCanvas.isTouch)
		{
			if (this.isRes)
			{
				this.center = this.cmdRes;
				this.left = this.cmdBackFromRegister;
			}
			else
			{
				this.center = this.cmdOK;
				this.left = this.cmdFogetPass;
			}
		}
		else if (this.isRes)
		{
			this.center = this.cmdRes;
			this.left = this.cmdBackFromRegister;
		}
		else
		{
			this.center = this.cmdOK;
			this.left = this.cmdFogetPass;
		}
		if (GameCanvas.isPointerJustRelease)
		{
			if (!this.isLogin2 || this.isRes)
			{
				if (GameCanvas.isPointerHoldIn(this.tfUser.x, this.tfUser.y, this.tfUser.width, this.tfUser.height))
				{
					this.focus = 0;
				}
				else if (GameCanvas.isPointerHoldIn(this.tfPass.x, this.tfPass.y, this.tfPass.width, this.tfPass.height))
				{
					this.focus = 1;
				}
			}
		}
		if (Main.isPC && GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] && this.right != null)
		{
			this.right.performAction();
		}
		base.updateKey();
		GameCanvas.clearKeyPressed();
	}

	// Token: 0x0600076B RID: 1899 RVA: 0x00006FBA File Offset: 0x000051BA
	public void resetLogo()
	{
		this.yL = -50;
	}

	// Token: 0x0600076C RID: 1900 RVA: 0x000678D8 File Offset: 0x00065AD8
	public void perform(int idAction, object p)
	{
		switch (idAction)
		{
		case 1000:
			try
			{
				GameMidlet.instance.platformRequest((string)p);
			}
			catch (Exception ex)
			{
			}
			GameCanvas.endDlg();
			break;
		case 1001:
			GameCanvas.endDlg();
			this.isRes = false;
			break;
		case 1002:
		{
			GameCanvas.startWaitDlg();
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
			break;
		}
		case 1003:
			GameCanvas.startOKDlg(mResources.goToWebForPassword);
			break;
		case 1004:
			ServerListScreen.doUpdateServer();
			GameCanvas.serverScreen.switchToMe();
			break;
		case 1005:
			try
			{
				GameMidlet.instance.platformRequest("http://ngocrongonline.com");
			}
			catch (Exception ex2)
			{
			}
			break;
		default:
			switch (idAction)
			{
			case 2000:
				break;
			case 2001:
				if (this.isCheck)
				{
					this.isCheck = false;
				}
				else
				{
					this.isCheck = true;
				}
				break;
			case 2002:
				this.doRegister();
				break;
			case 2003:
				this.doMenu();
				break;
			case 2004:
				this.actRegister();
				break;
			default:
				if (idAction != 10041)
				{
					if (idAction != 10042)
					{
						if (idAction != 13)
						{
							if (idAction != 4000)
							{
								if (idAction == 10021)
								{
									this.actRegisterLeft();
								}
							}
							else
							{
								this.doRegister(this.tfUser.getText());
							}
						}
						else
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
					}
					else
					{
						Rms.saveRMSInt("lowGraphic", 1);
						GameCanvas.startOK(mResources.plsRestartGame, 8885, null);
					}
				}
				else
				{
					Rms.saveRMSInt("lowGraphic", 0);
					GameCanvas.startOK(mResources.plsRestartGame, 8885, null);
				}
				break;
			case 2008:
				Rms.saveRMSString("acc", this.tfUser.getText().Trim());
				Rms.saveRMSString("pass", this.tfPass.getText().Trim());
				if (ServerListScreen.loadScreen)
				{
					GameCanvas.serverScreen.switchToMe();
				}
				else
				{
					GameCanvas.serverScreen.show2();
				}
				break;
			}
			break;
		}
	}

	// Token: 0x0600076D RID: 1901 RVA: 0x00006FC4 File Offset: 0x000051C4
	public void actRegisterLeft()
	{
		if (this.isLogin2)
		{
			this.doLogin();
			return;
		}
		this.isRes = false;
		this.tfPass.isFocus = false;
		this.tfUser.isFocus = true;
		this.left = this.cmdMenu;
	}

	// Token: 0x0600076E RID: 1902 RVA: 0x00007003 File Offset: 0x00005203
	public void actRegister()
	{
		GameCanvas.endDlg();
		this.isRes = true;
		this.tfPass.isFocus = false;
		this.tfUser.isFocus = true;
	}

	// Token: 0x0600076F RID: 1903 RVA: 0x00067BE4 File Offset: 0x00065DE4
	public void backToRegister()
	{
		if (GameCanvas.loginScr.isLogin2)
		{
			GameCanvas.startYesNoDlg(mResources.note, new Command(mResources.YES, GameCanvas.panel, 10019, null), new Command(mResources.NO, GameCanvas.panel, 10020, null));
			return;
		}
		if (Main.isWindowsPhone)
		{
			GameMidlet.isBackWindowsPhone = true;
		}
		GameCanvas.instance.resetToLoginScr = false;
		GameCanvas.instance.doResetToLoginScr(GameCanvas.loginScr);
		Session_ME.gI().close();
	}

	// Token: 0x04000DB1 RID: 3505
	public TField tfUser;

	// Token: 0x04000DB2 RID: 3506
	public TField tfPass;

	// Token: 0x04000DB3 RID: 3507
	public static bool isContinueToLogin = false;

	// Token: 0x04000DB4 RID: 3508
	private int focus;

	// Token: 0x04000DB5 RID: 3509
	private int wC;

	// Token: 0x04000DB6 RID: 3510
	private int yL;

	// Token: 0x04000DB7 RID: 3511
	private int defYL;

	// Token: 0x04000DB8 RID: 3512
	public bool isCheck;

	// Token: 0x04000DB9 RID: 3513
	public bool isRes;

	// Token: 0x04000DBA RID: 3514
	public Command cmdLogin;

	// Token: 0x04000DBB RID: 3515
	public Command cmdCheck;

	// Token: 0x04000DBC RID: 3516
	public Command cmdFogetPass;

	// Token: 0x04000DBD RID: 3517
	public Command cmdRes;

	// Token: 0x04000DBE RID: 3518
	public Command cmdMenu;

	// Token: 0x04000DBF RID: 3519
	public Command cmdBackFromRegister;

	// Token: 0x04000DC0 RID: 3520
	public string listFAQ = string.Empty;

	// Token: 0x04000DC1 RID: 3521
	public string titleFAQ;

	// Token: 0x04000DC2 RID: 3522
	public string subtitleFAQ;

	// Token: 0x04000DC3 RID: 3523
	private string numSupport = string.Empty;

	// Token: 0x04000DC4 RID: 3524
	public static bool isLocal = false;

	// Token: 0x04000DC5 RID: 3525
	public static bool isUpdateAll;

	// Token: 0x04000DC6 RID: 3526
	public static bool isUpdateData;

	// Token: 0x04000DC7 RID: 3527
	public static bool isUpdateMap;

	// Token: 0x04000DC8 RID: 3528
	public static bool isUpdateSkill;

	// Token: 0x04000DC9 RID: 3529
	public static bool isUpdateItem;

	// Token: 0x04000DCA RID: 3530
	public static string serverName;

	// Token: 0x04000DCB RID: 3531
	public static Image imgTitle;

	// Token: 0x04000DCC RID: 3532
	public int plX;

	// Token: 0x04000DCD RID: 3533
	public int plY;

	// Token: 0x04000DCE RID: 3534
	public int lY;

	// Token: 0x04000DCF RID: 3535
	public int lX;

	// Token: 0x04000DD0 RID: 3536
	public int logoDes;

	// Token: 0x04000DD1 RID: 3537
	public int lineX;

	// Token: 0x04000DD2 RID: 3538
	public int lineY;

	// Token: 0x04000DD3 RID: 3539
	public static int[] bgId = new int[]
	{
		0,
		8,
		2,
		6,
		9
	};

	// Token: 0x04000DD4 RID: 3540
	public static bool isTryGetIPFromWap;

	// Token: 0x04000DD5 RID: 3541
	public static short timeLogin;

	// Token: 0x04000DD6 RID: 3542
	public static long lastTimeLogin;

	// Token: 0x04000DD7 RID: 3543
	public static long currTimeLogin;

	// Token: 0x04000DD8 RID: 3544
	private int yt;

	// Token: 0x04000DD9 RID: 3545
	private Command cmdSelect;

	// Token: 0x04000DDA RID: 3546
	private Command cmdOK;

	// Token: 0x04000DDB RID: 3547
	private int xLog;

	// Token: 0x04000DDC RID: 3548
	private int yLog;

	// Token: 0x04000DDD RID: 3549
	public static GameMidlet m;

	// Token: 0x04000DDE RID: 3550
	private int yy = GameCanvas.hh - mScreen.ITEM_HEIGHT - 5;

	// Token: 0x04000DDF RID: 3551
	private int freeAreaHeight;

	// Token: 0x04000DE0 RID: 3552
	private int xP;

	// Token: 0x04000DE1 RID: 3553
	private int yP;

	// Token: 0x04000DE2 RID: 3554
	private int wP;

	// Token: 0x04000DE3 RID: 3555
	private int hP;

	// Token: 0x04000DE4 RID: 3556
	private int t = 20;

	// Token: 0x04000DE5 RID: 3557
	private bool isRegistering;

	// Token: 0x04000DE6 RID: 3558
	private string passRe = string.Empty;

	// Token: 0x04000DE7 RID: 3559
	public bool isFAQ;

	// Token: 0x04000DE8 RID: 3560
	private int tipid = -1;

	// Token: 0x04000DE9 RID: 3561
	public bool isLogin2;

	// Token: 0x04000DEA RID: 3562
	private int v = 2;

	// Token: 0x04000DEB RID: 3563
	private int g;

	// Token: 0x04000DEC RID: 3564
	private int ylogo = -40;

	// Token: 0x04000DED RID: 3565
	private int dir = 1;

	// Token: 0x04000DEE RID: 3566
	private Command cmdCallHotline;

	// Token: 0x04000DEF RID: 3567
	public static bool isLoggingIn;
}
