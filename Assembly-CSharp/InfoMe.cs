using System;

// Token: 0x020000A8 RID: 168
public class InfoMe
{
	// Token: 0x06000734 RID: 1844 RVA: 0x00064A70 File Offset: 0x00062C70
	public InfoMe()
	{
		for (int i = 0; i < this.charId.Length; i++)
		{
			this.charId[i] = new int[3];
		}
	}

	// Token: 0x06000735 RID: 1845 RVA: 0x00006E86 File Offset: 0x00005086
	public static InfoMe gI()
	{
		if (InfoMe.me == null)
		{
			InfoMe.me = new InfoMe();
		}
		return InfoMe.me;
	}

	// Token: 0x06000736 RID: 1846 RVA: 0x00064AC8 File Offset: 0x00062CC8
	public void loadCharId()
	{
		for (int i = 0; i < this.charId.Length; i++)
		{
			this.charId[i] = new int[3];
		}
	}

	// Token: 0x06000737 RID: 1847 RVA: 0x00064AFC File Offset: 0x00062CFC
	public void paint(mGraphics g)
	{
		if (this.Equals(GameScr.info2) && GameScr.gI().isVS())
		{
			return;
		}
		if (this.Equals(GameScr.info2) && GameScr.gI().popUpYesNo != null)
		{
			return;
		}
		if (!GameScr.isPaint)
		{
			return;
		}
		if (GameCanvas.currentScreen != GameScr.gI() && GameCanvas.currentScreen != CrackBallScr.gI())
		{
			return;
		}
		if (ChatPopup.serverChatPopUp != null)
		{
			return;
		}
		if (!this.isUpdate)
		{
			return;
		}
		if (global::Char.ischangingMap)
		{
			return;
		}
		if (GameCanvas.panel.isShow && this.Equals(GameScr.info2))
		{
			return;
		}
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
		if (this.info != null)
		{
			this.info.paint(g, this.cmx, this.cmy, this.dir);
			if (this.info.info == null || this.info.info.charInfo == null || this.cmdChat != null || !GameCanvas.isTouch)
			{
			}
			if (this.info.info == null || this.info.info.charInfo == null || this.cmdChat != null)
			{
			}
		}
		if (this.info.info != null && this.info.info.charInfo == null && this.charId != null)
		{
			SmallImage.drawSmallImage(g, this.charId[global::Char.myCharz().cgender][this.f], this.cmx, this.cmy + 3 + ((GameCanvas.gameTick % 10 <= 5) ? 0 : 1), (this.dir != 1) ? 2 : 0, StaticObj.VCENTER_HCENTER);
		}
		g.translate(-g.getTranslateX(), -g.getTranslateY());
	}

	// Token: 0x06000738 RID: 1848 RVA: 0x00006EA1 File Offset: 0x000050A1
	public void hide()
	{
		this.info.hide();
	}

	// Token: 0x06000739 RID: 1849 RVA: 0x00064D0C File Offset: 0x00062F0C
	public void moveCamera()
	{
		if (this.cmy != this.cmtoY)
		{
			this.cmvy = this.cmtoY - this.cmy << 2;
			this.cmdy += this.cmvy;
			this.cmy += this.cmdy >> 4;
			this.cmdy &= 15;
		}
		if (this.cmx != this.cmtoX)
		{
			this.cmvx = this.cmtoX - this.cmx << 2;
			this.cmdx += this.cmvx;
			this.cmx += this.cmdx >> 4;
			this.cmdx &= 15;
		}
		this.tF++;
		if (this.tF == 5)
		{
			this.tF = 0;
			if (this.f == 0)
			{
				this.f = 1;
			}
			else
			{
				this.f = 0;
			}
		}
	}

	// Token: 0x0600073A RID: 1850 RVA: 0x00006EAE File Offset: 0x000050AE
	public void doClick(int t)
	{
		this.timeDelay = t;
	}

	// Token: 0x0600073B RID: 1851 RVA: 0x00064E14 File Offset: 0x00063014
	public void update()
	{
		if (this.info != null && this.info.infoWaitToShow != null && this.info.infoWaitToShow.size() == 0 && this.cmy != -40)
		{
			this.info.timeW--;
			if (this.info.timeW <= 0)
			{
				this.cmy = -40;
				this.info.time = 0;
				this.info.infoWaitToShow.removeAllElements();
				this.info.says = null;
				this.info.timeW = 200;
			}
		}
		if (this.Equals(GameScr.info2) && GameScr.gI().popUpYesNo != null)
		{
			return;
		}
		if (!this.isUpdate)
		{
			return;
		}
		this.moveCamera();
		if (this.info == null)
		{
			return;
		}
		if (this.info != null && this.info.info == null)
		{
			return;
		}
		if (!this.isDone)
		{
			if (this.timeDelay > 0)
			{
				this.timeDelay--;
				if (this.timeDelay == 0)
				{
					GameCanvas.panel.setTypeMessage();
					GameCanvas.panel.show();
				}
			}
			if (GameCanvas.gameTick % 3 == 0)
			{
				if (global::Char.myCharz().cdir == 1)
				{
					this.cmtoX = global::Char.myCharz().cx - 20 - GameScr.cmx;
				}
				if (global::Char.myCharz().cdir == -1)
				{
					this.cmtoX = global::Char.myCharz().cx + 20 - GameScr.cmx;
				}
				if (this.cmtoX <= 24)
				{
					this.cmtoX += this.info.sayWidth / 2;
				}
				if (this.cmtoX >= GameCanvas.w - 24)
				{
					this.cmtoX -= this.info.sayWidth / 2;
				}
				this.cmtoY = global::Char.myCharz().cy - 40 - GameScr.cmy;
				if (this.info.says != null && this.cmtoY < (this.info.says.Length + 1) * 12 + 10)
				{
					this.cmtoY = (this.info.says.Length + 1) * 12 + 10;
				}
				if (this.info.info.charInfo != null)
				{
					if (GameCanvas.w - 50 > 155 + this.info.W)
					{
						this.cmtoX = GameCanvas.w - 60 - this.info.W / 2;
						this.cmtoY = this.info.H + 10;
					}
					else
					{
						this.cmtoX = GameCanvas.w - 20 - this.info.W / 2;
						this.cmtoY = 45 + this.info.H;
						if (GameCanvas.w > GameCanvas.h || GameCanvas.w < 220)
						{
							this.cmtoX = GameCanvas.w - 20 - this.info.W / 2;
							this.cmtoY = this.info.H + 10;
						}
					}
				}
			}
			if (this.cmx > global::Char.myCharz().cx - GameScr.cmx)
			{
				this.dir = -1;
			}
			else
			{
				this.dir = 1;
			}
		}
		if (this.info.info != null)
		{
			if (this.info.infoWaitToShow.size() > 1)
			{
				if (this.info.info.timeCount == 0)
				{
					this.info.time++;
					if (this.info.time >= this.info.info.speed)
					{
						this.info.time = 0;
						this.info.infoWaitToShow.removeElementAt(0);
						InfoItem infoItem = (InfoItem)this.info.infoWaitToShow.firstElement();
						this.info.info = infoItem;
						this.info.getInfo();
					}
				}
				else
				{
					this.info.info.curr = mSystem.currentTimeMillis();
					if (this.info.info.curr - this.info.info.last >= 100L)
					{
						this.info.info.last = mSystem.currentTimeMillis();
						this.info.info.timeCount--;
					}
					if (this.info.info.timeCount == 0)
					{
						this.info.infoWaitToShow.removeElementAt(0);
						if (this.info.infoWaitToShow.size() == 0)
						{
							return;
						}
						InfoItem infoItem2 = (InfoItem)this.info.infoWaitToShow.firstElement();
						this.info.info = infoItem2;
						this.info.getInfo();
					}
				}
			}
			else if (this.info.infoWaitToShow.size() == 1)
			{
				if (this.info.info.timeCount == 0)
				{
					this.info.time++;
					if (this.info.time >= this.info.info.speed)
					{
						this.isDone = true;
					}
					if (this.info.time == this.info.info.speed)
					{
						this.cmtoY = -40;
						this.cmtoX = global::Char.myCharz().cx - GameScr.cmx + ((global::Char.myCharz().cdir != 1) ? 20 : -20);
					}
					if (this.info.time >= this.info.info.speed + 20)
					{
						this.info.time = 0;
						this.info.infoWaitToShow.removeAllElements();
						this.info.says = null;
						this.info.timeW = 200;
					}
				}
				else
				{
					this.info.info.curr = mSystem.currentTimeMillis();
					if (this.info.info.curr - this.info.info.last >= 100L)
					{
						this.info.info.last = mSystem.currentTimeMillis();
						this.info.info.timeCount--;
					}
					if (this.info.info.timeCount == 0)
					{
						this.isDone = true;
						this.cmtoY = -40;
						this.cmtoX = global::Char.myCharz().cx - GameScr.cmx + ((global::Char.myCharz().cdir != 1) ? 20 : -20);
						this.info.time = 0;
						this.info.infoWaitToShow.removeAllElements();
						this.info.says = null;
						this.cmdChat = null;
					}
				}
			}
		}
	}

	// Token: 0x0600073C RID: 1852 RVA: 0x00006EB7 File Offset: 0x000050B7
	public void addInfoWithChar(string s, global::Char c, bool isChatServer)
	{
		this.playerID = c.charID;
		this.info.addInfo(s, 3, c, isChatServer);
		this.isDone = false;
	}

	// Token: 0x0600073D RID: 1853 RVA: 0x0006552C File Offset: 0x0006372C
	public void addInfo(string s, int Type)
	{
		s = Res.changeString(s);
		if (this.info.infoWaitToShow.size() > 0 && s.Equals(((InfoItem)this.info.infoWaitToShow.lastElement()).s))
		{
			return;
		}
		if (this.info.infoWaitToShow.size() > 10)
		{
			for (int i = 0; i < 5; i++)
			{
				this.info.infoWaitToShow.removeElementAt(0);
			}
		}
		global::Char cInfo = null;
		this.info.addInfo(s, Type, cInfo, false);
		if (this.info.infoWaitToShow.size() == 1)
		{
			this.cmy = 0;
			this.cmx = global::Char.myCharz().cx - GameScr.cmx + ((global::Char.myCharz().cdir != 1) ? 20 : -20);
		}
		this.isDone = false;
	}

	// Token: 0x04000D6D RID: 3437
	public static InfoMe me;

	// Token: 0x04000D6E RID: 3438
	public int[][] charId = new int[3][];

	// Token: 0x04000D6F RID: 3439
	public Info info = new Info();

	// Token: 0x04000D70 RID: 3440
	public int dir;

	// Token: 0x04000D71 RID: 3441
	public int f;

	// Token: 0x04000D72 RID: 3442
	public int tF;

	// Token: 0x04000D73 RID: 3443
	public int cmtoY;

	// Token: 0x04000D74 RID: 3444
	public int cmy;

	// Token: 0x04000D75 RID: 3445
	public int cmdy;

	// Token: 0x04000D76 RID: 3446
	public int cmvy;

	// Token: 0x04000D77 RID: 3447
	public int cmyLim;

	// Token: 0x04000D78 RID: 3448
	public int cmtoX;

	// Token: 0x04000D79 RID: 3449
	public int cmx;

	// Token: 0x04000D7A RID: 3450
	public int cmdx;

	// Token: 0x04000D7B RID: 3451
	public int cmvx;

	// Token: 0x04000D7C RID: 3452
	public int cmxLim;

	// Token: 0x04000D7D RID: 3453
	public bool isDone;

	// Token: 0x04000D7E RID: 3454
	public bool isUpdate = true;

	// Token: 0x04000D7F RID: 3455
	public int timeDelay;

	// Token: 0x04000D80 RID: 3456
	public int playerID;

	// Token: 0x04000D81 RID: 3457
	public int timeCount;

	// Token: 0x04000D82 RID: 3458
	public Command cmdChat;

	// Token: 0x04000D83 RID: 3459
	public bool isShow;
}
