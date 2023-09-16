using System;

// Token: 0x0200008C RID: 140
public class TaskOrder
{
	// Token: 0x06000445 RID: 1093 RVA: 0x00005F3F File Offset: 0x0000413F
	public TaskOrder(sbyte taskId, short count, short maxCount, string name, string description, sbyte killId, sbyte mapId)
	{
		this.count = (int)count;
		this.maxCount = maxCount;
		this.taskId = (int)taskId;
		this.name = name;
		this.description = description;
		this.killId = (int)killId;
		this.mapId = (int)mapId;
	}

	// Token: 0x04000719 RID: 1817
	public const sbyte TASK_DAY = 0;

	// Token: 0x0400071A RID: 1818
	public const sbyte TASK_BOSS = 1;

	// Token: 0x0400071B RID: 1819
	public int taskId;

	// Token: 0x0400071C RID: 1820
	public int count;

	// Token: 0x0400071D RID: 1821
	public short maxCount;

	// Token: 0x0400071E RID: 1822
	public string name;

	// Token: 0x0400071F RID: 1823
	public string description;

	// Token: 0x04000720 RID: 1824
	public int killId;

	// Token: 0x04000721 RID: 1825
	public int mapId;
}
