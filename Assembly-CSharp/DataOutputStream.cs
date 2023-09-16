using System;

// Token: 0x02000005 RID: 5
public class DataOutputStream
{
	// Token: 0x06000022 RID: 34 RVA: 0x00003A83 File Offset: 0x00001C83
	public void writeShort(short i)
	{
		this.w.writeShort(i);
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00003A91 File Offset: 0x00001C91
	public void writeInt(int i)
	{
		this.w.writeInt(i);
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00003A9F File Offset: 0x00001C9F
	public void write(sbyte[] data)
	{
		this.w.writeSByte(data);
	}

	// Token: 0x06000025 RID: 37 RVA: 0x00003AAD File Offset: 0x00001CAD
	public sbyte[] toByteArray()
	{
		return this.w.getData();
	}

	// Token: 0x06000026 RID: 38 RVA: 0x00003ABA File Offset: 0x00001CBA
	public void close()
	{
		this.w.Close();
	}

	// Token: 0x06000027 RID: 39 RVA: 0x00003AC7 File Offset: 0x00001CC7
	public void writeByte(sbyte b)
	{
		this.w.writeByte(b);
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00003AD5 File Offset: 0x00001CD5
	public void writeUTF(string name)
	{
		this.w.writeUTF(name);
	}

	// Token: 0x06000029 RID: 41 RVA: 0x00003AE3 File Offset: 0x00001CE3
	public void writeBoolean(bool b)
	{
		this.w.writeBoolean(b);
	}

	// Token: 0x04000008 RID: 8
	private myWriter w = new myWriter();
}
