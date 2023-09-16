using System;

// Token: 0x0200000B RID: 11
public class Math
{
	// Token: 0x06000055 RID: 85 RVA: 0x00003BF5 File Offset: 0x00001DF5
	public static int abs(int i)
	{
		return (i <= 0) ? (-i) : i;
	}

	// Token: 0x06000056 RID: 86 RVA: 0x00003C06 File Offset: 0x00001E06
	public static int min(int x, int y)
	{
		return (x >= y) ? y : x;
	}

	// Token: 0x06000057 RID: 87 RVA: 0x00003C16 File Offset: 0x00001E16
	public static int max(int x, int y)
	{
		return (x <= y) ? y : x;
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00008C2C File Offset: 0x00006E2C
	public static int pow(int data, int x)
	{
		int num = 1;
		for (int i = 0; i < x; i++)
		{
			num *= data;
		}
		return num;
	}

	// Token: 0x04000020 RID: 32
	public const double PI = 3.1415926535897931;
}
