using System;

// Token: 0x02000080 RID: 128
public class Skills
{
	// Token: 0x060003EF RID: 1007 RVA: 0x00005A99 File Offset: 0x00003C99
	public static void add(Skill skill)
	{
		Skills.skills.put(skill.skillId, skill);
	}

	// Token: 0x060003F0 RID: 1008 RVA: 0x00005AB1 File Offset: 0x00003CB1
	public static Skill get(short skillId)
	{
		return (Skill)Skills.skills.get(skillId);
	}

	// Token: 0x040006D5 RID: 1749
	public static MyHashTable skills = new MyHashTable();
}
