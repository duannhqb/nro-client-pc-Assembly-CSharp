using System;

// Token: 0x0200007A RID: 122
public class Skill
{
	// Token: 0x060003E3 RID: 995 RVA: 0x00022828 File Offset: 0x00020A28
	public string strTimeReplay()
	{
		if (this.coolDown % 1000 == 0)
		{
			return this.coolDown / 1000 + string.Empty;
		}
		int num = this.coolDown % 1000;
		return this.coolDown / 1000 + "." + ((num % 100 != 0) ? (num / 10) : (num / 100));
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x000228A8 File Offset: 0x00020AA8
	public void paint(int x, int y, mGraphics g)
	{
		SmallImage.drawSmallImage(g, this.template.iconId, x, y, 0, StaticObj.VCENTER_HCENTER);
		long num = mSystem.currentTimeMillis();
		long num2 = num - this.lastTimeUseThisSkill;
		if (num2 < (long)this.coolDown)
		{
			g.setColor(2721889, 0.7f);
			if (this.paintCanNotUseSkill && GameCanvas.gameTick % 6 > 2)
			{
				g.setColor(876862);
			}
			int num3 = (int)(num2 * 20L / (long)this.coolDown);
			g.fillRect(x - 10, y - 10 + num3, 20, 20 - num3);
		}
		else
		{
			this.paintCanNotUseSkill = false;
		}
	}

	// Token: 0x0400069E RID: 1694
	public const sbyte ATT_STAND = 0;

	// Token: 0x0400069F RID: 1695
	public const sbyte ATT_FLY = 1;

	// Token: 0x040006A0 RID: 1696
	public const sbyte SKILL_AUTO_USE = 0;

	// Token: 0x040006A1 RID: 1697
	public const sbyte SKILL_CLICK_USE_ATTACK = 1;

	// Token: 0x040006A2 RID: 1698
	public const sbyte SKILL_CLICK_USE_BUFF = 2;

	// Token: 0x040006A3 RID: 1699
	public const sbyte SKILL_CLICK_NPC = 3;

	// Token: 0x040006A4 RID: 1700
	public const sbyte SKILL_CLICK_LIVE = 4;

	// Token: 0x040006A5 RID: 1701
	public SkillTemplate template;

	// Token: 0x040006A6 RID: 1702
	public short skillId;

	// Token: 0x040006A7 RID: 1703
	public int point;

	// Token: 0x040006A8 RID: 1704
	public long powRequire;

	// Token: 0x040006A9 RID: 1705
	public int coolDown;

	// Token: 0x040006AA RID: 1706
	public long lastTimeUseThisSkill;

	// Token: 0x040006AB RID: 1707
	public int dx;

	// Token: 0x040006AC RID: 1708
	public int dy;

	// Token: 0x040006AD RID: 1709
	public int maxFight;

	// Token: 0x040006AE RID: 1710
	public int manaUse;

	// Token: 0x040006AF RID: 1711
	public SkillOption[] options;

	// Token: 0x040006B0 RID: 1712
	public bool paintCanNotUseSkill;

	// Token: 0x040006B1 RID: 1713
	public short damage;

	// Token: 0x040006B2 RID: 1714
	public string moreInfo;

	// Token: 0x040006B3 RID: 1715
	public short price;
}
