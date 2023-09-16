using System;

// Token: 0x020000BE RID: 190
public class TabClanIcon : IActionListener
{
	// Token: 0x0600093D RID: 2365 RVA: 0x0008A470 File Offset: 0x00088670
	public TabClanIcon()
	{
		this.left = new Command(mResources.SELECT, this, 1, null);
		this.right = new Command(mResources.CLOSE, this, 2, null);
	}

	// Token: 0x0600093E RID: 2366 RVA: 0x0008A4C4 File Offset: 0x000886C4
	public void init()
	{
		if (this.isGetName)
		{
			this.w = 170;
			this.h = 118;
			this.x = GameCanvas.w / 2 - this.w / 2;
			this.y = GameCanvas.h / 2 - this.h / 2;
		}
		else
		{
			this.w = 170;
			this.h = 170;
			this.x = GameCanvas.w / 2 - this.w / 2;
			this.y = GameCanvas.h / 2 - this.h / 2;
			if (GameCanvas.h < 240)
			{
				this.y -= 10;
			}
		}
		this.cmx = this.x;
		this.cmtoX = 0;
		if (!this.isRequest)
		{
			this.nItem = ClanImage.vClanImage.size();
		}
		else
		{
			this.nItem = this.vItems.size();
		}
		if (GameCanvas.isTouch)
		{
			this.left.x = this.x;
			this.left.y = this.y + this.h + 5;
			this.right.x = this.x + this.w - 68;
			this.right.y = this.y + this.h + 5;
		}
		TabClanIcon.scrMain = new Scroll();
		TabClanIcon.scrMain.setStyle(this.nItem, this.WIDTH, this.x, this.y + this.disStart, this.w, this.h - this.disStart, true, 1);
	}

	// Token: 0x0600093F RID: 2367 RVA: 0x00007A77 File Offset: 0x00005C77
	public void show(bool isGetName)
	{
		if (global::Char.myCharz().clan != null)
		{
			this.isUpdate = true;
		}
		this.isShow = true;
		this.isGetName = isGetName;
		this.init();
	}

	// Token: 0x06000940 RID: 2368 RVA: 0x00007AA3 File Offset: 0x00005CA3
	public void showRequest(int msgID)
	{
		this.isShow = true;
		this.isRequest = true;
		this.msgID = msgID;
		this.init();
	}

	// Token: 0x06000941 RID: 2369 RVA: 0x00007AC0 File Offset: 0x00005CC0
	public void hide()
	{
		this.cmtoX = this.x + this.w;
		SmallImage.clearHastable();
	}

	// Token: 0x06000942 RID: 2370 RVA: 0x00003984 File Offset: 0x00001B84
	public void paintPeans(mGraphics g)
	{
	}

	// Token: 0x06000943 RID: 2371 RVA: 0x0008A678 File Offset: 0x00088878
	public void paintIcon(mGraphics g)
	{
		g.translate(-this.cmx, 0);
		PopUp.paintPopUp(g, this.x, this.y - 17, this.w, this.h + 17, -1, true);
		mFont.tahoma_7b_dark.drawString(g, mResources.select_clan_icon, this.x + this.w / 2, this.y - 7, 2);
		if (this.lastSelect >= 0 && this.lastSelect <= ClanImage.vClanImage.size() - 1)
		{
			ClanImage clanImage = (ClanImage)ClanImage.vClanImage.elementAt(this.lastSelect);
			if (clanImage.idImage != null)
			{
				global::Char.myCharz().paintBag(g, clanImage.idImage, GameCanvas.w / 2, this.y + 45, 1, false);
			}
		}
		global::Char.myCharz().paintCharBody(g, GameCanvas.w / 2, this.y + 45, 1, global::Char.myCharz().cf, false);
		g.setClip(this.x, this.y + this.disStart, this.w, this.h - this.disStart - 10);
		if (TabClanIcon.scrMain != null)
		{
			g.translate(0, -TabClanIcon.scrMain.cmy);
		}
		for (int i = 0; i < this.nItem; i++)
		{
			int num = this.x + 10;
			int num2 = this.y + i * this.WIDTH + this.disStart;
			if (num2 + this.WIDTH - ((TabClanIcon.scrMain == null) ? 0 : TabClanIcon.scrMain.cmy) >= this.y + this.disStart && num2 - ((TabClanIcon.scrMain == null) ? 0 : TabClanIcon.scrMain.cmy) <= this.y + this.disStart + this.h)
			{
				ClanImage clanImage2 = (ClanImage)ClanImage.vClanImage.elementAt(i);
				mFont mFont = mFont.tahoma_7_grey;
				if (i == this.lastSelect)
				{
					mFont = mFont.tahoma_7_blue;
				}
				if (clanImage2.name != null)
				{
					mFont.drawString(g, clanImage2.name, num + 20, num2, 0);
				}
				if (clanImage2.xu > 0)
				{
					mFont.drawString(g, clanImage2.xu + " " + mResources.XU, num + this.w - 20, num2, mFont.RIGHT);
				}
				else if (clanImage2.luong > 0)
				{
					mFont.drawString(g, clanImage2.luong + " " + mResources.LUONG, num + this.w - 20, num2, mFont.RIGHT);
				}
				if (clanImage2.idImage != null)
				{
					SmallImage.drawSmallImage(g, (int)clanImage2.idImage[0], num, num2, 0, 0);
				}
			}
		}
		g.translate(0, -g.getTranslateY());
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
		GameCanvas.paintz.paintCmdBar(g, this.left, this.center, this.right);
	}

	// Token: 0x06000944 RID: 2372 RVA: 0x00007ADA File Offset: 0x00005CDA
	public void paint(mGraphics g)
	{
		if (!this.isRequest)
		{
			this.paintIcon(g);
		}
		else
		{
			this.paintPeans(g);
		}
	}

	// Token: 0x06000945 RID: 2373 RVA: 0x0008A98C File Offset: 0x00088B8C
	public void update()
	{
		if (TabClanIcon.scrMain != null)
		{
			TabClanIcon.scrMain.updatecm();
		}
		if (this.cmx != this.cmtoX)
		{
			this.cmvx = this.cmtoX - this.cmx << 2;
			this.cmdx += this.cmvx;
			this.cmx += this.cmdx >> 3;
			this.cmdx &= 15;
		}
		if (global::Math.abs(this.cmtoX - this.cmx) < 10)
		{
			this.cmx = this.cmtoX;
		}
		if (this.cmx >= this.x + this.w - 10 && this.cmtoX >= this.x + this.w - 10)
		{
			this.isShow = false;
		}
	}

	// Token: 0x06000946 RID: 2374 RVA: 0x0008AA6C File Offset: 0x00088C6C
	public void updateKey()
	{
		if (this.left != null && (GameCanvas.keyPressed[12] || mScreen.getCmdPointerLast(this.left)))
		{
			this.left.performAction();
		}
		if (this.right != null && (GameCanvas.keyPressed[13] || mScreen.getCmdPointerLast(this.right)))
		{
			this.right.performAction();
		}
		if (this.center != null && (GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] || mScreen.getCmdPointerLast(this.center)))
		{
			this.center.performAction();
		}
		if (!this.isGetName)
		{
			if (TabClanIcon.scrMain == null)
			{
				return;
			}
			if (GameCanvas.isTouch)
			{
				TabClanIcon.scrMain.updateKey();
				this.select = TabClanIcon.scrMain.selectedItem;
			}
			if (GameCanvas.keyPressed[(!Main.isPC) ? 2 : 21])
			{
				GameCanvas.keyPressed[(!Main.isPC) ? 2 : 21] = false;
				this.select--;
				if (this.select < 0)
				{
					this.select = this.nItem - 1;
				}
				TabClanIcon.scrMain.moveTo(this.select * TabClanIcon.scrMain.ITEM_SIZE);
			}
			if (GameCanvas.keyPressed[(!Main.isPC) ? 8 : 22])
			{
				GameCanvas.keyPressed[(!Main.isPC) ? 8 : 22] = false;
				this.select++;
				if (this.select > this.nItem - 1)
				{
					this.select = 0;
				}
				TabClanIcon.scrMain.moveTo(this.select * TabClanIcon.scrMain.ITEM_SIZE);
			}
			if (this.select != -1)
			{
				this.lastSelect = this.select;
			}
		}
		GameCanvas.clearKeyHold();
		GameCanvas.clearKeyPressed();
	}

	// Token: 0x06000947 RID: 2375 RVA: 0x0008AC78 File Offset: 0x00088E78
	public void perform(int idAction, object p)
	{
		if (idAction == 2)
		{
			this.hide();
		}
		if (idAction == 1)
		{
			if (!this.isGetName)
			{
				if (!this.isRequest)
				{
					if (this.lastSelect >= 0)
					{
						this.hide();
						if (global::Char.myCharz().clan == null)
						{
							Service.gI().getClan(2, (sbyte)((ClanImage)ClanImage.vClanImage.elementAt(this.lastSelect)).ID, this.text);
						}
						else
						{
							Service.gI().getClan(4, (sbyte)((ClanImage)ClanImage.vClanImage.elementAt(this.lastSelect)).ID, string.Empty);
						}
					}
				}
				else if (this.lastSelect >= 0)
				{
					Item item = (Item)this.vItems.elementAt(this.select);
				}
			}
		}
	}

	// Token: 0x040010ED RID: 4333
	private int x;

	// Token: 0x040010EE RID: 4334
	private int y;

	// Token: 0x040010EF RID: 4335
	private int w;

	// Token: 0x040010F0 RID: 4336
	private int h;

	// Token: 0x040010F1 RID: 4337
	private Command left;

	// Token: 0x040010F2 RID: 4338
	private Command right;

	// Token: 0x040010F3 RID: 4339
	private Command center;

	// Token: 0x040010F4 RID: 4340
	private int WIDTH = 24;

	// Token: 0x040010F5 RID: 4341
	public int nItem;

	// Token: 0x040010F6 RID: 4342
	private int disStart = 50;

	// Token: 0x040010F7 RID: 4343
	public static Scroll scrMain;

	// Token: 0x040010F8 RID: 4344
	public int cmtoX;

	// Token: 0x040010F9 RID: 4345
	public int cmx;

	// Token: 0x040010FA RID: 4346
	public int cmvx;

	// Token: 0x040010FB RID: 4347
	public int cmdx;

	// Token: 0x040010FC RID: 4348
	public bool isShow;

	// Token: 0x040010FD RID: 4349
	public bool isGetName;

	// Token: 0x040010FE RID: 4350
	public string text;

	// Token: 0x040010FF RID: 4351
	private bool isRequest;

	// Token: 0x04001100 RID: 4352
	private bool isUpdate;

	// Token: 0x04001101 RID: 4353
	public MyVector vItems = new MyVector();

	// Token: 0x04001102 RID: 4354
	private int msgID;

	// Token: 0x04001103 RID: 4355
	private int select;

	// Token: 0x04001104 RID: 4356
	private int lastSelect;

	// Token: 0x04001105 RID: 4357
	private ScrollResult sr;
}
