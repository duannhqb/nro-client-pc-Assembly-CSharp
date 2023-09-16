using System;

// Token: 0x0200008B RID: 139
public class Task
{
	// Token: 0x06000444 RID: 1092 RVA: 0x00027B54 File Offset: 0x00025D54
	public Task(short taskId, sbyte index, string name, string detail, string[] subNames, short[] counts, short count, string[] contentInfo)
	{
		this.taskId = taskId;
		this.index = (int)index;
		this.names = mFont.tahoma_7b_green2.splitFontArray(name, Panel.WIDTH_PANEL - 20);
		this.details = mFont.tahoma_7.splitFontArray(detail, Panel.WIDTH_PANEL - 20);
		this.subNames = subNames;
		this.counts = counts;
		this.count = count;
		this.contentInfo = contentInfo;
	}

	// Token: 0x04000710 RID: 1808
	public int index;

	// Token: 0x04000711 RID: 1809
	public int max;

	// Token: 0x04000712 RID: 1810
	public short[] counts;

	// Token: 0x04000713 RID: 1811
	public short taskId;

	// Token: 0x04000714 RID: 1812
	public string[] names;

	// Token: 0x04000715 RID: 1813
	public string[] details;

	// Token: 0x04000716 RID: 1814
	public string[] subNames;

	// Token: 0x04000717 RID: 1815
	public string[] contentInfo;

	// Token: 0x04000718 RID: 1816
	public short count;
}
