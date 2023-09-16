using System;

// Token: 0x02000040 RID: 64
public class FireWorkMn
{
	// Token: 0x06000289 RID: 649 RVA: 0x00017AA0 File Offset: 0x00015CA0
	public FireWorkMn(int x, int y, int goc, int n)
	{
		this.x = x;
		this.y = y;
		this.goc = goc;
		this.n = n;
		for (int i = 0; i < n; i++)
		{
			this.fw.addElement(new Firework(x, y, global::Math.abs(this.rd.nextInt() % 8) + 3, i * goc, this.color[global::Math.abs(this.rd.nextInt() % this.color.Length)]));
		}
	}

	// Token: 0x0600028A RID: 650 RVA: 0x00017B6C File Offset: 0x00015D6C
	public void paint(mGraphics g)
	{
		for (int i = 0; i < this.fw.size(); i++)
		{
			Firework firework = (Firework)this.fw.elementAt(i);
			if (firework.y < -200)
			{
				this.fw.removeElementAt(i);
			}
			firework.paint(g);
		}
	}

	// Token: 0x040002F6 RID: 758
	private int x;

	// Token: 0x040002F7 RID: 759
	private int y;

	// Token: 0x040002F8 RID: 760
	private int goc = 1;

	// Token: 0x040002F9 RID: 761
	private int n = 360;

	// Token: 0x040002FA RID: 762
	private MyRandom rd = new MyRandom();

	// Token: 0x040002FB RID: 763
	private MyVector fw = new MyVector();

	// Token: 0x040002FC RID: 764
	private int[] color = new int[]
	{
		16711680,
		16776960,
		65280,
		16777215,
		255,
		65535,
		15790320,
		12632256
	};
}
