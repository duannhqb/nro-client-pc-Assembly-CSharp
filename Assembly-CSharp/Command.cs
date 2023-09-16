using System;

// Token: 0x02000052 RID: 82
public class Command
{
	// Token: 0x060002D5 RID: 725 RVA: 0x0001A400 File Offset: 0x00018600
	public Command(string caption, IActionListener actionListener, int action, object p, int x, int y)
	{
		this.caption = caption;
		this.idAction = action;
		this.actionListener = actionListener;
		this.p = p;
		this.x = x;
		this.y = y;
	}

	// Token: 0x060002D6 RID: 726 RVA: 0x00004F8B File Offset: 0x0000318B
	public Command()
	{
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x0001A468 File Offset: 0x00018668
	public Command(string caption, IActionListener actionListener, int action, object p)
	{
		this.caption = caption;
		this.idAction = action;
		this.actionListener = actionListener;
		this.p = p;
	}

	// Token: 0x060002D8 RID: 728 RVA: 0x0001A4C0 File Offset: 0x000186C0
	public Command(string caption, int action, object p)
	{
		this.caption = caption;
		this.idAction = action;
		this.p = p;
	}

	// Token: 0x060002D9 RID: 729 RVA: 0x00004FBB File Offset: 0x000031BB
	public Command(string caption, int action)
	{
		this.caption = caption;
		this.idAction = action;
	}

	// Token: 0x060002DA RID: 730 RVA: 0x0001A510 File Offset: 0x00018710
	public Command(string caption, int action, int x, int y)
	{
		this.caption = caption;
		this.idAction = action;
		this.x = x;
		this.y = y;
	}

	// Token: 0x060002DB RID: 731 RVA: 0x00004FF9 File Offset: 0x000031F9
	public void perform(string str)
	{
		if (this.actionChat != null)
		{
			this.actionChat(str);
		}
	}

	// Token: 0x060002DC RID: 732 RVA: 0x0001A568 File Offset: 0x00018768
	public void performAction()
	{
		GameCanvas.clearAllPointerEvent();
		if (this.isPlaySoundButton && ((this.caption != null && !this.caption.Equals(string.Empty) && !this.caption.Equals(mResources.saying)) || this.img != null))
		{
			SoundMn.gI().buttonClick();
		}
		if (this.idAction > 0)
		{
			if (this.actionListener != null)
			{
				this.actionListener.perform(this.idAction, this.p);
			}
			else
			{
				GameScr.gI().actionPerform(this.idAction, this.p);
			}
		}
	}

	// Token: 0x060002DD RID: 733 RVA: 0x00005012 File Offset: 0x00003212
	public void setType()
	{
		this.type = 1;
		this.w = 160;
		this.hw = 80;
	}

	// Token: 0x060002DE RID: 734 RVA: 0x0001A618 File Offset: 0x00018818
	public void paint(mGraphics g)
	{
		if (this.img != null)
		{
			g.drawImage(this.img, this.x, this.y + mGraphics.addYWhenOpenKeyBoard, 0);
			if (this.isFocus)
			{
				if (this.imgFocus == null)
				{
					if (this.cmdClosePanel)
					{
						g.drawImage(ItemMap.imageFlare, this.x + 8, this.y + mGraphics.addYWhenOpenKeyBoard + 8, 3);
					}
					else
					{
						g.drawImage(ItemMap.imageFlare, this.x - ((!this.img.Equals(GameScr.imgMenu)) ? 0 : 10), this.y + mGraphics.addYWhenOpenKeyBoard, 0);
					}
				}
				else
				{
					g.drawImage(this.imgFocus, this.x, this.y + mGraphics.addYWhenOpenKeyBoard, 0);
				}
			}
			if (this.caption != "menu" && this.caption != null)
			{
				if (!this.isFocus)
				{
					mFont.tahoma_7b_dark.drawString(g, this.caption, this.x + mGraphics.getImageWidth(this.img) / 2, this.y + mGraphics.getImageHeight(this.img) / 2 - 5, 2);
				}
				else
				{
					mFont.tahoma_7b_green2.drawString(g, this.caption, this.x + mGraphics.getImageWidth(this.img) / 2, this.y + mGraphics.getImageHeight(this.img) / 2 - 5, 2);
				}
			}
			return;
		}
		if (this.caption != string.Empty)
		{
			if (this.type == 1)
			{
				if (!this.isFocus)
				{
					Command.paintOngMau(Command.btn0left, Command.btn0mid, Command.btn0right, this.x, this.y, 160, g);
				}
				else
				{
					Command.paintOngMau(Command.btn1left, Command.btn1mid, Command.btn1right, this.x, this.y, 160, g);
				}
			}
			else if (!this.isFocus)
			{
				Command.paintOngMau(Command.btn0left, Command.btn0mid, Command.btn0right, this.x, this.y, 76, g);
			}
			else
			{
				Command.paintOngMau(Command.btn1left, Command.btn1mid, Command.btn1right, this.x, this.y, 76, g);
			}
		}
		int num;
		if (this.type == 1)
		{
			num = this.x + this.hw;
		}
		else
		{
			num = this.x + 38;
		}
		if (!this.isFocus)
		{
			mFont.tahoma_7b_dark.drawString(g, this.caption, num, this.y + 7, 2);
		}
		else
		{
			mFont.tahoma_7b_green2.drawString(g, this.caption, num, this.y + 7, 2);
		}
	}

	// Token: 0x060002DF RID: 735 RVA: 0x0001A8E8 File Offset: 0x00018AE8
	public static void paintOngMau(Image img0, Image img1, Image img2, int x, int y, int size, mGraphics g)
	{
		for (int i = 10; i <= size - 20; i += 10)
		{
			g.drawImage(img1, x + i, y, 0);
		}
		int num = size % 10;
		if (num > 0)
		{
			g.drawRegion(img1, 0, 0, num, 24, 0, x + size - 10 - num, y, 0);
		}
		g.drawImage(img0, x, y, 0);
		g.drawImage(img2, x + size - 10, y, 0);
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x0001A960 File Offset: 0x00018B60
	public bool isPointerPressInside()
	{
		this.isFocus = false;
		if (GameCanvas.isPointerHoldIn(this.x, this.y, this.w, this.h))
		{
			if (GameCanvas.isPointerDown)
			{
				this.isFocus = true;
			}
			if (GameCanvas.isPointerJustRelease && GameCanvas.isPointerClick)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060002E1 RID: 737 RVA: 0x0001A9C0 File Offset: 0x00018BC0
	public bool isPointerPressInsideCamera(int cmx, int cmy)
	{
		this.isFocus = false;
		if (GameCanvas.isPointerHoldIn(this.x - cmx, this.y - cmy, this.w, this.h))
		{
			Res.outz("w= " + this.w);
			if (GameCanvas.isPointerDown)
			{
				this.isFocus = true;
			}
			if (GameCanvas.isPointerJustRelease && GameCanvas.isPointerClick)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0400049E RID: 1182
	public ActionChat actionChat;

	// Token: 0x0400049F RID: 1183
	public string caption;

	// Token: 0x040004A0 RID: 1184
	public string[] subCaption;

	// Token: 0x040004A1 RID: 1185
	public IActionListener actionListener;

	// Token: 0x040004A2 RID: 1186
	public int idAction;

	// Token: 0x040004A3 RID: 1187
	public bool isPlaySoundButton = true;

	// Token: 0x040004A4 RID: 1188
	public Image img;

	// Token: 0x040004A5 RID: 1189
	public Image imgFocus;

	// Token: 0x040004A6 RID: 1190
	public int x;

	// Token: 0x040004A7 RID: 1191
	public int y;

	// Token: 0x040004A8 RID: 1192
	public int w = mScreen.cmdW;

	// Token: 0x040004A9 RID: 1193
	public int h = mScreen.cmdH;

	// Token: 0x040004AA RID: 1194
	public int hw;

	// Token: 0x040004AB RID: 1195
	private int lenCaption;

	// Token: 0x040004AC RID: 1196
	public bool isFocus;

	// Token: 0x040004AD RID: 1197
	public object p;

	// Token: 0x040004AE RID: 1198
	public int type;

	// Token: 0x040004AF RID: 1199
	public string caption2 = string.Empty;

	// Token: 0x040004B0 RID: 1200
	public static Image btn0left;

	// Token: 0x040004B1 RID: 1201
	public static Image btn0mid;

	// Token: 0x040004B2 RID: 1202
	public static Image btn0right;

	// Token: 0x040004B3 RID: 1203
	public static Image btn1left;

	// Token: 0x040004B4 RID: 1204
	public static Image btn1mid;

	// Token: 0x040004B5 RID: 1205
	public static Image btn1right;

	// Token: 0x040004B6 RID: 1206
	public bool cmdClosePanel;
}
