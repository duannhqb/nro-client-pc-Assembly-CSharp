using System;

// Token: 0x0200005D RID: 93
public class Info : IActionListener
{
	// Token: 0x0600031D RID: 797 RVA: 0x00005132 File Offset: 0x00003332
	public void hide()
	{
		this.says = null;
		this.infoWaitToShow.removeAllElements();
	}

	// Token: 0x0600031E RID: 798 RVA: 0x0001B910 File Offset: 0x00019B10
	public void paint(mGraphics g, int x, int y, int dir)
	{
		if (this.infoWaitToShow.size() != 0)
		{
			g.translate(x, y);
			if (this.says != null && this.says.Length != 0 && this.type != 1)
			{
				if (this.outSide)
				{
					this.cx -= GameScr.cmx;
					this.cy -= GameScr.cmy;
					this.cy += 35;
				}
				int num = (mGraphics.zoomLevel != 1) ? 10 : 0;
				if (this.info.charInfo == null)
				{
					PopUp.paintPopUp(g, this.X, this.Y, this.W, this.H, 16777215, false);
				}
				else
				{
					mSystem.paintPopUp2(g, this.X - 23, this.Y - num / 2, this.W + 15, this.H + ((!GameCanvas.isTouch) ? 14 : 0) + num);
				}
				if (this.info.charInfo == null)
				{
					g.drawRegion(Info.gocnhon, 0, 0, 9, 8, (dir != 1) ? 2 : 0, this.cx - 3 + ((dir != 1) ? 20 : -15), this.cy - this.ch - 20 + this.sayRun + 2, mGraphics.TOP | mGraphics.HCENTER);
				}
				int num2 = -1;
				int i = 0;
				while (i < this.says.Length)
				{
					mFont mFont = mFont.tahoma_7;
					string text = this.says[i];
					int num4;
					if (this.says[i].StartsWith("|"))
					{
						string[] array = Res.split(this.says[i], "|", 0);
						if (array.Length == 3)
						{
							text = array[2];
						}
						if (array.Length == 4)
						{
							text = array[3];
							int num3 = int.Parse(array[2]);
						}
						num4 = int.Parse(array[1]);
						num2 = num4;
					}
					else
					{
						num4 = num2;
					}
					switch (num4 + 1)
					{
					case 0:
						mFont = mFont.tahoma_7;
						break;
					case 1:
						mFont = mFont.tahoma_7b_dark;
						break;
					case 2:
						mFont = mFont.tahoma_7b_green;
						break;
					case 3:
						mFont = mFont.tahoma_7b_blue;
						break;
					case 4:
						mFont = mFont.tahoma_7_red;
						break;
					case 5:
						mFont = mFont.tahoma_7_green;
						break;
					case 6:
						mFont = mFont.tahoma_7_blue;
						break;
					case 8:
						mFont = mFont.tahoma_7b_red;
						break;
					}
					IL_28C:
					if (this.info.charInfo == null)
					{
						mFont.drawString(g, text, this.cx, this.cy - this.ch - 15 + this.sayRun + i * 12 - this.says.Length * 12 - 9, 2);
					}
					else
					{
						int num5 = this.X - 23;
						int num6 = this.Y - num / 2;
						int num7 = (mSystem.clientType != 1) ? (this.W + 25) : (this.W + 28);
						int num8 = this.H + ((!GameCanvas.isTouch) ? 14 : 0) + num;
						g.setColor(4465169);
						g.fillRect(num5, num6 + num8, num7, 2);
						int num9 = this.info.timeCount * num7 / this.info.maxTime;
						if (num9 < 0)
						{
							num9 = 0;
						}
						g.setColor(43758);
						g.fillRect(num5, num6 + num8, num9, 2);
						if (this.info.timeCount == 0)
						{
							return;
						}
						this.info.charInfo.paintHead(g, this.X + 10, this.Y + this.H / 2, 0);
						if (mGraphics.zoomLevel == 1)
						{
							((!this.info.isChatServer) ? mFont.tahoma_7b_greenSmall : mFont.tahoma_7b_yellowSmall2).drawString(g, this.info.charInfo.cName, this.X + 12, this.Y + 3, 0);
						}
						else
						{
							((!this.info.isChatServer) ? mFont.tahoma_7b_greenSmall : mFont.tahoma_7b_yellowSmall2).drawString(g, this.info.charInfo.cName, this.X + 12, this.Y - 3, 0);
						}
						if (!GameCanvas.isTouch)
						{
							if (!TField.isQwerty)
							{
								mFont.tahoma_7b_green2Small.drawString(g, "Nhấn # để chat", this.X + this.W / 2 + 10, this.Y + this.H, mFont.CENTER);
							}
							else
							{
								mFont.tahoma_7b_green2Small.drawString(g, "Nhấn Y để chat", this.X + this.W / 2 + 10, this.Y + this.H, mFont.CENTER);
							}
						}
						if (mGraphics.zoomLevel == 1)
						{
							TextInfo.paint(g, text, this.X + 14, this.Y + this.H / 2 + 2, this.W - 16, this.H, mFont.tahoma_7_whiteSmall);
						}
						else
						{
							string[] array2 = mFont.tahoma_7_whiteSmall.splitFontArray(text, 120);
							for (int j = 0; j < array2.Length; j++)
							{
								mFont.tahoma_7_whiteSmall.drawString(g, array2[j], this.X + 12, this.Y + 12 + j * 12 - 3, 0);
							}
							GameCanvas.resetTrans(g);
						}
					}
					i++;
					continue;
					goto IL_28C;
				}
				if (this.info.charInfo != null)
				{
				}
			}
			g.translate(-x, -y);
		}
	}

	// Token: 0x0600031F RID: 799 RVA: 0x0001BED4 File Offset: 0x0001A0D4
	public void update()
	{
		if (this.infoWaitToShow.size() != 0 && this.info.timeCount == 0)
		{
			this.time++;
			if (this.time >= this.info.speed)
			{
				this.time = 0;
				this.infoWaitToShow.removeElementAt(0);
				if (this.infoWaitToShow.size() == 0)
				{
					return;
				}
				InfoItem infoItem = (InfoItem)this.infoWaitToShow.firstElement();
				this.info = infoItem;
				this.getInfo();
			}
		}
	}

	// Token: 0x06000320 RID: 800 RVA: 0x0001BF6C File Offset: 0x0001A16C
	public void getInfo()
	{
		this.sayWidth = 100;
		if (GameCanvas.w == 128)
		{
			this.sayWidth = 128;
		}
		int num;
		if (this.info.charInfo != null)
		{
			this.says = new string[]
			{
				this.info.s
			};
			if (mGraphics.zoomLevel == 1)
			{
				num = this.says.Length;
			}
			else
			{
				string[] array = mFont.tahoma_7_whiteSmall.splitFontArray(this.info.s, 120);
				num = array.Length;
			}
		}
		else
		{
			this.says = mFont.tahoma_7.splitFontArray(this.info.s, this.sayWidth - 10);
			num = this.says.Length;
		}
		this.sayRun = 7;
		this.X = this.cx - this.sayWidth / 2 - 1;
		this.Y = this.cy - this.ch - 15 + this.sayRun - num * 12 - 15;
		this.W = this.sayWidth + 2 + ((this.info.charInfo == null) ? 0 : 30);
		this.H = (num + 1) * 12 + 1 + ((this.info.charInfo == null) ? 0 : 5);
	}

	// Token: 0x06000321 RID: 801 RVA: 0x0001C0BC File Offset: 0x0001A2BC
	public void addInfo(string s, int Type, global::Char cInfo, bool isChatServer)
	{
		this.type = Type;
		if (GameCanvas.w == 128)
		{
			this.limLeft = 1;
		}
		if (this.infoWaitToShow.size() > 10)
		{
			this.infoWaitToShow.removeElementAt(0);
		}
		if (this.infoWaitToShow.size() > 0 && s.Equals(((InfoItem)this.infoWaitToShow.lastElement()).s))
		{
			Res.outz("return");
			return;
		}
		InfoItem infoItem = new InfoItem(s);
		if (this.type == 0)
		{
			infoItem.speed = s.Length;
		}
		if (infoItem.speed < 70)
		{
			infoItem.speed = 70;
		}
		if (this.type == 1)
		{
			infoItem.speed = 10000000;
		}
		if (this.type == 3)
		{
			infoItem.speed = 300;
			infoItem.last = mSystem.currentTimeMillis();
			infoItem.timeCount = s.Length * 10 / 4;
			if (infoItem.timeCount < 150)
			{
				infoItem.timeCount = 150;
			}
			infoItem.maxTime = infoItem.timeCount;
		}
		if (cInfo != null)
		{
			infoItem.charInfo = cInfo;
			infoItem.isChatServer = isChatServer;
			GameCanvas.panel.addChatMessage(infoItem);
			if (GameCanvas.isTouch && GameCanvas.panel.isViewChatServer)
			{
				GameScr.info2.cmdChat = new Command(mResources.CHAT, this, 1000, infoItem);
			}
		}
		if ((cInfo != null && GameCanvas.panel.isViewChatServer) || cInfo == null)
		{
			this.infoWaitToShow.addElement(infoItem);
		}
		if (this.infoWaitToShow.size() == 1)
		{
			this.info = (InfoItem)this.infoWaitToShow.firstElement();
			this.getInfo();
		}
		if (GameCanvas.isTouch && cInfo != null && GameCanvas.panel.isViewChatServer && GameCanvas.w - 50 > 155 + this.W)
		{
			GameScr.info2.cmdChat.x = GameCanvas.w - this.W - 50;
			GameScr.info2.cmdChat.y = 35;
		}
	}

	// Token: 0x06000322 RID: 802 RVA: 0x0001C2F4 File Offset: 0x0001A4F4
	public void addInfo(string s, int speed, mFont f)
	{
		if (GameCanvas.w == 128)
		{
			this.limLeft = 1;
		}
		if (this.infoWaitToShow.size() > 10)
		{
			this.infoWaitToShow.removeElementAt(0);
		}
		this.infoWaitToShow.addElement(new InfoItem(s, f, speed));
	}

	// Token: 0x06000323 RID: 803 RVA: 0x00005146 File Offset: 0x00003346
	public bool isEmpty()
	{
		return this.p1 == 5 && this.infoWaitToShow.size() == 0;
	}

	// Token: 0x06000324 RID: 804 RVA: 0x00005165 File Offset: 0x00003365
	public void perform(int idAction, object p)
	{
		if (idAction == 1000)
		{
			ChatTextField.gI().startChat(GameScr.gI(), mResources.chat_player);
		}
	}

	// Token: 0x06000325 RID: 805 RVA: 0x00003984 File Offset: 0x00001B84
	public void onCancelChat()
	{
	}

	// Token: 0x040004E8 RID: 1256
	public MyVector infoWaitToShow = new MyVector();

	// Token: 0x040004E9 RID: 1257
	public InfoItem info;

	// Token: 0x040004EA RID: 1258
	public int p1 = 5;

	// Token: 0x040004EB RID: 1259
	public int p2;

	// Token: 0x040004EC RID: 1260
	public int p3;

	// Token: 0x040004ED RID: 1261
	public int x;

	// Token: 0x040004EE RID: 1262
	public int strWidth;

	// Token: 0x040004EF RID: 1263
	public int limLeft = 2;

	// Token: 0x040004F0 RID: 1264
	public int hI = 20;

	// Token: 0x040004F1 RID: 1265
	public int xChar;

	// Token: 0x040004F2 RID: 1266
	public int yChar;

	// Token: 0x040004F3 RID: 1267
	public int sayWidth = 100;

	// Token: 0x040004F4 RID: 1268
	public int sayRun;

	// Token: 0x040004F5 RID: 1269
	public string[] says;

	// Token: 0x040004F6 RID: 1270
	public int cx;

	// Token: 0x040004F7 RID: 1271
	public int cy;

	// Token: 0x040004F8 RID: 1272
	public int ch;

	// Token: 0x040004F9 RID: 1273
	public bool outSide;

	// Token: 0x040004FA RID: 1274
	public int f;

	// Token: 0x040004FB RID: 1275
	public int tF;

	// Token: 0x040004FC RID: 1276
	public Image img;

	// Token: 0x040004FD RID: 1277
	public static Image gocnhon = GameCanvas.loadImage("/mainImage/myTexture2dgocnhon.png");

	// Token: 0x040004FE RID: 1278
	public int time;

	// Token: 0x040004FF RID: 1279
	public int timeW;

	// Token: 0x04000500 RID: 1280
	public int type;

	// Token: 0x04000501 RID: 1281
	public int X;

	// Token: 0x04000502 RID: 1282
	public int Y;

	// Token: 0x04000503 RID: 1283
	public int W;

	// Token: 0x04000504 RID: 1284
	public int H;
}
