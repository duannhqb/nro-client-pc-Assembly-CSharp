using System;

// Token: 0x020000BC RID: 188
public class SplashScr : mScreen
{
	// Token: 0x06000934 RID: 2356 RVA: 0x00007A42 File Offset: 0x00005C42
	public SplashScr()
	{
		SplashScr.instance = this;
	}

	// Token: 0x06000935 RID: 2357 RVA: 0x00007A50 File Offset: 0x00005C50
	public static void loadSplashScr()
	{
		SplashScr.splashScrStat = 0;
	}

	// Token: 0x06000936 RID: 2358 RVA: 0x00089F84 File Offset: 0x00088184
	public override void update()
	{
		if (SplashScr.splashScrStat == 30 && !this.isCheckConnect)
		{
			this.isCheckConnect = true;
			if (Rms.loadRMSInt("isPlaySound") != -1)
			{
				GameCanvas.isPlaySound = (Rms.loadRMSInt("isPlaySound") == 1);
			}
			if (GameCanvas.isPlaySound)
			{
				SoundMn.gI().loadSound(TileMap.mapID);
			}
			SoundMn.gI().getStrOption();
			ServerListScreen.loadIP();
		}
		SplashScr.splashScrStat++;
		ServerListScreen.updateDeleteData();
	}

	// Token: 0x06000937 RID: 2359 RVA: 0x0008A014 File Offset: 0x00088214
	public static void loadIP()
	{
		if (Rms.loadRMSInt("svselect") == -1)
		{
			int num = 0;
			if ((int)mResources.language > 0)
			{
				for (int i = 0; i < (int)mResources.language; i++)
				{
					num += ServerListScreen.lengthServer[i];
				}
			}
			if ((int)ServerListScreen.serverPriority == -1)
			{
				ServerListScreen.ipSelect = num + Res.random(0, ServerListScreen.lengthServer[(int)mResources.language]);
			}
			else
			{
				ServerListScreen.ipSelect = (int)ServerListScreen.serverPriority;
			}
			Rms.saveRMSInt("svselect", ServerListScreen.ipSelect);
			GameMidlet.IP = ServerListScreen.address[ServerListScreen.ipSelect];
			GameMidlet.PORT = (int)ServerListScreen.port[ServerListScreen.ipSelect];
			mResources.loadLanguague(ServerListScreen.language[ServerListScreen.ipSelect]);
			LoginScr.serverName = ServerListScreen.nameServer[ServerListScreen.ipSelect];
			GameCanvas.connect();
		}
		else
		{
			ServerListScreen.ipSelect = Rms.loadRMSInt("svselect");
			if (ServerListScreen.ipSelect > ServerListScreen.nameServer.Length - 1)
			{
				ServerListScreen.ipSelect = (int)ServerListScreen.serverPriority;
				Rms.saveRMSInt("svselect", ServerListScreen.ipSelect);
			}
			GameMidlet.IP = ServerListScreen.address[ServerListScreen.ipSelect];
			GameMidlet.PORT = (int)ServerListScreen.port[ServerListScreen.ipSelect];
			mResources.loadLanguague(ServerListScreen.language[ServerListScreen.ipSelect]);
			LoginScr.serverName = ServerListScreen.nameServer[ServerListScreen.ipSelect];
			GameCanvas.connect();
		}
	}

	// Token: 0x06000938 RID: 2360 RVA: 0x0008A170 File Offset: 0x00088370
	public override void paint(mGraphics g)
	{
		if (SplashScr.imgLogo != null && SplashScr.splashScrStat < 30)
		{
			g.setColor(16777215);
			g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
			g.drawImage(SplashScr.imgLogo, GameCanvas.w / 2, GameCanvas.h / 2, 3);
		}
		if (SplashScr.nData != -1)
		{
			g.setColor(0);
			g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
			g.drawImage(LoginScr.imgTitle, GameCanvas.w / 2, GameCanvas.h / 2 - 24, StaticObj.BOTTOM_HCENTER);
			GameCanvas.paintShukiren(GameCanvas.hw, GameCanvas.h / 2 + 24, g);
			mFont.tahoma_7b_white.drawString(g, mResources.downloading_data + SplashScr.nData * 100 / SplashScr.maxData + "%", GameCanvas.w / 2, GameCanvas.h / 2, 2);
		}
		else if (SplashScr.splashScrStat >= 30)
		{
			g.setColor(0);
			g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
			GameCanvas.paintShukiren(GameCanvas.hw, GameCanvas.hh, g);
			if (ServerListScreen.cmdDeleteRMS != null)
			{
				mFont.tahoma_7_white.drawString(g, mResources.xoadulieu, GameCanvas.w - 2, GameCanvas.h - 15, 1, mFont.tahoma_7_grey);
			}
		}
	}

	// Token: 0x06000939 RID: 2361 RVA: 0x00007A58 File Offset: 0x00005C58
	public static void loadImg()
	{
		SplashScr.imgLogo = GameCanvas.loadImage("/gamelogo.png");
	}

	// Token: 0x040010C0 RID: 4288
	public static int splashScrStat;

	// Token: 0x040010C1 RID: 4289
	private bool isCheckConnect;

	// Token: 0x040010C2 RID: 4290
	private bool isSwitchToLogin;

	// Token: 0x040010C3 RID: 4291
	public static int nData = -1;

	// Token: 0x040010C4 RID: 4292
	public static int maxData = -1;

	// Token: 0x040010C5 RID: 4293
	public static SplashScr instance;

	// Token: 0x040010C6 RID: 4294
	public static Image imgLogo;
}
