using System;

// Token: 0x02000010 RID: 16
public class MyStream
{
	// Token: 0x0600006D RID: 109 RVA: 0x00009174 File Offset: 0x00007374
	public static DataInputStream readFile(string path)
	{
		path = Main.res + path;
		DataInputStream result;
		try
		{
			result = DataInputStream.getResourceAsStream(path);
		}
		catch (Exception ex)
		{
			result = null;
		}
		return result;
	}
}
