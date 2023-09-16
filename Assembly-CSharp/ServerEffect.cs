using System;

// Token: 0x02000047 RID: 71
public class ServerEffect : Effect2
{
	// Token: 0x060002A6 RID: 678 RVA: 0x0001891C File Offset: 0x00016B1C
	public static void addServerEffect(int id, int cx, int cy, int loopCount)
	{
		ServerEffect serverEffect = new ServerEffect();
		serverEffect.eff = GameScr.efs[id - 1];
		serverEffect.x = cx;
		serverEffect.y = cy;
		serverEffect.loopCount = (short)loopCount;
		Effect2.vEffect2.addElement(serverEffect);
	}

	// Token: 0x060002A7 RID: 679 RVA: 0x00018960 File Offset: 0x00016B60
	public static void addServerEffect(int id, int cx, int cy, int loopCount, int trans)
	{
		ServerEffect serverEffect = new ServerEffect();
		serverEffect.eff = GameScr.efs[id - 1];
		serverEffect.x = cx;
		serverEffect.y = cy;
		serverEffect.loopCount = (short)loopCount;
		serverEffect.trans = trans;
		Effect2.vEffect2.addElement(serverEffect);
	}

	// Token: 0x060002A8 RID: 680 RVA: 0x000189AC File Offset: 0x00016BAC
	public static void addServerEffect(int id, Mob m, int loopCount)
	{
		ServerEffect serverEffect = new ServerEffect();
		serverEffect.eff = GameScr.efs[id - 1];
		serverEffect.m = m;
		serverEffect.loopCount = (short)loopCount;
		Effect2.vEffect2.addElement(serverEffect);
	}

	// Token: 0x060002A9 RID: 681 RVA: 0x000189E8 File Offset: 0x00016BE8
	public static void addServerEffect(int id, global::Char c, int loopCount)
	{
		ServerEffect serverEffect = new ServerEffect();
		serverEffect.eff = GameScr.efs[id - 1];
		serverEffect.c = c;
		serverEffect.loopCount = (short)loopCount;
		Effect2.vEffect2.addElement(serverEffect);
	}

	// Token: 0x060002AA RID: 682 RVA: 0x00018A24 File Offset: 0x00016C24
	public static void addServerEffect(int id, global::Char c, int loopCount, int trans)
	{
		ServerEffect serverEffect = new ServerEffect();
		serverEffect.eff = GameScr.efs[id - 1];
		serverEffect.c = c;
		serverEffect.loopCount = (short)loopCount;
		serverEffect.trans = trans;
		Effect2.vEffect2.addElement(serverEffect);
	}

	// Token: 0x060002AB RID: 683 RVA: 0x00018A68 File Offset: 0x00016C68
	public static void addServerEffectWithTime(int id, int cx, int cy, int timeLengthInSecond)
	{
		ServerEffect serverEffect = new ServerEffect();
		serverEffect.eff = GameScr.efs[id - 1];
		serverEffect.x = cx;
		serverEffect.y = cy;
		serverEffect.endTime = mSystem.currentTimeMillis() + (long)(timeLengthInSecond * 1000);
		Effect2.vEffect2.addElement(serverEffect);
	}

	// Token: 0x060002AC RID: 684 RVA: 0x00018AB8 File Offset: 0x00016CB8
	public static void addServerEffectWithTime(int id, global::Char c, int timeLengthInSecond)
	{
		ServerEffect serverEffect = new ServerEffect();
		serverEffect.eff = GameScr.efs[id - 1];
		serverEffect.c = c;
		serverEffect.endTime = mSystem.currentTimeMillis() + (long)(timeLengthInSecond * 1000);
		Effect2.vEffect2.addElement(serverEffect);
	}

	// Token: 0x060002AD RID: 685 RVA: 0x00018B00 File Offset: 0x00016D00
	public override void paint(mGraphics g)
	{
		if (mGraphics.zoomLevel == 1)
		{
			GameScr.countEff++;
		}
		if (GameScr.countEff < 8)
		{
			if (this.c != null)
			{
				this.x = this.c.cx;
				this.y = this.c.cy + GameCanvas.transY;
			}
			if (this.m != null)
			{
				this.x = this.m.x;
				this.y = this.m.y + GameCanvas.transY;
			}
			int num = this.x + this.dx0 + this.eff.arrEfInfo[this.i0].dx;
			int num2 = this.y + this.dy0 + this.eff.arrEfInfo[this.i0].dy;
			if (GameCanvas.isPaint(num, num2))
			{
				SmallImage.drawSmallImage(g, this.eff.arrEfInfo[this.i0].idImg, num, num2, this.trans, mGraphics.VCENTER | mGraphics.HCENTER);
			}
		}
	}

	// Token: 0x060002AE RID: 686 RVA: 0x00018C20 File Offset: 0x00016E20
	public override void update()
	{
		if (this.endTime != 0L)
		{
			this.i0++;
			if (this.i0 >= this.eff.arrEfInfo.Length)
			{
				this.i0 = 0;
			}
			if (mSystem.currentTimeMillis() - this.endTime > 0L)
			{
				Effect2.vEffect2.removeElement(this);
			}
		}
		else
		{
			this.i0++;
			if (this.i0 >= this.eff.arrEfInfo.Length)
			{
				this.loopCount -= 1;
				if (this.loopCount <= 0)
				{
					Effect2.vEffect2.removeElement(this);
				}
				else
				{
					this.i0 = 0;
				}
			}
		}
		if (GameCanvas.gameTick % 11 == 0 && this.c != null && this.c != global::Char.myCharz() && !GameScr.vCharInMap.contains(this.c))
		{
			Effect2.vEffect2.removeElement(this);
		}
	}

	// Token: 0x04000336 RID: 822
	public EffectCharPaint eff;

	// Token: 0x04000337 RID: 823
	private int i0;

	// Token: 0x04000338 RID: 824
	private int dx0;

	// Token: 0x04000339 RID: 825
	private int dy0;

	// Token: 0x0400033A RID: 826
	private int x;

	// Token: 0x0400033B RID: 827
	private int y;

	// Token: 0x0400033C RID: 828
	private global::Char c;

	// Token: 0x0400033D RID: 829
	private Mob m;

	// Token: 0x0400033E RID: 830
	private short loopCount;

	// Token: 0x0400033F RID: 831
	private long endTime;

	// Token: 0x04000340 RID: 832
	private int trans;
}
