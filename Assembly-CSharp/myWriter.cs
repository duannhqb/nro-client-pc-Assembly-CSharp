using System;
using System.IO;
using System.Text;
using UnityEngine;

// Token: 0x0200002F RID: 47
public class myWriter
{
	// Token: 0x060001FC RID: 508 RVA: 0x00011D90 File Offset: 0x0000FF90
	public void writeSByte(sbyte value)
	{
		this.checkLenght(0);
		this.buffer[this.posWrite++] = value;
	}

	// Token: 0x060001FD RID: 509 RVA: 0x00011DC0 File Offset: 0x0000FFC0
	public void writeSByteUncheck(sbyte value)
	{
		this.buffer[this.posWrite++] = value;
	}

	// Token: 0x060001FE RID: 510 RVA: 0x00004B18 File Offset: 0x00002D18
	public void writeByte(sbyte value)
	{
		this.writeSByte(value);
	}

	// Token: 0x060001FF RID: 511 RVA: 0x00004B21 File Offset: 0x00002D21
	public void writeByte(int value)
	{
		this.writeSByte((sbyte)value);
	}

	// Token: 0x06000200 RID: 512 RVA: 0x00004B2B File Offset: 0x00002D2B
	public void writeChar(char value)
	{
		this.writeSByte(0);
		this.writeSByte((sbyte)value);
	}

	// Token: 0x06000201 RID: 513 RVA: 0x00004B21 File Offset: 0x00002D21
	public void writeUnsignedByte(byte value)
	{
		this.writeSByte((sbyte)value);
	}

	// Token: 0x06000202 RID: 514 RVA: 0x00011DE8 File Offset: 0x0000FFE8
	public void writeUnsignedByte(byte[] value)
	{
		this.checkLenght(value.Length);
		for (int i = 0; i < value.Length; i++)
		{
			this.writeSByteUncheck((sbyte)value[i]);
		}
	}

	// Token: 0x06000203 RID: 515 RVA: 0x00011E1C File Offset: 0x0001001C
	public void writeSByte(sbyte[] value)
	{
		this.checkLenght(value.Length);
		for (int i = 0; i < value.Length; i++)
		{
			this.writeSByteUncheck(value[i]);
		}
	}

	// Token: 0x06000204 RID: 516 RVA: 0x00011E50 File Offset: 0x00010050
	public void writeShort(short value)
	{
		this.checkLenght(2);
		for (int i = 1; i >= 0; i--)
		{
			this.writeSByteUncheck((sbyte)(value >> i * 8));
		}
	}

	// Token: 0x06000205 RID: 517 RVA: 0x00011E88 File Offset: 0x00010088
	public void writeShort(int value)
	{
		this.checkLenght(2);
		short num = (short)value;
		for (int i = 1; i >= 0; i--)
		{
			this.writeSByteUncheck((sbyte)(num >> i * 8));
		}
	}

	// Token: 0x06000206 RID: 518 RVA: 0x00011E50 File Offset: 0x00010050
	public void writeUnsignedShort(ushort value)
	{
		this.checkLenght(2);
		for (int i = 1; i >= 0; i--)
		{
			this.writeSByteUncheck((sbyte)(value >> i * 8));
		}
	}

	// Token: 0x06000207 RID: 519 RVA: 0x00011EC0 File Offset: 0x000100C0
	public void writeInt(int value)
	{
		this.checkLenght(4);
		for (int i = 3; i >= 0; i--)
		{
			this.writeSByteUncheck((sbyte)(value >> i * 8));
		}
	}

	// Token: 0x06000208 RID: 520 RVA: 0x00011EF8 File Offset: 0x000100F8
	public void writeLong(long value)
	{
		this.checkLenght(8);
		for (int i = 7; i >= 0; i--)
		{
			this.writeSByteUncheck((sbyte)(value >> i * 8));
		}
	}

	// Token: 0x06000209 RID: 521 RVA: 0x00004B3C File Offset: 0x00002D3C
	public void writeBoolean(bool value)
	{
		this.writeSByte((!value) ? 0 : 1);
	}

	// Token: 0x0600020A RID: 522 RVA: 0x00004B3C File Offset: 0x00002D3C
	public void writeBool(bool value)
	{
		this.writeSByte((!value) ? 0 : 1);
	}

	// Token: 0x0600020B RID: 523 RVA: 0x00011F30 File Offset: 0x00010130
	public void writeString(string value)
	{
		char[] array = value.ToCharArray();
		this.writeShort((short)array.Length);
		this.checkLenght(array.Length);
		for (int i = 0; i < array.Length; i++)
		{
			this.writeSByteUncheck((sbyte)array[i]);
		}
	}

	// Token: 0x0600020C RID: 524 RVA: 0x00011F78 File Offset: 0x00010178
	public void writeUTF(string value)
	{
		Encoding unicode = Encoding.Unicode;
		Encoding encoding = Encoding.GetEncoding(65001);
		byte[] bytes = unicode.GetBytes(value);
		byte[] array = Encoding.Convert(unicode, encoding, bytes);
		this.writeShort((short)array.Length);
		this.checkLenght(array.Length);
		foreach (sbyte value2 in array)
		{
			this.writeSByteUncheck(value2);
		}
	}

	// Token: 0x0600020D RID: 525 RVA: 0x00004B18 File Offset: 0x00002D18
	public void write(sbyte value)
	{
		this.writeSByte(value);
	}

	// Token: 0x0600020E RID: 526 RVA: 0x00011FE4 File Offset: 0x000101E4
	public void write(ref sbyte[] data, int arg1, int arg2)
	{
		if (data == null)
		{
			return;
		}
		for (int i = 0; i < arg2; i++)
		{
			this.writeSByte(data[i + arg1]);
			if (this.posWrite > this.buffer.Length)
			{
				return;
			}
		}
	}

	// Token: 0x0600020F RID: 527 RVA: 0x00004B51 File Offset: 0x00002D51
	public void write(sbyte[] value)
	{
		this.writeSByte(value);
	}

	// Token: 0x06000210 RID: 528 RVA: 0x0001202C File Offset: 0x0001022C
	public sbyte[] getData()
	{
		if (this.posWrite <= 0)
		{
			return null;
		}
		sbyte[] array = new sbyte[this.posWrite];
		for (int i = 0; i < this.posWrite; i++)
		{
			array[i] = this.buffer[i];
		}
		return array;
	}

	// Token: 0x06000211 RID: 529 RVA: 0x00012078 File Offset: 0x00010278
	public void checkLenght(int ltemp)
	{
		if (this.posWrite + ltemp > this.lenght)
		{
			sbyte[] array = new sbyte[this.lenght + 1024 + ltemp];
			for (int i = 0; i < this.lenght; i++)
			{
				array[i] = this.buffer[i];
			}
			this.buffer = null;
			this.buffer = array;
			this.lenght += 1024 + ltemp;
		}
	}

	// Token: 0x06000212 RID: 530 RVA: 0x000120F0 File Offset: 0x000102F0
	private static void convertString(string[] args)
	{
		string path = args[0];
		string path2 = args[1];
		using (StreamReader streamReader = new StreamReader(path, Encoding.Unicode))
		{
			using (StreamWriter streamWriter = new StreamWriter(path2, false, Encoding.UTF8))
			{
				myWriter.CopyContents(streamReader, streamWriter);
			}
		}
	}

	// Token: 0x06000213 RID: 531 RVA: 0x00012168 File Offset: 0x00010368
	private static void CopyContents(TextReader input, TextWriter output)
	{
		char[] array = new char[8192];
		int count;
		while ((count = input.Read(array, 0, array.Length)) != 0)
		{
			output.Write(array, 0, count);
		}
		output.Flush();
		string message = output.ToString();
		Debug.Log(message);
	}

	// Token: 0x06000214 RID: 532 RVA: 0x00004B5A File Offset: 0x00002D5A
	public byte convertSbyteToByte(sbyte var)
	{
		if ((int)var > 0)
		{
			return (byte)var;
		}
		return (byte)((int)var + 256);
	}

	// Token: 0x06000215 RID: 533 RVA: 0x000121B4 File Offset: 0x000103B4
	public byte[] convertSbyteToByte(sbyte[] var)
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

	// Token: 0x06000216 RID: 534 RVA: 0x00004B70 File Offset: 0x00002D70
	public void Close()
	{
		this.buffer = null;
	}

	// Token: 0x06000217 RID: 535 RVA: 0x00004B70 File Offset: 0x00002D70
	public void close()
	{
		this.buffer = null;
	}

	// Token: 0x040001E3 RID: 483
	public sbyte[] buffer = new sbyte[2048];

	// Token: 0x040001E4 RID: 484
	private int posWrite;

	// Token: 0x040001E5 RID: 485
	private int lenght = 2048;
}
