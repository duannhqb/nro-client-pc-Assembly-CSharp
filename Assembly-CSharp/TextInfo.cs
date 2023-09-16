using System;

// Token: 0x0200008F RID: 143
public class TextInfo
{
	// Token: 0x0600044E RID: 1102 RVA: 0x00005FDB File Offset: 0x000041DB
	public static void reset()
	{
		TextInfo.dx = 0;
		TextInfo.tx = 0;
		TextInfo.isBack = false;
	}

	// Token: 0x0600044F RID: 1103 RVA: 0x00028804 File Offset: 0x00026A04
	public static void paint(mGraphics g, string str, int x, int y, int w, int h, mFont f)
	{
		if (TextInfo.wStr != f.getWidth(str) || !TextInfo.laststring.Equals(str))
		{
			TextInfo.laststring = str;
			TextInfo.dx = 0;
			TextInfo.wStr = f.getWidth(str);
			TextInfo.isBack = false;
			TextInfo.tx = 0;
		}
		g.setClip(x, y, w, h);
		if (TextInfo.wStr > w)
		{
			f.drawString(g, str, x - TextInfo.dx, y, 0);
		}
		else
		{
			f.drawString(g, str, x + w / 2, y, 2);
		}
		GameCanvas.resetTrans(g);
		if (TextInfo.wStr > w)
		{
			if (!TextInfo.isBack)
			{
				TextInfo.tx++;
				if (TextInfo.tx > 50)
				{
					TextInfo.dx++;
					if (TextInfo.dx >= TextInfo.wStr)
					{
						TextInfo.tx = 0;
						TextInfo.dx = -w + 30;
						TextInfo.isBack = true;
					}
				}
			}
			else
			{
				if (TextInfo.dx < 0)
				{
					int num = w + TextInfo.dx >> 1;
					TextInfo.dx += num;
				}
				if (TextInfo.dx > 0)
				{
					TextInfo.dx = 0;
				}
				if (TextInfo.dx == 0)
				{
					TextInfo.tx++;
					if (TextInfo.tx == 50)
					{
						TextInfo.tx = 0;
						TextInfo.isBack = false;
					}
				}
			}
		}
	}

	// Token: 0x0400073C RID: 1852
	public static int dx;

	// Token: 0x0400073D RID: 1853
	public static int tx;

	// Token: 0x0400073E RID: 1854
	public static int wStr;

	// Token: 0x0400073F RID: 1855
	public static bool isBack;

	// Token: 0x04000740 RID: 1856
	public static string laststring = string.Empty;
}
