using System;

// Token: 0x02000059 RID: 89
public class Friend
{
	// Token: 0x060002EA RID: 746 RVA: 0x00005081 File Offset: 0x00003281
	public Friend(string friendName, sbyte type)
	{
		this.friendName = friendName;
		this.type = type;
	}

	// Token: 0x060002EB RID: 747 RVA: 0x00005097 File Offset: 0x00003297
	public Friend(string friendName)
	{
		this.friendName = friendName;
		this.type = 2;
	}

	// Token: 0x040004D6 RID: 1238
	public string friendName;

	// Token: 0x040004D7 RID: 1239
	public sbyte type;
}
