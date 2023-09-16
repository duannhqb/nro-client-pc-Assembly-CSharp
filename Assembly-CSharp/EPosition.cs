using System;

// Token: 0x02000038 RID: 56
public class EPosition
{
	// Token: 0x0600024F RID: 591 RVA: 0x00004CEC File Offset: 0x00002EEC
	public EPosition(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	// Token: 0x06000250 RID: 592 RVA: 0x00004D10 File Offset: 0x00002F10
	public EPosition(int x, int y, int fol)
	{
		this.x = x;
		this.y = y;
		this.follow = (sbyte)fol;
	}

	// Token: 0x06000251 RID: 593 RVA: 0x00004D3C File Offset: 0x00002F3C
	public EPosition()
	{
	}

	// Token: 0x04000280 RID: 640
	public int x;

	// Token: 0x04000281 RID: 641
	public int y;

	// Token: 0x04000282 RID: 642
	public int anchor;

	// Token: 0x04000283 RID: 643
	public sbyte follow;

	// Token: 0x04000284 RID: 644
	public sbyte count;

	// Token: 0x04000285 RID: 645
	public sbyte dir = 1;

	// Token: 0x04000286 RID: 646
	public short index = -1;
}
