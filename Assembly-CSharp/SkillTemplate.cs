using System;

// Token: 0x0200007F RID: 127
public class SkillTemplate
{
	// Token: 0x060003EB RID: 1003 RVA: 0x00005A66 File Offset: 0x00003C66
	public bool isBuffToPlayer()
	{
		return this.type == 2;
	}

	// Token: 0x060003EC RID: 1004 RVA: 0x00005A77 File Offset: 0x00003C77
	public bool isUseAlone()
	{
		return this.type == 3;
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x00005A88 File Offset: 0x00003C88
	public bool isAttackSkill()
	{
		return this.type == 1;
	}

	// Token: 0x040006CB RID: 1739
	public sbyte id;

	// Token: 0x040006CC RID: 1740
	public int classId;

	// Token: 0x040006CD RID: 1741
	public string name;

	// Token: 0x040006CE RID: 1742
	public int maxPoint;

	// Token: 0x040006CF RID: 1743
	public int manaUseType;

	// Token: 0x040006D0 RID: 1744
	public int type;

	// Token: 0x040006D1 RID: 1745
	public int iconId;

	// Token: 0x040006D2 RID: 1746
	public string[] description;

	// Token: 0x040006D3 RID: 1747
	public Skill[] skills;

	// Token: 0x040006D4 RID: 1748
	public string damInfo;
}
