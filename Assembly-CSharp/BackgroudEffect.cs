using System;

// Token: 0x02000036 RID: 54
public class BackgroudEffect
{
	// Token: 0x06000228 RID: 552 RVA: 0x000125A4 File Offset: 0x000107A4
	public BackgroudEffect(int typeS)
	{
		BackgroudEffect.isFog = true;
		BackgroudEffect.initCloud();
		this.typeEff = typeS;
		switch (this.typeEff)
		{
		case 0:
		case 12:
			if (BackgroudEffect.imgHatMua == null)
			{
				BackgroudEffect.imgHatMua = GameCanvas.loadImageRMS("/bg/mua.png");
			}
			if (BackgroudEffect.imgMua1 == null)
			{
				BackgroudEffect.imgMua1 = GameCanvas.loadImageRMS("/bg/mua1.png");
			}
			if (BackgroudEffect.imgMua2 == null)
			{
				BackgroudEffect.imgMua2 = GameCanvas.loadImageRMS("/bg/mua2.png");
			}
			this.sum = Res.random(GameCanvas.w / 3, GameCanvas.w / 2);
			this.x = new int[this.sum];
			this.y = new int[this.sum];
			this.vx = new int[this.sum];
			this.vy = new int[this.sum];
			this.type = new int[this.sum];
			this.t = new int[this.sum];
			this.frame = new int[this.sum];
			this.isRainEffect = new bool[this.sum];
			this.activeEff = new bool[this.sum];
			for (int i = 0; i < this.sum; i++)
			{
				this.y[i] = Res.random(-10, GameCanvas.h + 100) + GameScr.cmy;
				this.x[i] = Res.random(-10, GameCanvas.w + 300) + GameScr.cmx;
				this.t[i] = Res.random(0, 1);
				this.vx[i] = -12;
				this.vy[i] = 12;
				this.type[i] = Res.random(1, 3);
				this.isRainEffect[i] = false;
				if (this.type[i] == 2 && i % 2 == 0)
				{
					this.isRainEffect[i] = true;
				}
				this.activeEff[i] = false;
				this.frame[i] = Res.random(1, 2);
			}
			break;
		case 1:
		case 2:
		case 5:
		case 6:
		case 7:
		case 11:
			if (this.typeEff == 1)
			{
				BackgroudEffect.imgLacay = GameCanvas.loadImageRMS("/bg/lacay.png");
			}
			if (this.typeEff == 2)
			{
				BackgroudEffect.imgLacay = GameCanvas.loadImageRMS("/bg/lacay2.png");
			}
			if (this.typeEff == 5)
			{
				BackgroudEffect.imgLacay = GameCanvas.loadImageRMS("/bg/lacay3.png");
			}
			if (this.typeEff == 6)
			{
				BackgroudEffect.imgLacay = GameCanvas.loadImageRMS("/bg/lacay4.png");
			}
			if (this.typeEff == 7)
			{
				BackgroudEffect.imgLacay = GameCanvas.loadImageRMS("/bg/lacay5.png");
			}
			if (this.typeEff == 11)
			{
				BackgroudEffect.imgLacay = GameCanvas.loadImageRMS("/bg/tuyet.png");
			}
			this.sum = Res.random(15, 25);
			if (this.typeEff == 11)
			{
				this.sum = 100;
			}
			this.x = new int[this.sum];
			this.y = new int[this.sum];
			this.vx = new int[this.sum];
			this.vy = new int[this.sum];
			this.t = new int[this.sum];
			this.frame = new int[this.sum];
			this.activeEff = new bool[this.sum];
			for (int j = 0; j < this.sum; j++)
			{
				this.x[j] = Res.random(-10, TileMap.pxw + 10);
				this.y[j] = Res.random(0, TileMap.pxh);
				this.frame[j] = Res.random(0, 1);
				this.t[j] = Res.random(0, 1);
				this.vx[j] = Res.random(-3, 3);
				this.vy[j] = Res.random(1, 4);
				if (this.typeEff == 11)
				{
					this.frame[j] = Res.random(0, 2);
					this.vx[j] = Res.abs(Res.random(1, 3));
					this.vy[j] = Res.abs(Res.random(1, 3));
				}
			}
			break;
		case 3:
			GameCanvas.isBoltEff = true;
			return;
		case 4:
			this.sum = Res.random(5, 10);
			if (BackgroudEffect.imgSao == null)
			{
				BackgroudEffect.imgSao = GameCanvas.loadImageRMS("/bg/sao.png");
			}
			this.x = new int[this.sum];
			this.y = new int[this.sum];
			this.frame = new int[this.sum];
			this.t = new int[this.sum];
			this.tick = new int[this.sum];
			for (int k = 0; k < this.sum; k++)
			{
				this.x[k] = Res.random(0, GameCanvas.w);
				this.y[k] = Res.random(0, 50);
				if (k % 2 == 0)
				{
					this.tick[k] = 0;
				}
				else if (k % 3 == 0)
				{
					this.tick[k] = 1;
				}
				else if (k % 4 == 0)
				{
					this.tick[k] = 2;
				}
				else
				{
					this.tick[k] = 3;
				}
				this.t[k] = Res.random(0, 10);
			}
			break;
		case 8:
			this.tStart = Res.random(100, 300);
			if (BackgroudEffect.imgShip == null)
			{
				BackgroudEffect.imgShip = GameCanvas.loadImageRMS("/bg/ship.png");
			}
			if (BackgroudEffect.imgFire1 == null)
			{
				BackgroudEffect.imgFire1 = GameCanvas.loadImageRMS("/bg/fire1.png");
			}
			if (BackgroudEffect.imgFire2 == null)
			{
				BackgroudEffect.imgFire2 = GameCanvas.loadImageRMS("/bg/fire2.png");
			}
			this.isFly = false;
			this.reloadShip();
			break;
		case 9:
			if (BackgroudEffect.imgChamTron1 == null)
			{
				BackgroudEffect.imgChamTron1 = GameCanvas.loadImageRMS("/bg/cham-tron1.png");
			}
			if (BackgroudEffect.imgChamTron2 == null)
			{
				BackgroudEffect.imgChamTron2 = GameCanvas.loadImageRMS("/bg/cham-tron2.png");
			}
			this.num = 20;
			this.x = new int[this.num];
			this.y = new int[this.num];
			BackgroudEffect.wP = new int[this.num];
			this.vx = new int[this.num];
			for (int l = 0; l < this.num; l++)
			{
				this.x[l] = Res.abs(Res.random(0, GameCanvas.w));
				this.y[l] = Res.abs(Res.random(10, 80));
				BackgroudEffect.wP[l] = Res.abs(Res.random(1, 3));
				this.vx[l] = BackgroudEffect.wP[l];
			}
			break;
		case 10:
		{
			this.num = 30;
			this.x = new int[this.num];
			this.y = new int[this.num];
			BackgroudEffect.wP = new int[this.num];
			this.vx = new int[this.num];
			int num = 0;
			for (int m = 0; m < this.num; m++)
			{
				this.x[m] = Res.abs(Res.random(0, GameCanvas.w)) + GameScr.cmx;
				num++;
				if (num > this.num / 2)
				{
					this.y[m] = Res.abs(Res.random(20, 60));
					BackgroudEffect.wP[m] = 10;
				}
				else
				{
					this.y[m] = Res.abs(Res.random(0, 20));
					BackgroudEffect.wP[m] = 7;
				}
				this.vx[m] = BackgroudEffect.wP[m] / 2 - 2;
			}
			break;
		}
		case 13:
			if (Res.abs(Res.random(0, 2)) == 0)
			{
				if (Res.abs(Res.random(0, 2)) == 0)
				{
					BackgroudEffect.isPaintFar = true;
				}
				else
				{
					BackgroudEffect.isPaintFar = false;
				}
				BackgroudEffect.nCloud = Res.abs(Res.random(2, 5));
				BackgroudEffect.initCloud();
			}
			break;
		case 14:
			if (Res.abs(Res.random(0, 2)) == 0)
			{
				BackgroudEffect.isFog = true;
				BackgroudEffect.initCloud();
			}
			break;
		}
	}

	// Token: 0x06000229 RID: 553 RVA: 0x00004C35 File Offset: 0x00002E35
	public static void clearImage()
	{
		TileMap.yWater = 0;
	}

	// Token: 0x0600022A RID: 554 RVA: 0x00012E08 File Offset: 0x00011008
	public static bool isHaveRain()
	{
		for (int i = 0; i < BackgroudEffect.vBgEffect.size(); i++)
		{
			BackgroudEffect backgroudEffect = (BackgroudEffect)BackgroudEffect.vBgEffect.elementAt(i);
			if (backgroudEffect.typeEff == 0 || backgroudEffect.typeEff == 12)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600022B RID: 555 RVA: 0x00012E5C File Offset: 0x0001105C
	public static void initCloud()
	{
		if (mSystem.clientType == 1)
		{
			BackgroudEffect.imgCloud1 = null;
			BackgroudEffect.imgFog = null;
			return;
		}
		if (GameCanvas.lowGraphic)
		{
			BackgroudEffect.imgCloud1 = null;
			BackgroudEffect.imgFog = null;
			return;
		}
		if (BackgroudEffect.nCloud > 0)
		{
			if (BackgroudEffect.imgCloud1 == null)
			{
				BackgroudEffect.imgCloud1 = GameCanvas.loadImage("/bg/fog1.png");
				BackgroudEffect.cloudw = BackgroudEffect.imgCloud1.getWidth();
			}
		}
		else
		{
			BackgroudEffect.imgCloud1 = null;
		}
		if (!BackgroudEffect.isFog)
		{
			BackgroudEffect.imgFog = null;
		}
		else
		{
			if (BackgroudEffect.imgFog == null)
			{
				BackgroudEffect.imgFog = GameCanvas.loadImage("/bg/fog0.png");
			}
			BackgroudEffect.fogw = 287;
		}
	}

	// Token: 0x0600022C RID: 556 RVA: 0x00012F10 File Offset: 0x00011110
	public static void updateCloud2()
	{
		if (mSystem.clientType == 1)
		{
			return;
		}
		if (GameCanvas.lowGraphic)
		{
			return;
		}
		if (BackgroudEffect.nCloud > 0)
		{
			int num = (GameCanvas.currentScreen != GameScr.gI()) ? (GameScr.cmx + GameCanvas.w) : TileMap.pxw;
			for (int i = 0; i < BackgroudEffect.nCloud; i++)
			{
				int num2 = i + 1;
				GameCanvas.cloudX[i] -= num2;
				if (GameCanvas.cloudX[i] < -BackgroudEffect.cloudw)
				{
					GameCanvas.cloudX[i] = num + 100;
				}
			}
		}
	}

	// Token: 0x0600022D RID: 557 RVA: 0x00012FAC File Offset: 0x000111AC
	public static void updateFog()
	{
		if (mSystem.clientType == 1)
		{
			return;
		}
		if (GameCanvas.lowGraphic)
		{
			return;
		}
		if (BackgroudEffect.isFog)
		{
			BackgroudEffect.xfog--;
			if (BackgroudEffect.xfog < -BackgroudEffect.fogw)
			{
				BackgroudEffect.xfog = 0;
			}
		}
	}

	// Token: 0x0600022E RID: 558 RVA: 0x00012FFC File Offset: 0x000111FC
	public static void paintCloud2(mGraphics g)
	{
		if (mSystem.clientType == 1)
		{
			return;
		}
		if (GameCanvas.lowGraphic)
		{
			return;
		}
		if (BackgroudEffect.nCloud == 0)
		{
			return;
		}
		if (BackgroudEffect.imgCloud1 != null)
		{
			for (int i = 0; i < BackgroudEffect.nCloud; i++)
			{
				int num = i;
				if (num > 3)
				{
					num = 3;
				}
				if (num == 0)
				{
				}
				g.drawImage(BackgroudEffect.imgCloud1, GameCanvas.cloudX[i], GameCanvas.cloudY[i], 3);
			}
		}
	}

	// Token: 0x0600022F RID: 559 RVA: 0x00013078 File Offset: 0x00011278
	public static void paintFog(mGraphics g)
	{
		if (mSystem.clientType == 1)
		{
			return;
		}
		if (GameCanvas.lowGraphic)
		{
			return;
		}
		if (!BackgroudEffect.isFog)
		{
			return;
		}
		if (BackgroudEffect.imgFog != null)
		{
			for (int i = BackgroudEffect.xfog; i < TileMap.pxw; i += BackgroudEffect.fogw)
			{
				if (i >= GameScr.cmx - BackgroudEffect.fogw)
				{
					g.drawImageFog(BackgroudEffect.imgFog, i, BackgroudEffect.yfog, 0);
				}
			}
		}
	}

	// Token: 0x06000230 RID: 560 RVA: 0x000130F4 File Offset: 0x000112F4
	private void reloadShip()
	{
		int cmx = GameScr.cmx;
		int cmy = GameScr.cmy;
		this.way = Res.random(1, 3);
		this.isFly = false;
		this.speed = Res.random(3, 5);
		if (this.way == 1)
		{
			this.xShip = -50;
			this.yShip = Res.random(cmy, GameCanvas.h - 100 + cmy);
			this.trans = 0;
		}
		else if (this.way == 2)
		{
			this.xShip = TileMap.pxw + 50;
			this.yShip = Res.random(cmy, GameCanvas.h - 100 + cmy);
			this.trans = 2;
		}
		else if (this.way == 3)
		{
			this.xShip = Res.random(50 + cmx, GameCanvas.w - 50 + cmx);
			this.yShip = -50;
			this.trans = ((Res.random(0, 2) != 0) ? 2 : 0);
		}
		else if (this.way == 4)
		{
			this.xShip = Res.random(50 + cmx, GameCanvas.w - 50 + cmx);
			this.yShip = TileMap.pxh + 50;
			this.trans = ((Res.random(0, 2) != 0) ? 2 : 0);
		}
	}

	// Token: 0x06000231 RID: 561 RVA: 0x0001323C File Offset: 0x0001143C
	public void paintWater(mGraphics g)
	{
		if (this.typeEff == 10)
		{
			g.setColor(this.colorWater);
			for (int i = 0; i < this.num; i++)
			{
				g.drawImage((i >= this.num / 2) ? BackgroudEffect.water1 : BackgroudEffect.water2, this.x[i], this.y[i] + this.yWater, 0);
			}
		}
	}

	// Token: 0x06000232 RID: 562 RVA: 0x000132B4 File Offset: 0x000114B4
	public void paintFar(mGraphics g)
	{
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		if (this.typeEff == 4)
		{
			for (int i = 0; i < this.sum; i++)
			{
				g.drawRegion(BackgroudEffect.imgSao, 0, 16 * this.frame[i], 16, 16, 0, this.x[i], this.y[i], 0);
			}
		}
		if (this.typeEff == 9)
		{
			g.setColor(16777215);
			for (int j = 0; j < this.num; j++)
			{
				g.drawImage((BackgroudEffect.wP[j] != 1) ? BackgroudEffect.imgChamTron2 : BackgroudEffect.imgChamTron1, this.x[j], this.y[j], 3);
			}
		}
	}

	// Token: 0x06000233 RID: 563 RVA: 0x00013388 File Offset: 0x00011588
	public void update()
	{
		switch (this.typeEff)
		{
		case 0:
		case 12:
			for (int i = 0; i < this.sum; i++)
			{
				if (i % 3 != 0 && this.typeEff != 12 && TileMap.tileTypeAt(this.x[i], this.y[i] - GameCanvas.transY, 2))
				{
					this.activeEff[i] = true;
				}
				if (i % 3 == 0 && this.y[i] > GameCanvas.h + GameScr.cmy)
				{
					this.x[i] = Res.random(-10, GameCanvas.w + 300) + GameScr.cmx;
					this.y[i] = Res.random(-100, 0) + GameScr.cmy;
				}
				if (!this.activeEff[i])
				{
					this.y[i] += this.vy[i];
					this.x[i] += this.vx[i];
				}
				if (this.activeEff[i])
				{
					this.t[i]++;
					if (this.t[i] > 2)
					{
						this.frame[i]++;
						this.t[i] = 0;
						if (this.frame[i] > 1)
						{
							this.frame[i] = 0;
							this.activeEff[i] = false;
							this.x[i] = Res.random(-10, GameCanvas.w + 300) + GameScr.cmx;
							this.y[i] = Res.random(-100, 0) + GameScr.cmy;
						}
					}
				}
			}
			break;
		case 1:
		case 2:
		case 5:
		case 6:
		case 7:
		case 11:
			for (int j = 0; j < this.sum; j++)
			{
				if (j % 3 != 0 && TileMap.tileTypeAt(this.x[j], this.y[j] + ((TileMap.tileID != 15) ? 0 : 10), 2))
				{
					this.activeEff[j] = true;
				}
				if (j % 3 == 0 && this.y[j] > TileMap.pxh)
				{
					this.x[j] = Res.random(-10, TileMap.pxw + 50);
					this.y[j] = Res.random(-50, 0);
				}
				if (!this.activeEff[j])
				{
					for (int k = 0; k < Teleport.vTeleport.size(); k++)
					{
						Teleport teleport = (Teleport)Teleport.vTeleport.elementAt(k);
						if (teleport != null && teleport.paintFire && this.x[j] < teleport.x + 80 && this.x[j] > teleport.x - 80 && this.y[j] < teleport.y + 80 && this.y[j] > teleport.y - 80)
						{
							this.x[j] += ((this.x[j] >= teleport.x) ? 10 : -10);
						}
					}
					this.y[j] += this.vy[j];
					this.x[j] += this.vx[j];
					this.t[j]++;
					int num = (this.typeEff != 11) ? 4 : 3;
					if (this.t[j] > ((this.typeEff == 2) ? 4 : 2))
					{
						if (this.typeEff != 11)
						{
							this.frame[j]++;
						}
						this.t[j] = 0;
						if (this.frame[j] > num - 1)
						{
							this.frame[j] = 0;
						}
					}
				}
				else
				{
					this.t[j]++;
					if (this.t[j] == 100)
					{
						this.t[j] = 0;
						this.x[j] = Res.random(-10, TileMap.pxw + 50);
						this.y[j] = Res.random(-50, 0);
						this.activeEff[j] = false;
					}
				}
			}
			break;
		case 4:
			for (int l = 0; l < this.sum; l++)
			{
				this.t[l]++;
				if (this.t[l] > 10)
				{
					this.tick[l]++;
					this.t[l] = 0;
					if (this.tick[l] > 5)
					{
						this.tick[l] = 0;
					}
					this.frame[l] = this.dem[this.tick[l]];
				}
			}
			break;
		case 8:
			this.tFire++;
			if (this.tFire == 3)
			{
				this.tFire = 0;
				this.frameFire++;
				if (this.frameFire > 1)
				{
					this.frameFire = 0;
				}
			}
			if (GameCanvas.gameTick % this.tStart == 0)
			{
				this.isFly = true;
			}
			if (this.isFly)
			{
				if (this.way == 1)
				{
					this.xShip += this.speed;
					if (this.xShip > TileMap.pxw + 50)
					{
						this.reloadShip();
					}
				}
				else if (this.way == 2)
				{
					this.xShip -= this.speed;
					if (this.xShip < -50)
					{
						this.reloadShip();
					}
				}
				else if (this.way == 3)
				{
					this.yShip += this.speed;
					if (this.yShip > TileMap.pxh + 50)
					{
						this.reloadShip();
					}
				}
				else if (this.way == 4)
				{
					this.yShip -= this.speed;
					if (this.yShip < -50)
					{
						this.reloadShip();
					}
				}
			}
			break;
		case 9:
			for (int m = 0; m < this.num; m++)
			{
				this.x[m] -= this.vx[m];
				if (this.x[m] < -this.vx[m])
				{
					BackgroudEffect.wP[m] = Res.abs(Res.random(1, 3));
					this.vx[m] = BackgroudEffect.wP[m];
					this.x[m] = GameCanvas.w + this.vx[m];
				}
			}
			break;
		case 10:
			for (int n = 0; n < this.num; n++)
			{
				this.x[n] -= this.vx[n];
				if (this.x[n] < -this.vx[n] + GameScr.cmx)
				{
					this.x[n] = GameCanvas.w + this.vx[n] + GameScr.cmx;
				}
			}
			break;
		case 13:
			BackgroudEffect.updateCloud2();
			break;
		case 14:
			BackgroudEffect.updateFog();
			break;
		}
	}

	// Token: 0x06000234 RID: 564 RVA: 0x00013B08 File Offset: 0x00011D08
	public void paintFront(mGraphics g)
	{
		switch (this.typeEff)
		{
		case 0:
		case 12:
		{
			int cmx = GameScr.cmx;
			int cmy = GameScr.cmy;
			for (int i = 0; i < this.sum; i++)
			{
				if (this.type[i] == 2)
				{
					if (this.x[i] >= GameScr.cmx && this.x[i] <= GameCanvas.w + GameScr.cmx && this.y[i] >= GameScr.cmy && this.y[i] <= GameCanvas.h + GameScr.cmy)
					{
						if (this.activeEff[i])
						{
							g.drawRegion(BackgroudEffect.imgHatMua, 0, 10 * this.frame[i], 13, 10, 0, this.x[i], this.y[i] - 10, 0);
						}
						else
						{
							g.drawImage(BackgroudEffect.imgMua1, this.x[i], this.y[i], 0);
						}
					}
				}
			}
			break;
		}
		case 1:
		case 2:
		case 5:
		case 6:
		case 7:
		case 11:
			this.paintLacay1(g, BackgroudEffect.imgLacay);
			break;
		case 13:
			if (!BackgroudEffect.isPaintFar)
			{
				BackgroudEffect.paintCloud2(g);
			}
			break;
		}
	}

	// Token: 0x06000235 RID: 565 RVA: 0x00013C7C File Offset: 0x00011E7C
	public void paintLacay1(mGraphics g, Image img)
	{
		int num = (this.typeEff != 11) ? 4 : 3;
		for (int i = 0; i < this.sum; i++)
		{
			if (i % 3 == 0)
			{
				if (this.x[i] >= GameScr.cmx && this.x[i] <= GameCanvas.w + GameScr.cmx && this.y[i] >= GameScr.cmy && this.y[i] <= GameCanvas.h + GameScr.cmy)
				{
					g.drawRegion(img, 0, mGraphics.getImageHeight(img) / num * this.frame[i], mGraphics.getImageWidth(img), mGraphics.getImageHeight(img) / num, 0, this.x[i], this.y[i], 0);
				}
			}
		}
	}

	// Token: 0x06000236 RID: 566 RVA: 0x00013D50 File Offset: 0x00011F50
	public void paintLacay2(mGraphics g, Image img)
	{
		int num = (this.typeEff != 11) ? 4 : 3;
		for (int i = 0; i < this.sum; i++)
		{
			if (i % 3 != 0)
			{
				if (this.x[i] >= GameScr.cmx && this.x[i] <= GameCanvas.w + GameScr.cmx && this.y[i] >= GameScr.cmy && this.y[i] <= GameCanvas.h + GameScr.cmy)
				{
					g.drawRegion(img, 0, mGraphics.getImageHeight(img) / num * this.frame[i], mGraphics.getImageWidth(img), mGraphics.getImageHeight(img) / num, 0, this.x[i], this.y[i], 0);
				}
			}
		}
	}

	// Token: 0x06000237 RID: 567 RVA: 0x00013E24 File Offset: 0x00012024
	public void paintBehindTile(mGraphics g)
	{
		int num = this.typeEff;
		if (num != 8)
		{
			if (num == 13)
			{
				if (BackgroudEffect.isPaintFar)
				{
					BackgroudEffect.paintCloud2(g);
				}
			}
		}
		else
		{
			g.drawRegion(BackgroudEffect.imgShip, 0, 0, BackgroudEffect.imgShip.getWidth(), BackgroudEffect.imgShip.getHeight(), this.trans, this.xShip, this.yShip, 3);
			if (this.way == 1 || this.way == 2)
			{
				int num2 = (this.trans != 0) ? 25 : -25;
				g.drawRegion(BackgroudEffect.imgFire1, 0, this.frameFire * 8, 20, 8, this.trans, this.xShip + num2, this.yShip + 5, 3);
			}
			else
			{
				int num3 = (this.trans != 0) ? -11 : 11;
				g.drawRegion(BackgroudEffect.imgFire2, 0, this.frameFire * 18, 8, 18, this.trans, this.xShip + num3, this.yShip + 22, 3);
			}
		}
	}

	// Token: 0x06000238 RID: 568 RVA: 0x00013F44 File Offset: 0x00012144
	public void paintBack(mGraphics g)
	{
		switch (this.typeEff)
		{
		case 0:
		{
			int cmx = GameScr.cmx;
			int cmy = GameScr.cmy;
			g.setColor(10742731);
			for (int i = 0; i < this.sum; i++)
			{
				if (this.type[i] != 2)
				{
					if (this.x[i] >= GameScr.cmx && this.x[i] <= GameCanvas.w + GameScr.cmx && this.y[i] >= GameScr.cmy && this.y[i] <= GameCanvas.h + GameScr.cmy)
					{
						g.drawImage(BackgroudEffect.imgMua2, this.x[i], this.y[i], 0);
					}
				}
			}
			break;
		}
		case 1:
		case 2:
		case 5:
		case 6:
		case 7:
		case 11:
			this.paintLacay2(g, BackgroudEffect.imgLacay);
			break;
		case 3:
			return;
		}
	}

	// Token: 0x06000239 RID: 569 RVA: 0x00014060 File Offset: 0x00012260
	public static void addEffect(int id)
	{
		if (GameCanvas.lowGraphic)
		{
			return;
		}
		BackgroudEffect o = new BackgroudEffect(id);
		BackgroudEffect.vBgEffect.addElement(o);
	}

	// Token: 0x0600023A RID: 570 RVA: 0x0001408C File Offset: 0x0001228C
	public static void addWater(int color, int yWater)
	{
		BackgroudEffect backgroudEffect = new BackgroudEffect(10);
		backgroudEffect.colorWater = color;
		backgroudEffect.yWater = yWater;
		BackgroudEffect.vBgEffect.addElement(backgroudEffect);
	}

	// Token: 0x0600023B RID: 571 RVA: 0x000140BC File Offset: 0x000122BC
	public static void paintWaterAll(mGraphics g)
	{
		for (int i = 0; i < BackgroudEffect.vBgEffect.size(); i++)
		{
			((BackgroudEffect)BackgroudEffect.vBgEffect.elementAt(i)).paintWater(g);
		}
	}

	// Token: 0x0600023C RID: 572 RVA: 0x000140FC File Offset: 0x000122FC
	public static void paintBehindTileAll(mGraphics g)
	{
		for (int i = 0; i < BackgroudEffect.vBgEffect.size(); i++)
		{
			((BackgroudEffect)BackgroudEffect.vBgEffect.elementAt(i)).paintBehindTile(g);
		}
	}

	// Token: 0x0600023D RID: 573 RVA: 0x0001413C File Offset: 0x0001233C
	public static void paintFrontAll(mGraphics g)
	{
		for (int i = 0; i < BackgroudEffect.vBgEffect.size(); i++)
		{
			((BackgroudEffect)BackgroudEffect.vBgEffect.elementAt(i)).paintFront(g);
		}
	}

	// Token: 0x0600023E RID: 574 RVA: 0x0001417C File Offset: 0x0001237C
	public static void paintFarAll(mGraphics g)
	{
		for (int i = 0; i < BackgroudEffect.vBgEffect.size(); i++)
		{
			((BackgroudEffect)BackgroudEffect.vBgEffect.elementAt(i)).paintFar(g);
		}
	}

	// Token: 0x0600023F RID: 575 RVA: 0x000141BC File Offset: 0x000123BC
	public static void paintBackAll(mGraphics g)
	{
		for (int i = 0; i < BackgroudEffect.vBgEffect.size(); i++)
		{
			((BackgroudEffect)BackgroudEffect.vBgEffect.elementAt(i)).paintBack(g);
		}
	}

	// Token: 0x06000240 RID: 576 RVA: 0x000141FC File Offset: 0x000123FC
	public static void updateEff()
	{
		for (int i = 0; i < BackgroudEffect.vBgEffect.size(); i++)
		{
			((BackgroudEffect)BackgroudEffect.vBgEffect.elementAt(i)).update();
		}
	}

	// Token: 0x04000217 RID: 535
	public static MyVector vBgEffect = new MyVector();

	// Token: 0x04000218 RID: 536
	private int[] x;

	// Token: 0x04000219 RID: 537
	private int[] y;

	// Token: 0x0400021A RID: 538
	private int[] vx;

	// Token: 0x0400021B RID: 539
	private int[] vy;

	// Token: 0x0400021C RID: 540
	public static int[] wP;

	// Token: 0x0400021D RID: 541
	private int num;

	// Token: 0x0400021E RID: 542
	private int xShip;

	// Token: 0x0400021F RID: 543
	private int yShip;

	// Token: 0x04000220 RID: 544
	private int way;

	// Token: 0x04000221 RID: 545
	private int trans;

	// Token: 0x04000222 RID: 546
	private int frameFire;

	// Token: 0x04000223 RID: 547
	private int tFire;

	// Token: 0x04000224 RID: 548
	private int tStart;

	// Token: 0x04000225 RID: 549
	private int speed;

	// Token: 0x04000226 RID: 550
	private bool isFly;

	// Token: 0x04000227 RID: 551
	public static Image imgSnow;

	// Token: 0x04000228 RID: 552
	public static Image imgHatMua;

	// Token: 0x04000229 RID: 553
	public static Image imgMua1;

	// Token: 0x0400022A RID: 554
	public static Image imgMua2;

	// Token: 0x0400022B RID: 555
	public static Image imgSao;

	// Token: 0x0400022C RID: 556
	private static Image imgLacay;

	// Token: 0x0400022D RID: 557
	private static Image imgShip;

	// Token: 0x0400022E RID: 558
	private static Image imgFire1;

	// Token: 0x0400022F RID: 559
	private static Image imgFire2;

	// Token: 0x04000230 RID: 560
	private int[] type;

	// Token: 0x04000231 RID: 561
	private int sum;

	// Token: 0x04000232 RID: 562
	public int typeEff;

	// Token: 0x04000233 RID: 563
	public int xx;

	// Token: 0x04000234 RID: 564
	public int waterY;

	// Token: 0x04000235 RID: 565
	private bool[] isRainEffect;

	// Token: 0x04000236 RID: 566
	private int[] frame;

	// Token: 0x04000237 RID: 567
	private int[] t;

	// Token: 0x04000238 RID: 568
	private bool[] activeEff;

	// Token: 0x04000239 RID: 569
	private int yWater;

	// Token: 0x0400023A RID: 570
	private int colorWater;

	// Token: 0x0400023B RID: 571
	public const int TYPE_MUA = 0;

	// Token: 0x0400023C RID: 572
	public const int TYPE_LATRAIDAT_1 = 1;

	// Token: 0x0400023D RID: 573
	public const int TYPE_LATRAIDAT_2 = 2;

	// Token: 0x0400023E RID: 574
	public const int TYPE_SAMSET = 3;

	// Token: 0x0400023F RID: 575
	public const int TYPE_SAO = 4;

	// Token: 0x04000240 RID: 576
	public const int TYPE_LANAMEK_1 = 5;

	// Token: 0x04000241 RID: 577
	public const int TYPE_LASAYAI_1 = 6;

	// Token: 0x04000242 RID: 578
	public const int TYPE_LANAMEK_2 = 7;

	// Token: 0x04000243 RID: 579
	public const int TYPE_SHIP_TRAIDAT = 8;

	// Token: 0x04000244 RID: 580
	public const int TYPE_HANHTINH = 9;

	// Token: 0x04000245 RID: 581
	public const int TYPE_WATER = 10;

	// Token: 0x04000246 RID: 582
	public const int TYPE_SNOW = 11;

	// Token: 0x04000247 RID: 583
	public const int TYPE_MUA_FRONT = 12;

	// Token: 0x04000248 RID: 584
	public const int TYPE_CLOUD = 13;

	// Token: 0x04000249 RID: 585
	public const int TYPE_FOG = 14;

	// Token: 0x0400024A RID: 586
	public static Image water1 = GameCanvas.loadImage("/mainImage/myTexture2dwater1.png");

	// Token: 0x0400024B RID: 587
	public static Image water2 = GameCanvas.loadImage("/mainImage/myTexture2dwater2.png");

	// Token: 0x0400024C RID: 588
	public static Image imgChamTron1;

	// Token: 0x0400024D RID: 589
	public static Image imgChamTron2;

	// Token: 0x0400024E RID: 590
	public static bool isFog;

	// Token: 0x0400024F RID: 591
	public static bool isPaintFar;

	// Token: 0x04000250 RID: 592
	public static int nCloud;

	// Token: 0x04000251 RID: 593
	public static Image imgCloud1;

	// Token: 0x04000252 RID: 594
	public static Image imgFog;

	// Token: 0x04000253 RID: 595
	public static int cloudw;

	// Token: 0x04000254 RID: 596
	public static int xfog;

	// Token: 0x04000255 RID: 597
	public static int yfog;

	// Token: 0x04000256 RID: 598
	public static int fogw;

	// Token: 0x04000257 RID: 599
	private int[] dem = new int[]
	{
		0,
		1,
		2,
		1,
		0,
		0
	};

	// Token: 0x04000258 RID: 600
	private int[] tick;
}
