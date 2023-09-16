using System;
using System.Text;
using UnityEngine;

// Token: 0x0200002E RID: 46
public class myReader
{
	// Token: 0x060001DF RID: 479 RVA: 0x0000397C File Offset: 0x00001B7C
	public myReader()
	{
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x00004A5F File Offset: 0x00002C5F
	public myReader(sbyte[] data)
	{
		this.buffer = data;
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x00011AA4 File Offset: 0x0000FCA4
	public myReader(string filename)
	{
		TextAsset textAsset = (TextAsset)Resources.Load(filename, typeof(TextAsset));
		this.buffer = mSystem.convertToSbyte(textAsset.bytes);
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x00011AE0 File Offset: 0x0000FCE0
	public sbyte readSByte()
	{
		if (this.posRead < this.buffer.Length)
		{
			return this.buffer[this.posRead++];
		}
		this.posRead = this.buffer.Length;
		throw new Exception(" loi doc sbyte eof ");
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x00004A6E File Offset: 0x00002C6E
	public sbyte readsbyte()
	{
		return this.readSByte();
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x00004A6E File Offset: 0x00002C6E
	public sbyte readByte()
	{
		return this.readSByte();
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x00004A76 File Offset: 0x00002C76
	public void mark(int readlimit)
	{
		this.posMark = this.posRead;
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x00004A84 File Offset: 0x00002C84
	public void reset()
	{
		this.posRead = this.posMark;
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x00004A92 File Offset: 0x00002C92
	public byte readUnsignedByte()
	{
		return myReader.convertSbyteToByte(this.readSByte());
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x00011B34 File Offset: 0x0000FD34
	public short readShort()
	{
		short num = 0;
		for (int i = 0; i < 2; i++)
		{
			num = (short)(num << 8);
			num |= (short)(255 & (int)this.buffer[this.posRead++]);
		}
		return num;
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x00011B80 File Offset: 0x0000FD80
	public ushort readUnsignedShort()
	{
		ushort num = 0;
		for (int i = 0; i < 2; i++)
		{
			num = (ushort)(num << 8);
			num |= (ushort)(255 & (int)this.buffer[this.posRead++]);
		}
		return num;
	}

	// Token: 0x060001EA RID: 490 RVA: 0x00011BCC File Offset: 0x0000FDCC
	public int readInt()
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			num <<= 8;
			num |= (255 & (int)this.buffer[this.posRead++]);
		}
		return num;
	}

	// Token: 0x060001EB RID: 491 RVA: 0x00011C14 File Offset: 0x0000FE14
	public long readLong()
	{
		long num = 0L;
		for (int i = 0; i < 8; i++)
		{
			num <<= 8;
			num |= (long)(255 & (int)this.buffer[this.posRead++]);
		}
		return num;
	}

	// Token: 0x060001EC RID: 492 RVA: 0x00004A9F File Offset: 0x00002C9F
	public bool readBool()
	{
		return (int)this.readSByte() > 0;
	}

	// Token: 0x060001ED RID: 493 RVA: 0x00004A9F File Offset: 0x00002C9F
	public bool readBoolean()
	{
		return (int)this.readSByte() > 0;
	}

	// Token: 0x060001EE RID: 494 RVA: 0x00011C60 File Offset: 0x0000FE60
	public string readString()
	{
		short num = this.readShort();
		byte[] array = new byte[(int)num];
		for (int i = 0; i < (int)num; i++)
		{
			array[i] = myReader.convertSbyteToByte(this.readSByte());
		}
		UTF8Encoding utf8Encoding = new UTF8Encoding();
		return utf8Encoding.GetString(array);
	}

	// Token: 0x060001EF RID: 495 RVA: 0x00011C60 File Offset: 0x0000FE60
	public string readStringUTF()
	{
		short num = this.readShort();
		byte[] array = new byte[(int)num];
		for (int i = 0; i < (int)num; i++)
		{
			array[i] = myReader.convertSbyteToByte(this.readSByte());
		}
		UTF8Encoding utf8Encoding = new UTF8Encoding();
		return utf8Encoding.GetString(array);
	}

	// Token: 0x060001F0 RID: 496 RVA: 0x00004AB5 File Offset: 0x00002CB5
	public string readUTF()
	{
		return this.readStringUTF();
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x00004ABD File Offset: 0x00002CBD
	public int read()
	{
		if (this.posRead < this.buffer.Length)
		{
			return (int)this.readSByte();
		}
		return -1;
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x00011CA8 File Offset: 0x0000FEA8
	public int read(ref sbyte[] data)
	{
		if (data == null)
		{
			return 0;
		}
		int num = 0;
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = this.readSByte();
			if (this.posRead > this.buffer.Length)
			{
				return -1;
			}
			num++;
		}
		return num;
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x00011CFC File Offset: 0x0000FEFC
	public void readFully(ref sbyte[] data)
	{
		if (data == null || data.Length + this.posRead > this.buffer.Length)
		{
			return;
		}
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = this.readSByte();
		}
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x00004ADB File Offset: 0x00002CDB
	public int available()
	{
		return this.buffer.Length - this.posRead;
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x00003B40 File Offset: 0x00001D40
	public static byte convertSbyteToByte(sbyte var)
	{
		if ((int)var > 0)
		{
			return (byte)var;
		}
		return (byte)((int)var + 256);
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x00008494 File Offset: 0x00006694
	public static byte[] convertSbyteToByte(sbyte[] var)
	{
		byte[] array = new byte[var.Length];
		for (int i = 0; i < var.Length; i++)
		{
			if ((int)var[i] > 0)
			{
				array[i] = (byte)var[i];
			}
			else
			{
				array[i] = (byte)((int)var[i] + 256);
			}
		}
		return array;
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x00004AEC File Offset: 0x00002CEC
	public void Close()
	{
		this.buffer = null;
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x00004AEC File Offset: 0x00002CEC
	public void close()
	{
		this.buffer = null;
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x00011D48 File Offset: 0x0000FF48
	public void read(ref sbyte[] data, int arg1, int arg2)
	{
		if (data == null)
		{
			return;
		}
		for (int i = 0; i < arg2; i++)
		{
			data[i + arg1] = this.readSByte();
			if (this.posRead > this.buffer.Length)
			{
				return;
			}
		}
	}

	// Token: 0x040001DE RID: 478
	public sbyte[] buffer;

	// Token: 0x040001DF RID: 479
	private int posRead;

	// Token: 0x040001E0 RID: 480
	private int posMark;

	// Token: 0x040001E1 RID: 481
	private static string fileName;

	// Token: 0x040001E2 RID: 482
	private static int status;
}
