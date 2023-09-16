using System;

// Token: 0x0200003F RID: 63
public class FireWorkEff
{
	// Token: 0x06000282 RID: 642 RVA: 0x00017730 File Offset: 0x00015930
	public static void preDraw()
	{
		if (FireWorkEff.st)
		{
			FireWorkEff.animate();
		}
		if (FireWorkEff.t > 32 && FireWorkEff.st)
		{
			FireWorkEff.st = false;
			FireWorkEff.mg.removeAllElements();
			FireWorkEff.mg.addElement(new FireWorkMn(Res.random(50, GameCanvas.w - 50), Res.random(GameCanvas.h - 100, GameCanvas.h), 5, 72));
		}
	}

	// Token: 0x06000283 RID: 643 RVA: 0x000177A8 File Offset: 0x000159A8
	public static void paint(mGraphics g)
	{
		FireWorkEff.preDraw();
		g.setColor(0);
		g.fillRect(0, 0, FireWorkEff.w, FireWorkEff.h);
		g.setColor(16711680);
		for (int i = 0; i < FireWorkEff.mg.size(); i++)
		{
			((FireWorkMn)FireWorkEff.mg.elementAt(i)).paint(g);
		}
		if (!FireWorkEff.st)
		{
			FireWorkEff.keyPressed(-(global::Math.abs(FireWorkEff.r.nextInt() % 3) + 5));
		}
	}

	// Token: 0x06000284 RID: 644 RVA: 0x00017834 File Offset: 0x00015A34
	public static void keyPressed(int k)
	{
		if (k == -5 && !FireWorkEff.st)
		{
			FireWorkEff.x0 = FireWorkEff.w / 2;
			FireWorkEff.ag = 80;
			FireWorkEff.st = true;
			FireWorkEff.add();
		}
		else if (k == -7 && !FireWorkEff.st)
		{
			FireWorkEff.ag = 60;
			FireWorkEff.x0 = 0;
			FireWorkEff.st = true;
			FireWorkEff.add();
		}
		else if (k == -6 && !FireWorkEff.st)
		{
			FireWorkEff.ag = 120;
			FireWorkEff.x0 = FireWorkEff.w;
			FireWorkEff.st = true;
			FireWorkEff.add();
		}
	}

	// Token: 0x06000285 RID: 645 RVA: 0x000178D4 File Offset: 0x00015AD4
	public static void add()
	{
		FireWorkEff.y0 = 0;
		FireWorkEff.v = 16;
		FireWorkEff.t = 0;
		FireWorkEff.a = 0f;
		for (int i = 0; i < 3; i++)
		{
			FireWorkEff.mang_y[i] = 0;
			FireWorkEff.mang_x[i] = FireWorkEff.x0;
		}
		FireWorkEff.st = true;
	}

	// Token: 0x06000286 RID: 646 RVA: 0x0001792C File Offset: 0x00015B2C
	public static void animate()
	{
		FireWorkEff.mang_y[2] = FireWorkEff.mang_y[1];
		FireWorkEff.mang_x[2] = FireWorkEff.mang_x[1];
		FireWorkEff.mang_y[1] = FireWorkEff.mang_y[0];
		FireWorkEff.mang_x[1] = FireWorkEff.mang_x[0];
		FireWorkEff.mang_y[0] = FireWorkEff.y;
		FireWorkEff.mang_x[0] = FireWorkEff.x;
		FireWorkEff.x = Res.cos((int)((double)FireWorkEff.ag * 3.1415926535897931 / 180.0)) * FireWorkEff.v * FireWorkEff.t + FireWorkEff.x0;
		FireWorkEff.y = (int)((float)(FireWorkEff.v * Res.sin((int)((double)FireWorkEff.ag * 3.1415926535897931 / 180.0)) * FireWorkEff.t) - FireWorkEff.a * (float)FireWorkEff.t * (float)FireWorkEff.t / 2f) + FireWorkEff.y0;
		if (FireWorkEff.time() - FireWorkEff.last >= FireWorkEff.delay)
		{
			FireWorkEff.t++;
			FireWorkEff.last = FireWorkEff.time();
		}
	}

	// Token: 0x06000287 RID: 647 RVA: 0x00004E3E File Offset: 0x0000303E
	public static long time()
	{
		return mSystem.currentTimeMillis();
	}

	// Token: 0x040002E3 RID: 739
	private static int w;

	// Token: 0x040002E4 RID: 740
	private static int h;

	// Token: 0x040002E5 RID: 741
	private static MyRandom r = new MyRandom();

	// Token: 0x040002E6 RID: 742
	private static MyVector mg = new MyVector();

	// Token: 0x040002E7 RID: 743
	private static int f = 17;

	// Token: 0x040002E8 RID: 744
	private static int x;

	// Token: 0x040002E9 RID: 745
	private static int y;

	// Token: 0x040002EA RID: 746
	private static int ag;

	// Token: 0x040002EB RID: 747
	private static int x0;

	// Token: 0x040002EC RID: 748
	private static int y0;

	// Token: 0x040002ED RID: 749
	private static int t;

	// Token: 0x040002EE RID: 750
	private static int v;

	// Token: 0x040002EF RID: 751
	private static int ymax = 269;

	// Token: 0x040002F0 RID: 752
	private static float a;

	// Token: 0x040002F1 RID: 753
	private static int[] mang_x = new int[3];

	// Token: 0x040002F2 RID: 754
	private static int[] mang_y = new int[3];

	// Token: 0x040002F3 RID: 755
	private static bool st = false;

	// Token: 0x040002F4 RID: 756
	private static long last = 0L;

	// Token: 0x040002F5 RID: 757
	private static long delay = 150L;
}
