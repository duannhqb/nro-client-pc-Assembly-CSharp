﻿using System;

// Token: 0x02000002 RID: 2
public class ArrayCast
{
	// Token: 0x06000002 RID: 2 RVA: 0x000080C8 File Offset: 0x000062C8
	public static sbyte[] cast(byte[] data)
	{
		sbyte[] array = new sbyte[data.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (sbyte)data[i];
		}
		return array;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000080FC File Offset: 0x000062FC
	public static byte[] cast(sbyte[] data)
	{
		byte[] array = new byte[data.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (byte)data[i];
		}
		return array;
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00008130 File Offset: 0x00006330
	public static char[] ToCharArray(sbyte[] data)
	{
		char[] array = new char[data.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (char)data[i];
		}
		return array;
	}
}
