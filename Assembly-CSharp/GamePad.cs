using System;

// Token: 0x020000C4 RID: 196
public class GamePad
{
	// Token: 0x060009CE RID: 2510 RVA: 0x00091BA8 File Offset: 0x0008FDA8
	public GamePad()
	{
		this.R = 28;
		if (GameCanvas.w < 300)
		{
			this.isSmallGamePad = true;
			this.isMediumGamePad = false;
			this.isLargeGamePad = false;
		}
		if (GameCanvas.w >= 300 && GameCanvas.w <= 380)
		{
			this.isSmallGamePad = false;
			this.isMediumGamePad = true;
			this.isLargeGamePad = false;
		}
		if (GameCanvas.w > 380)
		{
			this.isSmallGamePad = false;
			this.isMediumGamePad = false;
			this.isLargeGamePad = true;
		}
		if (!this.isLargeGamePad)
		{
			this.xZone = 0;
			this.wZone = GameCanvas.hw;
			this.yZone = GameCanvas.hh >> 1;
			this.hZone = GameCanvas.h - 80;
		}
		else
		{
			this.xZone = 0;
			this.wZone = GameCanvas.hw / 4 * 3 - 20;
			this.yZone = GameCanvas.hh >> 1;
			this.hZone = GameCanvas.h;
		}
	}

	// Token: 0x060009CF RID: 2511 RVA: 0x00091CAC File Offset: 0x0008FEAC
	public void update()
	{
		if (GameScr.isAnalog == 0)
		{
			return;
		}
		if (GameCanvas.isPointerDown && !GameCanvas.isPointerJustRelease)
		{
			this.xTemp = GameCanvas.pxFirst;
			this.yTemp = GameCanvas.pyFirst;
			if (this.xTemp >= this.xZone && this.xTemp <= this.wZone && this.yTemp >= this.yZone && this.yTemp <= this.hZone)
			{
				if (!this.isGamePad)
				{
					this.xC = (this.xM = this.xTemp);
					this.yC = (this.yM = this.yTemp);
				}
				this.isGamePad = true;
				this.deltaX = GameCanvas.px - this.xC;
				this.deltaY = GameCanvas.py - this.yC;
				this.delta = global::Math.pow(this.deltaX, 2) + global::Math.pow(this.deltaY, 2);
				this.d = Res.sqrt(this.delta);
				if (global::Math.abs(this.deltaX) > 4 || global::Math.abs(this.deltaY) > 4)
				{
					this.angle = Res.angle(this.deltaX, this.deltaY);
					if (!GameCanvas.isPointerHoldIn(this.xC - this.R, this.yC - this.R, 2 * this.R, 2 * this.R))
					{
						if (this.d != 0)
						{
							this.yM = this.deltaY * this.R / this.d;
							this.xM = this.deltaX * this.R / this.d;
							this.xM += this.xC;
							this.yM += this.yC;
							if (!Res.inRect(this.xC - this.R, this.yC - this.R, 2 * this.R, 2 * this.R, this.xM, this.yM))
							{
								this.xM = this.xMLast;
								this.yM = this.yMLast;
							}
							else
							{
								this.xMLast = this.xM;
								this.yMLast = this.yM;
							}
						}
						else
						{
							this.xM = this.xMLast;
							this.yM = this.yMLast;
						}
					}
					else
					{
						this.xM = GameCanvas.px;
						this.yM = GameCanvas.py;
					}
					this.resetHold();
					if (this.checkPointerMove(2))
					{
						if ((this.angle <= 360 && this.angle >= 340) || (this.angle >= 0 && this.angle <= 20))
						{
							GameCanvas.keyHold[(!Main.isPC) ? 6 : 24] = true;
							GameCanvas.keyPressed[(!Main.isPC) ? 6 : 24] = true;
						}
						else if (this.angle > 40 && this.angle < 70)
						{
							GameCanvas.keyHold[(!Main.isPC) ? 6 : 24] = true;
							GameCanvas.keyPressed[(!Main.isPC) ? 6 : 24] = true;
						}
						else if (this.angle >= 70 && this.angle <= 110)
						{
							GameCanvas.keyHold[(!Main.isPC) ? 8 : 22] = true;
							GameCanvas.keyPressed[(!Main.isPC) ? 8 : 22] = true;
						}
						else if (this.angle > 110 && this.angle < 120)
						{
							GameCanvas.keyHold[(!Main.isPC) ? 4 : 23] = true;
							GameCanvas.keyPressed[(!Main.isPC) ? 4 : 23] = true;
						}
						else if (this.angle >= 120 && this.angle <= 200)
						{
							GameCanvas.keyHold[(!Main.isPC) ? 4 : 23] = true;
							GameCanvas.keyPressed[(!Main.isPC) ? 4 : 23] = true;
						}
						else if (this.angle > 200 && this.angle < 250)
						{
							GameCanvas.keyHold[(!Main.isPC) ? 2 : 21] = true;
							GameCanvas.keyPressed[(!Main.isPC) ? 2 : 21] = true;
							GameCanvas.keyHold[(!Main.isPC) ? 4 : 23] = true;
							GameCanvas.keyPressed[(!Main.isPC) ? 4 : 23] = true;
						}
						else if (this.angle >= 250 && this.angle <= 290)
						{
							GameCanvas.keyHold[(!Main.isPC) ? 2 : 21] = true;
							GameCanvas.keyPressed[(!Main.isPC) ? 2 : 21] = true;
						}
						else if (this.angle > 290 && this.angle < 340)
						{
							GameCanvas.keyHold[(!Main.isPC) ? 2 : 21] = true;
							GameCanvas.keyPressed[(!Main.isPC) ? 2 : 21] = true;
							GameCanvas.keyHold[(!Main.isPC) ? 6 : 24] = true;
							GameCanvas.keyPressed[(!Main.isPC) ? 6 : 24] = true;
						}
					}
					else
					{
						this.resetHold();
					}
				}
			}
		}
		else
		{
			this.xM = (this.xC = 45);
			if (!this.isLargeGamePad)
			{
				this.yM = (this.yC = GameCanvas.h - 90);
			}
			else
			{
				this.yM = (this.yC = GameCanvas.h - 45);
			}
			this.isGamePad = false;
			this.resetHold();
		}
	}

	// Token: 0x060009D0 RID: 2512 RVA: 0x000922DC File Offset: 0x000904DC
	private bool checkPointerMove(int distance)
	{
		if (GameScr.isAnalog == 0)
		{
			return false;
		}
		if (global::Char.myCharz().statusMe == 3)
		{
			return true;
		}
		try
		{
			for (int i = 2; i > 0; i--)
			{
				int i2 = GameCanvas.arrPos[i].x - GameCanvas.arrPos[i - 1].x;
				int i3 = GameCanvas.arrPos[i].y - GameCanvas.arrPos[i - 1].y;
				if (Res.abs(i2) > distance && Res.abs(i3) > distance)
				{
					return false;
				}
			}
		}
		catch (Exception ex)
		{
		}
		return true;
	}

	// Token: 0x060009D1 RID: 2513 RVA: 0x00007FED File Offset: 0x000061ED
	private void resetHold()
	{
		GameCanvas.clearKeyHold();
	}

	// Token: 0x060009D2 RID: 2514 RVA: 0x00092390 File Offset: 0x00090590
	public void paint(mGraphics g)
	{
		if (GameScr.isAnalog == 0)
		{
			return;
		}
		g.drawImage(GameScr.imgAnalog1, this.xC, this.yC, mGraphics.HCENTER | mGraphics.VCENTER);
		g.drawImage(GameScr.imgAnalog2, this.xM, this.yM, mGraphics.HCENTER | mGraphics.VCENTER);
	}

	// Token: 0x060009D3 RID: 2515 RVA: 0x00007FF4 File Offset: 0x000061F4
	public bool disableCheckDrag()
	{
		return GameScr.isAnalog != 0 && this.isGamePad;
	}

	// Token: 0x060009D4 RID: 2516 RVA: 0x000923EC File Offset: 0x000905EC
	public bool disableClickMove()
	{
		return GameScr.isAnalog != 0 && ((GameCanvas.px >= this.xZone && GameCanvas.px <= this.wZone && GameCanvas.py >= this.yZone && GameCanvas.py <= this.hZone) || GameCanvas.px >= GameCanvas.w - 50);
	}

	// Token: 0x04001233 RID: 4659
	private int xC;

	// Token: 0x04001234 RID: 4660
	private int yC;

	// Token: 0x04001235 RID: 4661
	private int xM;

	// Token: 0x04001236 RID: 4662
	private int yM;

	// Token: 0x04001237 RID: 4663
	private int xMLast;

	// Token: 0x04001238 RID: 4664
	private int yMLast;

	// Token: 0x04001239 RID: 4665
	private int R;

	// Token: 0x0400123A RID: 4666
	private int r;

	// Token: 0x0400123B RID: 4667
	private int d;

	// Token: 0x0400123C RID: 4668
	private int xTemp;

	// Token: 0x0400123D RID: 4669
	private int yTemp;

	// Token: 0x0400123E RID: 4670
	private int deltaX;

	// Token: 0x0400123F RID: 4671
	private int deltaY;

	// Token: 0x04001240 RID: 4672
	private int delta;

	// Token: 0x04001241 RID: 4673
	private int angle;

	// Token: 0x04001242 RID: 4674
	public int xZone;

	// Token: 0x04001243 RID: 4675
	public int yZone;

	// Token: 0x04001244 RID: 4676
	public int wZone;

	// Token: 0x04001245 RID: 4677
	public int hZone;

	// Token: 0x04001246 RID: 4678
	private bool isGamePad;

	// Token: 0x04001247 RID: 4679
	public bool isSmallGamePad;

	// Token: 0x04001248 RID: 4680
	public bool isMediumGamePad;

	// Token: 0x04001249 RID: 4681
	public bool isLargeGamePad;
}
