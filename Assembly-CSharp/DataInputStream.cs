﻿using System;
using System.Threading;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class DataInputStream
{
	// Token: 0x0600000C RID: 12 RVA: 0x00008164 File Offset: 0x00006364
	public DataInputStream(string filename)
	{
		TextAsset textAsset = (TextAsset)Resources.Load(filename, typeof(TextAsset));
		this.r = new myReader(ArrayCast.cast(textAsset.bytes));
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00003986 File Offset: 0x00001B86
	public DataInputStream(sbyte[] data)
	{
		this.r = new myReader(data);
	}

	// Token: 0x0600000E RID: 14 RVA: 0x0000399A File Offset: 0x00001B9A
	public static void update()
	{
		if (DataInputStream.status == 2)
		{
			DataInputStream.status = 1;
			DataInputStream.istemp = DataInputStream.__getResourceAsStream(DataInputStream.filenametemp);
			DataInputStream.status = 0;
		}
	}

	// Token: 0x0600000F RID: 15 RVA: 0x000039C2 File Offset: 0x00001BC2
	public static DataInputStream getResourceAsStream(string filename)
	{
		return DataInputStream.__getResourceAsStream(filename);
	}

	// Token: 0x06000010 RID: 16 RVA: 0x000081A4 File Offset: 0x000063A4
	private static DataInputStream _getResourceAsStream(string filename)
	{
		if (DataInputStream.status != 0)
		{
			for (int i = 0; i < 500; i++)
			{
				Thread.Sleep(5);
				if (DataInputStream.status == 0)
				{
					break;
				}
			}
			if (DataInputStream.status != 0)
			{
				Debug.LogError("CANNOT GET INPUTSTREAM " + filename + " WHEN GETTING " + DataInputStream.filenametemp);
				return null;
			}
		}
		DataInputStream.istemp = null;
		DataInputStream.filenametemp = filename;
		DataInputStream.status = 2;
		int j;
		for (j = 0; j < 500; j++)
		{
			Thread.Sleep(5);
			if (DataInputStream.status == 0)
			{
				break;
			}
		}
		if (j == 500)
		{
			Debug.LogError("TOO LONG FOR CREATE INPUTSTREAM " + filename);
			DataInputStream.status = 0;
			return null;
		}
		return DataInputStream.istemp;
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00008274 File Offset: 0x00006474
	private static DataInputStream __getResourceAsStream(string filename)
	{
		DataInputStream result;
		try
		{
			result = new DataInputStream(filename);
		}
		catch (Exception ex)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000039CA File Offset: 0x00001BCA
	public short readShort()
	{
		return this.r.readShort();
	}

	// Token: 0x06000013 RID: 19 RVA: 0x000039D7 File Offset: 0x00001BD7
	public int readInt()
	{
		return this.r.readInt();
	}

	// Token: 0x06000014 RID: 20 RVA: 0x000039E4 File Offset: 0x00001BE4
	public int read()
	{
		return (int)this.r.readUnsignedByte();
	}

	// Token: 0x06000015 RID: 21 RVA: 0x000039F1 File Offset: 0x00001BF1
	public void read(ref sbyte[] data)
	{
		this.r.read(ref data);
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00003A00 File Offset: 0x00001C00
	public void close()
	{
		this.r.Close();
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00003A00 File Offset: 0x00001C00
	public void Close()
	{
		this.r.Close();
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00003A0D File Offset: 0x00001C0D
	public string readUTF()
	{
		return this.r.readUTF();
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00003A1A File Offset: 0x00001C1A
	public sbyte readByte()
	{
		return this.r.readByte();
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00003A27 File Offset: 0x00001C27
	public long readLong()
	{
		return this.r.readLong();
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00003A34 File Offset: 0x00001C34
	public bool readBoolean()
	{
		return this.r.readBoolean();
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00003A41 File Offset: 0x00001C41
	public int readUnsignedByte()
	{
		return (int)((byte)this.r.readByte());
	}

	// Token: 0x0600001D RID: 29 RVA: 0x00003A4F File Offset: 0x00001C4F
	public int readUnsignedShort()
	{
		return (int)this.r.readUnsignedShort();
	}

	// Token: 0x0600001E RID: 30 RVA: 0x000039F1 File Offset: 0x00001BF1
	public void readFully(ref sbyte[] data)
	{
		this.r.read(ref data);
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00003A5C File Offset: 0x00001C5C
	public int available()
	{
		return this.r.available();
	}

	// Token: 0x06000020 RID: 32 RVA: 0x00003A69 File Offset: 0x00001C69
	internal void read(ref sbyte[] byteData, int p, int size)
	{
		throw new NotImplementedException();
	}

	// Token: 0x04000002 RID: 2
	public myReader r;

	// Token: 0x04000003 RID: 3
	private const int INTERVAL = 5;

	// Token: 0x04000004 RID: 4
	private const int MAXTIME = 500;

	// Token: 0x04000005 RID: 5
	public static DataInputStream istemp;

	// Token: 0x04000006 RID: 6
	private static int status;

	// Token: 0x04000007 RID: 7
	private static string filenametemp;
}
