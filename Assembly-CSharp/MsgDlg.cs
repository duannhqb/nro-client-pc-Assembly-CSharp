using System;

// Token: 0x020000B2 RID: 178
public class MsgDlg : Dialog
{
	// Token: 0x060007BF RID: 1983 RVA: 0x0006C3CC File Offset: 0x0006A5CC
	public MsgDlg()
	{
		this.padLeft = 35;
		if (GameCanvas.w <= 176)
		{
			this.padLeft = 10;
		}
		if (GameCanvas.w > 320)
		{
			this.padLeft = 80;
		}
	}

	// Token: 0x060007C0 RID: 1984 RVA: 0x00007228 File Offset: 0x00005428
	public void pleasewait()
	{
		this.setInfo(mResources.PLEASEWAIT, null, null, null);
		GameCanvas.currentDialog = this;
		this.time = mSystem.currentTimeMillis() + 5000L;
	}

	// Token: 0x060007C1 RID: 1985 RVA: 0x00007250 File Offset: 0x00005450
	public override void show()
	{
		GameCanvas.currentDialog = this;
		this.time = -1L;
	}

	// Token: 0x060007C2 RID: 1986 RVA: 0x0006C420 File Offset: 0x0006A620
	public void setInfo(string info)
	{
		this.info = mFont.tahoma_8b.splitFontArray(info, GameCanvas.w - (this.padLeft * 2 + 20));
		this.h = 80;
		if (this.info.Length >= 5)
		{
			this.h = this.info.Length * mFont.tahoma_8b.getHeight() + 20;
		}
	}

	// Token: 0x060007C3 RID: 1987 RVA: 0x0006C484 File Offset: 0x0006A684
	public void setInfo(string info, Command left, Command center, Command right)
	{
		this.info = mFont.tahoma_8b.splitFontArray(info, GameCanvas.w - (this.padLeft * 2 + 20));
		this.left = left;
		this.center = center;
		this.right = right;
		this.h = 80;
		if (this.info.Length >= 5)
		{
			this.h = this.info.Length * mFont.tahoma_8b.getHeight() + 20;
		}
		if (GameCanvas.isTouch)
		{
			if (left != null)
			{
				this.left.x = GameCanvas.w / 2 - 68 - 5;
				this.left.y = GameCanvas.h - 50;
			}
			if (right != null)
			{
				this.right.x = GameCanvas.w / 2 + 5;
				this.right.y = GameCanvas.h - 50;
			}
			if (center != null)
			{
				this.center.x = GameCanvas.w / 2 - 35;
				this.center.y = GameCanvas.h - 50;
			}
		}
		this.isWait = false;
	}

	// Token: 0x060007C4 RID: 1988 RVA: 0x0006C598 File Offset: 0x0006A798
	public override void paint(mGraphics g)
	{
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
		if (LoginScr.isContinueToLogin)
		{
			return;
		}
		int num = GameCanvas.h - this.h - 38;
		int w = GameCanvas.w - this.padLeft * 2;
		GameCanvas.paintz.paintPopUp(this.padLeft, num, w, this.h, g);
		int num2 = num + (this.h - this.info.Length * mFont.tahoma_8b.getHeight()) / 2 - 2;
		if (this.isWait)
		{
			num2 += 8;
			GameCanvas.paintShukiren(GameCanvas.hw, num2 - 12, g);
		}
		int i = 0;
		int num3 = num2;
		while (i < this.info.Length)
		{
			mFont.tahoma_7b_dark.drawString(g, this.info[i], GameCanvas.hw, num3, 2);
			i++;
			num3 += mFont.tahoma_8b.getHeight();
		}
		base.paint(g);
	}

	// Token: 0x060007C5 RID: 1989 RVA: 0x00007260 File Offset: 0x00005460
	public override void update()
	{
		base.update();
		if (this.time != -1L && mSystem.currentTimeMillis() > this.time)
		{
			GameCanvas.endDlg();
		}
	}

	// Token: 0x04000E9B RID: 3739
	public string[] info;

	// Token: 0x04000E9C RID: 3740
	public bool isWait;

	// Token: 0x04000E9D RID: 3741
	private int h;

	// Token: 0x04000E9E RID: 3742
	private int padLeft;

	// Token: 0x04000E9F RID: 3743
	private long time = -1L;
}
