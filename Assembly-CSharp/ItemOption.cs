using System;

// Token: 0x02000061 RID: 97
public class ItemOption
{
	// Token: 0x0600034E RID: 846 RVA: 0x0000397C File Offset: 0x00001B7C
	public ItemOption()
	{
	}

	// Token: 0x0600034F RID: 847 RVA: 0x000053B0 File Offset: 0x000035B0
	public ItemOption(int optionTemplateId, int param)
	{
		this.param = param;
		this.optionTemplate = GameScr.gI().iOptionTemplates[optionTemplateId];
	}

	// Token: 0x06000350 RID: 848 RVA: 0x000053D1 File Offset: 0x000035D1
	public string getOptionString()
	{
		return NinjaUtil.replace(this.optionTemplate.name, "#", this.param + string.Empty);
	}

	// Token: 0x06000351 RID: 849 RVA: 0x000053FD File Offset: 0x000035FD
	public string getOptionName()
	{
		return NinjaUtil.replace(this.optionTemplate.name, "+#", string.Empty);
	}

	// Token: 0x06000352 RID: 850 RVA: 0x00005419 File Offset: 0x00003619
	public string getOptiongColor()
	{
		return NinjaUtil.replace(this.optionTemplate.name, "$", string.Empty);
	}

	// Token: 0x06000353 RID: 851 RVA: 0x0001D624 File Offset: 0x0001B824
	public string getOptionShopstring()
	{
		string result = string.Empty;
		if (this.optionTemplate.id == 0 || this.optionTemplate.id == 1 || this.optionTemplate.id == 21 || this.optionTemplate.id == 22 || this.optionTemplate.id == 23 || this.optionTemplate.id == 24 || this.optionTemplate.id == 25 || this.optionTemplate.id == 26)
		{
			int num = this.param - 50 + 1;
			result = string.Concat(new object[]
			{
				NinjaUtil.replace(this.optionTemplate.name, "#", this.param + string.Empty),
				" (",
				num,
				"-",
				this.param,
				")"
			});
		}
		else if (this.optionTemplate.id == 6 || this.optionTemplate.id == 7 || this.optionTemplate.id == 8 || this.optionTemplate.id == 9 || this.optionTemplate.id == 19)
		{
			int num = this.param - 10 + 1;
			result = string.Concat(new object[]
			{
				NinjaUtil.replace(this.optionTemplate.name, "#", this.param + string.Empty),
				" (",
				num,
				"-",
				this.param,
				")"
			});
		}
		else if (this.optionTemplate.id == 2 || this.optionTemplate.id == 3 || this.optionTemplate.id == 4 || this.optionTemplate.id == 5 || this.optionTemplate.id == 10 || this.optionTemplate.id == 11 || this.optionTemplate.id == 12 || this.optionTemplate.id == 13 || this.optionTemplate.id == 14 || this.optionTemplate.id == 15 || this.optionTemplate.id == 17 || this.optionTemplate.id == 18 || this.optionTemplate.id == 20)
		{
			int num = this.param - 5 + 1;
			result = string.Concat(new object[]
			{
				NinjaUtil.replace(this.optionTemplate.name, "#", this.param + string.Empty),
				" (",
				num,
				"-",
				this.param,
				")"
			});
		}
		else if (this.optionTemplate.id == 16)
		{
			int num = this.param - 3 + 1;
			result = string.Concat(new object[]
			{
				NinjaUtil.replace(this.optionTemplate.name, "#", this.param + string.Empty),
				" (",
				num,
				"-",
				this.param,
				")"
			});
		}
		else
		{
			result = NinjaUtil.replace(this.optionTemplate.name, "#", this.param + string.Empty);
		}
		return result;
	}

	// Token: 0x04000582 RID: 1410
	public int param;

	// Token: 0x04000583 RID: 1411
	public sbyte active;

	// Token: 0x04000584 RID: 1412
	public sbyte activeCard;

	// Token: 0x04000585 RID: 1413
	public ItemOptionTemplate optionTemplate;
}
