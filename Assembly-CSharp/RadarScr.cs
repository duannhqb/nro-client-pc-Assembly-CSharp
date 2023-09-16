using System;
using UnityEngine;

// Token: 0x020000B6 RID: 182
public class RadarScr : mScreen
{
	// Token: 0x060008C3 RID: 2243 RVA: 0x00083DE0 File Offset: 0x00081FE0
	public RadarScr()
	{
		RadarScr.TYPE_UI = true;
		Image img = mSystem.loadImage("/radar/17.png");
		Image img2 = mSystem.loadImage("/radar/3.png");
		Image img3 = mSystem.loadImage("/radar/23.png");
		RadarScr.fraImgFocus = new FrameImage(img, 28, 28);
		RadarScr.fraImgFocusNone = new FrameImage(img2, 30, 30);
		RadarScr.fraEff = new FrameImage(img3, 11, 11);
		RadarScr.imgUI = mSystem.loadImage("/radar/0.png");
		RadarScr.imgArrow_Left = mSystem.loadImage("/radar/1.png");
		RadarScr.imgArrow_Right = mSystem.loadImage("/radar/2.png");
		RadarScr.imgUIText = mSystem.loadImage("/radar/17.png");
		RadarScr.imgArrow_Down = mSystem.loadImage("/radar/4.png");
		RadarScr.imgLock = mSystem.loadImage("/radar/5.png");
		RadarScr.imgUse_0 = mSystem.loadImage("/radar/6.png");
		RadarScr.imgRank = new Image[7];
		for (int i = 0; i < 7; i++)
		{
			RadarScr.imgRank[i] = mSystem.loadImage("/radar/" + (i + 7) + ".png");
		}
		RadarScr.imgUse = mSystem.loadImage("/radar/14.png");
		RadarScr.imgBack = mSystem.loadImage("/radar/15.png");
		RadarScr.imgChange = mSystem.loadImage("/radar/16.png");
		RadarScr.imgUIText = mSystem.loadImage("/radar/18.png");
		RadarScr.imgBar_1 = mSystem.loadImage("/radar/19.png");
		RadarScr.imgPro_0 = mSystem.loadImage("/radar/20.png");
		RadarScr.imgPro_1 = mSystem.loadImage("/radar/21.png");
		RadarScr.imgBar_0 = mSystem.loadImage("/radar/22.png");
		RadarScr.wUi = 200;
		RadarScr.hUi = 219;
		RadarScr.xUi = GameCanvas.hw - (RadarScr.wUi + 40) / 2;
		RadarScr.yUi = GameCanvas.hh - RadarScr.hUi / 2;
		RadarScr.xText = RadarScr.xUi + RadarScr.wUi - 81;
		RadarScr.yText = RadarScr.yUi + 29;
		RadarScr.wText = 120;
		RadarScr.hText = 80;
		RadarScr.xyArrow = new int[][]
		{
			new int[]
			{
				RadarScr.xUi + 34,
				RadarScr.yUi + RadarScr.hUi - 42
			},
			new int[]
			{
				RadarScr.xUi + RadarScr.wUi / 2 - RadarScr.imgArrow_Down.getWidth() / 2,
				RadarScr.yUi + RadarScr.hUi / 2 + 33
			},
			new int[]
			{
				RadarScr.xUi + RadarScr.wUi - 41,
				RadarScr.yUi + RadarScr.hUi - 42
			}
		};
		RadarScr.xyItem = new int[][]
		{
			new int[]
			{
				RadarScr.xUi + 25,
				RadarScr.yUi + RadarScr.hUi - 82
			},
			new int[]
			{
				RadarScr.xUi + 57,
				RadarScr.yUi + RadarScr.hUi - 62
			},
			new int[]
			{
				RadarScr.xUi + RadarScr.wUi / 2 - 14,
				RadarScr.yUi + RadarScr.hUi - 102
			},
			new int[]
			{
				RadarScr.xUi + RadarScr.wUi - 57 - 28,
				RadarScr.yUi + RadarScr.hUi - 62
			},
			new int[]
			{
				RadarScr.xUi + RadarScr.wUi - 25 - 28,
				RadarScr.yUi + RadarScr.hUi - 82
			}
		};
		this.dxArrow = new int[2];
		this.dyArrow = 0;
		RadarScr.xMon = RadarScr.xUi + 73;
		RadarScr.yMon = RadarScr.yUi + RadarScr.hUi / 2 + 5;
		RadarScr.yCmd = RadarScr.yUi + RadarScr.hUi - 22;
		RadarScr.xCmd = new int[]
		{
			RadarScr.xUi + RadarScr.wUi / 2 - 8 - 80,
			RadarScr.xUi + RadarScr.wUi / 2 - 8,
			RadarScr.xUi + RadarScr.wUi / 2 - 8 + 80
		};
		RadarScr.dxCmd = new int[3];
		this.yClip = RadarScr.yText + 10 + 70;
		this.hClip = 0;
		RadarScr.list = new MyVector();
		RadarScr.listUse = new MyVector();
		this.page = 1;
		this.maxpage = 2;
	}

	// Token: 0x060008C4 RID: 2244 RVA: 0x0000772E File Offset: 0x0000592E
	public static RadarScr gI()
	{
		if (RadarScr.instance == null)
		{
			RadarScr.instance = new RadarScr();
		}
		return RadarScr.instance;
	}

	// Token: 0x060008C5 RID: 2245 RVA: 0x00084218 File Offset: 0x00082418
	public void SetRadarScr(MyVector list, int num, int numMax)
	{
		RadarScr.list = list;
		RadarScr.SetNum(num, numMax);
		this.page = 1;
		this.indexFocus = 2;
		this.listIndex();
		RadarScr.TYPE_UI = true;
		RadarScr.SetListUse();
		if (RadarScr.TYPE_UI)
		{
			this.maxpage = list.size() / 5 + ((list.size() % 5 <= 0) ? 0 : 1);
		}
		else
		{
			this.maxpage = RadarScr.listUse.size() / 5 + ((RadarScr.listUse.size() % 5 <= 0) ? 0 : 1);
		}
	}

	// Token: 0x060008C6 RID: 2246 RVA: 0x00007749 File Offset: 0x00005949
	public static void SetNum(int num, int numMax)
	{
		RadarScr.num = num;
		RadarScr.numMax = numMax;
	}

	// Token: 0x060008C7 RID: 2247 RVA: 0x000842B0 File Offset: 0x000824B0
	public static void SetListUse()
	{
		RadarScr.listUse = new MyVector(string.Empty);
		for (int i = 0; i < RadarScr.list.size(); i++)
		{
			Info_RadaScr info_RadaScr = (Info_RadaScr)RadarScr.list.elementAt(i);
			if (info_RadaScr != null && (int)info_RadaScr.isUse == 1)
			{
				RadarScr.listUse.addElement(info_RadaScr);
			}
		}
	}

	// Token: 0x060008C8 RID: 2248 RVA: 0x00084318 File Offset: 0x00082518
	public void listIndex()
	{
		MyVector myVector = RadarScr.listUse;
		if (RadarScr.TYPE_UI)
		{
			myVector = RadarScr.list;
		}
		int num = (this.page - 1) * 5;
		int num2 = num + 5;
		for (int i = num; i < num2; i++)
		{
			if (i >= myVector.size())
			{
				RadarScr.index[i - num] = -1;
			}
			else
			{
				Info_RadaScr info_RadaScr = (Info_RadaScr)myVector.elementAt(i);
				if (info_RadaScr != null)
				{
					RadarScr.index[i - num] = info_RadaScr.id;
				}
			}
		}
		RadarScr.cmyText = 0;
		RadarScr.hText = 0;
		SoundMn.gI().radarItem();
	}

	// Token: 0x060008C9 RID: 2249 RVA: 0x000843B4 File Offset: 0x000825B4
	public override void update()
	{
		try
		{
			if (RadarScr.hText < 80)
			{
				RadarScr.hText += 4;
				if (RadarScr.hText > 80)
				{
					RadarScr.hText = 80;
				}
			}
			this.focus_card = Info_RadaScr.GetInfo(RadarScr.listUse, RadarScr.index[this.indexFocus]);
			if (RadarScr.TYPE_UI)
			{
				this.focus_card = Info_RadaScr.GetInfo(RadarScr.list, RadarScr.index[this.indexFocus]);
			}
			GameScr.gI().update();
			if (GameCanvas.gameTick % 10 < 6)
			{
				if (GameCanvas.gameTick % 2 == 0)
				{
					this.dyArrow--;
				}
			}
			else
			{
				this.dyArrow = 0;
			}
			if (this.focus_card != null)
			{
				int num = (int)this.focus_card.amount * 100 / (int)this.focus_card.max_amount;
				this.hClip = num * RadarScr.imgBar_1.getHeight() / 100;
				int num2 = RadarScr.num * 100 / RadarScr.list.size();
				this.wClip = num2 * RadarScr.imgPro_1.getWidth() / 100;
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("-upd-radaScr-null: " + ex.ToString());
		}
	}

	// Token: 0x060008CA RID: 2250 RVA: 0x00084510 File Offset: 0x00082710
	public override void updateKey()
	{
		if (InfoDlg.isLock)
		{
			return;
		}
		if (GameCanvas.isTouch && !ChatTextField.gI().isShow && !GameCanvas.menu.showMenu)
		{
			this.updateKeyTouchControl();
		}
		if (GameCanvas.keyPressed[(!Main.isPC) ? 8 : 22])
		{
			GameCanvas.keyPressed[(!Main.isPC) ? 8 : 22] = false;
			this.doKeyText(1);
		}
		if (GameCanvas.keyPressed[(!Main.isPC) ? 2 : 21])
		{
			GameCanvas.keyPressed[(!Main.isPC) ? 2 : 21] = false;
			this.doKeyText(-1);
		}
		if (GameCanvas.keyPressed[(!Main.isPC) ? 4 : 23])
		{
			GameCanvas.keyPressed[(!Main.isPC) ? 4 : 23] = false;
			this.doKeyItem(1);
		}
		if (GameCanvas.keyPressed[(!Main.isPC) ? 6 : 24])
		{
			GameCanvas.keyPressed[(!Main.isPC) ? 6 : 24] = false;
			this.doKeyItem(0);
		}
		if (GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25])
		{
			GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] = false;
			this.doClickUse(1);
		}
		if (GameCanvas.keyPressed[13])
		{
			this.doClickUse(2);
		}
		if (GameCanvas.keyPressed[12])
		{
			GameCanvas.keyPressed[12] = false;
			this.doClickUse(0);
		}
		GameCanvas.clearKeyPressed();
	}

	// Token: 0x060008CB RID: 2251 RVA: 0x000846C0 File Offset: 0x000828C0
	private void doChangeUI()
	{
		RadarScr.TYPE_UI = !RadarScr.TYPE_UI;
		this.page = 1;
		this.indexFocus = 0;
		if (RadarScr.TYPE_UI)
		{
			this.maxpage = RadarScr.list.size() / 5 + ((RadarScr.list.size() % 5 <= 0) ? 0 : 1);
		}
		else
		{
			this.maxpage = RadarScr.listUse.size() / 5 + ((RadarScr.listUse.size() % 5 <= 0) ? 0 : 1);
		}
		this.listIndex();
	}

	// Token: 0x060008CC RID: 2252 RVA: 0x00084758 File Offset: 0x00082958
	private void updateKeyTouchControl()
	{
		if (GameCanvas.isPointerClick)
		{
			for (int i = 0; i < 5; i++)
			{
				if (GameCanvas.isPointerHoldIn(RadarScr.xyItem[i][0], RadarScr.xyItem[i][1], 30, 30) && GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease && i != this.indexFocus)
				{
					this.doClickItem(i);
				}
			}
			if (GameCanvas.isPointerHoldIn(RadarScr.xyArrow[0][0] - 5, RadarScr.xyArrow[0][1] - 5, 20, 20))
			{
				if (GameCanvas.isPointerDown)
				{
					this.dxArrow[0] = 1;
				}
				if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
				{
					this.doClickArrow(0);
					this.dxArrow[0] = 0;
				}
			}
			if (GameCanvas.isPointerHoldIn(RadarScr.xyArrow[2][0] - 5, RadarScr.xyArrow[2][1] - 5, 20, 20))
			{
				if (GameCanvas.isPointerDown)
				{
					this.dxArrow[1] = 1;
				}
				if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
				{
					this.doClickArrow(1);
					this.dxArrow[1] = 0;
				}
			}
			for (int j = 0; j < RadarScr.xCmd.Length; j++)
			{
				if (GameCanvas.isPointerHoldIn(RadarScr.xCmd[j] - 5, RadarScr.yCmd - 5, 20, 20))
				{
					if (GameCanvas.isPointerDown)
					{
						RadarScr.dxCmd[j] = 1;
					}
					if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
					{
						this.doClickUse(j);
						RadarScr.dxCmd[j] = 0;
					}
				}
			}
		}
		else
		{
			RadarScr.dxCmd[0] = 0;
			RadarScr.dxCmd[1] = 0;
			RadarScr.dxCmd[2] = 0;
			this.dxArrow[0] = 0;
			this.dxArrow[1] = 0;
		}
		if (GameCanvas.isPointerHoldIn(RadarScr.xText, 0, RadarScr.wText, RadarScr.yText + RadarScr.hText))
		{
			if (GameCanvas.isPointerMove)
			{
				if (this.pyy == 0)
				{
					this.pyy = GameCanvas.py;
				}
				this.pxx = this.pyy - GameCanvas.py;
				if (this.pxx != 0)
				{
					RadarScr.cmyText += this.pxx;
					this.pyy = GameCanvas.py;
				}
				if (RadarScr.cmyText < 0)
				{
					RadarScr.cmyText = 0;
				}
				if (RadarScr.cmyText > this.focus_card.cp.lim)
				{
					RadarScr.cmyText = this.focus_card.cp.lim;
				}
			}
			else
			{
				this.pyy = 0;
				this.pyy = 0;
			}
		}
	}

	// Token: 0x060008CD RID: 2253 RVA: 0x000849E4 File Offset: 0x00082BE4
	private void doClickUse(int i)
	{
		if (i == 0)
		{
			this.doChangeUI();
		}
		else if (i == 1)
		{
			if (this.focus_card != null)
			{
				Service.gI().SendRada(1, this.focus_card.id);
			}
		}
		else if (i == 2)
		{
			GameScr.gI().switchToMe();
		}
		SoundMn.gI().radarClick();
	}

	// Token: 0x060008CE RID: 2254 RVA: 0x00084A4C File Offset: 0x00082C4C
	private void doClickArrow(int dir)
	{
		if (RadarScr.TYPE_UI)
		{
			this.maxpage = RadarScr.list.size() / 5 + ((RadarScr.list.size() % 5 <= 0) ? 0 : 1);
		}
		else
		{
			this.maxpage = RadarScr.listUse.size() / 5 + ((RadarScr.listUse.size() % 5 <= 0) ? 0 : 1);
		}
		int num = this.page;
		if (dir == 0)
		{
			if (this.page == 1)
			{
				return;
			}
			num--;
			if (num < 1)
			{
				num = 1;
			}
		}
		else
		{
			if (this.page == this.maxpage)
			{
				return;
			}
			num++;
			if (num > this.maxpage)
			{
				num = this.maxpage;
			}
		}
		if (num != this.page)
		{
			this.page = num;
			this.listIndex();
		}
	}

	// Token: 0x060008CF RID: 2255 RVA: 0x00007757 File Offset: 0x00005957
	private void doClickItem(int focus)
	{
		this.indexFocus = focus;
		this.listIndex();
	}

	// Token: 0x060008D0 RID: 2256 RVA: 0x00084B30 File Offset: 0x00082D30
	private void doKeyText(int type)
	{
		RadarScr.cmyText += 12 * type;
		if (RadarScr.cmyText < 0)
		{
			RadarScr.cmyText = 0;
		}
		if (RadarScr.cmyText > this.focus_card.cp.lim)
		{
			RadarScr.cmyText = this.focus_card.cp.lim;
		}
	}

	// Token: 0x060008D1 RID: 2257 RVA: 0x00084B8C File Offset: 0x00082D8C
	private void doKeyItem(int type)
	{
		int num = this.indexFocus;
		int num2 = this.page;
		if (type == 0)
		{
			num++;
		}
		else
		{
			num--;
		}
		if (num >= RadarScr.index.Length)
		{
			if (this.page < this.maxpage)
			{
				num = 0;
				num2++;
			}
			else
			{
				num = RadarScr.index.Length - 1;
			}
		}
		if (num < 0)
		{
			if (this.page > 1)
			{
				num = RadarScr.index.Length - 1;
				num2--;
			}
			else
			{
				num = 0;
			}
		}
		if (num != this.indexFocus)
		{
			this.indexFocus = num;
			RadarScr.cmyText = 0;
			RadarScr.hText = 0;
		}
		if (num2 != this.page)
		{
			this.page = num2;
			this.listIndex();
		}
	}

	// Token: 0x060008D2 RID: 2258 RVA: 0x00084C50 File Offset: 0x00082E50
	public override void paint(mGraphics g)
	{
		try
		{
			GameScr.gI().paint(g);
			g.translate(-GameScr.cmx, -GameScr.cmy);
			g.translate(0, GameCanvas.transY);
			GameScr.resetTranslate(g);
			g.drawImage(RadarScr.imgUI, RadarScr.xUi, RadarScr.yUi, 0);
			g.drawImage(RadarScr.imgPro_0, RadarScr.xUi + RadarScr.wUi / 2 - RadarScr.imgPro_0.getWidth() / 2, RadarScr.yUi - RadarScr.imgPro_0.getHeight() / 2 - 2, 0);
			g.setClip(RadarScr.xUi + RadarScr.wUi / 2 - RadarScr.imgPro_0.getWidth() / 2 + 13, RadarScr.yUi - RadarScr.imgPro_0.getHeight() / 2 + 3, this.wClip, RadarScr.imgPro_0.getHeight());
			g.drawImage(RadarScr.imgPro_1, RadarScr.xUi + RadarScr.wUi / 2 - RadarScr.imgPro_0.getWidth() / 2 + 13, RadarScr.yUi - RadarScr.imgPro_0.getHeight() / 2 + 3, 0);
			GameScr.resetTranslate(g);
			g.drawImage(RadarScr.imgChange, RadarScr.xCmd[0], RadarScr.yCmd + RadarScr.dxCmd[0], 0);
			g.drawImage(RadarScr.imgUse_0, RadarScr.xCmd[1], RadarScr.yCmd + RadarScr.dxCmd[1], 0);
			g.drawImage(RadarScr.imgBack, RadarScr.xCmd[2], RadarScr.yCmd + RadarScr.dxCmd[2], 0);
			if (RadarScr.TYPE_UI)
			{
				g.drawRegion(RadarScr.imgUse, 0, 0, 17, 17, 0, RadarScr.xCmd[1], RadarScr.yCmd + RadarScr.dxCmd[1], 0);
			}
			else
			{
				g.drawRegion(RadarScr.imgUse, 0, 0, 17, 17, 1, RadarScr.xCmd[1], RadarScr.yCmd + RadarScr.dxCmd[1], 0);
			}
			if (this.focus_card != null)
			{
				g.setClip(RadarScr.xUi + 30, RadarScr.yUi + 13, RadarScr.wUi - 60, RadarScr.hUi / 2);
				this.focus_card.paintInfo(g, RadarScr.xMon, RadarScr.yMon);
				GameScr.resetTranslate(g);
				mFont.tahoma_7b_yellow.drawString(g, (((int)this.focus_card.level <= 0) ? " " : ("Lv." + this.focus_card.level + " ")) + this.focus_card.name, RadarScr.xUi + RadarScr.wUi / 2, RadarScr.yUi + 15, 2);
				mFont.tahoma_7_white.drawString(g, "no." + this.focus_card.no, RadarScr.xUi + 30, RadarScr.yText - 2, 0);
				g.drawImage(RadarScr.imgBar_0, RadarScr.xUi + 36, RadarScr.yText + 10, 0);
				g.setClip(RadarScr.xUi + 36, this.yClip - this.hClip, 7, this.hClip);
				g.drawImage(RadarScr.imgBar_1, RadarScr.xUi + 36, RadarScr.yText + 10, 0);
				GameScr.resetTranslate(g);
				g.drawImage(RadarScr.imgRank[(int)this.focus_card.rank], RadarScr.xUi + 39 - 5 + 14, RadarScr.yText + 12, 0);
			}
			g.setClip(RadarScr.xText, RadarScr.yText, RadarScr.wText + 5, RadarScr.hText + 8);
			if (this.focus_card != null)
			{
				g.drawImage(RadarScr.imgUIText, RadarScr.xText, RadarScr.yText, 0);
			}
			GameScr.resetTranslate(g);
			g.setClip(RadarScr.xText, RadarScr.yText + 1, RadarScr.wText, RadarScr.hText + 5);
			if (this.focus_card != null && this.focus_card.cp != null)
			{
				if (this.focus_card.cp.says == null)
				{
					return;
				}
				this.focus_card.cp.paintRada(g, RadarScr.cmyText);
			}
			GameScr.resetTranslate(g);
			if ((!RadarScr.TYPE_UI && RadarScr.listUse.size() > 5) || RadarScr.TYPE_UI)
			{
				if (this.page > 1)
				{
					g.drawImage(RadarScr.imgArrow_Left, RadarScr.xyArrow[0][0], RadarScr.xyArrow[0][1] + this.dxArrow[0], 0);
				}
				if (this.page < this.maxpage)
				{
					g.drawImage(RadarScr.imgArrow_Right, RadarScr.xyArrow[2][0], RadarScr.xyArrow[2][1] + this.dxArrow[1], 0);
				}
			}
			for (int i = 0; i < RadarScr.index.Length; i++)
			{
				int num = 0;
				int num2 = 0;
				int idx = 0;
				if (i == this.indexFocus)
				{
					num = this.dyArrow;
					num2 = -10;
					idx = 1;
					g.drawImage(RadarScr.imgArrow_Down, RadarScr.xyItem[i][0] + 10, RadarScr.xyItem[i][1] + this.dyArrow + 29 + num2, 0);
				}
				Info_RadaScr info = Info_RadaScr.GetInfo(RadarScr.listUse, RadarScr.index[i]);
				if (RadarScr.TYPE_UI)
				{
					info = Info_RadaScr.GetInfo(RadarScr.list, RadarScr.index[i]);
				}
				if (info != null)
				{
					RadarScr.fraImgFocus.drawFrame((int)info.rank, RadarScr.xyItem[i][0], RadarScr.xyItem[i][1] + num + num2, 0, 0, g);
					SmallImage.drawSmallImage(g, info.idIcon, RadarScr.xyItem[i][0] + 14, RadarScr.xyItem[i][1] + 14 + num + num2, 0, StaticObj.VCENTER_HCENTER);
					info.paintEff(g, RadarScr.xyItem[i][0], RadarScr.xyItem[i][1] + num + num2);
					if ((int)info.level == 0)
					{
						g.drawImage(RadarScr.imgLock, RadarScr.xyItem[i][0], RadarScr.xyItem[i][1] + num + num2, 0);
					}
					if (i == this.indexFocus)
					{
						RadarScr.fraImgFocus.drawFrame(7, RadarScr.xyItem[i][0], RadarScr.xyItem[i][1] + num + num2, 0, 0, g);
					}
					if ((int)info.isUse == 1)
					{
						RadarScr.fraImgFocus.drawFrame(8, RadarScr.xyItem[i][0], RadarScr.xyItem[i][1] + num + num2, 0, 0, g);
					}
				}
				else
				{
					RadarScr.fraImgFocusNone.drawFrame(idx, RadarScr.xyItem[i][0] - 1, RadarScr.xyItem[i][1] - 1 + num + num2, 0, 0, g);
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("-pnt-radaScr-null: " + ex.ToString());
		}
	}

	// Token: 0x060008D3 RID: 2259 RVA: 0x00007766 File Offset: 0x00005966
	public override void switchToMe()
	{
		GameScr.isPaintOther = true;
		base.switchToMe();
	}

	// Token: 0x04000FFA RID: 4090
	public const sbyte SUBCMD_ALL = 0;

	// Token: 0x04000FFB RID: 4091
	public const sbyte SUBCMD_USE = 1;

	// Token: 0x04000FFC RID: 4092
	public const sbyte SUBCMD_LEVEL = 2;

	// Token: 0x04000FFD RID: 4093
	public const sbyte SUBCMD_AMOUNT = 3;

	// Token: 0x04000FFE RID: 4094
	public const sbyte SUBCMD_AURA = 4;

	// Token: 0x04000FFF RID: 4095
	public static RadarScr instance;

	// Token: 0x04001000 RID: 4096
	public static bool TYPE_UI;

	// Token: 0x04001001 RID: 4097
	public static FrameImage fraImgFocus;

	// Token: 0x04001002 RID: 4098
	public static FrameImage fraImgFocusNone;

	// Token: 0x04001003 RID: 4099
	public static FrameImage fraEff;

	// Token: 0x04001004 RID: 4100
	private static Image imgUI;

	// Token: 0x04001005 RID: 4101
	private static Image imgUIText;

	// Token: 0x04001006 RID: 4102
	private static Image imgArrow_Left;

	// Token: 0x04001007 RID: 4103
	private static Image imgArrow_Right;

	// Token: 0x04001008 RID: 4104
	private static Image imgArrow_Down;

	// Token: 0x04001009 RID: 4105
	private static Image imgLock;

	// Token: 0x0400100A RID: 4106
	private static Image imgUse_0;

	// Token: 0x0400100B RID: 4107
	private static Image imgUse;

	// Token: 0x0400100C RID: 4108
	private static Image imgBack;

	// Token: 0x0400100D RID: 4109
	private static Image imgChange;

	// Token: 0x0400100E RID: 4110
	private static Image imgBar_0;

	// Token: 0x0400100F RID: 4111
	private static Image imgBar_1;

	// Token: 0x04001010 RID: 4112
	private static Image imgPro_0;

	// Token: 0x04001011 RID: 4113
	private static Image imgPro_1;

	// Token: 0x04001012 RID: 4114
	private static Image[] imgRank;

	// Token: 0x04001013 RID: 4115
	public static int xUi;

	// Token: 0x04001014 RID: 4116
	public static int yUi;

	// Token: 0x04001015 RID: 4117
	public static int wUi;

	// Token: 0x04001016 RID: 4118
	public static int hUi;

	// Token: 0x04001017 RID: 4119
	public static int xMon;

	// Token: 0x04001018 RID: 4120
	public static int yMon;

	// Token: 0x04001019 RID: 4121
	public static int xText;

	// Token: 0x0400101A RID: 4122
	public static int yText;

	// Token: 0x0400101B RID: 4123
	public static int wText;

	// Token: 0x0400101C RID: 4124
	public static int cmyText;

	// Token: 0x0400101D RID: 4125
	public static int hText;

	// Token: 0x0400101E RID: 4126
	public static int yCmd;

	// Token: 0x0400101F RID: 4127
	public static int[] xCmd = new int[0];

	// Token: 0x04001020 RID: 4128
	public static int[] dxCmd = new int[0];

	// Token: 0x04001021 RID: 4129
	private static int[][] xyArrow;

	// Token: 0x04001022 RID: 4130
	private static int[][] xyItem;

	// Token: 0x04001023 RID: 4131
	private static int[] index = new int[]
	{
		-2,
		-1,
		0,
		1,
		2
	};

	// Token: 0x04001024 RID: 4132
	private int dyArrow;

	// Token: 0x04001025 RID: 4133
	private int[] dxArrow;

	// Token: 0x04001026 RID: 4134
	private int page;

	// Token: 0x04001027 RID: 4135
	private int maxpage;

	// Token: 0x04001028 RID: 4136
	private int indexFocus;

	// Token: 0x04001029 RID: 4137
	public static MyVector list;

	// Token: 0x0400102A RID: 4138
	public static MyVector listUse;

	// Token: 0x0400102B RID: 4139
	private static int num;

	// Token: 0x0400102C RID: 4140
	private static int numMax;

	// Token: 0x0400102D RID: 4141
	private Info_RadaScr focus_card;

	// Token: 0x0400102E RID: 4142
	private int pxx;

	// Token: 0x0400102F RID: 4143
	private int pyy;

	// Token: 0x04001030 RID: 4144
	private int xClip;

	// Token: 0x04001031 RID: 4145
	private int wClip;

	// Token: 0x04001032 RID: 4146
	private int yClip;

	// Token: 0x04001033 RID: 4147
	private int hClip;
}
