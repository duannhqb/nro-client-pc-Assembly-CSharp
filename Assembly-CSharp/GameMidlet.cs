using System;
using UnityEngine;

// Token: 0x020000C3 RID: 195
public class GameMidlet
{
	// Token: 0x060009C6 RID: 2502 RVA: 0x00007F54 File Offset: 0x00006154
	public GameMidlet()
	{
		this.initGame();
	}

	// Token: 0x060009C7 RID: 2503 RVA: 0x00091B38 File Offset: 0x0008FD38
	public void initGame()
	{
		GameMidlet.instance = this;
		MotherCanvas.instance = new MotherCanvas();
		Session_ME.gI().setHandler(Controller.gI());
		Session_ME2.gI().setHandler(Controller.gI());
		Session_ME2.isMainSession = false;
		GameMidlet.instance = this;
		GameMidlet.gameCanvas = new GameCanvas();
		GameMidlet.gameCanvas.start();
		SplashScr.loadImg();
		SplashScr.loadSplashScr();
		GameCanvas.currentScreen = new SplashScr();
	}

	// Token: 0x060009C8 RID: 2504 RVA: 0x00007F62 File Offset: 0x00006162
	public void exit()
	{
		if (Main.typeClient == 6)
		{
			mSystem.exitWP();
		}
		else
		{
			GameCanvas.bRun = false;
			mSystem.gcc();
			this.notifyDestroyed();
		}
	}

	// Token: 0x060009C9 RID: 2505 RVA: 0x00007F8A File Offset: 0x0000618A
	public static void sendSMS(string data, string to, Command successAction, Command failAction)
	{
		Cout.println("SEND SMS");
	}

	// Token: 0x060009CA RID: 2506 RVA: 0x00007F96 File Offset: 0x00006196
	public static void flatForm(string url)
	{
		Cout.LogWarning("PLATFORM REQUEST: " + url);
		Application.OpenURL(url);
	}

	// Token: 0x060009CB RID: 2507 RVA: 0x00007FAE File Offset: 0x000061AE
	public void notifyDestroyed()
	{
		Main.exit();
	}

	// Token: 0x060009CC RID: 2508 RVA: 0x00007FB5 File Offset: 0x000061B5
	public void platformRequest(string url)
	{
		Cout.LogWarning("PLATFORM REQUEST: " + url);
		Application.OpenURL(url);
	}

	// Token: 0x04001229 RID: 4649
	public static string IP = "112.213.94.23";

	// Token: 0x0400122A RID: 4650
	public static int PORT = 14445;

	// Token: 0x0400122B RID: 4651
	public static string IP2;

	// Token: 0x0400122C RID: 4652
	public static int PORT2;

	// Token: 0x0400122D RID: 4653
	public static sbyte PROVIDER;

	// Token: 0x0400122E RID: 4654
	public static string VERSION = "2.0.7";

	// Token: 0x0400122F RID: 4655
	public static GameCanvas gameCanvas;

	// Token: 0x04001230 RID: 4656
	public static GameMidlet instance;

	// Token: 0x04001231 RID: 4657
	public static bool isConnect2;

	// Token: 0x04001232 RID: 4658
	public static bool isBackWindowsPhone;
}
