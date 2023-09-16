using System;
using Assets.src.g;

// Token: 0x020000A2 RID: 162
public class GameScr : mScreen, IChatable
{
	// Token: 0x0600067A RID: 1658 RVA: 0x000565FC File Offset: 0x000547FC
	public GameScr()
	{
		if (GameCanvas.w == 128 || GameCanvas.h <= 208)
		{
			GameScr.indexSize = 20;
		}
		this.cmdback = new Command(string.Empty, 11021);
		this.cmdMenu = new Command("menu", 11000);
		this.cmdFocus = new Command(string.Empty, 11001);
		this.cmdMenu.img = GameScr.imgMenu;
		this.cmdMenu.w = mGraphics.getImageWidth(this.cmdMenu.img) + 20;
		this.cmdMenu.isPlaySoundButton = false;
		this.cmdFocus.img = GameScr.imgFocus;
		if (GameCanvas.isTouch)
		{
			this.cmdMenu.x = 0;
			this.cmdMenu.y = 50;
			this.cmdFocus = null;
		}
		else
		{
			this.cmdMenu.x = 0;
			this.cmdMenu.y = GameScr.gH - 30;
			this.cmdFocus.x = GameScr.gW - 32;
			this.cmdFocus.y = GameScr.gH - 32;
		}
		this.right = this.cmdFocus;
		GameScr.isPaintRada = 1;
		if (GameCanvas.isTouch)
		{
			GameScr.isHaveSelectSkill = true;
		}
	}

	// Token: 0x0600067B RID: 1659 RVA: 0x000567D4 File Offset: 0x000549D4
	public static void loadBg()
	{
		GameScr.imgLbtn = GameCanvas.loadImage("/mainImage/myTexture2dbtnl.png");
		GameScr.imgLbtnFocus = GameCanvas.loadImage("/mainImage/myTexture2dbtnlf.png");
		GameScr.imgLbtn2 = GameCanvas.loadImage("/mainImage/myTexture2dbtnl2.png");
		GameScr.imgLbtnFocus2 = GameCanvas.loadImage("/mainImage/myTexture2dbtnlf2.png");
		GameScr.imgPanel = GameCanvas.loadImage("/mainImage/myTexture2dpanel.png");
		GameScr.imgPanel2 = GameCanvas.loadImage("/mainImage/panel2.png");
		GameScr.imgHP = GameCanvas.loadImage("/mainImage/myTexture2dHP.png");
		GameScr.imgSP = GameCanvas.loadImage("/mainImage/SP.png");
		GameScr.imgHPLost = GameCanvas.loadImage("/mainImage/myTexture2dhpLost.png");
		GameScr.imgMPLost = GameCanvas.loadImage("/mainImage/myTexture2dmpLost.png");
		GameScr.imgMP = GameCanvas.loadImage("/mainImage/myTexture2dMP.png");
		GameScr.imgSkill = GameCanvas.loadImage("/mainImage/myTexture2dskill.png");
		GameScr.imgSkill2 = GameCanvas.loadImage("/mainImage/myTexture2dskill2.png");
		GameScr.imgMenu = GameCanvas.loadImage("/mainImage/myTexture2dmenu.png");
		GameScr.imgFocus = GameCanvas.loadImage("/mainImage/myTexture2dfocus.png");
		GameScr.imgChatPC = GameCanvas.loadImage("/pc/chat.png");
		GameScr.imgChatsPC2 = GameCanvas.loadImage("/pc/chat2.png");
		if (GameCanvas.isTouch)
		{
			GameScr.imgArrow = GameCanvas.loadImage("/mainImage/myTexture2darrow.png");
			GameScr.imgArrow2 = GameCanvas.loadImage("/mainImage/myTexture2darrow2.png");
			GameScr.imgChat = GameCanvas.loadImage("/mainImage/myTexture2dchat.png");
			GameScr.imgChat2 = GameCanvas.loadImage("/mainImage/myTexture2dchat2.png");
			GameScr.imgFocus2 = GameCanvas.loadImage("/mainImage/myTexture2dfocus2.png");
			GameScr.imgHP1 = GameCanvas.loadImage("/mainImage/myTexture2dPea0.png");
			GameScr.imgHP2 = GameCanvas.loadImage("/mainImage/myTexture2dPea1.png");
			GameScr.imgAnalog1 = GameCanvas.loadImage("/mainImage/myTexture2danalog1.png");
			GameScr.imgAnalog2 = GameCanvas.loadImage("/mainImage/myTexture2danalog2.png");
			GameScr.imgHP3 = GameCanvas.loadImage("/mainImage/myTexture2dPea2.png");
			GameScr.imgHP4 = GameCanvas.loadImage("/mainImage/myTexture2dPea3.png");
			GameScr.imgFire0 = GameCanvas.loadImage("/mainImage/myTexture2dfirebtn0.png");
			GameScr.imgFire1 = GameCanvas.loadImage("/mainImage/myTexture2dfirebtn1.png");
		}
		GameScr.flyTextX = new int[5];
		GameScr.flyTextY = new int[5];
		GameScr.flyTextDx = new int[5];
		GameScr.flyTextDy = new int[5];
		GameScr.flyTextState = new int[5];
		GameScr.flyTextString = new string[5];
		GameScr.flyTextYTo = new int[5];
		GameScr.flyTime = new int[5];
		GameScr.flyTextColor = new int[8];
		for (int i = 0; i < 5; i++)
		{
			GameScr.flyTextState[i] = -1;
		}
		sbyte[] array = Rms.loadRMS("NRdataVersion");
		sbyte[] array2 = Rms.loadRMS("NRmapVersion");
		sbyte[] array3 = Rms.loadRMS("NRskillVersion");
		sbyte[] array4 = Rms.loadRMS("NRitemVersion");
		if (array != null)
		{
			GameScr.vcData = array[0];
		}
		if (array2 != null)
		{
			GameScr.vcMap = array2[0];
		}
		if (array3 != null)
		{
			GameScr.vcSkill = array3[0];
		}
		if (array4 != null)
		{
			GameScr.vcItem = array4[0];
		}
		GameScr.imgNut = GameCanvas.loadImage("/mainImage/myTexture2dnut.png");
		GameScr.imgNutF = GameCanvas.loadImage("/mainImage/myTexture2dnutF.png");
		MobCapcha.init();
		GameScr.isAnalog = ((Rms.loadRMSInt("analog") != 1) ? 0 : 1);
		GameScr.gamePad = new GamePad();
		GameScr.arrow = GameCanvas.loadImage("/mainImage/myTexture2darrow3.png");
		GameScr.imgTrans = GameCanvas.loadImage("/bg/trans.png");
		GameScr.imgRoomStat = GameCanvas.loadImage("/mainImage/myTexture2dstat.png");
		GameScr.frBarPow0 = GameCanvas.loadImage("/mainImage/myTexture2dlineColor20.png");
		GameScr.frBarPow1 = GameCanvas.loadImage("/mainImage/myTexture2dlineColor21.png");
		GameScr.frBarPow2 = GameCanvas.loadImage("/mainImage/myTexture2dlineColor22.png");
		GameScr.frBarPow20 = GameCanvas.loadImage("/mainImage/myTexture2dlineColor00.png");
		GameScr.frBarPow21 = GameCanvas.loadImage("/mainImage/myTexture2dlineColor01.png");
		GameScr.frBarPow22 = GameCanvas.loadImage("/mainImage/myTexture2dlineColor02.png");
	}

	// Token: 0x0600067C RID: 1660 RVA: 0x00006A7A File Offset: 0x00004C7A
	public void initSelectChar()
	{
		this.readPart();
		SmallImage.init();
	}

	// Token: 0x0600067D RID: 1661 RVA: 0x00056B64 File Offset: 0x00054D64
	public static void paintOngMauPercent(Image img0, Image img1, Image img2, float x, float y, int size, float pixelPercent, mGraphics g)
	{
		int clipX = g.getClipX();
		int clipY = g.getClipY();
		int clipWidth = g.getClipWidth();
		int clipHeight = g.getClipHeight();
		g.setClip((int)x, (int)y, (int)pixelPercent, 13);
		int num = size / 15 - 2;
		for (int i = 0; i < num; i++)
		{
			g.drawImage(img1, x + (float)((i + 1) * 15), y, 0);
		}
		g.drawImage(img0, x, y, 0);
		g.drawImage(img1, x + (float)size - 30f, y, 0);
		g.drawImage(img2, x + (float)size - 15f, y, 0);
		g.setClip(clipX, clipY, clipWidth, clipHeight);
	}

	// Token: 0x0600067E RID: 1662 RVA: 0x00006A87 File Offset: 0x00004C87
	public void initTraining()
	{
		if (CreateCharScr.isCreateChar)
		{
			CreateCharScr.isCreateChar = false;
			this.right = null;
		}
	}

	// Token: 0x0600067F RID: 1663 RVA: 0x00006AA0 File Offset: 0x00004CA0
	public bool isMapDocNhan()
	{
		return TileMap.mapID >= 53 && TileMap.mapID <= 62;
	}

	// Token: 0x06000680 RID: 1664 RVA: 0x00006ABD File Offset: 0x00004CBD
	public bool isMapFize()
	{
		return TileMap.mapID >= 63;
	}

	// Token: 0x06000681 RID: 1665 RVA: 0x00056C1C File Offset: 0x00054E1C
	public override void switchToMe()
	{
		GameScr.vChatVip.removeAllElements();
		ServerListScreen.isWait = false;
		if (BackgroudEffect.isHaveRain())
		{
			SoundMn.gI().rain();
		}
		LoginScr.isContinueToLogin = false;
		global::Char.isLoadingMap = false;
		if (!GameScr.isPaintOther)
		{
			Service.gI().finishLoadMap();
		}
		if (TileMap.isTrainingMap())
		{
			this.initTraining();
		}
		GameScr.info1.isUpdate = true;
		GameScr.info2.isUpdate = true;
		this.resetButton();
		GameScr.isLoadAllData = true;
		GameScr.isPaintOther = false;
		base.switchToMe();
	}

	// Token: 0x06000682 RID: 1666 RVA: 0x00056CAC File Offset: 0x00054EAC
	public static int getMaxExp(int level)
	{
		int num = 0;
		for (int i = 0; i <= level; i++)
		{
			num += (int)GameScr.exps[i];
		}
		return num;
	}

	// Token: 0x06000683 RID: 1667 RVA: 0x00056CDC File Offset: 0x00054EDC
	public static void resetAllvector()
	{
		GameScr.vCharInMap.removeAllElements();
		Teleport.vTeleport.removeAllElements();
		GameScr.vItemMap.removeAllElements();
		Effect2.vEffect2.removeAllElements();
		Effect2.vAnimateEffect.removeAllElements();
		Effect2.vEffect2Outside.removeAllElements();
		Effect2.vEffectFeet.removeAllElements();
		Effect2.vEffect3.removeAllElements();
		GameScr.vMobAttack.removeAllElements();
		GameScr.vMob.removeAllElements();
		GameScr.vNpc.removeAllElements();
		global::Char.myCharz().vMovePoints.removeAllElements();
	}

	// Token: 0x06000684 RID: 1668 RVA: 0x00003984 File Offset: 0x00001B84
	public void loadSkillShortcut()
	{
	}

	// Token: 0x06000685 RID: 1669 RVA: 0x00056D68 File Offset: 0x00054F68
	public void onOSkill(sbyte[] oSkillID)
	{
		Cout.println("GET onScreenSkill!");
		GameScr.onScreenSkill = new Skill[5];
		if (oSkillID == null)
		{
			this.loadDefaultonScreenSkill();
		}
		else
		{
			for (int i = 0; i < oSkillID.Length; i++)
			{
				for (int j = 0; j < global::Char.myCharz().vSkillFight.size(); j++)
				{
					Skill skill = (Skill)global::Char.myCharz().vSkillFight.elementAt(j);
					if ((int)skill.template.id == (int)oSkillID[i])
					{
						GameScr.onScreenSkill[i] = skill;
						break;
					}
				}
			}
		}
	}

	// Token: 0x06000686 RID: 1670 RVA: 0x00056E08 File Offset: 0x00055008
	public void onKSkill(sbyte[] kSkillID)
	{
		Cout.println("GET KEYSKILL!");
		GameScr.keySkill = new Skill[5];
		if (kSkillID == null)
		{
			this.loadDefaultKeySkill();
		}
		else
		{
			for (int i = 0; i < kSkillID.Length; i++)
			{
				for (int j = 0; j < global::Char.myCharz().vSkillFight.size(); j++)
				{
					Skill skill = (Skill)global::Char.myCharz().vSkillFight.elementAt(j);
					if ((int)skill.template.id == (int)kSkillID[i])
					{
						GameScr.keySkill[i] = skill;
						break;
					}
				}
			}
		}
	}

	// Token: 0x06000687 RID: 1671 RVA: 0x00056EA8 File Offset: 0x000550A8
	public void onCSkill(sbyte[] cSkillID)
	{
		Cout.println("GET CURRENTSKILL!");
		if (cSkillID == null || cSkillID.Length == 0)
		{
			if (global::Char.myCharz().vSkillFight.size() > 0)
			{
				global::Char.myCharz().myskill = (Skill)global::Char.myCharz().vSkillFight.elementAt(0);
			}
		}
		else
		{
			for (int i = 0; i < global::Char.myCharz().vSkillFight.size(); i++)
			{
				Skill skill = (Skill)global::Char.myCharz().vSkillFight.elementAt(i);
				if ((int)skill.template.id == (int)cSkillID[0])
				{
					global::Char.myCharz().myskill = skill;
					break;
				}
			}
		}
		if (global::Char.myCharz().myskill != null)
		{
			Service.gI().selectSkill((int)global::Char.myCharz().myskill.template.id);
			this.saveRMSCurrentSkill(global::Char.myCharz().myskill.template.id);
		}
	}

	// Token: 0x06000688 RID: 1672 RVA: 0x00056FAC File Offset: 0x000551AC
	private void loadDefaultonScreenSkill()
	{
		Cout.println("LOAD DEFAULT ONmScreen SKILL");
		for (int i = 0; i < GameScr.onScreenSkill.Length; i++)
		{
			if (i >= global::Char.myCharz().vSkillFight.size())
			{
				break;
			}
			Skill skill = (Skill)global::Char.myCharz().vSkillFight.elementAt(i);
			GameScr.onScreenSkill[i] = skill;
		}
		this.saveonScreenSkillToRMS();
	}

	// Token: 0x06000689 RID: 1673 RVA: 0x0005701C File Offset: 0x0005521C
	private void loadDefaultKeySkill()
	{
		Cout.println("LOAD DEFAULT KEY SKILL");
		for (int i = 0; i < GameScr.keySkill.Length; i++)
		{
			if (i >= global::Char.myCharz().vSkillFight.size())
			{
				break;
			}
			Skill skill = (Skill)global::Char.myCharz().vSkillFight.elementAt(i);
			GameScr.keySkill[i] = skill;
		}
		this.saveKeySkillToRMS();
	}

	// Token: 0x0600068A RID: 1674 RVA: 0x0005708C File Offset: 0x0005528C
	public void doSetOnScreenSkill(SkillTemplate skillTemplate)
	{
		Skill skill = global::Char.myCharz().getSkill(skillTemplate);
		MyVector myVector = new MyVector();
		for (int i = 0; i < 5; i++)
		{
			object[] p = new object[]
			{
				skill,
				i + string.Empty
			};
			myVector.addElement(new Command(mResources.into_place + (i + 1), 11120, p));
		}
		GameCanvas.menu.startAt(myVector, 0);
	}

	// Token: 0x0600068B RID: 1675 RVA: 0x0005710C File Offset: 0x0005530C
	public void doSetKeySkill(SkillTemplate skillTemplate)
	{
		Cout.println("DO SET KEY SKILL");
		Skill skill = global::Char.myCharz().getSkill(skillTemplate);
		string[] array = (!TField.isQwerty) ? mResources.key_skill : mResources.key_skill_qwerty;
		MyVector myVector = new MyVector();
		for (int i = 0; i < 5; i++)
		{
			object[] p = new object[]
			{
				skill,
				i + string.Empty
			};
			myVector.addElement(new Command(array[i], 11121, p));
		}
		GameCanvas.menu.startAt(myVector, 0);
	}

	// Token: 0x0600068C RID: 1676 RVA: 0x000571A4 File Offset: 0x000553A4
	public void saveonScreenSkillToRMS()
	{
		sbyte[] array = new sbyte[GameScr.onScreenSkill.Length];
		for (int i = 0; i < GameScr.onScreenSkill.Length; i++)
		{
			if (GameScr.onScreenSkill[i] == null)
			{
				array[i] = -1;
			}
			else
			{
				array[i] = GameScr.onScreenSkill[i].template.id;
			}
		}
		Service.gI().changeOnKeyScr(array);
	}

	// Token: 0x0600068D RID: 1677 RVA: 0x0005720C File Offset: 0x0005540C
	public void saveKeySkillToRMS()
	{
		sbyte[] array = new sbyte[GameScr.keySkill.Length];
		for (int i = 0; i < GameScr.keySkill.Length; i++)
		{
			if (GameScr.keySkill[i] == null)
			{
				array[i] = -1;
			}
			else
			{
				array[i] = GameScr.keySkill[i].template.id;
			}
		}
		Service.gI().changeOnKeyScr(array);
	}

	// Token: 0x0600068E RID: 1678 RVA: 0x00003984 File Offset: 0x00001B84
	public void saveRMSCurrentSkill(sbyte id)
	{
	}

	// Token: 0x0600068F RID: 1679 RVA: 0x00057274 File Offset: 0x00055474
	public void addSkillShortcut(Skill skill)
	{
		Cout.println("ADD SKILL SHORTCUT TO SKILL " + skill.template.id);
		for (int i = 0; i < GameScr.onScreenSkill.Length; i++)
		{
			if (GameScr.onScreenSkill[i] == null)
			{
				GameScr.onScreenSkill[i] = skill;
				break;
			}
		}
		for (int j = 0; j < GameScr.keySkill.Length; j++)
		{
			if (GameScr.keySkill[j] == null)
			{
				GameScr.keySkill[j] = skill;
				break;
			}
		}
		if (global::Char.myCharz().myskill == null)
		{
			global::Char.myCharz().myskill = skill;
		}
		this.saveKeySkillToRMS();
		this.saveonScreenSkillToRMS();
	}

	// Token: 0x06000690 RID: 1680 RVA: 0x00057328 File Offset: 0x00055528
	public bool isBagFull()
	{
		for (int i = global::Char.myCharz().arrItemBag.Length - 1; i >= 0; i--)
		{
			if (global::Char.myCharz().arrItemBag[i] == null)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06000691 RID: 1681 RVA: 0x00006ACE File Offset: 0x00004CCE
	public void createConfirm(string[] menu, Npc npc)
	{
		this.resetButton();
		this.isLockKey = true;
		this.left = new Command(menu[0], 130011, npc);
		this.right = new Command(menu[1], 130012, npc);
	}

	// Token: 0x06000692 RID: 1682 RVA: 0x00057368 File Offset: 0x00055568
	public void createMenu(string[] menu, Npc npc)
	{
		MyVector myVector = new MyVector();
		for (int i = 0; i < menu.Length; i++)
		{
			myVector.addElement(new Command(menu[i], 11057, npc));
		}
		GameCanvas.menu.startAt(myVector, 2);
	}

	// Token: 0x06000693 RID: 1683 RVA: 0x000573B0 File Offset: 0x000555B0
	public void readPart()
	{
		DataInputStream dataInputStream = null;
		try
		{
			dataInputStream = new DataInputStream(Rms.loadRMS("NR_part"));
			int num = (int)dataInputStream.readShort();
			GameScr.parts = new Part[num];
			for (int i = 0; i < num; i++)
			{
				int type = (int)dataInputStream.readByte();
				GameScr.parts[i] = new Part(type);
				for (int j = 0; j < GameScr.parts[i].pi.Length; j++)
				{
					GameScr.parts[i].pi[j] = new PartImage();
					GameScr.parts[i].pi[j].id = dataInputStream.readShort();
					GameScr.parts[i].pi[j].dx = dataInputStream.readByte();
					GameScr.parts[i].pi[j].dy = dataInputStream.readByte();
				}
			}
		}
		catch (Exception ex)
		{
			Cout.LogError("LOI TAI readPart " + ex.ToString());
		}
		finally
		{
			try
			{
				dataInputStream.close();
			}
			catch (Exception ex2)
			{
				Cout.LogError("LOI TAI readPart 2" + ex2.ToString());
			}
		}
	}

	// Token: 0x06000694 RID: 1684 RVA: 0x00057500 File Offset: 0x00055700
	public void readEfect()
	{
		DataInputStream dataInputStream = null;
		try
		{
			dataInputStream = new DataInputStream(Rms.loadRMS("NR_effect"));
			int num = (int)dataInputStream.readShort();
			GameScr.efs = new EffectCharPaint[num];
			for (int i = 0; i < num; i++)
			{
				GameScr.efs[i] = new EffectCharPaint();
				GameScr.efs[i].idEf = (int)dataInputStream.readShort();
				GameScr.efs[i].arrEfInfo = new EffectInfoPaint[(int)dataInputStream.readByte()];
				for (int j = 0; j < GameScr.efs[i].arrEfInfo.Length; j++)
				{
					GameScr.efs[i].arrEfInfo[j] = new EffectInfoPaint();
					GameScr.efs[i].arrEfInfo[j].idImg = (int)dataInputStream.readShort();
					GameScr.efs[i].arrEfInfo[j].dx = (int)dataInputStream.readByte();
					GameScr.efs[i].arrEfInfo[j].dy = (int)dataInputStream.readByte();
				}
			}
		}
		catch (Exception ex)
		{
		}
		finally
		{
			try
			{
				dataInputStream.close();
			}
			catch (Exception ex2)
			{
				Cout.LogError("Loi ham Eff: " + ex2.ToString());
			}
		}
	}

	// Token: 0x06000695 RID: 1685 RVA: 0x00057658 File Offset: 0x00055858
	public void readArrow()
	{
		DataInputStream dataInputStream = null;
		try
		{
			dataInputStream = new DataInputStream(Rms.loadRMS("NR_arrow"));
			int num = (int)dataInputStream.readShort();
			GameScr.arrs = new Arrowpaint[num];
			for (int i = 0; i < num; i++)
			{
				GameScr.arrs[i] = new Arrowpaint();
				GameScr.arrs[i].id = (int)dataInputStream.readShort();
				GameScr.arrs[i].imgId[0] = (int)dataInputStream.readShort();
				GameScr.arrs[i].imgId[1] = (int)dataInputStream.readShort();
				GameScr.arrs[i].imgId[2] = (int)dataInputStream.readShort();
			}
		}
		catch (Exception ex)
		{
		}
		finally
		{
			try
			{
				dataInputStream.close();
			}
			catch (Exception ex2)
			{
				Cout.LogError("Loi ham readArrow: " + ex2.ToString());
			}
		}
	}

	// Token: 0x06000696 RID: 1686 RVA: 0x00057754 File Offset: 0x00055954
	public void readDart()
	{
		DataInputStream dataInputStream = null;
		try
		{
			dataInputStream = new DataInputStream(Rms.loadRMS("NR_dart"));
			int num = (int)dataInputStream.readShort();
			GameScr.darts = new DartInfo[num];
			for (int i = 0; i < num; i++)
			{
				GameScr.darts[i] = new DartInfo();
				GameScr.darts[i].id = dataInputStream.readShort();
				GameScr.darts[i].nUpdate = dataInputStream.readShort();
				GameScr.darts[i].va = (int)(dataInputStream.readShort() * 256);
				GameScr.darts[i].xdPercent = dataInputStream.readShort();
				int num2 = (int)dataInputStream.readShort();
				GameScr.darts[i].tail = new short[num2];
				for (int j = 0; j < num2; j++)
				{
					GameScr.darts[i].tail[j] = dataInputStream.readShort();
				}
				num2 = (int)dataInputStream.readShort();
				GameScr.darts[i].tailBorder = new short[num2];
				for (int k = 0; k < num2; k++)
				{
					GameScr.darts[i].tailBorder[k] = dataInputStream.readShort();
				}
				num2 = (int)dataInputStream.readShort();
				GameScr.darts[i].xd1 = new short[num2];
				for (int l = 0; l < num2; l++)
				{
					GameScr.darts[i].xd1[l] = dataInputStream.readShort();
				}
				num2 = (int)dataInputStream.readShort();
				GameScr.darts[i].xd2 = new short[num2];
				for (int m = 0; m < num2; m++)
				{
					GameScr.darts[i].xd2[m] = dataInputStream.readShort();
				}
				num2 = (int)dataInputStream.readShort();
				GameScr.darts[i].head = new short[num2][];
				for (int n = 0; n < num2; n++)
				{
					short num3 = dataInputStream.readShort();
					GameScr.darts[i].head[n] = new short[(int)num3];
					for (int num4 = 0; num4 < (int)num3; num4++)
					{
						GameScr.darts[i].head[n][num4] = dataInputStream.readShort();
					}
				}
				num2 = (int)dataInputStream.readShort();
				GameScr.darts[i].headBorder = new short[num2][];
				for (int num5 = 0; num5 < num2; num5++)
				{
					short num6 = dataInputStream.readShort();
					GameScr.darts[i].headBorder[num5] = new short[(int)num6];
					for (int num7 = 0; num7 < (int)num6; num7++)
					{
						GameScr.darts[i].headBorder[num5][num7] = dataInputStream.readShort();
					}
				}
			}
		}
		catch (Exception ex)
		{
			Cout.LogError("Loi ham ReadDart: " + ex.ToString());
		}
		finally
		{
			try
			{
				dataInputStream.close();
			}
			catch (Exception ex2)
			{
				Cout.LogError("Loi ham reaaDart: " + ex2.ToString());
			}
		}
	}

	// Token: 0x06000697 RID: 1687 RVA: 0x00057A90 File Offset: 0x00055C90
	public void readSkill()
	{
		DataInputStream dataInputStream = null;
		try
		{
			dataInputStream = new DataInputStream(Rms.loadRMS("NR_skill"));
			int num = (int)dataInputStream.readShort();
			int num2 = Skills.skills.size();
			GameScr.sks = new SkillPaint[num2];
			for (int i = 0; i < num; i++)
			{
				short num3 = dataInputStream.readShort();
				Res.outz("skill id= " + num3);
				if (num3 == 1111)
				{
					num3 = (short)(num - 1);
				}
				GameScr.sks[(int)num3] = new SkillPaint();
				GameScr.sks[(int)num3].id = (int)num3;
				GameScr.sks[(int)num3].effectHappenOnMob = (int)dataInputStream.readShort();
				if (GameScr.sks[(int)num3].effectHappenOnMob <= 0)
				{
					GameScr.sks[(int)num3].effectHappenOnMob = 80;
				}
				GameScr.sks[(int)num3].numEff = (int)dataInputStream.readByte();
				GameScr.sks[(int)num3].skillStand = new SkillInfoPaint[(int)dataInputStream.readByte()];
				for (int j = 0; j < GameScr.sks[(int)num3].skillStand.Length; j++)
				{
					GameScr.sks[(int)num3].skillStand[j] = new SkillInfoPaint();
					GameScr.sks[(int)num3].skillStand[j].status = (int)dataInputStream.readByte();
					GameScr.sks[(int)num3].skillStand[j].effS0Id = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillStand[j].e0dx = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillStand[j].e0dy = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillStand[j].effS1Id = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillStand[j].e1dx = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillStand[j].e1dy = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillStand[j].effS2Id = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillStand[j].e2dx = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillStand[j].e2dy = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillStand[j].arrowId = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillStand[j].adx = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillStand[j].ady = (int)dataInputStream.readShort();
				}
				GameScr.sks[(int)num3].skillfly = new SkillInfoPaint[(int)dataInputStream.readByte()];
				for (int k = 0; k < GameScr.sks[(int)num3].skillfly.Length; k++)
				{
					GameScr.sks[(int)num3].skillfly[k] = new SkillInfoPaint();
					GameScr.sks[(int)num3].skillfly[k].status = (int)dataInputStream.readByte();
					GameScr.sks[(int)num3].skillfly[k].effS0Id = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillfly[k].e0dx = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillfly[k].e0dy = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillfly[k].effS1Id = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillfly[k].e1dx = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillfly[k].e1dy = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillfly[k].effS2Id = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillfly[k].e2dx = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillfly[k].e2dy = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillfly[k].arrowId = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillfly[k].adx = (int)dataInputStream.readShort();
					GameScr.sks[(int)num3].skillfly[k].ady = (int)dataInputStream.readShort();
				}
			}
		}
		catch (Exception ex)
		{
			Cout.LogError("Loi ham readSkill: " + ex.ToString());
		}
		finally
		{
			try
			{
				dataInputStream.close();
			}
			catch (Exception ex2)
			{
				Cout.LogError("Loi ham readskill: " + ex2.ToString());
			}
		}
	}

	// Token: 0x06000698 RID: 1688 RVA: 0x00006B05 File Offset: 0x00004D05
	public static GameScr gI()
	{
		if (GameScr.instance == null)
		{
			GameScr.instance = new GameScr();
		}
		return GameScr.instance;
	}

	// Token: 0x06000699 RID: 1689 RVA: 0x00006B20 File Offset: 0x00004D20
	public static void clearGameScr()
	{
		GameScr.instance = null;
	}

	// Token: 0x0600069A RID: 1690 RVA: 0x00006B28 File Offset: 0x00004D28
	public void loadGameScr()
	{
		GameScr.loadSplash();
		Res.init();
		this.loadInforBar();
	}

	// Token: 0x0600069B RID: 1691 RVA: 0x00057F70 File Offset: 0x00056170
	public void doMenuInforMe()
	{
		GameScr.scrMain.clear();
		GameScr.scrInfo.clear();
		GameScr.isViewNext = false;
		this.cmdBag = new Command(mResources.MENUME[0], 1100011);
		this.cmdSkill = new Command(mResources.MENUME[1], 1100012);
		this.cmdTiemnang = new Command(mResources.MENUME[2], 1100013);
		this.cmdInfo = new Command(mResources.MENUME[3], 1100014);
		this.cmdtrangbi = new Command(mResources.MENUME[4], 1100015);
		MyVector myVector = new MyVector();
		myVector.addElement(this.cmdBag);
		myVector.addElement(this.cmdSkill);
		myVector.addElement(this.cmdTiemnang);
		myVector.addElement(this.cmdInfo);
		myVector.addElement(this.cmdtrangbi);
		GameCanvas.menu.startAt(myVector, 3);
	}

	// Token: 0x0600069C RID: 1692 RVA: 0x00058058 File Offset: 0x00056258
	public void doMenusynthesis()
	{
		MyVector myVector = new MyVector();
		myVector.addElement(new Command(mResources.SYNTHESIS[0], 110002));
		myVector.addElement(new Command(mResources.SYNTHESIS[1], 1100032));
		myVector.addElement(new Command(mResources.SYNTHESIS[2], 1100033));
		GameCanvas.menu.startAt(myVector, 3);
	}

	// Token: 0x0600069D RID: 1693 RVA: 0x000580BC File Offset: 0x000562BC
	public static void loadCamera(bool fullmScreen, int cx, int cy)
	{
		GameScr.gW = GameCanvas.w;
		GameScr.cmdBarH = 39;
		GameScr.gH = GameCanvas.h;
		GameScr.cmdBarW = GameScr.gW;
		GameScr.cmdBarX = 0;
		GameScr.cmdBarY = GameCanvas.h - Paint.hTab - GameScr.cmdBarH;
		GameScr.girlHPBarY = 0;
		GameScr.csPadMaxH = GameCanvas.h / 6;
		if (GameScr.csPadMaxH < 48)
		{
			GameScr.csPadMaxH = 48;
		}
		GameScr.gW2 = GameScr.gW >> 1;
		GameScr.gH2 = GameScr.gH >> 1;
		GameScr.gW3 = GameScr.gW / 3;
		GameScr.gH3 = GameScr.gH / 3;
		GameScr.gW23 = GameScr.gH - 120;
		GameScr.gH23 = GameScr.gH * 2 / 3;
		GameScr.gW34 = 3 * GameScr.gW / 4;
		GameScr.gH34 = 3 * GameScr.gH / 4;
		GameScr.gW6 = GameScr.gW / 6;
		GameScr.gH6 = GameScr.gH / 6;
		GameScr.gssw = GameScr.gW / (int)TileMap.size + 2;
		GameScr.gssh = GameScr.gH / (int)TileMap.size + 2;
		if (GameScr.gW % 24 != 0)
		{
			GameScr.gssw++;
		}
		GameScr.cmxLim = (TileMap.tmw - 1) * (int)TileMap.size - GameScr.gW;
		GameScr.cmyLim = (TileMap.tmh - 1) * (int)TileMap.size - GameScr.gH;
		if (cx == -1 && cy == -1)
		{
			GameScr.cmx = (GameScr.cmtoX = global::Char.myCharz().cx - GameScr.gW2 + GameScr.gW6 * global::Char.myCharz().cdir);
			GameScr.cmy = (GameScr.cmtoY = global::Char.myCharz().cy - GameScr.gH23);
		}
		else
		{
			GameScr.cmx = (GameScr.cmtoX = cx - GameScr.gW23 + GameScr.gW6 * global::Char.myCharz().cdir);
			GameScr.cmy = (GameScr.cmtoY = cy - GameScr.gH23);
		}
		GameScr.firstY = GameScr.cmy;
		if (GameScr.cmx < 24)
		{
			GameScr.cmx = (GameScr.cmtoX = 24);
		}
		if (GameScr.cmx > GameScr.cmxLim)
		{
			GameScr.cmx = (GameScr.cmtoX = GameScr.cmxLim);
		}
		if (GameScr.cmy < 0)
		{
			GameScr.cmy = (GameScr.cmtoY = 0);
		}
		if (GameScr.cmy > GameScr.cmyLim)
		{
			GameScr.cmy = (GameScr.cmtoY = GameScr.cmyLim);
		}
		GameScr.gssx = GameScr.cmx / (int)TileMap.size - 1;
		if (GameScr.gssx < 0)
		{
			GameScr.gssx = 0;
		}
		GameScr.gssy = GameScr.cmy / (int)TileMap.size;
		GameScr.gssxe = GameScr.gssx + GameScr.gssw;
		GameScr.gssye = GameScr.gssy + GameScr.gssh;
		if (GameScr.gssy < 0)
		{
			GameScr.gssy = 0;
		}
		if (GameScr.gssye > TileMap.tmh - 1)
		{
			GameScr.gssye = TileMap.tmh - 1;
		}
		TileMap.countx = (GameScr.gssxe - GameScr.gssx) * 4;
		if (TileMap.countx > TileMap.tmw)
		{
			TileMap.countx = TileMap.tmw;
		}
		TileMap.county = (GameScr.gssye - GameScr.gssy) * 4;
		if (TileMap.county > TileMap.tmh)
		{
			TileMap.county = TileMap.tmh;
		}
		TileMap.gssx = (global::Char.myCharz().cx - 2 * GameScr.gW) / (int)TileMap.size;
		if (TileMap.gssx < 0)
		{
			TileMap.gssx = 0;
		}
		TileMap.gssxe = TileMap.gssx + TileMap.countx;
		if (TileMap.gssxe > TileMap.tmw)
		{
			TileMap.gssxe = TileMap.tmw;
		}
		TileMap.gssy = (global::Char.myCharz().cy - 2 * GameScr.gH) / (int)TileMap.size;
		if (TileMap.gssy < 0)
		{
			TileMap.gssy = 0;
		}
		TileMap.gssye = TileMap.gssy + TileMap.county;
		if (TileMap.gssye > TileMap.tmh)
		{
			TileMap.gssye = TileMap.tmh;
		}
		ChatTextField.gI().parentScreen = GameScr.instance;
		ChatTextField.gI().tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
		ChatTextField.gI().initChatTextField();
		if (GameCanvas.isTouch)
		{
			GameScr.yTouchBar = GameScr.gH - 88;
			GameScr.xC = GameScr.gW - 40;
			GameScr.yC = 2;
			if (GameCanvas.w <= 240)
			{
				GameScr.xC = GameScr.gW - 35;
				GameScr.yC = 5;
			}
			GameScr.xF = GameScr.gW - 55;
			GameScr.yF = GameScr.yTouchBar + 35;
			GameScr.xTG = GameScr.gW - 37;
			GameScr.yTG = GameScr.yTouchBar - 1;
			if (GameCanvas.w >= 450)
			{
				GameScr.yTG -= 12;
				GameScr.yHP -= 7;
				GameScr.xF -= 10;
				GameScr.yF -= 5;
				GameScr.xTG -= 10;
			}
		}
		GameScr.setSkillBarPosition();
		GameScr.disXC = ((GameCanvas.w <= 200) ? 30 : 40);
		if (Rms.loadRMSInt("viewchat") == -1)
		{
			GameCanvas.panel.isViewChatServer = true;
		}
		else
		{
			GameCanvas.panel.isViewChatServer = (Rms.loadRMSInt("viewchat") == 1);
		}
	}

	// Token: 0x0600069E RID: 1694 RVA: 0x00058620 File Offset: 0x00056820
	public static void setSkillBarPosition()
	{
		Skill[] array = (!GameCanvas.isTouch) ? GameScr.keySkill : GameScr.onScreenSkill;
		GameScr.xS = new int[array.Length];
		GameScr.yS = new int[array.Length];
		if (GameCanvas.isTouchControlSmallScreen && GameScr.isUseTouch)
		{
			GameScr.xSkill = 23;
			GameScr.ySkill = 52;
			GameScr.padSkill = 5;
			for (int i = 0; i < GameScr.xS.Length; i++)
			{
				GameScr.xS[i] = i * (25 + GameScr.padSkill);
				GameScr.yS[i] = GameScr.ySkill;
			}
			GameScr.xHP = array.Length * (25 + GameScr.padSkill);
			GameScr.yHP = GameScr.ySkill;
		}
		else
		{
			GameScr.wSkill = 30;
			if (GameCanvas.w <= 320)
			{
				GameScr.ySkill = GameScr.gH - GameScr.wSkill - 6;
				GameScr.xSkill = GameScr.gW2 - array.Length * GameScr.wSkill / 2 - 25;
			}
			else
			{
				GameScr.wSkill = 40;
				GameScr.xSkill = 10;
				GameScr.ySkill = GameCanvas.h - GameScr.wSkill + 7;
			}
			for (int j = 0; j < GameScr.xS.Length; j++)
			{
				GameScr.xS[j] = j * GameScr.wSkill;
				GameScr.yS[j] = GameScr.ySkill;
			}
			GameScr.xHP = array.Length * GameScr.wSkill;
			GameScr.yHP = GameScr.ySkill;
		}
		if (GameCanvas.isTouch)
		{
			GameScr.xSkill = 17;
			GameScr.ySkill = GameCanvas.h - 40;
			if (GameScr.gamePad.isSmallGamePad && GameScr.isAnalog == 1)
			{
				GameScr.xHP = array.Length * GameScr.wSkill;
				GameScr.yHP = GameScr.ySkill;
			}
			else
			{
				GameScr.xHP = GameCanvas.w - 45;
				GameScr.yHP = GameCanvas.h - 45;
			}
			GameScr.setTouchBtn();
			for (int k = 0; k < GameScr.xS.Length; k++)
			{
				GameScr.xS[k] = k * GameScr.wSkill;
				GameScr.yS[k] = GameScr.ySkill;
			}
		}
	}

	// Token: 0x0600069F RID: 1695 RVA: 0x00058834 File Offset: 0x00056A34
	private static void updateCamera()
	{
		if (GameScr.isPaintOther)
		{
			return;
		}
		if (GameScr.cmx != GameScr.cmtoX || GameScr.cmy != GameScr.cmtoY)
		{
			GameScr.cmvx = GameScr.cmtoX - GameScr.cmx << 2;
			GameScr.cmvy = GameScr.cmtoY - GameScr.cmy << 2;
			GameScr.cmdx += GameScr.cmvx;
			GameScr.cmx += GameScr.cmdx >> 4;
			GameScr.cmdx &= 15;
			GameScr.cmdy += GameScr.cmvy;
			GameScr.cmy += GameScr.cmdy >> 4;
			GameScr.cmdy &= 15;
			if (GameScr.cmx < 24)
			{
				GameScr.cmx = 24;
			}
			if (GameScr.cmx > GameScr.cmxLim)
			{
				GameScr.cmx = GameScr.cmxLim;
			}
			if (GameScr.cmy < 0)
			{
				GameScr.cmy = 0;
			}
			if (GameScr.cmy > GameScr.cmyLim)
			{
				GameScr.cmy = GameScr.cmyLim;
			}
		}
		GameScr.gssx = GameScr.cmx / (int)TileMap.size - 1;
		if (GameScr.gssx < 0)
		{
			GameScr.gssx = 0;
		}
		GameScr.gssy = GameScr.cmy / (int)TileMap.size;
		GameScr.gssxe = GameScr.gssx + GameScr.gssw;
		GameScr.gssye = GameScr.gssy + GameScr.gssh;
		if (GameScr.gssy < 0)
		{
			GameScr.gssy = 0;
		}
		if (GameScr.gssye > TileMap.tmh - 1)
		{
			GameScr.gssye = TileMap.tmh - 1;
		}
		TileMap.gssx = (global::Char.myCharz().cx - 2 * GameScr.gW) / (int)TileMap.size;
		if (TileMap.gssx < 0)
		{
			TileMap.gssx = 0;
		}
		TileMap.gssxe = TileMap.gssx + TileMap.countx;
		if (TileMap.gssxe > TileMap.tmw)
		{
			TileMap.gssxe = TileMap.tmw;
			TileMap.gssx = TileMap.gssxe - TileMap.countx;
		}
		TileMap.gssy = (global::Char.myCharz().cy - 2 * GameScr.gH) / (int)TileMap.size;
		if (TileMap.gssy < 0)
		{
			TileMap.gssy = 0;
		}
		TileMap.gssye = TileMap.gssy + TileMap.county;
		if (TileMap.gssye > TileMap.tmh)
		{
			TileMap.gssye = TileMap.tmh;
			TileMap.gssy = TileMap.gssye - TileMap.county;
		}
		GameScr.scrMain.updatecm();
		GameScr.scrInfo.updatecm();
	}

	// Token: 0x060006A0 RID: 1696 RVA: 0x00058AAC File Offset: 0x00056CAC
	public bool testAct()
	{
		sbyte b = 2;
		while ((int)b < 9)
		{
			if (GameCanvas.keyHold[(int)b])
			{
				return false;
			}
			b = (sbyte)((int)b + 2);
		}
		return true;
	}

	// Token: 0x060006A1 RID: 1697 RVA: 0x00058AE0 File Offset: 0x00056CE0
	public void clanInvite(string strInvite, int clanID, int code)
	{
		ClanObject clanObject = new ClanObject();
		clanObject.code = code;
		clanObject.clanID = clanID;
		this.startYesNoPopUp(strInvite, new Command(mResources.YES, 12002, clanObject), new Command(mResources.NO, 12003, clanObject));
	}

	// Token: 0x060006A2 RID: 1698 RVA: 0x00058B28 File Offset: 0x00056D28
	public void playerMenu(global::Char c)
	{
		this.auto = 0;
		GameCanvas.clearKeyHold();
		if (global::Char.myCharz().charFocus.charID < 0)
		{
			return;
		}
		if (global::Char.myCharz().charID < 0)
		{
			return;
		}
		MyVector vPlayerMenu = GameCanvas.panel.vPlayerMenu;
		if (vPlayerMenu.size() > 0)
		{
			return;
		}
		if (global::Char.myCharz().taskMaint != null && global::Char.myCharz().taskMaint.taskId > 1)
		{
			vPlayerMenu.addElement(new Command(mResources.make_friend, 11112, global::Char.myCharz().charFocus));
			vPlayerMenu.addElement(new Command(mResources.trade, 11113, global::Char.myCharz().charFocus));
		}
		if (global::Char.myCharz().clan != null && (int)global::Char.myCharz().role < 2 && global::Char.myCharz().charFocus.clanID == -1)
		{
			vPlayerMenu.addElement(new Command(mResources.CHAR_ORDER[4], 110391));
		}
		if (global::Char.myCharz().charFocus.statusMe != 14 && global::Char.myCharz().charFocus.statusMe != 5)
		{
			if (global::Char.myCharz().taskMaint != null && global::Char.myCharz().taskMaint.taskId >= 14)
			{
				vPlayerMenu.addElement(new Command(mResources.CHAR_ORDER[0], 2003));
			}
		}
		else if (global::Char.myCharz().myskill.template.type == 4)
		{
		}
		if (global::Char.myCharz().clan != null && global::Char.myCharz().clan.ID == global::Char.myCharz().charFocus.clanID && global::Char.myCharz().charFocus.statusMe != 14 && global::Char.myCharz().taskMaint != null && global::Char.myCharz().taskMaint.taskId >= 14)
		{
			vPlayerMenu.addElement(new Command(mResources.CHAR_ORDER[1], 2004));
		}
		int num = global::Char.myCharz().nClass.skillTemplates.Length;
		for (int i = 0; i < num; i++)
		{
			SkillTemplate skillTemplate = global::Char.myCharz().nClass.skillTemplates[i];
			Skill skill = global::Char.myCharz().getSkill(skillTemplate);
			if (skill != null && skillTemplate.isBuffToPlayer() && skill.point >= 1)
			{
				vPlayerMenu.addElement(new Command(skillTemplate.name, 12004, skill));
			}
		}
	}

	// Token: 0x060006A3 RID: 1699 RVA: 0x00058DB4 File Offset: 0x00056FB4
	public bool isAttack()
	{
		if (this.checkClickToBotton(global::Char.myCharz().charFocus))
		{
			return false;
		}
		if (this.checkClickToBotton(global::Char.myCharz().mobFocus))
		{
			return false;
		}
		if (this.checkClickToBotton(global::Char.myCharz().npcFocus))
		{
			return false;
		}
		if (ChatTextField.gI().isShow)
		{
			return false;
		}
		if (InfoDlg.isLock || global::Char.myCharz().isLockAttack || global::Char.isLockKey)
		{
			return false;
		}
		if (global::Char.myCharz().myskill != null && (int)global::Char.myCharz().myskill.template.id == 6 && global::Char.myCharz().itemFocus != null)
		{
			this.pickItem();
			return false;
		}
		if (global::Char.myCharz().myskill != null && global::Char.myCharz().myskill.template.type == 2 && global::Char.myCharz().npcFocus == null && (int)global::Char.myCharz().myskill.template.id != 6)
		{
			return this.checkSkillValid();
		}
		if (global::Char.myCharz().skillPaint != null || (global::Char.myCharz().mobFocus == null && global::Char.myCharz().npcFocus == null && global::Char.myCharz().charFocus == null && global::Char.myCharz().itemFocus == null))
		{
			return false;
		}
		if (global::Char.myCharz().mobFocus != null)
		{
			if (global::Char.myCharz().mobFocus.isBigBoss() && global::Char.myCharz().mobFocus.status == 4)
			{
				global::Char.myCharz().mobFocus = null;
				global::Char.myCharz().currentMovePoint = null;
			}
			GameScr.isAutoPlay = true;
			if (!this.isMeCanAttackMob(global::Char.myCharz().mobFocus))
			{
				Res.outz("can not attack");
				return false;
			}
			if (this.mobCapcha != null)
			{
				return false;
			}
			if (global::Char.myCharz().myskill == null)
			{
				return false;
			}
			if (global::Char.myCharz().isSelectingSkillUseAlone())
			{
				return false;
			}
			if (global::Char.myCharz().mobFocus.status == 1 || global::Char.myCharz().mobFocus.status == 0 || global::Char.myCharz().myskill.template.type == 4)
			{
				return false;
			}
			if (!this.checkSkillValid())
			{
				return false;
			}
			if (global::Char.myCharz().cx < global::Char.myCharz().mobFocus.getX())
			{
				global::Char.myCharz().cdir = 1;
			}
			else
			{
				global::Char.myCharz().cdir = -1;
			}
			int num = global::Math.abs(global::Char.myCharz().cx - global::Char.myCharz().mobFocus.getX());
			int num2 = global::Math.abs(global::Char.myCharz().cy - global::Char.myCharz().mobFocus.getY());
			global::Char.myCharz().cvx = 0;
			if (num > global::Char.myCharz().myskill.dx || num2 > global::Char.myCharz().myskill.dy)
			{
				bool flag = false;
				if (global::Char.myCharz().mobFocus is BigBoss || global::Char.myCharz().mobFocus is BigBoss2)
				{
					flag = true;
				}
				int num3 = (global::Char.myCharz().myskill.dx - ((!flag) ? 20 : 50)) * ((global::Char.myCharz().cx <= global::Char.myCharz().mobFocus.getX()) ? -1 : 1);
				if (num <= global::Char.myCharz().myskill.dx)
				{
					num3 = 0;
				}
				global::Char.myCharz().currentMovePoint = new MovePoint(global::Char.myCharz().mobFocus.getX() + num3, global::Char.myCharz().mobFocus.getY());
				global::Char.myCharz().endMovePointCommand = new Command(null, null, 8002, null);
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
				return false;
			}
			if ((int)global::Char.myCharz().myskill.template.id == 20)
			{
				return true;
			}
			if (num2 > num && Res.abs(global::Char.myCharz().cy - global::Char.myCharz().mobFocus.getY()) > 30 && (int)global::Char.myCharz().mobFocus.getTemplate().type == 4)
			{
				global::Char.myCharz().currentMovePoint = new MovePoint(global::Char.myCharz().cx + global::Char.myCharz().cdir, global::Char.myCharz().mobFocus.getY());
				global::Char.myCharz().endMovePointCommand = new Command(null, null, 8002, null);
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
				return false;
			}
			int num4 = 20;
			bool flag2 = false;
			if (global::Char.myCharz().mobFocus is BigBoss || global::Char.myCharz().mobFocus is BigBoss2)
			{
				flag2 = true;
			}
			if (global::Char.myCharz().myskill.dx > 100)
			{
				num4 = 60;
				if (num < 20)
				{
					global::Char.myCharz().createShadow(global::Char.myCharz().cx, global::Char.myCharz().cy, 10);
				}
			}
			bool flag3 = false;
			if ((TileMap.tileTypeAtPixel(global::Char.myCharz().cx, global::Char.myCharz().cy + 3) & 2) == 2)
			{
				int num5 = (global::Char.myCharz().cx <= global::Char.myCharz().mobFocus.getX()) ? -1 : 1;
				if ((TileMap.tileTypeAtPixel(global::Char.myCharz().mobFocus.getX() + num4 * num5, global::Char.myCharz().cy + 3) & 2) != 2)
				{
					flag3 = true;
				}
			}
			if (num <= num4 && !flag3)
			{
				if (num >= 30)
				{
					int num6 = (global::Char.myCharz().cx <= global::Char.myCharz().mobFocus.getX()) ? (-num4) : num4;
					global::Char.myCharz().currentMovePoint = new MovePoint(global::Char.myCharz().cx + num6, global::Char.myCharz().cy);
					global::Char.myCharz().endMovePointCommand = new Command(null, null, 8002, null);
					GameCanvas.clearKeyHold();
					GameCanvas.clearKeyPressed();
					return false;
				}
				if (global::Char.myCharz().cx > global::Char.myCharz().mobFocus.getX())
				{
					global::Char.myCharz().cx = global::Char.myCharz().mobFocus.getX() + num4 + ((!flag2) ? 0 : 30);
					global::Char.myCharz().cdir = -1;
				}
				else
				{
					global::Char.myCharz().cx = global::Char.myCharz().mobFocus.getX() - num4 - ((!flag2) ? 0 : 30);
					global::Char.myCharz().cdir = 1;
				}
				Service.gI().charMove();
			}
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			return true;
		}
		else if (global::Char.myCharz().npcFocus != null)
		{
			if (global::Char.myCharz().npcFocus.isHide)
			{
				return false;
			}
			if (global::Char.myCharz().cx < global::Char.myCharz().npcFocus.cx)
			{
				global::Char.myCharz().cdir = 1;
			}
			else
			{
				global::Char.myCharz().cdir = -1;
			}
			if (global::Char.myCharz().cx < global::Char.myCharz().npcFocus.cx)
			{
				global::Char.myCharz().npcFocus.cdir = -1;
			}
			else
			{
				global::Char.myCharz().npcFocus.cdir = 1;
			}
			int num7 = global::Math.abs(global::Char.myCharz().cx - global::Char.myCharz().npcFocus.cx);
			int num8 = global::Math.abs(global::Char.myCharz().cy - global::Char.myCharz().npcFocus.cy);
			if (num8 > 40)
			{
				global::Char.myCharz().cy = global::Char.myCharz().npcFocus.cy - 40;
			}
			if (num7 < 60)
			{
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
				if (this.tMenuDelay == 0)
				{
					if (global::Char.myCharz().taskMaint != null && global::Char.myCharz().taskMaint.taskId == 0)
					{
						if (global::Char.myCharz().taskMaint.index < 4 && global::Char.myCharz().npcFocus.template.npcTemplateId == 4)
						{
							return false;
						}
						if (global::Char.myCharz().taskMaint.index < 3 && global::Char.myCharz().npcFocus.template.npcTemplateId == 3)
						{
							return false;
						}
					}
					this.tMenuDelay = 50;
					InfoDlg.showWait();
					Service.gI().charMove();
					Service.gI().openMenu(global::Char.myCharz().npcFocus.template.npcTemplateId);
				}
			}
			else
			{
				int num9 = (20 + Res.r.nextInt(20)) * ((global::Char.myCharz().cx <= global::Char.myCharz().npcFocus.cx) ? -1 : 1);
				global::Char.myCharz().currentMovePoint = new MovePoint(global::Char.myCharz().npcFocus.cx + num9, global::Char.myCharz().cy);
				global::Char.myCharz().endMovePointCommand = new Command(null, null, 8002, null);
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
			}
			return false;
		}
		else if (global::Char.myCharz().charFocus != null)
		{
			if (this.mobCapcha != null)
			{
				return false;
			}
			if (global::Char.myCharz().cx < global::Char.myCharz().charFocus.cx)
			{
				global::Char.myCharz().cdir = 1;
			}
			else
			{
				global::Char.myCharz().cdir = -1;
			}
			int num10 = global::Math.abs(global::Char.myCharz().cx - global::Char.myCharz().charFocus.cx);
			int num11 = global::Math.abs(global::Char.myCharz().cy - global::Char.myCharz().charFocus.cy);
			if (!global::Char.myCharz().isMeCanAttackOtherPlayer(global::Char.myCharz().charFocus) && !global::Char.myCharz().isSelectingSkillBuffToPlayer())
			{
				if (num10 < 60 && num11 < 40)
				{
					this.playerMenu(global::Char.myCharz().charFocus);
					if (!GameCanvas.isTouch && global::Char.myCharz().charFocus.charID >= 0 && TileMap.mapID != 51 && TileMap.mapID != 52 && this.popUpYesNo == null)
					{
						GameCanvas.panel.setTypePlayerMenu(global::Char.myCharz().charFocus);
						GameCanvas.panel.show();
						Service.gI().getPlayerMenu(global::Char.myCharz().charFocus.charID);
						Service.gI().messagePlayerMenu(global::Char.myCharz().charFocus.charID);
					}
				}
				else
				{
					int num12 = (20 + Res.r.nextInt(20)) * ((global::Char.myCharz().cx <= global::Char.myCharz().charFocus.cx) ? -1 : 1);
					global::Char.myCharz().currentMovePoint = new MovePoint(global::Char.myCharz().charFocus.cx + num12, global::Char.myCharz().charFocus.cy);
					global::Char.myCharz().endMovePointCommand = new Command(null, null, 8002, null);
					GameCanvas.clearKeyHold();
					GameCanvas.clearKeyPressed();
				}
				return false;
			}
			if (global::Char.myCharz().myskill == null)
			{
				return false;
			}
			if (!this.checkSkillValid())
			{
				return false;
			}
			if (global::Char.myCharz().cx < global::Char.myCharz().charFocus.cx)
			{
				global::Char.myCharz().cdir = 1;
			}
			else
			{
				global::Char.myCharz().cdir = -1;
			}
			global::Char.myCharz().cvx = 0;
			if (num10 > global::Char.myCharz().myskill.dx || num11 > global::Char.myCharz().myskill.dy)
			{
				int num13 = (global::Char.myCharz().myskill.dx - 20) * ((global::Char.myCharz().cx <= global::Char.myCharz().charFocus.cx) ? -1 : 1);
				if (num10 <= global::Char.myCharz().myskill.dx)
				{
					num13 = 0;
				}
				global::Char.myCharz().currentMovePoint = new MovePoint(global::Char.myCharz().charFocus.cx + num13, global::Char.myCharz().charFocus.cy);
				global::Char.myCharz().endMovePointCommand = new Command(null, null, 8002, null);
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
				return false;
			}
			if ((int)global::Char.myCharz().myskill.template.id == 20)
			{
				return true;
			}
			int num14 = 20;
			if (global::Char.myCharz().myskill.dx > 60)
			{
				num14 = 60;
				if (num10 < 20)
				{
					global::Char.myCharz().createShadow(global::Char.myCharz().cx, global::Char.myCharz().cy, 10);
				}
			}
			bool flag4 = false;
			if ((TileMap.tileTypeAtPixel(global::Char.myCharz().cx, global::Char.myCharz().cy + 3) & 2) == 2)
			{
				int num15 = (global::Char.myCharz().cx <= global::Char.myCharz().charFocus.cx) ? -1 : 1;
				if ((TileMap.tileTypeAtPixel(global::Char.myCharz().charFocus.cx + num14 * num15, global::Char.myCharz().cy + 3) & 2) != 2)
				{
					flag4 = true;
				}
			}
			if (num10 <= num14 && !flag4)
			{
				if (global::Char.myCharz().cx > global::Char.myCharz().charFocus.cx)
				{
					global::Char.myCharz().cx = global::Char.myCharz().charFocus.cx + num14;
					global::Char.myCharz().cdir = -1;
				}
				else
				{
					global::Char.myCharz().cx = global::Char.myCharz().charFocus.cx - num14;
					global::Char.myCharz().cdir = 1;
				}
				Service.gI().charMove();
			}
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			return true;
		}
		else
		{
			if (global::Char.myCharz().itemFocus != null)
			{
				this.pickItem();
				return false;
			}
			return true;
		}
	}

	// Token: 0x060006A4 RID: 1700 RVA: 0x00059BBC File Offset: 0x00057DBC
	public bool isMeCanAttackMob(Mob m)
	{
		if (m == null)
		{
			return false;
		}
		if ((int)global::Char.myCharz().cTypePk == 5)
		{
			return true;
		}
		if (global::Char.myCharz().isAttacPlayerStatus() && !m.isMobMe)
		{
			return false;
		}
		if (global::Char.myCharz().mobMe != null && m.Equals(global::Char.myCharz().mobMe))
		{
			return false;
		}
		global::Char @char = GameScr.findCharInMap(m.mobId);
		return @char == null || (int)@char.cTypePk == 5 || global::Char.myCharz().isMeCanAttackOtherPlayer(@char);
	}

	// Token: 0x060006A5 RID: 1701 RVA: 0x00059C5C File Offset: 0x00057E5C
	private bool checkSkillValid()
	{
		if (global::Char.myCharz().myskill != null && ((global::Char.myCharz().myskill.template.manaUseType != 1 && global::Char.myCharz().cMP < global::Char.myCharz().myskill.manaUse) || (global::Char.myCharz().myskill.template.manaUseType == 1 && global::Char.myCharz().cMP < global::Char.myCharz().cMPFull * global::Char.myCharz().myskill.manaUse / 100)))
		{
			GameScr.info1.addInfo(mResources.NOT_ENOUGH_MP, 0);
			this.auto = 0;
			return false;
		}
		if (global::Char.myCharz().myskill == null || (global::Char.myCharz().myskill.template.maxPoint > 0 && global::Char.myCharz().myskill.point == 0))
		{
			GameCanvas.startOKDlg(mResources.SKILL_FAIL);
			return false;
		}
		return true;
	}

	// Token: 0x060006A6 RID: 1702 RVA: 0x00059D5C File Offset: 0x00057F5C
	private bool checkSkillValid2()
	{
		return (global::Char.myCharz().myskill == null || ((global::Char.myCharz().myskill.template.manaUseType == 1 || global::Char.myCharz().cMP >= global::Char.myCharz().myskill.manaUse) && (global::Char.myCharz().myskill.template.manaUseType != 1 || global::Char.myCharz().cMP >= global::Char.myCharz().cMPFull * global::Char.myCharz().myskill.manaUse / 100))) && global::Char.myCharz().myskill != null && (global::Char.myCharz().myskill.template.maxPoint <= 0 || global::Char.myCharz().myskill.point != 0);
	}

	// Token: 0x060006A7 RID: 1703 RVA: 0x00059E38 File Offset: 0x00058038
	public void resetButton()
	{
		GameCanvas.menu.showMenu = false;
		ChatTextField.gI().close();
		ChatTextField.gI().center = null;
		this.isLockKey = false;
		this.typeTrade = 0;
		GameScr.indexMenu = 0;
		GameScr.indexSelect = 0;
		this.indexItemUse = -1;
		GameScr.indexRow = -1;
		GameScr.indexRowMax = 0;
		GameScr.indexTitle = 0;
		this.typeTrade = (this.typeTradeOrder = 0);
		mSystem.endKey();
		if (global::Char.myCharz().cHP <= 0 || global::Char.myCharz().statusMe == 14 || global::Char.myCharz().statusMe == 5)
		{
			if (global::Char.myCharz().meDead)
			{
				this.cmdDead = new Command(mResources.DIES[0], 11038);
				this.center = this.cmdDead;
				global::Char.myCharz().cHP = 0;
			}
			GameScr.isHaveSelectSkill = false;
		}
		else
		{
			GameScr.isHaveSelectSkill = true;
		}
		GameScr.scrMain.clear();
	}

	// Token: 0x060006A8 RID: 1704 RVA: 0x00006B3A File Offset: 0x00004D3A
	public override void keyPress(int keyCode)
	{
		base.keyPress(keyCode);
	}

	// Token: 0x060006A9 RID: 1705 RVA: 0x00059F38 File Offset: 0x00058138
	public override void updateKey()
	{
		if (Controller.isStopReadMessage || global::Char.myCharz().isTeleport)
		{
			return;
		}
		if (InfoDlg.isLock)
		{
			return;
		}
		if (GameCanvas.isTouch && !ChatTextField.gI().isShow && !GameCanvas.menu.showMenu)
		{
			this.updateKeyTouchControl();
		}
		this.checkAuto();
		GameCanvas.debug("F2", 0);
		if (ChatPopup.currChatPopup != null)
		{
			Command cmdNextLine = ChatPopup.currChatPopup.cmdNextLine;
			if ((GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] || mScreen.getCmdPointerLast(cmdNextLine)) && cmdNextLine != null)
			{
				GameCanvas.isPointerJustRelease = false;
				GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] = false;
				mScreen.keyTouch = -1;
				if (cmdNextLine != null)
				{
					cmdNextLine.performAction();
				}
			}
		}
		else if (!ChatTextField.gI().isShow)
		{
			if ((GameCanvas.keyPressed[12] || mScreen.getCmdPointerLast(GameCanvas.currentScreen.left)) && this.left != null)
			{
				GameCanvas.isPointerJustRelease = false;
				GameCanvas.isPointerClick = false;
				GameCanvas.keyPressed[12] = false;
				mScreen.keyTouch = -1;
				if (this.left != null)
				{
					this.left.performAction();
				}
			}
			if ((GameCanvas.keyPressed[13] || mScreen.getCmdPointerLast(GameCanvas.currentScreen.right)) && this.right != null)
			{
				GameCanvas.isPointerJustRelease = false;
				GameCanvas.isPointerClick = false;
				GameCanvas.keyPressed[13] = false;
				mScreen.keyTouch = -1;
				if (this.right != null)
				{
					this.right.performAction();
				}
			}
			if ((GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] || mScreen.getCmdPointerLast(GameCanvas.currentScreen.center)) && this.center != null)
			{
				GameCanvas.isPointerJustRelease = false;
				GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] = false;
				mScreen.keyTouch = -1;
				if (this.center != null)
				{
					this.center.performAction();
				}
			}
		}
		else
		{
			if (ChatTextField.gI().left != null && (GameCanvas.keyPressed[12] || mScreen.getCmdPointerLast(ChatTextField.gI().left)) && ChatTextField.gI().left != null)
			{
				ChatTextField.gI().left.performAction();
			}
			if (ChatTextField.gI().right != null && (GameCanvas.keyPressed[13] || mScreen.getCmdPointerLast(ChatTextField.gI().right)) && ChatTextField.gI().right != null)
			{
				ChatTextField.gI().right.performAction();
			}
			if (ChatTextField.gI().center != null && (GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] || mScreen.getCmdPointerLast(ChatTextField.gI().center)) && ChatTextField.gI().center != null)
			{
				ChatTextField.gI().center.performAction();
			}
		}
		GameCanvas.debug("F6", 0);
		this.updateKeyAlert();
		GameCanvas.debug("F7", 0);
		if (global::Char.myCharz().currentMovePoint != null)
		{
			for (int i = 0; i < GameCanvas.keyPressed.Length; i++)
			{
				if (GameCanvas.keyPressed[i])
				{
					global::Char.myCharz().currentMovePoint = null;
					break;
				}
			}
		}
		GameCanvas.debug("F8", 0);
		if (ChatTextField.gI().isShow && GameCanvas.keyAsciiPress != 0)
		{
			ChatTextField.gI().keyPressed(GameCanvas.keyAsciiPress);
			GameCanvas.keyAsciiPress = 0;
			return;
		}
		if (this.isLockKey)
		{
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			return;
		}
		if (GameCanvas.menu.showMenu || this.isOpenUI() || global::Char.isLockKey)
		{
			return;
		}
		if (GameCanvas.keyPressed[10])
		{
			GameCanvas.keyPressed[10] = false;
			this.doUseHP();
			GameCanvas.clearKeyPressed();
		}
		if (GameCanvas.keyPressed[11] && this.mobCapcha == null)
		{
			if (this.popUpYesNo != null)
			{
				this.popUpYesNo.cmdYes.performAction();
			}
			else if (GameScr.info2.info.info != null && GameScr.info2.info.info.charInfo != null)
			{
				GameCanvas.panel.setTypeMessage();
				GameCanvas.panel.show();
			}
			GameCanvas.keyPressed[11] = false;
			GameCanvas.clearKeyPressed();
		}
		if (GameCanvas.keyAsciiPress != 0 && TField.isQwerty && GameCanvas.keyAsciiPress == 32)
		{
			this.doUseHP();
			GameCanvas.keyAsciiPress = 0;
			GameCanvas.clearKeyPressed();
		}
		if (GameCanvas.keyAsciiPress != 0 && this.mobCapcha == null && TField.isQwerty && GameCanvas.keyAsciiPress == 121)
		{
			if (this.popUpYesNo != null)
			{
				this.popUpYesNo.cmdYes.performAction();
				GameCanvas.keyAsciiPress = 0;
				GameCanvas.clearKeyPressed();
			}
			else if (GameScr.info2.info.info != null && GameScr.info2.info.info.charInfo != null)
			{
				GameCanvas.panel.setTypeMessage();
				GameCanvas.panel.show();
				GameCanvas.keyAsciiPress = 0;
				GameCanvas.clearKeyPressed();
			}
		}
		if (GameCanvas.keyPressed[10] && this.mobCapcha == null)
		{
			GameCanvas.keyPressed[10] = false;
			GameScr.info2.doClick(10);
			GameCanvas.clearKeyPressed();
		}
		this.checkDrag();
		if (!global::Char.myCharz().isFlyAndCharge)
		{
			this.checkClick();
		}
		if (global::Char.myCharz().cmdMenu != null && global::Char.myCharz().cmdMenu.isPointerPressInside())
		{
			global::Char.myCharz().cmdMenu.performAction();
		}
		if (global::Char.myCharz().skillPaint != null)
		{
			return;
		}
		if (GameCanvas.keyAsciiPress != 0)
		{
			if (this.mobCapcha == null)
			{
				if (TField.isQwerty)
				{
					if (GameCanvas.keyPressed[1])
					{
						if (GameScr.keySkill[0] != null)
						{
							this.doSelectSkill(GameScr.keySkill[0], true);
						}
					}
					else if (GameCanvas.keyPressed[2])
					{
						if (GameScr.keySkill[1] != null)
						{
							this.doSelectSkill(GameScr.keySkill[1], true);
						}
					}
					else if (GameCanvas.keyPressed[3])
					{
						if (GameScr.keySkill[2] != null)
						{
							this.doSelectSkill(GameScr.keySkill[2], true);
						}
					}
					else if (GameCanvas.keyPressed[4])
					{
						if (GameScr.keySkill[3] != null)
						{
							this.doSelectSkill(GameScr.keySkill[3], true);
						}
					}
					else if (GameCanvas.keyPressed[5])
					{
						if (GameScr.keySkill[4] != null)
						{
							this.doSelectSkill(GameScr.keySkill[4], true);
						}
					}
					else if (GameCanvas.keyAsciiPress == 114)
					{
						ChatTextField.gI().startChat(this, string.Empty);
					}
				}
				else if (!GameCanvas.isMoveNumberPad)
				{
					ChatTextField.gI().startChat(GameCanvas.keyAsciiPress, this, string.Empty);
				}
				else if (GameCanvas.keyAsciiPress == 55)
				{
					if (GameScr.keySkill[0] != null)
					{
						this.doSelectSkill(GameScr.keySkill[0], true);
					}
				}
				else if (GameCanvas.keyAsciiPress == 56)
				{
					if (GameScr.keySkill[1] != null)
					{
						this.doSelectSkill(GameScr.keySkill[1], true);
					}
				}
				else if (GameCanvas.keyAsciiPress == 57)
				{
					if (GameScr.keySkill[(!Main.isPC) ? 2 : 21] != null)
					{
						this.doSelectSkill(GameScr.keySkill[2], true);
					}
				}
				else if (GameCanvas.keyAsciiPress == 48)
				{
					ChatTextField.gI().startChat(this, string.Empty);
				}
			}
			else
			{
				char[] array = this.keyInput.ToCharArray();
				MyVector myVector = new MyVector();
				for (int j = 0; j < array.Length; j++)
				{
					myVector.addElement(array[j] + string.Empty);
				}
				myVector.removeElementAt(0);
				string text = (char)GameCanvas.keyAsciiPress + string.Empty;
				if (text.Equals(string.Empty) || text == null || text.Equals("\n"))
				{
					text = "-";
				}
				myVector.insertElementAt(text, myVector.size());
				this.keyInput = string.Empty;
				for (int k = 0; k < myVector.size(); k++)
				{
					this.keyInput += ((string)myVector.elementAt(k)).ToUpper();
				}
				Service.gI().mobCapcha((char)GameCanvas.keyAsciiPress);
			}
			GameCanvas.keyAsciiPress = 0;
		}
		if (global::Char.myCharz().statusMe == 1)
		{
			GameCanvas.debug("F10", 0);
			if (!this.doSeleckSkillFlag)
			{
				if (GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25])
				{
					GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] = false;
					this.doFire(false, false);
				}
				else if (GameCanvas.keyHold[(!Main.isPC) ? 2 : 21])
				{
					if (!global::Char.myCharz().isLockMove)
					{
						this.setCharJump(0);
					}
				}
				else if (GameCanvas.keyHold[1] && this.mobCapcha == null)
				{
					if (!Main.isPC)
					{
						global::Char.myCharz().cdir = -1;
						if (!global::Char.myCharz().isLockMove)
						{
							this.setCharJump(-4);
						}
					}
				}
				else if (GameCanvas.keyHold[(!Main.isPC) ? 5 : 25] && this.mobCapcha == null)
				{
					if (!Main.isPC)
					{
						global::Char.myCharz().cdir = 1;
						if (!global::Char.myCharz().isLockMove)
						{
							this.setCharJump(4);
						}
					}
				}
				else if (GameCanvas.keyHold[(!Main.isPC) ? 4 : 23])
				{
					GameScr.isAutoPlay = false;
					global::Char.myCharz().isAttack = false;
					if (global::Char.myCharz().cdir == 1)
					{
						global::Char.myCharz().cdir = -1;
					}
					else if (!global::Char.myCharz().isLockMove)
					{
						if (global::Char.myCharz().cx - global::Char.myCharz().cxSend != 0)
						{
							Service.gI().charMove();
						}
						global::Char.myCharz().statusMe = 2;
						global::Char.myCharz().cvx = -global::Char.myCharz().cspeed;
					}
					global::Char.myCharz().holder = false;
				}
				else if (GameCanvas.keyHold[(!Main.isPC) ? 6 : 24])
				{
					GameScr.isAutoPlay = false;
					global::Char.myCharz().isAttack = false;
					if (global::Char.myCharz().cdir == -1)
					{
						global::Char.myCharz().cdir = 1;
					}
					else if (!global::Char.myCharz().isLockMove)
					{
						if (global::Char.myCharz().cx - global::Char.myCharz().cxSend != 0)
						{
							Service.gI().charMove();
						}
						global::Char.myCharz().statusMe = 2;
						global::Char.myCharz().cvx = global::Char.myCharz().cspeed;
					}
					global::Char.myCharz().holder = false;
				}
			}
		}
		else if (global::Char.myCharz().statusMe == 2)
		{
			GameCanvas.debug("F11", 0);
			if (GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25])
			{
				GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] = false;
				this.doFire(false, true);
			}
			else if (GameCanvas.keyHold[(!Main.isPC) ? 2 : 21])
			{
				if (global::Char.myCharz().cx - global::Char.myCharz().cxSend != 0 || global::Char.myCharz().cy - global::Char.myCharz().cySend != 0)
				{
					Service.gI().charMove();
				}
				global::Char.myCharz().cvy = -10;
				global::Char.myCharz().statusMe = 3;
				global::Char.myCharz().cp1 = 0;
			}
			else if (GameCanvas.keyHold[1] && this.mobCapcha == null)
			{
				if (Main.isPC)
				{
					if (global::Char.myCharz().cx - global::Char.myCharz().cxSend != 0 || global::Char.myCharz().cy - global::Char.myCharz().cySend != 0)
					{
						Service.gI().charMove();
					}
					global::Char.myCharz().cdir = -1;
					global::Char.myCharz().cvy = -10;
					global::Char.myCharz().cvx = -4;
					global::Char.myCharz().statusMe = 3;
					global::Char.myCharz().cp1 = 0;
				}
			}
			else if (GameCanvas.keyHold[3] && this.mobCapcha == null)
			{
				if (!Main.isPC)
				{
					if (global::Char.myCharz().cx - global::Char.myCharz().cxSend != 0 || global::Char.myCharz().cy - global::Char.myCharz().cySend != 0)
					{
						Service.gI().charMove();
					}
					global::Char.myCharz().cdir = 1;
					global::Char.myCharz().cvy = -10;
					global::Char.myCharz().cvx = 4;
					global::Char.myCharz().statusMe = 3;
					global::Char.myCharz().cp1 = 0;
				}
			}
			else if (GameCanvas.keyHold[(!Main.isPC) ? 4 : 23])
			{
				GameScr.isAutoPlay = false;
				if (global::Char.myCharz().cdir == 1)
				{
					global::Char.myCharz().cdir = -1;
				}
				else
				{
					global::Char.myCharz().cvx = -global::Char.myCharz().cspeed + global::Char.myCharz().cBonusSpeed;
				}
			}
			else if (GameCanvas.keyHold[(!Main.isPC) ? 6 : 24])
			{
				GameScr.isAutoPlay = false;
				if (global::Char.myCharz().cdir == -1)
				{
					global::Char.myCharz().cdir = 1;
				}
				else
				{
					global::Char.myCharz().cvx = global::Char.myCharz().cspeed + global::Char.myCharz().cBonusSpeed;
				}
			}
		}
		else if (global::Char.myCharz().statusMe == 3)
		{
			GameScr.isAutoPlay = false;
			GameCanvas.debug("F12", 0);
			if (GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25])
			{
				GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] = false;
				this.doFire(false, true);
			}
			if (GameCanvas.keyHold[(!Main.isPC) ? 4 : 23] || (GameCanvas.keyHold[1] && this.mobCapcha == null))
			{
				if (global::Char.myCharz().cdir == 1)
				{
					global::Char.myCharz().cdir = -1;
				}
				else
				{
					global::Char.myCharz().cvx = -global::Char.myCharz().cspeed;
				}
			}
			else if (GameCanvas.keyHold[(!Main.isPC) ? 6 : 24] || (GameCanvas.keyHold[3] && this.mobCapcha == null))
			{
				if (global::Char.myCharz().cdir == -1)
				{
					global::Char.myCharz().cdir = 1;
				}
				else
				{
					global::Char.myCharz().cvx = global::Char.myCharz().cspeed;
				}
			}
			if ((GameCanvas.keyHold[(!Main.isPC) ? 2 : 21] || ((GameCanvas.keyHold[1] || GameCanvas.keyHold[3]) && this.mobCapcha == null)) && global::Char.myCharz().canFly && global::Char.myCharz().cMP > 0 && global::Char.myCharz().cp1 < 8 && global::Char.myCharz().cvy > -4)
			{
				global::Char.myCharz().cp1++;
				global::Char.myCharz().cvy = -7;
			}
		}
		else if (global::Char.myCharz().statusMe == 4)
		{
			GameCanvas.debug("F13", 0);
			if (GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25])
			{
				GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] = false;
				this.doFire(false, true);
			}
			if (GameCanvas.keyHold[(!Main.isPC) ? 2 : 21] && global::Char.myCharz().cMP > 0 && global::Char.myCharz().canFly)
			{
				GameScr.isAutoPlay = false;
				if ((global::Char.myCharz().cx - global::Char.myCharz().cxSend != 0 || global::Char.myCharz().cy - global::Char.myCharz().cySend != 0) && (Res.abs(global::Char.myCharz().cx - global::Char.myCharz().cxSend) > 96 || Res.abs(global::Char.myCharz().cy - global::Char.myCharz().cySend) > 24))
				{
					Service.gI().charMove();
				}
				global::Char.myCharz().cvy = -10;
				global::Char.myCharz().statusMe = 3;
				global::Char.myCharz().cp1 = 0;
			}
			if (GameCanvas.keyHold[(!Main.isPC) ? 4 : 23])
			{
				GameScr.isAutoPlay = false;
				if (global::Char.myCharz().cdir == 1)
				{
					global::Char.myCharz().cdir = -1;
				}
				else
				{
					global::Char.myCharz().cp1++;
					global::Char.myCharz().cvx = -global::Char.myCharz().cspeed;
					if (global::Char.myCharz().cp1 > 5 && global::Char.myCharz().cvy > 6)
					{
						global::Char.myCharz().statusMe = 10;
						global::Char.myCharz().cp1 = 0;
						global::Char.myCharz().cvy = 0;
					}
				}
			}
			else if (GameCanvas.keyHold[(!Main.isPC) ? 6 : 24])
			{
				GameScr.isAutoPlay = false;
				if (global::Char.myCharz().cdir == -1)
				{
					global::Char.myCharz().cdir = 1;
				}
				else
				{
					global::Char.myCharz().cp1++;
					global::Char.myCharz().cvx = global::Char.myCharz().cspeed;
					if (global::Char.myCharz().cp1 > 5 && global::Char.myCharz().cvy > 6)
					{
						global::Char.myCharz().statusMe = 10;
						global::Char.myCharz().cp1 = 0;
						global::Char.myCharz().cvy = 0;
					}
				}
			}
		}
		else if (global::Char.myCharz().statusMe == 10)
		{
			GameCanvas.debug("F14", 0);
			if (GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25])
			{
				GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] = false;
				this.doFire(false, true);
			}
			if (global::Char.myCharz().canFly && global::Char.myCharz().cMP > 0)
			{
				if (GameCanvas.keyHold[(!Main.isPC) ? 2 : 21])
				{
					GameScr.isAutoPlay = false;
					if ((global::Char.myCharz().cx - global::Char.myCharz().cxSend != 0 || global::Char.myCharz().cy - global::Char.myCharz().cySend != 0) && (Res.abs(global::Char.myCharz().cx - global::Char.myCharz().cxSend) > 96 || Res.abs(global::Char.myCharz().cy - global::Char.myCharz().cySend) > 24))
					{
						Service.gI().charMove();
					}
					global::Char.myCharz().cvy = -10;
					global::Char.myCharz().statusMe = 3;
					global::Char.myCharz().cp1 = 0;
				}
				else if (GameCanvas.keyHold[(!Main.isPC) ? 4 : 23])
				{
					GameScr.isAutoPlay = false;
					if (global::Char.myCharz().cdir == 1)
					{
						global::Char.myCharz().cdir = -1;
					}
					else
					{
						global::Char.myCharz().cvx = -(global::Char.myCharz().cspeed + 1);
					}
				}
				else if (GameCanvas.keyHold[(!Main.isPC) ? 6 : 24])
				{
					if (global::Char.myCharz().cdir == -1)
					{
						global::Char.myCharz().cdir = 1;
					}
					else
					{
						global::Char.myCharz().cvx = global::Char.myCharz().cspeed + 1;
					}
				}
			}
		}
		else if (global::Char.myCharz().statusMe == 7)
		{
			GameCanvas.debug("F15", 0);
			if (GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25])
			{
				GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] = false;
			}
			if (GameCanvas.keyHold[(!Main.isPC) ? 4 : 23])
			{
				GameScr.isAutoPlay = false;
				if (global::Char.myCharz().cdir == 1)
				{
					global::Char.myCharz().cdir = -1;
				}
				else
				{
					global::Char.myCharz().cvx = -global::Char.myCharz().cspeed + 2;
				}
			}
			else if (GameCanvas.keyHold[(!Main.isPC) ? 6 : 24])
			{
				GameScr.isAutoPlay = false;
				if (global::Char.myCharz().cdir == -1)
				{
					global::Char.myCharz().cdir = 1;
				}
				else
				{
					global::Char.myCharz().cvx = global::Char.myCharz().cspeed - 2;
				}
			}
		}
		GameCanvas.debug("F17", 0);
		if (GameCanvas.keyPressed[(!Main.isPC) ? 8 : 22] && GameCanvas.keyAsciiPress != 56)
		{
			GameCanvas.keyPressed[(!Main.isPC) ? 8 : 22] = false;
			global::Char.myCharz().delayFall = 0;
		}
		if (GameCanvas.keyPressed[10])
		{
			GameCanvas.keyPressed[10] = false;
			this.doUseHP();
		}
		GameCanvas.debug("F20", 0);
		GameCanvas.clearKeyPressed();
		GameCanvas.debug("F23", 0);
		this.doSeleckSkillFlag = false;
	}

	// Token: 0x060006AA RID: 1706 RVA: 0x00006B43 File Offset: 0x00004D43
	public bool isVsMap()
	{
		return true;
	}

	// Token: 0x060006AB RID: 1707 RVA: 0x0005B5CC File Offset: 0x000597CC
	private void checkDrag()
	{
		if (GameScr.isAnalog == 1)
		{
			return;
		}
		if (GameScr.gamePad.disableCheckDrag())
		{
			return;
		}
		global::Char.myCharz().cmtoChar = true;
		if (GameScr.isUseTouch)
		{
			return;
		}
		if (GameCanvas.isPointerJustDown)
		{
			GameCanvas.isPointerJustDown = false;
			this.isPointerDowning = true;
			this.ptDownTime = 0;
			this.ptLastDownX = (this.ptFirstDownX = GameCanvas.px);
			this.ptLastDownY = (this.ptFirstDownY = GameCanvas.py);
		}
		if (this.isPointerDowning)
		{
			int num = GameCanvas.px - this.ptLastDownX;
			int num2 = GameCanvas.py - this.ptLastDownY;
			if (!this.isChangingCameraMode && (Res.abs(GameCanvas.px - this.ptFirstDownX) > 15 || Res.abs(GameCanvas.py - this.ptFirstDownY) > 15))
			{
				this.isChangingCameraMode = true;
			}
			this.ptLastDownX = GameCanvas.px;
			this.ptLastDownY = GameCanvas.py;
			this.ptDownTime++;
			if (this.isChangingCameraMode)
			{
				global::Char.myCharz().cmtoChar = false;
				GameScr.cmx -= num;
				GameScr.cmy -= num2;
				if (GameScr.cmx < 24)
				{
					int num3 = (24 - GameScr.cmx) / 3;
					if (num3 != 0)
					{
						GameScr.cmx += num - num / num3;
					}
				}
				if (GameScr.cmx < ((!this.isVsMap()) ? 0 : 24))
				{
					GameScr.cmx = ((!this.isVsMap()) ? 0 : 24);
				}
				if (GameScr.cmx > GameScr.cmxLim)
				{
					int num4 = (GameScr.cmx - GameScr.cmxLim) / 3;
					if (num4 != 0)
					{
						GameScr.cmx += num - num / num4;
					}
				}
				if (GameScr.cmx > GameScr.cmxLim + ((!this.isVsMap()) ? 24 : 0))
				{
					GameScr.cmx = GameScr.cmxLim + ((!this.isVsMap()) ? 24 : 0);
				}
				if (GameScr.cmy < 0)
				{
					int num5 = -GameScr.cmy / 3;
					if (num5 != 0)
					{
						GameScr.cmy += num2 - num2 / num5;
					}
				}
				if (GameScr.cmy < -((!this.isVsMap()) ? 24 : 0))
				{
					GameScr.cmy = -((!this.isVsMap()) ? 24 : 0);
				}
				if (GameScr.cmy > GameScr.cmyLim)
				{
					GameScr.cmy = GameScr.cmyLim;
				}
				GameScr.cmtoX = GameScr.cmx;
				GameScr.cmtoY = GameScr.cmy;
			}
		}
		if (this.isPointerDowning && GameCanvas.isPointerJustRelease)
		{
			this.isPointerDowning = false;
			this.isChangingCameraMode = false;
			if (Res.abs(GameCanvas.px - this.ptFirstDownX) > 15 || Res.abs(GameCanvas.py - this.ptFirstDownY) > 15)
			{
				GameCanvas.isPointerJustRelease = false;
			}
		}
	}

	// Token: 0x060006AC RID: 1708 RVA: 0x0005B8D0 File Offset: 0x00059AD0
	private void checkClick()
	{
		if (this.isCharging())
		{
			return;
		}
		if (this.popUpYesNo != null && this.popUpYesNo.cmdYes != null && this.popUpYesNo.cmdYes.isPointerPressInside())
		{
			this.popUpYesNo.cmdYes.performAction();
			return;
		}
		if (this.checkClickToCapcha())
		{
			return;
		}
		long num = mSystem.currentTimeMillis();
		if (this.lastSingleClick != 0L && num - this.lastSingleClick > 300L)
		{
			this.lastSingleClick = 0L;
			GameCanvas.isPointerJustDown = false;
			if (!this.disableSingleClick)
			{
				this.checkSingleClick();
				GameCanvas.isPointerJustRelease = false;
			}
		}
		if (GameCanvas.isPointerJustRelease)
		{
			this.disableSingleClick = this.checkSingleClickEarly();
			if (num - this.lastSingleClick < 300L)
			{
				this.lastSingleClick = 0L;
				this.checkDoubleClick();
			}
			else
			{
				this.lastSingleClick = num;
				this.lastClickCMX = GameScr.cmx;
				this.lastClickCMY = GameScr.cmy;
			}
			GameCanvas.isPointerJustRelease = false;
		}
	}

	// Token: 0x060006AD RID: 1709 RVA: 0x0005B9E0 File Offset: 0x00059BE0
	private IMapObject findClickToItem(int px, int py)
	{
		IMapObject mapObject = null;
		int num = 0;
		int num2 = 30;
		MyVector[] array = new MyVector[]
		{
			GameScr.vMob,
			GameScr.vNpc,
			GameScr.vItemMap,
			GameScr.vCharInMap
		};
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = 0; j < array[i].size(); j++)
			{
				IMapObject mapObject2 = (IMapObject)array[i].elementAt(j);
				if (!mapObject2.isInvisible())
				{
					if (mapObject2 is Mob)
					{
						Mob mob = (Mob)mapObject2;
						if (mob.isMobMe && mob.Equals(global::Char.myCharz().mobMe))
						{
							goto IL_139;
						}
					}
					int x = mapObject2.getX();
					int y = mapObject2.getY();
					int w = mapObject2.getW();
					int h = mapObject2.getH();
					if (this.inRectangle(px, py, x - w / 2 - num2, y - h - num2, w + num2 * 2, h + num2 * 2))
					{
						if (mapObject == null)
						{
							mapObject = mapObject2;
							num = Res.abs(px - x) + Res.abs(py - y);
							if (i == 1)
							{
								return mapObject;
							}
						}
						else
						{
							int num3 = Res.abs(px - x) + Res.abs(py - y);
							if (num3 < num)
							{
								mapObject = mapObject2;
								num = num3;
							}
						}
					}
				}
				IL_139:;
			}
		}
		return mapObject;
	}

	// Token: 0x060006AE RID: 1710 RVA: 0x00006B46 File Offset: 0x00004D46
	private bool inRectangle(int xClick, int yClick, int x, int y, int w, int h)
	{
		return xClick >= x && xClick <= x + w && yClick >= y && yClick <= y + h;
	}

	// Token: 0x060006AF RID: 1711 RVA: 0x0005BB50 File Offset: 0x00059D50
	private bool checkSingleClickEarly()
	{
		int num = GameCanvas.px + GameScr.cmx;
		int num2 = GameCanvas.py + GameScr.cmy;
		global::Char.myCharz().cancelAttack();
		IMapObject mapObject = this.findClickToItem(num, num2);
		if (mapObject == null)
		{
			return false;
		}
		if (global::Char.myCharz().isAttacPlayerStatus() && global::Char.myCharz().charFocus != null && !mapObject.Equals(global::Char.myCharz().charFocus))
		{
			if (!mapObject.Equals(global::Char.myCharz().charFocus.mobMe))
			{
				if (mapObject is global::Char)
				{
					global::Char @char = (global::Char)mapObject;
					if ((int)@char.cTypePk != 5 && !@char.isAttacPlayerStatus())
					{
						this.checkClickMoveTo(num, num2);
						return false;
					}
				}
			}
		}
		if ((global::Char.myCharz().mobFocus == mapObject || global::Char.myCharz().itemFocus == mapObject) && !Main.isPC)
		{
			this.doDoubleClickToObj(mapObject);
			return true;
		}
		if (TileMap.mapID == 51 && mapObject.Equals(global::Char.myCharz().npcFocus))
		{
			this.checkClickMoveTo(num, num2);
			return false;
		}
		if (global::Char.myCharz().skillPaint != null || global::Char.myCharz().arr != null || global::Char.myCharz().dart != null || global::Char.myCharz().skillInfoPaint() != null)
		{
			return false;
		}
		global::Char.myCharz().focusManualTo(mapObject);
		mapObject.stopMoving();
		return false;
	}

	// Token: 0x060006B0 RID: 1712 RVA: 0x0005BCCC File Offset: 0x00059ECC
	private void checkDoubleClick()
	{
		int num = GameCanvas.px + this.lastClickCMX;
		int num2 = GameCanvas.py + this.lastClickCMY;
		int cy = global::Char.myCharz().cy;
		if (this.isLockKey)
		{
			return;
		}
		IMapObject mapObject = this.findClickToItem(num, num2);
		if (mapObject != null)
		{
			if (mapObject is Mob && !this.isMeCanAttackMob((Mob)mapObject))
			{
				this.checkClickMoveTo(num, num2);
				return;
			}
			if (this.checkClickToBotton(mapObject))
			{
				return;
			}
			if (!mapObject.Equals(global::Char.myCharz().npcFocus) && this.mobCapcha != null)
			{
				return;
			}
			if (global::Char.myCharz().isAttacPlayerStatus() && global::Char.myCharz().charFocus != null && !mapObject.Equals(global::Char.myCharz().charFocus))
			{
				if (!mapObject.Equals(global::Char.myCharz().charFocus.mobMe))
				{
					if (mapObject is global::Char)
					{
						global::Char @char = (global::Char)mapObject;
						if ((int)@char.cTypePk != 5 && !@char.isAttacPlayerStatus())
						{
							this.checkClickMoveTo(num, num2);
							return;
						}
					}
				}
			}
			if (TileMap.mapID == 51 && mapObject.Equals(global::Char.myCharz().npcFocus))
			{
				this.checkClickMoveTo(num, num2);
				return;
			}
			this.doDoubleClickToObj(mapObject);
			return;
		}
		else
		{
			if (this.checkClickToPopup(num, num2))
			{
				return;
			}
			if (this.checkClipTopChatPopUp(num, num2))
			{
				return;
			}
			if (Main.isPC)
			{
				return;
			}
			this.checkClickMoveTo(num, num2);
			return;
		}
	}

	// Token: 0x060006B1 RID: 1713 RVA: 0x0005BE5C File Offset: 0x0005A05C
	private bool checkClickToBotton(IMapObject Object)
	{
		if (Object == null)
		{
			return false;
		}
		int i = Object.getY();
		int num = global::Char.myCharz().cy;
		if (i < num)
		{
			while (i < num)
			{
				num -= 5;
				if (TileMap.tileTypeAt(global::Char.myCharz().cx, num, 8192))
				{
					this.auto = 0;
					global::Char.myCharz().cancelAttack();
					global::Char.myCharz().currentMovePoint = null;
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060006B2 RID: 1714 RVA: 0x0005BED4 File Offset: 0x0005A0D4
	private void doDoubleClickToObj(IMapObject obj)
	{
		if (!obj.Equals(global::Char.myCharz().npcFocus) && this.mobCapcha != null)
		{
			return;
		}
		if (this.checkClickToBotton(obj))
		{
			return;
		}
		this.checkEffToObj(obj);
		global::Char.myCharz().cancelAttack();
		global::Char.myCharz().currentMovePoint = null;
		global::Char.myCharz().cvx = (global::Char.myCharz().cvy = 0);
		obj.stopMoving();
		this.auto = 10;
		this.doFire(false, true);
		this.clickToX = obj.getX();
		this.clickToY = obj.getY();
		this.clickOnTileTop = false;
		this.clickMoving = true;
		this.clickMovingRed = true;
		this.clickMovingTimeOut = 20;
		this.clickMovingP1 = 30;
	}

	// Token: 0x060006B3 RID: 1715 RVA: 0x0005BF98 File Offset: 0x0005A198
	private void checkSingleClick()
	{
		int xClick = GameCanvas.px + this.lastClickCMX;
		int yClick = GameCanvas.py + this.lastClickCMY;
		if (this.isLockKey)
		{
			return;
		}
		if (this.checkClickToPopup(xClick, yClick))
		{
			return;
		}
		if (this.checkClipTopChatPopUp(xClick, yClick))
		{
			return;
		}
		this.checkClickMoveTo(xClick, yClick);
	}

	// Token: 0x060006B4 RID: 1716 RVA: 0x0005BFF0 File Offset: 0x0005A1F0
	private bool checkClipTopChatPopUp(int xClick, int yClick)
	{
		if (this.Equals(GameScr.info2) && GameScr.gI().popUpYesNo != null)
		{
			return false;
		}
		if (GameScr.info2.info.info != null && GameScr.info2.info.info.charInfo != null)
		{
			int x = Res.abs(GameScr.info2.cmx) + GameScr.info2.info.X - 40;
			int y = Res.abs(GameScr.info2.cmy) + GameScr.info2.info.Y;
			if (this.inRectangle(xClick - GameScr.cmx, yClick - GameScr.cmy, x, y, 200, GameScr.info2.info.H))
			{
				GameScr.info2.doClick(10);
				return true;
			}
		}
		return false;
	}

	// Token: 0x060006B5 RID: 1717 RVA: 0x0005C0D0 File Offset: 0x0005A2D0
	private bool checkClickToPopup(int xClick, int yClick)
	{
		for (int i = 0; i < PopUp.vPopups.size(); i++)
		{
			PopUp popUp = (PopUp)PopUp.vPopups.elementAt(i);
			if (this.inRectangle(xClick, yClick, popUp.cx, popUp.cy, popUp.cw, popUp.ch))
			{
				if (popUp.cy <= 24 && TileMap.isInAirMap() && (int)global::Char.myCharz().cTypePk != 0)
				{
					return false;
				}
				if (popUp.isPaint)
				{
					popUp.doClick(10);
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060006B6 RID: 1718 RVA: 0x0005C170 File Offset: 0x0005A370
	private void checkClickMoveTo(int xClick, int yClick)
	{
		if (GameScr.gamePad.disableClickMove())
		{
			return;
		}
		global::Char.myCharz().cancelAttack();
		if (xClick < TileMap.pxw && xClick > TileMap.pxw - 32)
		{
			global::Char.myCharz().currentMovePoint = new MovePoint(TileMap.pxw, yClick);
			return;
		}
		if (xClick < 32 && xClick > 0)
		{
			global::Char.myCharz().currentMovePoint = new MovePoint(0, yClick);
			return;
		}
		if (xClick < TileMap.pxw && xClick > TileMap.pxw - 48)
		{
			global::Char.myCharz().currentMovePoint = new MovePoint(TileMap.pxw, yClick);
			return;
		}
		if (xClick < 48 && xClick > 0)
		{
			global::Char.myCharz().currentMovePoint = new MovePoint(0, yClick);
			return;
		}
		this.clickToX = xClick;
		this.clickToY = yClick;
		this.clickOnTileTop = false;
		global::Char.myCharz().delayFall = 0;
		int num = (!global::Char.myCharz().canFly || global::Char.myCharz().cMP <= 0) ? 1000 : 0;
		if (this.clickToY > global::Char.myCharz().cy && Res.abs(this.clickToX - global::Char.myCharz().cx) < 12)
		{
			return;
		}
		for (int i = 0; i < 60 + num; i += 24)
		{
			if (this.clickToY + i >= TileMap.pxh - 24)
			{
				break;
			}
			if (TileMap.tileTypeAt(this.clickToX, this.clickToY + i, 2))
			{
				this.clickToY = TileMap.tileYofPixel(this.clickToY + i);
				this.clickOnTileTop = true;
				break;
			}
		}
		for (int j = 0; j < 40 + num; j += 24)
		{
			if (TileMap.tileTypeAt(this.clickToX, this.clickToY - j, 2))
			{
				this.clickToY = TileMap.tileYofPixel(this.clickToY - j);
				this.clickOnTileTop = true;
				break;
			}
		}
		this.clickMoving = true;
		this.clickMovingRed = false;
		this.clickMovingP1 = ((!this.clickOnTileTop) ? 30 : ((yClick >= this.clickToY) ? this.clickToY : yClick));
		global::Char.myCharz().delayFall = 0;
		if (!this.clickOnTileTop && this.clickToY < global::Char.myCharz().cy - 50)
		{
			global::Char.myCharz().delayFall = 20;
		}
		this.clickMovingTimeOut = 30;
		this.auto = 0;
		if (global::Char.myCharz().holder)
		{
			global::Char.myCharz().removeHoleEff();
		}
		global::Char.myCharz().currentMovePoint = new MovePoint(this.clickToX, this.clickToY);
		global::Char.myCharz().cdir = ((global::Char.myCharz().cx - global::Char.myCharz().currentMovePoint.xEnd <= 0) ? 1 : -1);
		global::Char.myCharz().endMovePointCommand = null;
		GameScr.isAutoPlay = false;
	}

	// Token: 0x060006B7 RID: 1719 RVA: 0x0005C468 File Offset: 0x0005A668
	private void checkAuto()
	{
		long num = mSystem.currentTimeMillis();
		if (GameCanvas.keyPressed[(!Main.isPC) ? 2 : 21] || GameCanvas.keyPressed[(!Main.isPC) ? 4 : 23] || GameCanvas.keyPressed[(!Main.isPC) ? 6 : 24] || GameCanvas.keyPressed[1] || GameCanvas.keyPressed[3])
		{
			this.auto = 0;
			GameScr.isAutoPlay = false;
		}
		if (GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] && !this.isPaintPopup())
		{
			if (this.auto == 0)
			{
				if (num - this.lastFire < 800L && this.checkSkillValid2() && (global::Char.myCharz().mobFocus != null || (global::Char.myCharz().charFocus != null && global::Char.myCharz().isMeCanAttackOtherPlayer(global::Char.myCharz().charFocus))))
				{
					Res.outz("toi day");
					this.auto = 10;
					GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] = false;
				}
			}
			else
			{
				this.auto = 0;
				GameCanvas.keyPressed[(!Main.isPC) ? 4 : 23] = (GameCanvas.keyPressed[(!Main.isPC) ? 6 : 24] = false);
			}
			this.lastFire = num;
		}
		if (GameCanvas.gameTick % 5 == 0 && this.auto > 0 && global::Char.myCharz().currentMovePoint == null)
		{
			if (global::Char.myCharz().myskill != null && (global::Char.myCharz().myskill.template.isUseAlone() || global::Char.myCharz().myskill.paintCanNotUseSkill))
			{
				return;
			}
			if ((global::Char.myCharz().mobFocus != null && global::Char.myCharz().mobFocus.status != 1 && global::Char.myCharz().mobFocus.status != 0 && global::Char.myCharz().charFocus == null) || (global::Char.myCharz().charFocus != null && global::Char.myCharz().isMeCanAttackOtherPlayer(global::Char.myCharz().charFocus)))
			{
				if (global::Char.myCharz().myskill.paintCanNotUseSkill)
				{
					return;
				}
				this.doFire(false, true);
			}
		}
		if (this.auto > 1)
		{
			this.auto--;
		}
	}

	// Token: 0x060006B8 RID: 1720 RVA: 0x0005C6FC File Offset: 0x0005A8FC
	public void doUseHP()
	{
		if (global::Char.myCharz().stone)
		{
			return;
		}
		if (global::Char.myCharz().blindEff)
		{
			return;
		}
		if (global::Char.myCharz().holdEffID > 0)
		{
			return;
		}
		long num = mSystem.currentTimeMillis();
		if (num - this.lastUsePotion < 10000L)
		{
			return;
		}
		if (!global::Char.myCharz().doUsePotion())
		{
			GameScr.info1.addInfo(mResources.HP_EMPTY, 0);
		}
		else
		{
			ServerEffect.addServerEffect(11, global::Char.myCharz(), 5);
			ServerEffect.addServerEffect(104, global::Char.myCharz(), 4);
			this.lastUsePotion = num;
			SoundMn.gI().eatPeans();
		}
	}

	// Token: 0x060006B9 RID: 1721 RVA: 0x0005C7A4 File Offset: 0x0005A9A4
	public void activeSuperPower(int x, int y)
	{
		if (!this.isSuperPower)
		{
			SoundMn.gI().bigeExlode();
			this.isSuperPower = true;
			this.tPower = 0;
			this.dxPower = 0;
			this.xPower = x - GameScr.cmx;
			this.yPower = y - GameScr.cmy;
		}
	}

	// Token: 0x060006BA RID: 1722 RVA: 0x0005C7F8 File Offset: 0x0005A9F8
	public void activeRongThanEff(bool isMe)
	{
		this.activeRongThan = true;
		this.isUseFreez = true;
		this.isMeCallRongThan = true;
		if (isMe)
		{
			Effect me = new Effect(20, global::Char.myCharz().cx, global::Char.myCharz().cy - 77, 2, 8, 1);
			EffecMn.addEff(me);
		}
	}

	// Token: 0x060006BB RID: 1723 RVA: 0x00006B6F File Offset: 0x00004D6F
	public void hideRongThanEff()
	{
		this.activeRongThan = false;
		this.isUseFreez = true;
		this.isMeCallRongThan = false;
	}

	// Token: 0x060006BC RID: 1724 RVA: 0x00006B86 File Offset: 0x00004D86
	public void doiMauTroi()
	{
		this.isRongThanXuatHien = true;
		this.mautroi = mGraphics.blendColor(0.4f, 0, GameCanvas.colorTop[GameCanvas.colorTop.Length - 1]);
	}

	// Token: 0x060006BD RID: 1725 RVA: 0x0005C848 File Offset: 0x0005AA48
	public void callRongThan(int x, int y)
	{
		Res.outz(string.Concat(new object[]
		{
			"VE RONG THAN O VI TRI x= ",
			x,
			" y=",
			y
		}));
		this.doiMauTroi();
		Effect me = new Effect((!this.isRongNamek) ? 17 : 25, x, y - 77, 2, -1, 1);
		EffecMn.addEff(me);
	}

	// Token: 0x060006BE RID: 1726 RVA: 0x00006BAF File Offset: 0x00004DAF
	public void hideRongThan()
	{
		this.isRongThanXuatHien = false;
		EffecMn.removeEff(17);
		if (this.isRongNamek)
		{
			this.isRongNamek = false;
			EffecMn.removeEff(25);
		}
	}

	// Token: 0x060006BF RID: 1727 RVA: 0x0005C8B8 File Offset: 0x0005AAB8
	private void autoPlay()
	{
		if (this.timeSkill > 0)
		{
			this.timeSkill--;
		}
		if (!GameScr.canAutoPlay)
		{
			return;
		}
		if (GameScr.isChangeZone)
		{
			return;
		}
		if (global::Char.myCharz().statusMe == 14 || global::Char.myCharz().statusMe == 5)
		{
			return;
		}
		if (global::Char.myCharz().isCharge || global::Char.myCharz().isFlyAndCharge || global::Char.myCharz().isUseChargeSkill())
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < GameScr.vMob.size(); i++)
		{
			Mob mob = (Mob)GameScr.vMob.elementAt(i);
			if (mob.status != 0 && mob.status != 1)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			return;
		}
		bool flag2 = false;
		for (int j = 0; j < global::Char.myCharz().arrItemBag.Length; j++)
		{
			Item item = global::Char.myCharz().arrItemBag[j];
			if (item != null && (int)item.template.type == 6)
			{
				flag2 = true;
				break;
			}
		}
		if (!flag2 && GameCanvas.gameTick % 150 == 0)
		{
			Service.gI().requestPean();
		}
		if (global::Char.myCharz().cHP <= global::Char.myCharz().cHPFull * 20 / 100 || global::Char.myCharz().cMP <= global::Char.myCharz().cMPFull * 20 / 100)
		{
			this.doUseHP();
		}
		if (global::Char.myCharz().mobFocus == null || (global::Char.myCharz().mobFocus != null && global::Char.myCharz().mobFocus.isMobMe))
		{
			for (int k = 0; k < GameScr.vMob.size(); k++)
			{
				Mob mob2 = (Mob)GameScr.vMob.elementAt(k);
				if (mob2.status != 0 && mob2.status != 1 && mob2.hp > 0 && !mob2.isMobMe)
				{
					global::Char.myCharz().cx = mob2.x;
					global::Char.myCharz().cy = mob2.y;
					global::Char.myCharz().mobFocus = mob2;
					Service.gI().charMove();
					Res.outz("focus 1 con bossssssssssssssssssssssssssssssssssssssssssssssssss");
					break;
				}
			}
		}
		else if (global::Char.myCharz().mobFocus.hp <= 0 || global::Char.myCharz().mobFocus.status == 1 || global::Char.myCharz().mobFocus.status == 0)
		{
			global::Char.myCharz().mobFocus = null;
		}
		if (global::Char.myCharz().mobFocus != null && this.timeSkill == 0)
		{
			if (global::Char.myCharz().skillInfoPaint() != null && global::Char.myCharz().indexSkill < global::Char.myCharz().skillInfoPaint().Length && global::Char.myCharz().dart != null && global::Char.myCharz().arr != null)
			{
				return;
			}
			Skill skill = null;
			if (GameCanvas.isTouch)
			{
				for (int l = 0; l < GameScr.onScreenSkill.Length; l++)
				{
					if (GameScr.onScreenSkill[l] != null)
					{
						if (!GameScr.onScreenSkill[l].paintCanNotUseSkill)
						{
							if ((int)GameScr.onScreenSkill[l].template.id != 10)
							{
								if ((int)GameScr.onScreenSkill[l].template.id != 11)
								{
									if ((int)GameScr.onScreenSkill[l].template.id != 14)
									{
										if ((int)GameScr.onScreenSkill[l].template.id != 23)
										{
											if ((int)GameScr.onScreenSkill[l].template.id != 7)
											{
												if (global::Char.myCharz().skillInfoPaint() == null)
												{
													int num;
													if (GameScr.onScreenSkill[l].template.manaUseType == 2)
													{
														num = 1;
													}
													else if (GameScr.onScreenSkill[l].template.manaUseType != 1)
													{
														num = GameScr.onScreenSkill[l].manaUse;
													}
													else
													{
														num = GameScr.onScreenSkill[l].manaUse * global::Char.myCharz().cMPFull / 100;
													}
													if (global::Char.myCharz().cMP >= num)
													{
														if (skill == null)
														{
															skill = GameScr.onScreenSkill[l];
														}
														else if (skill.coolDown < GameScr.onScreenSkill[l].coolDown)
														{
															skill = GameScr.onScreenSkill[l];
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				if (skill != null)
				{
					this.doSelectSkill(skill, true);
					this.doDoubleClickToObj(global::Char.myCharz().mobFocus);
				}
			}
			else
			{
				for (int m = 0; m < GameScr.keySkill.Length; m++)
				{
					if (GameScr.keySkill[m] != null)
					{
						if (!GameScr.keySkill[m].paintCanNotUseSkill)
						{
							if ((int)GameScr.keySkill[m].template.id != 10)
							{
								if ((int)GameScr.keySkill[m].template.id != 11)
								{
									if ((int)GameScr.keySkill[m].template.id != 14)
									{
										if ((int)GameScr.keySkill[m].template.id != 23)
										{
											if ((int)GameScr.keySkill[m].template.id != 7)
											{
												if (global::Char.myCharz().skillInfoPaint() == null)
												{
													int num2;
													if (GameScr.keySkill[m].template.manaUseType == 2)
													{
														num2 = 1;
													}
													else if (GameScr.keySkill[m].template.manaUseType != 1)
													{
														num2 = GameScr.keySkill[m].manaUse;
													}
													else
													{
														num2 = GameScr.keySkill[m].manaUse * global::Char.myCharz().cMPFull / 100;
													}
													if (global::Char.myCharz().cMP >= num2)
													{
														if (skill == null)
														{
															skill = GameScr.keySkill[m];
														}
														else if (skill.coolDown < GameScr.keySkill[m].coolDown)
														{
															skill = GameScr.keySkill[m];
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				if (skill != null)
				{
					this.doSelectSkill(skill, true);
					this.doDoubleClickToObj(global::Char.myCharz().mobFocus);
				}
			}
		}
	}

	// Token: 0x060006C0 RID: 1728 RVA: 0x0005CF88 File Offset: 0x0005B188
	private void doFire(bool isFireByShortCut, bool skipWaypoint)
	{
		GameScr.tam++;
		Waypoint waypoint = global::Char.myCharz().isInEnterOfflinePoint();
		Waypoint waypoint2 = global::Char.myCharz().isInEnterOnlinePoint();
		if (!skipWaypoint && waypoint != null && (global::Char.myCharz().mobFocus == null || (global::Char.myCharz().mobFocus != null && global::Char.myCharz().mobFocus.templateId == 0)))
		{
			waypoint.popup.command.performAction();
		}
		else if (!skipWaypoint && waypoint2 != null && (global::Char.myCharz().mobFocus == null || (global::Char.myCharz().mobFocus != null && global::Char.myCharz().mobFocus.templateId == 0)))
		{
			waypoint2.popup.command.performAction();
		}
		else
		{
			if (TileMap.mapID == 51 && global::Char.myCharz().npcFocus != null)
			{
				return;
			}
			if (global::Char.myCharz().statusMe != 14)
			{
				global::Char.myCharz().cvx = (global::Char.myCharz().cvy = 0);
				if (global::Char.myCharz().isSelectingSkillUseAlone() && global::Char.myCharz().focusToAttack())
				{
					if (this.checkSkillValid())
					{
						global::Char.myCharz().currentFireByShortcut = isFireByShortCut;
						global::Char.myCharz().useSkillNotFocus();
					}
				}
				else if (this.isAttack())
				{
					if (global::Char.myCharz().isUseChargeSkill() && global::Char.myCharz().focusToAttack())
					{
						if (this.checkSkillValid())
						{
							global::Char.myCharz().currentFireByShortcut = isFireByShortCut;
							global::Char.myCharz().sendUseChargeSkill();
						}
						else
						{
							global::Char.myCharz().stopUseChargeSkill();
						}
					}
					else
					{
						bool flag = TileMap.tileTypeAt(global::Char.myCharz().cx, global::Char.myCharz().cy, 2);
						global::Char.myCharz().setSkillPaint(GameScr.sks[(int)global::Char.myCharz().myskill.skillId], (!flag) ? 1 : 0);
						if (flag)
						{
							global::Char.myCharz().delayFall = 20;
						}
						global::Char.myCharz().currentFireByShortcut = isFireByShortCut;
					}
				}
				if (global::Char.myCharz().isSelectingSkillBuffToPlayer())
				{
					this.auto = 0;
				}
			}
		}
	}

	// Token: 0x060006C1 RID: 1729 RVA: 0x0005D1C0 File Offset: 0x0005B3C0
	private void askToPick()
	{
		Npc npc = new Npc(5, 0, -100, 100, 5, GameScr.info1.charId[global::Char.myCharz().cgender][2]);
		string nhatvatpham = mResources.nhatvatpham;
		string[] menu = new string[]
		{
			"Có",
			"Không"
		};
		npc.idItem = 673;
		GameScr.gI().createMenu(menu, npc);
		ChatPopup.addChatPopupWithIcon(nhatvatpham, 100000, npc, 5820);
	}

	// Token: 0x060006C2 RID: 1730 RVA: 0x0005D238 File Offset: 0x0005B438
	private void pickItem()
	{
		if (global::Char.myCharz().itemFocus != null)
		{
			if (global::Char.myCharz().cx < global::Char.myCharz().itemFocus.x)
			{
				global::Char.myCharz().cdir = 1;
			}
			else
			{
				global::Char.myCharz().cdir = -1;
			}
			int num = global::Math.abs(global::Char.myCharz().cx - global::Char.myCharz().itemFocus.x);
			int num2 = global::Math.abs(global::Char.myCharz().cy - global::Char.myCharz().itemFocus.y);
			if (num <= 40 && num2 < 40)
			{
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
				if (global::Char.myCharz().itemFocus.template.id != 673)
				{
					Service.gI().pickItem(global::Char.myCharz().itemFocus.itemMapID);
				}
				else
				{
					this.askToPick();
				}
			}
			else
			{
				global::Char.myCharz().currentMovePoint = new MovePoint(global::Char.myCharz().itemFocus.x, global::Char.myCharz().itemFocus.y);
				global::Char.myCharz().endMovePointCommand = new Command(null, null, 8002, null);
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
			}
		}
	}

	// Token: 0x060006C3 RID: 1731 RVA: 0x0005D37C File Offset: 0x0005B57C
	public bool isCharging()
	{
		return global::Char.myCharz().isFlyAndCharge || global::Char.myCharz().isUseSkillAfterCharge || global::Char.myCharz().isStandAndCharge || global::Char.myCharz().isWaitMonkey || this.isSuperPower || global::Char.myCharz().isFreez;
	}

	// Token: 0x060006C4 RID: 1732 RVA: 0x0005D3E4 File Offset: 0x0005B5E4
	public void doSelectSkill(Skill skill, bool isShortcut)
	{
		if (global::Char.myCharz().isCreateDark)
		{
			return;
		}
		if (this.isCharging())
		{
			return;
		}
		if (global::Char.myCharz().taskMaint.taskId <= 1)
		{
			return;
		}
		global::Char.myCharz().myskill = skill;
		if (this.lastSkill != skill && this.lastSkill != null)
		{
			Service.gI().selectSkill((int)skill.template.id);
			this.saveRMSCurrentSkill(skill.template.id);
			this.resetButton();
			this.lastSkill = skill;
			this.selectedIndexSkill = -1;
			GameScr.gI().auto = 0;
			return;
		}
		if (global::Char.myCharz().isSelectingSkillUseAlone())
		{
			Res.outz("use skill not focus");
			this.doUseSkillNotFocus(skill);
			this.lastSkill = skill;
			return;
		}
		this.selectedIndexSkill = -1;
		if (skill != null)
		{
			Res.outz("only select skill");
			if (this.lastSkill != skill)
			{
				Service.gI().selectSkill((int)skill.template.id);
				this.saveRMSCurrentSkill(skill.template.id);
				this.resetButton();
			}
			if (global::Char.myCharz().charFocus == null && global::Char.myCharz().isSelectingSkillBuffToPlayer())
			{
				return;
			}
			if (global::Char.myCharz().focusToAttack())
			{
				this.doFire(isShortcut, true);
				this.doSeleckSkillFlag = true;
			}
			this.lastSkill = skill;
		}
	}

	// Token: 0x060006C5 RID: 1733 RVA: 0x0005D548 File Offset: 0x0005B748
	public void doUseSkill(Skill skill, bool isShortcut)
	{
		if ((TileMap.mapID == 112 || TileMap.mapID == 113) && (int)global::Char.myCharz().cTypePk == 0)
		{
			return;
		}
		if (global::Char.myCharz().isSelectingSkillUseAlone())
		{
			Res.outz("HERE");
			this.doUseSkillNotFocus(skill);
			return;
		}
		this.selectedIndexSkill = -1;
		if (skill != null)
		{
			Service.gI().selectSkill((int)skill.template.id);
			this.saveRMSCurrentSkill(skill.template.id);
			this.resetButton();
			global::Char.myCharz().myskill = skill;
			this.doFire(isShortcut, true);
		}
	}

	// Token: 0x060006C6 RID: 1734 RVA: 0x0005D5EC File Offset: 0x0005B7EC
	public void doUseSkillNotFocus(Skill skill)
	{
		if ((TileMap.mapID == 112 || TileMap.mapID == 113) && (int)global::Char.myCharz().cTypePk == 0)
		{
			return;
		}
		if (this.checkSkillValid())
		{
			this.selectedIndexSkill = -1;
			if (skill != null)
			{
				Service.gI().selectSkill((int)skill.template.id);
				this.saveRMSCurrentSkill(skill.template.id);
				this.resetButton();
				global::Char.myCharz().myskill = skill;
				global::Char.myCharz().useSkillNotFocus();
				global::Char.myCharz().currentFireByShortcut = true;
				this.auto = 0;
			}
		}
	}

	// Token: 0x060006C7 RID: 1735 RVA: 0x0005D690 File Offset: 0x0005B890
	public void sortSkill()
	{
		for (int i = 0; i < global::Char.myCharz().vSkillFight.size() - 1; i++)
		{
			Skill skill = (Skill)global::Char.myCharz().vSkillFight.elementAt(i);
			for (int j = i + 1; j < global::Char.myCharz().vSkillFight.size(); j++)
			{
				Skill skill2 = (Skill)global::Char.myCharz().vSkillFight.elementAt(j);
				if ((int)skill2.template.id < (int)skill.template.id)
				{
					Skill skill3 = skill2;
					skill2 = skill;
					skill = skill3;
					global::Char.myCharz().vSkillFight.setElementAt(skill, i);
					global::Char.myCharz().vSkillFight.setElementAt(skill2, j);
				}
			}
		}
	}

	// Token: 0x060006C8 RID: 1736 RVA: 0x0005D754 File Offset: 0x0005B954
	public void updateKeyTouchCapcha()
	{
		if (this.isNotPaintTouchControl())
		{
			return;
		}
		for (int i = 0; i < this.strCapcha.Length; i++)
		{
			this.keyCapcha[i] = -1;
			if (GameCanvas.isTouchControl)
			{
				int num = (GameCanvas.w - this.strCapcha.Length * GameScr.disXC) / 2;
				int w = this.strCapcha.Length * GameScr.disXC;
				int y = GameCanvas.h - 40;
				int h = GameScr.disXC;
				if (GameCanvas.isPointerHoldIn(num, y, w, h))
				{
					int num2 = (GameCanvas.px - num) / GameScr.disXC;
					if (i == num2)
					{
						this.keyCapcha[i] = 1;
					}
					if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease && i == num2)
					{
						char[] array = this.keyInput.ToCharArray();
						MyVector myVector = new MyVector();
						for (int j = 0; j < array.Length; j++)
						{
							myVector.addElement(array[j] + string.Empty);
						}
						myVector.removeElementAt(0);
						myVector.insertElementAt(this.strCapcha[i] + string.Empty, myVector.size());
						this.keyInput = string.Empty;
						for (int k = 0; k < myVector.size(); k++)
						{
							this.keyInput += ((string)myVector.elementAt(k)).ToUpper();
						}
						Service.gI().mobCapcha(this.strCapcha[i]);
					}
				}
			}
		}
	}

	// Token: 0x060006C9 RID: 1737 RVA: 0x0005D900 File Offset: 0x0005BB00
	public bool checkClickToCapcha()
	{
		if (this.mobCapcha == null)
		{
			return false;
		}
		int x = (GameCanvas.w - 5 * GameScr.disXC) / 2;
		int w = 5 * GameScr.disXC;
		int y = GameCanvas.h - 40;
		int h = GameScr.disXC;
		return GameCanvas.isPointerHoldIn(x, y, w, h);
	}

	// Token: 0x060006CA RID: 1738 RVA: 0x0005D954 File Offset: 0x0005BB54
	public void checkMouseChat()
	{
		if (GameCanvas.isMouseFocus(GameScr.xC, GameScr.yC, 34, 34))
		{
			if (!TileMap.isOfflineMap())
			{
				mScreen.keyMouse = 15;
			}
		}
		else if (GameCanvas.isMouseFocus(GameScr.xHP, GameScr.yHP, 40, 40))
		{
			if (global::Char.myCharz().statusMe != 14)
			{
				mScreen.keyMouse = 10;
			}
		}
		else if (GameCanvas.isMouseFocus(GameScr.xF, GameScr.yF, 40, 40))
		{
			if (global::Char.myCharz().statusMe != 14)
			{
				mScreen.keyMouse = 5;
			}
		}
		else if (this.cmdMenu != null && GameCanvas.isMouseFocus(this.cmdMenu.x, this.cmdMenu.y, this.cmdMenu.w / 2, this.cmdMenu.h))
		{
			mScreen.keyMouse = 1;
		}
		else
		{
			mScreen.keyMouse = -1;
		}
	}

	// Token: 0x060006CB RID: 1739 RVA: 0x0005DA4C File Offset: 0x0005BC4C
	private void updateKeyTouchControl()
	{
		if (this.isNotPaintTouchControl())
		{
			return;
		}
		mScreen.keyTouch = -1;
		if (GameCanvas.isTouchControl)
		{
			if (GameCanvas.isPointerHoldIn(0, 0, 60, 50) && GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
			{
				if (global::Char.myCharz().cmdMenu != null)
				{
					global::Char.myCharz().cmdMenu.performAction();
				}
				global::Char.myCharz().currentMovePoint = null;
				GameCanvas.clearAllPointerEvent();
				this.flareFindFocus = true;
				this.flareTime = 5;
				return;
			}
			if (Main.isPC)
			{
				this.checkMouseChat();
			}
			if (!TileMap.isOfflineMap() && GameCanvas.isPointerHoldIn(GameScr.xC, GameScr.yC, 34, 34))
			{
				mScreen.keyTouch = 15;
				GameCanvas.isPointerJustDown = false;
				this.isPointerDowning = false;
				if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
				{
					ChatTextField.gI().startChat(this, string.Empty);
					SoundMn.gI().buttonClick();
					global::Char.myCharz().currentMovePoint = null;
					GameCanvas.clearAllPointerEvent();
					return;
				}
			}
			if (global::Char.myCharz().cmdMenu != null && GameCanvas.isPointerHoldIn(global::Char.myCharz().cmdMenu.x - 17, global::Char.myCharz().cmdMenu.y - 17, 34, 34))
			{
				mScreen.keyTouch = 20;
				GameCanvas.isPointerJustDown = false;
				this.isPointerDowning = false;
				if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
				{
					GameCanvas.clearAllPointerEvent();
					global::Char.myCharz().cmdMenu.performAction();
					return;
				}
			}
			this.updateGamePad();
			if (((GameScr.isAnalog != 0) ? GameCanvas.isPointerHoldIn(GameScr.xHP, GameScr.yHP, 34, 34) : GameCanvas.isPointerHoldIn(GameScr.xHP, GameScr.yHP, 40, 40)) && global::Char.myCharz().statusMe != 14 && this.mobCapcha == null)
			{
				mScreen.keyTouch = 10;
				GameCanvas.isPointerJustDown = false;
				this.isPointerDowning = false;
				if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
				{
					GameCanvas.keyPressed[10] = true;
					GameCanvas.isPointerClick = (GameCanvas.isPointerJustDown = (GameCanvas.isPointerJustRelease = false));
				}
			}
		}
		if (this.mobCapcha != null)
		{
			this.updateKeyTouchCapcha();
		}
		else if (GameScr.isHaveSelectSkill)
		{
			if (this.isCharging())
			{
				return;
			}
			this.keyTouchSkill = -1;
			if (GameCanvas.isPointerHoldIn(GameScr.xSkill + GameScr.xS[0] - GameScr.wSkill / 2 + 12, GameScr.yS[0] - GameScr.wSkill / 2 + 12, GameScr.onScreenSkill.Length * GameScr.wSkill, GameScr.wSkill) || (!GameCanvas.isTouchControl && GameCanvas.isPointerHoldIn(GameScr.xSkill + GameScr.xS[0] - GameScr.wSkill / 2 + 12, GameScr.yS[0] - GameScr.wSkill / 2 + 12, GameScr.wSkill, GameScr.onScreenSkill.Length * GameScr.wSkill)))
			{
				GameCanvas.isPointerJustDown = false;
				this.isPointerDowning = false;
				int num = (GameCanvas.pxLast - (GameScr.xSkill + GameScr.xS[0] - GameScr.wSkill / 2 + 12)) / GameScr.wSkill;
				this.keyTouchSkill = num;
				if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
				{
					GameCanvas.isPointerClick = (GameCanvas.isPointerJustDown = (GameCanvas.isPointerJustRelease = false));
					this.selectedIndexSkill = num;
					if (GameScr.indexSelect < 0)
					{
						GameScr.indexSelect = 0;
					}
					if (!Main.isPC)
					{
						if (this.selectedIndexSkill > GameScr.onScreenSkill.Length - 1)
						{
							this.selectedIndexSkill = GameScr.onScreenSkill.Length - 1;
						}
					}
					else if (this.selectedIndexSkill > GameScr.keySkill.Length - 1)
					{
						this.selectedIndexSkill = GameScr.keySkill.Length - 1;
					}
					Skill skill;
					if (!Main.isPC)
					{
						skill = GameScr.onScreenSkill[this.selectedIndexSkill];
					}
					else
					{
						skill = GameScr.keySkill[this.selectedIndexSkill];
					}
					if (skill != null)
					{
						this.doSelectSkill(skill, true);
					}
				}
			}
		}
		if (GameCanvas.isPointerJustRelease)
		{
			if (GameCanvas.keyHold[1] || (GameCanvas.keyHold[(!Main.isPC) ? 2 : 21] || GameCanvas.keyHold[3]) || GameCanvas.keyHold[(!Main.isPC) ? 4 : 23] || GameCanvas.keyHold[(!Main.isPC) ? 6 : 24])
			{
				GameCanvas.isPointerJustRelease = false;
			}
			GameCanvas.keyHold[1] = false;
			GameCanvas.keyHold[(!Main.isPC) ? 2 : 21] = false;
			GameCanvas.keyHold[3] = false;
			GameCanvas.keyHold[(!Main.isPC) ? 4 : 23] = false;
			GameCanvas.keyHold[(!Main.isPC) ? 6 : 24] = false;
		}
	}

	// Token: 0x060006CC RID: 1740 RVA: 0x00006BD8 File Offset: 0x00004DD8
	public void setCharJumpAtt()
	{
		global::Char.myCharz().cvy = -10;
		global::Char.myCharz().statusMe = 3;
		global::Char.myCharz().cp1 = 0;
	}

	// Token: 0x060006CD RID: 1741 RVA: 0x0005DF20 File Offset: 0x0005C120
	public void setCharJump(int cvx)
	{
		if (global::Char.myCharz().cx - global::Char.myCharz().cxSend != 0 || global::Char.myCharz().cy - global::Char.myCharz().cySend != 0)
		{
			Service.gI().charMove();
		}
		global::Char.myCharz().cvy = -10;
		global::Char.myCharz().cvx = cvx;
		global::Char.myCharz().statusMe = 3;
		global::Char.myCharz().cp1 = 0;
	}

	// Token: 0x060006CE RID: 1742 RVA: 0x0005DF98 File Offset: 0x0005C198
	public void updateOpen()
	{
		if (!this.isstarOpen)
		{
			return;
		}
		if (this.moveUp > -3)
		{
			this.moveUp -= 4;
		}
		else
		{
			this.moveUp = -2;
		}
		if (this.moveDow < GameCanvas.h + 3)
		{
			this.moveDow += 4;
		}
		else
		{
			this.moveDow = GameCanvas.h + 2;
		}
		if (this.moveUp <= -2 && this.moveDow >= GameCanvas.h + 2)
		{
			this.isstarOpen = false;
		}
	}

	// Token: 0x060006CF RID: 1743 RVA: 0x00003984 File Offset: 0x00001B84
	public void initCreateCommand()
	{
	}

	// Token: 0x060006D0 RID: 1744 RVA: 0x00003984 File Offset: 0x00001B84
	public void checkCharFocus()
	{
	}

	// Token: 0x060006D1 RID: 1745 RVA: 0x0005E034 File Offset: 0x0005C234
	public void updateXoSo()
	{
		if (this.tShow != 0)
		{
			GameScr.currXS = mSystem.currentTimeMillis();
			if (GameScr.currXS - GameScr.lastXS > 1000L)
			{
				GameScr.lastXS = mSystem.currentTimeMillis();
				GameScr.secondXS++;
			}
			if (GameScr.secondXS > 20)
			{
				for (int i = 0; i < this.winnumber.Length; i++)
				{
					this.randomNumber[i] = this.winnumber[i];
				}
				this.tShow--;
				if (this.tShow == 0)
				{
					this.yourNumber = string.Empty;
					GameScr.info1.addInfo(this.strFinish, 0);
					GameScr.secondXS = 0;
				}
				return;
			}
			if (this.moveIndex > this.winnumber.Length - 1)
			{
				this.tShow--;
				if (this.tShow == 0)
				{
					this.yourNumber = string.Empty;
					GameScr.info1.addInfo(this.strFinish, 0);
				}
				return;
			}
			if (this.moveIndex < this.randomNumber.Length)
			{
				if (this.tMove[this.moveIndex] == 15)
				{
					if (this.randomNumber[this.moveIndex] == this.winnumber[this.moveIndex] - 1)
					{
						this.delayMove[this.moveIndex] = 10;
					}
					if (this.randomNumber[this.moveIndex] == this.winnumber[this.moveIndex])
					{
						this.tMove[this.moveIndex] = -1;
						this.moveIndex++;
					}
				}
				else if (GameCanvas.gameTick % 5 == 0)
				{
					this.tMove[this.moveIndex]++;
				}
			}
			for (int j = 0; j < this.winnumber.Length; j++)
			{
				if (this.tMove[j] != -1)
				{
					this.moveCount[j]++;
					if (this.moveCount[j] > this.tMove[j] + this.delayMove[j])
					{
						this.moveCount[j] = 0;
						this.randomNumber[j]++;
						if (this.randomNumber[j] >= 10)
						{
							this.randomNumber[j] = 0;
						}
					}
				}
			}
		}
	}

	// Token: 0x060006D2 RID: 1746 RVA: 0x0005E280 File Offset: 0x0005C480
	public override void update()
	{
		if (GameCanvas.keyPressed[16])
		{
			GameCanvas.keyPressed[16] = false;
			global::Char.myCharz().findNextFocusByKey();
		}
		if (GameCanvas.keyPressed[13] && !GameCanvas.panel.isShow)
		{
			GameCanvas.keyPressed[13] = false;
			global::Char.myCharz().findNextFocusByKey();
		}
		if (GameCanvas.keyPressed[17])
		{
			GameCanvas.keyPressed[17] = false;
			global::Char.myCharz().searchItem();
			if (global::Char.myCharz().itemFocus != null)
			{
				this.pickItem();
			}
		}
		if (GameCanvas.gameTick % 100 == 0 && TileMap.mapID == 137)
		{
			GameScr.shock_scr = 30;
		}
		if (GameScr.isAutoPlay && GameCanvas.gameTick % 20 == 0)
		{
			this.autoPlay();
		}
		this.updateXoSo();
		mSystem.checkAdComlete();
		SmallImage.update();
		try
		{
			if (LoginScr.isContinueToLogin)
			{
				LoginScr.isContinueToLogin = false;
			}
			if (GameScr.tickMove == 1)
			{
				GameScr.lastTick = mSystem.currentTimeMillis();
			}
			if (GameScr.tickMove == 100)
			{
				GameScr.tickMove = 0;
				GameScr.currTick = mSystem.currentTimeMillis();
				int second = (int)(GameScr.currTick - GameScr.lastTick) / 1000;
				Service.gI().checkMMove(second);
			}
			if (GameScr.lockTick > 0)
			{
				GameScr.lockTick--;
				if (GameScr.lockTick == 0)
				{
					Controller.isStopReadMessage = false;
				}
			}
			this.checkCharFocus();
			GameCanvas.debug("E1", 0);
			GameScr.updateCamera();
			GameCanvas.debug("E2", 0);
			ChatTextField.gI().update();
			GameCanvas.debug("E3", 0);
			for (int i = 0; i < GameScr.vCharInMap.size(); i++)
			{
				((global::Char)GameScr.vCharInMap.elementAt(i)).update();
			}
			for (int i = 0; i < Teleport.vTeleport.size(); i++)
			{
				((Teleport)Teleport.vTeleport.elementAt(i)).update();
			}
			global::Char.myCharz().update();
			if (global::Char.myCharz().statusMe == 1)
			{
			}
			if (this.popUpYesNo != null)
			{
				this.popUpYesNo.update();
			}
			EffecMn.update();
			GameCanvas.debug("E5x", 0);
			for (int i = 0; i < GameScr.vMob.size(); i++)
			{
				((Mob)GameScr.vMob.elementAt(i)).update();
			}
			GameCanvas.debug("E6", 0);
			for (int i = 0; i < GameScr.vNpc.size(); i++)
			{
				((Npc)GameScr.vNpc.elementAt(i)).update();
			}
			this.nSkill = GameScr.onScreenSkill.Length;
			for (int i = GameScr.onScreenSkill.Length - 1; i >= 0; i--)
			{
				Skill skill = GameScr.onScreenSkill[i];
				if (skill != null)
				{
					this.nSkill = i + 1;
					break;
				}
				this.nSkill--;
			}
			if (this.nSkill == 1 && GameCanvas.isTouch)
			{
				GameScr.xSkill = -200;
			}
			else if (GameScr.xSkill < 0)
			{
				GameScr.setSkillBarPosition();
			}
			GameCanvas.debug("E7", 0);
			GameCanvas.gI().updateDust();
			GameCanvas.debug("E8", 0);
			GameScr.updateFlyText();
			PopUp.updateAll();
			GameScr.updateSplash();
			this.updateSS();
			GameCanvas.updateBG();
			GameCanvas.debug("E9", 0);
			this.updateClickToArrow();
			GameCanvas.debug("E10", 0);
			for (int i = 0; i < GameScr.vItemMap.size(); i++)
			{
				((ItemMap)GameScr.vItemMap.elementAt(i)).update();
			}
			GameCanvas.debug("E11", 0);
			GameCanvas.debug("E13", 0);
			for (int i = Effect2.vRemoveEffect2.size() - 1; i >= 0; i--)
			{
				Effect2.vEffect2.removeElement(Effect2.vRemoveEffect2.elementAt(i));
				Effect2.vRemoveEffect2.removeElementAt(i);
			}
			for (int i = 0; i < Effect2.vEffect2.size(); i++)
			{
				Effect2 effect = (Effect2)Effect2.vEffect2.elementAt(i);
				effect.update();
			}
			for (int i = 0; i < Effect2.vEffect2Outside.size(); i++)
			{
				Effect2 effect2 = (Effect2)Effect2.vEffect2Outside.elementAt(i);
				effect2.update();
			}
			for (int i = 0; i < Effect2.vAnimateEffect.size(); i++)
			{
				Effect2 effect3 = (Effect2)Effect2.vAnimateEffect.elementAt(i);
				effect3.update();
			}
			for (int i = 0; i < Effect2.vEffectFeet.size(); i++)
			{
				Effect2 effect4 = (Effect2)Effect2.vEffectFeet.elementAt(i);
				effect4.update();
			}
			for (int i = 0; i < Effect2.vEffect3.size(); i++)
			{
				Effect2 effect5 = (Effect2)Effect2.vEffect3.elementAt(i);
				effect5.update();
			}
			BackgroudEffect.updateEff();
			GameScr.info1.update();
			GameScr.info2.update();
			GameCanvas.debug("E15", 0);
			if (GameScr.currentCharViewInfo != null && !GameScr.currentCharViewInfo.Equals(global::Char.myCharz()))
			{
				GameScr.currentCharViewInfo.update();
			}
			this.runArrow++;
			if (this.runArrow > 3)
			{
				this.runArrow = 0;
			}
			if (this.isInjureHp)
			{
				this.twHp++;
				if (this.twHp == 20)
				{
					this.twHp = 0;
					this.isInjureHp = false;
				}
			}
			else if (this.dHP > global::Char.myCharz().cHP)
			{
				int num = this.dHP - global::Char.myCharz().cHP >> 1;
				if (num < 1)
				{
					num = 1;
				}
				this.dHP -= num;
			}
			else
			{
				this.dHP = global::Char.myCharz().cHP;
			}
			if (this.isInjureMp)
			{
				this.twMp++;
				if (this.twMp == 20)
				{
					this.twMp = 0;
					this.isInjureMp = false;
				}
			}
			else if (this.dMP > global::Char.myCharz().cMP)
			{
				int num2 = this.dMP - global::Char.myCharz().cMP >> 1;
				if (num2 < 1)
				{
					num2 = 1;
				}
				this.dMP -= num2;
			}
			else
			{
				this.dMP = global::Char.myCharz().cMP;
			}
			if (this.tMenuDelay > 0)
			{
				this.tMenuDelay--;
			}
			if (this.isRongThanMenu())
			{
				int num3 = 100;
				while (this.yR - num3 < GameScr.cmy)
				{
					GameScr.cmy--;
				}
			}
			for (int i = 0; i < global::Char.vItemTime.size(); i++)
			{
				((ItemTime)global::Char.vItemTime.elementAt(i)).update();
			}
			for (int i = 0; i < GameScr.textTime.size(); i++)
			{
				((ItemTime)GameScr.textTime.elementAt(i)).update();
			}
			this.updateChatVip();
		}
		catch (Exception ex)
		{
		}
		int num4 = GameCanvas.gameTick % 4000;
		if (num4 == 1000)
		{
			GameScr.checkRemoveImage();
		}
	}

	// Token: 0x060006D3 RID: 1747 RVA: 0x00003984 File Offset: 0x00001B84
	public void updateKeyChatPopUp()
	{
	}

	// Token: 0x060006D4 RID: 1748 RVA: 0x00006BFC File Offset: 0x00004DFC
	public bool isRongThanMenu()
	{
		return this.isMeCallRongThan;
	}

	// Token: 0x060006D5 RID: 1749 RVA: 0x0005EA14 File Offset: 0x0005CC14
	public void paintEffect(mGraphics g)
	{
		for (int i = 0; i < Effect2.vEffect2.size(); i++)
		{
			Effect2 effect = (Effect2)Effect2.vEffect2.elementAt(i);
			if (!(effect is ChatPopup))
			{
				effect.paint(g);
			}
		}
		if (!GameCanvas.lowGraphic)
		{
			for (int i = 0; i < Effect2.vAnimateEffect.size(); i++)
			{
				Effect2 effect2 = (Effect2)Effect2.vAnimateEffect.elementAt(i);
				effect2.paint(g);
			}
		}
		for (int i = 0; i < Effect2.vEffect2Outside.size(); i++)
		{
			Effect2 effect3 = (Effect2)Effect2.vEffect2Outside.elementAt(i);
			effect3.paint(g);
		}
	}

	// Token: 0x060006D6 RID: 1750 RVA: 0x0005EAD0 File Offset: 0x0005CCD0
	public void paintBgItem(mGraphics g, int layer)
	{
		for (int i = 0; i < TileMap.vCurrItem.size(); i++)
		{
			BgItem bgItem = (BgItem)TileMap.vCurrItem.elementAt(i);
			if (bgItem.idImage != -1 && (int)bgItem.layer == layer)
			{
				bgItem.paint(g);
			}
		}
		if (TileMap.mapID == 48 && layer == 3 && !GameCanvas.lowGraphic && GameCanvas.bgW != null && GameCanvas.bgW[0] != 0)
		{
			for (int j = 0; j < TileMap.pxw / GameCanvas.bgW[0] + 1; j++)
			{
				g.drawImage(GameCanvas.imgBG[0], j * GameCanvas.bgW[0], TileMap.pxh - GameCanvas.bgH[0] - 70, 0);
			}
		}
	}

	// Token: 0x060006D7 RID: 1751 RVA: 0x00006C0C File Offset: 0x00004E0C
	public void paintBlackSky(mGraphics g)
	{
		if (GameCanvas.lowGraphic)
		{
			return;
		}
		g.fillTrans(GameScr.imgTrans, 0, 0, GameCanvas.w, GameCanvas.h);
	}

	// Token: 0x060006D8 RID: 1752 RVA: 0x0005EBA4 File Offset: 0x0005CDA4
	public void paintCapcha(mGraphics g)
	{
		MobCapcha.paint(g, global::Char.myCharz().cx, global::Char.myCharz().cy);
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		if (GameCanvas.menu.showMenu)
		{
			return;
		}
		if (GameCanvas.panel.isShow)
		{
			return;
		}
		if (ChatPopup.currChatPopup != null)
		{
			return;
		}
		if (GameCanvas.isTouch)
		{
			for (int i = 0; i < this.strCapcha.Length; i++)
			{
				int x = (GameCanvas.w - this.strCapcha.Length * GameScr.disXC) / 2 + i * GameScr.disXC + GameScr.disXC / 2;
				if (this.keyCapcha[i] == -1)
				{
					g.drawImage(GameScr.imgNut, x, GameCanvas.h - 25, 3);
					mFont.tahoma_7b_dark.drawString(g, this.strCapcha[i] + string.Empty, x, GameCanvas.h - 30, 2);
				}
				else
				{
					g.drawImage(GameScr.imgNutF, x, GameCanvas.h - 25, 3);
					mFont.tahoma_7b_green2.drawString(g, this.strCapcha[i] + string.Empty, x, GameCanvas.h - 30, 2);
				}
			}
		}
	}

	// Token: 0x060006D9 RID: 1753 RVA: 0x0005ECF8 File Offset: 0x0005CEF8
	public override void paint(mGraphics g)
	{
		GameScr.countEff = 0;
		if (!GameScr.isPaint)
		{
			return;
		}
		GameCanvas.debug("PA1", 1);
		if (this.isFreez || (this.isUseFreez && ChatPopup.currChatPopup == null))
		{
			this.dem++;
			if ((this.dem < 30 && this.dem >= 0 && GameCanvas.gameTick % 4 == 0) || (this.dem >= 30 && this.dem <= 50 && GameCanvas.gameTick % 3 == 0) || this.dem > 50)
			{
				g.setColor(16777215);
				g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
				if (this.dem > 50)
				{
					if (this.isUseFreez)
					{
						this.isUseFreez = false;
						this.dem = 0;
						if (this.activeRongThan)
						{
							this.callRongThan(this.xR, this.yR);
						}
						else
						{
							this.hideRongThan();
						}
					}
					this.paintInfoBar(g);
					g.translate(-GameScr.cmx, -GameScr.cmy);
					g.translate(0, GameCanvas.transY);
					global::Char.myCharz().paint(g);
					mSystem.paintFlyText(g);
					GameScr.resetTranslate(g);
					this.paintSelectedSkill(g);
					return;
				}
				return;
			}
		}
		GameCanvas.debug("PA2", 1);
		GameCanvas.paintBGGameScr(g);
		if ((this.isRongThanXuatHien || this.isFireWorks) && TileMap.bgID != 3)
		{
			this.paintBlackSky(g);
		}
		GameCanvas.debug("PA3", 1);
		if (GameScr.shock_scr > 0)
		{
			g.translate(-GameScr.cmx + GameScr.shock_x[GameScr.shock_scr % GameScr.shock_x.Length], -GameScr.cmy + GameScr.shock_y[GameScr.shock_scr % GameScr.shock_y.Length]);
			GameScr.shock_scr--;
		}
		else
		{
			g.translate(-GameScr.cmx, -GameScr.cmy);
		}
		if (this.isSuperPower)
		{
			int tx = (GameCanvas.gameTick % 3 != 0) ? -3 : 3;
			g.translate(tx, 0);
		}
		BackgroudEffect.paintBehindTileAll(g);
		EffecMn.paintLayer1(g);
		TileMap.paintTilemap(g);
		TileMap.paintOutTilemap(g);
		for (int i = 0; i < GameScr.vCharInMap.size(); i++)
		{
			global::Char @char = (global::Char)GameScr.vCharInMap.elementAt(i);
			if (@char.isMabuHold && TileMap.mapID == 128)
			{
				@char.paintHeadWithXY(g, @char.cx, @char.cy, 0);
			}
		}
		if (global::Char.myCharz().isMabuHold && TileMap.mapID == 128)
		{
			global::Char.myCharz().paintHeadWithXY(g, global::Char.myCharz().cx, global::Char.myCharz().cy, 0);
		}
		this.paintBgItem(g, 2);
		if (global::Char.myCharz().cmdMenu != null && GameCanvas.isTouch)
		{
			if (mScreen.keyTouch == 20)
			{
				g.drawImage(GameScr.imgChat2, global::Char.myCharz().cmdMenu.x + GameScr.cmx, global::Char.myCharz().cmdMenu.y + GameScr.cmy, mGraphics.HCENTER | mGraphics.VCENTER);
			}
			else
			{
				g.drawImage(GameScr.imgChat, global::Char.myCharz().cmdMenu.x + GameScr.cmx, global::Char.myCharz().cmdMenu.y + GameScr.cmy, mGraphics.HCENTER | mGraphics.VCENTER);
			}
		}
		GameCanvas.debug("PA4", 1);
		GameCanvas.debug("PA5", 1);
		BackgroudEffect.paintBackAll(g);
		for (int i = 0; i < Effect2.vEffectFeet.size(); i++)
		{
			Effect2 effect = (Effect2)Effect2.vEffectFeet.elementAt(i);
			effect.paint(g);
		}
		for (int i = 0; i < Teleport.vTeleport.size(); i++)
		{
			((Teleport)Teleport.vTeleport.elementAt(i)).paintHole(g);
		}
		for (int i = 0; i < GameScr.vNpc.size(); i++)
		{
			Npc npc = (Npc)GameScr.vNpc.elementAt(i);
			if (npc.cHP > 0)
			{
				npc.paintShadow(g);
			}
		}
		for (int i = 0; i < GameScr.vNpc.size(); i++)
		{
			((Npc)GameScr.vNpc.elementAt(i)).paint(g);
		}
		g.translate(0, GameCanvas.transY);
		GameCanvas.debug("PA7", 1);
		GameCanvas.debug("PA8", 1);
		for (int i = 0; i < GameScr.vCharInMap.size(); i++)
		{
			global::Char char2 = null;
			try
			{
				char2 = (global::Char)GameScr.vCharInMap.elementAt(i);
			}
			catch (Exception ex)
			{
				Cout.LogError("Loi ham paint char gamesc: " + ex.ToString());
			}
			if (char2 != null)
			{
				if (!GameCanvas.panel.isShow || !GameCanvas.panel.isTypeShop())
				{
					if (char2.isShadown)
					{
						char2.paintShadow(g);
					}
				}
			}
		}
		global::Char.myCharz().paintShadow(g);
		EffecMn.paintLayer2(g);
		for (int i = 0; i < GameScr.vMob.size(); i++)
		{
			((Mob)GameScr.vMob.elementAt(i)).paint(g);
		}
		for (int i = 0; i < Teleport.vTeleport.size(); i++)
		{
			((Teleport)Teleport.vTeleport.elementAt(i)).paint(g);
		}
		for (int i = 0; i < GameScr.vCharInMap.size(); i++)
		{
			global::Char char3 = null;
			try
			{
				char3 = (global::Char)GameScr.vCharInMap.elementAt(i);
			}
			catch (Exception ex2)
			{
			}
			if (char3 != null)
			{
				if (!GameCanvas.panel.isShow || !GameCanvas.panel.isTypeShop())
				{
					char3.paint(g);
				}
			}
		}
		global::Char.myCharz().paint(g);
		if (global::Char.myCharz().skillPaint != null && global::Char.myCharz().skillInfoPaint() != null && global::Char.myCharz().indexSkill < global::Char.myCharz().skillInfoPaint().Length)
		{
			global::Char.myCharz().paintCharWithSkill(g);
			global::Char.myCharz().paintMount2(g);
		}
		for (int i = 0; i < GameScr.vCharInMap.size(); i++)
		{
			global::Char char4 = null;
			try
			{
				char4 = (global::Char)GameScr.vCharInMap.elementAt(i);
			}
			catch (Exception ex3)
			{
				Cout.LogError("Loi ham paint char gamescr: " + ex3.ToString());
			}
			if (char4 != null)
			{
				if (!GameCanvas.panel.isShow || !GameCanvas.panel.isTypeShop())
				{
					if (char4.skillPaint != null && char4.skillInfoPaint() != null && char4.indexSkill < char4.skillInfoPaint().Length)
					{
						char4.paintCharWithSkill(g);
						char4.paintMount2(g);
					}
				}
			}
		}
		for (int i = 0; i < GameScr.vItemMap.size(); i++)
		{
			((ItemMap)GameScr.vItemMap.elementAt(i)).paint(g);
		}
		g.translate(0, -GameCanvas.transY);
		GameCanvas.debug("PA9", 1);
		GameScr.paintSplash(g);
		GameCanvas.debug("PA10", 1);
		GameCanvas.debug("PA11", 1);
		GameCanvas.debug("PA13", 1);
		this.paintEffect(g);
		this.paintBgItem(g, 3);
		for (int i = 0; i < GameScr.vNpc.size(); i++)
		{
			Npc npc2 = (Npc)GameScr.vNpc.elementAt(i);
			npc2.paintName(g);
		}
		EffecMn.paintLayer3(g);
		for (int i = 0; i < GameScr.vNpc.size(); i++)
		{
			Npc npc3 = (Npc)GameScr.vNpc.elementAt(i);
			if (npc3.chatInfo != null)
			{
				if (npc3 != null)
				{
					npc3.chatInfo.paint(g, npc3.cx, npc3.cy - npc3.ch - GameCanvas.transY, npc3.cdir);
				}
			}
		}
		for (int i = 0; i < GameScr.vCharInMap.size(); i++)
		{
			global::Char char5 = null;
			try
			{
				char5 = (global::Char)GameScr.vCharInMap.elementAt(i);
			}
			catch (Exception ex4)
			{
			}
			if (char5 != null)
			{
				if (char5.chatInfo != null)
				{
					char5.chatInfo.paint(g, char5.cx, char5.cy - char5.ch, char5.cdir);
				}
			}
		}
		if (global::Char.myCharz().chatInfo != null)
		{
			global::Char.myCharz().chatInfo.paint(g, global::Char.myCharz().cx, global::Char.myCharz().cy - global::Char.myCharz().ch, global::Char.myCharz().cdir);
		}
		BackgroudEffect.paintFrontAll(g);
		for (int j = 0; j < TileMap.vCurrItem.size(); j++)
		{
			BgItem bgItem = (BgItem)TileMap.vCurrItem.elementAt(j);
			if (bgItem.idImage != -1 && (int)bgItem.layer > 3)
			{
				bgItem.paint(g);
			}
		}
		PopUp.paintAll(g);
		if (TileMap.mapID == 120)
		{
			if ((int)this.percentMabu != 100)
			{
				int w = (int)this.percentMabu * mGraphics.getImageWidth(GameScr.imgHPLost) / 100;
				int num = (int)this.percentMabu;
				g.drawImage(GameScr.imgHPLost, TileMap.pxw / 2 - mGraphics.getImageWidth(GameScr.imgHPLost) / 2, 220, 0);
				g.setClip(TileMap.pxw / 2 - mGraphics.getImageWidth(GameScr.imgHPLost) / 2, 220, w, 10);
				g.drawImage(GameScr.imgHP, TileMap.pxw / 2 - mGraphics.getImageWidth(GameScr.imgHPLost) / 2, 220, 0);
				g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
			}
			if (this.mabuEff)
			{
				this.tMabuEff++;
				if (GameCanvas.gameTick % 3 == 0)
				{
					Effect me = new Effect(19, Res.random(TileMap.pxw / 2 - 50, TileMap.pxw / 2 + 50), 340, 2, 1, -1);
					EffecMn.addEff(me);
				}
				if (GameCanvas.gameTick % 15 == 0)
				{
					Effect me2 = new Effect(18, Res.random(TileMap.pxw / 2 - 5, TileMap.pxw / 2 + 5), Res.random(300, 320), 2, 1, -1);
					EffecMn.addEff(me2);
				}
				if (this.tMabuEff == 100)
				{
					this.activeSuperPower(TileMap.pxw / 2, 300);
				}
				if (this.tMabuEff == 110)
				{
					this.tMabuEff = 0;
					this.mabuEff = false;
				}
			}
		}
		BackgroudEffect.paintFog(g);
		bool flag = true;
		for (int i = 0; i < BackgroudEffect.vBgEffect.size(); i++)
		{
			BackgroudEffect backgroudEffect = (BackgroudEffect)BackgroudEffect.vBgEffect.elementAt(i);
			if (backgroudEffect.typeEff == 0)
			{
				flag = false;
				break;
			}
		}
		if (mGraphics.zoomLevel <= 1 || Main.isIpod || Main.isIphone4)
		{
			flag = false;
		}
		if (flag && !this.isRongThanXuatHien)
		{
			int num2 = TileMap.pxw / (mGraphics.getImageWidth(TileMap.imgLight) + 50);
			if (num2 <= 0)
			{
				num2 = 1;
			}
			if (TileMap.tileID != 28)
			{
				for (int i = 0; i < num2; i++)
				{
					int num3 = 100 + i * (mGraphics.getImageWidth(TileMap.imgLight) + 50) - GameScr.cmx / 2;
					int num4 = -20;
					int imageWidth = mGraphics.getImageWidth(TileMap.imgLight);
					if (num3 + imageWidth >= GameScr.cmx && num3 <= GameScr.cmx + GameCanvas.w && num4 + mGraphics.getImageHeight(TileMap.imgLight) >= GameScr.cmy && num4 <= GameScr.cmy + GameCanvas.h)
					{
						g.drawImage(TileMap.imgLight, 100 + i * (mGraphics.getImageWidth(TileMap.imgLight) + 50) - GameScr.cmx / 2, num4, 0);
					}
				}
			}
		}
		mSystem.paintFlyText(g);
		GameCanvas.debug("PA14", 1);
		GameCanvas.debug("PA15", 1);
		GameCanvas.debug("PA16", 1);
		this.paintArrowPointToNPC(g);
		GameCanvas.debug("PA17", 1);
		if (!GameScr.isPaintOther && GameScr.isPaintRada == 1 && !GameCanvas.panel.isShow)
		{
			this.paintInfoBar(g);
		}
		GameScr.resetTranslate(g);
		if (!GameScr.isPaintOther)
		{
			if (GameCanvas.open3Hour)
			{
				if (GameCanvas.w > 250)
				{
					g.drawImage(GameCanvas.img12, 160, 6, 0);
					mFont.tahoma_7_white.drawString(g, "Dành cho người chơi trên 12 tuổi.", 180, 2, 0);
					mFont.tahoma_7_white.drawString(g, "Chơi quá 180 phút mỗi ngày ", 180, 12, 0);
					mFont.tahoma_7_white.drawString(g, "sẽ hại sức khỏe.", 180, 22, 0);
				}
				else
				{
					g.drawImage(GameCanvas.img12, 5, GameCanvas.h - 67, 0);
					mFont.tahoma_7_white.drawString(g, "Dành cho người chơi trên 12 tuổi.", 25, GameCanvas.h - 70, 0);
					mFont.tahoma_7_white.drawString(g, "Chơi quá 180 phút mỗi ngày sẽ hại sức khỏe.", 25, GameCanvas.h - 60, 0);
				}
			}
			GameCanvas.debug("PA21", 1);
			GameCanvas.debug("PA18", 1);
			g.translate(-g.getTranslateX(), -g.getTranslateY());
			if ((TileMap.mapID == 128 || TileMap.mapID == 127) && (int)GameScr.mabuPercent != 0)
			{
				int num5 = 30;
				int num6 = 200;
				g.setColor(0);
				g.fillRect(num5 - 27, num6 - 112, 54, 8);
				g.setColor(16711680);
				g.setClip(num5 - 25, num6 - 110, (int)GameScr.mabuPercent, 4);
				g.fillRect(num5 - 25, num6 - 110, 50, 4);
				g.setClip(0, 0, 3000, 3000);
				mFont.tahoma_7b_white.drawString(g, "Mabu", num5, num6 - 112 + 10, 2, mFont.tahoma_7b_dark);
			}
			if (global::Char.myCharz().isFusion)
			{
				global::Char.myCharz().tFusion++;
				if (GameCanvas.gameTick % 3 == 0)
				{
					g.setColor(16777215);
					g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
				}
				if (global::Char.myCharz().tFusion >= 100)
				{
					global::Char.myCharz().fusionComplete();
				}
			}
			for (int i = 0; i < GameScr.vCharInMap.size(); i++)
			{
				global::Char char6 = null;
				try
				{
					char6 = (global::Char)GameScr.vCharInMap.elementAt(i);
				}
				catch (Exception ex5)
				{
				}
				if (char6 != null)
				{
					if (char6.isFusion && global::Char.isCharInScreen(char6))
					{
						char6.tFusion++;
						if (GameCanvas.gameTick % 3 == 0)
						{
							g.setColor(16777215);
							g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
						}
						if (char6.tFusion >= 100)
						{
							char6.fusionComplete();
						}
					}
				}
			}
			GameCanvas.paintz.paintTabSoft(g);
			GameCanvas.debug("PA19", 1);
			GameCanvas.debug("PA20", 1);
			GameScr.resetTranslate(g);
			this.paintSelectedSkill(g);
			GameCanvas.debug("PA22", 1);
			GameScr.resetTranslate(g);
			if (GameCanvas.isTouch && GameCanvas.isTouchControl)
			{
				this.paintTouchControl(g);
			}
			GameScr.resetTranslate(g);
			this.paintChatVip(g);
			if (!GameCanvas.panel.isShow && GameCanvas.currentDialog == null && ChatPopup.currChatPopup == null && ChatPopup.serverChatPopUp == null && GameCanvas.currentScreen.Equals(GameScr.instance))
			{
				base.paint(g);
				if (mScreen.keyMouse == 1 && this.cmdMenu != null)
				{
					g.drawImage(ItemMap.imageFlare, this.cmdMenu.x + 7, this.cmdMenu.y + 15, 3);
				}
			}
			GameScr.resetTranslate(g);
			int num7 = 100 + ((global::Char.vItemTime.size() == 0) ? 0 : (GameScr.textTime.size() * 12));
			if (global::Char.myCharz().clan != null)
			{
				int num8 = 0;
				int num9 = 0;
				int num10 = (GameCanvas.h - 100 - 60) / 12;
				for (int i = 0; i < GameScr.vCharInMap.size(); i++)
				{
					global::Char char7 = (global::Char)GameScr.vCharInMap.elementAt(i);
					if (char7.clanID != -1 && char7.clanID == global::Char.myCharz().clan.ID)
					{
						if (char7.isOutX() && char7.cx < global::Char.myCharz().cx)
						{
							int num11 = num10;
							if (global::Char.vItemTime.size() != 0)
							{
								num11 -= GameScr.textTime.size();
							}
							if (num8 <= num11)
							{
								mFont.tahoma_7_green.drawString(g, char7.cName, 20, num7 - 12 + num8 * 12, mFont.LEFT, mFont.tahoma_7_grey);
								char7.paintHp(g, 10, num7 + num8 * 12 - 5);
								num8++;
							}
						}
						else if (char7.isOutX() && char7.cx > global::Char.myCharz().cx)
						{
							if (num9 <= num10)
							{
								mFont.tahoma_7_green.drawString(g, char7.cName, GameCanvas.w - 25, num7 - 12 + num9 * 12, mFont.RIGHT, mFont.tahoma_7_grey);
								char7.paintHp(g, GameCanvas.w - 15, num7 + num9 * 12 - 5);
								num9++;
							}
						}
					}
				}
			}
			ChatTextField.gI().paint(g);
			if (GameScr.isNewClanMessage && !GameCanvas.panel.isShow && GameCanvas.gameTick % 4 == 0)
			{
				g.drawImage(ItemMap.imageFlare, this.cmdMenu.x + 15, this.cmdMenu.y + 30, mGraphics.BOTTOM | mGraphics.HCENTER);
			}
			if (this.isSuperPower)
			{
				this.dxPower += 5;
				if (this.tPower >= 0)
				{
					this.tPower += this.dxPower;
				}
				Res.outz("x power= " + this.xPower);
				if (this.tPower < 0)
				{
					this.tPower--;
					if (this.tPower == -20)
					{
						this.isSuperPower = false;
						this.tPower = 0;
						this.dxPower = 0;
					}
				}
				else if ((this.xPower - this.tPower > 0 || this.tPower < TileMap.pxw) && this.tPower > 0)
				{
					g.setColor(16777215);
					if (!GameCanvas.lowGraphic)
					{
						g.fillArg(0, 0, GameCanvas.w, GameCanvas.h, 0, 0);
					}
					else
					{
						g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
					}
				}
				else
				{
					this.tPower = -1;
				}
			}
			for (int i = 0; i < global::Char.vItemTime.size(); i++)
			{
				((ItemTime)global::Char.vItemTime.elementAt(i)).paint(g, this.cmdMenu.x + 32 + i * 24, 55);
			}
			for (int i = 0; i < GameScr.textTime.size(); i++)
			{
				((ItemTime)GameScr.textTime.elementAt(i)).paintText(g, this.cmdMenu.x + ((global::Char.vItemTime.size() == 0) ? 25 : 5), ((global::Char.vItemTime.size() == 0) ? 45 : 90) + i * 12);
			}
			this.paintXoSo(g);
			if ((int)mResources.language == 1)
			{
				long second = mSystem.currentTimeMillis() + GameScr.deltaTime;
				mFont.tahoma_7b_white.drawString(g, NinjaUtil.getDate2(second), 10, GameCanvas.h - 65, 0, mFont.tahoma_7b_dark);
			}
			if (!this.yourNumber.Equals(string.Empty))
			{
				for (int i = 0; i < this.strPaint.Length; i++)
				{
					mFont.tahoma_7b_white.drawString(g, this.strPaint[i], 5, 85 + i * 18, 0, mFont.tahoma_7b_dark);
				}
			}
		}
	}

	// Token: 0x060006DA RID: 1754 RVA: 0x00060240 File Offset: 0x0005E440
	private void paintXoSo(mGraphics g)
	{
		if (this.tShow != 0)
		{
			string text = string.Empty;
			for (int i = 0; i < this.winnumber.Length; i++)
			{
				text = text + this.randomNumber[i] + " ";
			}
			PopUp.paintPopUp(g, 20, 45, 95, 35, 16777215, false);
			mFont.tahoma_7b_dark.drawString(g, mResources.kquaVongQuay, 68, 50, 2);
			mFont.tahoma_7b_dark.drawString(g, text + string.Empty, 68, 65, 2);
		}
	}

	// Token: 0x060006DB RID: 1755 RVA: 0x000602D4 File Offset: 0x0005E4D4
	private void checkEffToObj(IMapObject obj)
	{
		if (obj == null)
		{
			return;
		}
		if (this.tDoubleDelay > 0)
		{
			return;
		}
		this.tDoubleDelay = 10;
		int x = obj.getX();
		int num = Res.abs(global::Char.myCharz().cx - x);
		int num2;
		if (num <= 80)
		{
			num2 = 1;
		}
		else if (num > 80 && num <= 200)
		{
			num2 = 2;
		}
		else if (num > 200 && num <= 400)
		{
			num2 = 3;
		}
		else
		{
			num2 = 4;
		}
		Res.outz("nLoop= " + num2);
		if (obj.Equals(global::Char.myCharz().mobFocus) || (obj.Equals(global::Char.myCharz().charFocus) && global::Char.myCharz().isMeCanAttackOtherPlayer(global::Char.myCharz().charFocus)))
		{
			ServerEffect.addServerEffect(135, obj.getX(), obj.getY(), num2);
		}
		else if (obj.Equals(global::Char.myCharz().npcFocus) || obj.Equals(global::Char.myCharz().itemFocus) || obj.Equals(global::Char.myCharz().charFocus))
		{
			ServerEffect.addServerEffect(136, obj.getX(), obj.getY(), num2);
		}
	}

	// Token: 0x060006DC RID: 1756 RVA: 0x0006042C File Offset: 0x0005E62C
	private void updateClickToArrow()
	{
		if (this.tDoubleDelay > 0)
		{
			this.tDoubleDelay--;
		}
		if (this.clickMoving)
		{
			this.clickMoving = false;
			IMapObject mapObject = this.findClickToItem(this.clickToX, this.clickToY);
			if (mapObject == null || (mapObject != null && mapObject.Equals(global::Char.myCharz().npcFocus) && TileMap.mapID == 51))
			{
				ServerEffect.addServerEffect(134, this.clickToX, this.clickToY + GameCanvas.transY / 2, 3);
			}
		}
	}

	// Token: 0x060006DD RID: 1757 RVA: 0x000604C4 File Offset: 0x0005E6C4
	private void paintWaypointArrow(mGraphics g)
	{
		int num = 10;
		Task taskMaint = global::Char.myCharz().taskMaint;
		if (taskMaint != null && taskMaint.taskId == 0 && ((taskMaint.index != 1 && taskMaint.index < 6) || taskMaint.index == 0))
		{
			return;
		}
		for (int i = 0; i < TileMap.vGo.size(); i++)
		{
			Waypoint waypoint = (Waypoint)TileMap.vGo.elementAt(i);
			if (waypoint.minY == 0 || (int)waypoint.maxY >= TileMap.pxh - 24)
			{
				if ((int)waypoint.maxY <= TileMap.pxh / 2)
				{
					int x = (int)(waypoint.minX + (waypoint.maxX - waypoint.minX) / 2);
					int y = (int)(waypoint.minY + (waypoint.maxY - waypoint.minY) / 2) + this.runArrow;
					if (GameCanvas.isTouch)
					{
						y = (int)(waypoint.maxY + (waypoint.maxY - waypoint.minY)) + this.runArrow + num;
					}
					g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 6, x, y, StaticObj.VCENTER_HCENTER);
				}
				else if ((int)waypoint.minY >= TileMap.pxh / 2)
				{
					g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 4, (int)(waypoint.minX + (waypoint.maxX - waypoint.minX) / 2), (int)(waypoint.minY - 12) - this.runArrow, StaticObj.VCENTER_HCENTER);
				}
			}
			else if (waypoint.minX >= 0 && waypoint.minX < 24)
			{
				if (!GameCanvas.isTouch)
				{
					g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 2, (int)(waypoint.maxX + 12) + this.runArrow, (int)(waypoint.maxY - 12), StaticObj.VCENTER_HCENTER);
				}
				else
				{
					g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 2, (int)(waypoint.maxX + 12) + this.runArrow, (int)(waypoint.maxY - 32), StaticObj.VCENTER_HCENTER);
				}
			}
			else if ((int)waypoint.minX <= TileMap.tmw * 24 && (int)waypoint.minX >= TileMap.tmw * 24 - 48)
			{
				if (!GameCanvas.isTouch)
				{
					g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 0, (int)(waypoint.minX - 12) - this.runArrow, (int)(waypoint.maxY - 12), StaticObj.VCENTER_HCENTER);
				}
				else
				{
					g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 0, (int)(waypoint.minX - 12) - this.runArrow, (int)(waypoint.maxY - 32), StaticObj.VCENTER_HCENTER);
				}
			}
			else
			{
				g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 4, (int)(waypoint.minX + (waypoint.maxX - waypoint.minX) / 2), (int)(waypoint.maxY - 48) - this.runArrow, StaticObj.VCENTER_HCENTER);
			}
		}
	}

	// Token: 0x060006DE RID: 1758 RVA: 0x000607D0 File Offset: 0x0005E9D0
	public static Npc findNPCInMap(short id)
	{
		for (int i = 0; i < GameScr.vNpc.size(); i++)
		{
			Npc npc = (Npc)GameScr.vNpc.elementAt(i);
			if (npc.template.npcTemplateId == (int)id)
			{
				return npc;
			}
		}
		return null;
	}

	// Token: 0x060006DF RID: 1759 RVA: 0x00060820 File Offset: 0x0005EA20
	public static global::Char findCharInMap(int charId)
	{
		for (int i = 0; i < GameScr.vCharInMap.size(); i++)
		{
			global::Char @char = (global::Char)GameScr.vCharInMap.elementAt(i);
			if (@char.charID == charId)
			{
				return @char;
			}
		}
		return null;
	}

	// Token: 0x060006E0 RID: 1760 RVA: 0x00006C30 File Offset: 0x00004E30
	public static Mob findMobInMap(sbyte mobIndex)
	{
		return (Mob)GameScr.vMob.elementAt((int)mobIndex);
	}

	// Token: 0x060006E1 RID: 1761 RVA: 0x00060868 File Offset: 0x0005EA68
	public static Mob findMobInMap(int mobId)
	{
		for (int i = 0; i < GameScr.vMob.size(); i++)
		{
			Mob mob = (Mob)GameScr.vMob.elementAt(i);
			if (mob.mobId == mobId)
			{
				return mob;
			}
		}
		return null;
	}

	// Token: 0x060006E2 RID: 1762 RVA: 0x000608B0 File Offset: 0x0005EAB0
	public static Npc getNpcTask()
	{
		for (int i = 0; i < GameScr.vNpc.size(); i++)
		{
			Npc npc = (Npc)GameScr.vNpc.elementAt(i);
			if (npc.template.npcTemplateId == (int)GameScr.getTaskNpcId())
			{
				return npc;
			}
		}
		return null;
	}

	// Token: 0x060006E3 RID: 1763 RVA: 0x00060904 File Offset: 0x0005EB04
	private void paintArrowPointToNPC(mGraphics g)
	{
		try
		{
			if (ChatPopup.currChatPopup == null)
			{
				int num = (int)GameScr.getTaskNpcId();
				if (num != -1)
				{
					Npc npc = null;
					for (int i = 0; i < GameScr.vNpc.size(); i++)
					{
						Npc npc2 = (Npc)GameScr.vNpc.elementAt(i);
						if (npc2.template.npcTemplateId == num)
						{
							if (npc == null)
							{
								npc = npc2;
							}
							else if (Res.abs(npc2.cx - global::Char.myCharz().cx) < Res.abs(npc.cx - global::Char.myCharz().cx))
							{
								npc = npc2;
							}
						}
					}
					if (npc != null && npc.statusMe != 15)
					{
						if (npc.cx <= GameScr.cmx || npc.cx >= GameScr.cmx + GameScr.gW || npc.cy <= GameScr.cmy || npc.cy >= GameScr.cmy + GameScr.gH)
						{
							if (GameCanvas.gameTick % 10 >= 5)
							{
								int num2 = npc.cx - global::Char.myCharz().cx;
								int num3 = npc.cy - global::Char.myCharz().cy;
								int x = 0;
								int y = 0;
								int arg = 0;
								if (num2 > 0 && num3 >= 0)
								{
									if (Res.abs(num2) >= Res.abs(num3))
									{
										x = GameScr.gW - 10;
										y = GameScr.gH / 2 + 30;
										if (GameCanvas.isTouch)
										{
											y = GameScr.gH / 2 + 10;
										}
										arg = 0;
									}
									else
									{
										x = GameScr.gW / 2;
										y = GameScr.gH - 10;
										arg = 5;
									}
								}
								else if (num2 >= 0 && num3 < 0)
								{
									if (Res.abs(num2) >= Res.abs(num3))
									{
										x = GameScr.gW - 10;
										y = GameScr.gH / 2 + 30;
										if (GameCanvas.isTouch)
										{
											y = GameScr.gH / 2 + 10;
										}
										arg = 0;
									}
									else
									{
										x = GameScr.gW / 2;
										y = 10;
										arg = 6;
									}
								}
								if (num2 < 0 && num3 >= 0)
								{
									if (Res.abs(num2) >= Res.abs(num3))
									{
										x = 10;
										y = GameScr.gH / 2 + 30;
										if (GameCanvas.isTouch)
										{
											y = GameScr.gH / 2 + 10;
										}
										arg = 3;
									}
									else
									{
										x = GameScr.gW / 2;
										y = GameScr.gH - 10;
										arg = 5;
									}
								}
								else if (num2 <= 0 && num3 < 0)
								{
									if (Res.abs(num2) >= Res.abs(num3))
									{
										x = 10;
										y = GameScr.gH / 2 + 30;
										if (GameCanvas.isTouch)
										{
											y = GameScr.gH / 2 + 10;
										}
										arg = 3;
									}
									else
									{
										x = GameScr.gW / 2;
										y = 10;
										arg = 6;
									}
								}
								GameScr.resetTranslate(g);
								g.drawRegion(GameScr.arrow, 0, 0, 13, 16, arg, x, y, StaticObj.VCENTER_HCENTER);
							}
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			Cout.LogError("Loi ham arrow to npc: " + ex.ToString());
		}
	}

	// Token: 0x060006E4 RID: 1764 RVA: 0x00006C43 File Offset: 0x00004E43
	public static void resetTranslate(mGraphics g)
	{
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.setClip(0, -200, GameCanvas.w, 200 + GameCanvas.h);
	}

	// Token: 0x060006E5 RID: 1765 RVA: 0x00060C64 File Offset: 0x0005EE64
	private void paintTouchControl(mGraphics g)
	{
		if (this.isNotPaintTouchControl())
		{
			return;
		}
		GameScr.resetTranslate(g);
		if (!TileMap.isOfflineMap() && !this.isVS())
		{
			if (mScreen.keyTouch == 15 || mScreen.keyMouse == 15)
			{
				g.drawImage((!Main.isPC) ? GameScr.imgChat2 : GameScr.imgChatsPC2, GameScr.xC + 17, GameScr.yC + 17 + mGraphics.addYWhenOpenKeyBoard, mGraphics.HCENTER | mGraphics.VCENTER);
			}
			else
			{
				g.drawImage((!Main.isPC) ? GameScr.imgChat : GameScr.imgChatPC, GameScr.xC + 17, GameScr.yC + 17 + mGraphics.addYWhenOpenKeyBoard, mGraphics.HCENTER | mGraphics.VCENTER);
			}
		}
		if (!GameScr.isUseTouch)
		{
			return;
		}
	}

	// Token: 0x060006E6 RID: 1766 RVA: 0x00060D40 File Offset: 0x0005EF40
	public void paintImageBarRight(mGraphics g, global::Char c)
	{
		int num = c.cHP * GameScr.hpBarW / c.cHPFull;
		int num2 = c.cMP * GameScr.mpBarW;
		int num3 = this.dHP * GameScr.hpBarW / c.cHPFull;
		int num4 = this.dMP * GameScr.mpBarW;
		g.setClip(GameCanvas.w / 2 + 58 - mGraphics.getImageWidth(GameScr.imgPanel), 0, 95, 100);
		g.drawRegion(GameScr.imgPanel, 0, 0, mGraphics.getImageWidth(GameScr.imgPanel), mGraphics.getImageHeight(GameScr.imgPanel), 2, GameCanvas.w / 2 + 60, 0, mGraphics.RIGHT | mGraphics.TOP);
		g.setClip(GameCanvas.w / 2 + 60 - 83 - GameScr.hpBarW + GameScr.hpBarW - num3, 5, num3, 10);
		g.drawImage(GameScr.imgHPLost, GameCanvas.w / 2 + 60 - 83, 5, mGraphics.RIGHT | mGraphics.TOP);
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
		g.setClip(GameCanvas.w / 2 + 60 - 83 - GameScr.hpBarW + GameScr.hpBarW - num, 5, num, 10);
		g.drawImage(GameScr.imgHP, GameCanvas.w / 2 + 60 - 83, 5, mGraphics.RIGHT | mGraphics.TOP);
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
		g.setClip(GameCanvas.w / 2 + 60 - 83 - GameScr.mpBarW + GameScr.hpBarW - num4, 20, num4, 6);
		g.drawImage(GameScr.imgMPLost, GameCanvas.w / 2 + 60 - 83, 20, mGraphics.RIGHT | mGraphics.TOP);
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
		g.setClip(GameCanvas.w / 2 + 60 - 83 - GameScr.mpBarW + GameScr.hpBarW - num2, 20, num2, 6);
		g.drawImage(GameScr.imgMP, GameCanvas.w / 2 + 60 - 83, 20, mGraphics.RIGHT | mGraphics.TOP);
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
	}

	// Token: 0x060006E7 RID: 1767 RVA: 0x00060F58 File Offset: 0x0005F158
	private void paintImageBar(mGraphics g, bool isLeft, global::Char c)
	{
		if (c == null)
		{
			return;
		}
		int num;
		int num2;
		int num3;
		int num4;
		if (c.charID == global::Char.myCharz().charID)
		{
			num = this.dHP * GameScr.hpBarW / c.cHPFull;
			num2 = this.dMP * GameScr.mpBarW / c.cMPFull;
			num3 = c.cHP * GameScr.hpBarW / c.cHPFull;
			num4 = c.cMP * GameScr.mpBarW / c.cMPFull;
		}
		else
		{
			num = c.dHP * GameScr.hpBarW / c.cHPFull;
			num2 = c.perCentMp * GameScr.mpBarW / 100;
			num3 = c.cHP * GameScr.hpBarW / c.cHPFull;
			num4 = c.perCentMp * GameScr.mpBarW / 100;
		}
		if (global::Char.myCharz().secondPower > 0)
		{
			int w = (int)global::Char.myCharz().powerPoint * GameScr.spBarW / (int)global::Char.myCharz().maxPowerPoint;
			g.drawImage(GameScr.imgPanel2, 58, 29, 0);
			g.setClip(83, 31, w, 10);
			g.drawImage(GameScr.imgSP, 83, 31, 0);
			g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
			mFont.tahoma_7_white.drawString(g, string.Concat(new object[]
			{
				global::Char.myCharz().strInfo,
				":",
				global::Char.myCharz().powerPoint,
				"/",
				global::Char.myCharz().maxPowerPoint
			}), 115, 29, 2);
		}
		if (c.charID != global::Char.myCharz().charID)
		{
			g.setClip(mGraphics.getImageWidth(GameScr.imgPanel) - 95, 0, 95, 100);
		}
		g.drawImage(GameScr.imgPanel, 0, 0, 0);
		if (isLeft)
		{
			g.setClip(83, 5, num, 10);
		}
		else
		{
			g.setClip(83 + GameScr.hpBarW - num, 5, num, 10);
		}
		g.drawImage(GameScr.imgHPLost, 83, 5, 0);
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
		if (isLeft)
		{
			g.setClip(83, 5, num3, 10);
		}
		else
		{
			g.setClip(83 + GameScr.hpBarW - num3, 5, num3, 10);
		}
		g.drawImage(GameScr.imgHP, 83, 5, 0);
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
		if (isLeft)
		{
			g.setClip(83, 20, num2, 6);
		}
		else
		{
			g.setClip(83 + GameScr.mpBarW - num2, 20, num2, 6);
		}
		g.drawImage(GameScr.imgMPLost, 83, 20, 0);
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
		if (isLeft)
		{
			g.setClip(83, 20, num2, 6);
		}
		else
		{
			g.setClip(83 + GameScr.mpBarW - num4, 20, num4, 6);
		}
		g.drawImage(GameScr.imgMP, 83, 20, 0);
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
		if (global::Char.myCharz().cMP == 0 && GameCanvas.gameTick % 10 > 5)
		{
			g.setClip(83, 20, 2, 6);
			g.drawImage(GameScr.imgMPLost, 83, 20, 0);
			g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
		}
	}

	// Token: 0x060006E8 RID: 1768 RVA: 0x00003984 File Offset: 0x00001B84
	public void getInjure()
	{
	}

	// Token: 0x060006E9 RID: 1769 RVA: 0x000612A8 File Offset: 0x0005F4A8
	public void starVS()
	{
		this.curr = (this.last = mSystem.currentTimeMillis());
		this.secondVS = 180;
	}

	// Token: 0x060006EA RID: 1770 RVA: 0x000612D4 File Offset: 0x0005F4D4
	private global::Char findCharVS1()
	{
		for (int i = 0; i < GameScr.vCharInMap.size(); i++)
		{
			global::Char @char = (global::Char)GameScr.vCharInMap.elementAt(i);
			if ((int)@char.cTypePk != 0)
			{
				return @char;
			}
		}
		return null;
	}

	// Token: 0x060006EB RID: 1771 RVA: 0x0006131C File Offset: 0x0005F51C
	private global::Char findCharVS2()
	{
		for (int i = 0; i < GameScr.vCharInMap.size(); i++)
		{
			global::Char @char = (global::Char)GameScr.vCharInMap.elementAt(i);
			if ((int)@char.cTypePk != 0 && @char != this.findCharVS1())
			{
				return @char;
			}
		}
		return null;
	}

	// Token: 0x060006EC RID: 1772 RVA: 0x00061370 File Offset: 0x0005F570
	private void paintInfoBar(mGraphics g)
	{
		GameScr.resetTranslate(g);
		if (this.isVS() && global::Char.myCharz().charFocus != null)
		{
			g.translate(GameCanvas.w / 2 - 62, 0);
			this.paintImageBar(g, true, global::Char.myCharz().charFocus);
			g.translate(-(GameCanvas.w / 2 - 65), 0);
			this.paintImageBarRight(g, global::Char.myCharz());
			global::Char.myCharz().paintHeadWithXY(g, 15, 20, 0);
			global::Char.myCharz().charFocus.paintHeadWithXY(g, GameCanvas.w - 15, 20, 2);
		}
		else if (TileMap.mapID == 130 && this.findCharVS1() != null && this.findCharVS2() != null)
		{
			g.translate(GameCanvas.w / 2 - 62, 0);
			this.paintImageBar(g, true, this.findCharVS1());
			g.translate(-(GameCanvas.w / 2 - 65), 0);
			this.paintImageBarRight(g, this.findCharVS2());
			this.findCharVS1().paintHeadWithXY(g, 15, 20, 0);
			this.findCharVS2().paintHeadWithXY(g, GameCanvas.w - 15, 20, 2);
		}
		else
		{
			this.paintImageBar(g, true, global::Char.myCharz());
			if (global::Char.myCharz().isInEnterOfflinePoint() != null || global::Char.myCharz().isInEnterOnlinePoint() != null)
			{
				mFont.tahoma_7_green2.drawString(g, mResources.enter, this.imgScrW / 2, 8 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
			}
			else if (global::Char.myCharz().mobFocus != null)
			{
				if (global::Char.myCharz().mobFocus.getTemplate() != null)
				{
					mFont.tahoma_7b_green2.drawString(g, global::Char.myCharz().mobFocus.getTemplate().name, this.imgScrW / 2, 9 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
				}
				if (global::Char.myCharz().mobFocus.templateId != 0)
				{
					mFont.tahoma_7b_green2.drawString(g, NinjaUtil.getMoneys((long)global::Char.myCharz().mobFocus.hp) + string.Empty, this.imgScrW / 2, 22 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
				}
			}
			else if (global::Char.myCharz().npcFocus != null)
			{
				mFont.tahoma_7b_green2.drawString(g, global::Char.myCharz().npcFocus.template.name, this.imgScrW / 2, 9 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
				if (global::Char.myCharz().npcFocus.template.npcTemplateId == 4)
				{
					mFont.tahoma_7b_green2.drawString(g, GameScr.gI().magicTree.currPeas + "/" + GameScr.gI().magicTree.maxPeas, this.imgScrW / 2, 22 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
				}
			}
			else if (global::Char.myCharz().charFocus != null)
			{
				mFont.tahoma_7b_green2.drawString(g, global::Char.myCharz().charFocus.cName, this.imgScrW / 2, 9 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
				mFont.tahoma_7b_green2.drawString(g, NinjaUtil.getMoneys((long)global::Char.myCharz().charFocus.cHP) + string.Empty, this.imgScrW / 2, 22 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
			}
			else
			{
				mFont.tahoma_7b_green2.drawString(g, global::Char.myCharz().cName, this.imgScrW / 2, 9 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
				mFont.tahoma_7b_green2.drawString(g, NinjaUtil.getMoneys(global::Char.myCharz().cPower) + string.Empty, this.imgScrW / 2, 22 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
			}
		}
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		if (this.isVS() && this.secondVS > 0)
		{
			this.curr = mSystem.currentTimeMillis();
			if (this.curr - this.last >= 1000L)
			{
				this.last = mSystem.currentTimeMillis();
				this.secondVS--;
			}
			mFont.tahoma_7b_white.drawString(g, this.secondVS + string.Empty, GameCanvas.w / 2, 13, 2, mFont.tahoma_7b_dark);
		}
		if (this.flareFindFocus)
		{
			g.drawImage(ItemMap.imageFlare, 40, 35, mGraphics.BOTTOM | mGraphics.HCENTER);
			this.flareTime--;
			if (this.flareTime < 0)
			{
				this.flareTime = 0;
				this.flareFindFocus = false;
			}
		}
	}

	// Token: 0x060006ED RID: 1773 RVA: 0x00061820 File Offset: 0x0005FA20
	public bool isVS()
	{
		return (TileMap.mapID == 130 || TileMap.mapID == 51 || TileMap.mapID == 112 || TileMap.mapID == 113 || TileMap.mapID == 129) && ((int)global::Char.myCharz().cTypePk != 0 || (TileMap.mapID == 130 && this.findCharVS1() != null && this.findCharVS2() != null));
	}

	// Token: 0x060006EE RID: 1774 RVA: 0x000618A8 File Offset: 0x0005FAA8
	private void paintSelectedSkill(mGraphics g)
	{
		if (this.mobCapcha != null)
		{
			this.paintCapcha(g);
			return;
		}
		if (GameCanvas.currentDialog != null || ChatPopup.currChatPopup != null || GameCanvas.menu.showMenu || this.isPaintPopup() || GameCanvas.panel.isShow || global::Char.myCharz().taskMaint.taskId == 0 || ChatTextField.gI().isShow || GameCanvas.currentScreen == MoneyCharge.instance)
		{
			return;
		}
		long num = mSystem.currentTimeMillis();
		long num2 = num - this.lastUsePotion;
		int num3 = 0;
		if (num2 < 10000L)
		{
			num3 = (int)(num2 * 20L / 10000L);
		}
		if (!GameCanvas.isTouch)
		{
			g.drawImage((mScreen.keyTouch != 10) ? GameScr.imgSkill : GameScr.imgSkill2, GameScr.xSkill + GameScr.xHP - 1, GameScr.yHP - 1, 0);
			SmallImage.drawSmallImage(g, 542, GameScr.xSkill + GameScr.xHP + 3, GameScr.yHP + 3, 0, 0);
			mFont.number_gray.drawString(g, string.Empty + GameScr.hpPotion, GameScr.xSkill + GameScr.xHP + 22, GameScr.yHP + 15, 1);
			if (num2 < 10000L)
			{
				g.setColor(2721889);
				num3 = (int)(num2 * 20L / 10000L);
				g.fillRect(GameScr.xSkill + GameScr.xHP + 3, GameScr.yHP + 3 + num3, 20, 20 - num3);
			}
		}
		else if (global::Char.myCharz().statusMe != 14)
		{
			if (GameScr.gamePad.isSmallGamePad)
			{
				if (GameScr.isAnalog != 1)
				{
					g.setColor(9670800);
					g.fillRect(GameScr.xHP + 9, GameScr.yHP + 10, 22, 20);
					g.setColor(16777215);
					g.fillRect(GameScr.xHP + 9, GameScr.yHP + 10 + ((num3 == 0) ? 0 : (20 - num3)), 22, (num3 == 0) ? 20 : num3);
					g.drawImage((mScreen.keyTouch != 10) ? GameScr.imgHP1 : GameScr.imgHP2, GameScr.xHP, GameScr.yHP, 0);
					mFont.tahoma_7_red.drawString(g, string.Empty + GameScr.hpPotion, GameScr.xHP + 20, GameScr.yHP + 15, 2);
				}
				else if (GameScr.isAnalog == 1)
				{
					g.drawImage((mScreen.keyTouch != 10) ? GameScr.imgSkill : GameScr.imgSkill2, GameScr.xSkill + GameScr.xHP - 1, GameScr.yHP - 1, 0);
					SmallImage.drawSmallImage(g, 542, GameScr.xSkill + GameScr.xHP + 3, GameScr.yHP + 3, 0, 0);
					mFont.number_gray.drawString(g, string.Empty + GameScr.hpPotion, GameScr.xSkill + GameScr.xHP + 22, GameScr.yHP + 13, 1);
					if (num2 < 10000L)
					{
						g.setColor(2721889);
						num3 = (int)(num2 * 20L / 10000L);
						g.fillRect(GameScr.xSkill + GameScr.xHP + 3, GameScr.yHP + 3 + num3, 20, 20 - num3);
					}
				}
			}
			else if (!GameScr.gamePad.isSmallGamePad)
			{
				if (GameScr.isAnalog != 1)
				{
					g.setColor(9670800);
					g.fillRect(GameScr.xHP + 9, GameScr.yHP + 10, 22, 20);
					g.setColor(16777215);
					g.fillRect(GameScr.xHP + 9, GameScr.yHP + 10 + ((num3 == 0) ? 0 : (20 - num3)), 22, (num3 == 0) ? 20 : num3);
					g.drawImage((mScreen.keyTouch != 10) ? GameScr.imgHP1 : GameScr.imgHP2, GameScr.xHP, GameScr.yHP, 0);
					mFont.tahoma_7_red.drawString(g, string.Empty + GameScr.hpPotion, GameScr.xHP + 20, GameScr.yHP + 15, 2);
				}
				else
				{
					g.setColor(9670800);
					g.fillRect(GameScr.xHP + 10, GameScr.yHP + 10, 20, 18);
					g.setColor(16777215);
					g.fillRect(GameScr.xHP + 10, GameScr.yHP + 10 + ((num3 == 0) ? 0 : (20 - num3)), 20, (num3 == 0) ? 18 : num3);
					g.drawImage((mScreen.keyTouch != 10) ? GameScr.imgHP3 : GameScr.imgHP4, GameScr.xHP + 20, GameScr.yHP + 20, mGraphics.HCENTER | mGraphics.VCENTER);
					mFont.tahoma_7_red.drawString(g, string.Empty + GameScr.hpPotion, GameScr.xHP + 20, GameScr.yHP + 15, 2);
				}
			}
		}
		if (GameScr.isHaveSelectSkill)
		{
			Skill[] array = Main.isPC ? GameScr.keySkill : GameScr.onScreenSkill;
			if (mScreen.keyTouch == 10)
			{
			}
			if (!GameCanvas.isTouch)
			{
				g.setColor(11152401);
				g.fillRect(GameScr.xSkill + GameScr.xHP + 2, GameScr.yHP - 10, 20, 10);
				mFont.tahoma_7_white.drawString(g, "*", GameScr.xSkill + GameScr.xHP + 12, GameScr.yHP - 8, mFont.CENTER);
			}
			int num4 = (!Main.isPC) ? this.nSkill : array.Length;
			for (int i = 0; i < num4; i++)
			{
				if (Main.isPC)
				{
					string[] array3;
					if (TField.isQwerty)
					{
						string[] array2 = new string[5];
						array2[0] = "1";
						array2[1] = "2";
						array2[2] = "3";
						array2[3] = "4";
						array3 = array2;
						array2[4] = "5";
					}
					else
					{
						string[] array4 = new string[5];
						array4[0] = "7";
						array4[1] = "8";
						array4[2] = "9";
						array4[3] = "10";
						array3 = array4;
						array4[4] = "11";
					}
					string[] array5 = array3;
					mFont.tahoma_7b_dark.drawString(g, array5[i], GameScr.xSkill + GameScr.xS[i] + 14, GameScr.yS[i] - 13, mFont.CENTER);
					mFont.tahoma_7b_white.drawString(g, array5[i], GameScr.xSkill + GameScr.xS[i] + 14, GameScr.yS[i] - 14, mFont.CENTER);
				}
				Skill skill = array[i];
				if (skill != global::Char.myCharz().myskill)
				{
					g.drawImage(GameScr.imgSkill, GameScr.xSkill + GameScr.xS[i] - 1, GameScr.yS[i] - 1, 0);
				}
				if (skill != null)
				{
					if (skill == global::Char.myCharz().myskill)
					{
						g.drawImage(GameScr.imgSkill2, GameScr.xSkill + GameScr.xS[i] - 1, GameScr.yS[i] - 1, 0);
						if (GameCanvas.isTouch && !Main.isPC)
						{
							g.drawRegion(Mob.imgHP, 0, 12, 9, 6, 0, GameScr.xSkill + GameScr.xS[i] + 8, GameScr.yS[i] - 7, 0);
						}
					}
					skill.paint(GameScr.xSkill + GameScr.xS[i] + 13, GameScr.yS[i] + 13, g);
					if ((i == this.selectedIndexSkill && !this.isPaintUI() && GameCanvas.gameTick % 10 > 5) || i == this.keyTouchSkill)
					{
						g.drawImage(ItemMap.imageFlare, GameScr.xSkill + GameScr.xS[i] + 13, GameScr.yS[i] + 14, 3);
					}
				}
			}
		}
		this.paintGamePad(g);
	}

	// Token: 0x060006EF RID: 1775 RVA: 0x000620B4 File Offset: 0x000602B4
	public void paintOpen(mGraphics g)
	{
		if (this.isstarOpen)
		{
			g.translate(-g.getTranslateX(), -g.getTranslateY());
			g.fillRect(0, 0, GameCanvas.w, this.moveUp);
			g.setColor(10275899);
			g.fillRect(0, this.moveUp - 1, GameCanvas.w, 1);
			g.fillRect(0, this.moveDow + 1, GameCanvas.w, 1);
		}
	}

	// Token: 0x060006F0 RID: 1776 RVA: 0x00062128 File Offset: 0x00060328
	public static void startFlyText(string flyString, int x, int y, int dx, int dy, int color)
	{
		int num = -1;
		for (int i = 0; i < 5; i++)
		{
			if (GameScr.flyTextState[i] == -1)
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			return;
		}
		GameScr.flyTextColor[num] = color;
		GameScr.flyTextString[num] = flyString;
		GameScr.flyTextX[num] = x;
		GameScr.flyTextY[num] = y;
		GameScr.flyTextDx[num] = dx;
		GameScr.flyTextDy[num] = ((dy >= 0) ? 5 : -5);
		GameScr.flyTextState[num] = 0;
		GameScr.flyTime[num] = 0;
		GameScr.flyTextYTo[num] = 10;
		for (int j = 0; j < 5; j++)
		{
			if (GameScr.flyTextState[j] != -1 && num != j && GameScr.flyTextDy[num] < 0 && Res.abs(GameScr.flyTextX[num] - GameScr.flyTextX[j]) <= 20 && GameScr.flyTextYTo[num] == GameScr.flyTextYTo[j])
			{
				GameScr.flyTextYTo[num] += 10;
			}
		}
	}

	// Token: 0x060006F1 RID: 1777 RVA: 0x00062230 File Offset: 0x00060430
	public static void updateFlyText()
	{
		for (int i = 0; i < 5; i++)
		{
			if (GameScr.flyTextState[i] != -1)
			{
				if (GameScr.flyTextState[i] > GameScr.flyTextYTo[i])
				{
					GameScr.flyTime[i]++;
					if (GameScr.flyTime[i] == 25)
					{
						GameScr.flyTime[i] = 0;
						GameScr.flyTextState[i] = -1;
						GameScr.flyTextYTo[i] = 0;
						GameScr.flyTextDx[i] = 0;
						GameScr.flyTextX[i] = 0;
					}
				}
				else
				{
					GameScr.flyTextState[i] += Res.abs(GameScr.flyTextDy[i]);
					GameScr.flyTextX[i] += GameScr.flyTextDx[i];
					GameScr.flyTextY[i] += GameScr.flyTextDy[i];
				}
			}
		}
	}

	// Token: 0x060006F2 RID: 1778 RVA: 0x00062304 File Offset: 0x00060504
	public static void loadSplash()
	{
		if (GameScr.imgSplash == null)
		{
			GameScr.imgSplash = new Image[3];
			for (int i = 0; i < 3; i++)
			{
				GameScr.imgSplash[i] = GameCanvas.loadImage("/e/sp" + i + ".png");
			}
		}
		GameScr.splashX = new int[2];
		GameScr.splashY = new int[2];
		GameScr.splashState = new int[2];
		GameScr.splashF = new int[2];
		GameScr.splashDir = new int[2];
		GameScr.splashState[0] = (GameScr.splashState[1] = -1);
	}

	// Token: 0x060006F3 RID: 1779 RVA: 0x000623A4 File Offset: 0x000605A4
	public static bool startSplash(int x, int y, int dir)
	{
		int num = (GameScr.splashState[0] != -1) ? 1 : 0;
		if (GameScr.splashState[num] != -1)
		{
			return false;
		}
		GameScr.splashState[num] = 0;
		GameScr.splashDir[num] = dir;
		GameScr.splashX[num] = x;
		GameScr.splashY[num] = y;
		return true;
	}

	// Token: 0x060006F4 RID: 1780 RVA: 0x000623F8 File Offset: 0x000605F8
	public static void updateSplash()
	{
		for (int i = 0; i < 2; i++)
		{
			if (GameScr.splashState[i] != -1)
			{
				GameScr.splashState[i]++;
				GameScr.splashX[i] += GameScr.splashDir[i] << 2;
				GameScr.splashY[i]--;
				if (GameScr.splashState[i] >= 6)
				{
					GameScr.splashState[i] = -1;
				}
				else
				{
					GameScr.splashF[i] = (GameScr.splashState[i] >> 1) % 3;
				}
			}
		}
	}

	// Token: 0x060006F5 RID: 1781 RVA: 0x00062488 File Offset: 0x00060688
	public static void paintSplash(mGraphics g)
	{
		for (int i = 0; i < 2; i++)
		{
			if (GameScr.splashState[i] != -1)
			{
				if (GameScr.splashDir[i] == 1)
				{
					g.drawImage(GameScr.imgSplash[GameScr.splashF[i]], GameScr.splashX[i], GameScr.splashY[i], 3);
				}
				else
				{
					g.drawRegion(GameScr.imgSplash[GameScr.splashF[i]], 0, 0, mGraphics.getImageWidth(GameScr.imgSplash[GameScr.splashF[i]]), mGraphics.getImageHeight(GameScr.imgSplash[GameScr.splashF[i]]), 2, GameScr.splashX[i], GameScr.splashY[i], 3);
				}
			}
		}
	}

	// Token: 0x060006F6 RID: 1782 RVA: 0x00006C75 File Offset: 0x00004E75
	private void loadInforBar()
	{
		this.imgScrW = 84;
		GameScr.hpBarW = 66;
		GameScr.mpBarW = 59;
		GameScr.hpBarX = 52;
		GameScr.hpBarY = 10;
		GameScr.spBarW = 61;
		GameScr.expBarW = GameScr.gW - 61;
	}

	// Token: 0x060006F7 RID: 1783 RVA: 0x00062534 File Offset: 0x00060734
	public void updateSS()
	{
		if (GameScr.indexMenu == -1)
		{
			return;
		}
		if (GameScr.cmySK != GameScr.cmtoYSK)
		{
			GameScr.cmvySK = GameScr.cmtoYSK - GameScr.cmySK << 2;
			GameScr.cmdySK += GameScr.cmvySK;
			GameScr.cmySK += GameScr.cmdySK >> 4;
			GameScr.cmdySK &= 15;
		}
		if (global::Math.abs(GameScr.cmtoYSK - GameScr.cmySK) < 15 && GameScr.cmySK < 0)
		{
			GameScr.cmtoYSK = 0;
		}
		if (global::Math.abs(GameScr.cmtoYSK - GameScr.cmySK) < 15 && GameScr.cmySK > GameScr.cmyLimSK)
		{
			GameScr.cmtoYSK = GameScr.cmyLimSK;
		}
	}

	// Token: 0x060006F8 RID: 1784 RVA: 0x000625F8 File Offset: 0x000607F8
	public void updateKeyAlert()
	{
		if (!GameScr.isPaintAlert || GameCanvas.currentDialog != null)
		{
			return;
		}
		bool flag = false;
		if (GameCanvas.keyPressed[Key.NUM8])
		{
			GameScr.indexRow++;
			if (GameScr.indexRow >= this.texts.size())
			{
				GameScr.indexRow = 0;
			}
			flag = true;
		}
		else if (GameCanvas.keyPressed[Key.NUM2])
		{
			GameScr.indexRow--;
			if (GameScr.indexRow < 0)
			{
				GameScr.indexRow = this.texts.size() - 1;
			}
			flag = true;
		}
		if (flag)
		{
			GameScr.scrMain.moveTo(GameScr.indexRow * GameScr.scrMain.ITEM_SIZE);
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
		}
		if (GameCanvas.isTouch)
		{
			ScrollResult scrollResult = GameScr.scrMain.updateKey();
			if (scrollResult.isDowning || scrollResult.isFinish)
			{
				GameScr.indexRow = scrollResult.selected;
				flag = true;
			}
		}
		if (flag && GameScr.indexRow >= 0 && GameScr.indexRow < this.texts.size())
		{
			string text = (string)this.texts.elementAt(GameScr.indexRow);
			this.fnick = null;
			this.alertURL = null;
			this.center = null;
			ChatTextField.gI().center = null;
			int num;
			if ((num = text.IndexOf("http://")) >= 0)
			{
				Cout.println("currentLine: " + text);
				this.alertURL = text.Substring(num);
				this.center = new Command(mResources.open_link, 12000);
				if (!GameCanvas.isTouch)
				{
					ChatTextField.gI().center = new Command(mResources.open_link, null, 12000, null);
				}
			}
			else if (text.IndexOf("@") >= 0)
			{
				string text2 = text.Substring(2);
				text2 = text2.Trim();
				num = text2.IndexOf("@");
				string text3 = text2.Substring(num);
				int num2 = text3.IndexOf(" ");
				if (num2 <= 0)
				{
					num2 = num + text3.Length;
				}
				else
				{
					num2 += num;
				}
				this.fnick = text2.Substring(num + 1, num2);
				if (!this.fnick.Equals(string.Empty) && !this.fnick.Equals(global::Char.myCharz().cName))
				{
					this.center = new Command(mResources.SELECT, 12009, this.fnick);
					if (!GameCanvas.isTouch)
					{
						ChatTextField.gI().center = new Command(mResources.SELECT, null, 12009, this.fnick);
					}
				}
				else
				{
					this.fnick = null;
					this.center = null;
				}
			}
		}
	}

	// Token: 0x060006F9 RID: 1785 RVA: 0x000628C8 File Offset: 0x00060AC8
	public bool isPaintPopup()
	{
		return GameScr.isPaintItemInfo || GameScr.isPaintInfoMe || GameScr.isPaintStore || GameScr.isPaintWeapon || GameScr.isPaintNonNam || GameScr.isPaintNonNu || GameScr.isPaintAoNam || GameScr.isPaintAoNu || GameScr.isPaintGangTayNam || GameScr.isPaintGangTayNu || GameScr.isPaintQuanNam || GameScr.isPaintQuanNu || GameScr.isPaintGiayNam || GameScr.isPaintGiayNu || GameScr.isPaintLien || GameScr.isPaintNhan || GameScr.isPaintNgocBoi || GameScr.isPaintPhu || GameScr.isPaintStack || GameScr.isPaintStackLock || GameScr.isPaintGrocery || GameScr.isPaintGroceryLock || GameScr.isPaintUpGrade || GameScr.isPaintConvert || GameScr.isPaintSplit || GameScr.isPaintUpPearl || GameScr.isPaintBox || GameScr.isPaintTrade || GameScr.isPaintAlert || GameScr.isPaintZone || GameScr.isPaintTeam || GameScr.isPaintClan || GameScr.isPaintFindTeam || GameScr.isPaintTask || GameScr.isPaintFriend || GameScr.isPaintEnemies || GameScr.isPaintCharInMap || GameScr.isPaintMessage;
	}

	// Token: 0x060006FA RID: 1786 RVA: 0x00062A54 File Offset: 0x00060C54
	public bool isNotPaintTouchControl()
	{
		return (!GameCanvas.isTouchControl && GameCanvas.currentScreen == GameScr.gI()) || !GameCanvas.isTouch || ChatTextField.gI().isShow || InfoDlg.isShow || (GameCanvas.currentDialog != null || ChatPopup.currChatPopup != null || GameCanvas.menu.showMenu || GameCanvas.panel.isShow || this.isPaintPopup());
	}

	// Token: 0x060006FB RID: 1787 RVA: 0x00062AE8 File Offset: 0x00060CE8
	public bool isPaintUI()
	{
		return GameScr.isPaintStore || GameScr.isPaintWeapon || GameScr.isPaintNonNam || GameScr.isPaintNonNu || GameScr.isPaintAoNam || GameScr.isPaintAoNu || GameScr.isPaintGangTayNam || GameScr.isPaintGangTayNu || GameScr.isPaintQuanNam || GameScr.isPaintQuanNu || GameScr.isPaintGiayNam || GameScr.isPaintGiayNu || GameScr.isPaintLien || GameScr.isPaintNhan || GameScr.isPaintNgocBoi || GameScr.isPaintPhu || GameScr.isPaintStack || GameScr.isPaintStackLock || GameScr.isPaintGrocery || GameScr.isPaintGroceryLock || GameScr.isPaintUpGrade || GameScr.isPaintConvert || GameScr.isPaintSplit || GameScr.isPaintUpPearl || GameScr.isPaintBox || GameScr.isPaintTrade;
	}

	// Token: 0x060006FC RID: 1788 RVA: 0x00062BFC File Offset: 0x00060DFC
	public bool isOpenUI()
	{
		return GameScr.isPaintItemInfo || GameScr.isPaintInfoMe || GameScr.isPaintStore || GameScr.isPaintNonNam || GameScr.isPaintNonNu || GameScr.isPaintAoNam || GameScr.isPaintAoNu || GameScr.isPaintGangTayNam || GameScr.isPaintGangTayNu || GameScr.isPaintQuanNam || GameScr.isPaintQuanNu || GameScr.isPaintGiayNam || GameScr.isPaintGiayNu || GameScr.isPaintLien || GameScr.isPaintNhan || GameScr.isPaintNgocBoi || GameScr.isPaintPhu || GameScr.isPaintWeapon || GameScr.isPaintStack || GameScr.isPaintStackLock || GameScr.isPaintGrocery || GameScr.isPaintGroceryLock || GameScr.isPaintUpGrade || GameScr.isPaintConvert || GameScr.isPaintUpPearl || GameScr.isPaintBox || GameScr.isPaintSplit || GameScr.isPaintTrade;
	}

	// Token: 0x060006FD RID: 1789 RVA: 0x00062D24 File Offset: 0x00060F24
	public static void setPopupSize(int w, int h)
	{
		if (GameCanvas.w == 128 || GameCanvas.h <= 208)
		{
			w = 126;
			h = 160;
		}
		GameScr.indexTitle = 0;
		GameScr.popupW = w;
		GameScr.popupH = h;
		GameScr.popupX = GameScr.gW2 - w / 2;
		GameScr.popupY = GameScr.gH2 - h / 2;
		if (GameCanvas.isTouch && !GameScr.isPaintZone && !GameScr.isPaintTeam && !GameScr.isPaintClan && !GameScr.isPaintCharInMap && !GameScr.isPaintFindTeam && !GameScr.isPaintFriend && !GameScr.isPaintEnemies && !GameScr.isPaintTask && !GameScr.isPaintMessage)
		{
			if (GameCanvas.h <= 240)
			{
				GameScr.popupY -= 10;
			}
			if (GameCanvas.isTouch && !GameCanvas.isTouchControlSmallScreen && GameCanvas.currentScreen is GameScr)
			{
				GameScr.popupW = 310;
				GameScr.popupX = GameScr.gW / 2 - GameScr.popupW / 2;
				if (GameScr.isPaintInfoMe && GameScr.indexMenu > 0)
				{
					GameScr.popupW = w;
					GameScr.popupX = GameScr.gW2 - w / 2;
				}
			}
		}
		if (GameScr.popupY < -10)
		{
			GameScr.popupY = -10;
		}
		if (GameCanvas.h > 208 && GameScr.popupY < 0)
		{
			GameScr.popupY = 0;
		}
		if (GameCanvas.h == 208 && GameScr.popupY < 10)
		{
			GameScr.popupY = 10;
		}
	}

	// Token: 0x060006FE RID: 1790 RVA: 0x00006CAF File Offset: 0x00004EAF
	public static void loadImg()
	{
		TileMap.loadTileImage();
	}

	// Token: 0x060006FF RID: 1791 RVA: 0x00062EC8 File Offset: 0x000610C8
	public void paintTitle(mGraphics g, string title, bool arrow)
	{
		int num = GameScr.gW / 2;
		g.setColor(Paint.COLORDARK);
		g.fillRoundRect(num - mFont.tahoma_8b.getWidth(title) / 2 - 12, GameScr.popupY + 4, mFont.tahoma_8b.getWidth(title) + 22, 24, 6, 6);
		if ((GameScr.indexTitle == 0 || GameCanvas.isTouch) && arrow)
		{
			SmallImage.drawSmallImage(g, 989, num - mFont.tahoma_8b.getWidth(title) / 2 - 15 - 7 - ((GameCanvas.gameTick % 8 > 3) ? 0 : 2), GameScr.popupY + 16, 2, StaticObj.VCENTER_HCENTER);
			SmallImage.drawSmallImage(g, 989, num + mFont.tahoma_8b.getWidth(title) / 2 + 15 + 5 + ((GameCanvas.gameTick % 8 > 3) ? 0 : 2), GameScr.popupY + 16, 0, StaticObj.VCENTER_HCENTER);
		}
		if (GameScr.indexTitle == 0)
		{
			g.setColor(Paint.COLORFOCUS);
		}
		else
		{
			g.setColor(Paint.COLORBORDER);
		}
		g.drawRoundRect(num - mFont.tahoma_8b.getWidth(title) / 2 - 12, GameScr.popupY + 4, mFont.tahoma_8b.getWidth(title) + 22, 24, 6, 6);
		mFont.tahoma_8b.drawString(g, title, num, GameScr.popupY + 9, 2);
	}

	// Token: 0x06000700 RID: 1792 RVA: 0x00063028 File Offset: 0x00061228
	public static int getTaskMapId()
	{
		int result;
		if (global::Char.myCharz().taskMaint == null)
		{
			result = -1;
		}
		else
		{
			result = GameScr.mapTasks[global::Char.myCharz().taskMaint.index];
		}
		return result;
	}

	// Token: 0x06000701 RID: 1793 RVA: 0x00063064 File Offset: 0x00061264
	public static sbyte getTaskNpcId()
	{
		sbyte result = 0;
		if (global::Char.myCharz().taskMaint == null)
		{
			result = -1;
		}
		else if (global::Char.myCharz().taskMaint.index <= GameScr.tasks.Length - 1)
		{
			result = (sbyte)GameScr.tasks[global::Char.myCharz().taskMaint.index];
		}
		return result;
	}

	// Token: 0x06000702 RID: 1794 RVA: 0x00003984 File Offset: 0x00001B84
	public void refreshTeam()
	{
	}

	// Token: 0x06000703 RID: 1795 RVA: 0x000630C0 File Offset: 0x000612C0
	public void onChatFromMe(string text, string to)
	{
		Res.outz("CHAT");
		if (!GameScr.isPaintMessage || GameCanvas.isTouch)
		{
			ChatTextField.gI().isShow = false;
		}
		if (to.Equals(mResources.chat_player))
		{
			if (GameScr.info2.playerID == global::Char.myCharz().charID)
			{
				return;
			}
			Service.gI().chatPlayer(text, GameScr.info2.playerID);
			return;
		}
		else
		{
			if (text.Equals(string.Empty))
			{
				return;
			}
			Service.gI().chat(text);
			return;
		}
	}

	// Token: 0x06000704 RID: 1796 RVA: 0x00006CB6 File Offset: 0x00004EB6
	public void onCancelChat()
	{
		if (GameScr.isPaintMessage)
		{
			GameScr.isPaintMessage = false;
			ChatTextField.gI().center = null;
		}
	}

	// Token: 0x06000705 RID: 1797 RVA: 0x00063154 File Offset: 0x00061354
	public void openWeb(string strLeft, string strRight, string url, string title, string str)
	{
		GameScr.isPaintAlert = true;
		this.isLockKey = true;
		GameScr.indexRow = 0;
		GameScr.setPopupSize(175, 200);
		this.textsTitle = title;
		this.texts = mFont.tahoma_7.splitFontVector(str, GameScr.popupW - 30);
		this.center = null;
		this.left = new Command(strLeft, 11068, url);
		this.right = new Command(strRight, 11069);
	}

	// Token: 0x06000706 RID: 1798 RVA: 0x000631D0 File Offset: 0x000613D0
	public void sendSms(string strLeft, string strRight, short port, string syntax, string title, string str)
	{
		GameScr.isPaintAlert = true;
		this.isLockKey = true;
		GameScr.indexRow = 0;
		GameScr.setPopupSize(175, 200);
		this.textsTitle = title;
		this.texts = mFont.tahoma_7.splitFontVector(str, GameScr.popupW - 30);
		this.center = null;
		MyVector myVector = new MyVector();
		myVector.addElement(string.Empty + port);
		myVector.addElement(syntax);
		this.left = new Command(strLeft, 11074);
		this.right = new Command(strRight, 11075);
	}

	// Token: 0x06000707 RID: 1799 RVA: 0x00006CD3 File Offset: 0x00004ED3
	public void actMenu()
	{
		GameCanvas.panel.setTypeMain();
		GameCanvas.panel.show();
	}

	// Token: 0x06000708 RID: 1800 RVA: 0x00063270 File Offset: 0x00061470
	public void openUIZone(Message message)
	{
		InfoDlg.hide();
		try
		{
			this.zones = new int[(int)message.reader().readByte()];
			this.pts = new int[this.zones.Length];
			this.numPlayer = new int[this.zones.Length];
			this.maxPlayer = new int[this.zones.Length];
			this.rank1 = new int[this.zones.Length];
			this.rankName1 = new string[this.zones.Length];
			this.rank2 = new int[this.zones.Length];
			this.rankName2 = new string[this.zones.Length];
			for (int i = 0; i < this.zones.Length; i++)
			{
				this.zones[i] = (int)message.reader().readByte();
				this.pts[i] = (int)message.reader().readByte();
				this.numPlayer[i] = (int)message.reader().readByte();
				this.maxPlayer[i] = (int)message.reader().readByte();
				sbyte b = message.reader().readByte();
				if ((int)b == 1)
				{
					this.rankName1[i] = message.reader().readUTF();
					this.rank1[i] = message.reader().readInt();
					this.rankName2[i] = message.reader().readUTF();
					this.rank2[i] = message.reader().readInt();
				}
			}
		}
		catch (Exception ex)
		{
			Cout.LogError("Loi ham OPEN UIZONE " + ex.ToString());
		}
		GameCanvas.panel.setTypeZone();
		GameCanvas.panel.show();
	}

	// Token: 0x06000709 RID: 1801 RVA: 0x00006CE9 File Offset: 0x00004EE9
	public void showViewInfo()
	{
		GameScr.indexMenu = 3;
		GameScr.isPaintInfoMe = true;
		GameScr.setPopupSize(175, 200);
	}

	// Token: 0x0600070A RID: 1802 RVA: 0x00063438 File Offset: 0x00061638
	private void actDead()
	{
		MyVector myVector = new MyVector();
		myVector.addElement(new Command(mResources.DIES[1], 110381));
		myVector.addElement(new Command(mResources.DIES[2], 110382));
		myVector.addElement(new Command(mResources.DIES[3], 110383));
		GameCanvas.menu.startAt(myVector, 3);
	}

	// Token: 0x0600070B RID: 1803 RVA: 0x00006D06 File Offset: 0x00004F06
	public void startYesNoPopUp(string info, Command cmdYes, Command cmdNo)
	{
		this.popUpYesNo = new PopUpYesNo();
		this.popUpYesNo.setPopUp(info, cmdYes, cmdNo);
	}

	// Token: 0x0600070C RID: 1804 RVA: 0x0006349C File Offset: 0x0006169C
	public void player_vs_player(int playerId, int xu, string info, sbyte typePK)
	{
		global::Char @char = GameScr.findCharInMap(playerId);
		if (@char != null)
		{
			if ((int)typePK == 3)
			{
				this.startYesNoPopUp(info, new Command(mResources.OK, 2000, @char), new Command(mResources.CLOSE, 2009, @char));
			}
			if ((int)typePK == 4)
			{
				this.startYesNoPopUp(info, new Command(mResources.OK, 2005, @char), new Command(mResources.CLOSE, 2009, @char));
			}
		}
	}

	// Token: 0x0600070D RID: 1805 RVA: 0x00063518 File Offset: 0x00061718
	public void giaodich(int playerID)
	{
		global::Char @char = GameScr.findCharInMap(playerID);
		if (@char != null)
		{
			this.startYesNoPopUp(@char.cName + mResources.want_to_trade, new Command(mResources.YES, 11114, @char), new Command(mResources.NO, 2009, @char));
		}
	}

	// Token: 0x0600070E RID: 1806 RVA: 0x00063568 File Offset: 0x00061768
	public void getFlagImage(int charID, sbyte cflag)
	{
		if (GameScr.vFlag.size() == 0)
		{
			Service.gI().getFlag(2, cflag);
			Res.outz("getFlag1");
		}
		else if (charID == global::Char.myCharz().charID)
		{
			Res.outz("my cflag: isme");
			if (global::Char.myCharz().isGetFlagImage(cflag))
			{
				Res.outz("my cflag: true");
				for (int i = 0; i < GameScr.vFlag.size(); i++)
				{
					PKFlag pkflag = (PKFlag)GameScr.vFlag.elementAt(i);
					if (pkflag != null && (int)pkflag.cflag == (int)cflag)
					{
						Res.outz("my cflag: cflag==");
						global::Char.myCharz().flagImage = pkflag.IDimageFlag;
					}
				}
			}
			else if (!global::Char.myCharz().isGetFlagImage(cflag))
			{
				Res.outz("my cflag: false");
				Service.gI().getFlag(2, cflag);
			}
		}
		else
		{
			Res.outz("my cflag: not me");
			if (GameScr.findCharInMap(charID) != null)
			{
				if (GameScr.findCharInMap(charID).isGetFlagImage(cflag))
				{
					Res.outz("my cflag: true");
					for (int j = 0; j < GameScr.vFlag.size(); j++)
					{
						PKFlag pkflag2 = (PKFlag)GameScr.vFlag.elementAt(j);
						if (pkflag2 != null && (int)pkflag2.cflag == (int)cflag)
						{
							Res.outz("my cflag: cflag==");
							GameScr.findCharInMap(charID).flagImage = pkflag2.IDimageFlag;
						}
					}
				}
				else if (!GameScr.findCharInMap(charID).isGetFlagImage(cflag))
				{
					Res.outz("my cflag: false");
					Service.gI().getFlag(2, cflag);
				}
			}
		}
	}

	// Token: 0x0600070F RID: 1807 RVA: 0x00063714 File Offset: 0x00061914
	public void actionPerform(int idAction, object p)
	{
		Cout.println("PERFORM WITH ID = " + idAction);
		switch (idAction)
		{
		case 2000:
			this.popUpYesNo = null;
			GameCanvas.endDlg();
			if ((global::Char)p == null)
			{
				Service.gI().player_vs_player(1, 3, -1);
				return;
			}
			Service.gI().player_vs_player(1, 3, ((global::Char)p).charID);
			Service.gI().charMove();
			break;
		case 2001:
			GameCanvas.endDlg();
			break;
		default:
			switch (idAction)
			{
			case 11111:
				if (global::Char.myCharz().charFocus == null)
				{
					return;
				}
				InfoDlg.showWait();
				if (GameCanvas.panel.vPlayerMenu.size() <= 0)
				{
					this.playerMenu(global::Char.myCharz().charFocus);
				}
				GameCanvas.panel.setTypePlayerMenu(global::Char.myCharz().charFocus);
				GameCanvas.panel.show();
				Service.gI().getPlayerMenu(global::Char.myCharz().charFocus.charID);
				Service.gI().messagePlayerMenu(global::Char.myCharz().charFocus.charID);
				break;
			case 11112:
			{
				global::Char @char = (global::Char)p;
				Service.gI().friend(1, @char.charID);
				break;
			}
			case 11113:
			{
				global::Char char2 = (global::Char)p;
				if (char2 != null)
				{
					Service.gI().giaodich(0, char2.charID, -1, -1);
				}
				break;
			}
			case 11114:
			{
				this.popUpYesNo = null;
				GameCanvas.endDlg();
				global::Char char3 = (global::Char)p;
				if (char3 == null)
				{
					return;
				}
				Service.gI().giaodich(1, char3.charID, -1, -1);
				break;
			}
			case 11115:
				if (global::Char.myCharz().charFocus == null)
				{
					return;
				}
				InfoDlg.showWait();
				Service.gI().playerMenuAction(global::Char.myCharz().charFocus.charID, (short)global::Char.myCharz().charFocus.menuSelect);
				break;
			default:
				switch (idAction)
				{
				case 12000:
					Service.gI().getClan(1, -1, null);
					break;
				case 12001:
					GameCanvas.endDlg();
					break;
				case 12002:
				{
					GameCanvas.endDlg();
					ClanObject clanObject = (ClanObject)p;
					Service.gI().clanInvite(1, -1, clanObject.clanID, clanObject.code);
					this.popUpYesNo = null;
					break;
				}
				case 12003:
				{
					ClanObject clanObject = (ClanObject)p;
					GameCanvas.endDlg();
					Service.gI().clanInvite(2, -1, clanObject.clanID, clanObject.code);
					this.popUpYesNo = null;
					break;
				}
				case 12004:
				{
					Skill skill = (Skill)p;
					this.doUseSkill(skill, true);
					global::Char.myCharz().saveLoadPreviousSkill();
					break;
				}
				default:
					switch (idAction)
					{
					case 11000:
						this.actMenu();
						break;
					case 11001:
						global::Char.myCharz().findNextFocusByKey();
						break;
					case 11002:
						GameCanvas.panel.hide();
						break;
					default:
						if (idAction != 1)
						{
							if (idAction != 2)
							{
								switch (idAction)
								{
								case 11057:
								{
									Effect2.vEffect2Outside.removeAllElements();
									Effect2.vEffect2.removeAllElements();
									Npc npc = (Npc)p;
									if (npc.idItem == 0)
									{
										Service.gI().confirmMenu((short)npc.template.npcTemplateId, (sbyte)GameCanvas.menu.menuSelectedItem);
									}
									else if (GameCanvas.menu.menuSelectedItem == 0)
									{
										Service.gI().pickItem(npc.idItem);
									}
									break;
								}
								default:
									switch (idAction)
									{
									case 110001:
										GameCanvas.panel.setTypeMain();
										GameCanvas.panel.show();
										break;
									default:
										if (idAction != 110382)
										{
											if (idAction != 110383)
											{
												if (idAction != 8002)
												{
													if (idAction != 11038)
													{
														if (idAction != 11067)
														{
															if (idAction != 110391)
															{
																if (idAction == 888351)
																{
																	Service.gI().petStatus(5);
																	GameCanvas.endDlg();
																}
															}
															else
															{
																Service.gI().clanInvite(0, global::Char.myCharz().charFocus.charID, -1, -1);
															}
														}
														else if (TileMap.zoneID != GameScr.indexSelect)
														{
															Service.gI().requestChangeZone(GameScr.indexSelect, this.indexItemUse);
															InfoDlg.showWait();
														}
														else
														{
															GameScr.info1.addInfo(mResources.ZONE_HERE, 0);
														}
													}
													else
													{
														this.actDead();
													}
												}
												else
												{
													this.doFire(false, true);
													GameCanvas.clearKeyHold();
													GameCanvas.clearKeyPressed();
												}
											}
											else
											{
												Service.gI().wakeUpFromDead();
											}
										}
										else
										{
											Service.gI().returnTownFromDead();
										}
										break;
									case 110004:
										GameCanvas.menu.showMenu = false;
										break;
									}
									break;
								case 11059:
								{
									Skill skill2 = GameScr.onScreenSkill[this.selectedIndexSkill];
									this.doUseSkill(skill2, false);
									this.center = null;
									break;
								}
								}
							}
							else
							{
								GameCanvas.menu.showMenu = false;
							}
						}
						else
						{
							GameCanvas.endDlg();
						}
						break;
					}
					break;
				}
				break;
			case 11120:
			{
				object[] array = (object[])p;
				Skill skill3 = (Skill)array[0];
				int num = int.Parse((string)array[1]);
				for (int i = 0; i < GameScr.onScreenSkill.Length; i++)
				{
					if (GameScr.onScreenSkill[i] == skill3)
					{
						GameScr.onScreenSkill[i] = null;
					}
				}
				GameScr.onScreenSkill[num] = skill3;
				this.saveonScreenSkillToRMS();
				break;
			}
			case 11121:
			{
				object[] array2 = (object[])p;
				Skill skill4 = (Skill)array2[0];
				int num2 = int.Parse((string)array2[1]);
				for (int j = 0; j < GameScr.keySkill.Length; j++)
				{
					if (GameScr.keySkill[j] == skill4)
					{
						GameScr.keySkill[j] = null;
					}
				}
				GameScr.keySkill[num2] = skill4;
				this.saveKeySkillToRMS();
				break;
			}
			}
			break;
		case 2003:
			GameCanvas.endDlg();
			InfoDlg.showWait();
			Service.gI().player_vs_player(0, 3, global::Char.myCharz().charFocus.charID);
			break;
		case 2004:
			GameCanvas.endDlg();
			Service.gI().player_vs_player(0, 4, global::Char.myCharz().charFocus.charID);
			break;
		case 2005:
			GameCanvas.endDlg();
			this.popUpYesNo = null;
			if ((global::Char)p == null)
			{
				Service.gI().player_vs_player(1, 4, -1);
				return;
			}
			Service.gI().player_vs_player(1, 4, ((global::Char)p).charID);
			break;
		case 2006:
			GameCanvas.endDlg();
			Service.gI().player_vs_player(2, 4, global::Char.myCharz().charFocus.charID);
			break;
		case 2007:
			GameCanvas.endDlg();
			GameMidlet.instance.exit();
			break;
		case 2009:
			this.popUpYesNo = null;
			break;
		}
	}

	// Token: 0x06000710 RID: 1808 RVA: 0x00063E18 File Offset: 0x00062018
	private static void setTouchBtn()
	{
		if (GameScr.isAnalog == 0)
		{
			return;
		}
		GameScr.xTG = (GameScr.xF = GameCanvas.w - 45);
		if (GameScr.gamePad.isLargeGamePad)
		{
			GameScr.xSkill = GameScr.gamePad.wZone - 20;
			GameScr.wSkill = 35;
			GameScr.xHP = GameScr.xF - 45;
		}
		else if (GameScr.gamePad.isMediumGamePad)
		{
			GameScr.xHP = GameScr.xF - 45;
		}
		GameScr.yF = GameCanvas.h - 45;
		GameScr.yTG = GameScr.yF - 45;
	}

	// Token: 0x06000711 RID: 1809 RVA: 0x00063EB4 File Offset: 0x000620B4
	private void updateGamePad()
	{
		if (GameScr.isAnalog == 0)
		{
			return;
		}
		if (global::Char.myCharz().statusMe == 14)
		{
			return;
		}
		if (GameCanvas.isPointerHoldIn(GameScr.xF, GameScr.yF, 40, 40))
		{
			mScreen.keyTouch = 5;
			if (GameCanvas.isPointerJustRelease)
			{
				GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] = true;
				GameCanvas.isPointerClick = (GameCanvas.isPointerJustDown = (GameCanvas.isPointerJustRelease = false));
			}
		}
		GameScr.gamePad.update();
		if (GameCanvas.isPointerHoldIn(GameScr.xTG, GameScr.yTG, 34, 34))
		{
			mScreen.keyTouch = 13;
			GameCanvas.isPointerJustDown = false;
			this.isPointerDowning = false;
			if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
			{
				global::Char.myCharz().findNextFocusByKey();
				GameCanvas.isPointerClick = (GameCanvas.isPointerJustDown = (GameCanvas.isPointerJustRelease = false));
			}
		}
	}

	// Token: 0x06000712 RID: 1810 RVA: 0x00063F98 File Offset: 0x00062198
	private void paintGamePad(mGraphics g)
	{
		if (GameScr.isAnalog == 0)
		{
			return;
		}
		if (global::Char.myCharz().statusMe == 14)
		{
			return;
		}
		g.drawImage((mScreen.keyTouch != 5 && mScreen.keyMouse != 5) ? GameScr.imgFire0 : GameScr.imgFire1, GameScr.xF + 20, GameScr.yF + 20, mGraphics.HCENTER | mGraphics.VCENTER);
		GameScr.gamePad.paint(g);
		g.drawImage((mScreen.keyTouch != 13) ? GameScr.imgFocus : GameScr.imgFocus2, GameScr.xTG + 20, GameScr.yTG + 20, mGraphics.HCENTER | mGraphics.VCENTER);
	}

	// Token: 0x06000713 RID: 1811 RVA: 0x00064050 File Offset: 0x00062250
	public void showWinNumber(string num, string finish)
	{
		this.winnumber = new int[num.Length];
		this.randomNumber = new int[num.Length];
		this.tMove = new int[num.Length];
		this.moveCount = new int[num.Length];
		this.delayMove = new int[num.Length];
		for (int i = 0; i < num.Length; i++)
		{
			this.winnumber[i] = (int)((short)num[i]);
			this.randomNumber[i] = Res.random(0, 11);
			this.tMove[i] = 1;
			this.delayMove[i] = 0;
		}
		this.tShow = 100;
		this.moveIndex = 0;
		this.strFinish = finish;
		GameScr.lastXS = (GameScr.currXS = mSystem.currentTimeMillis());
	}

	// Token: 0x06000714 RID: 1812 RVA: 0x00064124 File Offset: 0x00062324
	public void chatVip(string chatVip)
	{
		if (!this.startChat)
		{
			this.currChatWidth = mFont.tahoma_7b_yellowSmall.getWidth(chatVip);
			this.xChatVip = GameCanvas.w;
			this.startChat = true;
		}
		if (chatVip.StartsWith("!"))
		{
			chatVip = chatVip.Substring(1, chatVip.Length);
			this.isFireWorks = true;
		}
		GameScr.vChatVip.addElement(chatVip);
	}

	// Token: 0x06000715 RID: 1813 RVA: 0x00006D21 File Offset: 0x00004F21
	public void clearChatVip()
	{
		GameScr.vChatVip.removeAllElements();
		this.xChatVip = GameCanvas.w;
		this.startChat = false;
	}

	// Token: 0x06000716 RID: 1814 RVA: 0x00064190 File Offset: 0x00062390
	public void paintChatVip(mGraphics g)
	{
		if (GameScr.vChatVip.size() == 0)
		{
			return;
		}
		if (!GameScr.isPaintChatVip)
		{
			return;
		}
		g.setClip(0, GameCanvas.h - 13, GameCanvas.w, 15);
		g.fillRect(0, GameCanvas.h - 13, GameCanvas.w, 15, 0, 90);
		string st = (string)GameScr.vChatVip.elementAt(0);
		mFont.tahoma_7b_yellow.drawString(g, st, this.xChatVip, GameCanvas.h - 13, 0, mFont.tahoma_7b_dark);
	}

	// Token: 0x06000717 RID: 1815 RVA: 0x00064218 File Offset: 0x00062418
	public void updateChatVip()
	{
		if (this.startChat)
		{
			this.xChatVip -= 2;
			if (this.xChatVip < -this.currChatWidth)
			{
				this.xChatVip = GameCanvas.w;
				GameScr.vChatVip.removeElementAt(0);
				if (GameScr.vChatVip.size() == 0)
				{
					this.isFireWorks = false;
					this.startChat = false;
					return;
				}
				this.currChatWidth = mFont.tahoma_7b_white.getWidth((string)GameScr.vChatVip.elementAt(0));
			}
		}
	}

	// Token: 0x06000718 RID: 1816 RVA: 0x00006D3F File Offset: 0x00004F3F
	public void showYourNumber(string strNum)
	{
		this.yourNumber = strNum;
		this.strPaint = mFont.tahoma_7.splitFontArray(this.yourNumber, 500);
	}

	// Token: 0x06000719 RID: 1817 RVA: 0x00006D63 File Offset: 0x00004F63
	public static void checkRemoveImage()
	{
		ImgByName.checkDelHash(ImgByName.hashImagePath, 10, false);
	}

	// Token: 0x0600071A RID: 1818 RVA: 0x000642A4 File Offset: 0x000624A4
	public static void StartServerPopUp(string strMsg)
	{
		GameCanvas.endDlg();
		int avatar = 1139;
		ChatPopup.addBigMessage(strMsg, 100000, new Npc(-1, 0, 0, 0, 0, 0)
		{
			avatar = avatar
		});
		ChatPopup.serverChatPopUp.cmdMsg1 = new Command(mResources.CLOSE, ChatPopup.serverChatPopUp, 1001, null);
		ChatPopup.serverChatPopUp.cmdMsg1.x = GameCanvas.w / 2 - 35;
		ChatPopup.serverChatPopUp.cmdMsg1.y = GameCanvas.h - 35;
	}

	// Token: 0x04000B9D RID: 2973
	public static bool isPaintOther = false;

	// Token: 0x04000B9E RID: 2974
	public static MyVector textTime = new MyVector(string.Empty);

	// Token: 0x04000B9F RID: 2975
	public static bool isLoadAllData = false;

	// Token: 0x04000BA0 RID: 2976
	public static GameScr instance;

	// Token: 0x04000BA1 RID: 2977
	public static int gW;

	// Token: 0x04000BA2 RID: 2978
	public static int gH;

	// Token: 0x04000BA3 RID: 2979
	public static int gW2;

	// Token: 0x04000BA4 RID: 2980
	public static int gssw;

	// Token: 0x04000BA5 RID: 2981
	public static int gssh;

	// Token: 0x04000BA6 RID: 2982
	public static int gH34;

	// Token: 0x04000BA7 RID: 2983
	public static int gW3;

	// Token: 0x04000BA8 RID: 2984
	public static int gH3;

	// Token: 0x04000BA9 RID: 2985
	public static int gH23;

	// Token: 0x04000BAA RID: 2986
	public static int gW23;

	// Token: 0x04000BAB RID: 2987
	public static int gH2;

	// Token: 0x04000BAC RID: 2988
	public static int csPadMaxH;

	// Token: 0x04000BAD RID: 2989
	public static int cmdBarH;

	// Token: 0x04000BAE RID: 2990
	public static int gW34;

	// Token: 0x04000BAF RID: 2991
	public static int gW6;

	// Token: 0x04000BB0 RID: 2992
	public static int gH6;

	// Token: 0x04000BB1 RID: 2993
	public static int cmx;

	// Token: 0x04000BB2 RID: 2994
	public static int cmy;

	// Token: 0x04000BB3 RID: 2995
	public static int cmdx;

	// Token: 0x04000BB4 RID: 2996
	public static int cmdy;

	// Token: 0x04000BB5 RID: 2997
	public static int cmvx;

	// Token: 0x04000BB6 RID: 2998
	public static int cmvy;

	// Token: 0x04000BB7 RID: 2999
	public static int cmtoX;

	// Token: 0x04000BB8 RID: 3000
	public static int cmtoY;

	// Token: 0x04000BB9 RID: 3001
	public static int cmxLim;

	// Token: 0x04000BBA RID: 3002
	public static int cmyLim;

	// Token: 0x04000BBB RID: 3003
	public static int gssx;

	// Token: 0x04000BBC RID: 3004
	public static int gssy;

	// Token: 0x04000BBD RID: 3005
	public static int gssxe;

	// Token: 0x04000BBE RID: 3006
	public static int gssye;

	// Token: 0x04000BBF RID: 3007
	public Command cmdback;

	// Token: 0x04000BC0 RID: 3008
	public Command cmdBag;

	// Token: 0x04000BC1 RID: 3009
	public Command cmdSkill;

	// Token: 0x04000BC2 RID: 3010
	public Command cmdTiemnang;

	// Token: 0x04000BC3 RID: 3011
	public Command cmdtrangbi;

	// Token: 0x04000BC4 RID: 3012
	public Command cmdInfo;

	// Token: 0x04000BC5 RID: 3013
	public Command cmdFocus;

	// Token: 0x04000BC6 RID: 3014
	public Command cmdFire;

	// Token: 0x04000BC7 RID: 3015
	public static int d;

	// Token: 0x04000BC8 RID: 3016
	public static int hpPotion;

	// Token: 0x04000BC9 RID: 3017
	public static SkillPaint[] sks;

	// Token: 0x04000BCA RID: 3018
	public static Arrowpaint[] arrs;

	// Token: 0x04000BCB RID: 3019
	public static DartInfo[] darts;

	// Token: 0x04000BCC RID: 3020
	public static Part[] parts;

	// Token: 0x04000BCD RID: 3021
	public static EffectCharPaint[] efs;

	// Token: 0x04000BCE RID: 3022
	public static int lockTick;

	// Token: 0x04000BCF RID: 3023
	private int moveUp;

	// Token: 0x04000BD0 RID: 3024
	private int moveDow;

	// Token: 0x04000BD1 RID: 3025
	private int idTypeTask;

	// Token: 0x04000BD2 RID: 3026
	private bool isstarOpen;

	// Token: 0x04000BD3 RID: 3027
	private bool isChangeSkill;

	// Token: 0x04000BD4 RID: 3028
	public static MyVector vClan = new MyVector();

	// Token: 0x04000BD5 RID: 3029
	public static MyVector vPtMap = new MyVector();

	// Token: 0x04000BD6 RID: 3030
	public static MyVector vFriend = new MyVector();

	// Token: 0x04000BD7 RID: 3031
	public static MyVector vEnemies = new MyVector();

	// Token: 0x04000BD8 RID: 3032
	public static MyVector vCharInMap = new MyVector();

	// Token: 0x04000BD9 RID: 3033
	public static MyVector vItemMap = new MyVector();

	// Token: 0x04000BDA RID: 3034
	public static MyVector vMobAttack = new MyVector();

	// Token: 0x04000BDB RID: 3035
	public static MyVector vSet = new MyVector();

	// Token: 0x04000BDC RID: 3036
	public static MyVector vMob = new MyVector();

	// Token: 0x04000BDD RID: 3037
	public static MyVector vNpc = new MyVector();

	// Token: 0x04000BDE RID: 3038
	public static MyVector vFlag = new MyVector();

	// Token: 0x04000BDF RID: 3039
	public static NClass[] nClasss;

	// Token: 0x04000BE0 RID: 3040
	public static int indexSize = 28;

	// Token: 0x04000BE1 RID: 3041
	public static int indexTitle = 0;

	// Token: 0x04000BE2 RID: 3042
	public static int indexSelect = 0;

	// Token: 0x04000BE3 RID: 3043
	public static int indexRow = -1;

	// Token: 0x04000BE4 RID: 3044
	public static int indexRowMax;

	// Token: 0x04000BE5 RID: 3045
	public static int indexMenu = 0;

	// Token: 0x04000BE6 RID: 3046
	public Item itemFocus;

	// Token: 0x04000BE7 RID: 3047
	public ItemOptionTemplate[] iOptionTemplates;

	// Token: 0x04000BE8 RID: 3048
	public SkillOptionTemplate[] sOptionTemplates;

	// Token: 0x04000BE9 RID: 3049
	private static Scroll scrInfo = new Scroll();

	// Token: 0x04000BEA RID: 3050
	public static Scroll scrMain = new Scroll();

	// Token: 0x04000BEB RID: 3051
	public static MyVector vItemUpGrade = new MyVector();

	// Token: 0x04000BEC RID: 3052
	public static bool isTypeXu;

	// Token: 0x04000BED RID: 3053
	public static bool isViewNext;

	// Token: 0x04000BEE RID: 3054
	public static bool isViewClanMemOnline = false;

	// Token: 0x04000BEF RID: 3055
	public static bool isViewClanInvite = true;

	// Token: 0x04000BF0 RID: 3056
	public static bool isChop;

	// Token: 0x04000BF1 RID: 3057
	public static string titleInputText = string.Empty;

	// Token: 0x04000BF2 RID: 3058
	public static int tickMove;

	// Token: 0x04000BF3 RID: 3059
	public static bool isPaintAlert = false;

	// Token: 0x04000BF4 RID: 3060
	public static bool isPaintTask = false;

	// Token: 0x04000BF5 RID: 3061
	public static bool isPaintTeam = false;

	// Token: 0x04000BF6 RID: 3062
	public static bool isPaintFindTeam = false;

	// Token: 0x04000BF7 RID: 3063
	public static bool isPaintFriend = false;

	// Token: 0x04000BF8 RID: 3064
	public static bool isPaintEnemies = false;

	// Token: 0x04000BF9 RID: 3065
	public static bool isPaintItemInfo = false;

	// Token: 0x04000BFA RID: 3066
	public static bool isHaveSelectSkill = false;

	// Token: 0x04000BFB RID: 3067
	public static bool isPaintSkill = false;

	// Token: 0x04000BFC RID: 3068
	public static bool isPaintInfoMe = false;

	// Token: 0x04000BFD RID: 3069
	public static bool isPaintStore = false;

	// Token: 0x04000BFE RID: 3070
	public static bool isPaintNonNam = false;

	// Token: 0x04000BFF RID: 3071
	public static bool isPaintNonNu = false;

	// Token: 0x04000C00 RID: 3072
	public static bool isPaintAoNam = false;

	// Token: 0x04000C01 RID: 3073
	public static bool isPaintAoNu = false;

	// Token: 0x04000C02 RID: 3074
	public static bool isPaintGangTayNam = false;

	// Token: 0x04000C03 RID: 3075
	public static bool isPaintGangTayNu = false;

	// Token: 0x04000C04 RID: 3076
	public static bool isPaintQuanNam = false;

	// Token: 0x04000C05 RID: 3077
	public static bool isPaintQuanNu = false;

	// Token: 0x04000C06 RID: 3078
	public static bool isPaintGiayNam = false;

	// Token: 0x04000C07 RID: 3079
	public static bool isPaintGiayNu = false;

	// Token: 0x04000C08 RID: 3080
	public static bool isPaintLien = false;

	// Token: 0x04000C09 RID: 3081
	public static bool isPaintNhan = false;

	// Token: 0x04000C0A RID: 3082
	public static bool isPaintNgocBoi = false;

	// Token: 0x04000C0B RID: 3083
	public static bool isPaintPhu = false;

	// Token: 0x04000C0C RID: 3084
	public static bool isPaintWeapon = false;

	// Token: 0x04000C0D RID: 3085
	public static bool isPaintStack = false;

	// Token: 0x04000C0E RID: 3086
	public static bool isPaintStackLock = false;

	// Token: 0x04000C0F RID: 3087
	public static bool isPaintGrocery = false;

	// Token: 0x04000C10 RID: 3088
	public static bool isPaintGroceryLock = false;

	// Token: 0x04000C11 RID: 3089
	public static bool isPaintUpGrade = false;

	// Token: 0x04000C12 RID: 3090
	public static bool isPaintConvert = false;

	// Token: 0x04000C13 RID: 3091
	public static bool isPaintUpGradeGold = false;

	// Token: 0x04000C14 RID: 3092
	public static bool isPaintUpPearl = false;

	// Token: 0x04000C15 RID: 3093
	public static bool isPaintBox = false;

	// Token: 0x04000C16 RID: 3094
	public static bool isPaintSplit = false;

	// Token: 0x04000C17 RID: 3095
	public static bool isPaintCharInMap = false;

	// Token: 0x04000C18 RID: 3096
	public static bool isPaintTrade = false;

	// Token: 0x04000C19 RID: 3097
	public static bool isPaintZone = false;

	// Token: 0x04000C1A RID: 3098
	public static bool isPaintMessage = false;

	// Token: 0x04000C1B RID: 3099
	public static bool isPaintClan = false;

	// Token: 0x04000C1C RID: 3100
	public static bool isRequestMember = false;

	// Token: 0x04000C1D RID: 3101
	public static global::Char currentCharViewInfo;

	// Token: 0x04000C1E RID: 3102
	public static long[] exps;

	// Token: 0x04000C1F RID: 3103
	public static int[] crystals;

	// Token: 0x04000C20 RID: 3104
	public static int[] upClothe;

	// Token: 0x04000C21 RID: 3105
	public static int[] upAdorn;

	// Token: 0x04000C22 RID: 3106
	public static int[] upWeapon;

	// Token: 0x04000C23 RID: 3107
	public static int[] coinUpCrystals;

	// Token: 0x04000C24 RID: 3108
	public static int[] coinUpClothes;

	// Token: 0x04000C25 RID: 3109
	public static int[] coinUpAdorns;

	// Token: 0x04000C26 RID: 3110
	public static int[] coinUpWeapons;

	// Token: 0x04000C27 RID: 3111
	public static int[] maxPercents;

	// Token: 0x04000C28 RID: 3112
	public static int[] goldUps;

	// Token: 0x04000C29 RID: 3113
	public int tMenuDelay;

	// Token: 0x04000C2A RID: 3114
	public int zoneCol = 6;

	// Token: 0x04000C2B RID: 3115
	public int[] zones;

	// Token: 0x04000C2C RID: 3116
	public int[] pts;

	// Token: 0x04000C2D RID: 3117
	public int[] numPlayer;

	// Token: 0x04000C2E RID: 3118
	public int[] maxPlayer;

	// Token: 0x04000C2F RID: 3119
	public int[] rank1;

	// Token: 0x04000C30 RID: 3120
	public int[] rank2;

	// Token: 0x04000C31 RID: 3121
	public string[] rankName1;

	// Token: 0x04000C32 RID: 3122
	public string[] rankName2;

	// Token: 0x04000C33 RID: 3123
	public int typeTrade;

	// Token: 0x04000C34 RID: 3124
	public int typeTradeOrder;

	// Token: 0x04000C35 RID: 3125
	public int coinTrade;

	// Token: 0x04000C36 RID: 3126
	public int coinTradeOrder;

	// Token: 0x04000C37 RID: 3127
	public int timeTrade;

	// Token: 0x04000C38 RID: 3128
	public int indexItemUse = -1;

	// Token: 0x04000C39 RID: 3129
	public int cLastFocusID = -1;

	// Token: 0x04000C3A RID: 3130
	public int cPreFocusID = -1;

	// Token: 0x04000C3B RID: 3131
	public bool isLockKey;

	// Token: 0x04000C3C RID: 3132
	public static int[] tasks;

	// Token: 0x04000C3D RID: 3133
	public static int[] mapTasks;

	// Token: 0x04000C3E RID: 3134
	public static Image imgRoomStat;

	// Token: 0x04000C3F RID: 3135
	public static Image frBarPow0;

	// Token: 0x04000C40 RID: 3136
	public static Image frBarPow1;

	// Token: 0x04000C41 RID: 3137
	public static Image frBarPow2;

	// Token: 0x04000C42 RID: 3138
	public static Image frBarPow20;

	// Token: 0x04000C43 RID: 3139
	public static Image frBarPow21;

	// Token: 0x04000C44 RID: 3140
	public static Image frBarPow22;

	// Token: 0x04000C45 RID: 3141
	public MyVector texts;

	// Token: 0x04000C46 RID: 3142
	public string textsTitle;

	// Token: 0x04000C47 RID: 3143
	public static sbyte vcData;

	// Token: 0x04000C48 RID: 3144
	public static sbyte vcMap;

	// Token: 0x04000C49 RID: 3145
	public static sbyte vcSkill;

	// Token: 0x04000C4A RID: 3146
	public static sbyte vcItem;

	// Token: 0x04000C4B RID: 3147
	public static sbyte vsData;

	// Token: 0x04000C4C RID: 3148
	public static sbyte vsMap;

	// Token: 0x04000C4D RID: 3149
	public static sbyte vsSkill;

	// Token: 0x04000C4E RID: 3150
	public static sbyte vsItem;

	// Token: 0x04000C4F RID: 3151
	public static sbyte vcTask;

	// Token: 0x04000C50 RID: 3152
	public static Image imgArrow;

	// Token: 0x04000C51 RID: 3153
	public static Image imgArrow2;

	// Token: 0x04000C52 RID: 3154
	public static Image imgChat;

	// Token: 0x04000C53 RID: 3155
	public static Image imgChat2;

	// Token: 0x04000C54 RID: 3156
	public static Image imgMenu;

	// Token: 0x04000C55 RID: 3157
	public static Image imgFocus;

	// Token: 0x04000C56 RID: 3158
	public static Image imgFocus2;

	// Token: 0x04000C57 RID: 3159
	public static Image imgSkill;

	// Token: 0x04000C58 RID: 3160
	public static Image imgSkill2;

	// Token: 0x04000C59 RID: 3161
	public static Image imgHP1;

	// Token: 0x04000C5A RID: 3162
	public static Image imgHP2;

	// Token: 0x04000C5B RID: 3163
	public static Image imgHP3;

	// Token: 0x04000C5C RID: 3164
	public static Image imgHP4;

	// Token: 0x04000C5D RID: 3165
	public static Image imgFire0;

	// Token: 0x04000C5E RID: 3166
	public static Image imgFire1;

	// Token: 0x04000C5F RID: 3167
	public static Image imgLbtn;

	// Token: 0x04000C60 RID: 3168
	public static Image imgLbtnFocus;

	// Token: 0x04000C61 RID: 3169
	public static Image imgLbtn2;

	// Token: 0x04000C62 RID: 3170
	public static Image imgLbtnFocus2;

	// Token: 0x04000C63 RID: 3171
	public static Image imgAnalog1;

	// Token: 0x04000C64 RID: 3172
	public static Image imgAnalog2;

	// Token: 0x04000C65 RID: 3173
	public string tradeName = string.Empty;

	// Token: 0x04000C66 RID: 3174
	public string tradeItemName = string.Empty;

	// Token: 0x04000C67 RID: 3175
	public int timeLengthMap;

	// Token: 0x04000C68 RID: 3176
	public int timeStartMap;

	// Token: 0x04000C69 RID: 3177
	public static sbyte typeViewInfo = 0;

	// Token: 0x04000C6A RID: 3178
	public static sbyte typeActive = 0;

	// Token: 0x04000C6B RID: 3179
	public static InfoMe info1 = new InfoMe();

	// Token: 0x04000C6C RID: 3180
	public static InfoMe info2 = new InfoMe();

	// Token: 0x04000C6D RID: 3181
	public static Image imgPanel;

	// Token: 0x04000C6E RID: 3182
	public static Image imgPanel2;

	// Token: 0x04000C6F RID: 3183
	public static Image imgHP;

	// Token: 0x04000C70 RID: 3184
	public static Image imgMP;

	// Token: 0x04000C71 RID: 3185
	public static Image imgSP;

	// Token: 0x04000C72 RID: 3186
	public static Image imgHPLost;

	// Token: 0x04000C73 RID: 3187
	public static Image imgMPLost;

	// Token: 0x04000C74 RID: 3188
	public Mob mobCapcha;

	// Token: 0x04000C75 RID: 3189
	public MagicTree magicTree;

	// Token: 0x04000C76 RID: 3190
	public static int countEff;

	// Token: 0x04000C77 RID: 3191
	public static GamePad gamePad = new GamePad();

	// Token: 0x04000C78 RID: 3192
	public static Image imgChatPC;

	// Token: 0x04000C79 RID: 3193
	public static Image imgChatsPC2;

	// Token: 0x04000C7A RID: 3194
	public static int isAnalog = 0;

	// Token: 0x04000C7B RID: 3195
	public static bool isUseTouch;

	// Token: 0x04000C7C RID: 3196
	public static Skill[] keySkill = new Skill[5];

	// Token: 0x04000C7D RID: 3197
	public static Skill[] onScreenSkill = new Skill[5];

	// Token: 0x04000C7E RID: 3198
	public Command cmdMenu;

	// Token: 0x04000C7F RID: 3199
	public static int firstY;

	// Token: 0x04000C80 RID: 3200
	public static int wSkill;

	// Token: 0x04000C81 RID: 3201
	public static long deltaTime;

	// Token: 0x04000C82 RID: 3202
	public bool isPointerDowning;

	// Token: 0x04000C83 RID: 3203
	public bool isChangingCameraMode;

	// Token: 0x04000C84 RID: 3204
	private int ptLastDownX;

	// Token: 0x04000C85 RID: 3205
	private int ptLastDownY;

	// Token: 0x04000C86 RID: 3206
	private int ptFirstDownX;

	// Token: 0x04000C87 RID: 3207
	private int ptFirstDownY;

	// Token: 0x04000C88 RID: 3208
	private int ptDownTime;

	// Token: 0x04000C89 RID: 3209
	private bool disableSingleClick;

	// Token: 0x04000C8A RID: 3210
	public long lastSingleClick;

	// Token: 0x04000C8B RID: 3211
	public bool clickMoving;

	// Token: 0x04000C8C RID: 3212
	public bool clickOnTileTop;

	// Token: 0x04000C8D RID: 3213
	public bool clickMovingRed;

	// Token: 0x04000C8E RID: 3214
	private int clickToX;

	// Token: 0x04000C8F RID: 3215
	private int clickToY;

	// Token: 0x04000C90 RID: 3216
	private int lastClickCMX;

	// Token: 0x04000C91 RID: 3217
	private int lastClickCMY;

	// Token: 0x04000C92 RID: 3218
	private int clickMovingP1;

	// Token: 0x04000C93 RID: 3219
	private int clickMovingTimeOut;

	// Token: 0x04000C94 RID: 3220
	private long lastMove;

	// Token: 0x04000C95 RID: 3221
	public static bool isNewClanMessage;

	// Token: 0x04000C96 RID: 3222
	private long lastFire;

	// Token: 0x04000C97 RID: 3223
	private long lastUsePotion;

	// Token: 0x04000C98 RID: 3224
	public int auto;

	// Token: 0x04000C99 RID: 3225
	public int dem;

	// Token: 0x04000C9A RID: 3226
	private string strTam = string.Empty;

	// Token: 0x04000C9B RID: 3227
	private int a;

	// Token: 0x04000C9C RID: 3228
	public bool isFreez;

	// Token: 0x04000C9D RID: 3229
	public bool isUseFreez;

	// Token: 0x04000C9E RID: 3230
	public static Image imgTrans;

	// Token: 0x04000C9F RID: 3231
	public bool isRongThanXuatHien;

	// Token: 0x04000CA0 RID: 3232
	public bool isRongNamek;

	// Token: 0x04000CA1 RID: 3233
	public bool isSuperPower;

	// Token: 0x04000CA2 RID: 3234
	public int tPower;

	// Token: 0x04000CA3 RID: 3235
	public int xPower;

	// Token: 0x04000CA4 RID: 3236
	public int yPower;

	// Token: 0x04000CA5 RID: 3237
	public int dxPower;

	// Token: 0x04000CA6 RID: 3238
	public bool activeRongThan;

	// Token: 0x04000CA7 RID: 3239
	public bool isMeCallRongThan;

	// Token: 0x04000CA8 RID: 3240
	public int mautroi;

	// Token: 0x04000CA9 RID: 3241
	public int mapRID;

	// Token: 0x04000CAA RID: 3242
	public int zoneRID;

	// Token: 0x04000CAB RID: 3243
	public int bgRID = -1;

	// Token: 0x04000CAC RID: 3244
	public static int tam = 0;

	// Token: 0x04000CAD RID: 3245
	public static bool isAutoPlay;

	// Token: 0x04000CAE RID: 3246
	public static bool canAutoPlay;

	// Token: 0x04000CAF RID: 3247
	public static bool isChangeZone;

	// Token: 0x04000CB0 RID: 3248
	private int timeSkill;

	// Token: 0x04000CB1 RID: 3249
	private int nSkill;

	// Token: 0x04000CB2 RID: 3250
	private int selectedIndexSkill = -1;

	// Token: 0x04000CB3 RID: 3251
	private Skill lastSkill;

	// Token: 0x04000CB4 RID: 3252
	private bool doSeleckSkillFlag;

	// Token: 0x04000CB5 RID: 3253
	public string strCapcha;

	// Token: 0x04000CB6 RID: 3254
	private long longPress;

	// Token: 0x04000CB7 RID: 3255
	private int move;

	// Token: 0x04000CB8 RID: 3256
	public bool flareFindFocus;

	// Token: 0x04000CB9 RID: 3257
	private int flareTime;

	// Token: 0x04000CBA RID: 3258
	public int keyTouchSkill = -1;

	// Token: 0x04000CBB RID: 3259
	private long lastSendUpdatePostion;

	// Token: 0x04000CBC RID: 3260
	public static long lastTick;

	// Token: 0x04000CBD RID: 3261
	public static long currTick;

	// Token: 0x04000CBE RID: 3262
	private int timeAuto;

	// Token: 0x04000CBF RID: 3263
	public static long lastXS;

	// Token: 0x04000CC0 RID: 3264
	public static long currXS;

	// Token: 0x04000CC1 RID: 3265
	public static int secondXS;

	// Token: 0x04000CC2 RID: 3266
	public int runArrow;

	// Token: 0x04000CC3 RID: 3267
	public static int isPaintRada;

	// Token: 0x04000CC4 RID: 3268
	public static Image imgNut;

	// Token: 0x04000CC5 RID: 3269
	public static Image imgNutF;

	// Token: 0x04000CC6 RID: 3270
	public int[] keyCapcha;

	// Token: 0x04000CC7 RID: 3271
	public static Image imgCapcha;

	// Token: 0x04000CC8 RID: 3272
	public string keyInput;

	// Token: 0x04000CC9 RID: 3273
	public static int disXC;

	// Token: 0x04000CCA RID: 3274
	public static bool isPaint = true;

	// Token: 0x04000CCB RID: 3275
	public static int shock_scr;

	// Token: 0x04000CCC RID: 3276
	private static int[] shock_x = new int[]
	{
		3,
		-3,
		3,
		-3
	};

	// Token: 0x04000CCD RID: 3277
	private static int[] shock_y = new int[]
	{
		3,
		-3,
		-3,
		3
	};

	// Token: 0x04000CCE RID: 3278
	private int tDoubleDelay;

	// Token: 0x04000CCF RID: 3279
	public static Image arrow;

	// Token: 0x04000CD0 RID: 3280
	private static int yTouchBar;

	// Token: 0x04000CD1 RID: 3281
	private static int xC;

	// Token: 0x04000CD2 RID: 3282
	private static int yC;

	// Token: 0x04000CD3 RID: 3283
	private static int xL;

	// Token: 0x04000CD4 RID: 3284
	private static int yL;

	// Token: 0x04000CD5 RID: 3285
	public int xR;

	// Token: 0x04000CD6 RID: 3286
	public int yR;

	// Token: 0x04000CD7 RID: 3287
	private static int xU;

	// Token: 0x04000CD8 RID: 3288
	private static int yU;

	// Token: 0x04000CD9 RID: 3289
	private static int xF;

	// Token: 0x04000CDA RID: 3290
	private static int yF;

	// Token: 0x04000CDB RID: 3291
	public static int xHP;

	// Token: 0x04000CDC RID: 3292
	public static int yHP;

	// Token: 0x04000CDD RID: 3293
	private static int xTG;

	// Token: 0x04000CDE RID: 3294
	private static int yTG;

	// Token: 0x04000CDF RID: 3295
	public static int[] xS;

	// Token: 0x04000CE0 RID: 3296
	public static int[] yS;

	// Token: 0x04000CE1 RID: 3297
	public static int xSkill;

	// Token: 0x04000CE2 RID: 3298
	public static int ySkill;

	// Token: 0x04000CE3 RID: 3299
	public static int padSkill;

	// Token: 0x04000CE4 RID: 3300
	public int dMP;

	// Token: 0x04000CE5 RID: 3301
	public int twMp;

	// Token: 0x04000CE6 RID: 3302
	public bool isInjureMp;

	// Token: 0x04000CE7 RID: 3303
	public int dHP;

	// Token: 0x04000CE8 RID: 3304
	public int twHp;

	// Token: 0x04000CE9 RID: 3305
	public bool isInjureHp;

	// Token: 0x04000CEA RID: 3306
	private long curr;

	// Token: 0x04000CEB RID: 3307
	private long last;

	// Token: 0x04000CEC RID: 3308
	private int secondVS;

	// Token: 0x04000CED RID: 3309
	private int[] idVS = new int[]
	{
		-1,
		-1
	};

	// Token: 0x04000CEE RID: 3310
	public static string[] flyTextString;

	// Token: 0x04000CEF RID: 3311
	public static int[] flyTextX;

	// Token: 0x04000CF0 RID: 3312
	public static int[] flyTextY;

	// Token: 0x04000CF1 RID: 3313
	public static int[] flyTextYTo;

	// Token: 0x04000CF2 RID: 3314
	public static int[] flyTextDx;

	// Token: 0x04000CF3 RID: 3315
	public static int[] flyTextDy;

	// Token: 0x04000CF4 RID: 3316
	public static int[] flyTextState;

	// Token: 0x04000CF5 RID: 3317
	public static int[] flyTextColor;

	// Token: 0x04000CF6 RID: 3318
	public static int[] flyTime;

	// Token: 0x04000CF7 RID: 3319
	public static int[] splashX;

	// Token: 0x04000CF8 RID: 3320
	public static int[] splashY;

	// Token: 0x04000CF9 RID: 3321
	public static int[] splashState;

	// Token: 0x04000CFA RID: 3322
	public static int[] splashF;

	// Token: 0x04000CFB RID: 3323
	public static int[] splashDir;

	// Token: 0x04000CFC RID: 3324
	public static Image[] imgSplash;

	// Token: 0x04000CFD RID: 3325
	public static int cmdBarX;

	// Token: 0x04000CFE RID: 3326
	public static int cmdBarY;

	// Token: 0x04000CFF RID: 3327
	public static int cmdBarW;

	// Token: 0x04000D00 RID: 3328
	public static int cmdBarLeftW;

	// Token: 0x04000D01 RID: 3329
	public static int cmdBarRightW;

	// Token: 0x04000D02 RID: 3330
	public static int cmdBarCenterW;

	// Token: 0x04000D03 RID: 3331
	public static int hpBarX;

	// Token: 0x04000D04 RID: 3332
	public static int hpBarY;

	// Token: 0x04000D05 RID: 3333
	public static int hpBarW;

	// Token: 0x04000D06 RID: 3334
	public static int spBarW;

	// Token: 0x04000D07 RID: 3335
	public static int mpBarW;

	// Token: 0x04000D08 RID: 3336
	public static int expBarW;

	// Token: 0x04000D09 RID: 3337
	public static int lvPosX;

	// Token: 0x04000D0A RID: 3338
	public static int moneyPosX;

	// Token: 0x04000D0B RID: 3339
	public static int hpBarH;

	// Token: 0x04000D0C RID: 3340
	public static int girlHPBarY;

	// Token: 0x04000D0D RID: 3341
	public static Image[] imgCmdBar;

	// Token: 0x04000D0E RID: 3342
	private int imgScrW;

	// Token: 0x04000D0F RID: 3343
	public static int popupY;

	// Token: 0x04000D10 RID: 3344
	public static int popupX;

	// Token: 0x04000D11 RID: 3345
	public static int isborderIndex;

	// Token: 0x04000D12 RID: 3346
	public static int isselectedRow;

	// Token: 0x04000D13 RID: 3347
	private static Image imgNolearn;

	// Token: 0x04000D14 RID: 3348
	public int cmxp;

	// Token: 0x04000D15 RID: 3349
	public int cmvxp;

	// Token: 0x04000D16 RID: 3350
	public int cmdxp;

	// Token: 0x04000D17 RID: 3351
	public int cmxLimp;

	// Token: 0x04000D18 RID: 3352
	public int cmyLimp;

	// Token: 0x04000D19 RID: 3353
	public int cmyp;

	// Token: 0x04000D1A RID: 3354
	public int cmvyp;

	// Token: 0x04000D1B RID: 3355
	public int cmdyp;

	// Token: 0x04000D1C RID: 3356
	private int indexTiemNang;

	// Token: 0x04000D1D RID: 3357
	private string alertURL;

	// Token: 0x04000D1E RID: 3358
	private string fnick;

	// Token: 0x04000D1F RID: 3359
	public static int xstart;

	// Token: 0x04000D20 RID: 3360
	public static int ystart;

	// Token: 0x04000D21 RID: 3361
	public static int popupW = 140;

	// Token: 0x04000D22 RID: 3362
	public static int popupH = 160;

	// Token: 0x04000D23 RID: 3363
	public static int cmySK;

	// Token: 0x04000D24 RID: 3364
	public static int cmtoYSK;

	// Token: 0x04000D25 RID: 3365
	public static int cmdySK;

	// Token: 0x04000D26 RID: 3366
	public static int cmvySK;

	// Token: 0x04000D27 RID: 3367
	public static int cmyLimSK;

	// Token: 0x04000D28 RID: 3368
	public static int columns = 6;

	// Token: 0x04000D29 RID: 3369
	public static int rows;

	// Token: 0x04000D2A RID: 3370
	private int totalRowInfo;

	// Token: 0x04000D2B RID: 3371
	private int ypaintKill;

	// Token: 0x04000D2C RID: 3372
	private int ylimUp;

	// Token: 0x04000D2D RID: 3373
	private int ylimDow;

	// Token: 0x04000D2E RID: 3374
	private int yPaint;

	// Token: 0x04000D2F RID: 3375
	public static int indexEff = 0;

	// Token: 0x04000D30 RID: 3376
	public static EffectCharPaint effUpok;

	// Token: 0x04000D31 RID: 3377
	public static int inforX;

	// Token: 0x04000D32 RID: 3378
	public static int inforY;

	// Token: 0x04000D33 RID: 3379
	public static int inforW;

	// Token: 0x04000D34 RID: 3380
	public static int inforH;

	// Token: 0x04000D35 RID: 3381
	public Command cmdDead;

	// Token: 0x04000D36 RID: 3382
	public static bool notPaint = false;

	// Token: 0x04000D37 RID: 3383
	public static bool isPing = false;

	// Token: 0x04000D38 RID: 3384
	public static int INFO = 0;

	// Token: 0x04000D39 RID: 3385
	public static int STORE = 1;

	// Token: 0x04000D3A RID: 3386
	public static int ZONE = 2;

	// Token: 0x04000D3B RID: 3387
	public static int UPGRADE = 3;

	// Token: 0x04000D3C RID: 3388
	private int Hitem = 30;

	// Token: 0x04000D3D RID: 3389
	private int maxSizeRow = 5;

	// Token: 0x04000D3E RID: 3390
	private int isTranKyNang;

	// Token: 0x04000D3F RID: 3391
	private bool isTran;

	// Token: 0x04000D40 RID: 3392
	private int cmY_Old;

	// Token: 0x04000D41 RID: 3393
	private int cmX_Old;

	// Token: 0x04000D42 RID: 3394
	public PopUpYesNo popUpYesNo;

	// Token: 0x04000D43 RID: 3395
	public static MyVector vChatVip = new MyVector();

	// Token: 0x04000D44 RID: 3396
	public static int vBig;

	// Token: 0x04000D45 RID: 3397
	public bool isFireWorks;

	// Token: 0x04000D46 RID: 3398
	public int[] winnumber;

	// Token: 0x04000D47 RID: 3399
	public int[] randomNumber;

	// Token: 0x04000D48 RID: 3400
	public int[] tMove;

	// Token: 0x04000D49 RID: 3401
	public int[] moveCount;

	// Token: 0x04000D4A RID: 3402
	public int[] delayMove;

	// Token: 0x04000D4B RID: 3403
	public int moveIndex;

	// Token: 0x04000D4C RID: 3404
	private bool isWin;

	// Token: 0x04000D4D RID: 3405
	private string strFinish;

	// Token: 0x04000D4E RID: 3406
	private int tShow;

	// Token: 0x04000D4F RID: 3407
	private int xChatVip;

	// Token: 0x04000D50 RID: 3408
	private int currChatWidth;

	// Token: 0x04000D51 RID: 3409
	private bool startChat;

	// Token: 0x04000D52 RID: 3410
	public sbyte percentMabu;

	// Token: 0x04000D53 RID: 3411
	public bool mabuEff;

	// Token: 0x04000D54 RID: 3412
	public int tMabuEff;

	// Token: 0x04000D55 RID: 3413
	public static bool isPaintChatVip;

	// Token: 0x04000D56 RID: 3414
	public static sbyte mabuPercent;

	// Token: 0x04000D57 RID: 3415
	public static sbyte isNewMember;

	// Token: 0x04000D58 RID: 3416
	private string yourNumber = string.Empty;

	// Token: 0x04000D59 RID: 3417
	private string[] strPaint;
}
