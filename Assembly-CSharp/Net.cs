using System;
using UnityEngine;

// Token: 0x02000012 RID: 18
internal class Net
{
	// Token: 0x0600007F RID: 127 RVA: 0x000091B4 File Offset: 0x000073B4
	public static void update()
	{
		if (Net.www != null && Net.www.isDone)
		{
			string str = string.Empty;
			if (Net.www.error == null || Net.www.error.Equals(string.Empty))
			{
				str = Net.www.text;
			}
			Net.www = null;
			if (Net.h != null)
			{
				Net.h.perform(str);
			}
		}
	}

	// Token: 0x06000080 RID: 128 RVA: 0x00003E95 File Offset: 0x00002095
	public static void connectHTTP(string link, Command h)
	{
		if (Net.www != null)
		{
			Cout.LogError("GET HTTP BUSY");
		}
		Net.www = new WWW(link);
		Net.h = h;
	}

	// Token: 0x06000081 RID: 129 RVA: 0x00003EBC File Offset: 0x000020BC
	public static void connectHTTP2(string link, Command h)
	{
		Net.h = h;
		if (link != null)
		{
			h.perform(link);
		}
	}

	// Token: 0x04000028 RID: 40
	public static WWW www;

	// Token: 0x04000029 RID: 41
	public static Command h;
}
