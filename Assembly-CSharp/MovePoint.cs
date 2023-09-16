using System;

// Token: 0x0200006B RID: 107
public class MovePoint
{
	// Token: 0x06000378 RID: 888 RVA: 0x000054EF File Offset: 0x000036EF
	public MovePoint(int xEnd, int yEnd, int act, int dir)
	{
		this.xEnd = xEnd;
		this.yEnd = yEnd;
		this.dir = dir;
		this.status = act;
	}

	// Token: 0x06000379 RID: 889 RVA: 0x00005514 File Offset: 0x00003714
	public MovePoint(int xEnd, int yEnd)
	{
		this.xEnd = xEnd;
		this.yEnd = yEnd;
	}

	// Token: 0x040005F0 RID: 1520
	public int xEnd;

	// Token: 0x040005F1 RID: 1521
	public int yEnd;

	// Token: 0x040005F2 RID: 1522
	public int dir;

	// Token: 0x040005F3 RID: 1523
	public int cvx;

	// Token: 0x040005F4 RID: 1524
	public int cvy;

	// Token: 0x040005F5 RID: 1525
	public int status;
}
