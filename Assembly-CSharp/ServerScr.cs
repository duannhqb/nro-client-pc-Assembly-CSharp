using System;

// Token: 0x020000BB RID: 187
public class ServerScr : mScreen, IActionListener
{
	// Token: 0x0600092E RID: 2350 RVA: 0x00089A94 File Offset: 0x00087C94
	public ServerScr()
	{
		TileMap.bgID = (int)((byte)(mSystem.currentTimeMillis() % 9L));
		if (TileMap.bgID == 5 || TileMap.bgID == 6)
		{
			TileMap.bgID = 4;
		}
		GameScr.loadCamera(true, -1, -1);
		GameScr.cmx = 100;
		GameScr.cmy = 200;
	}

	// Token: 0x0600092F RID: 2351 RVA: 0x00089AEC File Offset: 0x00087CEC
	public override void switchToMe()
	{
		SoundMn.gI().stopAll();
		base.switchToMe();
		this.vecServer = new Command[ServerListScreen.nameServer.Length];
		for (int i = 0; i < ServerListScreen.nameServer.Length; i++)
		{
			this.vecServer[i] = new Command(ServerListScreen.nameServer[i], this, 100 + i, null);
		}
		this.mainSelect = ServerListScreen.ipSelect;
		this.w2c = 5;
		this.wc = 76;
		this.hc = mScreen.cmdH;
		this.numw = 2;
		if (GameCanvas.w > 3 * (this.wc + this.w2c))
		{
			this.numw = 3;
		}
		this.numh = this.vecServer.Length / this.numw + ((this.vecServer.Length % this.numw != 0) ? 1 : 0);
		for (int j = 0; j < this.vecServer.Length; j++)
		{
			if (this.vecServer[j] != null)
			{
				int num = GameCanvas.hw - this.numw * (this.wc + this.w2c) / 2;
				int x = num + j % this.numw * (this.wc + this.w2c);
				int num2 = GameCanvas.hh - this.numh * (this.hc + this.w2c) / 2;
				int y = num2 + j / this.numw * (this.hc + this.w2c);
				this.vecServer[j].x = x;
				this.vecServer[j].y = y;
			}
		}
		if (!GameCanvas.isTouch)
		{
			this.cmdCheck = new Command(mResources.SELECT, this, 99, null);
			this.center = this.cmdCheck;
		}
	}

	// Token: 0x06000930 RID: 2352 RVA: 0x00089CA8 File Offset: 0x00087EA8
	public override void update()
	{
		GameScr.cmx++;
		if (GameScr.cmx > GameCanvas.w * 3 + 100)
		{
			GameScr.cmx = 100;
		}
		for (int i = 0; i < this.vecServer.Length; i++)
		{
			if (!GameCanvas.isTouch)
			{
				if (i == this.mainSelect)
				{
					if (GameCanvas.gameTick % 10 < 4)
					{
						this.vecServer[i].isFocus = true;
					}
					else
					{
						this.vecServer[i].isFocus = false;
					}
				}
				else
				{
					this.vecServer[i].isFocus = false;
				}
			}
			else if (this.vecServer[i] != null && this.vecServer[i].isPointerPressInside())
			{
				this.vecServer[i].performAction();
			}
		}
	}

	// Token: 0x06000931 RID: 2353 RVA: 0x00089D80 File Offset: 0x00087F80
	public override void paint(mGraphics g)
	{
		GameCanvas.paintBGGameScr(g);
		for (int i = 0; i < this.vecServer.Length; i++)
		{
			if (this.vecServer[i] != null)
			{
				this.vecServer[i].paint(g);
			}
		}
		base.paint(g);
	}

	// Token: 0x06000932 RID: 2354 RVA: 0x00089DD0 File Offset: 0x00087FD0
	public override void updateKey()
	{
		base.updateKey();
		int num = this.mainSelect % this.numw;
		int num2 = this.mainSelect / this.numw;
		if (GameCanvas.keyPressed[4])
		{
			if (num > 0)
			{
				this.mainSelect--;
			}
			GameCanvas.keyPressed[4] = false;
		}
		else if (GameCanvas.keyPressed[6])
		{
			if (num < this.numw - 1)
			{
				this.mainSelect++;
			}
			GameCanvas.keyPressed[6] = false;
		}
		else if (GameCanvas.keyPressed[2])
		{
			if (num2 > 0)
			{
				this.mainSelect -= this.numw;
			}
			GameCanvas.keyPressed[2] = false;
		}
		else if (GameCanvas.keyPressed[8])
		{
			if (num2 < this.numh - 1)
			{
				this.mainSelect += this.numw;
			}
			GameCanvas.keyPressed[8] = false;
		}
		if (this.mainSelect < 0)
		{
			this.mainSelect = 0;
		}
		if (this.mainSelect >= this.vecServer.Length)
		{
			this.mainSelect = this.vecServer.Length - 1;
		}
		if (GameCanvas.keyPressed[5])
		{
			this.vecServer[num].performAction();
			GameCanvas.keyPressed[5] = false;
		}
		GameCanvas.clearKeyPressed();
	}

	// Token: 0x06000933 RID: 2355 RVA: 0x00089F2C File Offset: 0x0008812C
	public void perform(int idAction, object p)
	{
		if (idAction == 99)
		{
			ServerListScreen.ipSelect = this.mainSelect;
			GameCanvas.serverScreen.selectServer();
			GameCanvas.serverScreen.switchToMe();
		}
		else
		{
			ServerListScreen.ipSelect = idAction - 100;
			GameCanvas.serverScreen.selectServer();
			GameCanvas.serverScreen.switchToMe();
		}
	}

	// Token: 0x040010B7 RID: 4279
	private int mainSelect;

	// Token: 0x040010B8 RID: 4280
	private Command[] vecServer;

	// Token: 0x040010B9 RID: 4281
	private Command cmdCheck;

	// Token: 0x040010BA RID: 4282
	public const int icmd = 100;

	// Token: 0x040010BB RID: 4283
	private int wc;

	// Token: 0x040010BC RID: 4284
	private int hc;

	// Token: 0x040010BD RID: 4285
	private int w2c;

	// Token: 0x040010BE RID: 4286
	private int numw;

	// Token: 0x040010BF RID: 4287
	private int numh;
}
