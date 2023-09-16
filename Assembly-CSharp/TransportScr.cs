using System;

// Token: 0x020000C1 RID: 193
public class TransportScr : mScreen, IActionListener
{
	// Token: 0x0600096D RID: 2413 RVA: 0x0008C018 File Offset: 0x0008A218
	public TransportScr()
	{
		this.posX = new int[this.n];
		this.posY = new int[this.n];
		for (int i = 0; i < this.n; i++)
		{
			this.posX[i] = Res.random(0, GameCanvas.w);
			this.posY[i] = i * (GameCanvas.h / this.n);
		}
		this.posX2 = new int[this.n];
		this.posY2 = new int[this.n];
		for (int j = 0; j < this.n; j++)
		{
			this.posX2[j] = Res.random(0, GameCanvas.w);
			this.posY2[j] = j * (GameCanvas.h / this.n);
		}
	}

	// Token: 0x0600096E RID: 2414 RVA: 0x00007C4D File Offset: 0x00005E4D
	public static TransportScr gI()
	{
		if (TransportScr.instance == null)
		{
			TransportScr.instance = new TransportScr();
		}
		return TransportScr.instance;
	}

	// Token: 0x0600096F RID: 2415 RVA: 0x0008C100 File Offset: 0x0008A300
	public override void switchToMe()
	{
		if (TransportScr.ship == null)
		{
			TransportScr.ship = GameCanvas.loadImage("/mainImage/myTexture2dfutherShip.png");
		}
		if (TransportScr.taungam == null)
		{
			TransportScr.taungam = GameCanvas.loadImage("/mainImage/taungam.png");
		}
		this.isSpeed = false;
		this.transNow = false;
		if (global::Char.myCharz().checkLuong() > 0 && (int)this.type == 0)
		{
			this.center = new Command(mResources.faster, this, 1, null);
		}
		else
		{
			this.center = null;
		}
		this.currSpeed = 0;
		base.switchToMe();
	}

	// Token: 0x06000970 RID: 2416 RVA: 0x0008C198 File Offset: 0x0008A398
	public override void paint(mGraphics g)
	{
		g.setColor(((int)this.type != 0) ? 3056895 : 0);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
		for (int i = 0; i < this.n; i++)
		{
			g.setColor(((int)this.type != 0) ? 11140863 : 14802654);
			g.fillRect(this.posX[i], this.posY[i], 10, 2);
		}
		if ((int)this.type == 0)
		{
			g.drawRegion(TransportScr.ship, 0, 0, 72, 95, 7, this.cmx + this.currSpeed, GameCanvas.h / 2, 3);
		}
		if ((int)this.type == 1)
		{
			g.drawRegion(TransportScr.taungam, 0, 0, 144, 79, 2, this.cmx + this.currSpeed, GameCanvas.h / 2, 3);
		}
		for (int j = 0; j < this.n; j++)
		{
			g.setColor(((int)this.type != 0) ? 7536127 : 14935011);
			g.fillRect(this.posX2[j], this.posY2[j], 18, 3);
		}
		base.paint(g);
	}

	// Token: 0x06000971 RID: 2417 RVA: 0x0008C2E8 File Offset: 0x0008A4E8
	public override void update()
	{
		if ((int)this.type == 0)
		{
			if (!this.isSpeed)
			{
				this.currSpeed = GameCanvas.w / 2 * (int)this.time / (int)this.maxTime;
			}
		}
		else
		{
			this.currSpeed += 2;
		}
		Controller.isStopReadMessage = false;
		this.cmx = (((GameCanvas.w / 2 + this.cmx) / 2 + this.cmx) / 2 + this.cmx) / 2;
		if ((int)this.type == 1)
		{
			this.cmx = 0;
		}
		for (int i = 0; i < this.n; i++)
		{
			this.posX[i] -= this.speed / 2;
			if (this.posX[i] < -20)
			{
				this.posX[i] = GameCanvas.w;
			}
		}
		for (int j = 0; j < this.n; j++)
		{
			this.posX2[j] -= this.speed;
			if (this.posX2[j] < -20)
			{
				this.posX2[j] = GameCanvas.w;
			}
		}
		if (GameCanvas.gameTick % 3 == 0)
		{
			this.speed += ((!this.isSpeed) ? 1 : 2);
		}
		if (this.speed > ((!this.isSpeed) ? 25 : 80))
		{
			this.speed = ((!this.isSpeed) ? 25 : 80);
		}
		this.curr = mSystem.currentTimeMillis();
		if (this.curr - this.last >= 1000L)
		{
			this.time += 1;
			this.last = this.curr;
		}
		if (this.isSpeed)
		{
			this.currSpeed += 3;
		}
		if (this.currSpeed >= GameCanvas.w / 2 + 30 && !this.transNow)
		{
			this.transNow = true;
			Service.gI().transportNow();
		}
		base.update();
	}

	// Token: 0x06000972 RID: 2418 RVA: 0x00007C68 File Offset: 0x00005E68
	public override void updateKey()
	{
		base.updateKey();
	}

	// Token: 0x06000973 RID: 2419 RVA: 0x0008C504 File Offset: 0x0008A704
	public void perform(int idAction, object p)
	{
		if (idAction == 1)
		{
			GameCanvas.startYesNoDlg(mResources.fasterQuestion, new Command(mResources.YES, this, 2, null), new Command(mResources.NO, this, 3, null));
		}
		if (idAction == 2 && global::Char.myCharz().checkLuong() > 0)
		{
			this.isSpeed = true;
			GameCanvas.endDlg();
			this.center = null;
		}
		if (idAction == 3)
		{
			GameCanvas.endDlg();
		}
	}

	// Token: 0x0400116F RID: 4463
	public static TransportScr instance;

	// Token: 0x04001170 RID: 4464
	public static Image ship;

	// Token: 0x04001171 RID: 4465
	public static Image taungam;

	// Token: 0x04001172 RID: 4466
	public sbyte type;

	// Token: 0x04001173 RID: 4467
	public int speed = 5;

	// Token: 0x04001174 RID: 4468
	public int[] posX;

	// Token: 0x04001175 RID: 4469
	public int[] posY;

	// Token: 0x04001176 RID: 4470
	public int[] posX2;

	// Token: 0x04001177 RID: 4471
	public int[] posY2;

	// Token: 0x04001178 RID: 4472
	private int cmx;

	// Token: 0x04001179 RID: 4473
	private int n = 20;

	// Token: 0x0400117A RID: 4474
	public short time;

	// Token: 0x0400117B RID: 4475
	public short maxTime;

	// Token: 0x0400117C RID: 4476
	public long last;

	// Token: 0x0400117D RID: 4477
	public long curr;

	// Token: 0x0400117E RID: 4478
	private bool isSpeed;

	// Token: 0x0400117F RID: 4479
	private bool transNow;

	// Token: 0x04001180 RID: 4480
	private int currSpeed;
}
