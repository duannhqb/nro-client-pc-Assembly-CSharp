using System;

// Token: 0x02000095 RID: 149
public class NinjaUtil
{
	// Token: 0x0600047D RID: 1149 RVA: 0x0000607A File Offset: 0x0000427A
	public static void onLoadMapComplete()
	{
		GameCanvas.endDlg();
	}

	// Token: 0x0600047E RID: 1150 RVA: 0x00006081 File Offset: 0x00004281
	public void onLoading()
	{
		GameCanvas.startWaitDlg(mResources.downloading_data);
	}

	// Token: 0x0600047F RID: 1151 RVA: 0x0003C278 File Offset: 0x0003A478
	public static int randomNumber(int max)
	{
		MyRandom myRandom = new MyRandom();
		return myRandom.nextInt(max);
	}

	// Token: 0x06000480 RID: 1152 RVA: 0x0003C294 File Offset: 0x0003A494
	public static sbyte[] readByteArray(Message msg)
	{
		try
		{
			int num = msg.reader().readInt();
			sbyte[] result = new sbyte[num];
			msg.reader().read(ref result);
			return result;
		}
		catch (Exception ex)
		{
			Cout.LogError("LOI DOC readByteArray NINJAUTIL");
		}
		return null;
	}

	// Token: 0x06000481 RID: 1153 RVA: 0x0003C2EC File Offset: 0x0003A4EC
	public static sbyte[] readByteArray(myReader dos)
	{
		try
		{
			int num = dos.readInt();
			sbyte[] result = new sbyte[num];
			dos.read(ref result);
			return result;
		}
		catch (Exception ex)
		{
			Cout.LogError("LOI DOC readByteArray dos  NINJAUTIL");
		}
		return null;
	}

	// Token: 0x06000482 RID: 1154 RVA: 0x0000608D File Offset: 0x0000428D
	public static string replace(string text, string regex, string replacement)
	{
		return text.Replace(regex, replacement);
	}

	// Token: 0x06000483 RID: 1155 RVA: 0x0003C33C File Offset: 0x0003A53C
	public static string numberTostring(string number)
	{
		string text = string.Empty;
		string str = string.Empty;
		if (number.Equals(string.Empty))
		{
			return text;
		}
		if (number[0] == '-')
		{
			str = "-";
			number = number.Substring(1);
		}
		for (int i = number.Length - 1; i >= 0; i--)
		{
			if ((number.Length - 1 - i) % 3 == 0 && number.Length - 1 - i > 0)
			{
				text = number[i] + "." + text;
			}
			else
			{
				text = number[i] + text;
			}
		}
		return str + text;
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x0003C3F8 File Offset: 0x0003A5F8
	public static string getDate(int second)
	{
		long num = (long)second * 1000L;
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		DateTime dateTime2 = dateTime.Add(new TimeSpan(num * 10000L)).ToUniversalTime();
		int hour = dateTime2.Hour;
		int minute = dateTime2.Minute;
		int day = dateTime2.Day;
		int month = dateTime2.Month;
		int year = dateTime2.Year;
		return string.Concat(new object[]
		{
			day,
			"/",
			month,
			"/",
			year,
			" ",
			hour,
			"h"
		});
	}

	// Token: 0x06000485 RID: 1157 RVA: 0x0003C4C0 File Offset: 0x0003A6C0
	public static string getDate2(long second)
	{
		long num = second + 25200000L;
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		DateTime dateTime2 = dateTime.Add(new TimeSpan(num * 10000L)).ToUniversalTime();
		int hour = dateTime2.Hour;
		int minute = dateTime2.Minute;
		return string.Concat(new object[]
		{
			hour,
			"h",
			minute,
			"m"
		});
	}

	// Token: 0x06000486 RID: 1158 RVA: 0x0003C548 File Offset: 0x0003A748
	public static string getTime(int timeRemainS)
	{
		int num = 0;
		if (timeRemainS > 60)
		{
			num = timeRemainS / 60;
			timeRemainS %= 60;
		}
		int num2 = 0;
		if (num > 60)
		{
			num2 = num / 60;
			num %= 60;
		}
		int num3 = 0;
		if (num2 > 24)
		{
			num3 = num2 / 24;
			num2 %= 24;
		}
		string text = string.Empty;
		if (num3 > 0)
		{
			text += num3;
			text += "d";
			text = text + num2 + "h";
		}
		else if (num2 > 0)
		{
			text += num2;
			text += "h";
			text = text + num + "'";
		}
		else
		{
			if (num > 9)
			{
				text += num;
			}
			else
			{
				text = text + "0" + num;
			}
			text += ":";
			if (timeRemainS > 9)
			{
				text += timeRemainS;
			}
			else
			{
				text = text + "0" + timeRemainS;
			}
		}
		return text;
	}

	// Token: 0x06000487 RID: 1159 RVA: 0x0003C66C File Offset: 0x0003A86C
	public static string getMoneys(long m)
	{
		string text = string.Empty;
		long num = m / 1000L + 1L;
		int num2 = 0;
		while ((long)num2 < num)
		{
			if (m < 1000L)
			{
				text = m + text;
				break;
			}
			long num3 = m % 1000L;
			if (num3 == 0L)
			{
				text = ".000" + text;
			}
			else if (num3 < 10L)
			{
				text = ".00" + num3 + text;
			}
			else if (num3 < 100L)
			{
				text = ".0" + num3 + text;
			}
			else
			{
				text = "." + num3 + text;
			}
			m /= 1000L;
			num2++;
		}
		return text;
	}

	// Token: 0x06000488 RID: 1160 RVA: 0x0003C740 File Offset: 0x0003A940
	public static string getTimeAgo(int timeRemainS)
	{
		int num = 0;
		if (timeRemainS > 60)
		{
			num = timeRemainS / 60;
			timeRemainS %= 60;
		}
		int num2 = 0;
		if (num > 60)
		{
			num2 = num / 60;
			num %= 60;
		}
		int num3 = 0;
		if (num2 > 24)
		{
			num3 = num2 / 24;
			num2 %= 24;
		}
		string text = string.Empty;
		if (num3 > 0)
		{
			text += num3;
			text += "d";
			text = text + num2 + "h";
		}
		else if (num2 > 0)
		{
			text += num2;
			text += "h";
			text = text + num + "'";
		}
		else
		{
			if (num == 0)
			{
				num = 1;
			}
			text += num;
			text += "ph";
		}
		return text;
	}

	// Token: 0x06000489 RID: 1161 RVA: 0x0003C820 File Offset: 0x0003AA20
	public static string[] split(string original, string separator)
	{
		MyVector myVector = new MyVector();
		for (int i = original.IndexOf(separator); i >= 0; i = original.IndexOf(separator))
		{
			myVector.addElement(original.Substring(0, i));
			original = original.Substring(i + separator.Length);
		}
		myVector.addElement(original);
		string[] array = new string[myVector.size()];
		if (myVector.size() > 0)
		{
			for (int j = 0; j < myVector.size(); j++)
			{
				array[j] = (string)myVector.elementAt(j);
			}
		}
		return array;
	}
}
