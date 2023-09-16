﻿using System;

// Token: 0x0200004C RID: 76
public class Arrow
{
	// Token: 0x060002BA RID: 698 RVA: 0x00004F61 File Offset: 0x00003161
	public Arrow(global::Char charBelong, Arrowpaint arrp)
	{
		this.charBelong = charBelong;
		this.arrp = arrp;
	}

	// Token: 0x060002BB RID: 699 RVA: 0x00018D2C File Offset: 0x00016F2C
	public void update()
	{
		if (this.charBelong.mobFocus == null && this.charBelong.charFocus == null)
		{
			this.endMe();
		}
		else
		{
			if (this.charBelong.mobFocus != null)
			{
				this.axTo = this.charBelong.mobFocus.x;
				this.ayTo = this.charBelong.mobFocus.y - this.charBelong.mobFocus.h / 4;
			}
			else if (this.charBelong.charFocus != null)
			{
				this.axTo = this.charBelong.charFocus.cx;
				this.ayTo = this.charBelong.charFocus.cy - this.charBelong.charFocus.ch / 4;
			}
			int num = this.axTo - this.ax;
			int num2 = this.ayTo - this.ay;
			int num3 = 5;
			int num4 = 4;
			if (num + num2 < 60)
			{
				num4 = 3;
			}
			else if (num + num2 < 30)
			{
				num4 = 2;
			}
			if (this.ax != this.axTo)
			{
				if (num > 0 && num < num3)
				{
					this.ax = this.axTo;
				}
				else if (num < 0 && num > -num3)
				{
					this.ax = this.axTo;
				}
				else
				{
					this.avx = this.axTo - this.ax << 2;
					this.adx += this.avx;
					this.ax += this.adx >> num4;
					this.adx &= 15;
				}
			}
			if (this.ay != this.ayTo)
			{
				if (num2 > 0 && num2 < num3)
				{
					this.ay = this.ayTo;
				}
				else if (num2 < 0 && num2 > -num3)
				{
					this.ay = this.ayTo;
				}
				else
				{
					this.avy = this.ayTo - this.ay << 2;
					this.ady += this.avy;
					this.ay += this.ady >> num4;
					this.ady &= 15;
				}
			}
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			if (this.charBelong.mobFocus != null)
			{
				num5 = this.axTo - this.charBelong.mobFocus.w / 4;
				num7 = this.axTo + this.charBelong.mobFocus.w / 4;
				num6 = this.ayTo - this.charBelong.mobFocus.h / 4;
				num8 = this.ayTo + this.charBelong.mobFocus.h / 4;
			}
			else if (this.charBelong.charFocus != null)
			{
				num5 = this.axTo - this.charBelong.charFocus.cw / 4;
				num7 = this.axTo + this.charBelong.charFocus.cw / 4;
				num6 = this.ayTo - this.charBelong.charFocus.ch / 4;
				num8 = this.ayTo + this.charBelong.charFocus.ch / 4;
			}
			if (this.life > 0)
			{
				this.life--;
			}
			if (this.life == 0 || (this.ax >= num5 && this.ax <= num7 && this.ay >= num6 && this.ay <= num8))
			{
				this.endMe();
			}
		}
	}

	// Token: 0x060002BC RID: 700 RVA: 0x000190EC File Offset: 0x000172EC
	private void endMe()
	{
		this.charBelong.arr = null;
		this.ax = (this.ay = (this.axTo = (this.ayTo = (this.avx = (this.avy = (this.adx = (this.ady = 0)))))));
		this.charBelong.setAttack();
		if (this.charBelong.me)
		{
			this.charBelong.saveLoadPreviousSkill();
		}
	}

	// Token: 0x060002BD RID: 701 RVA: 0x00019174 File Offset: 0x00017374
	public void paint(mGraphics g)
	{
		int dx = this.axTo - this.ax;
		int num = this.ayTo - this.ay;
		int num2 = Arrow.findDirIndexFromAngle(Res.angle(dx, -num));
		SmallImage.drawSmallImage(g, this.arrp.imgId[(int)Arrow.FRAME[num2]], this.ax, this.ay, Arrow.TRANSFORM[num2], mGraphics.VCENTER | mGraphics.HCENTER);
	}

	// Token: 0x060002BE RID: 702 RVA: 0x000191E4 File Offset: 0x000173E4
	public static int findDirIndexFromAngle(int angle)
	{
		int i = 0;
		while (i < Arrow.ARROWINDEX.Length - 1)
		{
			if (angle >= Arrow.ARROWINDEX[i] && angle <= Arrow.ARROWINDEX[i + 1])
			{
				if (i >= 16)
				{
					return 0;
				}
				return i;
			}
			else
			{
				i++;
			}
		}
		return 0;
	}

	// Token: 0x04000349 RID: 841
	public int life;

	// Token: 0x0400034A RID: 842
	public int ax;

	// Token: 0x0400034B RID: 843
	public int ay;

	// Token: 0x0400034C RID: 844
	public int axTo;

	// Token: 0x0400034D RID: 845
	public int ayTo;

	// Token: 0x0400034E RID: 846
	public int avx;

	// Token: 0x0400034F RID: 847
	public int avy;

	// Token: 0x04000350 RID: 848
	public int adx;

	// Token: 0x04000351 RID: 849
	public int ady;

	// Token: 0x04000352 RID: 850
	public global::Char charBelong;

	// Token: 0x04000353 RID: 851
	public Arrowpaint arrp;

	// Token: 0x04000354 RID: 852
	public static sbyte[] FRAME = new sbyte[]
	{
		0,
		1,
		2,
		1,
		0,
		1,
		2,
		1,
		0,
		1,
		2,
		1,
		0,
		1,
		2,
		1,
		0,
		1,
		2,
		1,
		0,
		1,
		2,
		1,
		0
	};

	// Token: 0x04000355 RID: 853
	public static int[] ARROWINDEX = new int[]
	{
		0,
		15,
		37,
		52,
		75,
		105,
		127,
		142,
		165,
		195,
		217,
		232,
		255,
		285,
		307,
		322,
		345,
		370
	};

	// Token: 0x04000356 RID: 854
	public static int[] TRANSFORM = new int[]
	{
		0,
		0,
		0,
		7,
		6,
		6,
		6,
		2,
		2,
		3,
		3,
		4,
		5,
		5,
		5,
		1
	};
}
