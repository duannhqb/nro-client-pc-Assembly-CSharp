using System;

// Token: 0x02000070 RID: 112
public class Paint
{
	// Token: 0x06000387 RID: 903 RVA: 0x0001FBA4 File Offset: 0x0001DDA4
	public static void loadbg()
	{
		for (int i = 0; i < Paint.goc.Length; i++)
		{
			Paint.goc[i] = GameCanvas.loadImage("/mainImage/myTexture2dgoc" + (i + 1) + ".png");
		}
	}

	// Token: 0x06000388 RID: 904 RVA: 0x0001FBEC File Offset: 0x0001DDEC
	public void paintDefaultBg(mGraphics g)
	{
		g.setColor(8916494);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
		g.drawImage(Paint.imgBg, GameCanvas.w / 2, GameCanvas.h / 2 - Paint.hTab / 2 - 1, 3);
		g.drawImage(Paint.imgLT, 0, 0, 0);
		g.drawImage(Paint.imgRT, GameCanvas.w, 0, mGraphics.TOP | mGraphics.RIGHT);
		g.drawImage(Paint.imgLB, 0, GameCanvas.h - Paint.hTab - 2, mGraphics.BOTTOM | mGraphics.LEFT);
		g.drawImage(Paint.imgRB, GameCanvas.w, GameCanvas.h - Paint.hTab - 2, mGraphics.BOTTOM | mGraphics.RIGHT);
		g.setColor(16774843);
		g.drawRect(0, 0, GameCanvas.w, 0);
		g.drawRect(0, GameCanvas.h - Paint.hTab - 2, GameCanvas.w, 0);
		g.drawRect(0, 0, 0, GameCanvas.h - Paint.hTab);
		g.drawRect(GameCanvas.w - 1, 0, 0, GameCanvas.h - Paint.hTab);
	}

	// Token: 0x06000389 RID: 905 RVA: 0x00005587 File Offset: 0x00003787
	public void paintfillDefaultBg(mGraphics g)
	{
		g.setColor(205314);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
	}

	// Token: 0x0600038A RID: 906 RVA: 0x00003984 File Offset: 0x00001B84
	public void repaintCircleBg()
	{
	}

	// Token: 0x0600038B RID: 907 RVA: 0x00003984 File Offset: 0x00001B84
	public void paintSolidBg(mGraphics g)
	{
	}

	// Token: 0x0600038C RID: 908 RVA: 0x000055A6 File Offset: 0x000037A6
	public void paintDefaultPopup(mGraphics g, int x, int y, int w, int h)
	{
		g.setColor(8411138);
		g.fillRect(x, y, w, h);
		g.setColor(13606712);
		g.drawRect(x, y, w, h);
	}

	// Token: 0x0600038D RID: 909 RVA: 0x000055D6 File Offset: 0x000037D6
	public void paintWhitePopup(mGraphics g, int y, int x, int width, int height)
	{
		g.setColor(16776363);
		g.fillRect(x, y, width, height);
		g.setColor(0);
		g.drawRect(x - 1, y - 1, width + 1, height + 1);
	}

	// Token: 0x0600038E RID: 910 RVA: 0x0001FD14 File Offset: 0x0001DF14
	public void paintDefaultPopupH(mGraphics g, int h)
	{
		g.setColor(14279153);
		g.fillRect(8, GameCanvas.h - (h + 37), GameCanvas.w - 16, h + 4);
		g.setColor(4682453);
		g.fillRect(10, GameCanvas.h - (h + 35), GameCanvas.w - 20, h);
	}

	// Token: 0x0600038F RID: 911 RVA: 0x0001FD70 File Offset: 0x0001DF70
	public void paintCmdBar(mGraphics g, Command left, Command center, Command right)
	{
		mFont mFont = (!GameCanvas.isTouch) ? mFont.tahoma_7b_dark : mFont.tahoma_7b_dark;
		int num = 3;
		if (left != null)
		{
			Paint.lenCaption = mFont.getWidth(left.caption);
			if (Paint.lenCaption > 0)
			{
				if (left.x >= 0 && left.y > 0)
				{
					left.paint(g);
				}
				else
				{
					g.drawImage((mScreen.keyTouch != 0) ? GameScr.imgLbtn : GameScr.imgLbtnFocus, 1, GameCanvas.h - mScreen.cmdH - 1, 0);
					mFont.drawString(g, left.caption, 35, GameCanvas.h - mScreen.cmdH + 3 + num, 2);
				}
			}
		}
		if (center != null)
		{
			Paint.lenCaption = mFont.getWidth(center.caption);
			if (Paint.lenCaption > 0)
			{
				if (center.x > 0 && center.y > 0)
				{
					center.paint(g);
				}
				else
				{
					g.drawImage((mScreen.keyTouch != 1) ? GameScr.imgLbtn : GameScr.imgLbtnFocus, GameCanvas.hw - 35, GameCanvas.h - mScreen.cmdH - 1, 0);
					mFont.drawString(g, center.caption, GameCanvas.hw, GameCanvas.h - mScreen.cmdH + 3 + num, 2);
				}
			}
		}
		if (right != null)
		{
			Paint.lenCaption = mFont.getWidth(right.caption);
			if (Paint.lenCaption > 0)
			{
				if (right.x > 0 && right.y > 0)
				{
					right.paint(g);
				}
				else
				{
					g.drawImage((mScreen.keyTouch != 2) ? GameScr.imgLbtn : GameScr.imgLbtnFocus, GameCanvas.w - 71, GameCanvas.h - mScreen.cmdH - 1, 0);
					mFont.drawString(g, right.caption, GameCanvas.w - 35, GameCanvas.h - mScreen.cmdH + 3 + num, 2);
				}
			}
		}
	}

	// Token: 0x06000390 RID: 912 RVA: 0x00003984 File Offset: 0x00001B84
	public void paintTabSoft(mGraphics g)
	{
	}

	// Token: 0x06000391 RID: 913 RVA: 0x0000560A File Offset: 0x0000380A
	public void paintSelect(mGraphics g, int x, int y, int w, int h)
	{
		g.setColor(16774843);
		g.fillRect(x, y, w, h);
	}

	// Token: 0x06000392 RID: 914 RVA: 0x00005623 File Offset: 0x00003823
	public void paintLogo(mGraphics g, int x, int y)
	{
		g.drawImage(Paint.imgLogo, x, y, 3);
	}

	// Token: 0x06000393 RID: 915 RVA: 0x00003984 File Offset: 0x00001B84
	public void paintHotline(mGraphics g, string number)
	{
	}

	// Token: 0x06000394 RID: 916 RVA: 0x0001FF74 File Offset: 0x0001E174
	public void paintBackMenu(mGraphics g, int x, int y, int w, int h, bool iss)
	{
		if (iss)
		{
			g.setColor(16646144);
			g.fillRoundRect(x, y, w, h, 10, 10);
			g.setColor(16770612);
		}
		else
		{
			g.setColor(16775097);
			g.fillRoundRect(x, y, w, h, 10, 10);
			g.setColor(16775097);
		}
		g.fillRoundRect(x + 3, y + 3, w - 6, h - 6, 10, 10);
	}

	// Token: 0x06000395 RID: 917 RVA: 0x00003984 File Offset: 0x00001B84
	public void paintMsgBG(mGraphics g, int x, int y, int w, int h, string title, string subTitle, string check)
	{
	}

	// Token: 0x06000396 RID: 918 RVA: 0x00003984 File Offset: 0x00001B84
	public void paintDefaultScrList(mGraphics g, string title, string subTitle, string check)
	{
	}

	// Token: 0x06000397 RID: 919 RVA: 0x00005633 File Offset: 0x00003833
	public void paintCheck(mGraphics g, int x, int y, int index)
	{
		g.drawImage(Paint.imgTick[1], x, y, 3);
		if (index == 1)
		{
			g.drawImage(Paint.imgTick[0], x + 1, y - 3, 3);
		}
	}

	// Token: 0x06000398 RID: 920 RVA: 0x00005661 File Offset: 0x00003861
	public void paintImgMsg(mGraphics g, int x, int y, int index)
	{
		g.drawImage(Paint.imgMsg[index], x, y, 0);
	}

	// Token: 0x06000399 RID: 921 RVA: 0x00005674 File Offset: 0x00003874
	public void paintTitleBoard(mGraphics g, int roomId)
	{
		this.paintDefaultBg(g);
	}

	// Token: 0x0600039A RID: 922 RVA: 0x0001FFF4 File Offset: 0x0001E1F4
	public void paintCheckPass(mGraphics g, int x, int y, bool check, bool focus)
	{
		if (focus)
		{
			g.drawRegion(Paint.imgCheck, 0, ((!check) ? 1 : 3) * 18, 20, 18, 0, x, y, 0);
		}
		else
		{
			g.drawRegion(Paint.imgCheck, 0, ((!check) ? 0 : 2) * 18, 20, 18, 0, x, y, 0);
		}
	}

	// Token: 0x0600039B RID: 923 RVA: 0x00020058 File Offset: 0x0001E258
	public void paintInputDlg(mGraphics g, int x, int y, int w, int h, string[] str)
	{
		this.paintFrame(x, y, w, h, g);
		int num = y + 20 - mFont.tahoma_8b.getHeight();
		int i = 0;
		int num2 = num;
		while (i < str.Length)
		{
			mFont.tahoma_8b.drawString(g, str[i], x + w / 2, num2, 2);
			i++;
			num2 += mFont.tahoma_8b.getHeight();
		}
	}

	// Token: 0x0600039C RID: 924 RVA: 0x00003984 File Offset: 0x00001B84
	public void paintIconMainMenu(mGraphics g, int x, int y, bool iss, bool isSe, int i, int wStr)
	{
	}

	// Token: 0x0600039D RID: 925 RVA: 0x0000567D File Offset: 0x0000387D
	public void paintLineRoom(mGraphics g, int x, int y, int xTo, int yTo)
	{
		g.setColor(16774843);
		g.drawLine(x, y, xTo, yTo);
	}

	// Token: 0x0600039E RID: 926 RVA: 0x00005696 File Offset: 0x00003896
	public void paintCellContaint(mGraphics g, int x, int y, int w, int h, bool iss)
	{
		if (iss)
		{
			g.setColor(13132288);
			g.fillRect(x + 2, y + 2, w - 3, w - 3);
		}
		g.setColor(3502080);
		g.drawRect(x, y, w, w);
	}

	// Token: 0x0600039F RID: 927 RVA: 0x000056D5 File Offset: 0x000038D5
	public void paintScroll(mGraphics g, int x, int y, int h)
	{
		g.setColor(3847752);
		g.fillRect(x, y, 4, h);
	}

	// Token: 0x060003A0 RID: 928 RVA: 0x000056ED File Offset: 0x000038ED
	public int[] getColorMsg()
	{
		return this.color;
	}

	// Token: 0x060003A1 RID: 929 RVA: 0x000056F5 File Offset: 0x000038F5
	public void paintLogo(mGraphics g)
	{
		g.setColor(8916494);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
		g.drawImage(Paint.imgLogo, GameCanvas.h >> 1, GameCanvas.w >> 1, 3);
	}

	// Token: 0x060003A2 RID: 930 RVA: 0x000200C0 File Offset: 0x0001E2C0
	public void paintTextLogin(mGraphics g, bool isRes)
	{
		int num = 0;
		if (!isRes && GameCanvas.h <= 240)
		{
			num = 15;
		}
		mFont.tahoma_7b_green2.drawString(g, mResources.LOGINLABELS[0], GameCanvas.hw, GameCanvas.hh + 60 - num, 2);
		mFont.tahoma_7b_green2.drawString(g, mResources.LOGINLABELS[1], GameCanvas.hw, GameCanvas.hh + 73 - num, 2);
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x0000572E File Offset: 0x0000392E
	public void paintSellectBoard(mGraphics g, int x, int y, int w, int h)
	{
		g.drawImage(Paint.imgSelectBoard, x - 7, y, 0);
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x00003C68 File Offset: 0x00001E68
	public int isRegisterUsingWAP()
	{
		return 0;
	}

	// Token: 0x060003A5 RID: 933 RVA: 0x00005740 File Offset: 0x00003940
	public string getCard()
	{
		return "/vmg/card.on";
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x00005747 File Offset: 0x00003947
	public void paintSellectedShop(mGraphics g, int x, int y, int w, int h)
	{
		g.setColor(16777215);
		g.drawRect(x, y, 40, 40);
		g.drawRect(x + 1, y + 1, 38, 38);
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x00005770 File Offset: 0x00003970
	public string getUrlUpdateGame()
	{
		return string.Concat(new object[]
		{
			"http://wap.teamobi.com?info=checkupdate&game=3&version=",
			GameMidlet.VERSION,
			"&provider=",
			GameMidlet.PROVIDER
		});
	}

	// Token: 0x060003A8 RID: 936 RVA: 0x00003984 File Offset: 0x00001B84
	public void doSelect(int focus)
	{
	}

	// Token: 0x060003A9 RID: 937 RVA: 0x0002012C File Offset: 0x0001E32C
	public void paintPopUp(int x, int y, int w, int h, mGraphics g)
	{
		g.setColor(9340251);
		g.drawRect(x + 18, y, (w - 36) / 2 - 32, h);
		g.drawRect(x + 18 + (w - 36) / 2 + 32, y, (w - 36) / 2 - 22, h);
		g.drawRect(x, y + 8, w, h - 17);
		g.setColor(Paint.COLORBACKGROUND);
		g.fillRect(x + 18, y + 3, (w - 36) / 2 - 32, h - 4);
		g.fillRect(x + 18 + (w - 36) / 2 + 31, y + 3, (w - 38) / 2 - 22, h - 4);
		g.fillRect(x + 1, y + 6, w - 1, h - 11);
		g.setColor(14667919);
		g.fillRect(x + 18, y + 1, (w - 36) / 2 - 32, 2);
		g.fillRect(x + 18 + (w - 36) / 2 + 32, y + 1, (w - 36) / 2 - 12, 2);
		g.fillRect(x + 18, y + h - 2, (w - 36) / 2 - 31, 2);
		g.fillRect(x + 18 + (w - 36) / 2 + 32, y + h - 2, (w - 36) / 2 - 31, 2);
		g.fillRect(x + 1, y + 11, 2, h - 18);
		g.fillRect(x + w - 2, y + 11, 2, h - 18);
		g.drawImage(Paint.goc[0], x - 3, y - 2, mGraphics.TOP | mGraphics.LEFT);
		g.drawImage(Paint.goc[2], x + w + 3, y - 2, StaticObj.TOP_RIGHT);
		g.drawImage(Paint.goc[1], x - 3, y + h + 3, StaticObj.BOTTOM_LEFT);
		g.drawImage(Paint.goc[3], x + w + 4, y + h + 2, StaticObj.BOTTOM_RIGHT);
		g.drawImage(Paint.goc[4], x + w / 2, y, StaticObj.TOP_CENTER);
		g.drawImage(Paint.goc[5], x + w / 2, y + h + 1, StaticObj.BOTTOM_HCENTER);
	}

	// Token: 0x060003AA RID: 938 RVA: 0x0002034C File Offset: 0x0001E54C
	public void paintFrame(int x, int y, int w, int h, mGraphics g)
	{
		g.setColor(13524492);
		g.drawRect(x + 6, y, w - 12, h);
		g.drawRect(x, y + 6, w, h - 12);
		g.drawRect(x + 7, y + 1, w - 14, h - 2);
		g.drawRect(x + 1, y + 7, w - 2, h - 14);
		g.setColor(14338484);
		g.fillRect(x + 8, y + 2, w - 16, h - 3);
		g.fillRect(x + 2, y + 8, w - 3, h - 14);
		g.drawImage(GameCanvas.imgBorder[2], x, y, mGraphics.TOP | mGraphics.LEFT);
		g.drawRegion(GameCanvas.imgBorder[2], 0, 0, 16, 16, 2, x + w + 1, y, StaticObj.TOP_RIGHT);
		g.drawRegion(GameCanvas.imgBorder[2], 0, 0, 16, 16, 1, x, y + h + 1, StaticObj.BOTTOM_LEFT);
		g.drawRegion(GameCanvas.imgBorder[2], 0, 0, 16, 16, 3, x + w + 1, y + h + 1, StaticObj.BOTTOM_RIGHT);
	}

	// Token: 0x060003AB RID: 939 RVA: 0x000057A2 File Offset: 0x000039A2
	public void paintFrameSimple(int x, int y, int w, int h, mGraphics g)
	{
		g.setColor(6702080);
		g.fillRect(x, y, w, h);
		g.setColor(14338484);
		g.fillRect(x + 1, y + 1, w - 2, h - 2);
	}

	// Token: 0x060003AC RID: 940 RVA: 0x000057DC File Offset: 0x000039DC
	public void paintFrameBorder(int x, int y, int w, int h, mGraphics g)
	{
		this.paintFrame(x, y, w, h, g);
	}

	// Token: 0x060003AD RID: 941 RVA: 0x000057EB File Offset: 0x000039EB
	public void paintFrameInside(int x, int y, int w, int h, mGraphics g)
	{
		g.setColor(Paint.COLORBACKGROUND);
		g.fillRect(x, y, w, h);
	}

	// Token: 0x060003AE RID: 942 RVA: 0x00005805 File Offset: 0x00003A05
	public void paintFrameInsideSelected(int x, int y, int w, int h, mGraphics g)
	{
		g.setColor(Paint.COLORLIGHT);
		g.fillRect(x, y, w, h);
	}

	// Token: 0x0400061A RID: 1562
	public static int COLORBACKGROUND = 15787715;

	// Token: 0x0400061B RID: 1563
	public static int COLORLIGHT = 16383818;

	// Token: 0x0400061C RID: 1564
	public static int COLORDARK = 3937280;

	// Token: 0x0400061D RID: 1565
	public static int COLORBORDER = 15224576;

	// Token: 0x0400061E RID: 1566
	public static int COLORFOCUS = 16777215;

	// Token: 0x0400061F RID: 1567
	public static Image imgBg;

	// Token: 0x04000620 RID: 1568
	public static Image imgLogo;

	// Token: 0x04000621 RID: 1569
	public static Image imgLB;

	// Token: 0x04000622 RID: 1570
	public static Image imgLT;

	// Token: 0x04000623 RID: 1571
	public static Image imgRB;

	// Token: 0x04000624 RID: 1572
	public static Image imgRT;

	// Token: 0x04000625 RID: 1573
	public static Image imgChuong;

	// Token: 0x04000626 RID: 1574
	public static Image imgSelectBoard;

	// Token: 0x04000627 RID: 1575
	public static Image imgtoiSmall;

	// Token: 0x04000628 RID: 1576
	public static Image imgTayTren;

	// Token: 0x04000629 RID: 1577
	public static Image imgTayDuoi;

	// Token: 0x0400062A RID: 1578
	public static Image[] imgTick = new Image[2];

	// Token: 0x0400062B RID: 1579
	public static Image[] imgMsg = new Image[2];

	// Token: 0x0400062C RID: 1580
	public static Image[] goc = new Image[6];

	// Token: 0x0400062D RID: 1581
	public static int hTab = 24;

	// Token: 0x0400062E RID: 1582
	public static int lenCaption = 0;

	// Token: 0x0400062F RID: 1583
	public int[] color = new int[]
	{
		15970400,
		13479911,
		2250052,
		16374659,
		15906669,
		12931125,
		3108954
	};

	// Token: 0x04000630 RID: 1584
	public static Image imgCheck = GameCanvas.loadImage("/mainImage/myTexture2dcheck.png");
}
