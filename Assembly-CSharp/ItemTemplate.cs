using System;

// Token: 0x02000063 RID: 99
public class ItemTemplate
{
	// Token: 0x06000355 RID: 853 RVA: 0x0001DA24 File Offset: 0x0001BC24
	public ItemTemplate(short templateID, sbyte type, sbyte gender, string name, string description, sbyte level, int strRequire, short iconID, short part, bool isUpToUp)
	{
		this.id = templateID;
		this.type = type;
		this.gender = gender;
		this.name = name;
		this.name = Res.changeString(this.name);
		this.description = description;
		this.description = Res.changeString(this.description);
		this.level = level;
		this.strRequire = strRequire;
		this.iconID = iconID;
		this.part = part;
		this.isUpToUp = isUpToUp;
	}

	// Token: 0x04000589 RID: 1417
	public short id;

	// Token: 0x0400058A RID: 1418
	public sbyte type;

	// Token: 0x0400058B RID: 1419
	public sbyte gender;

	// Token: 0x0400058C RID: 1420
	public string name;

	// Token: 0x0400058D RID: 1421
	public string[] subName;

	// Token: 0x0400058E RID: 1422
	public string description;

	// Token: 0x0400058F RID: 1423
	public sbyte level;

	// Token: 0x04000590 RID: 1424
	public short iconID;

	// Token: 0x04000591 RID: 1425
	public short part;

	// Token: 0x04000592 RID: 1426
	public bool isUpToUp;

	// Token: 0x04000593 RID: 1427
	public int w;

	// Token: 0x04000594 RID: 1428
	public int h;

	// Token: 0x04000595 RID: 1429
	public int strRequire;
}
