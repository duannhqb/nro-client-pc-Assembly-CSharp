using System;

// Token: 0x02000013 RID: 19
public class TouchScreenKeyboard
{
	// Token: 0x06000083 RID: 131 RVA: 0x00003ED1 File Offset: 0x000020D1
	public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType t, bool b1, bool b2, bool type, bool b3, string caption)
	{
		return null;
	}

	// Token: 0x06000084 RID: 132 RVA: 0x00003984 File Offset: 0x00001B84
	public static void Clear()
	{
	}

	// Token: 0x0400002A RID: 42
	public static bool hideInput;

	// Token: 0x0400002B RID: 43
	public static bool visible;

	// Token: 0x0400002C RID: 44
	public bool done;

	// Token: 0x0400002D RID: 45
	public bool active;

	// Token: 0x0400002E RID: 46
	public string text;
}
