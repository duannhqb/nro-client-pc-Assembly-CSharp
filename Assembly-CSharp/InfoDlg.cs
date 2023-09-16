using System;

// Token: 0x020000A6 RID: 166
public class InfoDlg
{
	// Token: 0x0600072C RID: 1836 RVA: 0x00006D9E File Offset: 0x00004F9E
	public static void show(string title, string subtitle, int delay)
	{
		if (title == null)
		{
			return;
		}
		InfoDlg.isShow = true;
		InfoDlg.title = title;
		InfoDlg.subtitke = subtitle;
		InfoDlg.delay = delay;
	}

	// Token: 0x0600072D RID: 1837 RVA: 0x00006DBF File Offset: 0x00004FBF
	public static void showWait()
	{
		InfoDlg.show(mResources.PLEASEWAIT, null, 1000);
		InfoDlg.isLock = true;
	}

	// Token: 0x0600072E RID: 1838 RVA: 0x00006DD7 File Offset: 0x00004FD7
	public static void showWait(string str)
	{
		InfoDlg.show(str, null, 700);
		InfoDlg.isLock = true;
	}

	// Token: 0x0600072F RID: 1839 RVA: 0x00064968 File Offset: 0x00062B68
	public static void paint(mGraphics g)
	{
		if (!InfoDlg.isShow)
		{
			return;
		}
		if (InfoDlg.isLock && InfoDlg.delay > 4990)
		{
			return;
		}
		if (GameScr.isPaintAlert)
		{
			return;
		}
		int num = 10;
		GameCanvas.paintz.paintPopUp(GameCanvas.hw - 75, num, 150, 55, g);
		if (InfoDlg.isLock)
		{
			GameCanvas.paintShukiren(GameCanvas.hw - mFont.tahoma_8b.getWidth(InfoDlg.title) / 2 - 10, num + 28, g);
			mFont.tahoma_8b.drawString(g, InfoDlg.title, GameCanvas.hw + 5, num + 21, 2);
		}
		else if (InfoDlg.subtitke != null)
		{
			mFont.tahoma_8b.drawString(g, InfoDlg.title, GameCanvas.hw, num + 13, 2);
			mFont.tahoma_7_green2.drawString(g, InfoDlg.subtitke, GameCanvas.hw, num + 30, 2);
		}
		else
		{
			mFont.tahoma_8b.drawString(g, InfoDlg.title, GameCanvas.hw, num + 21, 2);
		}
	}

	// Token: 0x06000730 RID: 1840 RVA: 0x00006DEB File Offset: 0x00004FEB
	public static void update()
	{
		if (InfoDlg.delay > 0)
		{
			InfoDlg.delay--;
			if (InfoDlg.delay == 0)
			{
				InfoDlg.hide();
			}
		}
	}

	// Token: 0x06000731 RID: 1841 RVA: 0x00006E13 File Offset: 0x00005013
	public static void hide()
	{
		InfoDlg.title = string.Empty;
		InfoDlg.subtitke = null;
		InfoDlg.isLock = false;
		InfoDlg.delay = 0;
		InfoDlg.isShow = false;
	}

	// Token: 0x04000D5E RID: 3422
	public static bool isShow;

	// Token: 0x04000D5F RID: 3423
	private static string title;

	// Token: 0x04000D60 RID: 3424
	private static string subtitke;

	// Token: 0x04000D61 RID: 3425
	public static int delay;

	// Token: 0x04000D62 RID: 3426
	public static bool isLock;
}
