using System;

// Token: 0x02000077 RID: 119
public class Position
{
	// Token: 0x060003D0 RID: 976 RVA: 0x00005945 File Offset: 0x00003B45
	public Position()
	{
		this.x = 0;
		this.y = 0;
	}

	// Token: 0x060003D1 RID: 977 RVA: 0x0000595B File Offset: 0x00003B5B
	public Position(int x, int y, int anchor)
	{
		this.x = x;
		this.y = y;
		this.anchor = anchor;
	}

	// Token: 0x060003D2 RID: 978 RVA: 0x00005978 File Offset: 0x00003B78
	public Position(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x0000598E File Offset: 0x00003B8E
	public void setPosTo(int xT, int yT)
	{
		this.xTo = (short)xT;
		this.yTo = (short)yT;
		this.distant = (short)Res.distance(this.x, this.y, (int)this.xTo, (int)this.yTo);
	}

	// Token: 0x060003D4 RID: 980 RVA: 0x00021AD8 File Offset: 0x0001FCD8
	public int translate()
	{
		if (this.x == (int)this.xTo && this.y == (int)this.yTo)
		{
			return -1;
		}
		if (global::Math.abs(((int)this.xTo - this.x) / 2) <= 1 && global::Math.abs(((int)this.yTo - this.y) / 2) <= 1)
		{
			this.x = (int)this.xTo;
			this.y = (int)this.yTo;
			return 0;
		}
		if (this.x != (int)this.xTo)
		{
			this.x += ((int)this.xTo - this.x) / 2;
		}
		if (this.y != (int)this.yTo)
		{
			this.y += ((int)this.yTo - this.y) / 2;
		}
		if (Res.distance(this.x, this.y, (int)this.xTo, (int)this.yTo) <= (int)(this.distant / 5))
		{
			return 2;
		}
		return 1;
	}

	// Token: 0x060003D5 RID: 981 RVA: 0x000059C4 File Offset: 0x00003BC4
	public void update()
	{
		this.layer.update();
	}

	// Token: 0x060003D6 RID: 982 RVA: 0x000059D1 File Offset: 0x00003BD1
	public void paint(mGraphics g)
	{
		this.layer.paint(g, this.x, this.y);
	}

	// Token: 0x04000674 RID: 1652
	public int x;

	// Token: 0x04000675 RID: 1653
	public int y;

	// Token: 0x04000676 RID: 1654
	public int anchor;

	// Token: 0x04000677 RID: 1655
	public int g;

	// Token: 0x04000678 RID: 1656
	public int v;

	// Token: 0x04000679 RID: 1657
	public int w;

	// Token: 0x0400067A RID: 1658
	public int h;

	// Token: 0x0400067B RID: 1659
	public int color;

	// Token: 0x0400067C RID: 1660
	public int limitY;

	// Token: 0x0400067D RID: 1661
	public Layer layer;

	// Token: 0x0400067E RID: 1662
	public short yTo;

	// Token: 0x0400067F RID: 1663
	public short xTo;

	// Token: 0x04000680 RID: 1664
	public short distant;
}
