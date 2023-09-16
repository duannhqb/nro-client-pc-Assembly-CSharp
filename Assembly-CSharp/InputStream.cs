using System;

// Token: 0x0200000A RID: 10
public class InputStream : myReader
{
	// Token: 0x06000051 RID: 81 RVA: 0x00003BD5 File Offset: 0x00001DD5
	public InputStream()
	{
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00003BDD File Offset: 0x00001DDD
	public InputStream(sbyte[] data)
	{
		this.buffer = data;
	}

	// Token: 0x06000053 RID: 83 RVA: 0x00003BEC File Offset: 0x00001DEC
	public InputStream(string filename) : base(filename)
	{
	}
}
