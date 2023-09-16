using System;

// Token: 0x02000054 RID: 84
public class EffectChar
{
	// Token: 0x060002E3 RID: 739 RVA: 0x0000502E File Offset: 0x0000322E
	public EffectChar(sbyte templateId, int timeStart, int timeLenght, short param)
	{
		this.template = EffectChar.effTemplates[(int)templateId];
		this.timeStart = timeStart;
		this.timeLenght = timeLenght / 1000;
		this.param = param;
	}

	// Token: 0x040004C1 RID: 1217
	public static EffectTemplate[] effTemplates;

	// Token: 0x040004C2 RID: 1218
	public static sbyte EFF_ME;

	// Token: 0x040004C3 RID: 1219
	public static sbyte EFF_FRIEND = 1;

	// Token: 0x040004C4 RID: 1220
	public int timeStart;

	// Token: 0x040004C5 RID: 1221
	public int timeLenght;

	// Token: 0x040004C6 RID: 1222
	public short param;

	// Token: 0x040004C7 RID: 1223
	public EffectTemplate template;
}
