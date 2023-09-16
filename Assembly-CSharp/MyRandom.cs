using System;

// Token: 0x0200000F RID: 15
public class MyRandom
{
	// Token: 0x06000068 RID: 104 RVA: 0x00003CFB File Offset: 0x00001EFB
	public MyRandom()
	{
		this.r = new Random();
	}

	// Token: 0x06000069 RID: 105 RVA: 0x00003D0E File Offset: 0x00001F0E
	public int nextInt()
	{
		return this.r.Next();
	}

	// Token: 0x0600006A RID: 106 RVA: 0x00003D1B File Offset: 0x00001F1B
	public int nextInt(int a)
	{
		return this.r.Next(a);
	}

	// Token: 0x0600006B RID: 107 RVA: 0x00003D29 File Offset: 0x00001F29
	public int nextInt(int a, int b)
	{
		return this.r.Next(a, b);
	}

	// Token: 0x04000026 RID: 38
	public Random r;
}
