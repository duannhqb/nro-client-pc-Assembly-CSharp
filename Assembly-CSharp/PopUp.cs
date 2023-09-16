using System;

// Token: 0x02000075 RID: 117
public class PopUp
{
	// Token: 0x060003BD RID: 957 RVA: 0x00020CDC File Offset: 0x0001EEDC
	public PopUp(string info, int x, int y)
	{
		this.sayWidth = 100;
		if (info.Length < 10)
		{
			this.sayWidth = 60;
		}
		if (GameCanvas.w == 128)
		{
			this.sayWidth = 128;
		}
		this.says = mFont.tahoma_7b_dark.splitFontArray(info, this.sayWidth - 10);
		this.sayRun = 7;
		this.cx = x - this.sayWidth / 2 - 1;
		this.cy = y - 15 + this.sayRun - this.says.Length * 12 - 10;
		this.cw = this.sayWidth + 2;
		this.ch = (this.says.Length + 1) * 12 + 1;
		while (this.cw % 10 != 0)
		{
			this.cw++;
		}
		while (this.ch % 10 != 0)
		{
			this.ch++;
		}
		if (x >= 0 && x <= 24)
		{
			this.cx += this.cw / 2 + 30;
		}
		if (x <= TileMap.tmw * 24 && x >= TileMap.tmw * 24 - 24)
		{
			this.cx -= this.cw / 2 + 6;
		}
		while (this.cx <= 30)
		{
			this.cx += 2;
		}
		while (this.cx + this.cw >= TileMap.tmw * 24 - 30)
		{
			this.cx -= 2;
		}
	}

	// Token: 0x060003BE RID: 958 RVA: 0x00020E94 File Offset: 0x0001F094
	public static void loadBg()
	{
		if (PopUp.goc == null)
		{
			PopUp.goc = GameCanvas.loadImage("/mainImage/myTexture2dbd3.png");
		}
		if (PopUp.imgPopUp == null)
		{
			PopUp.imgPopUp = GameCanvas.loadImage("/mainImage/myTexture2dimgPopup.png");
		}
		if (PopUp.imgPopUp2 == null)
		{
			PopUp.imgPopUp2 = GameCanvas.loadImage("/mainImage/myTexture2dimgPopup2.png");
		}
	}

	// Token: 0x060003BF RID: 959 RVA: 0x00020EEC File Offset: 0x0001F0EC
	public void updateXYWH(string[] info, int x, int y)
	{
		this.sayWidth = 0;
		for (int i = 0; i < info.Length; i++)
		{
			if (this.sayWidth < mFont.tahoma_7b_dark.getWidth(info[i]))
			{
				this.sayWidth = mFont.tahoma_7b_dark.getWidth(info[i]);
			}
		}
		this.sayWidth += 20;
		this.says = info;
		this.sayRun = 7;
		this.cx = x - this.sayWidth / 2 - 1;
		this.cy = y - 15 + this.sayRun - this.says.Length * 12 - 10;
		this.cw = this.sayWidth + 2;
		this.ch = (this.says.Length + 1) * 12 + 1;
		while (this.cw % 10 != 0)
		{
			this.cw++;
		}
		while (this.ch % 10 != 0)
		{
			this.ch++;
		}
		if (x >= 0 && x <= 24)
		{
			this.cx += this.cw / 2 + 30;
		}
		if (x <= TileMap.tmw * 24 && x >= TileMap.tmw * 24 - 24)
		{
			this.cx -= this.cw / 2 + 6;
		}
		while (this.cx <= 30)
		{
			this.cx += 2;
		}
		while (this.cx + this.cw >= TileMap.tmw * 24 - 30)
		{
			this.cx -= 2;
		}
	}

	// Token: 0x060003C0 RID: 960 RVA: 0x000058C1 File Offset: 0x00003AC1
	public static void addPopUp(int x, int y, string info)
	{
		PopUp.vPopups.addElement(new PopUp(info, x, y));
	}

	// Token: 0x060003C1 RID: 961 RVA: 0x000058D5 File Offset: 0x00003AD5
	public static void addPopUp(PopUp p)
	{
		PopUp.vPopups.addElement(p);
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x000058E2 File Offset: 0x00003AE2
	public static void removePopUp(PopUp p)
	{
		PopUp.vPopups.removeElement(p);
	}

	// Token: 0x060003C3 RID: 963 RVA: 0x000058EF File Offset: 0x00003AEF
	public void paintClipPopUp(mGraphics g, int x, int y, int w, int h, int color, bool isFocus)
	{
		if (color == 1)
		{
			g.fillRect(x, y, w, h, 16777215, 90);
		}
		else
		{
			g.fillRect(x, y, w, h, 0, 77);
		}
	}

	// Token: 0x060003C4 RID: 964 RVA: 0x000210A0 File Offset: 0x0001F2A0
	public static void paintPopUp(mGraphics g, int x, int y, int w, int h, int color, bool isButton)
	{
		if (!isButton)
		{
			g.setColor(0);
			g.fillRect(x + 6, y, w - 14 + 1, h);
			g.fillRect(x, y + 6, w, h - 12 + 1);
			g.setColor(color);
			g.fillRect(x + 6, y + 1, w - 12, h - 2);
			g.fillRect(x + 1, y + 6, w - 2, h - 12);
			g.drawRegion(PopUp.goc, 0, 0, 7, 6, 0, x, y, 0);
			g.drawRegion(PopUp.goc, 0, 0, 7, 6, 2, x + w - 7, y, 0);
			g.drawRegion(PopUp.goc, 0, 0, 7, 6, 1, x, y + h - 6, 0);
			g.drawRegion(PopUp.goc, 0, 0, 7, 6, 3, x + w - 7, y + h - 6, 0);
		}
		else
		{
			Image arg = (color != 1) ? PopUp.imgPopUp : PopUp.imgPopUp2;
			g.drawRegion(arg, 0, 0, 10, 10, 0, x, y, 0);
			g.drawRegion(arg, 0, 20, 10, 10, 0, x + w - 10, y, 0);
			g.drawRegion(arg, 0, 50, 10, 10, 0, x, y + h - 10, 0);
			g.drawRegion(arg, 0, 70, 10, 10, 0, x + w - 10, y + h - 10, 0);
			int num = ((w - 20) % 10 != 0) ? ((w - 20) / 10 + 1) : ((w - 20) / 10);
			int num2 = ((h - 20) % 10 != 0) ? ((h - 20) / 10 + 1) : ((h - 20) / 10);
			for (int i = 0; i < num; i++)
			{
				g.drawRegion(arg, 0, 10, 10, 10, 0, x + 10 + i * 10, y, 0);
			}
			for (int j = 0; j < num2; j++)
			{
				g.drawRegion(arg, 0, 30, 10, 10, 0, x, y + 10 + j * 10, 0);
			}
			for (int k = 0; k < num; k++)
			{
				g.drawRegion(arg, 0, 60, 10, 10, 0, x + 10 + k * 10, y + h - 10, 0);
			}
			for (int l = 0; l < num2; l++)
			{
				g.drawRegion(arg, 0, 40, 10, 10, 0, x + w - 10, y + 10 + l * 10, 0);
			}
			g.setColor((color != 1) ? 16770503 : 12052656);
			g.fillRect(x + 10, y + 10, w - 20, h - 20);
		}
	}

	// Token: 0x060003C5 RID: 965 RVA: 0x0002132C File Offset: 0x0001F52C
	public void paint(mGraphics g)
	{
		if (!this.isPaint)
		{
			return;
		}
		if (this.says == null)
		{
			return;
		}
		if (ChatPopup.currChatPopup != null)
		{
			return;
		}
		if (!this.isHide)
		{
			this.paintClipPopUp(g, this.cx, this.cy - GameCanvas.transY, this.cw, this.ch, (this.timeDelay != 0) ? 1 : 0, true);
			for (int i = 0; i < this.says.Length; i++)
			{
				((this.timeDelay != 0) ? mFont.tahoma_7b_green2 : mFont.tahoma_7b_white).drawString(g, this.says[i], this.cx + this.cw / 2, this.cy + (this.ch / 2 - this.says.Length * 12 / 2) + i * 12 - GameCanvas.transY, 2);
			}
		}
	}

	// Token: 0x060003C6 RID: 966 RVA: 0x00021418 File Offset: 0x0001F618
	private void update()
	{
		if (global::Char.myCharz().taskMaint != null && global::Char.myCharz().taskMaint.taskId == 0)
		{
			if (this.cx + this.cw >= GameScr.cmx && this.cx <= GameCanvas.w + GameScr.cmx && this.cy + this.ch >= GameScr.cmy && this.cy <= GameCanvas.h + GameScr.cmy)
			{
				this.isHide = false;
			}
			else
			{
				this.isHide = true;
			}
		}
		if (global::Char.myCharz().taskMaint == null || (global::Char.myCharz().taskMaint != null && global::Char.myCharz().taskMaint.taskId != 0))
		{
			if (this.cx + this.cw / 2 >= global::Char.myCharz().cx - 100 && this.cx + this.cw / 2 <= global::Char.myCharz().cx + 100 && this.cy + this.ch >= GameScr.cmy && this.cy <= GameCanvas.h + GameScr.cmy)
			{
				this.isHide = false;
			}
			else
			{
				this.isHide = true;
			}
		}
		if (this.timeDelay > 0)
		{
			this.timeDelay--;
			if (this.timeDelay == 0 && this.command != null)
			{
				this.command.performAction();
			}
		}
		if (this.isWayPoint)
		{
			if (global::Char.myCharz().taskMaint != null)
			{
				if (global::Char.myCharz().taskMaint.taskId == 0)
				{
					if (global::Char.myCharz().taskMaint.index == 0)
					{
						this.isPaint = false;
					}
					if (global::Char.myCharz().taskMaint.index == 1)
					{
						this.isPaint = true;
					}
					if (global::Char.myCharz().taskMaint.index > 1 && global::Char.myCharz().taskMaint.index < 6)
					{
						this.isPaint = false;
					}
				}
				else if (!this.isPaint)
				{
					this.tDelay++;
					if (this.tDelay == 50)
					{
						this.isPaint = true;
					}
				}
			}
			else if (!this.isPaint)
			{
				Hint.isPaint = false;
				this.tDelay++;
				if (this.tDelay == 50)
				{
					this.isPaint = true;
					Hint.isPaint = true;
				}
			}
		}
	}

	// Token: 0x060003C7 RID: 967 RVA: 0x00005920 File Offset: 0x00003B20
	public void doClick(int timeDelay)
	{
		this.timeDelay = timeDelay;
	}

	// Token: 0x060003C8 RID: 968 RVA: 0x000216AC File Offset: 0x0001F8AC
	public static void paintAll(mGraphics g)
	{
		for (int i = 0; i < PopUp.vPopups.size(); i++)
		{
			((PopUp)PopUp.vPopups.elementAt(i)).paint(g);
		}
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x000216EC File Offset: 0x0001F8EC
	public static void updateAll()
	{
		for (int i = 0; i < PopUp.vPopups.size(); i++)
		{
			((PopUp)PopUp.vPopups.elementAt(i)).update();
		}
	}

	// Token: 0x04000654 RID: 1620
	public static MyVector vPopups = new MyVector();

	// Token: 0x04000655 RID: 1621
	public int sayWidth;

	// Token: 0x04000656 RID: 1622
	public int sayRun;

	// Token: 0x04000657 RID: 1623
	public string[] says;

	// Token: 0x04000658 RID: 1624
	public int cx;

	// Token: 0x04000659 RID: 1625
	public int cy;

	// Token: 0x0400065A RID: 1626
	public int cw;

	// Token: 0x0400065B RID: 1627
	public int ch;

	// Token: 0x0400065C RID: 1628
	public static int f;

	// Token: 0x0400065D RID: 1629
	public static int tF;

	// Token: 0x0400065E RID: 1630
	public static int dir;

	// Token: 0x0400065F RID: 1631
	public bool isWayPoint;

	// Token: 0x04000660 RID: 1632
	public int tDelay;

	// Token: 0x04000661 RID: 1633
	private int timeDelay;

	// Token: 0x04000662 RID: 1634
	public Command command;

	// Token: 0x04000663 RID: 1635
	public bool isPaint = true;

	// Token: 0x04000664 RID: 1636
	public bool isHide;

	// Token: 0x04000665 RID: 1637
	public static Image goc;

	// Token: 0x04000666 RID: 1638
	public static Image imgPopUp;

	// Token: 0x04000667 RID: 1639
	public static Image imgPopUp2;

	// Token: 0x04000668 RID: 1640
	public Image imgFocus;

	// Token: 0x04000669 RID: 1641
	public Image imgUnFocus;
}
