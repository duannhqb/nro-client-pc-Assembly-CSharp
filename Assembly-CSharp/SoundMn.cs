using System;

// Token: 0x02000084 RID: 132
public class SoundMn
{
	// Token: 0x06000406 RID: 1030 RVA: 0x00005B4C File Offset: 0x00003D4C
	public static void init(SoundMn.AssetManager ac)
	{
		Sound.setActivity(ac);
	}

	// Token: 0x06000407 RID: 1031 RVA: 0x00005B54 File Offset: 0x00003D54
	public static SoundMn gI()
	{
		if (SoundMn.gIz == null)
		{
			SoundMn.gIz = new SoundMn();
		}
		return SoundMn.gIz;
	}

	// Token: 0x06000408 RID: 1032 RVA: 0x0002316C File Offset: 0x0002136C
	public void loadSound(int mapID)
	{
		Sound.init(new int[]
		{
			SoundMn.AIR_SHIP,
			SoundMn.RAIN,
			SoundMn.TAITAONANGLUONG
		}, new int[]
		{
			SoundMn.GET_ITEM,
			SoundMn.MOVE,
			SoundMn.LOW_PUNCH,
			SoundMn.LOW_KICK,
			SoundMn.FLY,
			SoundMn.JUMP,
			SoundMn.PANEL_OPEN,
			SoundMn.BUTTON_CLOSE,
			SoundMn.BUTTON_CLICK,
			SoundMn.MEDIUM_PUNCH,
			SoundMn.MEDIUM_KICK,
			SoundMn.PANEL_OPEN,
			SoundMn.EAT_PEAN,
			SoundMn.OPEN_DIALOG,
			SoundMn.NORMAL_KAME,
			SoundMn.NAMEK_KAME,
			SoundMn.XAYDA_KAME,
			SoundMn.EXPLODE_1,
			SoundMn.EXPLODE_2,
			SoundMn.TRAIDAT_KAME,
			SoundMn.HP_UP,
			SoundMn.THAIDUONGHASAN,
			SoundMn.HOISINH,
			SoundMn.GONG,
			SoundMn.KHICHAY,
			SoundMn.BIG_EXPLODE,
			SoundMn.NAMEK_LAZER,
			SoundMn.NAMEK_CHARGE,
			SoundMn.RADAR_CLICK,
			SoundMn.RADAR_ITEM
		});
	}

	// Token: 0x06000409 RID: 1033 RVA: 0x000232A8 File Offset: 0x000214A8
	public void getSoundOption()
	{
		if (GameCanvas.loginScr.isLogin2 && global::Char.myCharz().taskMaint != null && global::Char.myCharz().taskMaint.taskId >= 2)
		{
			Panel.strTool = new string[]
			{
				mResources.radaCard,
				mResources.quayso,
				mResources.gameInfo,
				mResources.change_flag,
				mResources.change_zone,
				mResources.chat_world,
				mResources.account,
				mResources.option,
				mResources.change_account,
				mResources.REGISTOPROTECT
			};
			if (global::Char.myCharz().havePet)
			{
				Panel.strTool = new string[]
				{
					mResources.radaCard,
					mResources.quayso,
					mResources.gameInfo,
					mResources.pet,
					mResources.change_flag,
					mResources.change_zone,
					mResources.chat_world,
					mResources.account,
					mResources.option,
					mResources.change_account,
					mResources.REGISTOPROTECT
				};
			}
		}
		else
		{
			Panel.strTool = new string[]
			{
				mResources.radaCard,
				mResources.quayso,
				mResources.gameInfo,
				mResources.change_flag,
				mResources.change_zone,
				mResources.chat_world,
				mResources.account,
				mResources.option,
				mResources.change_account
			};
			if (global::Char.myCharz().havePet)
			{
				Panel.strTool = new string[]
				{
					mResources.radaCard,
					mResources.quayso,
					mResources.gameInfo,
					mResources.pet,
					mResources.change_flag,
					mResources.change_zone,
					mResources.chat_world,
					mResources.account,
					mResources.option,
					mResources.change_account
				};
			}
		}
	}

	// Token: 0x0600040A RID: 1034 RVA: 0x00023480 File Offset: 0x00021680
	public void getStrOption()
	{
		if (Main.isPC)
		{
			Panel.strCauhinh = new string[]
			{
				(!global::Char.isPaintAura) ? mResources.aura_on : mResources.aura_off,
				(!GameCanvas.isPlaySound) ? mResources.turnOnSound : mResources.turnOffSound,
				(mGraphics.zoomLevel <= 1) ? mResources.x2Screen : mResources.x1Screen
			};
		}
		else
		{
			Panel.strCauhinh = new string[]
			{
				(!global::Char.isPaintAura) ? mResources.aura_on : mResources.aura_off,
				(!GameCanvas.isPlaySound) ? mResources.turnOnSound : mResources.turnOffSound,
				(GameScr.isAnalog != 0) ? mResources.turnOffAnalog : mResources.turnOnAnalog
			};
		}
	}

	// Token: 0x0600040B RID: 1035 RVA: 0x00005B6F File Offset: 0x00003D6F
	public void HP_MPup()
	{
		Sound.playSound(SoundMn.HP_UP, 0.5f);
	}

	// Token: 0x0600040C RID: 1036 RVA: 0x0002355C File Offset: 0x0002175C
	public void charPunch(bool isKick, float volumn)
	{
		if (!global::Char.myCharz().me)
		{
			SoundMn.volume /= 2;
		}
		if (volumn <= 0f)
		{
			volumn = 0.01f;
		}
		int num = Res.random(0, 3);
		if (isKick)
		{
			Sound.playSound((num != 0) ? SoundMn.MEDIUM_KICK : SoundMn.LOW_KICK, 0.1f);
		}
		else
		{
			Sound.playSound((num != 0) ? SoundMn.MEDIUM_PUNCH : SoundMn.LOW_PUNCH, 0.1f);
		}
		this.poolCount++;
	}

	// Token: 0x0600040D RID: 1037 RVA: 0x00005B80 File Offset: 0x00003D80
	public void thaiduonghasan()
	{
		Sound.playSound(SoundMn.THAIDUONGHASAN, 0.5f);
		this.poolCount++;
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x00005B9F File Offset: 0x00003D9F
	public void rain()
	{
		Sound.playMus(SoundMn.RAIN, 0.3f, true);
	}

	// Token: 0x0600040F RID: 1039 RVA: 0x00005BB1 File Offset: 0x00003DB1
	public void gongName()
	{
		Sound.playSound(SoundMn.NAMEK_CHARGE, 0.3f);
		this.poolCount++;
	}

	// Token: 0x06000410 RID: 1040 RVA: 0x00005BD0 File Offset: 0x00003DD0
	public void gong()
	{
		Sound.playSound(SoundMn.GONG, 0.2f);
		this.poolCount++;
	}

	// Token: 0x06000411 RID: 1041 RVA: 0x00005BEF File Offset: 0x00003DEF
	public void getItem()
	{
		Sound.playSound(SoundMn.GET_ITEM, 0.3f);
		this.poolCount++;
	}

	// Token: 0x06000412 RID: 1042 RVA: 0x000235F8 File Offset: 0x000217F8
	public void soundToolOption()
	{
		GameCanvas.isPlaySound = !GameCanvas.isPlaySound;
		if (GameCanvas.isPlaySound)
		{
			SoundMn.gI().loadSound(TileMap.mapID);
			Rms.saveRMSInt("isPlaySound", 1);
		}
		else
		{
			SoundMn.gI().closeSound();
			Rms.saveRMSInt("isPlaySound", 0);
		}
		this.getStrOption();
	}

	// Token: 0x06000413 RID: 1043 RVA: 0x00005C0E File Offset: 0x00003E0E
	public void AuraToolOption()
	{
		if (global::Char.isPaintAura)
		{
			Rms.saveRMSInt("isPaintAura", 0);
			global::Char.isPaintAura = false;
		}
		else
		{
			Rms.saveRMSInt("isPaintAura", 1);
			global::Char.isPaintAura = true;
		}
		this.getStrOption();
	}

	// Token: 0x06000414 RID: 1044 RVA: 0x00003984 File Offset: 0x00001B84
	public void update()
	{
	}

	// Token: 0x06000415 RID: 1045 RVA: 0x00005C47 File Offset: 0x00003E47
	public void closeSound()
	{
		Sound.stopAll = true;
		this.stopAll();
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x00005C55 File Offset: 0x00003E55
	public void openSound()
	{
		if (Sound.music == null)
		{
			this.loadSound(0);
		}
		Sound.stopAll = false;
	}

	// Token: 0x06000417 RID: 1047 RVA: 0x00005C6E File Offset: 0x00003E6E
	public void bigeExlode()
	{
		Sound.playSound(SoundMn.BIG_EXPLODE, 0.5f);
		this.poolCount++;
	}

	// Token: 0x06000418 RID: 1048 RVA: 0x00005C8D File Offset: 0x00003E8D
	public void explode_1()
	{
		Sound.playSound(SoundMn.EXPLODE_1, 0.5f);
		this.poolCount++;
	}

	// Token: 0x06000419 RID: 1049 RVA: 0x00005C8D File Offset: 0x00003E8D
	public void explode_2()
	{
		Sound.playSound(SoundMn.EXPLODE_1, 0.5f);
		this.poolCount++;
	}

	// Token: 0x0600041A RID: 1050 RVA: 0x00005CAC File Offset: 0x00003EAC
	public void traidatKame()
	{
		Sound.playSound(SoundMn.TRAIDAT_KAME, 1f);
		this.poolCount++;
	}

	// Token: 0x0600041B RID: 1051 RVA: 0x00005CCB File Offset: 0x00003ECB
	public void namekKame()
	{
		Sound.playSound(SoundMn.NAMEK_KAME, 0.3f);
		this.poolCount++;
	}

	// Token: 0x0600041C RID: 1052 RVA: 0x00005CEA File Offset: 0x00003EEA
	public void nameLazer()
	{
		Sound.playSound(SoundMn.NAMEK_LAZER, 0.3f);
		this.poolCount++;
	}

	// Token: 0x0600041D RID: 1053 RVA: 0x00005D09 File Offset: 0x00003F09
	public void xaydaKame()
	{
		Sound.playSound(SoundMn.XAYDA_KAME, 0.3f);
		this.poolCount++;
	}

	// Token: 0x0600041E RID: 1054 RVA: 0x00023658 File Offset: 0x00021858
	public void mobKame(int type)
	{
		int id = SoundMn.XAYDA_KAME;
		if (type == 13)
		{
			id = SoundMn.NORMAL_KAME;
		}
		Sound.playSound(id, 0.1f);
		this.poolCount++;
	}

	// Token: 0x0600041F RID: 1055 RVA: 0x00023694 File Offset: 0x00021894
	public void charRun(float volumn)
	{
		if (!global::Char.myCharz().me)
		{
			SoundMn.volume /= 2;
			if (volumn <= 0f)
			{
				volumn = 0.01f;
			}
		}
		if (GameCanvas.gameTick % 8 == 0)
		{
			Sound.playSound(SoundMn.MOVE, volumn);
			this.poolCount++;
		}
	}

	// Token: 0x06000420 RID: 1056 RVA: 0x00005D28 File Offset: 0x00003F28
	public void monkeyRun(float volumn)
	{
		if (GameCanvas.gameTick % 8 == 0)
		{
			Sound.playSound(SoundMn.KHICHAY, 0.2f);
			this.poolCount++;
		}
	}

	// Token: 0x06000421 RID: 1057 RVA: 0x00005D53 File Offset: 0x00003F53
	public void charFall()
	{
		Sound.playSound(SoundMn.MOVE, 0.1f);
		this.poolCount++;
	}

	// Token: 0x06000422 RID: 1058 RVA: 0x00005D72 File Offset: 0x00003F72
	public void charJump()
	{
		Sound.playSound(SoundMn.MOVE, 0.2f);
		this.poolCount++;
	}

	// Token: 0x06000423 RID: 1059 RVA: 0x00005D91 File Offset: 0x00003F91
	public void panelOpen()
	{
		Sound.playSound(SoundMn.PANEL_OPEN, 0.5f);
		this.poolCount++;
	}

	// Token: 0x06000424 RID: 1060 RVA: 0x00005DB0 File Offset: 0x00003FB0
	public void buttonClose()
	{
		Sound.playSound(SoundMn.BUTTON_CLOSE, 0.5f);
		this.poolCount++;
	}

	// Token: 0x06000425 RID: 1061 RVA: 0x00005DCF File Offset: 0x00003FCF
	public void buttonClick()
	{
		Sound.playSound(SoundMn.BUTTON_CLICK, 0.5f);
		this.poolCount++;
	}

	// Token: 0x06000426 RID: 1062 RVA: 0x00003984 File Offset: 0x00001B84
	public void stopMove()
	{
	}

	// Token: 0x06000427 RID: 1063 RVA: 0x00005DEE File Offset: 0x00003FEE
	public void charFly()
	{
		Sound.playSound(SoundMn.FLY, 0.2f);
		this.poolCount++;
	}

	// Token: 0x06000428 RID: 1064 RVA: 0x00003984 File Offset: 0x00001B84
	public void stopFly()
	{
	}

	// Token: 0x06000429 RID: 1065 RVA: 0x00005DB0 File Offset: 0x00003FB0
	public void openMenu()
	{
		Sound.playSound(SoundMn.BUTTON_CLOSE, 0.5f);
		this.poolCount++;
	}

	// Token: 0x0600042A RID: 1066 RVA: 0x00005E0D File Offset: 0x0000400D
	public void panelClick()
	{
		Sound.playSound(SoundMn.PANEL_CLICK, 0.5f);
		this.poolCount++;
	}

	// Token: 0x0600042B RID: 1067 RVA: 0x00005E2C File Offset: 0x0000402C
	public void eatPeans()
	{
		Sound.playSound(SoundMn.EAT_PEAN, 0.5f);
		this.poolCount++;
	}

	// Token: 0x0600042C RID: 1068 RVA: 0x00005E4B File Offset: 0x0000404B
	public void openDialog()
	{
		Sound.playSound(SoundMn.OPEN_DIALOG, 0.5f);
	}

	// Token: 0x0600042D RID: 1069 RVA: 0x00005E5C File Offset: 0x0000405C
	public void hoisinh()
	{
		Sound.playSound(SoundMn.HOISINH, 0.5f);
		this.poolCount++;
	}

	// Token: 0x0600042E RID: 1070 RVA: 0x00005E7B File Offset: 0x0000407B
	public void taitao()
	{
		Sound.playMus(SoundMn.TAITAONANGLUONG, 0.5f, true);
	}

	// Token: 0x0600042F RID: 1071 RVA: 0x00003984 File Offset: 0x00001B84
	public void taitaoPause()
	{
	}

	// Token: 0x06000430 RID: 1072 RVA: 0x000236F4 File Offset: 0x000218F4
	public bool isPlayRain()
	{
		bool result;
		try
		{
			result = Sound.isPlayingSound();
		}
		catch (Exception ex)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000431 RID: 1073 RVA: 0x00003C68 File Offset: 0x00001E68
	public bool isPlayAirShip()
	{
		return false;
	}

	// Token: 0x06000432 RID: 1074 RVA: 0x00005E8D File Offset: 0x0000408D
	public void airShip()
	{
		SoundMn.cout++;
		if (SoundMn.cout % 2 == 0)
		{
			Sound.playMus(SoundMn.AIR_SHIP, 0.3f, false);
		}
	}

	// Token: 0x06000433 RID: 1075 RVA: 0x00003984 File Offset: 0x00001B84
	public void pauseAirShip()
	{
	}

	// Token: 0x06000434 RID: 1076 RVA: 0x00003984 File Offset: 0x00001B84
	public void resumeAirShip()
	{
	}

	// Token: 0x06000435 RID: 1077 RVA: 0x00005EB7 File Offset: 0x000040B7
	public void stopAll()
	{
		Sound.stopAllz();
	}

	// Token: 0x06000436 RID: 1078 RVA: 0x00005EBE File Offset: 0x000040BE
	public void backToRegister()
	{
		Session_ME.gI().close();
		GameCanvas.panel.hide();
		GameCanvas.loginScr.actRegister();
		GameCanvas.loginScr.switchToMe();
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x00005EE8 File Offset: 0x000040E8
	public void newKame()
	{
		this.poolCount++;
		if (this.poolCount % 15 == 0)
		{
			Sound.playSound(SoundMn.TRAIDAT_KAME, 0.5f);
		}
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x00005F15 File Offset: 0x00004115
	public void radarClick()
	{
		Sound.playSound(SoundMn.RADAR_CLICK, 0.5f);
	}

	// Token: 0x06000439 RID: 1081 RVA: 0x00005F26 File Offset: 0x00004126
	public void radarItem()
	{
		Sound.playSound(SoundMn.RADAR_ITEM, 0.5f);
	}

	// Token: 0x040006E5 RID: 1765
	public static SoundMn gIz;

	// Token: 0x040006E6 RID: 1766
	public static bool isSound = true;

	// Token: 0x040006E7 RID: 1767
	public static int volume;

	// Token: 0x040006E8 RID: 1768
	private static int MAX_VOLUME = 10;

	// Token: 0x040006E9 RID: 1769
	public static SoundMn.MediaPlayer[] music;

	// Token: 0x040006EA RID: 1770
	public static SoundMn.SoundPool[] sound;

	// Token: 0x040006EB RID: 1771
	public static int[] soundID;

	// Token: 0x040006EC RID: 1772
	public static int AIR_SHIP;

	// Token: 0x040006ED RID: 1773
	public static int RAIN = 1;

	// Token: 0x040006EE RID: 1774
	public static int TAITAONANGLUONG = 2;

	// Token: 0x040006EF RID: 1775
	public static int GET_ITEM;

	// Token: 0x040006F0 RID: 1776
	public static int MOVE = 1;

	// Token: 0x040006F1 RID: 1777
	public static int LOW_PUNCH = 2;

	// Token: 0x040006F2 RID: 1778
	public static int LOW_KICK = 3;

	// Token: 0x040006F3 RID: 1779
	public static int FLY = 4;

	// Token: 0x040006F4 RID: 1780
	public static int JUMP = 5;

	// Token: 0x040006F5 RID: 1781
	public static int PANEL_OPEN = 6;

	// Token: 0x040006F6 RID: 1782
	public static int BUTTON_CLOSE = 7;

	// Token: 0x040006F7 RID: 1783
	public static int BUTTON_CLICK = 8;

	// Token: 0x040006F8 RID: 1784
	public static int MEDIUM_PUNCH = 9;

	// Token: 0x040006F9 RID: 1785
	public static int MEDIUM_KICK = 10;

	// Token: 0x040006FA RID: 1786
	public static int PANEL_CLICK = 11;

	// Token: 0x040006FB RID: 1787
	public static int EAT_PEAN = 12;

	// Token: 0x040006FC RID: 1788
	public static int OPEN_DIALOG = 13;

	// Token: 0x040006FD RID: 1789
	public static int NORMAL_KAME = 14;

	// Token: 0x040006FE RID: 1790
	public static int NAMEK_KAME = 15;

	// Token: 0x040006FF RID: 1791
	public static int XAYDA_KAME = 16;

	// Token: 0x04000700 RID: 1792
	public static int EXPLODE_1 = 17;

	// Token: 0x04000701 RID: 1793
	public static int EXPLODE_2 = 18;

	// Token: 0x04000702 RID: 1794
	public static int TRAIDAT_KAME = 19;

	// Token: 0x04000703 RID: 1795
	public static int HP_UP = 20;

	// Token: 0x04000704 RID: 1796
	public static int THAIDUONGHASAN = 21;

	// Token: 0x04000705 RID: 1797
	public static int HOISINH = 22;

	// Token: 0x04000706 RID: 1798
	public static int GONG = 23;

	// Token: 0x04000707 RID: 1799
	public static int KHICHAY = 24;

	// Token: 0x04000708 RID: 1800
	public static int BIG_EXPLODE = 25;

	// Token: 0x04000709 RID: 1801
	public static int NAMEK_LAZER = 26;

	// Token: 0x0400070A RID: 1802
	public static int NAMEK_CHARGE = 27;

	// Token: 0x0400070B RID: 1803
	public static int RADAR_CLICK = 28;

	// Token: 0x0400070C RID: 1804
	public static int RADAR_ITEM = 29;

	// Token: 0x0400070D RID: 1805
	public bool freePool;

	// Token: 0x0400070E RID: 1806
	public int poolCount;

	// Token: 0x0400070F RID: 1807
	public static int cout = 1;

	// Token: 0x02000085 RID: 133
	public class MediaPlayer
	{
	}

	// Token: 0x02000086 RID: 134
	public class SoundPool
	{
	}

	// Token: 0x02000087 RID: 135
	public class AssetManager
	{
	}
}
