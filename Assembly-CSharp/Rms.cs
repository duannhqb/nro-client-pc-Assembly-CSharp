using System;
using System.IO;
using System.Threading;
using UnityEngine;

// Token: 0x02000017 RID: 23
public class Rms
{
	// Token: 0x06000087 RID: 135 RVA: 0x00003ED4 File Offset: 0x000020D4
	public static void saveRMS(string filename, sbyte[] data)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			Rms.__saveRMS(filename, data);
		}
		else
		{
			Rms._saveRMS(filename, data);
		}
	}

	// Token: 0x06000088 RID: 136 RVA: 0x00003F02 File Offset: 0x00002102
	public static sbyte[] loadRMS(string filename)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			return Rms.__loadRMS(filename);
		}
		return Rms._loadRMS(filename);
	}

	// Token: 0x06000089 RID: 137 RVA: 0x00009230 File Offset: 0x00007430
	public static string loadRMSString(string fileName)
	{
		sbyte[] array = Rms.loadRMS(fileName);
		if (array == null)
		{
			return null;
		}
		DataInputStream dataInputStream = new DataInputStream(array);
		try
		{
			string result = dataInputStream.readUTF();
			dataInputStream.close();
			return result;
		}
		catch (Exception ex)
		{
			Cout.println(ex.StackTrace);
		}
		return null;
	}

	// Token: 0x0600008A RID: 138 RVA: 0x00008494 File Offset: 0x00006694
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

	// Token: 0x0600008B RID: 139 RVA: 0x00009290 File Offset: 0x00007490
	public static void saveRMSString(string filename, string data)
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeUTF(data);
			Rms.saveRMS(filename, dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
			Cout.println(ex.StackTrace);
		}
	}

	// Token: 0x0600008C RID: 140 RVA: 0x000092E4 File Offset: 0x000074E4
	private static void _saveRMS(string filename, sbyte[] data)
	{
		if (Rms.status != 0)
		{
			Debug.LogError("Cannot save RMS " + filename + " because current is saving " + Rms.filename);
			return;
		}
		Rms.filename = filename;
		Rms.data = data;
		Rms.status = 2;
		int i;
		for (i = 0; i < 500; i++)
		{
			Thread.Sleep(5);
			if (Rms.status == 0)
			{
				break;
			}
		}
		if (i == 500)
		{
			Debug.LogError("TOO LONG TO SAVE RMS " + filename);
		}
	}

	// Token: 0x0600008D RID: 141 RVA: 0x00009370 File Offset: 0x00007570
	private static sbyte[] _loadRMS(string filename)
	{
		if (Rms.status != 0)
		{
			Debug.LogError("Cannot load RMS " + filename + " because current is loading " + Rms.filename);
			return null;
		}
		Rms.filename = filename;
		Rms.data = null;
		Rms.status = 3;
		int i;
		for (i = 0; i < 500; i++)
		{
			Thread.Sleep(5);
			if (Rms.status == 0)
			{
				break;
			}
		}
		if (i == 500)
		{
			Debug.LogError("TOO LONG TO LOAD RMS " + filename);
		}
		return Rms.data;
	}

	// Token: 0x0600008E RID: 142 RVA: 0x00009400 File Offset: 0x00007600
	public static void update()
	{
		if (Rms.status == 2)
		{
			Rms.status = 1;
			Rms.__saveRMS(Rms.filename, Rms.data);
			Rms.status = 0;
		}
		else if (Rms.status == 3)
		{
			Rms.status = 1;
			Rms.data = Rms.__loadRMS(Rms.filename);
			Rms.status = 0;
		}
	}

	// Token: 0x0600008F RID: 143 RVA: 0x00009460 File Offset: 0x00007660
	public static int loadRMSInt(string file)
	{
		sbyte[] array = Rms.loadRMS(file);
		return (array != null) ? ((int)array[0]) : -1;
	}

	// Token: 0x06000090 RID: 144 RVA: 0x00009484 File Offset: 0x00007684
	public static void saveRMSInt(string file, int x)
	{
		try
		{
			Rms.saveRMS(file, new sbyte[]
			{
				(sbyte)x
			});
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000091 RID: 145 RVA: 0x00003F2A File Offset: 0x0000212A
	public static string GetiPhoneDocumentsPath()
	{
		return Application.persistentDataPath;
	}

	// Token: 0x06000092 RID: 146 RVA: 0x000094C0 File Offset: 0x000076C0
	private static void __saveRMS(string filename, sbyte[] data)
	{
		string text = Rms.GetiPhoneDocumentsPath() + "/" + filename;
		FileStream fileStream = new FileStream(text, FileMode.Create);
		fileStream.Write(ArrayCast.cast(data), 0, data.Length);
		fileStream.Flush();
		fileStream.Close();
		Main.setBackupIcloud(text);
	}

	// Token: 0x06000093 RID: 147 RVA: 0x00009508 File Offset: 0x00007708
	private static sbyte[] __loadRMS(string filename)
	{
		sbyte[] result;
		try
		{
			FileStream fileStream = new FileStream(Rms.GetiPhoneDocumentsPath() + "/" + filename, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			sbyte[] array2 = ArrayCast.cast(array);
			result = ArrayCast.cast(array);
		}
		catch (Exception ex)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000094 RID: 148 RVA: 0x00009578 File Offset: 0x00007778
	public static void clearAll()
	{
		Cout.LogError3("clean rms");
		foreach (FileInfo fileInfo in new DirectoryInfo(Rms.GetiPhoneDocumentsPath() + "/").GetFiles())
		{
			fileInfo.Delete();
		}
	}

	// Token: 0x06000095 RID: 149 RVA: 0x000095C8 File Offset: 0x000077C8
	public static void DeleteStorage(string path)
	{
		try
		{
			File.Delete(Rms.GetiPhoneDocumentsPath() + "/" + path);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000096 RID: 150 RVA: 0x00009608 File Offset: 0x00007808
	public static string ByteArrayToString(byte[] ba)
	{
		string text = BitConverter.ToString(ba);
		return text.Replace("-", string.Empty);
	}

	// Token: 0x06000097 RID: 151 RVA: 0x0000962C File Offset: 0x0000782C
	public static byte[] StringToByteArray(string hex)
	{
		int length = hex.Length;
		byte[] array = new byte[length / 2];
		for (int i = 0; i < length; i += 2)
		{
			array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
		}
		return array;
	}

	// Token: 0x06000098 RID: 152 RVA: 0x00009670 File Offset: 0x00007870
	public static void deleteRecord(string name)
	{
		try
		{
			PlayerPrefs.DeleteKey(name);
		}
		catch (Exception ex)
		{
			Cout.println("loi xoa RMS --------------------------" + ex.ToString());
		}
	}

	// Token: 0x06000099 RID: 153 RVA: 0x000096B4 File Offset: 0x000078B4
	public static void clearRMS()
	{
		Rms.deleteRecord("data");
		Rms.deleteRecord("dataVersion");
		Rms.deleteRecord("map");
		Rms.deleteRecord("mapVersion");
		Rms.deleteRecord("skill");
		Rms.deleteRecord("killVersion");
		Rms.deleteRecord("item");
		Rms.deleteRecord("itemVersion");
	}

	// Token: 0x0600009A RID: 154 RVA: 0x00003F31 File Offset: 0x00002131
	public static void saveIP(string strID)
	{
		Rms.saveRMSString("NRIPlink", strID);
	}

	// Token: 0x0600009B RID: 155 RVA: 0x00009714 File Offset: 0x00007914
	public static string loadIP()
	{
		string text = Rms.loadRMSString("NRIPlink");
		if (text == null)
		{
			return null;
		}
		return text;
	}

	// Token: 0x0400004D RID: 77
	public static int status;

	// Token: 0x0400004E RID: 78
	public static sbyte[] data;

	// Token: 0x0400004F RID: 79
	public static string filename;

	// Token: 0x04000050 RID: 80
	private const int INTERVAL = 5;

	// Token: 0x04000051 RID: 81
	private const int MAXTIME = 500;
}
