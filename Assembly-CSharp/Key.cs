using System;

// Token: 0x02000066 RID: 102
public class Key
{
	// Token: 0x06000369 RID: 873 RVA: 0x0000548A File Offset: 0x0000368A
	public static void mapKeyPC()
	{
		if (!Main.isPC)
		{
			return;
		}
		Key.UP = 15;
		Key.DOWN = 16;
		Key.LEFT = 17;
		Key.RIGHT = 18;
	}

	// Token: 0x0400059F RID: 1439
	public static int NUM0;

	// Token: 0x040005A0 RID: 1440
	public static int NUM1 = 1;

	// Token: 0x040005A1 RID: 1441
	public static int NUM2 = 2;

	// Token: 0x040005A2 RID: 1442
	public static int NUM3 = 3;

	// Token: 0x040005A3 RID: 1443
	public static int NUM4 = 4;

	// Token: 0x040005A4 RID: 1444
	public static int NUM5 = 5;

	// Token: 0x040005A5 RID: 1445
	public static int NUM6 = 6;

	// Token: 0x040005A6 RID: 1446
	public static int NUM7 = 7;

	// Token: 0x040005A7 RID: 1447
	public static int NUM8 = 8;

	// Token: 0x040005A8 RID: 1448
	public static int NUM9 = 9;

	// Token: 0x040005A9 RID: 1449
	public static int STAR = 10;

	// Token: 0x040005AA RID: 1450
	public static int BOUND = 11;

	// Token: 0x040005AB RID: 1451
	public static int UP = 12;

	// Token: 0x040005AC RID: 1452
	public static int DOWN = 13;

	// Token: 0x040005AD RID: 1453
	public static int LEFT = 14;

	// Token: 0x040005AE RID: 1454
	public static int RIGHT = 15;

	// Token: 0x040005AF RID: 1455
	public static int FIRE = 16;

	// Token: 0x040005B0 RID: 1456
	public static int LEFT_SOFTKEY = 17;

	// Token: 0x040005B1 RID: 1457
	public static int RIGHT_SOFTKEY = 18;

	// Token: 0x040005B2 RID: 1458
	public static int CLEAR = 19;

	// Token: 0x040005B3 RID: 1459
	public static int BACK = 20;
}
