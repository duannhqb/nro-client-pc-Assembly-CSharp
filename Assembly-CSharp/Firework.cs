using System;

// Token: 0x02000041 RID: 65
public class Firework
{
	// Token: 0x0600028B RID: 651 RVA: 0x00017BCC File Offset: 0x00015DCC
	public Firework(int x0, int y0, int v, int angle, int cl)
	{
		this.y0 = y0;
		this.x0 = x0;
		this.a = 1f;
		this.v = v;
		this.angle = angle;
		this.w = GameCanvas.w;
		this.h = GameCanvas.h;
		this.last = this.time();
		for (int i = 0; i < 2; i++)
		{
			this.arr_x[i] = x0;
			this.arr_y[i] = y0;
		}
		this.cl = cl;
	}

	// Token: 0x0600028C RID: 652 RVA: 0x00017C8C File Offset: 0x00015E8C
	public void preDraw()
	{
		if (this.time() - this.last >= this.delay)
		{
			this.t++;
			this.last = this.time();
			this.arr_x[1] = this.arr_x[0];
			this.arr_y[1] = this.arr_y[0];
			this.arr_x[0] = this.x;
			this.arr_y[0] = this.y;
			this.x = Res.cos((int)((double)this.angle * 3.1415926535897931 / 180.0)) * this.v * this.t + this.x0;
			this.y = (int)((float)(this.v * Res.sin((int)((double)this.angle * 3.1415926535897931 / 180.0)) * this.t) - this.a * (float)this.t * (float)this.t / 2f) + this.y0;
		}
	}

	// Token: 0x0600028D RID: 653 RVA: 0x00017DA0 File Offset: 0x00015FA0
	public void paint(mGraphics g)
	{
		this.Drawline(g, this.w - this.x, this.h - this.y, this.cl);
		for (int i = 0; i < 2; i++)
		{
			this.Drawline(g, this.w - this.arr_x[i], this.h - this.arr_y[i], this.cl);
		}
		if (this.act)
		{
			this.preDraw();
		}
	}

	// Token: 0x0600028E RID: 654 RVA: 0x00004E3E File Offset: 0x0000303E
	public long time()
	{
		return mSystem.currentTimeMillis();
	}

	// Token: 0x0600028F RID: 655 RVA: 0x00004E45 File Offset: 0x00003045
	public void Drawline(mGraphics g, int x, int y, int color)
	{
		g.setColor(color);
		g.fillRect(x, y, 1, 2);
	}

	// Token: 0x040002FD RID: 765
	public int w;

	// Token: 0x040002FE RID: 766
	public int h;

	// Token: 0x040002FF RID: 767
	public int v;

	// Token: 0x04000300 RID: 768
	public int x0;

	// Token: 0x04000301 RID: 769
	public int x;

	// Token: 0x04000302 RID: 770
	public int y;

	// Token: 0x04000303 RID: 771
	public int y0;

	// Token: 0x04000304 RID: 772
	public int angle;

	// Token: 0x04000305 RID: 773
	public int t;

	// Token: 0x04000306 RID: 774
	public int cl = 16711680;

	// Token: 0x04000307 RID: 775
	private float a;

	// Token: 0x04000308 RID: 776
	private long last;

	// Token: 0x04000309 RID: 777
	private long delay = 150L;

	// Token: 0x0400030A RID: 778
	private bool act = true;

	// Token: 0x0400030B RID: 779
	private int[] arr_x = new int[2];

	// Token: 0x0400030C RID: 780
	private int[] arr_y = new int[2];
}
