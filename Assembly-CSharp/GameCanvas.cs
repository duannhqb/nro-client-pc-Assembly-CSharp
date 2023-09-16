using System;
using Assets.src.g;
using UnityEngine;

// Token: 0x020000C2 RID: 194
public class GameCanvas : IActionListener
{
	// Token: 0x06000974 RID: 2420 RVA: 0x0008C578 File Offset: 0x0008A778
	public GameCanvas()
	{
		int num = Rms.loadRMSInt("languageVersion");
		if (num == -1)
		{
			Rms.saveRMSInt("languageVersion", 2);
		}
		else if (num != 2)
		{
			Main.main.doClearRMS();
			Rms.saveRMSInt("languageVersion", 2);
		}
		GameCanvas.clearOldData = Rms.loadRMSInt(GameMidlet.VERSION);
		if (GameCanvas.clearOldData != 1)
		{
			Main.main.doClearRMS();
			Rms.saveRMSInt(GameMidlet.VERSION, 1);
		}
		this.initGame();
	}

	// Token: 0x06000975 RID: 2421 RVA: 0x00007C70 File Offset: 0x00005E70
	public static string getPlatformName()
	{
		return "Pc platform xxx";
	}

	// Token: 0x06000976 RID: 2422 RVA: 0x0008C610 File Offset: 0x0008A810
	public void initGame()
	{
		MotherCanvas.instance.setChildCanvas(this);
		GameCanvas.w = MotherCanvas.instance.getWidthz();
		GameCanvas.h = MotherCanvas.instance.getHeightz();
		GameCanvas.hw = GameCanvas.w / 2;
		GameCanvas.hh = GameCanvas.h / 2;
		GameCanvas.isTouch = true;
		if (GameCanvas.w >= 240)
		{
			GameCanvas.isTouchControl = true;
		}
		if (GameCanvas.w < 320)
		{
			GameCanvas.isTouchControlSmallScreen = true;
		}
		if (GameCanvas.w >= 320)
		{
			GameCanvas.isTouchControlLargeScreen = true;
		}
		GameCanvas.msgdlg = new MsgDlg();
		if (GameCanvas.h <= 160)
		{
			Paint.hTab = 15;
			mScreen.cmdH = 17;
		}
		GameScr.d = ((GameCanvas.w <= GameCanvas.h) ? GameCanvas.h : GameCanvas.w) + 20;
		GameCanvas.instance = this;
		mFont.init();
		mScreen.ITEM_HEIGHT = mFont.tahoma_8b.getHeight() + 8;
		this.initPaint();
		this.loadDust();
		this.loadWaterSplash();
		GameCanvas.panel = new Panel();
		GameCanvas.imgShuriken = GameCanvas.loadImage("/mainImage/myTexture2df.png");
		int num = Rms.loadRMSInt("clienttype");
		if (num != -1)
		{
			if (num > 7)
			{
				Rms.saveRMSInt("clienttype", mSystem.clientType);
			}
			else
			{
				mSystem.clientType = num;
			}
		}
		if (mSystem.clientType == 7 && (Rms.loadRMSString("fake") == null || Rms.loadRMSString("fake") == string.Empty))
		{
			GameCanvas.imgShuriken = GameCanvas.loadImage("/mainImage/wait.png");
		}
		GameCanvas.imgClear = GameCanvas.loadImage("/mainImage/myTexture2der.png");
		GameCanvas.img12 = GameCanvas.loadImage("/mainImage/12+.png");
		GameCanvas.debugUpdate = new MyVector();
		GameCanvas.debugPaint = new MyVector();
		GameCanvas.debugSession = new MyVector();
		for (int i = 0; i < 3; i++)
		{
			GameCanvas.imgBorder[i] = GameCanvas.loadImage("/mainImage/myTexture2dbd" + i + ".png");
		}
		GameCanvas.borderConnerW = mGraphics.getImageWidth(GameCanvas.imgBorder[0]);
		GameCanvas.borderConnerH = mGraphics.getImageHeight(GameCanvas.imgBorder[0]);
		GameCanvas.borderCenterW = mGraphics.getImageWidth(GameCanvas.imgBorder[1]);
		GameCanvas.borderCenterH = mGraphics.getImageHeight(GameCanvas.imgBorder[1]);
		Panel.graphics = Rms.loadRMSInt("lowGraphic");
		GameCanvas.lowGraphic = (Rms.loadRMSInt("lowGraphic") == 1);
		GameScr.isPaintChatVip = (Rms.loadRMSInt("serverchat") != 1);
		global::Char.isPaintAura = (Rms.loadRMSInt("isPaintAura") == 1);
		Res.init();
		SmallImage.loadBigImage();
		Panel.WIDTH_PANEL = 176;
		if (Panel.WIDTH_PANEL > GameCanvas.w)
		{
			Panel.WIDTH_PANEL = GameCanvas.w;
		}
		InfoMe.gI().loadCharId();
		Command.btn0left = GameCanvas.loadImage("/mainImage/btn0left.png");
		Command.btn0mid = GameCanvas.loadImage("/mainImage/btn0mid.png");
		Command.btn0right = GameCanvas.loadImage("/mainImage/btn0right.png");
		Command.btn1left = GameCanvas.loadImage("/mainImage/btn1left.png");
		Command.btn1mid = GameCanvas.loadImage("/mainImage/btn1mid.png");
		Command.btn1right = GameCanvas.loadImage("/mainImage/btn1right.png");
		GameCanvas.serverScreen = new ServerListScreen();
		GameCanvas.img12 = GameCanvas.loadImage("/mainImage/12+.png");
		for (int j = 0; j < 7; j++)
		{
			GameCanvas.imgBlue[j] = GameCanvas.loadImage("/effectdata/blue/" + j + ".png");
			GameCanvas.imgViolet[j] = GameCanvas.loadImage("/effectdata/violet/" + j + ".png");
		}
		ServerListScreen.createDeleteRMS();
		GameCanvas.serverScr = new ServerScr();
	}

	// Token: 0x06000977 RID: 2423 RVA: 0x00007C77 File Offset: 0x00005E77
	public static GameCanvas gI()
	{
		return GameCanvas.instance;
	}

	// Token: 0x06000978 RID: 2424 RVA: 0x00007C7E File Offset: 0x00005E7E
	public void initPaint()
	{
		GameCanvas.paintz = new Paint();
	}

	// Token: 0x06000979 RID: 2425 RVA: 0x00007C8A File Offset: 0x00005E8A
	public static void closeKeyBoard()
	{
		mGraphics.addYWhenOpenKeyBoard = 0;
		GameCanvas.timeOpenKeyBoard = 0;
		Main.closeKeyBoard();
	}

	// Token: 0x0600097A RID: 2426 RVA: 0x0008C9D0 File Offset: 0x0008ABD0
	public void update()
	{
		if (GameCanvas.gameTick % 5 == 0)
		{
			GameCanvas.timeNow = mSystem.currentTimeMillis();
		}
		Res.updateOnScreenDebug();
		try
		{
			if (global::TouchScreenKeyboard.visible)
			{
				GameCanvas.timeOpenKeyBoard++;
				if (GameCanvas.timeOpenKeyBoard > ((!Main.isWindowsPhone) ? 10 : 5))
				{
					mGraphics.addYWhenOpenKeyBoard = 94;
				}
			}
			else
			{
				mGraphics.addYWhenOpenKeyBoard = 0;
				GameCanvas.timeOpenKeyBoard = 0;
			}
			GameCanvas.debugUpdate.removeAllElements();
			long num = mSystem.currentTimeMillis();
			if (num - GameCanvas.timeTickEff1 >= 780L && !GameCanvas.isEff1)
			{
				GameCanvas.timeTickEff1 = num;
				GameCanvas.isEff1 = true;
			}
			else
			{
				GameCanvas.isEff1 = false;
			}
			if (num - GameCanvas.timeTickEff2 >= 7800L && !GameCanvas.isEff2)
			{
				GameCanvas.timeTickEff2 = num;
				GameCanvas.isEff2 = true;
			}
			else
			{
				GameCanvas.isEff2 = false;
			}
			if (GameCanvas.taskTick > 0)
			{
				GameCanvas.taskTick--;
			}
			GameCanvas.gameTick++;
			if (GameCanvas.gameTick > 10000)
			{
				if (mSystem.currentTimeMillis() - GameCanvas.lastTimePress > 20000L && GameCanvas.currentScreen == GameCanvas.loginScr)
				{
					GameMidlet.instance.exit();
				}
				GameCanvas.gameTick = 0;
			}
			if (GameCanvas.currentScreen != null)
			{
				if (ChatPopup.serverChatPopUp != null)
				{
					ChatPopup.serverChatPopUp.update();
					ChatPopup.serverChatPopUp.updateKey();
				}
				else if (ChatPopup.currChatPopup != null)
				{
					ChatPopup.currChatPopup.update();
					ChatPopup.currChatPopup.updateKey();
				}
				else if (GameCanvas.currentDialog != null)
				{
					GameCanvas.debug("B", 0);
					GameCanvas.currentDialog.update();
				}
				else if (GameCanvas.menu.showMenu)
				{
					GameCanvas.debug("C", 0);
					GameCanvas.menu.updateMenu();
					GameCanvas.debug("D", 0);
					GameCanvas.menu.updateMenuKey();
				}
				else if (GameCanvas.panel.isShow)
				{
					GameCanvas.panel.update();
					if (GameCanvas.panel2 != null)
					{
						if (GameCanvas.isFocusPanel2)
						{
							GameCanvas.panel2.updateKey();
						}
						else
						{
							GameCanvas.panel.updateKey();
						}
						if (GameCanvas.panel2.isShow)
						{
							GameCanvas.panel2.update();
							if (GameCanvas.isPointer(GameCanvas.panel2.X, GameCanvas.panel2.Y, GameCanvas.panel2.W, GameCanvas.panel2.H))
							{
								GameCanvas.panel2.updateKey();
							}
						}
					}
					else
					{
						GameCanvas.panel.updateKey();
					}
					if (GameCanvas.panel.chatTField != null && GameCanvas.panel.chatTField.isShow)
					{
						GameCanvas.panel.chatTFUpdateKey();
					}
					else if (GameCanvas.panel2 != null && GameCanvas.panel2.chatTField != null && GameCanvas.panel2.chatTField.isShow)
					{
						GameCanvas.panel2.chatTFUpdateKey();
					}
					if (GameCanvas.isPointer(GameCanvas.panel.X + GameCanvas.panel.W, GameCanvas.panel.Y, GameCanvas.w - GameCanvas.panel.W * 2, GameCanvas.panel.H) && GameCanvas.isPointerJustRelease && GameCanvas.panel.isDoneCombine)
					{
						GameCanvas.panel.hide();
					}
				}
				GameCanvas.debug("E", 0);
				if (!GameCanvas.isLoading)
				{
					GameCanvas.currentScreen.update();
				}
				GameCanvas.debug("F", 0);
				if (!GameCanvas.panel.isShow && ChatPopup.serverChatPopUp == null)
				{
					GameCanvas.currentScreen.updateKey();
				}
				Hint.update();
				SoundMn.gI().update();
			}
			GameCanvas.debug("Ix", 0);
			Timer.update();
			GameCanvas.debug("Hx", 0);
			InfoDlg.update();
			GameCanvas.debug("G", 0);
			if (this.resetToLoginScr)
			{
				this.resetToLoginScr = false;
				this.doResetToLoginScr(GameCanvas.serverScreen);
			}
			GameCanvas.debug("Zzz", 0);
			if (Controller.isConnectOK)
			{
				if (Controller.isMain)
				{
					GameMidlet.IP = ServerListScreen.address[ServerListScreen.ipSelect];
					GameMidlet.PORT = (int)ServerListScreen.port[ServerListScreen.ipSelect];
					Cout.println("Connect ok");
					ServerListScreen.testConnect = 2;
					Rms.saveRMSInt("svselect", ServerListScreen.ipSelect);
					Rms.saveIP(GameMidlet.IP + ":" + GameMidlet.PORT);
					Service.gI().setClientType();
					Service.gI().androidPack();
				}
				else
				{
					Service.gI().setClientType2();
					Service.gI().androidPack2();
				}
				Controller.isConnectOK = false;
			}
			if (Controller.isDisconnected)
			{
				Debug.Log("disconnect");
				if (!Controller.isMain)
				{
					if (GameCanvas.currentScreen == GameCanvas.serverScreen && !Service.reciveFromMainSession)
					{
						GameCanvas.serverScreen.cancel();
					}
					if (GameCanvas.currentScreen == GameCanvas.loginScr && !Service.reciveFromMainSession)
					{
						this.onDisconnected();
					}
				}
				else
				{
					this.onDisconnected();
				}
				Controller.isDisconnected = false;
			}
			if (Controller.isConnectionFail)
			{
				Debug.Log("connect fail");
				if (!Controller.isMain)
				{
					if (GameCanvas.currentScreen == GameCanvas.serverScreen && ServerListScreen.isGetData && !Service.reciveFromMainSession)
					{
						GameCanvas.serverScreen.cancel();
					}
					if (GameCanvas.currentScreen == GameCanvas.loginScr && !Service.reciveFromMainSession)
					{
						this.onConnectionFail();
					}
				}
				else
				{
					this.onConnectionFail();
				}
				Controller.isConnectionFail = false;
			}
			if (Main.isResume)
			{
				Main.isResume = false;
				if (GameCanvas.currentDialog != null && GameCanvas.currentDialog.left != null && GameCanvas.currentDialog.left.actionListener != null)
				{
					GameCanvas.currentDialog.left.performAction();
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x0600097B RID: 2427 RVA: 0x0008D000 File Offset: 0x0008B200
	public void onDisconnected()
	{
		if (Controller.isConnectionFail)
		{
			Controller.isConnectionFail = false;
		}
		GameCanvas.isResume = true;
		Session_ME.gI().clearSendingMessage();
		Session_ME2.gI().clearSendingMessage();
		if (Controller.isLoadingData)
		{
			GameCanvas.instance.resetToLoginScrz();
			GameCanvas.startOK(mResources.pls_restart_game_error, 8885, null);
			Controller.isDisconnected = false;
			return;
		}
		global::Char.isLoadingMap = false;
		if (Controller.isMain)
		{
			ServerListScreen.testConnect = 0;
		}
		GameCanvas.instance.resetToLoginScrz();
		if (Main.typeClient == 6)
		{
			if (GameCanvas.currentScreen != GameCanvas.serverScreen && GameCanvas.currentScreen != GameCanvas.loginScr)
			{
				GameCanvas.startOKDlg(mResources.maychutathoacmatsong);
			}
		}
		else
		{
			GameCanvas.startOKDlg(mResources.maychutathoacmatsong);
		}
		mSystem.endKey();
	}

	// Token: 0x0600097C RID: 2428 RVA: 0x0008D0CC File Offset: 0x0008B2CC
	public void onConnectionFail()
	{
		if (GameCanvas.currentScreen.Equals(SplashScr.instance))
		{
			if (ServerListScreen.hasConnected != null)
			{
				if (!ServerListScreen.hasConnected[0])
				{
					ServerListScreen.hasConnected[0] = true;
					ServerListScreen.ipSelect = 0;
					GameMidlet.IP = ServerListScreen.address[ServerListScreen.ipSelect];
					Rms.saveRMSInt("svselect", ServerListScreen.ipSelect);
					GameCanvas.connect();
				}
				else if (!ServerListScreen.hasConnected[2])
				{
					ServerListScreen.hasConnected[2] = true;
					ServerListScreen.ipSelect = 2;
					GameMidlet.IP = ServerListScreen.address[ServerListScreen.ipSelect];
					Rms.saveRMSInt("svselect", ServerListScreen.ipSelect);
					GameCanvas.connect();
				}
				else
				{
					GameCanvas.startOK(mResources.pls_restart_game_error, 8885, null);
				}
			}
			else
			{
				GameCanvas.startOK(mResources.pls_restart_game_error, 8885, null);
			}
			return;
		}
		Session_ME.gI().clearSendingMessage();
		Session_ME2.gI().clearSendingMessage();
		ServerListScreen.isWait = false;
		if (Controller.isLoadingData)
		{
			GameCanvas.startOK(mResources.pls_restart_game_error, 8885, null);
			Controller.isConnectionFail = false;
			return;
		}
		GameCanvas.isResume = true;
		LoginScr.isContinueToLogin = false;
		if (GameCanvas.loginScr != null)
		{
			GameCanvas.instance.resetToLoginScrz();
		}
		else
		{
			GameCanvas.loginScr = new LoginScr();
		}
		LoginScr.serverName = ServerListScreen.nameServer[ServerListScreen.ipSelect];
		if (GameCanvas.currentScreen != GameCanvas.serverScreen)
		{
			GameCanvas.startOK(mResources.lost_connection + LoginScr.serverName, 888395, null);
		}
		else
		{
			GameCanvas.endDlg();
		}
		global::Char.isLoadingMap = false;
		if (Controller.isMain)
		{
			ServerListScreen.testConnect = 0;
		}
		mSystem.endKey();
	}

	// Token: 0x0600097D RID: 2429 RVA: 0x0008D26C File Offset: 0x0008B46C
	public static bool isWaiting()
	{
		return InfoDlg.isShow || (GameCanvas.msgdlg != null && GameCanvas.msgdlg.info.Equals(mResources.PLEASEWAIT)) || global::Char.isLoadingMap || LoginScr.isContinueToLogin;
	}

	// Token: 0x0600097E RID: 2430 RVA: 0x00007C9D File Offset: 0x00005E9D
	public static void connect()
	{
		if (!Session_ME.gI().isConnected())
		{
			Session_ME.gI().connect(GameMidlet.IP, GameMidlet.PORT);
		}
	}

	// Token: 0x0600097F RID: 2431 RVA: 0x0008D2C0 File Offset: 0x0008B4C0
	public static void connect2()
	{
		if (!Session_ME2.gI().isConnected())
		{
			Res.outz(string.Concat(new object[]
			{
				"IP2= ",
				GameMidlet.IP2,
				" PORT 2= ",
				GameMidlet.PORT2
			}));
			Session_ME2.gI().connect(GameMidlet.IP2, GameMidlet.PORT2);
		}
	}

	// Token: 0x06000980 RID: 2432 RVA: 0x00007CC2 File Offset: 0x00005EC2
	public static void resetTrans(mGraphics g)
	{
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
	}

	// Token: 0x06000981 RID: 2433 RVA: 0x0008D328 File Offset: 0x0008B528
	public void initGameCanvas()
	{
		GameCanvas.debug("SP2i1", 0);
		GameCanvas.w = MotherCanvas.instance.getWidthz();
		GameCanvas.h = MotherCanvas.instance.getHeightz();
		GameCanvas.debug("SP2i2", 0);
		GameCanvas.hw = GameCanvas.w / 2;
		GameCanvas.hh = GameCanvas.h / 2;
		GameCanvas.wd3 = GameCanvas.w / 3;
		GameCanvas.hd3 = GameCanvas.h / 3;
		GameCanvas.w2d3 = 2 * GameCanvas.w / 3;
		GameCanvas.h2d3 = 2 * GameCanvas.h / 3;
		GameCanvas.w3d4 = 3 * GameCanvas.w / 4;
		GameCanvas.h3d4 = 3 * GameCanvas.h / 4;
		GameCanvas.wd6 = GameCanvas.w / 6;
		GameCanvas.hd6 = GameCanvas.h / 6;
		GameCanvas.debug("SP2i3", 0);
		mScreen.initPos();
		GameCanvas.debug("SP2i4", 0);
		GameCanvas.debug("SP2i5", 0);
		GameCanvas.inputDlg = new InputDlg();
		GameCanvas.debug("SP2i6", 0);
		GameCanvas.listPoint = new MyVector();
		GameCanvas.debug("SP2i7", 0);
	}

	// Token: 0x06000982 RID: 2434 RVA: 0x00003984 File Offset: 0x00001B84
	public void start()
	{
	}

	// Token: 0x06000983 RID: 2435 RVA: 0x00007CEA File Offset: 0x00005EEA
	public int getWidth()
	{
		return (int)ScaleGUI.WIDTH;
	}

	// Token: 0x06000984 RID: 2436 RVA: 0x00007CF2 File Offset: 0x00005EF2
	public int getHeight()
	{
		return (int)ScaleGUI.HEIGHT;
	}

	// Token: 0x06000985 RID: 2437 RVA: 0x00003984 File Offset: 0x00001B84
	public static void debug(string s, int type)
	{
	}

	// Token: 0x06000986 RID: 2438 RVA: 0x0008D43C File Offset: 0x0008B63C
	public void doResetToLoginScr(mScreen screen)
	{
		try
		{
			SoundMn.gI().stopAll();
			LoginScr.isContinueToLogin = false;
			TileMap.lastType = (TileMap.bgType = 0);
			global::Char.clearMyChar();
			GameScr.clearGameScr();
			GameScr.resetAllvector();
			InfoDlg.hide();
			GameScr.info1.hide();
			GameScr.info2.hide();
			GameScr.info2.cmdChat = null;
			Hint.isShow = false;
			ChatPopup.currChatPopup = null;
			Controller.isStopReadMessage = false;
			GameScr.loadCamera(true, -1, -1);
			GameScr.cmx = 100;
			GameCanvas.panel.currentTabIndex = 0;
			GameCanvas.panel.selected = ((!GameCanvas.isTouch) ? 0 : -1);
			GameCanvas.panel.init();
			GameCanvas.panel2 = null;
			GameScr.isPaint = true;
			ClanMessage.vMessage.removeAllElements();
			GameScr.textTime.removeAllElements();
			GameScr.vClan.removeAllElements();
			GameScr.vFriend.removeAllElements();
			GameScr.vEnemies.removeAllElements();
			TileMap.vCurrItem.removeAllElements();
			BackgroudEffect.vBgEffect.removeAllElements();
			EffecMn.vEff.removeAllElements();
			Effect.newEff.removeAllElements();
			GameCanvas.menu.showMenu = false;
			GameCanvas.panel.vItemCombine.removeAllElements();
			GameCanvas.panel.isShow = false;
			if (GameCanvas.panel.tabIcon != null)
			{
				GameCanvas.panel.tabIcon.isShow = false;
			}
			if (mGraphics.zoomLevel == 1)
			{
				SmallImage.clearHastable();
			}
			Session_ME.gI().close();
			Session_ME2.gI().close();
			screen.switchToMe();
		}
		catch (Exception ex)
		{
			Cout.println("Loi tai doResetToLoginScr " + ex.ToString());
		}
	}

	// Token: 0x06000987 RID: 2439 RVA: 0x00003984 File Offset: 0x00001B84
	public static void showErrorForm(int type, string moreInfo)
	{
	}

	// Token: 0x06000988 RID: 2440 RVA: 0x00003984 File Offset: 0x00001B84
	public static void paintCloud(mGraphics g)
	{
	}

	// Token: 0x06000989 RID: 2441 RVA: 0x00003984 File Offset: 0x00001B84
	public static void updateBG()
	{
	}

	// Token: 0x0600098A RID: 2442 RVA: 0x0008D5FC File Offset: 0x0008B7FC
	public static void fillRect(mGraphics g, int color, int x, int y, int w, int h, int detalY)
	{
		g.setColor(color);
		int cmy = GameScr.cmy;
		if (cmy > GameCanvas.h)
		{
			cmy = GameCanvas.h;
		}
		g.fillRect(x, y - ((detalY == 0) ? 0 : (cmy >> detalY)), w, h + ((detalY == 0) ? 0 : (cmy >> detalY)));
	}

	// Token: 0x0600098B RID: 2443 RVA: 0x0008D660 File Offset: 0x0008B860
	public static void paintBackgroundtLayer(mGraphics g, int layer, int deltaY, int color1, int color2)
	{
		try
		{
			int num = layer - 1;
			if (num == GameCanvas.imgBG.Length - 1 && (GameScr.gI().isRongThanXuatHien || GameScr.gI().isFireWorks))
			{
				g.setColor(GameScr.gI().mautroi);
				g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
				if (GameCanvas.typeBg == 2 || GameCanvas.typeBg == 4 || GameCanvas.typeBg == 7)
				{
					GameCanvas.drawSun1(g);
					GameCanvas.drawSun2(g);
				}
				if (GameScr.gI().isFireWorks && !GameCanvas.lowGraphic)
				{
					FireWorkEff.paint(g);
				}
			}
			else if (GameCanvas.imgBG != null && GameCanvas.imgBG[num] != null)
			{
				if (GameCanvas.moveX[num] != 0)
				{
					GameCanvas.moveX[num] += GameCanvas.moveXSpeed[num];
				}
				int cmy = GameScr.cmy;
				if (cmy > GameCanvas.h)
				{
					cmy = GameCanvas.h;
				}
				if (GameCanvas.layerSpeed[num] != 0)
				{
					for (int i = -((GameScr.cmx + GameCanvas.moveX[num] >> GameCanvas.layerSpeed[num]) % GameCanvas.bgW[num]); i < GameScr.gW; i += GameCanvas.bgW[num])
					{
						g.drawImage(GameCanvas.imgBG[num], i, GameCanvas.yb[num] - ((deltaY <= 0) ? 0 : (cmy >> deltaY)), 0);
					}
				}
				else
				{
					for (int j = 0; j < GameScr.gW; j += GameCanvas.bgW[num])
					{
						g.drawImage(GameCanvas.imgBG[num], j, GameCanvas.yb[num] - ((deltaY <= 0) ? 0 : (cmy >> deltaY)), 0);
					}
				}
				if (color1 != -1)
				{
					if (num == GameCanvas.nBg - 1)
					{
						GameCanvas.fillRect(g, color1, 0, -(cmy >> deltaY), GameScr.gW, GameCanvas.yb[num], deltaY);
					}
					else
					{
						GameCanvas.fillRect(g, color1, 0, GameCanvas.yb[num - 1] + GameCanvas.bgH[num - 1], GameScr.gW, GameCanvas.yb[num] - (GameCanvas.yb[num - 1] + GameCanvas.bgH[num - 1]), deltaY);
					}
				}
				if (color2 != -1)
				{
					if (num == 0)
					{
						GameCanvas.fillRect(g, color2, 0, GameCanvas.yb[num] + GameCanvas.bgH[num], GameScr.gW, GameScr.gH - (GameCanvas.yb[num] + GameCanvas.bgH[num]), deltaY);
					}
					else
					{
						GameCanvas.fillRect(g, color2, 0, GameCanvas.yb[num] + GameCanvas.bgH[num], GameScr.gW, GameCanvas.yb[num - 1] - (GameCanvas.yb[num] + GameCanvas.bgH[num]) + 80, deltaY);
					}
				}
				if (GameCanvas.currentScreen == GameScr.instance)
				{
					if (layer == 1 && GameCanvas.typeBg == 11)
					{
						g.drawImage(GameCanvas.imgSun2, -(GameScr.cmx >> GameCanvas.layerSpeed[0]) + 400, GameCanvas.yb[0] + 30 - (cmy >> 2), StaticObj.BOTTOM_HCENTER);
					}
					if (layer == 1 && GameCanvas.typeBg == 13)
					{
						g.drawImage(GameCanvas.imgBG[1], -(GameScr.cmx >> GameCanvas.layerSpeed[0]) + 200, GameCanvas.yb[0] - (cmy >> 3) + 30, 0);
						g.drawRegion(GameCanvas.imgBG[1], 0, 0, GameCanvas.bgW[1], GameCanvas.bgH[1], 2, -(GameScr.cmx >> GameCanvas.layerSpeed[0]) + 200 + GameCanvas.bgW[1], GameCanvas.yb[0] - (cmy >> 3) + 30, 0);
					}
					if (layer == 3 && TileMap.mapID == 1)
					{
						for (int k = 0; k < TileMap.pxh / mGraphics.getImageHeight(GameCanvas.imgCaycot); k++)
						{
							g.drawImage(GameCanvas.imgCaycot, -(GameScr.cmx >> GameCanvas.layerSpeed[2]) + 300, k * mGraphics.getImageHeight(GameCanvas.imgCaycot) - (cmy >> 3), 0);
						}
					}
				}
				int x = -(GameScr.cmx + GameCanvas.moveX[num] >> GameCanvas.layerSpeed[num]);
				EffecMn.paintBackGroundUnderLayer(g, x, GameCanvas.yb[num] + GameCanvas.bgH[num] - (cmy >> deltaY), num);
			}
		}
		catch (Exception ex)
		{
			Cout.LogError("Loi ham paint bground: " + ex.ToString());
		}
	}

	// Token: 0x0600098C RID: 2444 RVA: 0x0008DADC File Offset: 0x0008BCDC
	public static void drawSun1(mGraphics g)
	{
		if (GameCanvas.imgSun != null)
		{
			g.drawImage(GameCanvas.imgSun, GameCanvas.sunX, GameCanvas.sunY, 0);
		}
		if (GameCanvas.isBoltEff)
		{
			if (GameCanvas.gameTick % 200 == 0)
			{
				GameCanvas.boltActive = true;
			}
			if (GameCanvas.boltActive)
			{
				GameCanvas.tBolt++;
				if (GameCanvas.tBolt == 10)
				{
					GameCanvas.tBolt = 0;
					GameCanvas.boltActive = false;
				}
				if (GameCanvas.tBolt % 2 == 0)
				{
					g.setColor(16777215);
					g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
				}
			}
		}
	}

	// Token: 0x0600098D RID: 2445 RVA: 0x00003984 File Offset: 0x00001B84
	public static void drawSun2(mGraphics g)
	{
	}

	// Token: 0x0600098E RID: 2446 RVA: 0x00007CFA File Offset: 0x00005EFA
	public static bool isHDVersion()
	{
		return mGraphics.zoomLevel > 1;
	}

	// Token: 0x0600098F RID: 2447 RVA: 0x0008DB80 File Offset: 0x0008BD80
	public static void paintBGGameScr(mGraphics g)
	{
		if (!GameCanvas.isLoadBGok)
		{
			g.setColor(0);
			g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
		}
		if (global::Char.isLoadingMap)
		{
			return;
		}
		int gW = GameScr.gW;
		int gH = GameScr.gH;
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		try
		{
			if (GameCanvas.paintBG)
			{
				if (GameCanvas.currentScreen == GameScr.gI())
				{
					if (TileMap.mapID == 137 || TileMap.mapID == 115 || TileMap.mapID == 117 || TileMap.mapID == 118 || TileMap.mapID == 120 || TileMap.isMapDouble)
					{
						g.setColor(0);
						g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
						return;
					}
					if (TileMap.mapID == 138)
					{
						g.setColor(6776679);
						g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
						return;
					}
				}
				if (GameCanvas.typeBg == 0)
				{
					GameCanvas.paintBackgroundtLayer(g, 4, 6, GameCanvas.colorTop[3], GameCanvas.colorBotton[3]);
					GameCanvas.paintBackgroundtLayer(g, 3, 4, -1, GameCanvas.colorBotton[2]);
					GameCanvas.paintBackgroundtLayer(g, 2, 3, -1, GameCanvas.colorBotton[1]);
					GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, GameCanvas.colorBotton[0]);
				}
				else if (GameCanvas.typeBg == 1)
				{
					GameCanvas.paintBackgroundtLayer(g, 4, 6, -1, -1);
					GameCanvas.paintBackgroundtLayer(g, 3, 3, -1, -1);
					GameCanvas.fillRect(g, GameCanvas.colorTop[2], 0, -(GameScr.cmy >> 5), gW, GameCanvas.yb[2], 5);
					GameCanvas.fillRect(g, GameCanvas.colorBotton[2], 0, GameCanvas.yb[2] + GameCanvas.bgH[2] - (GameScr.cmy >> 3), gW, 70, 3);
					GameCanvas.paintBackgroundtLayer(g, 2, 2, -1, -1);
					GameCanvas.paintBackgroundtLayer(g, 1, 1, -1, GameCanvas.colorBotton[0]);
				}
				else if (GameCanvas.typeBg == 2)
				{
					GameCanvas.paintBackgroundtLayer(g, 5, 10, GameCanvas.colorTop[4], GameCanvas.colorBotton[4]);
					GameCanvas.paintBackgroundtLayer(g, 4, 8, -1, GameCanvas.colorTop[2]);
					GameCanvas.paintBackgroundtLayer(g, 3, 5, -1, GameCanvas.colorBotton[2]);
					GameCanvas.paintBackgroundtLayer(g, 2, 2, -1, GameCanvas.colorBotton[1]);
					GameCanvas.paintBackgroundtLayer(g, 1, 1, -1, GameCanvas.colorBotton[0]);
					GameCanvas.paintCloud(g);
				}
				else if (GameCanvas.typeBg == 3)
				{
					int num = GameScr.cmy - (325 - GameScr.gH23);
					g.translate(0, -num);
					GameCanvas.fillRect(g, (!GameScr.gI().isRongThanXuatHien && !GameScr.gI().isFireWorks) ? GameCanvas.colorTop[2] : GameScr.gI().mautroi, 0, num - (GameScr.cmy >> 3), gW, GameCanvas.yb[2] - num + (GameScr.cmy >> 3) + 100, 2);
					GameCanvas.paintBackgroundtLayer(g, 3, 2, -1, GameCanvas.colorBotton[2]);
					GameCanvas.paintBackgroundtLayer(g, 2, 0, -1, -1);
					GameCanvas.paintBackgroundtLayer(g, 1, 0, -1, GameCanvas.colorBotton[0]);
					g.translate(0, -g.getTranslateY());
				}
				else if (GameCanvas.typeBg == 4)
				{
					GameCanvas.paintBackgroundtLayer(g, 4, 7, GameCanvas.colorTop[3], -1);
					GameCanvas.paintBackgroundtLayer(g, 3, 3, -1, (!GameCanvas.isHDVersion()) ? GameCanvas.colorTop[1] : GameCanvas.colorBotton[2]);
					GameCanvas.paintBackgroundtLayer(g, 2, 2, GameCanvas.colorTop[1], GameCanvas.colorBotton[1]);
					GameCanvas.paintBackgroundtLayer(g, 1, 1, -1, GameCanvas.colorBotton[0]);
				}
				else if (GameCanvas.typeBg == 5)
				{
					GameCanvas.paintBackgroundtLayer(g, 4, 15, GameCanvas.colorTop[3], -1);
					GameCanvas.drawSun1(g);
					g.translate(100, 10);
					GameCanvas.drawSun1(g);
					g.translate(-100, -10);
					GameCanvas.drawSun2(g);
					GameCanvas.paintBackgroundtLayer(g, 3, 10, -1, -1);
					GameCanvas.paintBackgroundtLayer(g, 2, 6, -1, -1);
					GameCanvas.paintBackgroundtLayer(g, 1, 4, -1, -1);
					g.translate(0, 27);
					GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, -1);
					g.translate(0, 20);
					GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, GameCanvas.colorBotton[0]);
					g.translate(-g.getTranslateX(), -g.getTranslateY());
				}
				else if (GameCanvas.typeBg == 6)
				{
					GameCanvas.paintBackgroundtLayer(g, 5, 10, GameCanvas.colorTop[4], GameCanvas.colorBotton[4]);
					GameCanvas.drawSun1(g);
					GameCanvas.drawSun2(g);
					g.translate(60, 40);
					GameCanvas.drawSun2(g);
					g.translate(-60, -40);
					GameCanvas.paintBackgroundtLayer(g, 4, 7, -1, GameCanvas.colorBotton[3]);
					BackgroudEffect.paintFarAll(g);
					GameCanvas.paintBackgroundtLayer(g, 3, 4, -1, -1);
					GameCanvas.paintBackgroundtLayer(g, 2, 3, -1, GameCanvas.colorBotton[1]);
					GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, GameCanvas.colorBotton[0]);
				}
				else if (GameCanvas.typeBg == 7)
				{
					GameCanvas.paintBackgroundtLayer(g, 4, 6, GameCanvas.colorTop[3], GameCanvas.colorBotton[3]);
					GameCanvas.paintBackgroundtLayer(g, 3, 5, -1, -1);
					GameCanvas.paintBackgroundtLayer(g, 2, 4, -1, -1);
					GameCanvas.paintBackgroundtLayer(g, 1, 3, -1, GameCanvas.colorBotton[0]);
				}
				else if (GameCanvas.typeBg == 8)
				{
					GameCanvas.paintBackgroundtLayer(g, 4, 8, GameCanvas.colorTop[3], GameCanvas.colorBotton[3]);
					GameCanvas.drawSun1(g);
					GameCanvas.drawSun2(g);
					GameCanvas.paintBackgroundtLayer(g, 3, 4, -1, GameCanvas.colorBotton[2]);
					GameCanvas.paintBackgroundtLayer(g, 2, 2, -1, GameCanvas.colorBotton[1]);
					if (((TileMap.mapID < 92 || TileMap.mapID > 96) && TileMap.mapID != 51 && TileMap.mapID != 52) || GameCanvas.currentScreen == GameCanvas.loginScr)
					{
						GameCanvas.paintBackgroundtLayer(g, 1, 1, -1, GameCanvas.colorBotton[0]);
					}
				}
				else if (GameCanvas.typeBg == 9)
				{
					GameCanvas.paintBackgroundtLayer(g, 4, 8, GameCanvas.colorTop[3], GameCanvas.colorBotton[3]);
					GameCanvas.drawSun1(g);
					GameCanvas.drawSun2(g);
					g.translate(-80, 20);
					GameCanvas.drawSun2(g);
					g.translate(80, -20);
					BackgroudEffect.paintFarAll(g);
					GameCanvas.paintBackgroundtLayer(g, 3, 5, -1, -1);
					GameCanvas.paintBackgroundtLayer(g, 2, 3, -1, -1);
					GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, GameCanvas.colorBotton[0]);
				}
				else if (GameCanvas.typeBg == 10)
				{
					int num2 = GameScr.cmy - (380 - GameScr.gH23);
					g.translate(0, -num2);
					GameCanvas.fillRect(g, (!GameScr.gI().isRongThanXuatHien) ? GameCanvas.colorTop[1] : GameScr.gI().mautroi, 0, num2 - (GameScr.cmy >> 2), gW, GameCanvas.yb[1] - num2 + (GameScr.cmy >> 2) + 100, 2);
					GameCanvas.paintBackgroundtLayer(g, 2, 2, -1, GameCanvas.colorBotton[1]);
					GameCanvas.drawSun1(g);
					GameCanvas.drawSun2(g);
					GameCanvas.paintBackgroundtLayer(g, 1, 0, -1, -1);
					g.translate(0, -g.getTranslateY());
				}
				else if (GameCanvas.typeBg == 11)
				{
					GameCanvas.paintBackgroundtLayer(g, 3, 6, GameCanvas.colorTop[2], GameCanvas.colorBotton[2]);
					GameCanvas.drawSun1(g);
					GameCanvas.paintBackgroundtLayer(g, 2, 3, -1, GameCanvas.colorBotton[1]);
					GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, GameCanvas.colorBotton[0]);
				}
				else if (GameCanvas.typeBg == 12)
				{
					g.setColor(9161471);
					g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
					GameCanvas.paintBackgroundtLayer(g, 3, 4, -1, 14417919);
					GameCanvas.paintBackgroundtLayer(g, 2, 3, -1, 14417919);
					GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, 14417919);
					GameCanvas.paintCloud(g);
				}
				else if (GameCanvas.typeBg == 13)
				{
					g.setColor(15268088);
					g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
					GameCanvas.paintBackgroundtLayer(g, 1, 5, -1, 15268088);
				}
				else if (GameCanvas.typeBg == 15)
				{
					g.setColor(2631752);
					g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
					GameCanvas.paintBackgroundtLayer(g, 2, 3, -1, GameCanvas.colorBotton[1]);
					GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, GameCanvas.colorBotton[0]);
				}
				else if (GameCanvas.typeBg == 16)
				{
					GameCanvas.paintBackgroundtLayer(g, 4, 6, GameCanvas.colorTop[3], GameCanvas.colorBotton[3]);
					for (int i = 0; i < GameCanvas.imgSunSpec.Length; i++)
					{
						g.drawImage(GameCanvas.imgSunSpec[i], GameCanvas.cloudX[i], GameCanvas.cloudY[i], 33);
					}
					GameCanvas.paintBackgroundtLayer(g, 3, 4, -1, GameCanvas.colorBotton[2]);
					GameCanvas.paintBackgroundtLayer(g, 2, 3, -1, GameCanvas.colorBotton[1]);
					GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, GameCanvas.colorBotton[0]);
				}
				else
				{
					GameCanvas.fillRect(g, GameCanvas.colorBotton[3], 0, GameCanvas.yb[3] + GameCanvas.bgH[3], GameScr.gW, GameCanvas.yb[2] + GameCanvas.bgH[2], 6);
					GameCanvas.paintBackgroundtLayer(g, 4, 6, GameCanvas.colorTop[3], GameCanvas.colorBotton[3]);
					GameCanvas.drawSun1(g);
					GameCanvas.paintBackgroundtLayer(g, 3, 4, -1, GameCanvas.colorBotton[2]);
					GameCanvas.paintBackgroundtLayer(g, 2, 3, -1, GameCanvas.colorBotton[1]);
					GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, GameCanvas.colorBotton[0]);
				}
			}
			else
			{
				g.setColor(2315859);
				g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
				if (GameCanvas.tam != null)
				{
					for (int j = -((GameScr.cmx >> 2) % mGraphics.getImageWidth(GameCanvas.tam)); j < GameScr.gW; j += mGraphics.getImageWidth(GameCanvas.tam))
					{
						g.drawImage(GameCanvas.tam, j, (GameScr.cmy >> 3) + GameCanvas.h / 2 - 50, 0);
					}
				}
				g.setColor(5084791);
				g.fillRect(0, (GameScr.cmy >> 3) + GameCanvas.h / 2 - 50 + mGraphics.getImageHeight(GameCanvas.tam), gW, GameCanvas.h);
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000990 RID: 2448 RVA: 0x00003984 File Offset: 0x00001B84
	public static void resetBg()
	{
	}

	// Token: 0x06000991 RID: 2449 RVA: 0x0008E564 File Offset: 0x0008C764
	public static void getYBackground(int typeBg)
	{
		int gH = GameScr.gH23;
		switch (typeBg)
		{
		case 0:
			GameCanvas.yb[0] = gH - GameCanvas.bgH[0] + 70;
			GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] + 20;
			GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] + 30;
			GameCanvas.yb[3] = GameCanvas.yb[2] - GameCanvas.bgH[3] + 50;
			return;
		case 1:
			GameCanvas.yb[0] = gH - GameCanvas.bgH[0] + 120;
			GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] + 40;
			GameCanvas.yb[2] = GameCanvas.yb[1] - 90;
			GameCanvas.yb[3] = GameCanvas.yb[2] - 25;
			return;
		case 2:
			GameCanvas.yb[0] = gH - GameCanvas.bgH[0] + 150;
			GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] - 60;
			GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] - 40;
			GameCanvas.yb[3] = GameCanvas.yb[2] - GameCanvas.bgH[3] - 10;
			GameCanvas.yb[4] = GameCanvas.yb[3] - GameCanvas.bgH[4];
			return;
		case 3:
			GameCanvas.yb[0] = gH - GameCanvas.bgH[0] + 10;
			GameCanvas.yb[1] = GameCanvas.yb[0] + 80;
			GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] - 10;
			return;
		case 4:
			GameCanvas.yb[0] = gH - GameCanvas.bgH[0] + 130;
			GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1];
			GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] - 20;
			GameCanvas.yb[3] = GameCanvas.yb[1] - GameCanvas.bgH[2] - 80;
			return;
		case 5:
			GameCanvas.yb[0] = gH - GameCanvas.bgH[0] + 40;
			GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] + 10;
			GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] + 15;
			GameCanvas.yb[3] = GameCanvas.yb[2] - GameCanvas.bgH[3] + 50;
			return;
		case 6:
			GameCanvas.yb[0] = gH - GameCanvas.bgH[0] + 100;
			GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] - 30;
			GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] + 10;
			GameCanvas.yb[3] = GameCanvas.yb[2] - GameCanvas.bgH[3] + 15;
			GameCanvas.yb[4] = GameCanvas.yb[3] - GameCanvas.bgH[4] + 15;
			return;
		case 7:
			GameCanvas.yb[0] = gH - GameCanvas.bgH[0] + 20;
			GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] + 15;
			GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] + 20;
			GameCanvas.yb[3] = GameCanvas.yb[1] - GameCanvas.bgH[2] - 10;
			return;
		case 8:
			GameCanvas.yb[0] = gH - 103 + 150;
			if (TileMap.mapID == 103)
			{
				GameCanvas.yb[0] -= 100;
			}
			GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] - 10;
			GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] + 40;
			GameCanvas.yb[3] = GameCanvas.yb[2] - GameCanvas.bgH[3] + 10;
			return;
		case 9:
			GameCanvas.yb[0] = gH - GameCanvas.bgH[0] + 100;
			GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] + 22;
			GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] + 50;
			GameCanvas.yb[3] = GameCanvas.yb[2] - GameCanvas.bgH[3];
			return;
		case 10:
			GameCanvas.yb[0] = gH - GameCanvas.bgH[0] - 45;
			GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] - 10;
			return;
		case 11:
			GameCanvas.yb[0] = gH - GameCanvas.bgH[0] + 60;
			GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] + 5;
			GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] - 15;
			return;
		case 12:
			GameCanvas.yb[0] = gH + 40;
			GameCanvas.yb[1] = GameCanvas.yb[0] - 40;
			GameCanvas.yb[2] = GameCanvas.yb[1] - 40;
			return;
		case 13:
			GameCanvas.yb[0] = gH - 80;
			GameCanvas.yb[1] = GameCanvas.yb[0];
			return;
		case 15:
			GameCanvas.yb[0] = gH - 20;
			GameCanvas.yb[1] = GameCanvas.yb[0] - 80;
			return;
		case 16:
			GameCanvas.yb[0] = gH - GameCanvas.bgH[0] + 75;
			GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] + 50;
			GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] + 50;
			GameCanvas.yb[3] = GameCanvas.yb[2] - GameCanvas.bgH[3] + 90;
			return;
		}
		GameCanvas.yb[0] = gH - GameCanvas.bgH[0] + 75;
		GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] + 50;
		GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] + 50;
		GameCanvas.yb[3] = GameCanvas.yb[2] - GameCanvas.bgH[3] + 90;
	}

	// Token: 0x06000992 RID: 2450 RVA: 0x0008EB70 File Offset: 0x0008CD70
	public static void loadBG(int typeBG)
	{
		try
		{
			GameCanvas.isLoadBGok = true;
			if (GameCanvas.typeBg == 12)
			{
				BackgroudEffect.yfog = TileMap.pxh - 100;
			}
			else
			{
				BackgroudEffect.yfog = TileMap.pxh - 160;
			}
			BackgroudEffect.clearImage();
			GameCanvas.randomRaintEff(typeBG);
			if ((TileMap.lastBgID != typeBG || TileMap.lastType != TileMap.bgType) && typeBG != -1)
			{
				GameCanvas.transY = 12;
				TileMap.lastBgID = (int)((sbyte)typeBG);
				TileMap.lastType = (int)((sbyte)TileMap.bgType);
				GameCanvas.layerSpeed = new int[]
				{
					1,
					2,
					3,
					7,
					8
				};
				GameCanvas.moveX = new int[5];
				GameCanvas.moveXSpeed = new int[5];
				GameCanvas.typeBg = typeBG;
				GameCanvas.isBoltEff = false;
				GameScr.firstY = GameScr.cmy;
				GameCanvas.imgBG = null;
				GameCanvas.imgCloud = null;
				GameCanvas.imgSun = null;
				GameCanvas.imgCaycot = null;
				GameScr.firstY = -1;
				switch (GameCanvas.typeBg)
				{
				case 0:
					GameCanvas.imgCaycot = GameCanvas.loadImageRMS("/bg/caycot.png");
					GameCanvas.layerSpeed = new int[]
					{
						1,
						3,
						5,
						7
					};
					GameCanvas.nBg = 4;
					if (TileMap.bgType == 2)
					{
						GameCanvas.transY = 8;
					}
					goto IL_303;
				case 1:
					GameCanvas.transY = 7;
					GameCanvas.nBg = 4;
					goto IL_303;
				case 2:
				{
					int[] array = new int[5];
					array[2] = 1;
					GameCanvas.moveX = array;
					int[] array2 = new int[5];
					array2[2] = 2;
					GameCanvas.moveXSpeed = array2;
					GameCanvas.nBg = 5;
					goto IL_303;
				}
				case 3:
					GameCanvas.nBg = 3;
					goto IL_303;
				case 4:
				{
					BackgroudEffect.addEffect(3);
					int[] array3 = new int[5];
					array3[1] = 1;
					GameCanvas.moveX = array3;
					int[] array4 = new int[5];
					array4[1] = 1;
					GameCanvas.moveXSpeed = array4;
					GameCanvas.nBg = 4;
					goto IL_303;
				}
				case 5:
					GameCanvas.nBg = 4;
					goto IL_303;
				case 6:
				{
					int[] array5 = new int[5];
					array5[0] = 1;
					GameCanvas.moveX = array5;
					int[] array6 = new int[5];
					array6[0] = 2;
					GameCanvas.moveXSpeed = array6;
					GameCanvas.nBg = 5;
					goto IL_303;
				}
				case 7:
					GameCanvas.nBg = 4;
					goto IL_303;
				case 8:
					GameCanvas.transY = 8;
					GameCanvas.nBg = 4;
					goto IL_303;
				case 9:
					BackgroudEffect.addEffect(9);
					GameCanvas.nBg = 4;
					goto IL_303;
				case 10:
					GameCanvas.nBg = 2;
					goto IL_303;
				case 11:
					GameCanvas.transY = 7;
					GameCanvas.layerSpeed[2] = 0;
					GameCanvas.nBg = 3;
					goto IL_303;
				case 12:
				{
					int[] array7 = new int[5];
					array7[0] = 1;
					array7[1] = 1;
					GameCanvas.moveX = array7;
					int[] array8 = new int[5];
					array8[0] = 2;
					array8[1] = 1;
					GameCanvas.moveXSpeed = array8;
					GameCanvas.nBg = 3;
					goto IL_303;
				}
				case 13:
					GameCanvas.nBg = 2;
					goto IL_303;
				case 15:
					Res.outz("HELL");
					GameCanvas.nBg = 2;
					goto IL_303;
				case 16:
					GameCanvas.layerSpeed = new int[]
					{
						1,
						3,
						5,
						7
					};
					GameCanvas.nBg = 4;
					goto IL_303;
				}
				GameCanvas.layerSpeed = new int[]
				{
					1,
					3,
					5,
					7
				};
				GameCanvas.nBg = 4;
				IL_303:
				if (typeBG < 16)
				{
					GameCanvas.skyColor = StaticObj.SKYCOLOR[GameCanvas.typeBg];
				}
				else
				{
					try
					{
						string path = string.Concat(new object[]
						{
							"/bg/b",
							GameCanvas.typeBg,
							3,
							".png"
						});
						if (TileMap.bgType != 0)
						{
							path = string.Concat(new object[]
							{
								"/bg/b",
								GameCanvas.typeBg,
								3,
								"-",
								TileMap.bgType,
								".png"
							});
						}
						int[] array9 = new int[1];
						Image image = GameCanvas.loadImageRMS(path);
						image.getRGB(ref array9, 0, 1, mGraphics.getRealImageWidth(image) / 2, 0, 1, 1);
						GameCanvas.skyColor = array9[0];
					}
					catch (Exception ex)
					{
						GameCanvas.skyColor = StaticObj.SKYCOLOR[StaticObj.SKYCOLOR.Length - 1];
					}
				}
				if (GameCanvas.lowGraphic)
				{
					GameCanvas.tam = GameCanvas.loadImageRMS("/bg/b63.png");
				}
				else
				{
					GameCanvas.imgBG = new Image[GameCanvas.nBg];
					GameCanvas.bgW = new int[GameCanvas.nBg];
					GameCanvas.bgH = new int[GameCanvas.nBg];
					GameCanvas.colorBotton = new int[GameCanvas.nBg];
					GameCanvas.colorTop = new int[GameCanvas.nBg];
					if (TileMap.bgType == 100)
					{
						GameCanvas.imgBG[0] = GameCanvas.loadImageRMS("/bg/b100.png");
						GameCanvas.imgBG[1] = GameCanvas.loadImageRMS("/bg/b100.png");
						GameCanvas.imgBG[2] = GameCanvas.loadImageRMS("/bg/b82-1.png");
						GameCanvas.imgBG[3] = GameCanvas.loadImageRMS("/bg/b93.png");
						for (int i = 0; i < GameCanvas.nBg; i++)
						{
							if (GameCanvas.imgBG[i] != null)
							{
								int[] array10 = new int[1];
								GameCanvas.imgBG[i].getRGB(ref array10, 0, 1, mGraphics.getRealImageWidth(GameCanvas.imgBG[i]) / 2, 0, 1, 1);
								GameCanvas.colorTop[i] = array10[0];
								array10 = new int[1];
								GameCanvas.imgBG[i].getRGB(ref array10, 0, 1, mGraphics.getRealImageWidth(GameCanvas.imgBG[i]) / 2, mGraphics.getRealImageHeight(GameCanvas.imgBG[i]) - 1, 1, 1);
								GameCanvas.colorBotton[i] = array10[0];
								GameCanvas.bgW[i] = mGraphics.getImageWidth(GameCanvas.imgBG[i]);
								GameCanvas.bgH[i] = mGraphics.getImageHeight(GameCanvas.imgBG[i]);
							}
							else if (GameCanvas.nBg > 1)
							{
								GameCanvas.imgBG[i] = GameCanvas.loadImageRMS("/bg/b" + GameCanvas.typeBg + "0.png");
								GameCanvas.bgW[i] = mGraphics.getImageWidth(GameCanvas.imgBG[i]);
								GameCanvas.bgH[i] = mGraphics.getImageHeight(GameCanvas.imgBG[i]);
							}
						}
					}
					else
					{
						for (int j = 0; j < GameCanvas.nBg; j++)
						{
							string path2 = string.Concat(new object[]
							{
								"/bg/b",
								GameCanvas.typeBg,
								j,
								".png"
							});
							if (TileMap.bgType != 0)
							{
								path2 = string.Concat(new object[]
								{
									"/bg/b",
									GameCanvas.typeBg,
									j,
									"-",
									TileMap.bgType,
									".png"
								});
							}
							GameCanvas.imgBG[j] = GameCanvas.loadImageRMS(path2);
							if (GameCanvas.imgBG[j] != null)
							{
								int[] array11 = new int[1];
								GameCanvas.imgBG[j].getRGB(ref array11, 0, 1, mGraphics.getRealImageWidth(GameCanvas.imgBG[j]) / 2, 0, 1, 1);
								GameCanvas.colorTop[j] = array11[0];
								array11 = new int[1];
								GameCanvas.imgBG[j].getRGB(ref array11, 0, 1, mGraphics.getRealImageWidth(GameCanvas.imgBG[j]) / 2, mGraphics.getRealImageHeight(GameCanvas.imgBG[j]) - 1, 1, 1);
								GameCanvas.colorBotton[j] = array11[0];
								GameCanvas.bgW[j] = mGraphics.getImageWidth(GameCanvas.imgBG[j]);
								GameCanvas.bgH[j] = mGraphics.getImageHeight(GameCanvas.imgBG[j]);
							}
							else if (GameCanvas.nBg > 1)
							{
								GameCanvas.imgBG[j] = GameCanvas.loadImageRMS("/bg/b" + GameCanvas.typeBg + "0.png");
								GameCanvas.bgW[j] = mGraphics.getImageWidth(GameCanvas.imgBG[j]);
								GameCanvas.bgH[j] = mGraphics.getImageHeight(GameCanvas.imgBG[j]);
							}
						}
					}
					GameCanvas.getYBackground(GameCanvas.typeBg);
					GameCanvas.cloudX = new int[]
					{
						GameScr.gW / 2 - 40,
						GameScr.gW / 2 + 40,
						GameScr.gW / 2 - 100,
						GameScr.gW / 2 - 80,
						GameScr.gW / 2 - 120
					};
					GameCanvas.cloudY = new int[]
					{
						130,
						100,
						150,
						140,
						80
					};
					GameCanvas.imgSunSpec = null;
					if (GameCanvas.typeBg != 0)
					{
						if (GameCanvas.typeBg == 2)
						{
							GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun0.png");
							GameCanvas.sunX = GameScr.gW / 2 + 50;
							GameCanvas.sunY = GameCanvas.yb[4] - 40;
						}
						else if (GameCanvas.typeBg == 4)
						{
							GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun2.png");
							GameCanvas.sunX = GameScr.gW / 2 + 30;
							GameCanvas.sunY = GameCanvas.yb[3];
						}
						else if (GameCanvas.typeBg == 7)
						{
							GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun3" + ((TileMap.bgType != 0) ? ("-" + TileMap.bgType) : string.Empty) + ".png");
							GameCanvas.imgSun2 = GameCanvas.loadImageRMS("/bg/sun4" + ((TileMap.bgType != 0) ? ("-" + TileMap.bgType) : string.Empty) + ".png");
							GameCanvas.sunX = GameScr.gW - GameScr.gW / 3;
							GameCanvas.sunY = GameCanvas.yb[3] - 80;
							GameCanvas.sunX2 = GameCanvas.sunX - 100;
							GameCanvas.sunY2 = GameCanvas.yb[3] - 30;
						}
						else if (GameCanvas.typeBg == 6)
						{
							GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun5" + ((TileMap.bgType != 0) ? ("-" + TileMap.bgType) : string.Empty) + ".png");
							GameCanvas.imgSun2 = GameCanvas.loadImageRMS("/bg/sun6" + ((TileMap.bgType != 0) ? ("-" + TileMap.bgType) : string.Empty) + ".png");
							GameCanvas.sunX = GameScr.gW - GameScr.gW / 3;
							GameCanvas.sunY = GameCanvas.yb[4];
							GameCanvas.sunX2 = GameCanvas.sunX - 100;
							GameCanvas.sunY2 = GameCanvas.yb[4] + 20;
						}
						else if (typeBG == 5)
						{
							GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun8" + ((TileMap.bgType != 0) ? ("-" + TileMap.bgType) : string.Empty) + ".png");
							GameCanvas.imgSun2 = GameCanvas.loadImageRMS("/bg/sun7" + ((TileMap.bgType != 0) ? ("-" + TileMap.bgType) : string.Empty) + ".png");
							GameCanvas.sunX = GameScr.gW / 2 - 50;
							GameCanvas.sunY = GameCanvas.yb[3] + 20;
							GameCanvas.sunX2 = GameScr.gW / 2 + 20;
							GameCanvas.sunY2 = GameCanvas.yb[3] - 30;
						}
						else if (GameCanvas.typeBg == 8 && TileMap.mapID < 90)
						{
							GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun9" + ((TileMap.bgType != 0) ? ("-" + TileMap.bgType) : string.Empty) + ".png");
							GameCanvas.imgSun2 = GameCanvas.loadImageRMS("/bg/sun10" + ((TileMap.bgType != 0) ? ("-" + TileMap.bgType) : string.Empty) + ".png");
							GameCanvas.sunX = GameScr.gW / 2 - 30;
							GameCanvas.sunY = GameCanvas.yb[3] + 60;
							GameCanvas.sunX2 = GameScr.gW / 2 + 20;
							GameCanvas.sunY2 = GameCanvas.yb[3] + 10;
						}
						else if (typeBG == 9)
						{
							GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun11" + ((TileMap.bgType != 0) ? ("-" + TileMap.bgType) : string.Empty) + ".png");
							GameCanvas.imgSun2 = GameCanvas.loadImageRMS("/bg/sun12" + ((TileMap.bgType != 0) ? ("-" + TileMap.bgType) : string.Empty) + ".png");
							GameCanvas.sunX = GameScr.gW - GameScr.gW / 3;
							GameCanvas.sunY = GameCanvas.yb[4] + 20;
							GameCanvas.sunX2 = GameCanvas.sunX - 80;
							GameCanvas.sunY2 = GameCanvas.yb[4] + 40;
						}
						else if (typeBG == 10)
						{
							GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun13" + ((TileMap.bgType != 0) ? ("-" + TileMap.bgType) : string.Empty) + ".png");
							GameCanvas.imgSun2 = GameCanvas.loadImageRMS("/bg/sun14" + ((TileMap.bgType != 0) ? ("-" + TileMap.bgType) : string.Empty) + ".png");
							GameCanvas.sunX = GameScr.gW - GameScr.gW / 3;
							GameCanvas.sunY = GameCanvas.yb[1] - 30;
							GameCanvas.sunX2 = GameCanvas.sunX - 80;
							GameCanvas.sunY2 = GameCanvas.yb[1];
						}
						else if (typeBG == 11)
						{
							GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun15" + ((TileMap.bgType != 0) ? ("-" + TileMap.bgType) : string.Empty) + ".png");
							GameCanvas.imgSun2 = GameCanvas.loadImageRMS("/bg/b113" + ((TileMap.bgType != 0) ? ("-" + TileMap.bgType) : string.Empty) + ".png");
							GameCanvas.sunX = GameScr.gW / 2 - 30;
							GameCanvas.sunY = GameCanvas.yb[2] - 30;
						}
						else if (typeBG == 12)
						{
							GameCanvas.cloudY = new int[]
							{
								200,
								170,
								220,
								150,
								250
							};
						}
						else if (typeBG == 16)
						{
							GameCanvas.cloudX = new int[]
							{
								90,
								170,
								250,
								320,
								400,
								450,
								500
							};
							GameCanvas.cloudY = new int[]
							{
								GameCanvas.yb[2] + 5,
								GameCanvas.yb[2] - 20,
								GameCanvas.yb[2] - 50,
								GameCanvas.yb[2] - 30,
								GameCanvas.yb[2] - 50,
								GameCanvas.yb[2],
								GameCanvas.yb[2] - 40
							};
							GameCanvas.imgSunSpec = new Image[7];
							for (int k = 0; k < GameCanvas.imgSunSpec.Length; k++)
							{
								int num = 161;
								if (k == 0 || k == 2 || k == 3 || k == 2 || k == 6)
								{
									num = 160;
								}
								GameCanvas.imgSunSpec[k] = GameCanvas.loadImageRMS("/bg/sun" + num + ".png");
							}
						}
						else
						{
							GameCanvas.imgCloud = null;
							GameCanvas.imgSun = null;
							GameCanvas.imgSun2 = null;
							GameCanvas.imgSun = GameCanvas.loadImageRMS(string.Concat(new object[]
							{
								"/bg/sun",
								typeBG,
								(TileMap.bgType != 0) ? ("-" + TileMap.bgType) : string.Empty,
								".png"
							}));
							GameCanvas.sunX = GameScr.gW / 2 - 30;
							GameCanvas.sunY = GameCanvas.yb[2] - 30;
						}
					}
					GameCanvas.paintBG = false;
					if (!GameCanvas.paintBG)
					{
						GameCanvas.paintBG = true;
					}
				}
			}
		}
		catch (Exception ex2)
		{
			GameCanvas.isLoadBGok = false;
		}
	}

	// Token: 0x06000993 RID: 2451 RVA: 0x0008FBA0 File Offset: 0x0008DDA0
	private static void randomRaintEff(int typeBG)
	{
		for (int i = 0; i < GameCanvas.bgRain.Length; i++)
		{
			if (typeBG == GameCanvas.bgRain[i] && Res.random(0, 2) == 0)
			{
				BackgroudEffect.addEffect(0);
				break;
			}
		}
	}

	// Token: 0x06000994 RID: 2452 RVA: 0x0008FBEC File Offset: 0x0008DDEC
	public void keyPressedz(int keyCode)
	{
		GameCanvas.lastTimePress = mSystem.currentTimeMillis();
		if ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 122) || keyCode == 10 || keyCode == 8 || keyCode == 13 || keyCode == 32 || keyCode == 31)
		{
			GameCanvas.keyAsciiPress = keyCode;
		}
		this.mapKeyPress(keyCode);
	}

	// Token: 0x06000995 RID: 2453 RVA: 0x0008FC58 File Offset: 0x0008DE58
	public void mapKeyPress(int keyCode)
	{
		if (GameCanvas.currentDialog != null)
		{
			GameCanvas.currentDialog.keyPress(keyCode);
			GameCanvas.keyAsciiPress = 0;
			return;
		}
		GameCanvas.currentScreen.keyPress(keyCode);
		switch (keyCode)
		{
		case 48:
			GameCanvas.keyHold[0] = true;
			GameCanvas.keyPressed[0] = true;
			return;
		case 49:
			if (GameCanvas.currentScreen == CrackBallScr.instance || (GameCanvas.currentScreen == GameScr.instance && GameCanvas.isMoveNumberPad && !ChatTextField.gI().isShow))
			{
				GameCanvas.keyHold[1] = true;
				GameCanvas.keyPressed[1] = true;
			}
			return;
		case 50:
			if (GameCanvas.currentScreen == CrackBallScr.instance || (GameCanvas.currentScreen == GameScr.instance && GameCanvas.isMoveNumberPad && !ChatTextField.gI().isShow))
			{
				GameCanvas.keyHold[2] = true;
				GameCanvas.keyPressed[2] = true;
			}
			return;
		case 51:
			if (GameCanvas.currentScreen == CrackBallScr.instance || (GameCanvas.currentScreen == GameScr.instance && GameCanvas.isMoveNumberPad && !ChatTextField.gI().isShow))
			{
				GameCanvas.keyHold[3] = true;
				GameCanvas.keyPressed[3] = true;
			}
			return;
		case 52:
			if (GameCanvas.currentScreen == CrackBallScr.instance || (GameCanvas.currentScreen == GameScr.instance && GameCanvas.isMoveNumberPad && !ChatTextField.gI().isShow))
			{
				GameCanvas.keyHold[4] = true;
				GameCanvas.keyPressed[4] = true;
			}
			return;
		case 53:
			if (GameCanvas.currentScreen == CrackBallScr.instance || (GameCanvas.currentScreen == GameScr.instance && GameCanvas.isMoveNumberPad && !ChatTextField.gI().isShow))
			{
				GameCanvas.keyHold[5] = true;
				GameCanvas.keyPressed[5] = true;
			}
			return;
		case 54:
			if (GameCanvas.currentScreen == CrackBallScr.instance || (GameCanvas.currentScreen == GameScr.instance && GameCanvas.isMoveNumberPad && !ChatTextField.gI().isShow))
			{
				GameCanvas.keyHold[6] = true;
				GameCanvas.keyPressed[6] = true;
			}
			return;
		case 55:
			GameCanvas.keyHold[7] = true;
			GameCanvas.keyPressed[7] = true;
			return;
		case 56:
			if (GameCanvas.currentScreen == CrackBallScr.instance || (GameCanvas.currentScreen == GameScr.instance && GameCanvas.isMoveNumberPad && !ChatTextField.gI().isShow))
			{
				GameCanvas.keyHold[8] = true;
				GameCanvas.keyPressed[8] = true;
			}
			return;
		case 57:
			GameCanvas.keyHold[9] = true;
			GameCanvas.keyPressed[9] = true;
			return;
		default:
			switch (keyCode + 8)
			{
			case 0:
				GameCanvas.keyHold[14] = true;
				GameCanvas.keyPressed[14] = true;
				return;
			case 1:
				goto IL_354;
			case 2:
				goto IL_341;
			case 3:
				goto IL_1F9;
			case 4:
				if ((GameCanvas.currentScreen is GameScr || GameCanvas.currentScreen is CrackBallScr) && global::Char.myCharz().isAttack)
				{
					GameCanvas.clearKeyHold();
					GameCanvas.clearKeyPressed();
					return;
				}
				GameCanvas.keyHold[24] = true;
				GameCanvas.keyPressed[24] = true;
				return;
			case 5:
				if ((GameCanvas.currentScreen is GameScr || GameCanvas.currentScreen is CrackBallScr) && global::Char.myCharz().isAttack)
				{
					GameCanvas.clearKeyHold();
					GameCanvas.clearKeyPressed();
					return;
				}
				GameCanvas.keyHold[23] = true;
				GameCanvas.keyPressed[23] = true;
				return;
			case 6:
				goto IL_118;
			case 7:
				break;
			default:
				if (keyCode == -39)
				{
					goto IL_118;
				}
				if (keyCode != -38)
				{
					if (keyCode == -22)
					{
						goto IL_354;
					}
					if (keyCode == -21)
					{
						goto IL_341;
					}
					if (keyCode == -26)
					{
						GameCanvas.keyHold[16] = true;
						GameCanvas.keyPressed[16] = true;
						return;
					}
					if (keyCode == 10)
					{
						goto IL_1F9;
					}
					if (keyCode == 35)
					{
						GameCanvas.keyHold[11] = true;
						GameCanvas.keyPressed[11] = true;
						return;
					}
					if (keyCode == 42)
					{
						GameCanvas.keyHold[10] = true;
						GameCanvas.keyPressed[10] = true;
						return;
					}
					if (keyCode != 113)
					{
						return;
					}
					GameCanvas.keyHold[17] = true;
					GameCanvas.keyPressed[17] = true;
					return;
				}
				break;
			}
			if ((GameCanvas.currentScreen is GameScr || GameCanvas.currentScreen is CrackBallScr) && global::Char.myCharz().isAttack)
			{
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
				return;
			}
			GameCanvas.keyHold[21] = true;
			GameCanvas.keyPressed[21] = true;
			return;
			IL_118:
			if ((GameCanvas.currentScreen is GameScr || GameCanvas.currentScreen is CrackBallScr) && global::Char.myCharz().isAttack)
			{
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
				return;
			}
			GameCanvas.keyHold[22] = true;
			GameCanvas.keyPressed[22] = true;
			return;
			IL_1F9:
			if ((GameCanvas.currentScreen is GameScr || GameCanvas.currentScreen is CrackBallScr) && global::Char.myCharz().isAttack)
			{
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
				return;
			}
			GameCanvas.keyHold[25] = true;
			GameCanvas.keyPressed[25] = true;
			GameCanvas.keyHold[15] = true;
			GameCanvas.keyPressed[15] = true;
			return;
			IL_341:
			GameCanvas.keyHold[12] = true;
			GameCanvas.keyPressed[12] = true;
			return;
			IL_354:
			GameCanvas.keyHold[13] = true;
			GameCanvas.keyPressed[13] = true;
			return;
		}
	}

	// Token: 0x06000996 RID: 2454 RVA: 0x00007D0A File Offset: 0x00005F0A
	public void keyReleasedz(int keyCode)
	{
		GameCanvas.keyAsciiPress = 0;
		this.mapKeyRelease(keyCode);
	}

	// Token: 0x06000997 RID: 2455 RVA: 0x0009017C File Offset: 0x0008E37C
	public void mapKeyRelease(int keyCode)
	{
		switch (keyCode)
		{
		case 48:
			GameCanvas.keyHold[0] = false;
			GameCanvas.keyReleased[0] = true;
			return;
		case 49:
			if (GameCanvas.currentScreen == CrackBallScr.instance || (GameCanvas.currentScreen == GameScr.instance && GameCanvas.isMoveNumberPad && !ChatTextField.gI().isShow))
			{
				GameCanvas.keyHold[1] = false;
				GameCanvas.keyReleased[1] = true;
			}
			return;
		case 50:
			if (GameCanvas.currentScreen == CrackBallScr.instance || (GameCanvas.currentScreen == GameScr.instance && GameCanvas.isMoveNumberPad && !ChatTextField.gI().isShow))
			{
				GameCanvas.keyHold[2] = false;
				GameCanvas.keyReleased[2] = true;
			}
			return;
		case 51:
			if (GameCanvas.currentScreen == CrackBallScr.instance || (GameCanvas.currentScreen == GameScr.instance && GameCanvas.isMoveNumberPad && !ChatTextField.gI().isShow))
			{
				GameCanvas.keyHold[3] = false;
				GameCanvas.keyReleased[3] = true;
			}
			return;
		case 52:
			if (GameCanvas.currentScreen == CrackBallScr.instance || (GameCanvas.currentScreen == GameScr.instance && GameCanvas.isMoveNumberPad && !ChatTextField.gI().isShow))
			{
				GameCanvas.keyHold[4] = false;
				GameCanvas.keyReleased[4] = true;
			}
			return;
		case 53:
			if (GameCanvas.currentScreen == CrackBallScr.instance || (GameCanvas.currentScreen == GameScr.instance && GameCanvas.isMoveNumberPad && !ChatTextField.gI().isShow))
			{
				GameCanvas.keyHold[5] = false;
				GameCanvas.keyReleased[5] = true;
			}
			return;
		case 54:
			if (GameCanvas.currentScreen == CrackBallScr.instance || (GameCanvas.currentScreen == GameScr.instance && GameCanvas.isMoveNumberPad && !ChatTextField.gI().isShow))
			{
				GameCanvas.keyHold[6] = false;
				GameCanvas.keyReleased[6] = true;
			}
			return;
		case 55:
			GameCanvas.keyHold[7] = false;
			GameCanvas.keyReleased[7] = true;
			return;
		case 56:
			if (GameCanvas.currentScreen == CrackBallScr.instance || (GameCanvas.currentScreen == GameScr.instance && GameCanvas.isMoveNumberPad && !ChatTextField.gI().isShow))
			{
				GameCanvas.keyHold[8] = false;
				GameCanvas.keyReleased[8] = true;
			}
			return;
		case 57:
			GameCanvas.keyHold[9] = false;
			GameCanvas.keyReleased[9] = true;
			return;
		default:
			switch (keyCode + 8)
			{
			case 0:
				GameCanvas.keyHold[14] = false;
				return;
			case 1:
				goto IL_1F1;
			case 2:
				goto IL_1DE;
			case 3:
				goto IL_CE;
			case 4:
				GameCanvas.keyHold[24] = false;
				return;
			case 5:
				GameCanvas.keyHold[23] = false;
				return;
			case 6:
				goto IL_B0;
			case 7:
				break;
			default:
				if (keyCode == -39)
				{
					goto IL_B0;
				}
				if (keyCode != -38)
				{
					if (keyCode == -22)
					{
						goto IL_1F1;
					}
					if (keyCode == -21)
					{
						goto IL_1DE;
					}
					if (keyCode == -26)
					{
						GameCanvas.keyHold[16] = false;
						return;
					}
					if (keyCode == 10)
					{
						goto IL_CE;
					}
					if (keyCode == 35)
					{
						GameCanvas.keyHold[11] = false;
						GameCanvas.keyReleased[11] = true;
						return;
					}
					if (keyCode == 42)
					{
						GameCanvas.keyHold[10] = false;
						GameCanvas.keyReleased[10] = true;
						return;
					}
					if (keyCode != 113)
					{
						return;
					}
					GameCanvas.keyHold[17] = false;
					GameCanvas.keyReleased[17] = true;
					return;
				}
				break;
			}
			GameCanvas.keyHold[21] = false;
			return;
			IL_B0:
			GameCanvas.keyHold[22] = false;
			return;
			IL_CE:
			GameCanvas.keyHold[25] = false;
			GameCanvas.keyReleased[25] = true;
			GameCanvas.keyHold[15] = true;
			GameCanvas.keyPressed[15] = true;
			return;
			IL_1DE:
			GameCanvas.keyHold[12] = false;
			GameCanvas.keyReleased[12] = true;
			return;
			IL_1F1:
			GameCanvas.keyHold[13] = false;
			GameCanvas.keyReleased[13] = true;
			return;
		}
	}

	// Token: 0x06000998 RID: 2456 RVA: 0x00007D19 File Offset: 0x00005F19
	public void pointerMouse(int x, int y)
	{
		GameCanvas.pxMouse = x;
		GameCanvas.pyMouse = y;
	}

	// Token: 0x06000999 RID: 2457 RVA: 0x00007D27 File Offset: 0x00005F27
	public void scrollMouse(int a)
	{
		GameCanvas.pXYScrollMouse = a;
		if (GameCanvas.panel != null && GameCanvas.panel.isShow)
		{
			GameCanvas.panel.updateScroolMouse(a);
		}
	}

	// Token: 0x0600099A RID: 2458 RVA: 0x00090528 File Offset: 0x0008E728
	public void pointerDragged(int x, int y)
	{
		if (Res.abs(x - GameCanvas.pxLast) >= 10 || Res.abs(y - GameCanvas.pyLast) >= 10)
		{
			GameCanvas.isPointerClick = false;
			GameCanvas.isPointerDown = true;
			GameCanvas.isPointerMove = true;
		}
		GameCanvas.px = x;
		GameCanvas.py = y;
		GameCanvas.curPos++;
		if (GameCanvas.curPos > 3)
		{
			GameCanvas.curPos = 0;
		}
		GameCanvas.arrPos[GameCanvas.curPos] = new Position(x, y);
	}

	// Token: 0x0600099B RID: 2459 RVA: 0x00007D53 File Offset: 0x00005F53
	public static bool isHoldPress()
	{
		return mSystem.currentTimeMillis() - GameCanvas.lastTimePress >= 800L;
	}

	// Token: 0x0600099C RID: 2460 RVA: 0x000905A8 File Offset: 0x0008E7A8
	public void pointerPressed(int x, int y)
	{
		GameCanvas.isPointerJustRelease = false;
		GameCanvas.isPointerJustDown = true;
		GameCanvas.isPointerDown = true;
		GameCanvas.isPointerClick = true;
		GameCanvas.isPointerMove = false;
		GameCanvas.lastTimePress = mSystem.currentTimeMillis();
		GameCanvas.pxFirst = x;
		GameCanvas.pyFirst = y;
		GameCanvas.pxLast = x;
		GameCanvas.pyLast = y;
		GameCanvas.px = x;
		GameCanvas.py = y;
	}

	// Token: 0x0600099D RID: 2461 RVA: 0x00007D6E File Offset: 0x00005F6E
	public void pointerReleased(int x, int y)
	{
		GameCanvas.isPointerDown = false;
		GameCanvas.isPointerJustRelease = true;
		GameCanvas.isPointerMove = false;
		mScreen.keyTouch = -1;
		GameCanvas.px = x;
		GameCanvas.py = y;
	}

	// Token: 0x0600099E RID: 2462 RVA: 0x00090604 File Offset: 0x0008E804
	public static bool isPointerHoldIn(int x, int y, int w, int h)
	{
		return (GameCanvas.isPointerDown || GameCanvas.isPointerJustRelease) && (GameCanvas.px >= x && GameCanvas.px <= x + w && GameCanvas.py >= y && GameCanvas.py <= y + h);
	}

	// Token: 0x0600099F RID: 2463 RVA: 0x00007D94 File Offset: 0x00005F94
	public static bool isMouseFocus(int x, int y, int w, int h)
	{
		return GameCanvas.pxMouse >= x && GameCanvas.pxMouse <= x + w && GameCanvas.pyMouse >= y && GameCanvas.pyMouse <= y + h;
	}

	// Token: 0x060009A0 RID: 2464 RVA: 0x0009065C File Offset: 0x0008E85C
	public static void clearKeyPressed()
	{
		for (int i = 0; i < GameCanvas.keyPressed.Length; i++)
		{
			GameCanvas.keyPressed[i] = false;
		}
		GameCanvas.isPointerJustRelease = false;
	}

	// Token: 0x060009A1 RID: 2465 RVA: 0x00090690 File Offset: 0x0008E890
	public static void clearKeyHold()
	{
		for (int i = 0; i < GameCanvas.keyHold.Length; i++)
		{
			GameCanvas.keyHold[i] = false;
		}
	}

	// Token: 0x060009A2 RID: 2466 RVA: 0x000906C0 File Offset: 0x0008E8C0
	public static void checkBackButton()
	{
		if (ChatPopup.serverChatPopUp == null && ChatPopup.currChatPopup == null)
		{
			GameCanvas.startYesNoDlg(mResources.DOYOUWANTEXIT, new Command(mResources.YES, GameCanvas.instance, 8885, null), new Command(mResources.NO, GameCanvas.instance, 8882, null));
		}
	}

	// Token: 0x060009A3 RID: 2467 RVA: 0x00090718 File Offset: 0x0008E918
	public void paintChangeMap(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		g.setColor(0);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
		g.drawImage(LoginScr.imgTitle, GameCanvas.w / 2, GameCanvas.h / 2 - 24, StaticObj.BOTTOM_HCENTER);
		GameCanvas.paintShukiren(GameCanvas.hw, GameCanvas.h / 2 + 24, g);
		mFont.tahoma_7b_white.drawString(g, mResources.PLEASEWAIT + ((LoginScr.timeLogin <= 0) ? string.Empty : (" " + LoginScr.timeLogin + "s")), GameCanvas.w / 2, GameCanvas.h / 2, 2);
	}

	// Token: 0x060009A4 RID: 2468 RVA: 0x000907CC File Offset: 0x0008E9CC
	public void paint(mGraphics gx)
	{
		try
		{
			GameCanvas.debugPaint.removeAllElements();
			GameCanvas.debug("PA", 1);
			if (GameCanvas.currentScreen != null)
			{
				GameCanvas.currentScreen.paint(this.g);
			}
			GameCanvas.debug("PB", 1);
			this.g.translate(-this.g.getTranslateX(), -this.g.getTranslateY());
			this.g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
			if (GameCanvas.panel.isShow)
			{
				GameCanvas.panel.paint(this.g);
				if (GameCanvas.panel2 != null && GameCanvas.panel2.isShow)
				{
					GameCanvas.panel2.paint(this.g);
				}
				if (GameCanvas.panel.chatTField != null && GameCanvas.panel.chatTField.isShow)
				{
					GameCanvas.panel.chatTField.paint(this.g);
				}
				if (GameCanvas.panel2 != null && GameCanvas.panel2.chatTField != null && GameCanvas.panel2.chatTField.isShow)
				{
					GameCanvas.panel2.chatTField.paint(this.g);
				}
			}
			Res.paintOnScreenDebug(this.g);
			InfoDlg.paint(this.g);
			if (GameCanvas.currentDialog != null)
			{
				GameCanvas.debug("PC", 1);
				GameCanvas.currentDialog.paint(this.g);
			}
			else if (GameCanvas.menu.showMenu)
			{
				GameCanvas.debug("PD", 1);
				GameCanvas.menu.paintMenu(this.g);
			}
			GameScr.info1.paint(this.g);
			GameScr.info2.paint(this.g);
			if (GameScr.gI().popUpYesNo != null)
			{
				GameScr.gI().popUpYesNo.paint(this.g);
			}
			if (ChatPopup.currChatPopup != null)
			{
				ChatPopup.currChatPopup.paint(this.g);
			}
			Hint.paint(this.g);
			if (ChatPopup.serverChatPopUp != null)
			{
				ChatPopup.serverChatPopUp.paint(this.g);
			}
			for (int i = 0; i < Effect2.vEffect2.size(); i++)
			{
				Effect2 effect = (Effect2)Effect2.vEffect2.elementAt(i);
				if (effect is ChatPopup && !effect.Equals(ChatPopup.currChatPopup) && !effect.Equals(ChatPopup.serverChatPopUp))
				{
					effect.paint(this.g);
				}
			}
			if (global::Char.isLoadingMap || LoginScr.isContinueToLogin || ServerListScreen.waitToLogin || ServerListScreen.isWait)
			{
				this.paintChangeMap(this.g);
			}
			GameCanvas.debug("PE", 1);
			GameCanvas.resetTrans(this.g);
			EffecMn.paintLayer4(this.g);
			if ((int)mResources.language == 0 && GameCanvas.open3Hour && !GameCanvas.isLoading)
			{
				if (GameCanvas.currentScreen == GameCanvas.loginScr || GameCanvas.currentScreen == GameCanvas.serverScreen || GameCanvas.currentScreen == GameCanvas.serverScr)
				{
					this.g.drawImage(GameCanvas.img12, 5, 5, 0);
				}
				if (GameCanvas.currentScreen == CreateCharScr.instance)
				{
					this.g.drawImage(GameCanvas.img12, 5, 20, 0);
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060009A5 RID: 2469 RVA: 0x00007DC9 File Offset: 0x00005FC9
	public static void endDlg()
	{
		if (GameCanvas.inputDlg != null)
		{
			GameCanvas.inputDlg.tfInput.setMaxTextLenght(500);
		}
		GameCanvas.currentDialog = null;
		InfoDlg.hide();
	}

	// Token: 0x060009A6 RID: 2470 RVA: 0x00007DF4 File Offset: 0x00005FF4
	public static void startOKDlg(string info)
	{
		GameCanvas.closeKeyBoard();
		GameCanvas.msgdlg.setInfo(info, null, new Command(mResources.OK, GameCanvas.instance, 8882, null), null);
		GameCanvas.currentDialog = GameCanvas.msgdlg;
	}

	// Token: 0x060009A7 RID: 2471 RVA: 0x00007E27 File Offset: 0x00006027
	public static void startWaitDlg(string info)
	{
		GameCanvas.closeKeyBoard();
		GameCanvas.msgdlg.setInfo(info, null, new Command(mResources.CANCEL, GameCanvas.instance, 8882, null), null);
		GameCanvas.currentDialog = GameCanvas.msgdlg;
		GameCanvas.msgdlg.isWait = true;
	}

	// Token: 0x060009A8 RID: 2472 RVA: 0x00007E27 File Offset: 0x00006027
	public static void startOKDlg(string info, bool isError)
	{
		GameCanvas.closeKeyBoard();
		GameCanvas.msgdlg.setInfo(info, null, new Command(mResources.CANCEL, GameCanvas.instance, 8882, null), null);
		GameCanvas.currentDialog = GameCanvas.msgdlg;
		GameCanvas.msgdlg.isWait = true;
	}

	// Token: 0x060009A9 RID: 2473 RVA: 0x00007E65 File Offset: 0x00006065
	public static void startWaitDlg()
	{
		GameCanvas.closeKeyBoard();
		global::Char.isLoadingMap = true;
	}

	// Token: 0x060009AA RID: 2474 RVA: 0x00007E72 File Offset: 0x00006072
	public void openWeb(string strLeft, string strRight, string url, string str)
	{
		GameCanvas.msgdlg.setInfo(str, new Command(strLeft, this, 8881, url), null, new Command(strRight, this, 8882, null));
		GameCanvas.currentDialog = GameCanvas.msgdlg;
	}

	// Token: 0x060009AB RID: 2475 RVA: 0x00007EA5 File Offset: 0x000060A5
	public static void startOK(string info, int actionID, object p)
	{
		GameCanvas.closeKeyBoard();
		GameCanvas.msgdlg.setInfo(info, null, new Command(mResources.OK, GameCanvas.instance, actionID, p), null);
		GameCanvas.msgdlg.show();
	}

	// Token: 0x060009AC RID: 2476 RVA: 0x00090B60 File Offset: 0x0008ED60
	public static void startYesNoDlg(string info, int iYes, object pYes, int iNo, object pNo)
	{
		GameCanvas.closeKeyBoard();
		GameCanvas.msgdlg.setInfo(info, new Command(mResources.YES, GameCanvas.instance, iYes, pYes), new Command(string.Empty, GameCanvas.instance, iYes, pYes), new Command(mResources.NO, GameCanvas.instance, iNo, pNo));
		GameCanvas.msgdlg.show();
	}

	// Token: 0x060009AD RID: 2477 RVA: 0x00007ED4 File Offset: 0x000060D4
	public static void startYesNoDlg(string info, Command cmdYes, Command cmdNo)
	{
		GameCanvas.closeKeyBoard();
		GameCanvas.msgdlg.setInfo(info, cmdYes, null, cmdNo);
		GameCanvas.msgdlg.show();
	}

	// Token: 0x060009AE RID: 2478 RVA: 0x00090BBC File Offset: 0x0008EDBC
	public static string getMoneys(int m)
	{
		string text = string.Empty;
		int num = m / 1000 + 1;
		for (int i = 0; i < num; i++)
		{
			if (m < 1000)
			{
				text = m + text;
				break;
			}
			int num2 = m % 1000;
			if (num2 == 0)
			{
				text = ".000" + text;
			}
			else if (num2 < 10)
			{
				text = ".00" + num2 + text;
			}
			else if (num2 < 100)
			{
				text = ".0" + num2 + text;
			}
			else
			{
				text = "." + num2 + text;
			}
			m /= 1000;
		}
		return text;
	}

	// Token: 0x060009AF RID: 2479 RVA: 0x00007EF3 File Offset: 0x000060F3
	public static int getX(int start, int w)
	{
		return (GameCanvas.px - start) / w;
	}

	// Token: 0x060009B0 RID: 2480 RVA: 0x00007EFE File Offset: 0x000060FE
	public static int getY(int start, int w)
	{
		return (GameCanvas.py - start) / w;
	}

	// Token: 0x060009B1 RID: 2481 RVA: 0x00003984 File Offset: 0x00001B84
	protected void sizeChanged(int w, int h)
	{
	}

	// Token: 0x060009B2 RID: 2482 RVA: 0x00006B43 File Offset: 0x00004D43
	public static bool isGetResourceFromServer()
	{
		return true;
	}

	// Token: 0x060009B3 RID: 2483 RVA: 0x00090C88 File Offset: 0x0008EE88
	public static Image loadImageRMS(string path)
	{
		path = string.Concat(new object[]
		{
			Main.res,
			"/x",
			mGraphics.zoomLevel,
			path
		});
		path = GameCanvas.cutPng(path);
		Image result = null;
		try
		{
			result = Image.createImage(path);
		}
		catch (Exception ex)
		{
			try
			{
				string[] array = Res.split(path, "/", 0);
				string filename = "x" + mGraphics.zoomLevel + array[array.Length - 1];
				sbyte[] array2 = Rms.loadRMS(filename);
				if (array2 != null)
				{
					result = Image.createImage(array2, 0, array2.Length);
				}
			}
			catch (Exception ex2)
			{
				Cout.LogError("Loi ham khong tim thay a: " + ex.ToString());
			}
		}
		return result;
	}

	// Token: 0x060009B4 RID: 2484 RVA: 0x00090D6C File Offset: 0x0008EF6C
	public static Image loadImage(string path)
	{
		path = string.Concat(new object[]
		{
			Main.res,
			"/x",
			mGraphics.zoomLevel,
			path
		});
		path = GameCanvas.cutPng(path);
		Image result = null;
		try
		{
			result = Image.createImage(path);
		}
		catch (Exception ex)
		{
		}
		return result;
	}

	// Token: 0x060009B5 RID: 2485 RVA: 0x00090DD4 File Offset: 0x0008EFD4
	public static string cutPng(string str)
	{
		string result = str;
		if (str.Contains(".png"))
		{
			result = str.Replace(".png", string.Empty);
		}
		return result;
	}

	// Token: 0x060009B6 RID: 2486 RVA: 0x00007F09 File Offset: 0x00006109
	public static int random(int a, int b)
	{
		return a + GameCanvas.r.nextInt(b - a);
	}

	// Token: 0x060009B7 RID: 2487 RVA: 0x00090E08 File Offset: 0x0008F008
	public bool startDust(int dir, int x, int y)
	{
		if (GameCanvas.lowGraphic)
		{
			return false;
		}
		int num = (dir != 1) ? 1 : 0;
		if (this.dustState[num] != -1)
		{
			return false;
		}
		this.dustState[num] = 0;
		this.dustX[num] = x;
		this.dustY[num] = y;
		return true;
	}

	// Token: 0x060009B8 RID: 2488 RVA: 0x00090E5C File Offset: 0x0008F05C
	public void loadWaterSplash()
	{
		if (GameCanvas.lowGraphic)
		{
			return;
		}
		GameCanvas.imgWS = new Image[3];
		for (int i = 0; i < 3; i++)
		{
			GameCanvas.imgWS[i] = GameCanvas.loadImage("/e/w" + i + ".png");
		}
		GameCanvas.wsX = new int[2];
		GameCanvas.wsY = new int[2];
		GameCanvas.wsState = new int[2];
		GameCanvas.wsF = new int[2];
		GameCanvas.wsState[0] = (GameCanvas.wsState[1] = -1);
	}

	// Token: 0x060009B9 RID: 2489 RVA: 0x00090EF0 File Offset: 0x0008F0F0
	public bool startWaterSplash(int x, int y)
	{
		if (GameCanvas.lowGraphic)
		{
			return false;
		}
		int num = (GameCanvas.wsState[0] != -1) ? 1 : 0;
		if (GameCanvas.wsState[num] != -1)
		{
			return false;
		}
		GameCanvas.wsState[num] = 0;
		GameCanvas.wsX[num] = x;
		GameCanvas.wsY[num] = y;
		return true;
	}

	// Token: 0x060009BA RID: 2490 RVA: 0x00090F48 File Offset: 0x0008F148
	public void updateWaterSplash()
	{
		if (GameCanvas.lowGraphic)
		{
			return;
		}
		for (int i = 0; i < 2; i++)
		{
			if (GameCanvas.wsState[i] != -1)
			{
				GameCanvas.wsY[i]--;
				if (GameCanvas.gameTick % 2 == 0)
				{
					GameCanvas.wsState[i]++;
					if (GameCanvas.wsState[i] > 2)
					{
						GameCanvas.wsState[i] = -1;
					}
					else
					{
						GameCanvas.wsF[i] = GameCanvas.wsState[i];
					}
				}
			}
		}
	}

	// Token: 0x060009BB RID: 2491 RVA: 0x00090FD4 File Offset: 0x0008F1D4
	public void updateDust()
	{
		if (GameCanvas.lowGraphic)
		{
			return;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.dustState[i] != -1)
			{
				this.dustState[i]++;
				if (this.dustState[i] >= 5)
				{
					this.dustState[i] = -1;
				}
				if (i == 0)
				{
					this.dustX[i]--;
				}
				else
				{
					this.dustX[i]++;
				}
				this.dustY[i]--;
			}
		}
	}

	// Token: 0x060009BC RID: 2492 RVA: 0x00091074 File Offset: 0x0008F274
	public static bool isPaint(int x, int y)
	{
		return x >= GameScr.cmx && x <= GameScr.cmx + GameScr.gW && y >= GameScr.cmy && y <= GameScr.cmy + GameScr.gH + 30;
	}

	// Token: 0x060009BD RID: 2493 RVA: 0x000910C8 File Offset: 0x0008F2C8
	public void paintDust(mGraphics g)
	{
		if (GameCanvas.lowGraphic)
		{
			return;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.dustState[i] != -1 && GameCanvas.isPaint(this.dustX[i], this.dustY[i]))
			{
				g.drawImage(GameCanvas.imgDust[i][this.dustState[i]], this.dustX[i], this.dustY[i], 3);
			}
		}
	}

	// Token: 0x060009BE RID: 2494 RVA: 0x00091144 File Offset: 0x0008F344
	public void loadDust()
	{
		if (GameCanvas.lowGraphic)
		{
			return;
		}
		if (GameCanvas.imgDust == null)
		{
			GameCanvas.imgDust = new Image[2][];
			for (int i = 0; i < GameCanvas.imgDust.Length; i++)
			{
				GameCanvas.imgDust[i] = new Image[5];
			}
			for (int j = 0; j < 2; j++)
			{
				for (int k = 0; k < 5; k++)
				{
					GameCanvas.imgDust[j][k] = GameCanvas.loadImage(string.Concat(new object[]
					{
						"/e/d",
						j,
						k,
						".png"
					}));
				}
			}
		}
		this.dustX = new int[2];
		this.dustY = new int[2];
		this.dustState = new int[2];
		this.dustState[0] = (this.dustState[1] = -1);
	}

	// Token: 0x060009BF RID: 2495 RVA: 0x00091230 File Offset: 0x0008F430
	public static void paintShukiren(int x, int y, mGraphics g)
	{
		g.drawRegion(GameCanvas.imgShuriken, 0, Main.f * 16, 16, 16, 0, x, y, mGraphics.HCENTER | mGraphics.VCENTER);
	}

	// Token: 0x060009C0 RID: 2496 RVA: 0x00007F1A File Offset: 0x0000611A
	public void resetToLoginScrz()
	{
		this.resetToLoginScr = true;
	}

	// Token: 0x060009C1 RID: 2497 RVA: 0x00090604 File Offset: 0x0008E804
	public static bool isPointer(int x, int y, int w, int h)
	{
		return (GameCanvas.isPointerDown || GameCanvas.isPointerJustRelease) && (GameCanvas.px >= x && GameCanvas.px <= x + w && GameCanvas.py >= y && GameCanvas.py <= y + h);
	}

	// Token: 0x060009C2 RID: 2498 RVA: 0x00091264 File Offset: 0x0008F464
	public void perform(int idAction, object p)
	{
		switch (idAction)
		{
		case 88810:
		{
			int playerMapId = (int)p;
			GameCanvas.endDlg();
			Service.gI().acceptInviteTrade(playerMapId);
			break;
		}
		case 88811:
			GameCanvas.endDlg();
			Service.gI().cancelInviteTrade();
			break;
		default:
			switch (idAction)
			{
			case 8881:
			{
				string url = (string)p;
				try
				{
					GameMidlet.instance.platformRequest(url);
				}
				catch (Exception ex)
				{
				}
				GameCanvas.currentDialog = null;
				break;
			}
			case 8882:
				InfoDlg.hide();
				GameCanvas.currentDialog = null;
				break;
			default:
				switch (idAction)
				{
				case 888391:
				{
					string s = (string)p;
					GameCanvas.endDlg();
					Service.gI().clearAccProtect(int.Parse(s));
					break;
				}
				case 888392:
					Service.gI().menu(4, GameCanvas.menu.menuSelectedItem, 0);
					break;
				case 888393:
					if (GameCanvas.loginScr == null)
					{
						GameCanvas.loginScr = new LoginScr();
					}
					GameCanvas.loginScr.doLogin();
					Main.closeKeyBoard();
					break;
				case 888394:
					GameCanvas.endDlg();
					break;
				case 888395:
					GameCanvas.endDlg();
					break;
				case 888396:
					GameCanvas.endDlg();
					break;
				case 888397:
				{
					string text = (string)p;
					break;
				}
				default:
					if (idAction != 999)
					{
						if (idAction != 9000)
						{
							if (idAction != 9999)
							{
								if (idAction != 101023)
								{
									if (idAction == 888361)
									{
										string text2 = GameCanvas.inputDlg.tfInput.getText();
										GameCanvas.endDlg();
										if (text2.Length < 6 || text2.Equals(string.Empty))
										{
											GameCanvas.startOKDlg(mResources.ALERT_PRIVATE_PASS_1);
										}
										else
										{
											try
											{
												Service.gI().activeAccProtect(int.Parse(text2));
											}
											catch (Exception ex2)
											{
												GameCanvas.startOKDlg(mResources.ALERT_PRIVATE_PASS_2);
												Cout.println("Loi tai 888361 Gamescavas " + ex2.ToString());
											}
										}
									}
								}
								else
								{
									Main.numberQuit = 0;
								}
							}
							else
							{
								GameCanvas.endDlg();
								GameCanvas.connect();
								Service.gI().setClientType();
								if (GameCanvas.loginScr == null)
								{
									GameCanvas.loginScr = new LoginScr();
								}
								GameCanvas.loginScr.doLogin();
							}
						}
						else
						{
							GameCanvas.endDlg();
							SplashScr.imgLogo = null;
							SmallImage.loadBigRMS();
							mSystem.gcc();
							ServerListScreen.bigOk = true;
							ServerListScreen.loadScreen = true;
							GameScr.gI().loadGameScr();
							if (GameCanvas.currentScreen != GameCanvas.loginScr)
							{
								GameCanvas.serverScreen.switchToMe2();
							}
						}
					}
					else
					{
						mSystem.closeBanner();
						GameCanvas.endDlg();
					}
					break;
				}
				break;
			case 8884:
				GameCanvas.endDlg();
				GameCanvas.loginScr.switchToMe();
				break;
			case 8885:
				GameMidlet.instance.exit();
				break;
			case 8886:
			{
				GameCanvas.endDlg();
				string name = (string)p;
				Service.gI().addFriend(name);
				break;
			}
			case 8887:
			{
				GameCanvas.endDlg();
				int charId = (int)p;
				Service.gI().addPartyAccept(charId);
				break;
			}
			case 8888:
			{
				int charId2 = (int)p;
				Service.gI().addPartyCancel(charId2);
				GameCanvas.endDlg();
				break;
			}
			case 8889:
			{
				string str = (string)p;
				GameCanvas.endDlg();
				Service.gI().acceptPleaseParty(str);
				break;
			}
			}
			break;
		case 88814:
		{
			Item[] items = (Item[])p;
			GameCanvas.endDlg();
			Service.gI().crystalCollectLock(items);
			break;
		}
		case 88815:
			break;
		case 88817:
			ChatPopup.addChatPopup(string.Empty, 1, global::Char.myCharz().npcFocus);
			Service.gI().menu(global::Char.myCharz().npcFocus.template.npcTemplateId, GameCanvas.menu.menuSelectedItem, 0);
			break;
		case 88818:
		{
			short menuId = (short)p;
			Service.gI().textBoxId(menuId, GameCanvas.inputDlg.tfInput.getText());
			GameCanvas.endDlg();
			break;
		}
		case 88819:
		{
			short menuId2 = (short)p;
			Service.gI().menuId(menuId2);
			break;
		}
		case 88820:
		{
			string[] array = (string[])p;
			if (global::Char.myCharz().npcFocus == null)
			{
				return;
			}
			int menuSelectedItem = GameCanvas.menu.menuSelectedItem;
			if (array.Length > 1)
			{
				MyVector myVector = new MyVector();
				for (int i = 0; i < array.Length - 1; i++)
				{
					myVector.addElement(new Command(array[i + 1], GameCanvas.instance, 88821, menuSelectedItem));
				}
				GameCanvas.menu.startAt(myVector, 3);
			}
			else
			{
				ChatPopup.addChatPopup(string.Empty, 1, global::Char.myCharz().npcFocus);
				Service.gI().menu(global::Char.myCharz().npcFocus.template.npcTemplateId, menuSelectedItem, 0);
			}
			break;
		}
		case 88821:
		{
			int menuId3 = (int)p;
			ChatPopup.addChatPopup(string.Empty, 1, global::Char.myCharz().npcFocus);
			Service.gI().menu(global::Char.myCharz().npcFocus.template.npcTemplateId, menuId3, GameCanvas.menu.menuSelectedItem);
			break;
		}
		case 88822:
			ChatPopup.addChatPopup(string.Empty, 1, global::Char.myCharz().npcFocus);
			Service.gI().menu(global::Char.myCharz().npcFocus.template.npcTemplateId, GameCanvas.menu.menuSelectedItem, 0);
			break;
		case 88823:
			GameCanvas.startOKDlg(mResources.SENTMSG);
			break;
		case 88824:
			GameCanvas.startOKDlg(mResources.NOSENDMSG);
			break;
		case 88825:
			GameCanvas.startOKDlg(mResources.sendMsgSuccess, false);
			break;
		case 88826:
			GameCanvas.startOKDlg(mResources.cannotSendMsg, false);
			break;
		case 88827:
			GameCanvas.startOKDlg(mResources.sendGuessMsgSuccess);
			break;
		case 88828:
			GameCanvas.startOKDlg(mResources.sendMsgFail);
			break;
		case 88829:
		{
			string text3 = GameCanvas.inputDlg.tfInput.getText();
			if (text3.Equals(string.Empty))
			{
				return;
			}
			Service.gI().changeName(text3, (int)p);
			InfoDlg.showWait();
			break;
		}
		case 88836:
			GameCanvas.inputDlg.tfInput.setMaxTextLenght(6);
			GameCanvas.inputDlg.show(mResources.INPUT_PRIVATE_PASS, new Command(mResources.ACCEPT, GameCanvas.instance, 888361, null), TField.INPUT_TYPE_NUMERIC);
			break;
		case 88837:
		{
			string text4 = GameCanvas.inputDlg.tfInput.getText();
			GameCanvas.endDlg();
			try
			{
				Service.gI().openLockAccProtect(int.Parse(text4.Trim()));
			}
			catch (Exception ex3)
			{
				Cout.println("Loi tai 88837 " + ex3.ToString());
			}
			break;
		}
		case 88839:
		{
			string text5 = GameCanvas.inputDlg.tfInput.getText();
			GameCanvas.endDlg();
			if (text5.Length < 6 || text5.Equals(string.Empty))
			{
				GameCanvas.startOKDlg(mResources.ALERT_PRIVATE_PASS_1);
			}
			else
			{
				try
				{
					GameCanvas.startYesNoDlg(mResources.cancelAccountProtection, 888391, text5, 8882, null);
				}
				catch (Exception ex4)
				{
					GameCanvas.startOKDlg(mResources.ALERT_PRIVATE_PASS_2);
				}
			}
			break;
		}
		}
	}

	// Token: 0x060009C3 RID: 2499 RVA: 0x00007F23 File Offset: 0x00006123
	public static void clearAllPointerEvent()
	{
		GameCanvas.isPointerClick = false;
		GameCanvas.isPointerDown = false;
		GameCanvas.isPointerJustDown = false;
		GameCanvas.isPointerJustRelease = false;
		GameScr.gI().lastSingleClick = 0L;
		GameScr.gI().isPointerDowning = false;
	}

	// Token: 0x060009C4 RID: 2500 RVA: 0x00003984 File Offset: 0x00001B84
	public static void backToRegister()
	{
	}

	// Token: 0x04001181 RID: 4481
	public static long timeNow = 0L;

	// Token: 0x04001182 RID: 4482
	public static bool open3Hour;

	// Token: 0x04001183 RID: 4483
	public static bool lowGraphic = false;

	// Token: 0x04001184 RID: 4484
	public static bool isMoveNumberPad = true;

	// Token: 0x04001185 RID: 4485
	public static bool isLoading;

	// Token: 0x04001186 RID: 4486
	public static bool isTouch = false;

	// Token: 0x04001187 RID: 4487
	public static bool isTouchControl;

	// Token: 0x04001188 RID: 4488
	public static bool isTouchControlSmallScreen;

	// Token: 0x04001189 RID: 4489
	public static bool isTouchControlLargeScreen;

	// Token: 0x0400118A RID: 4490
	public static bool isConnectFail;

	// Token: 0x0400118B RID: 4491
	public static GameCanvas instance;

	// Token: 0x0400118C RID: 4492
	public static bool bRun;

	// Token: 0x0400118D RID: 4493
	public static bool[] keyPressed = new bool[30];

	// Token: 0x0400118E RID: 4494
	public static bool[] keyReleased = new bool[30];

	// Token: 0x0400118F RID: 4495
	public static bool[] keyHold = new bool[30];

	// Token: 0x04001190 RID: 4496
	public static bool isPointerDown;

	// Token: 0x04001191 RID: 4497
	public static bool isPointerClick;

	// Token: 0x04001192 RID: 4498
	public static bool isPointerJustRelease;

	// Token: 0x04001193 RID: 4499
	public static bool isPointerMove;

	// Token: 0x04001194 RID: 4500
	public static int px;

	// Token: 0x04001195 RID: 4501
	public static int py;

	// Token: 0x04001196 RID: 4502
	public static int pxFirst;

	// Token: 0x04001197 RID: 4503
	public static int pyFirst;

	// Token: 0x04001198 RID: 4504
	public static int pxLast;

	// Token: 0x04001199 RID: 4505
	public static int pyLast;

	// Token: 0x0400119A RID: 4506
	public static int pxMouse;

	// Token: 0x0400119B RID: 4507
	public static int pyMouse;

	// Token: 0x0400119C RID: 4508
	public static Position[] arrPos = new Position[4];

	// Token: 0x0400119D RID: 4509
	public static int gameTick;

	// Token: 0x0400119E RID: 4510
	public static int taskTick;

	// Token: 0x0400119F RID: 4511
	public static bool isEff1;

	// Token: 0x040011A0 RID: 4512
	public static bool isEff2;

	// Token: 0x040011A1 RID: 4513
	public static long timeTickEff1;

	// Token: 0x040011A2 RID: 4514
	public static long timeTickEff2;

	// Token: 0x040011A3 RID: 4515
	public static int w;

	// Token: 0x040011A4 RID: 4516
	public static int h;

	// Token: 0x040011A5 RID: 4517
	public static int hw;

	// Token: 0x040011A6 RID: 4518
	public static int hh;

	// Token: 0x040011A7 RID: 4519
	public static int wd3;

	// Token: 0x040011A8 RID: 4520
	public static int hd3;

	// Token: 0x040011A9 RID: 4521
	public static int w2d3;

	// Token: 0x040011AA RID: 4522
	public static int h2d3;

	// Token: 0x040011AB RID: 4523
	public static int w3d4;

	// Token: 0x040011AC RID: 4524
	public static int h3d4;

	// Token: 0x040011AD RID: 4525
	public static int wd6;

	// Token: 0x040011AE RID: 4526
	public static int hd6;

	// Token: 0x040011AF RID: 4527
	public static mScreen currentScreen;

	// Token: 0x040011B0 RID: 4528
	public static Menu menu = new Menu();

	// Token: 0x040011B1 RID: 4529
	public static Panel panel;

	// Token: 0x040011B2 RID: 4530
	public static Panel panel2;

	// Token: 0x040011B3 RID: 4531
	public static LoginScr loginScr;

	// Token: 0x040011B4 RID: 4532
	public static RegisterScreen registerScr;

	// Token: 0x040011B5 RID: 4533
	public static Dialog currentDialog;

	// Token: 0x040011B6 RID: 4534
	public static MsgDlg msgdlg;

	// Token: 0x040011B7 RID: 4535
	public static InputDlg inputDlg;

	// Token: 0x040011B8 RID: 4536
	public static MyVector currentPopup = new MyVector();

	// Token: 0x040011B9 RID: 4537
	public static int requestLoseCount;

	// Token: 0x040011BA RID: 4538
	public static MyVector listPoint;

	// Token: 0x040011BB RID: 4539
	public static Paint paintz;

	// Token: 0x040011BC RID: 4540
	public static bool isGetResFromServer;

	// Token: 0x040011BD RID: 4541
	public static Image[] imgBG;

	// Token: 0x040011BE RID: 4542
	public static int skyColor;

	// Token: 0x040011BF RID: 4543
	public static int curPos = 0;

	// Token: 0x040011C0 RID: 4544
	public static int[] bgW;

	// Token: 0x040011C1 RID: 4545
	public static int[] bgH;

	// Token: 0x040011C2 RID: 4546
	public static int planet = 0;

	// Token: 0x040011C3 RID: 4547
	private mGraphics g = new mGraphics();

	// Token: 0x040011C4 RID: 4548
	public static Image img12;

	// Token: 0x040011C5 RID: 4549
	public static Image[] imgBlue = new Image[7];

	// Token: 0x040011C6 RID: 4550
	public static Image[] imgViolet = new Image[7];

	// Token: 0x040011C7 RID: 4551
	public static bool isPlaySound = true;

	// Token: 0x040011C8 RID: 4552
	private static int clearOldData;

	// Token: 0x040011C9 RID: 4553
	public static int timeOpenKeyBoard;

	// Token: 0x040011CA RID: 4554
	public static bool isFocusPanel2;

	// Token: 0x040011CB RID: 4555
	public bool isPaintCarret;

	// Token: 0x040011CC RID: 4556
	public static MyVector debugUpdate;

	// Token: 0x040011CD RID: 4557
	public static MyVector debugPaint;

	// Token: 0x040011CE RID: 4558
	public static MyVector debugSession;

	// Token: 0x040011CF RID: 4559
	private static bool isShowErrorForm = false;

	// Token: 0x040011D0 RID: 4560
	public static bool paintBG;

	// Token: 0x040011D1 RID: 4561
	public static int gsskyHeight;

	// Token: 0x040011D2 RID: 4562
	public static int gsgreenField1Y;

	// Token: 0x040011D3 RID: 4563
	public static int gsgreenField2Y;

	// Token: 0x040011D4 RID: 4564
	public static int gshouseY;

	// Token: 0x040011D5 RID: 4565
	public static int gsmountainY;

	// Token: 0x040011D6 RID: 4566
	public static int bgLayer0y;

	// Token: 0x040011D7 RID: 4567
	public static int bgLayer1y;

	// Token: 0x040011D8 RID: 4568
	public static Image imgCloud;

	// Token: 0x040011D9 RID: 4569
	public static Image imgSun;

	// Token: 0x040011DA RID: 4570
	public static Image imgSun2;

	// Token: 0x040011DB RID: 4571
	public static Image imgClear;

	// Token: 0x040011DC RID: 4572
	public static Image[] imgBorder = new Image[3];

	// Token: 0x040011DD RID: 4573
	public static Image[] imgSunSpec = new Image[3];

	// Token: 0x040011DE RID: 4574
	public static int borderConnerW;

	// Token: 0x040011DF RID: 4575
	public static int borderConnerH;

	// Token: 0x040011E0 RID: 4576
	public static int borderCenterW;

	// Token: 0x040011E1 RID: 4577
	public static int borderCenterH;

	// Token: 0x040011E2 RID: 4578
	public static int[] cloudX;

	// Token: 0x040011E3 RID: 4579
	public static int[] cloudY;

	// Token: 0x040011E4 RID: 4580
	public static int sunX;

	// Token: 0x040011E5 RID: 4581
	public static int sunY;

	// Token: 0x040011E6 RID: 4582
	public static int sunX2;

	// Token: 0x040011E7 RID: 4583
	public static int sunY2;

	// Token: 0x040011E8 RID: 4584
	public static int[] layerSpeed;

	// Token: 0x040011E9 RID: 4585
	public static int[] moveX;

	// Token: 0x040011EA RID: 4586
	public static int[] moveXSpeed;

	// Token: 0x040011EB RID: 4587
	public static bool isBoltEff;

	// Token: 0x040011EC RID: 4588
	public static bool boltActive;

	// Token: 0x040011ED RID: 4589
	public static int tBolt;

	// Token: 0x040011EE RID: 4590
	public static int typeBg = -1;

	// Token: 0x040011EF RID: 4591
	public static int transY;

	// Token: 0x040011F0 RID: 4592
	public static int[] yb = new int[5];

	// Token: 0x040011F1 RID: 4593
	public static int[] colorTop;

	// Token: 0x040011F2 RID: 4594
	public static int[] colorBotton;

	// Token: 0x040011F3 RID: 4595
	public static int yb1;

	// Token: 0x040011F4 RID: 4596
	public static int yb2;

	// Token: 0x040011F5 RID: 4597
	public static int yb3;

	// Token: 0x040011F6 RID: 4598
	public static int nBg = 0;

	// Token: 0x040011F7 RID: 4599
	public static int lastBg = -1;

	// Token: 0x040011F8 RID: 4600
	public static int[] bgRain = new int[]
	{
		1,
		4,
		11
	};

	// Token: 0x040011F9 RID: 4601
	public static int[] bgRainFont = new int[]
	{
		-1
	};

	// Token: 0x040011FA RID: 4602
	public static Image imgCaycot;

	// Token: 0x040011FB RID: 4603
	public static Image tam;

	// Token: 0x040011FC RID: 4604
	public static int typeBackGround = -1;

	// Token: 0x040011FD RID: 4605
	public static int saveIDBg = -10;

	// Token: 0x040011FE RID: 4606
	public static bool isLoadBGok;

	// Token: 0x040011FF RID: 4607
	private static long lastTimePress = 0L;

	// Token: 0x04001200 RID: 4608
	public static int keyAsciiPress;

	// Token: 0x04001201 RID: 4609
	public static int pXYScrollMouse;

	// Token: 0x04001202 RID: 4610
	private static Image imgSignal;

	// Token: 0x04001203 RID: 4611
	public static MyVector flyTexts = new MyVector();

	// Token: 0x04001204 RID: 4612
	public int longTime;

	// Token: 0x04001205 RID: 4613
	public static bool isPointerJustDown = false;

	// Token: 0x04001206 RID: 4614
	private int count = 1;

	// Token: 0x04001207 RID: 4615
	public static bool csWait;

	// Token: 0x04001208 RID: 4616
	public static MyRandom r = new MyRandom();

	// Token: 0x04001209 RID: 4617
	public static bool isBlackScreen;

	// Token: 0x0400120A RID: 4618
	public static int[] bgSpeed;

	// Token: 0x0400120B RID: 4619
	public static int cmdBarX;

	// Token: 0x0400120C RID: 4620
	public static int cmdBarY;

	// Token: 0x0400120D RID: 4621
	public static int cmdBarW;

	// Token: 0x0400120E RID: 4622
	public static int cmdBarH;

	// Token: 0x0400120F RID: 4623
	public static int cmdBarLeftW;

	// Token: 0x04001210 RID: 4624
	public static int cmdBarRightW;

	// Token: 0x04001211 RID: 4625
	public static int cmdBarCenterW;

	// Token: 0x04001212 RID: 4626
	public static int hpBarX;

	// Token: 0x04001213 RID: 4627
	public static int hpBarY;

	// Token: 0x04001214 RID: 4628
	public static int hpBarW;

	// Token: 0x04001215 RID: 4629
	public static int expBarW;

	// Token: 0x04001216 RID: 4630
	public static int lvPosX;

	// Token: 0x04001217 RID: 4631
	public static int moneyPosX;

	// Token: 0x04001218 RID: 4632
	public static int hpBarH;

	// Token: 0x04001219 RID: 4633
	public static int girlHPBarY;

	// Token: 0x0400121A RID: 4634
	public int timeOut;

	// Token: 0x0400121B RID: 4635
	public int[] dustX;

	// Token: 0x0400121C RID: 4636
	public int[] dustY;

	// Token: 0x0400121D RID: 4637
	public int[] dustState;

	// Token: 0x0400121E RID: 4638
	public static int[] wsX;

	// Token: 0x0400121F RID: 4639
	public static int[] wsY;

	// Token: 0x04001220 RID: 4640
	public static int[] wsState;

	// Token: 0x04001221 RID: 4641
	public static int[] wsF;

	// Token: 0x04001222 RID: 4642
	public static Image[] imgWS;

	// Token: 0x04001223 RID: 4643
	public static Image imgShuriken;

	// Token: 0x04001224 RID: 4644
	public static Image[][] imgDust;

	// Token: 0x04001225 RID: 4645
	public static bool isResume;

	// Token: 0x04001226 RID: 4646
	public static ServerListScreen serverScreen;

	// Token: 0x04001227 RID: 4647
	public static ServerScr serverScr;

	// Token: 0x04001228 RID: 4648
	public bool resetToLoginScr;
}
