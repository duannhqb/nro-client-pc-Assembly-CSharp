using System;

// Token: 0x0200007C RID: 124
public class SkillOption
{
	// Token: 0x060003E7 RID: 999 RVA: 0x00022950 File Offset: 0x00020B50
	public string getOptionString()
	{
		if (this.optionString == null)
		{
			this.optionString = NinjaUtil.replace(this.optionTemplate.name, "#", string.Empty + this.param);
		}
		return this.optionString;
	}

	// Token: 0x040006C1 RID: 1729
	public int param;

	// Token: 0x040006C2 RID: 1730
	public SkillOptionTemplate optionTemplate;

	// Token: 0x040006C3 RID: 1731
	public string optionString;
}
