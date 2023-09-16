using System;

// Token: 0x020000B8 RID: 184
public class Res
{
	// Token: 0x060008F0 RID: 2288 RVA: 0x000873C4 File Offset: 0x000855C4
	public static void init()
	{
		Res.cosz = new short[91];
		Res.tanz = new int[91];
		for (int i = 0; i <= 90; i++)
		{
			Res.cosz[i] = Res.sinz[90 - i];
			if (Res.cosz[i] == 0)
			{
				Res.tanz[i] = int.MaxValue;
			}
			else
			{
				Res.tanz[i] = ((int)Res.sinz[i] << 10) / (int)Res.cosz[i];
			}
		}
	}

	// Token: 0x060008F1 RID: 2289 RVA: 0x00087444 File Offset: 0x00085644
	public static int sin(int a)
	{
		a = Res.fixangle(a);
		if (a >= 0 && a < 90)
		{
			return (int)Res.sinz[a];
		}
		if (a >= 90 && a < 180)
		{
			return (int)Res.sinz[180 - a];
		}
		if (a >= 180 && a < 270)
		{
			return (int)(-(int)Res.sinz[a - 180]);
		}
		return (int)(-(int)Res.sinz[360 - a]);
	}

	// Token: 0x060008F2 RID: 2290 RVA: 0x000874C4 File Offset: 0x000856C4
	public static int cos(int a)
	{
		a = Res.fixangle(a);
		if (a >= 0 && a < 90)
		{
			return (int)Res.cosz[a];
		}
		if (a >= 90 && a < 180)
		{
			return (int)(-(int)Res.cosz[180 - a]);
		}
		if (a >= 180 && a < 270)
		{
			return (int)(-(int)Res.cosz[a - 180]);
		}
		return (int)Res.cosz[360 - a];
	}

	// Token: 0x060008F3 RID: 2291 RVA: 0x00087544 File Offset: 0x00085744
	public static int tan(int a)
	{
		a = Res.fixangle(a);
		if (a >= 0 && a < 90)
		{
			return Res.tanz[a];
		}
		if (a >= 90 && a < 180)
		{
			return -Res.tanz[180 - a];
		}
		if (a >= 180 && a < 270)
		{
			return Res.tanz[a - 180];
		}
		return -Res.tanz[360 - a];
	}

	// Token: 0x060008F4 RID: 2292 RVA: 0x000875C4 File Offset: 0x000857C4
	public static int atan(int a)
	{
		for (int i = 0; i <= 90; i++)
		{
			if (Res.tanz[i] >= a)
			{
				return i;
			}
		}
		return 0;
	}

	// Token: 0x060008F5 RID: 2293 RVA: 0x000875F4 File Offset: 0x000857F4
	public static int angle(int dx, int dy)
	{
		int num;
		if (dx != 0)
		{
			int a = global::Math.abs((dy << 10) / dx);
			num = Res.atan(a);
			if (dy >= 0 && dx < 0)
			{
				num = 180 - num;
			}
			if (dy < 0 && dx < 0)
			{
				num = 180 + num;
			}
			if (dy < 0 && dx >= 0)
			{
				num = 360 - num;
			}
		}
		else
		{
			num = ((dy <= 0) ? 270 : 90);
		}
		return num;
	}

	// Token: 0x060008F6 RID: 2294 RVA: 0x0000786E File Offset: 0x00005A6E
	public static int fixangle(int angle)
	{
		if (angle >= 360)
		{
			angle -= 360;
		}
		if (angle < 0)
		{
			angle += 360;
		}
		return angle;
	}

	// Token: 0x060008F7 RID: 2295 RVA: 0x00003984 File Offset: 0x00001B84
	public static void outz(string s)
	{
	}

	// Token: 0x060008F8 RID: 2296 RVA: 0x00003984 File Offset: 0x00001B84
	public static void outz2(string s)
	{
	}

	// Token: 0x060008F9 RID: 2297 RVA: 0x00003984 File Offset: 0x00001B84
	public static void onScreenDebug(string s)
	{
	}

	// Token: 0x060008FA RID: 2298 RVA: 0x00003984 File Offset: 0x00001B84
	public static void paintOnScreenDebug(mGraphics g)
	{
	}

	// Token: 0x060008FB RID: 2299 RVA: 0x00003984 File Offset: 0x00001B84
	public static void updateOnScreenDebug()
	{
	}

	// Token: 0x060008FC RID: 2300 RVA: 0x00007895 File Offset: 0x00005A95
	public static string changeString(string str)
	{
		return str;
	}

	// Token: 0x060008FD RID: 2301 RVA: 0x0000608D File Offset: 0x0000428D
	public static string replace(string _text, string _searchStr, string _replacementStr)
	{
		return _text.Replace(_searchStr, _replacementStr);
	}

	// Token: 0x060008FE RID: 2302 RVA: 0x00007898 File Offset: 0x00005A98
	public static int xetVX(int goc, int d)
	{
		return Res.cos(Res.fixangle(goc)) * d >> 10;
	}

	// Token: 0x060008FF RID: 2303 RVA: 0x000078AA File Offset: 0x00005AAA
	public static int xetVY(int goc, int d)
	{
		return Res.sin(Res.fixangle(goc)) * d >> 10;
	}

	// Token: 0x06000900 RID: 2304 RVA: 0x000078BC File Offset: 0x00005ABC
	public static int random(int a, int b)
	{
		if (a == b)
		{
			return a;
		}
		return a + Res.r.nextInt(b - a);
	}

	// Token: 0x06000901 RID: 2305 RVA: 0x000078D6 File Offset: 0x00005AD6
	public static int random(int a)
	{
		return Res.r.nextInt(a);
	}

	// Token: 0x06000902 RID: 2306 RVA: 0x00087678 File Offset: 0x00085878
	public static int s2tick(int currentTimeMillis)
	{
		int num = currentTimeMillis * 16 / 1000;
		if (currentTimeMillis * 16 % 1000 >= 5)
		{
			num++;
		}
		return num;
	}

	// Token: 0x06000903 RID: 2307 RVA: 0x000078E3 File Offset: 0x00005AE3
	public static int distance(int x1, int y1, int x2, int y2)
	{
		return Res.sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
	}

	// Token: 0x06000904 RID: 2308 RVA: 0x000876A8 File Offset: 0x000858A8
	public static int sqrt(int a)
	{
		if (a <= 0)
		{
			return 0;
		}
		int num = (a + 1) / 2;
		int num2;
		do
		{
			num2 = num;
			num = num / 2 + a / (2 * num);
		}
		while (global::Math.abs(num2 - num) > 1);
		return num;
	}

	// Token: 0x06000905 RID: 2309 RVA: 0x000078D6 File Offset: 0x00005AD6
	public static int rnd(int a)
	{
		return Res.r.nextInt(a);
	}

	// Token: 0x06000906 RID: 2310 RVA: 0x00003BF5 File Offset: 0x00001DF5
	public static int abs(int i)
	{
		return (i <= 0) ? (-i) : i;
	}

	// Token: 0x06000907 RID: 2311 RVA: 0x000078F9 File Offset: 0x00005AF9
	public static bool inRect(int x1, int y1, int width, int height, int x2, int y2)
	{
		return x2 >= x1 && x2 <= x1 + width && y2 >= y1 && y2 <= y1 + height;
	}

	// Token: 0x06000908 RID: 2312 RVA: 0x000876E0 File Offset: 0x000858E0
	public static string[] split(string original, string separator, int count)
	{
		int num = original.IndexOf(separator);
		string[] array;
		if (num >= 0)
		{
			array = Res.split(original.Substring(num + separator.Length), separator, count + 1);
		}
		else
		{
			array = new string[count + 1];
			num = original.Length;
		}
		array[count] = original.Substring(0, num);
		return array;
	}

	// Token: 0x06000909 RID: 2313 RVA: 0x00087738 File Offset: 0x00085938
	public static string formatNumber(long number)
	{
		string text = string.Empty;
		string text2 = string.Empty;
		text = string.Empty;
		if (number >= 1000000000L)
		{
			text2 = mResources.billion;
			long num = number % 1000000000L / 100000000L;
			number /= 1000000000L;
			text = number + string.Empty;
			if (num > 0L)
			{
				string text3 = text;
				text = string.Concat(new object[]
				{
					text3,
					",",
					num,
					text2
				});
			}
			else
			{
				text += text2;
			}
		}
		else if (number >= 1000000L)
		{
			text2 = mResources.million;
			long num2 = number % 1000000L / 100000L;
			number /= 1000000L;
			text = number + string.Empty;
			if (num2 > 0L)
			{
				string text3 = text;
				text = string.Concat(new object[]
				{
					text3,
					",",
					num2,
					text2
				});
			}
			else
			{
				text += text2;
			}
		}
		else
		{
			text = number + string.Empty;
		}
		return text;
	}

	// Token: 0x0600090A RID: 2314 RVA: 0x00087868 File Offset: 0x00085A68
	public static string formatNumber2(long number)
	{
		string text = string.Empty;
		string text2 = string.Empty;
		text = string.Empty;
		if (number >= 1000000000L)
		{
			text2 = mResources.billion;
			long num = number % 1000000000L / 10000000L;
			number /= 1000000000L;
			text = number + string.Empty;
			if (num >= 10L)
			{
				if (num % 10L == 0L)
				{
					num /= 10L;
				}
				string text3 = text;
				text = string.Concat(new object[]
				{
					text3,
					",",
					num,
					text2
				});
			}
			else if (num > 0L)
			{
				string text3 = text;
				text = string.Concat(new object[]
				{
					text3,
					",0",
					num,
					text2
				});
			}
			else
			{
				text += text2;
			}
		}
		else if (number >= 1000000L)
		{
			text2 = mResources.million;
			long num2 = number % 1000000L / 10000L;
			number /= 1000000L;
			text = number + string.Empty;
			if (num2 >= 10L)
			{
				if (num2 % 10L == 0L)
				{
					num2 /= 10L;
				}
				string text3 = text;
				text = string.Concat(new object[]
				{
					text3,
					",",
					num2,
					text2
				});
			}
			else if (num2 > 0L)
			{
				string text3 = text;
				text = string.Concat(new object[]
				{
					text3,
					",0",
					num2,
					text2
				});
			}
			else
			{
				text += text2;
			}
		}
		else if (number >= 10000L)
		{
			text2 = "k";
			long num3 = number % 1000L / 10L;
			number /= 1000L;
			text = number + string.Empty;
			if (num3 >= 10L)
			{
				if (num3 % 10L == 0L)
				{
					num3 /= 10L;
				}
				string text3 = text;
				text = string.Concat(new object[]
				{
					text3,
					",",
					num3,
					text2
				});
			}
			else if (num3 > 0L)
			{
				string text3 = text;
				text = string.Concat(new object[]
				{
					text3,
					",0",
					num3,
					text2
				});
			}
			else
			{
				text += text2;
			}
		}
		else
		{
			text = number + string.Empty;
		}
		return text;
	}

	// Token: 0x04001076 RID: 4214
	private static short[] sinz = new short[]
	{
		0,
		18,
		36,
		54,
		71,
		89,
		107,
		125,
		143,
		160,
		178,
		195,
		213,
		230,
		248,
		265,
		282,
		299,
		316,
		333,
		350,
		367,
		384,
		400,
		416,
		433,
		449,
		465,
		481,
		496,
		512,
		527,
		543,
		558,
		573,
		587,
		602,
		616,
		630,
		644,
		658,
		672,
		685,
		698,
		711,
		724,
		737,
		749,
		761,
		773,
		784,
		796,
		807,
		818,
		828,
		839,
		849,
		859,
		868,
		878,
		887,
		896,
		904,
		912,
		920,
		928,
		935,
		943,
		949,
		956,
		962,
		968,
		974,
		979,
		984,
		989,
		994,
		998,
		1002,
		1005,
		1008,
		1011,
		1014,
		1016,
		1018,
		1020,
		1022,
		1023,
		1023,
		1024,
		1024
	};

	// Token: 0x04001077 RID: 4215
	private static short[] cosz;

	// Token: 0x04001078 RID: 4216
	private static int[] tanz;

	// Token: 0x04001079 RID: 4217
	public static int count;

	// Token: 0x0400107A RID: 4218
	public static bool isIcon;

	// Token: 0x0400107B RID: 4219
	public static bool isBig;

	// Token: 0x0400107C RID: 4220
	public static MyVector debug = new MyVector();

	// Token: 0x0400107D RID: 4221
	public static MyRandom r = new MyRandom();
}
