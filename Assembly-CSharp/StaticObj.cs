using System;

// Token: 0x020000BD RID: 189
public class StaticObj
{
	// Token: 0x040010C7 RID: 4295
	public static int TOP_CENTER = mGraphics.TOP | mGraphics.HCENTER;

	// Token: 0x040010C8 RID: 4296
	public static int TOP_LEFT = mGraphics.TOP | mGraphics.LEFT;

	// Token: 0x040010C9 RID: 4297
	public static int TOP_RIGHT = mGraphics.TOP | mGraphics.RIGHT;

	// Token: 0x040010CA RID: 4298
	public static int BOTTOM_HCENTER = mGraphics.BOTTOM | mGraphics.HCENTER;

	// Token: 0x040010CB RID: 4299
	public static int BOTTOM_LEFT = mGraphics.BOTTOM | mGraphics.LEFT;

	// Token: 0x040010CC RID: 4300
	public static int BOTTOM_RIGHT = mGraphics.BOTTOM | mGraphics.RIGHT;

	// Token: 0x040010CD RID: 4301
	public static int VCENTER_HCENTER = mGraphics.VCENTER | mGraphics.HCENTER;

	// Token: 0x040010CE RID: 4302
	public static int VCENTER_LEFT = mGraphics.VCENTER | mGraphics.LEFT;

	// Token: 0x040010CF RID: 4303
	public const string SAVE_SKILL = "skill";

	// Token: 0x040010D0 RID: 4304
	public const string SAVE_VERSIONUPDATE = "versionUpdate";

	// Token: 0x040010D1 RID: 4305
	public const string SAVE_KEYKILL = "keyskill";

	// Token: 0x040010D2 RID: 4306
	public const string SAVE_ITEM = "item";

	// Token: 0x040010D3 RID: 4307
	public const int NORMAL = 0;

	// Token: 0x040010D4 RID: 4308
	public const int UP_FALL = 1;

	// Token: 0x040010D5 RID: 4309
	public const int UP_RUN = 2;

	// Token: 0x040010D6 RID: 4310
	public const int FALL_RIGHT = 3;

	// Token: 0x040010D7 RID: 4311
	public const int FALL_LEFT = 4;

	// Token: 0x040010D8 RID: 4312
	public const int MOD_ATTACK_ME = 100;

	// Token: 0x040010D9 RID: 4313
	public const int TYPE_PLAYER = 3;

	// Token: 0x040010DA RID: 4314
	public const int TYPE_NON = 0;

	// Token: 0x040010DB RID: 4315
	public const int TYPE_VUKHI = 1;

	// Token: 0x040010DC RID: 4316
	public const int TYPE_AO = 2;

	// Token: 0x040010DD RID: 4317
	public const int TYPE_LIEN = 3;

	// Token: 0x040010DE RID: 4318
	public const int TYPE_TAY = 4;

	// Token: 0x040010DF RID: 4319
	public const int TYPE_NHAN = 5;

	// Token: 0x040010E0 RID: 4320
	public const int TYPE_QUAN = 6;

	// Token: 0x040010E1 RID: 4321
	public const int TYPE_BOI = 7;

	// Token: 0x040010E2 RID: 4322
	public const int TYPE_GIAY = 8;

	// Token: 0x040010E3 RID: 4323
	public const int TYPE_PHU = 9;

	// Token: 0x040010E4 RID: 4324
	public const int TYPE_OTHER = 11;

	// Token: 0x040010E5 RID: 4325
	public const int TYPE_CRYSTAL = 15;

	// Token: 0x040010E6 RID: 4326
	public const int FOCUS_MOD = 1;

	// Token: 0x040010E7 RID: 4327
	public const int FOCUS_ITEM = 2;

	// Token: 0x040010E8 RID: 4328
	public const int FOCUS_PLAYER = 3;

	// Token: 0x040010E9 RID: 4329
	public const int FOCUS_ZONE = 4;

	// Token: 0x040010EA RID: 4330
	public const int FOCUS_NPC = 5;

	// Token: 0x040010EB RID: 4331
	public static int[][] TYPEBG = new int[][]
	{
		new int[4],
		new int[]
		{
			1,
			1,
			1,
			1
		},
		new int[4],
		new int[]
		{
			2,
			2,
			2,
			2
		},
		new int[]
		{
			3,
			3,
			3,
			3
		},
		new int[]
		{
			4,
			-1,
			-1,
			4
		},
		new int[]
		{
			5,
			5,
			5,
			-1
		},
		new int[]
		{
			6,
			6,
			6,
			5
		},
		new int[]
		{
			7,
			7,
			-1,
			-1
		},
		new int[]
		{
			8,
			8,
			8,
			7
		},
		new int[]
		{
			9,
			-1,
			-1,
			8
		},
		new int[]
		{
			10,
			-1,
			-1,
			9
		},
		new int[]
		{
			11,
			-1,
			-1,
			-1
		}
	};

	// Token: 0x040010EC RID: 4332
	public static int[] SKYCOLOR = new int[]
	{
		1618168,
		1938102,
		43488,
		16316528,
		1628316,
		3270903,
		3576979,
		6999725,
		14594155,
		8562616,
		16026508,
		1052688,
		13952747,
		15268088,
		1628316,
		2631752,
		4079166
	};
}
