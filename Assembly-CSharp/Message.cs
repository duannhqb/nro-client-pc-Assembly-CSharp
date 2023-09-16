using System;

// Token: 0x02000024 RID: 36
public class Message
{
	// Token: 0x06000145 RID: 325 RVA: 0x0000456C File Offset: 0x0000276C
	public Message(int command)
	{
		this.command = (sbyte)command;
		this.dos = new myWriter();
	}

	// Token: 0x06000146 RID: 326 RVA: 0x00004587 File Offset: 0x00002787
	public Message()
	{
		this.dos = new myWriter();
	}

	// Token: 0x06000147 RID: 327 RVA: 0x0000459A File Offset: 0x0000279A
	public Message(sbyte command)
	{
		this.command = command;
		this.dos = new myWriter();
	}

	// Token: 0x06000148 RID: 328 RVA: 0x000045B4 File Offset: 0x000027B4
	public Message(sbyte command, sbyte[] data)
	{
		this.command = command;
		this.dis = new myReader(data);
	}

	// Token: 0x06000149 RID: 329 RVA: 0x000045CF File Offset: 0x000027CF
	public sbyte[] getData()
	{
		return this.dos.getData();
	}

	// Token: 0x0600014A RID: 330 RVA: 0x000045DC File Offset: 0x000027DC
	public myReader reader()
	{
		return this.dis;
	}

	// Token: 0x0600014B RID: 331 RVA: 0x000045E4 File Offset: 0x000027E4
	public myWriter writer()
	{
		return this.dos;
	}

	// Token: 0x0600014C RID: 332 RVA: 0x000045EC File Offset: 0x000027EC
	public int readInt3Byte()
	{
		return this.dis.readInt();
	}

	// Token: 0x0600014D RID: 333 RVA: 0x00003984 File Offset: 0x00001B84
	public void cleanup()
	{
	}

	// Token: 0x04000124 RID: 292
	public sbyte command;

	// Token: 0x04000125 RID: 293
	private myReader dis;

	// Token: 0x04000126 RID: 294
	private myWriter dos;
}
