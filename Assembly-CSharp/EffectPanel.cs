using System;

// Token: 0x0200003E RID: 62
public class EffectPanel : Effect2
{
	// Token: 0x0600027E RID: 638 RVA: 0x000174CC File Offset: 0x000156CC
	public static void addServerEffect(int id, int cx, int cy, int loopCount)
	{
		EffectPanel effectPanel = new EffectPanel();
		effectPanel.eff = GameScr.efs[id - 1];
		effectPanel.x = cx;
		effectPanel.y = cy;
		effectPanel.loopCount = (short)loopCount;
		Effect2.vEffect3.addElement(effectPanel);
	}

	// Token: 0x0600027F RID: 639 RVA: 0x00017510 File Offset: 0x00015710
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
			SmallImage.drawSmallImage(g, this.eff.arrEfInfo[this.i0].idImg, num, num2, this.trans, mGraphics.VCENTER | mGraphics.HCENTER);
		}
	}

	// Token: 0x06000280 RID: 640 RVA: 0x00017624 File Offset: 0x00015824
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
				Effect2.vEffect3.removeElement(this);
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
					Effect2.vEffect3.removeElement(this);
				}
				else
				{
					this.i0 = 0;
				}
			}
		}
		if (GameCanvas.gameTick % 11 == 0 && this.c != null && this.c != global::Char.myCharz() && !GameScr.vCharInMap.contains(this.c))
		{
			Effect2.vEffect3.removeElement(this);
		}
	}

	// Token: 0x040002D8 RID: 728
	public EffectCharPaint eff;

	// Token: 0x040002D9 RID: 729
	private int i0;

	// Token: 0x040002DA RID: 730
	private int dx0;

	// Token: 0x040002DB RID: 731
	private int dy0;

	// Token: 0x040002DC RID: 732
	private int x;

	// Token: 0x040002DD RID: 733
	private int y;

	// Token: 0x040002DE RID: 734
	private global::Char c;

	// Token: 0x040002DF RID: 735
	private Mob m;

	// Token: 0x040002E0 RID: 736
	private short loopCount;

	// Token: 0x040002E1 RID: 737
	private long endTime;

	// Token: 0x040002E2 RID: 738
	private int trans;
}
