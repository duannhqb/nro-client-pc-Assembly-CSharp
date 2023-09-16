using System;
using System.Text;
using UnityEngine;

// Token: 0x0200001F RID: 31
public class mSystem
{
	// Token: 0x06000107 RID: 263 RVA: 0x000043BB File Offset: 0x000025BB
	public static void resetCurInapp()
	{
		mSystem.curINAPP = 0;
	}

	// Token: 0x06000108 RID: 264 RVA: 0x000043C3 File Offset: 0x000025C3
	public static void callHotlinePC()
	{
		Application.OpenURL("http://ngocrongonline.com/");
	}

	// Token: 0x06000109 RID: 265 RVA: 0x00003984 File Offset: 0x00001B84
	public static void callHotlineJava()
	{
	}

	// Token: 0x0600010A RID: 266 RVA: 0x00003984 File Offset: 0x00001B84
	public static void callHotlineIphone()
	{
	}

	// Token: 0x0600010B RID: 267 RVA: 0x00003984 File Offset: 0x00001B84
	public static void callHotlineWindowsPhone()
	{
	}

	// Token: 0x0600010C RID: 268 RVA: 0x00003984 File Offset: 0x00001B84
	public static void closeBanner()
	{
	}

	// Token: 0x0600010D RID: 269 RVA: 0x00003984 File Offset: 0x00001B84
	public static void showBanner()
	{
	}

	// Token: 0x0600010E RID: 270 RVA: 0x00003984 File Offset: 0x00001B84
	public static void createAdmob()
	{
	}

	// Token: 0x0600010F RID: 271 RVA: 0x00003984 File Offset: 0x00001B84
	public static void checkAdComlete()
	{
	}

	// Token: 0x06000110 RID: 272 RVA: 0x000043CF File Offset: 0x000025CF
	public static void paintPopUp2(mGraphics g, int x, int y, int w, int h)
	{
		g.fillRect(x, y, w + 10, h, 0, 90);
	}

	// Token: 0x06000111 RID: 273 RVA: 0x000043E2 File Offset: 0x000025E2
	public static void arraycopy(sbyte[] scr, int scrPos, sbyte[] dest, int destPos, int lenght)
	{
		Array.Copy(scr, scrPos, dest, destPos, lenght);
	}

	// Token: 0x06000112 RID: 274 RVA: 0x0000C078 File Offset: 0x0000A278
	public static void arrayReplace(sbyte[] scr, int scrPos, ref sbyte[] dest, int destPos, int lenght)
	{
		if (scr == null || dest == null || scrPos + lenght > scr.Length)
		{
			return;
		}
		sbyte[] array = new sbyte[dest.Length + lenght];
		for (int i = 0; i < destPos; i++)
		{
			array[i] = dest[i];
		}
		for (int j = destPos; j < destPos + lenght; j++)
		{
			array[j] = scr[scrPos + j - destPos];
		}
		for (int k = destPos + lenght; k < array.Length; k++)
		{
			array[k] = dest[destPos + k - lenght];
		}
	}

	// Token: 0x06000113 RID: 275 RVA: 0x0000C108 File Offset: 0x0000A308
	public static long currentTimeMillis()
	{
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		return (DateTime.UtcNow.Ticks - dateTime.Ticks) / 10000L;
	}

	// Token: 0x06000114 RID: 276 RVA: 0x000043EF File Offset: 0x000025EF
	public static void freeData()
	{
		Resources.UnloadUnusedAssets();
		GC.Collect();
	}

	// Token: 0x06000115 RID: 277 RVA: 0x0000C148 File Offset: 0x0000A348
	public static sbyte[] convertToSbyte(byte[] scr)
	{
		sbyte[] array = new sbyte[scr.Length];
		for (int i = 0; i < scr.Length; i++)
		{
			array[i] = (sbyte)scr[i];
		}
		return array;
	}

	// Token: 0x06000116 RID: 278 RVA: 0x0000C17C File Offset: 0x0000A37C
	public static sbyte[] convertToSbyte(string scr)
	{
		ASCIIEncoding asciiencoding = new ASCIIEncoding();
		byte[] bytes = asciiencoding.GetBytes(scr);
		return mSystem.convertToSbyte(bytes);
	}

	// Token: 0x06000117 RID: 279 RVA: 0x00008494 File Offset: 0x00006694
	public static byte[] convetToByte(sbyte[] scr)
	{
		byte[] array = new byte[scr.Length];
		for (int i = 0; i < scr.Length; i++)
		{
			if ((int)scr[i] > 0)
			{
				array[i] = (byte)scr[i];
			}
			else
			{
				array[i] = (byte)((int)scr[i] + 256);
			}
		}
		return array;
	}

	// Token: 0x06000118 RID: 280 RVA: 0x0000C1A0 File Offset: 0x0000A3A0
	public static char[] ToCharArray(sbyte[] scr)
	{
		char[] array = new char[scr.Length];
		for (int i = 0; i < scr.Length; i++)
		{
			array[i] = (char)scr[i];
		}
		return array;
	}

	// Token: 0x06000119 RID: 281 RVA: 0x0000C1D4 File Offset: 0x0000A3D4
	public static int currentHour()
	{
		return DateTime.Now.Hour;
	}

	// Token: 0x0600011A RID: 282 RVA: 0x000043FC File Offset: 0x000025FC
	public static void println(object str)
	{
		Debug.Log(str);
	}

	// Token: 0x0600011B RID: 283 RVA: 0x000043EF File Offset: 0x000025EF
	public static void gcc()
	{
		Resources.UnloadUnusedAssets();
		GC.Collect();
	}

	// Token: 0x0600011C RID: 284 RVA: 0x00004404 File Offset: 0x00002604
	public static mSystem gI()
	{
		if (mSystem.instance == null)
		{
			mSystem.instance = new mSystem();
		}
		return mSystem.instance;
	}

	// Token: 0x0600011D RID: 285 RVA: 0x0000441F File Offset: 0x0000261F
	public static void onConnectOK()
	{
		Controller.isConnectOK = true;
	}

	// Token: 0x0600011E RID: 286 RVA: 0x00004427 File Offset: 0x00002627
	public static void onConnectionFail()
	{
		Controller.isConnectionFail = true;
	}

	// Token: 0x0600011F RID: 287 RVA: 0x0000442F File Offset: 0x0000262F
	public static void onDisconnected()
	{
		Controller.isDisconnected = true;
	}

	// Token: 0x06000120 RID: 288 RVA: 0x00003984 File Offset: 0x00001B84
	public static void exitWP()
	{
	}

	// Token: 0x06000121 RID: 289 RVA: 0x0000C1F0 File Offset: 0x0000A3F0
	public static void paintFlyText(mGraphics g)
	{
		for (int i = 0; i < 5; i++)
		{
			if (GameScr.flyTextState[i] != -1)
			{
				if (GameCanvas.isPaint(GameScr.flyTextX[i], GameScr.flyTextY[i]))
				{
					if (GameScr.flyTextColor[i] == mFont.RED)
					{
						mFont.bigNumber_red.drawStringBorder(g, GameScr.flyTextString[i], GameScr.flyTextX[i], GameScr.flyTextY[i], mFont.CENTER);
					}
					else if (GameScr.flyTextColor[i] == mFont.YELLOW)
					{
						mFont.bigNumber_yellow.drawStringBorder(g, GameScr.flyTextString[i], GameScr.flyTextX[i], GameScr.flyTextY[i], mFont.CENTER);
					}
					else if (GameScr.flyTextColor[i] == mFont.GREEN)
					{
						mFont.bigNumber_green.drawStringBorder(g, GameScr.flyTextString[i], GameScr.flyTextX[i], GameScr.flyTextY[i], mFont.CENTER);
					}
					else if (GameScr.flyTextColor[i] == mFont.FATAL)
					{
						mFont.bigNumber_yellow.drawStringBorder(g, GameScr.flyTextString[i], GameScr.flyTextX[i], GameScr.flyTextY[i], mFont.CENTER, mFont.bigNumber_black);
					}
					else if (GameScr.flyTextColor[i] == mFont.FATAL_ME)
					{
						mFont.bigNumber_green.drawStringBorder(g, GameScr.flyTextString[i], GameScr.flyTextX[i], GameScr.flyTextY[i], mFont.CENTER, mFont.bigNumber_black);
					}
					else if (GameScr.flyTextColor[i] == mFont.MISS)
					{
						mFont.bigNumber_While.drawStringBorder(g, GameScr.flyTextString[i], GameScr.flyTextX[i], GameScr.flyTextY[i], mFont.CENTER, mFont.tahoma_7_grey);
					}
					else if (GameScr.flyTextColor[i] == mFont.ORANGE)
					{
						mFont.bigNumber_orange.drawStringBorder(g, GameScr.flyTextString[i], GameScr.flyTextX[i], GameScr.flyTextY[i], mFont.CENTER);
					}
					else if (GameScr.flyTextColor[i] == mFont.ADDMONEY)
					{
						mFont.bigNumber_yellow.drawStringBorder(g, GameScr.flyTextString[i], GameScr.flyTextX[i], GameScr.flyTextY[i], mFont.CENTER, mFont.bigNumber_black);
					}
					else if (GameScr.flyTextColor[i] == mFont.MISS_ME)
					{
						mFont.bigNumber_While.drawStringBorder(g, GameScr.flyTextString[i], GameScr.flyTextX[i], GameScr.flyTextY[i], mFont.CENTER, mFont.bigNumber_black);
					}
					else if (GameScr.flyTextColor[i] == mFont.HP)
					{
						mFont.bigNumber_red.drawStringBorder(g, GameScr.flyTextString[i], GameScr.flyTextX[i], GameScr.flyTextY[i], mFont.CENTER, mFont.bigNumber_black);
					}
					else if (GameScr.flyTextColor[i] == mFont.MP)
					{
						mFont.bigNumber_blue.drawStringBorder(g, GameScr.flyTextString[i], GameScr.flyTextX[i], GameScr.flyTextY[i], mFont.CENTER, mFont.bigNumber_black);
					}
				}
			}
		}
	}

	// Token: 0x06000122 RID: 290 RVA: 0x00003984 File Offset: 0x00001B84
	public static void endKey()
	{
	}

	// Token: 0x06000123 RID: 291 RVA: 0x0000C4E0 File Offset: 0x0000A6E0
	public static FrameImage getFraImage(string nameImg)
	{
		FrameImage result = null;
		MainImage mainImage = null;
		if (mainImage == null)
		{
			mainImage = ImgByName.getImagePath(nameImg, ImgByName.hashImagePath);
		}
		if (mainImage.img != null)
		{
			int num = mainImage.img.getHeight() / (int)mainImage.nFrame;
			if (num < 1)
			{
				num = 1;
			}
			result = new FrameImage(mainImage.img, mainImage.img.getWidth(), num);
		}
		return result;
	}

	// Token: 0x06000124 RID: 292 RVA: 0x00004437 File Offset: 0x00002637
	public static Image loadImage(string path)
	{
		return GameCanvas.loadImage(path);
	}

	// Token: 0x040000ED RID: 237
	public static string strAdmob;

	// Token: 0x040000EE RID: 238
	public static bool loadAdOk;

	// Token: 0x040000EF RID: 239
	public static string publicID;

	// Token: 0x040000F0 RID: 240
	public static string android_pack;

	// Token: 0x040000F1 RID: 241
	public static int clientType = 4;

	// Token: 0x040000F2 RID: 242
	public static sbyte LANGUAGE;

	// Token: 0x040000F3 RID: 243
	public static sbyte curINAPP;

	// Token: 0x040000F4 RID: 244
	public static sbyte maxINAPP = 5;

	// Token: 0x040000F5 RID: 245
	public const int JAVA = 1;

	// Token: 0x040000F6 RID: 246
	public const int ANDROID = 2;

	// Token: 0x040000F7 RID: 247
	public const int IP_JB = 3;

	// Token: 0x040000F8 RID: 248
	public const int PC = 4;

	// Token: 0x040000F9 RID: 249
	public const int IP_APPSTORE = 5;

	// Token: 0x040000FA RID: 250
	public const int WINDOWS_PHONE = 6;

	// Token: 0x040000FB RID: 251
	public const int GOOGLE_PLAY = 7;

	// Token: 0x040000FC RID: 252
	public static mSystem instance;
}
