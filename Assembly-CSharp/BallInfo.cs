using System;

// Token: 0x02000098 RID: 152
public class BallInfo
{
	// Token: 0x06000547 RID: 1351 RVA: 0x00042354 File Offset: 0x00040554
	public void SetChar()
	{
		this.cFocus = new global::Char();
		this.cFocus.charID = Res.random(-999, -800);
		this.cFocus.head = -1;
		this.cFocus.body = -1;
		this.cFocus.leg = -1;
		this.cFocus.bag = -1;
		this.cFocus.cName = string.Empty;
		this.cFocus.cHP = (this.cFocus.cHPFull = 20);
	}

	// Token: 0x06000548 RID: 1352 RVA: 0x00006293 File Offset: 0x00004493
	public void UpdChar()
	{
		this.cFocus.cx = this.x;
		this.cFocus.cy = this.y;
	}

	// Token: 0x0400094A RID: 2378
	public int x;

	// Token: 0x0400094B RID: 2379
	public int y;

	// Token: 0x0400094C RID: 2380
	public int xTo = -999;

	// Token: 0x0400094D RID: 2381
	public int yTo = -999;

	// Token: 0x0400094E RID: 2382
	public int count;

	// Token: 0x0400094F RID: 2383
	public int vy;

	// Token: 0x04000950 RID: 2384
	public int vx;

	// Token: 0x04000951 RID: 2385
	public int dir;

	// Token: 0x04000952 RID: 2386
	public int idImg;

	// Token: 0x04000953 RID: 2387
	public bool isPaint = true;

	// Token: 0x04000954 RID: 2388
	public bool isDone;

	// Token: 0x04000955 RID: 2389
	public bool isSetImg;

	// Token: 0x04000956 RID: 2390
	public global::Char cFocus;
}
