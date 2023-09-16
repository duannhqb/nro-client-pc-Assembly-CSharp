using System;

// Token: 0x02000037 RID: 55
public class ChatPopup : Effect2, IActionListener
{
	// Token: 0x06000243 RID: 579 RVA: 0x00004C77 File Offset: 0x00002E77
	public static void addNextPopUpMultiLine(string strNext, Npc next)
	{
		ChatPopup.nextMultiChatPopUp = strNext;
		ChatPopup.nextChar = next;
		if (ChatPopup.currChatPopup == null)
		{
			ChatPopup.addChatPopupMultiLine(ChatPopup.nextMultiChatPopUp, 100000, ChatPopup.nextChar);
			ChatPopup.nextMultiChatPopUp = null;
			ChatPopup.nextChar = null;
		}
	}

	// Token: 0x06000244 RID: 580 RVA: 0x0001423C File Offset: 0x0001243C
	public static void addBigMessage(string chat, int howLong, Npc c)
	{
		string[] array = new string[]
		{
			chat
		};
		if (c.charID != 5 && GameScr.info1.isDone)
		{
			GameScr.info1.isUpdate = false;
		}
		global::Char.isLockKey = true;
		ChatPopup.serverChatPopUp = ChatPopup.addChatPopup(array[0], howLong, c);
		ChatPopup.serverChatPopUp.strY = 5;
		ChatPopup.serverChatPopUp.cx = GameCanvas.w / 2 - ChatPopup.serverChatPopUp.sayWidth / 2 - 1;
		ChatPopup.serverChatPopUp.cy = GameCanvas.h - 20 - ChatPopup.serverChatPopUp.ch;
		ChatPopup.serverChatPopUp.currentLine = 0;
		ChatPopup.serverChatPopUp.lines = array;
		ChatPopup.scr = new Scroll();
		int nItem = ChatPopup.serverChatPopUp.says.Length;
		ChatPopup.scr.setStyle(nItem, 12, ChatPopup.serverChatPopUp.cx, ChatPopup.serverChatPopUp.cy - ChatPopup.serverChatPopUp.strY + 12, ChatPopup.serverChatPopUp.sayWidth + 2, ChatPopup.serverChatPopUp.ch - 25, true, 1);
		SoundMn.gI().openDialog();
	}

	// Token: 0x06000245 RID: 581 RVA: 0x00014358 File Offset: 0x00012558
	public static void addChatPopupMultiLine(string chat, int howLong, Npc c)
	{
		string[] array = Res.split(chat, "\n", 0);
		global::Char.isLockKey = true;
		ChatPopup.currChatPopup = ChatPopup.addChatPopup(array[0], howLong, c);
		ChatPopup.currChatPopup.currentLine = 0;
		ChatPopup.currChatPopup.lines = array;
		string caption = mResources.CONTINUE;
		if (array.Length == 1)
		{
			caption = mResources.CLOSE;
		}
		ChatPopup.currChatPopup.cmdNextLine = new Command(caption, ChatPopup.currChatPopup, 8000, null);
		ChatPopup.currChatPopup.cmdNextLine.x = GameCanvas.w / 2 - 35;
		ChatPopup.currChatPopup.cmdNextLine.y = GameCanvas.h - 35;
		SoundMn.gI().openDialog();
	}

	// Token: 0x06000246 RID: 582 RVA: 0x00014408 File Offset: 0x00012608
	public static ChatPopup addChatPopupWithIcon(string chat, int howLong, Npc c, int idIcon)
	{
		ChatPopup.performDelay = 10;
		ChatPopup chatPopup = new ChatPopup();
		chatPopup.sayWidth = GameCanvas.w - 30 - ((!GameCanvas.menu.showMenu) ? 0 : GameCanvas.menu.menuX);
		if (chatPopup.sayWidth > 320)
		{
			chatPopup.sayWidth = 320;
		}
		if (chat.Length < 10)
		{
			chatPopup.sayWidth = 64;
		}
		if (GameCanvas.w == 128)
		{
			chatPopup.sayWidth = 128;
		}
		chatPopup.says = mFont.tahoma_7_red.splitFontArray(chat, chatPopup.sayWidth - 10);
		chatPopup.delay = howLong;
		chatPopup.c = c;
		chatPopup.iconID = idIcon;
		global::Char.chatPopup = chatPopup;
		chatPopup.ch = 15 - chatPopup.sayRun + chatPopup.says.Length * 12 + 10;
		if (chatPopup.ch > GameCanvas.h - 80)
		{
			chatPopup.ch = GameCanvas.h - 80;
		}
		chatPopup.mH = 10;
		if (GameCanvas.menu.showMenu)
		{
			chatPopup.mH = 0;
		}
		Effect2.vEffect2.addElement(chatPopup);
		ChatPopup.isHavePetNpc = false;
		if (c != null && c.charID == 5)
		{
			ChatPopup.isHavePetNpc = true;
			GameScr.info1.addInfo(string.Empty, 1);
		}
		ChatPopup.curr = (ChatPopup.last = mSystem.currentTimeMillis());
		chatPopup.ch += 15;
		return chatPopup;
	}

	// Token: 0x06000247 RID: 583 RVA: 0x00014588 File Offset: 0x00012788
	public static ChatPopup addChatPopup(string chat, int howLong, Npc c)
	{
		ChatPopup.performDelay = 10;
		ChatPopup chatPopup = new ChatPopup();
		chatPopup.sayWidth = GameCanvas.w - 30 - ((!GameCanvas.menu.showMenu) ? 0 : GameCanvas.menu.menuX);
		if (chatPopup.sayWidth > 320)
		{
			chatPopup.sayWidth = 320;
		}
		if (chat.Length < 10)
		{
			chatPopup.sayWidth = 64;
		}
		if (GameCanvas.w == 128)
		{
			chatPopup.sayWidth = 128;
		}
		chatPopup.says = mFont.tahoma_7_red.splitFontArray(chat, chatPopup.sayWidth - 10);
		chatPopup.delay = howLong;
		chatPopup.c = c;
		global::Char.chatPopup = chatPopup;
		chatPopup.ch = 15 - chatPopup.sayRun + chatPopup.says.Length * 12 + 10;
		if (chatPopup.ch > GameCanvas.h - 80)
		{
			chatPopup.ch = GameCanvas.h - 80;
		}
		chatPopup.mH = 10;
		if (GameCanvas.menu.showMenu)
		{
			chatPopup.mH = 0;
		}
		Effect2.vEffect2.addElement(chatPopup);
		ChatPopup.isHavePetNpc = false;
		if (c != null && c.charID == 5)
		{
			ChatPopup.isHavePetNpc = true;
			GameScr.info1.addInfo(string.Empty, 1);
		}
		ChatPopup.curr = (ChatPopup.last = mSystem.currentTimeMillis());
		return chatPopup;
	}

	// Token: 0x06000248 RID: 584 RVA: 0x000146F0 File Offset: 0x000128F0
	public override void update()
	{
		if (ChatPopup.scr != null)
		{
			GameScr.info1.isUpdate = false;
			ChatPopup.scr.updatecm();
		}
		else
		{
			GameScr.info1.isUpdate = true;
		}
		if (GameCanvas.menu.showMenu)
		{
			this.strY = 0;
			this.cx = GameCanvas.w / 2 - this.sayWidth / 2 - 1;
			this.cy = GameCanvas.menu.menuY - this.ch;
		}
		else
		{
			this.strY = 0;
			if (GameScr.gI().right != null || GameScr.gI().left != null || GameScr.gI().center != null || this.cmdNextLine != null || this.cmdMsg1 != null)
			{
				this.strY = 5;
				this.cx = GameCanvas.w / 2 - this.sayWidth / 2 - 1;
				this.cy = GameCanvas.h - 20 - this.ch;
			}
			else
			{
				this.cx = GameCanvas.w / 2 - this.sayWidth / 2 - 1;
				this.cy = GameCanvas.h - 5 - this.ch;
			}
		}
		if (this.delay > 0)
		{
			this.delay--;
		}
		if (ChatPopup.performDelay > 0)
		{
			ChatPopup.performDelay--;
		}
		if (this.sayRun > 1)
		{
			this.sayRun--;
		}
		if ((this.c != null && global::Char.chatPopup != null && global::Char.chatPopup != this) || (this.c != null && global::Char.chatPopup == null) || this.delay == 0)
		{
			Effect2.vEffect2Outside.removeElement(this);
			Effect2.vEffect2.removeElement(this);
		}
	}

	// Token: 0x06000249 RID: 585 RVA: 0x000148C8 File Offset: 0x00012AC8
	public override void paint(mGraphics g)
	{
		if (GameScr.gI().activeRongThan && GameScr.gI().isUseFreez)
		{
			return;
		}
		GameCanvas.resetTrans(g);
		int num = this.cx;
		int num2 = this.cy;
		int num3 = this.sayWidth + 2;
		int num4 = this.ch;
		if ((num <= 0 || num2 <= 0) && !GameCanvas.panel.isShow)
		{
			return;
		}
		PopUp.paintPopUp(g, num, num2, num3, num4, 16777215, false);
		if (this.c != null)
		{
			SmallImage.drawSmallImage(g, this.c.avatar, this.cx + 14, this.cy, 0, StaticObj.BOTTOM_LEFT);
		}
		if (this.iconID != 0)
		{
			SmallImage.drawSmallImage(g, this.iconID, this.cx + num3 / 2, this.cy + this.ch - 15, 0, StaticObj.VCENTER_HCENTER);
		}
		if (ChatPopup.scr != null)
		{
			g.setClip(num, num2, num3, num4 - 16);
			g.translate(0, -ChatPopup.scr.cmy);
		}
		int tx = 0;
		int ty = 0;
		if (this.isClip)
		{
			tx = g.getTranslateX();
			ty = g.getTranslateY();
			g.setClip(num, num2 + 1, num3, num4 - 17);
			g.translate(0, -ChatPopup.cmyText);
		}
		int num5 = -1;
		for (int i = 0; i < this.says.Length; i++)
		{
			if (!this.says[i].StartsWith("--"))
			{
				mFont mFont = mFont.tahoma_7;
				int num6 = 2;
				string st = this.says[i];
				int num7;
				if (this.says[i].StartsWith("|"))
				{
					string[] array = Res.split(this.says[i], "|", 0);
					if (array.Length == 3)
					{
						st = array[2];
					}
					if (array.Length == 4)
					{
						st = array[3];
						num6 = int.Parse(array[2]);
					}
					num7 = int.Parse(array[1]);
					num5 = num7;
				}
				else
				{
					num7 = num5;
				}
				switch (num7 + 1)
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
				IL_2B2:
				if (this.says[i].StartsWith("<"))
				{
					string[] array2 = Res.split(this.says[i], "<", 0);
					string[] array3 = Res.split(array2[1], ">", 1);
					if (this.second == 0)
					{
						this.second = int.Parse(array3[1]);
					}
					else
					{
						ChatPopup.curr = mSystem.currentTimeMillis();
						if (ChatPopup.curr - ChatPopup.last >= 1000L)
						{
							ChatPopup.last = ChatPopup.curr;
							this.second--;
						}
					}
					st = this.second + " " + array3[2];
					mFont.drawString(g, st, this.cx + this.sayWidth / 2, this.cy + this.sayRun + i * 12 - this.strY + 12, num6);
					goto IL_420;
				}
				if (num6 == 2)
				{
					mFont.drawString(g, st, this.cx + this.sayWidth / 2, this.cy + this.sayRun + i * 12 - this.strY + 12, num6);
				}
				if (num6 == 1)
				{
					mFont.drawString(g, st, this.cx + this.sayWidth - 5, this.cy + this.sayRun + i * 12 - this.strY + 12, num6);
					goto IL_420;
				}
				goto IL_420;
				goto IL_2B2;
			}
			g.setColor(0);
			g.fillRect(num + 10, this.cy + this.sayRun + i * 12 + 6, num3 - 20, 1);
			IL_420:;
		}
		if (this.isClip)
		{
			GameCanvas.resetTrans(g);
			g.translate(tx, ty);
		}
		if ((int)this.maxStarSlot > 0)
		{
			for (int j = 0; j < (int)this.maxStarSlot; j++)
			{
				g.drawImage(Panel.imgMaxStar, num + num3 / 2 - (int)this.maxStarSlot * 20 / 2 + j * 20 + mGraphics.getImageWidth(Panel.imgStar), num2 + num4 - 13, 3);
			}
		}
		if ((int)this.starSlot > 0)
		{
			for (int k = 0; k < (int)this.starSlot; k++)
			{
				g.drawImage(Panel.imgStar, num + num3 / 2 - (int)this.maxStarSlot * 20 / 2 + k * 20 + mGraphics.getImageWidth(Panel.imgStar), num2 + num4 - 13, 3);
			}
		}
		this.paintCmd(g);
	}

	// Token: 0x0600024A RID: 586 RVA: 0x00014DE8 File Offset: 0x00012FE8
	public void paintRada(mGraphics g, int cmyText)
	{
		int num = this.cx;
		int num2 = this.cy;
		int num3 = this.sayWidth;
		int num4 = this.ch;
		int translateX = g.getTranslateX();
		int translateY = g.getTranslateY();
		g.translate(0, -cmyText);
		if ((num <= 0 || num2 <= 0) && !GameCanvas.panel.isShow)
		{
			return;
		}
		int num5 = -1;
		for (int i = 0; i < this.says.Length; i++)
		{
			if (this.says[i].StartsWith("--"))
			{
				g.setColor(16777215);
				g.fillRect(num + 10, this.cy + this.sayRun + i * 12 - 6, num3 - 20, 1);
			}
			else
			{
				mFont mFont = mFont.tahoma_7_white;
				int num6 = 2;
				string st = this.says[i];
				int num7;
				if (this.says[i].StartsWith("|"))
				{
					string[] array = Res.split(this.says[i], "|", 0);
					if (array.Length == 3)
					{
						st = array[2];
					}
					if (array.Length == 4)
					{
						st = array[3];
						num6 = int.Parse(array[2]);
					}
					num7 = int.Parse(array[1]);
					num5 = num7;
				}
				else
				{
					num7 = num5;
				}
				switch (num7 + 1)
				{
				case 0:
					mFont = mFont.tahoma_7_white;
					break;
				case 1:
					mFont = mFont.tahoma_7b_white;
					break;
				case 2:
					mFont = mFont.tahoma_7b_green;
					break;
				case 3:
					mFont = mFont.tahoma_7b_red;
					break;
				}
				if (this.says[i].StartsWith("<"))
				{
					string[] array2 = Res.split(this.says[i], "<", 0);
					string[] array3 = Res.split(array2[1], ">", 1);
					if (this.second == 0)
					{
						this.second = int.Parse(array3[1]);
					}
					else
					{
						ChatPopup.curr = mSystem.currentTimeMillis();
						if (ChatPopup.curr - ChatPopup.last >= 1000L)
						{
							ChatPopup.last = ChatPopup.curr;
							this.second--;
						}
					}
					st = this.second + " " + array3[2];
					mFont.drawString(g, st, this.cx + this.sayWidth / 2, this.cy + this.sayRun + i * 12 - this.strY, num6);
				}
				else
				{
					if (num6 == 2)
					{
						mFont.drawString(g, st, this.cx + this.sayWidth / 2, this.cy + this.sayRun + i * 12 - this.strY, num6);
					}
					if (num6 == 1)
					{
						mFont.drawString(g, st, this.cx + this.sayWidth - 5, this.cy + this.sayRun + i * 12 - this.strY, num6);
					}
				}
			}
		}
		GameCanvas.resetTrans(g);
		g.translate(translateX, translateY);
	}

	// Token: 0x0600024B RID: 587 RVA: 0x00004CAF File Offset: 0x00002EAF
	private void doKeyText(int type)
	{
		ChatPopup.cmyText += 12 * type;
		if (ChatPopup.cmyText < 0)
		{
			ChatPopup.cmyText = 0;
		}
		if (ChatPopup.cmyText > this.lim)
		{
			ChatPopup.cmyText = this.lim;
		}
	}

	// Token: 0x0600024C RID: 588 RVA: 0x0001510C File Offset: 0x0001330C
	public void updateKey()
	{
		if (this.isClip)
		{
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
			if (GameCanvas.isPointerHoldIn(this.cx, 0, this.sayWidth + 2, this.ch))
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
						ChatPopup.cmyText += this.pxx;
						this.pyy = GameCanvas.py;
					}
					if (ChatPopup.cmyText < 0)
					{
						ChatPopup.cmyText = 0;
					}
					if (ChatPopup.cmyText > this.lim)
					{
						ChatPopup.cmyText = this.lim;
					}
				}
				else
				{
					this.pyy = 0;
					this.pyy = 0;
				}
			}
		}
		if (ChatPopup.scr != null)
		{
			if (GameCanvas.isTouch)
			{
				ChatPopup.scr.updateKey();
			}
			if (GameCanvas.keyHold[(!Main.isPC) ? 2 : 21])
			{
				ChatPopup.scr.cmtoY -= 12;
				if (ChatPopup.scr.cmtoY < 0)
				{
					ChatPopup.scr.cmtoY = 0;
				}
			}
			if (GameCanvas.keyHold[(!Main.isPC) ? 8 : 22])
			{
				GameCanvas.keyPressed[(!Main.isPC) ? 8 : 22] = false;
				ChatPopup.scr.cmtoY += 12;
				if (ChatPopup.scr.cmtoY > ChatPopup.scr.cmyLim)
				{
					ChatPopup.scr.cmtoY = ChatPopup.scr.cmyLim;
				}
			}
		}
		if (GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] || mScreen.getCmdPointerLast(GameCanvas.currentScreen.center))
		{
			GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] = false;
			mScreen.keyTouch = -1;
			if (this.cmdNextLine != null)
			{
				this.cmdNextLine.performAction();
			}
			else if (this.cmdMsg1 != null)
			{
				this.cmdMsg1.performAction();
			}
			else if (this.cmdMsg2 != null)
			{
				this.cmdMsg2.performAction();
			}
		}
		if (ChatPopup.scr != null && ChatPopup.scr.pointerIsDowning)
		{
			return;
		}
		if (this.cmdMsg1 != null && (GameCanvas.keyPressed[12] || GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] || mScreen.getCmdPointerLast(this.cmdMsg1)))
		{
			GameCanvas.keyPressed[12] = false;
			GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] = false;
			GameCanvas.isPointerClick = false;
			GameCanvas.isPointerJustRelease = false;
			this.cmdMsg1.performAction();
			mScreen.keyTouch = -1;
		}
		if (this.cmdMsg2 != null && (GameCanvas.keyPressed[13] || mScreen.getCmdPointerLast(this.cmdMsg2)))
		{
			GameCanvas.keyPressed[13] = false;
			GameCanvas.isPointerClick = false;
			GameCanvas.isPointerJustRelease = false;
			this.cmdMsg2.performAction();
			mScreen.keyTouch = -1;
		}
	}

	// Token: 0x0600024D RID: 589 RVA: 0x000154C0 File Offset: 0x000136C0
	public void paintCmd(mGraphics g)
	{
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
		GameCanvas.paintz.paintTabSoft(g);
		if (this.cmdNextLine != null)
		{
			GameCanvas.paintz.paintCmdBar(g, null, this.cmdNextLine, null);
		}
		if (this.cmdMsg1 != null)
		{
			GameCanvas.paintz.paintCmdBar(g, this.cmdMsg1, null, this.cmdMsg2);
		}
	}

	// Token: 0x0600024E RID: 590 RVA: 0x00015540 File Offset: 0x00013740
	public void perform(int idAction, object p)
	{
		if (idAction == 1000)
		{
			try
			{
				GameMidlet.instance.platformRequest((string)p);
			}
			catch (Exception ex)
			{
			}
			if (!Main.isPC)
			{
				GameMidlet.instance.notifyDestroyed();
			}
			else
			{
				idAction = 1001;
			}
			GameCanvas.endDlg();
		}
		if (idAction == 1001)
		{
			ChatPopup.scr = null;
			global::Char.chatPopup = null;
			ChatPopup.serverChatPopUp = null;
			GameScr.info1.isUpdate = true;
			global::Char.isLockKey = false;
			if (ChatPopup.isHavePetNpc)
			{
				GameScr.info1.info.time = 0;
				GameScr.info1.info.info.speed = 10;
			}
		}
		if (idAction == 8000)
		{
			if (ChatPopup.performDelay > 0)
			{
				return;
			}
			int num = ChatPopup.currChatPopup.currentLine;
			num++;
			if (num >= ChatPopup.currChatPopup.lines.Length)
			{
				global::Char.chatPopup = null;
				ChatPopup.currChatPopup = null;
				GameScr.info1.isUpdate = true;
				global::Char.isLockKey = false;
				if (ChatPopup.nextMultiChatPopUp != null)
				{
					ChatPopup.addChatPopupMultiLine(ChatPopup.nextMultiChatPopUp, 100000, ChatPopup.nextChar);
					ChatPopup.nextMultiChatPopUp = null;
					ChatPopup.nextChar = null;
				}
				else if (ChatPopup.isHavePetNpc)
				{
					GameScr.info1.info.time = 0;
					for (int i = 0; i < GameScr.info1.info.infoWaitToShow.size(); i++)
					{
						if (((InfoItem)GameScr.info1.info.infoWaitToShow.elementAt(i)).speed == 10000000)
						{
							((InfoItem)GameScr.info1.info.infoWaitToShow.elementAt(i)).speed = 10;
						}
					}
				}
				return;
			}
			ChatPopup chatPopup = ChatPopup.addChatPopup(ChatPopup.currChatPopup.lines[num], ChatPopup.currChatPopup.delay, ChatPopup.currChatPopup.c);
			chatPopup.currentLine = num;
			chatPopup.lines = ChatPopup.currChatPopup.lines;
			chatPopup.cmdNextLine = ChatPopup.currChatPopup.cmdNextLine;
			ChatPopup.currChatPopup = chatPopup;
		}
	}

	// Token: 0x04000259 RID: 601
	public int sayWidth = 100;

	// Token: 0x0400025A RID: 602
	public int delay;

	// Token: 0x0400025B RID: 603
	public int sayRun;

	// Token: 0x0400025C RID: 604
	public string[] says;

	// Token: 0x0400025D RID: 605
	public int cx;

	// Token: 0x0400025E RID: 606
	public int cy;

	// Token: 0x0400025F RID: 607
	public int ch;

	// Token: 0x04000260 RID: 608
	public int cmx;

	// Token: 0x04000261 RID: 609
	public int cmy;

	// Token: 0x04000262 RID: 610
	public int lim;

	// Token: 0x04000263 RID: 611
	public Npc c;

	// Token: 0x04000264 RID: 612
	private bool outSide;

	// Token: 0x04000265 RID: 613
	public static long curr;

	// Token: 0x04000266 RID: 614
	public static long last;

	// Token: 0x04000267 RID: 615
	private int currentLine;

	// Token: 0x04000268 RID: 616
	private string[] lines;

	// Token: 0x04000269 RID: 617
	public Command cmdNextLine;

	// Token: 0x0400026A RID: 618
	public Command cmdMsg1;

	// Token: 0x0400026B RID: 619
	public Command cmdMsg2;

	// Token: 0x0400026C RID: 620
	public static ChatPopup currChatPopup;

	// Token: 0x0400026D RID: 621
	public static ChatPopup serverChatPopUp;

	// Token: 0x0400026E RID: 622
	public static string nextMultiChatPopUp;

	// Token: 0x0400026F RID: 623
	public static Npc nextChar;

	// Token: 0x04000270 RID: 624
	public bool isShopDetail;

	// Token: 0x04000271 RID: 625
	public sbyte starSlot;

	// Token: 0x04000272 RID: 626
	public sbyte maxStarSlot;

	// Token: 0x04000273 RID: 627
	public static Scroll scr;

	// Token: 0x04000274 RID: 628
	public static bool isHavePetNpc;

	// Token: 0x04000275 RID: 629
	public int mH;

	// Token: 0x04000276 RID: 630
	public static int performDelay;

	// Token: 0x04000277 RID: 631
	public int dx;

	// Token: 0x04000278 RID: 632
	public int dy;

	// Token: 0x04000279 RID: 633
	public int second;

	// Token: 0x0400027A RID: 634
	public int strY;

	// Token: 0x0400027B RID: 635
	private int iconID;

	// Token: 0x0400027C RID: 636
	public bool isClip;

	// Token: 0x0400027D RID: 637
	public static int cmyText;

	// Token: 0x0400027E RID: 638
	private int pxx;

	// Token: 0x0400027F RID: 639
	private int pyy;
}
