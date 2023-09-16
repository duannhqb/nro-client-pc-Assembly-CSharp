using System;

// Token: 0x02000074 RID: 116
public class PlayerInfo
{
	// Token: 0x060003B8 RID: 952 RVA: 0x00005867 File Offset: 0x00003A67
	public string getName()
	{
		return this.name;
	}

	// Token: 0x060003B9 RID: 953 RVA: 0x0000586F File Offset: 0x00003A6F
	public void setMoney(int m)
	{
		this.xu = m;
		this.strMoney = GameCanvas.getMoneys(this.xu);
	}

	// Token: 0x060003BA RID: 954 RVA: 0x00005889 File Offset: 0x00003A89
	public void setName(string name)
	{
		this.name = name;
		if (name.Length > 9)
		{
			this.showName = name.Substring(0, 8);
		}
		else
		{
			this.showName = name;
		}
	}

	// Token: 0x060003BB RID: 955 RVA: 0x00003984 File Offset: 0x00001B84
	public void paint(mGraphics g, int x, int y)
	{
	}

	// Token: 0x060003BC RID: 956 RVA: 0x000058B9 File Offset: 0x00003AB9
	public int getExp()
	{
		return this.exp;
	}

	// Token: 0x04000646 RID: 1606
	public string name;

	// Token: 0x04000647 RID: 1607
	public string showName;

	// Token: 0x04000648 RID: 1608
	public string status;

	// Token: 0x04000649 RID: 1609
	public int IDDB;

	// Token: 0x0400064A RID: 1610
	private int exp;

	// Token: 0x0400064B RID: 1611
	public bool isReady;

	// Token: 0x0400064C RID: 1612
	public int xu;

	// Token: 0x0400064D RID: 1613
	public int gold;

	// Token: 0x0400064E RID: 1614
	public string strMoney = string.Empty;

	// Token: 0x0400064F RID: 1615
	public sbyte finishPosition;

	// Token: 0x04000650 RID: 1616
	public bool isMaster;

	// Token: 0x04000651 RID: 1617
	public static Image[] imgStart;

	// Token: 0x04000652 RID: 1618
	public sbyte[] indexLv;

	// Token: 0x04000653 RID: 1619
	public int onlineTime;
}
