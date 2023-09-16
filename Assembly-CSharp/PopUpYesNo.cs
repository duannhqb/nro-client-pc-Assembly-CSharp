using System;

// Token: 0x02000076 RID: 118
public class PopUpYesNo : IActionListener
{
	// Token: 0x060003CC RID: 972 RVA: 0x0002172C File Offset: 0x0001F92C
	public void setPopUp(string info, Command cmdYes, Command cmdNo)
	{
		this.info = new string[]
		{
			info
		};
		this.H = 29;
		this.cmdYes = cmdYes;
		this.cmdNo = cmdNo;
		this.cmdYes.img = (this.cmdNo.img = GameScr.imgNut);
		this.cmdYes.imgFocus = (this.cmdNo.imgFocus = GameScr.imgNutF);
		this.cmdYes.w = mGraphics.getImageWidth(cmdYes.img);
		this.cmdNo.w = mGraphics.getImageWidth(cmdYes.img);
		this.cmdYes.h = mGraphics.getImageHeight(cmdYes.img);
		this.cmdNo.h = mGraphics.getImageHeight(cmdYes.img);
		this.last = mSystem.currentTimeMillis();
		this.dem = this.info[0].Length / 3;
		if (this.dem < 15)
		{
			this.dem = 15;
		}
		TextInfo.reset();
	}

	// Token: 0x060003CD RID: 973 RVA: 0x00021830 File Offset: 0x0001FA30
	public void paint(mGraphics g)
	{
		PopUp.paintPopUp(g, this.X, this.Y, this.W, this.H + (GameCanvas.isTouch ? 0 : 10), 16777215, false);
		if (this.info != null)
		{
			TextInfo.paint(g, this.info[0], this.X + 5, this.Y + this.H / 2 - ((!GameCanvas.isTouch) ? 6 : 4), this.W - 10, this.H, mFont.tahoma_7);
			if (GameCanvas.isTouch)
			{
				this.cmdYes.paint(g);
				mFont.tahoma_7_yellow.drawString(g, this.dem + string.Empty, this.cmdYes.x + this.cmdYes.w / 2, this.cmdYes.y + this.cmdYes.h + 5, 2, mFont.tahoma_7_grey);
			}
			else if (TField.isQwerty)
			{
				mFont.tahoma_7b_blue.drawString(g, mResources.do_accept_qwerty + this.dem + ")", this.X + this.W / 2, this.Y + this.H - 6, 2);
			}
			else
			{
				mFont.tahoma_7b_blue.drawString(g, mResources.do_accept + this.dem + ")", this.X + this.W / 2, this.Y + this.H - 6, 2);
			}
		}
	}

	// Token: 0x060003CE RID: 974 RVA: 0x000219D4 File Offset: 0x0001FBD4
	public void update()
	{
		if (this.info != null)
		{
			this.X = GameCanvas.w - 5 - this.W;
			this.Y = 45;
			if (GameCanvas.w - 50 > 155 + this.W)
			{
				this.X = GameCanvas.w - 55 - this.W;
				this.Y = 5;
			}
			this.cmdYes.x = this.X - 35;
			this.cmdYes.y = this.Y;
			this.curr = mSystem.currentTimeMillis();
			Res.outz("curr - last= " + (this.curr - this.last));
			if (this.curr - this.last >= 1000L)
			{
				this.last = mSystem.currentTimeMillis();
				this.dem--;
			}
			if (this.dem == 0)
			{
				GameScr.gI().popUpYesNo = null;
			}
		}
	}

	// Token: 0x060003CF RID: 975 RVA: 0x00003984 File Offset: 0x00001B84
	public void perform(int idAction, object p)
	{
	}

	// Token: 0x0400066A RID: 1642
	public Command cmdYes;

	// Token: 0x0400066B RID: 1643
	public Command cmdNo;

	// Token: 0x0400066C RID: 1644
	public string[] info;

	// Token: 0x0400066D RID: 1645
	private int X;

	// Token: 0x0400066E RID: 1646
	private int Y;

	// Token: 0x0400066F RID: 1647
	private int W = 120;

	// Token: 0x04000670 RID: 1648
	private int H;

	// Token: 0x04000671 RID: 1649
	private int dem;

	// Token: 0x04000672 RID: 1650
	private long last;

	// Token: 0x04000673 RID: 1651
	private long curr;
}
