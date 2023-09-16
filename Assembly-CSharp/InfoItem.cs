using System;

// Token: 0x020000A7 RID: 167
public class InfoItem
{
	// Token: 0x06000732 RID: 1842 RVA: 0x00006E37 File Offset: 0x00005037
	public InfoItem(string s)
	{
		this.f = mFont.tahoma_7_green2;
		this.s = s;
		this.speed = 20;
	}

	// Token: 0x06000733 RID: 1843 RVA: 0x00006E61 File Offset: 0x00005061
	public InfoItem(string s, mFont f, int speed)
	{
		this.f = f;
		this.s = s;
		this.speed = speed;
	}

	// Token: 0x04000D63 RID: 3427
	public string s;

	// Token: 0x04000D64 RID: 3428
	private mFont f;

	// Token: 0x04000D65 RID: 3429
	public int speed = 70;

	// Token: 0x04000D66 RID: 3430
	public global::Char charInfo;

	// Token: 0x04000D67 RID: 3431
	public bool isChatServer;

	// Token: 0x04000D68 RID: 3432
	public bool isOnline;

	// Token: 0x04000D69 RID: 3433
	public int timeCount;

	// Token: 0x04000D6A RID: 3434
	public int maxTime;

	// Token: 0x04000D6B RID: 3435
	public long last;

	// Token: 0x04000D6C RID: 3436
	public long curr;
}
