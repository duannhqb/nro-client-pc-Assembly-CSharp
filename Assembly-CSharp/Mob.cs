using System;
using Assets.src.g;

// Token: 0x020000B0 RID: 176
public class Mob : IMapObject
{
	// Token: 0x06000788 RID: 1928 RVA: 0x00069694 File Offset: 0x00067894
	public Mob()
	{
	}

	// Token: 0x06000789 RID: 1929 RVA: 0x00069758 File Offset: 0x00067958
	public Mob(int mobId, bool isDisable, bool isDontMove, bool isFire, bool isIce, bool isWind, int templateId, int sys, int hp, sbyte level, int maxp, short pointx, short pointy, sbyte status, sbyte levelBoss)
	{
		this.isDisable = isDisable;
		this.isDontMove = isDontMove;
		this.isFire = isFire;
		this.isIce = isIce;
		this.isWind = isWind;
		this.sys = sys;
		this.mobId = mobId;
		this.templateId = templateId;
		this.hp = hp;
		this.level = level;
		this.pointx = pointx;
		this.x = (int)pointx;
		this.xFirst = (int)pointx;
		this.pointy = pointy;
		this.y = (int)pointy;
		this.yFirst = (int)pointy;
		this.status = (int)status;
		if (templateId != 70)
		{
			this.checkData();
			this.getData();
		}
		if (!Mob.isExistNewMob(templateId + string.Empty))
		{
			Mob.newMob.addElement(templateId + string.Empty);
		}
		this.maxHp = maxp;
		this.levelBoss = levelBoss;
		this.isDie = false;
		this.xSd = (int)pointx;
		this.ySd = (int)pointy;
		if (this.isNewModStand())
		{
			this.stand = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1,
				1,
				2,
				2,
				2,
				2,
				2,
				2,
				2
			};
			this.move = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1,
				1,
				2,
				2,
				2,
				2,
				2,
				2,
				2
			};
			this.moveFast = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1,
				1,
				2,
				2,
				2,
				2,
				2,
				2,
				2
			};
			this.attack1 = new int[]
			{
				3,
				3,
				3,
				3,
				4,
				4,
				4,
				4,
				5,
				5,
				5,
				5
			};
			this.attack2 = new int[]
			{
				3,
				3,
				3,
				3,
				4,
				4,
				4,
				4,
				5,
				5,
				5,
				5
			};
		}
		else if (this.isNewMod())
		{
			this.stand = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			};
			this.move = new int[]
			{
				1,
				1,
				1,
				1,
				2,
				2,
				2,
				2,
				1,
				1,
				1,
				1,
				3,
				3,
				3,
				3
			};
			this.moveFast = new int[]
			{
				1,
				1,
				2,
				2,
				1,
				1,
				3,
				3
			};
			this.attack1 = new int[]
			{
				4,
				4,
				4,
				5,
				5,
				5,
				6,
				6,
				6,
				6,
				6
			};
			this.attack2 = new int[]
			{
				7,
				7,
				7,
				8,
				8,
				8,
				9,
				9,
				9,
				9,
				9
			};
		}
		else if (this.isSpecial())
		{
			this.stand = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			};
			this.move = new int[]
			{
				2,
				2,
				3,
				3,
				2,
				2,
				4,
				4,
				2,
				2,
				3,
				3,
				2,
				2,
				4,
				4
			};
			this.moveFast = new int[]
			{
				2,
				2,
				3,
				3,
				2,
				2,
				4,
				4
			};
			this.attack1 = new int[]
			{
				5,
				6,
				7,
				8,
				9,
				10,
				11,
				12
			};
			this.attack2 = new int[]
			{
				5,
				12,
				13,
				14
			};
		}
		else
		{
			this.stand = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			};
			this.move = new int[]
			{
				1,
				1,
				1,
				1,
				2,
				2,
				2,
				2,
				3,
				3,
				3,
				3,
				2,
				2,
				2
			};
			this.moveFast = new int[]
			{
				1,
				1,
				2,
				2,
				3,
				3,
				2
			};
			this.attack1 = new int[]
			{
				4,
				5,
				6
			};
			this.attack2 = new int[]
			{
				7,
				8,
				9
			};
		}
	}

	// Token: 0x0600078A RID: 1930 RVA: 0x00007099 File Offset: 0x00005299
	public bool isBigBoss()
	{
		return this is BachTuoc || this is BigBoss2 || this is BigBoss || this is NewBoss;
	}

	// Token: 0x0600078B RID: 1931 RVA: 0x00069B20 File Offset: 0x00067D20
	public void getData()
	{
		if (Mob.arrMobTemplate[this.templateId].data == null)
		{
			Mob.arrMobTemplate[this.templateId].data = new EffectData();
			string text = "/Mob/" + this.templateId;
			DataInputStream dataInputStream = MyStream.readFile(text);
			if (dataInputStream != null)
			{
				Mob.arrMobTemplate[this.templateId].data.readData(text + "/data");
				Mob.arrMobTemplate[this.templateId].data.img = GameCanvas.loadImage(text + "/img.png");
			}
			else
			{
				Service.gI().requestModTemplate(this.templateId);
			}
			Mob.lastMob.addElement(this.templateId + string.Empty);
		}
		else
		{
			this.w = Mob.arrMobTemplate[this.templateId].data.width;
			this.h = Mob.arrMobTemplate[this.templateId].data.height;
		}
	}

	// Token: 0x0600078C RID: 1932 RVA: 0x000060C5 File Offset: 0x000042C5
	public void setBody(short id)
	{
		this.changBody = true;
		this.smallBody = id;
	}

	// Token: 0x0600078D RID: 1933 RVA: 0x000060D5 File Offset: 0x000042D5
	public void clearBody()
	{
		this.changBody = false;
	}

	// Token: 0x0600078E RID: 1934 RVA: 0x000418AC File Offset: 0x0003FAAC
	public static bool isExistNewMob(string id)
	{
		for (int i = 0; i < Mob.newMob.size(); i++)
		{
			string text = (string)Mob.newMob.elementAt(i);
			if (text.Equals(id))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600078F RID: 1935 RVA: 0x00069C34 File Offset: 0x00067E34
	public void checkData()
	{
		int num = 0;
		for (int i = 0; i < Mob.arrMobTemplate.Length; i++)
		{
			if (Mob.arrMobTemplate[i].data != null)
			{
				num++;
			}
		}
		if (num >= 10)
		{
			for (int j = 0; j < Mob.arrMobTemplate.Length; j++)
			{
				if (Mob.arrMobTemplate[j].data != null && num > 5)
				{
					Mob.arrMobTemplate[j].data = null;
				}
			}
		}
	}

	// Token: 0x06000790 RID: 1936 RVA: 0x000070C8 File Offset: 0x000052C8
	public void checkFrameTick(int[] array)
	{
		if (this.tick > array.Length - 1)
		{
			this.tick = 0;
		}
		this.frame = array[this.tick];
		this.tick++;
	}

	// Token: 0x06000791 RID: 1937 RVA: 0x00069CB8 File Offset: 0x00067EB8
	private void updateShadown()
	{
		int num = (int)TileMap.size;
		this.xSd = this.x;
		this.wCount = 0;
		if (this.ySd <= 0)
		{
			return;
		}
		if (TileMap.tileTypeAt(this.xSd, this.ySd, 2))
		{
			return;
		}
		if (TileMap.tileTypeAt(this.xSd / num, this.ySd / num) == 0)
		{
			this.isOutMap = true;
		}
		else if (TileMap.tileTypeAt(this.xSd / num, this.ySd / num) != 0 && !TileMap.tileTypeAt(this.xSd, this.ySd, 2))
		{
			this.xSd = this.x;
			this.ySd = this.y;
			this.isOutMap = false;
		}
		while (this.isOutMap && this.wCount < 10)
		{
			this.wCount++;
			this.ySd += 24;
			if (TileMap.tileTypeAt(this.xSd, this.ySd, 2))
			{
				if (this.ySd % 24 != 0)
				{
					this.ySd -= this.ySd % 24;
				}
				return;
			}
		}
	}

	// Token: 0x06000792 RID: 1938 RVA: 0x00069DF0 File Offset: 0x00067FF0
	private void paintShadow(mGraphics g)
	{
		int num = (int)TileMap.size;
		if (TileMap.tileTypeAt(this.xSd + num / 2, this.ySd + 1, 4))
		{
			g.setClip(this.xSd / num * num, (this.ySd - 30) / num * num, num, 100);
		}
		else if (TileMap.tileTypeAt((this.xSd - num / 2) / num, (this.ySd + 1) / num) == 0)
		{
			g.setClip(this.xSd / num * num, (this.ySd - 30) / num * num, 100, 100);
		}
		else if (TileMap.tileTypeAt((this.xSd + num / 2) / num, (this.ySd + 1) / num) == 0)
		{
			g.setClip(this.xSd / num * num, (this.ySd - 30) / num * num, num, 100);
		}
		else if (TileMap.tileTypeAt(this.xSd - num / 2, this.ySd + 1, 8))
		{
			g.setClip(this.xSd / 24 * num, (this.ySd - 30) / num * num, num, 100);
		}
		g.drawImage(TileMap.bong, this.xSd, this.ySd, 3);
		g.setClip(GameScr.cmx, GameScr.cmy - GameCanvas.transY, GameScr.gW, GameScr.gH + 2 * GameCanvas.transY);
	}

	// Token: 0x06000793 RID: 1939 RVA: 0x00069F50 File Offset: 0x00068150
	public void updateSuperEff()
	{
		if (this.typeSuperEff == 0 && GameCanvas.gameTick % 25 == 0)
		{
			ServerEffect.addServerEffect(114, this, 1);
		}
		if (this.typeSuperEff == 1 && GameCanvas.gameTick % 4 == 0)
		{
			ServerEffect.addServerEffect(132, this, 1);
		}
		if (this.typeSuperEff == 2 && GameCanvas.gameTick % 7 == 0)
		{
			ServerEffect.addServerEffect(131, this, 1);
		}
	}

	// Token: 0x06000794 RID: 1940 RVA: 0x00069FC8 File Offset: 0x000681C8
	public virtual void update()
	{
		if (this.blindEff && GameCanvas.gameTick % 5 == 0)
		{
			ServerEffect.addServerEffect(113, this.x, this.y, 1);
		}
		if (this.sleepEff && GameCanvas.gameTick % 10 == 0)
		{
			EffecMn.addEff(new Effect(41, this.x, this.y, 3, 1, 1));
		}
		if (!GameCanvas.lowGraphic && this.status != 1 && this.status != 0 && !GameCanvas.lowGraphic && GameCanvas.gameTick % (15 + this.mobId * 2) == 0)
		{
			for (int i = 0; i < GameScr.vCharInMap.size(); i++)
			{
				global::Char @char = (global::Char)GameScr.vCharInMap.elementAt(i);
				if (@char != null && @char.isFlyAndCharge && @char.cf == 32)
				{
					global::Char char2 = new global::Char();
					char2.cx = @char.cx;
					char2.cy = @char.cy - @char.ch;
					if (@char.cgender == 0)
					{
						MonsterDart.addMonsterDart(this.x + this.dir * this.w, this.y, this.checkIsBoss(), -100, -100, char2, 25);
					}
				}
			}
			if (global::Char.myCharz().isFlyAndCharge && global::Char.myCharz().cf == 32)
			{
				global::Char char3 = new global::Char();
				char3.cx = global::Char.myCharz().cx;
				char3.cy = global::Char.myCharz().cy - global::Char.myCharz().ch;
				if (global::Char.myCharz().cgender == 0)
				{
					MonsterDart.addMonsterDart(this.x + this.dir * this.w, this.y, this.checkIsBoss(), -100, -100, char3, 25);
				}
			}
		}
		if (this.holdEffID != 0 && GameCanvas.gameTick % 5 == 0)
		{
			EffecMn.addEff(new Effect(this.holdEffID, this.x, this.y + 24, 3, 5, 1));
		}
		if (this.isFreez)
		{
			if (GameCanvas.gameTick % 5 == 0)
			{
				ServerEffect.addServerEffect(113, this.x, this.y, 1);
			}
			long num = mSystem.currentTimeMillis();
			if (num - this.last >= 1000L)
			{
				this.seconds--;
				this.last = num;
				if (this.seconds < 0)
				{
					this.isFreez = false;
					this.seconds = 0;
				}
			}
			if (this.isNewModStand())
			{
				this.frame = this.attack1[GameCanvas.gameTick % this.attack1.Length];
			}
			else if (this.isNewMod())
			{
				if (GameCanvas.gameTick % 20 > 5)
				{
					this.frame = 11;
				}
				else
				{
					this.frame = 10;
				}
			}
			else if (this.isSpecial())
			{
				if (GameCanvas.gameTick % 20 > 5)
				{
					this.frame = 1;
				}
				else
				{
					this.frame = 15;
				}
			}
			else if (GameCanvas.gameTick % 20 > 5)
			{
				this.frame = 11;
			}
			else
			{
				this.frame = 10;
			}
		}
		if (!this.isUpdate())
		{
			return;
		}
		if (this.isShadown)
		{
			this.updateShadown();
		}
		if (this.vMobMove == null && (int)Mob.arrMobTemplate[this.templateId].rangeMove != 0)
		{
			return;
		}
		if (this.status != 3 && this.isBusyAttackSomeOne)
		{
			if (this.cFocus != null)
			{
				this.cFocus.doInjure(this.dame, this.dameMp, false, true);
			}
			else if (this.mobToAttack != null)
			{
				this.mobToAttack.setInjure();
			}
			this.isBusyAttackSomeOne = false;
		}
		if ((int)this.levelBoss > 0)
		{
			this.updateSuperEff();
		}
		switch (this.status)
		{
		case 1:
			this.isDisable = false;
			this.isDontMove = false;
			this.isFire = false;
			this.isIce = false;
			this.isWind = false;
			this.y += this.p1;
			if (GameCanvas.gameTick % 2 == 0)
			{
				if (this.p2 > 1)
				{
					this.p2--;
				}
				else if (this.p2 < -1)
				{
					this.p2++;
				}
			}
			this.x += this.p2;
			if (this.isNewModStand())
			{
				this.frame = this.attack1[GameCanvas.gameTick % this.attack1.Length];
			}
			else if (this.isNewMod())
			{
				this.frame = 11;
			}
			else if (this.isSpecial())
			{
				this.frame = 15;
			}
			else
			{
				this.frame = 11;
			}
			if (this.isDie)
			{
				this.isDie = false;
				if (this.isMobMe)
				{
					for (int j = 0; j < GameScr.vMob.size(); j++)
					{
						if (((Mob)GameScr.vMob.elementAt(j)).mobId == this.mobId)
						{
							GameScr.vMob.removeElementAt(j);
						}
					}
				}
				this.p1 = 0;
				this.p2 = 0;
				this.x = (this.y = 0);
				this.hp = this.getTemplate().hp;
				this.status = 0;
				this.timeStatus = 0;
				return;
			}
			if ((TileMap.tileTypeAtPixel(this.x, this.y) & 2) == 2)
			{
				this.p1 = ((this.p1 <= 4) ? (-this.p1) : -4);
				if (this.p3 == 0)
				{
					this.p3 = 16;
				}
			}
			else
			{
				this.p1++;
			}
			if (this.p3 > 0)
			{
				this.p3--;
				if (this.p3 == 0)
				{
					this.isDie = true;
				}
			}
			break;
		case 2:
			if (this.holdEffID != 0)
			{
				return;
			}
			if (this.isFreez)
			{
				return;
			}
			if (this.blindEff)
			{
				return;
			}
			if (this.sleepEff)
			{
				return;
			}
			this.timeStatus = 0;
			this.updateMobStandWait();
			break;
		case 3:
			if (this.holdEffID != 0)
			{
				return;
			}
			if (this.blindEff)
			{
				return;
			}
			if (this.sleepEff)
			{
				return;
			}
			if (this.isFreez)
			{
				return;
			}
			this.updateMobAttack();
			break;
		case 4:
			if (this.holdEffID != 0)
			{
				return;
			}
			if (this.blindEff)
			{
				return;
			}
			if (this.sleepEff)
			{
				return;
			}
			if (this.isFreez)
			{
				return;
			}
			this.timeStatus = 0;
			this.p1++;
			if (this.p1 > 40 + this.mobId % 5)
			{
				this.y -= 2;
				this.status = 5;
				this.p1 = 0;
			}
			break;
		case 5:
			if (this.holdEffID != 0)
			{
				return;
			}
			if (this.blindEff)
			{
				return;
			}
			if (this.sleepEff)
			{
				return;
			}
			if (this.isFreez)
			{
				if ((int)Mob.arrMobTemplate[this.templateId].type == 4)
				{
					this.ty++;
					this.wt++;
					this.fy += (this.wy ? -1 : 1);
					if (this.wt == 10)
					{
						this.wt = 0;
						this.wy = !this.wy;
					}
				}
				return;
			}
			this.timeStatus = 0;
			this.updateMobWalk();
			break;
		case 6:
			this.timeStatus = 0;
			this.p1++;
			this.y += this.p1;
			if (this.y >= this.yFirst)
			{
				this.y = this.yFirst;
				this.p1 = 0;
				this.status = 5;
			}
			break;
		case 7:
			this.updateInjure();
			break;
		}
	}

	// Token: 0x06000795 RID: 1941 RVA: 0x0006A828 File Offset: 0x00068A28
	public void setInjure()
	{
		if (this.hp > 0 && this.status != 3)
		{
			this.timeStatus = 4;
			this.status = 7;
			if ((int)this.getTemplate().type != 0 && Res.abs(this.x - this.xFirst) < 30)
			{
				this.x -= 10 * this.dir;
			}
		}
	}

	// Token: 0x06000796 RID: 1942 RVA: 0x0006A89C File Offset: 0x00068A9C
	public static BigBoss getBigBoss()
	{
		for (int i = 0; i < GameScr.vMob.size(); i++)
		{
			Mob mob = (Mob)GameScr.vMob.elementAt(i);
			if (mob is BigBoss)
			{
				return (BigBoss)mob;
			}
		}
		return null;
	}

	// Token: 0x06000797 RID: 1943 RVA: 0x0006A8E8 File Offset: 0x00068AE8
	public static BigBoss2 getBigBoss2()
	{
		for (int i = 0; i < GameScr.vMob.size(); i++)
		{
			Mob mob = (Mob)GameScr.vMob.elementAt(i);
			if (mob is BigBoss2)
			{
				return (BigBoss2)mob;
			}
		}
		return null;
	}

	// Token: 0x06000798 RID: 1944 RVA: 0x0006A934 File Offset: 0x00068B34
	public static BachTuoc getBachTuoc()
	{
		for (int i = 0; i < GameScr.vMob.size(); i++)
		{
			Mob mob = (Mob)GameScr.vMob.elementAt(i);
			if (mob is BachTuoc)
			{
				return (BachTuoc)mob;
			}
		}
		return null;
	}

	// Token: 0x06000799 RID: 1945 RVA: 0x0006A980 File Offset: 0x00068B80
	public static NewBoss getNewBoss(sbyte idBoss)
	{
		Mob mob = (Mob)GameScr.vMob.elementAt((int)idBoss);
		if (mob is NewBoss)
		{
			return (NewBoss)mob;
		}
		return null;
	}

	// Token: 0x0600079A RID: 1946 RVA: 0x0006A9B4 File Offset: 0x00068BB4
	public static void removeBigBoss()
	{
		for (int i = 0; i < GameScr.vMob.size(); i++)
		{
			Mob mob = (Mob)GameScr.vMob.elementAt(i);
			if (mob is BigBoss)
			{
				GameScr.vMob.removeElement(mob);
				return;
			}
		}
	}

	// Token: 0x0600079B RID: 1947 RVA: 0x0006AA04 File Offset: 0x00068C04
	public void setAttack(global::Char cFocus)
	{
		this.isBusyAttackSomeOne = true;
		this.mobToAttack = null;
		this.cFocus = cFocus;
		this.p1 = 0;
		this.p2 = 0;
		this.status = 3;
		this.tick = 0;
		this.dir = ((cFocus.cx <= this.x) ? -1 : 1);
		int cx = cFocus.cx;
		int cy = cFocus.cy;
		if (Res.abs(cx - this.x) < this.w * 2 && Res.abs(cy - this.y) < this.h * 2)
		{
			if (this.x < cx)
			{
				this.x = cx - this.w;
			}
			else
			{
				this.x = cx + this.w;
			}
			this.p3 = 0;
		}
		else
		{
			this.p3 = 1;
		}
	}

	// Token: 0x0600079C RID: 1948 RVA: 0x00006113 File Offset: 0x00004313
	private bool isSpecial()
	{
		return (this.templateId >= 58 && this.templateId <= 65) || this.templateId == 67 || this.templateId == 68;
	}

	// Token: 0x0600079D RID: 1949 RVA: 0x000070FD File Offset: 0x000052FD
	private bool isNewMod()
	{
		return this.templateId >= 73 && !this.isNewModStand();
	}

	// Token: 0x0600079E RID: 1950 RVA: 0x0000711A File Offset: 0x0000531A
	private bool isNewModStand()
	{
		return this.templateId == 76;
	}

	// Token: 0x0600079F RID: 1951 RVA: 0x0006AAE4 File Offset: 0x00068CE4
	private void updateInjure()
	{
		if (!this.isBusyAttackSomeOne && GameCanvas.gameTick % 4 == 0)
		{
			if (this.isNewModStand())
			{
				this.frame = this.attack1[GameCanvas.gameTick % this.attack1.Length];
			}
			else if (this.isNewMod())
			{
				if (this.frame != 10)
				{
					this.frame = 10;
				}
				else
				{
					this.frame = 11;
				}
			}
			else if (this.isSpecial())
			{
				if (this.frame != 1)
				{
					this.frame = 1;
				}
				else
				{
					this.frame = 15;
				}
			}
			else if (this.frame != 10)
			{
				this.frame = 10;
			}
			else
			{
				this.frame = 11;
			}
		}
		this.timeStatus--;
		if (this.timeStatus <= 0 && (this.isNewModStand() || (this.isNewMod() && this.frame == 11) || (this.isSpecial() && this.frame == 15) || (this.templateId < 58 && this.frame == 11)))
		{
			if ((this.injureBy != null && this.injureThenDie) || this.hp == 0)
			{
				this.status = 1;
				this.p2 = this.injureBy.cdir << 1;
				this.p1 = -3;
				this.p3 = 0;
			}
			else
			{
				this.status = 5;
				if (this.injureBy != null)
				{
					this.dir = -this.injureBy.cdir;
					if (Res.abs(this.x - this.injureBy.cx) < 24)
					{
						this.status = 2;
					}
				}
				this.p1 = (this.p2 = (this.p3 = 0));
				this.timeStatus = 0;
			}
			this.injureBy = null;
			return;
		}
		if ((int)Mob.arrMobTemplate[this.templateId].type != 0 && this.injureBy != null)
		{
			int num = -this.injureBy.cdir << 1;
			if (this.x > this.xFirst - (int)Mob.arrMobTemplate[this.templateId].rangeMove && this.x < this.xFirst + (int)Mob.arrMobTemplate[this.templateId].rangeMove)
			{
				this.x -= num;
			}
		}
	}

	// Token: 0x060007A0 RID: 1952 RVA: 0x0006AD70 File Offset: 0x00068F70
	private void updateMobStandWait()
	{
		this.checkFrameTick(this.stand);
		switch (Mob.arrMobTemplate[this.templateId].type)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			this.p1++;
			if (this.p1 > 10 + this.mobId % 10 && (this.cFocus == null || Res.abs(this.cFocus.cx - this.x) > 80) && (this.mobToAttack == null || Res.abs(this.mobToAttack.x - this.x) > 80))
			{
				this.status = 5;
			}
			break;
		case 4:
		case 5:
			this.p1++;
			if (this.p1 > this.mobId % 3 && (this.cFocus == null || Res.abs(this.cFocus.cx - this.x) > 80) && (this.mobToAttack == null || Res.abs(this.mobToAttack.x - this.x) > 80))
			{
				this.status = 5;
			}
			break;
		}
		if (this.cFocus != null && GameCanvas.gameTick % (10 + this.p1 % 20) == 0)
		{
			if (this.cFocus.cx > this.x)
			{
				this.dir = 1;
			}
			else
			{
				this.dir = -1;
			}
		}
		else if (this.mobToAttack != null && GameCanvas.gameTick % (10 + this.p1 % 20) == 0)
		{
			if (this.mobToAttack.x > this.x)
			{
				this.dir = 1;
			}
			else
			{
				this.dir = -1;
			}
		}
		if (this.forceWait > 0)
		{
			this.forceWait--;
			this.status = 2;
		}
	}

	// Token: 0x060007A1 RID: 1953 RVA: 0x0006AF7C File Offset: 0x0006917C
	public void updateMobAttack()
	{
		int[] array = (this.p3 != 0) ? this.attack2 : this.attack1;
		if (this.tick < array.Length)
		{
			this.checkFrameTick(array);
			if (this.x >= GameScr.cmx && this.x <= GameScr.cmx + GameCanvas.w && this.p3 == 0 && GameCanvas.gameTick % 2 == 0)
			{
				SoundMn.gI().charPunch(false, 0.05f);
			}
		}
		if (this.p1 == 0)
		{
			int num = (this.cFocus == null) ? this.mobToAttack.x : this.cFocus.cx;
			int num2 = (this.cFocus == null) ? this.mobToAttack.y : this.cFocus.cy;
			if (!this.isNewMod())
			{
				if (this.x > this.xFirst + (int)Mob.arrMobTemplate[this.templateId].rangeMove)
				{
					this.p1 = 1;
				}
				if (this.x < this.xFirst - (int)Mob.arrMobTemplate[this.templateId].rangeMove)
				{
					this.p1 = 1;
				}
			}
			if (((int)Mob.arrMobTemplate[this.templateId].type == 4 || (int)Mob.arrMobTemplate[this.templateId].type == 5) && !this.isDontMove)
			{
				this.y += (num2 - this.y) / 20;
			}
			this.p2++;
			if (this.p2 > array.Length - 1 || this.p1 == 1)
			{
				this.p1 = 1;
				if (this.p3 == 0)
				{
					if (this.cFocus != null)
					{
						this.cFocus.doInjure(this.dame, this.dameMp, false, true);
					}
					else
					{
						this.mobToAttack.setInjure();
					}
					this.isBusyAttackSomeOne = false;
				}
				else
				{
					if (this.cFocus != null)
					{
						MonsterDart.addMonsterDart(this.x + this.dir * this.w, this.y, this.checkIsBoss(), this.dame, this.dameMp, this.cFocus, (int)this.getTemplate().dartType);
					}
					else
					{
						global::Char @char = new global::Char();
						@char.cx = this.mobToAttack.x;
						@char.cy = this.mobToAttack.y;
						@char.charID = -100;
						MonsterDart.addMonsterDart(this.x + this.dir * this.w, this.y, this.checkIsBoss(), this.dame, this.dameMp, @char, (int)this.getTemplate().dartType);
					}
					this.isBusyAttackSomeOne = false;
				}
			}
			this.dir = ((this.x >= num) ? -1 : 1);
		}
		else if (this.p1 == 1)
		{
			if ((int)Mob.arrMobTemplate[this.templateId].type != 0 && !this.isDontMove && !this.isIce && !this.isWind)
			{
				this.x += (this.xFirst - this.x) / 4;
				this.y += (this.yFirst - this.y) / 4;
			}
			if (Res.abs(this.xFirst - this.x) < 5 && Res.abs(this.yFirst - this.y) < 5 && this.tick == array.Length)
			{
				this.status = 2;
				this.p1 = 0;
				this.p2 = 0;
				this.tick = 0;
			}
		}
	}

	// Token: 0x060007A2 RID: 1954 RVA: 0x0006B354 File Offset: 0x00069554
	public void updateMobWalk()
	{
		int num = 0;
		try
		{
			if (this.injureThenDie)
			{
				this.status = 1;
				this.p2 = this.injureBy.cdir << 3;
				this.p1 = -5;
				this.p3 = 0;
			}
			num = 1;
			if (!this.isIce)
			{
				if (this.isDontMove || this.isWind)
				{
					this.checkFrameTick(this.stand);
				}
				else
				{
					switch (Mob.arrMobTemplate[this.templateId].type)
					{
					case 0:
						if (this.isNewModStand())
						{
							this.frame = this.stand[GameCanvas.gameTick % this.stand.Length];
						}
						else
						{
							this.frame = 0;
						}
						num = 2;
						break;
					case 1:
					case 2:
					case 3:
					{
						num = 3;
						sbyte b = Mob.arrMobTemplate[this.templateId].speed;
						if ((int)b == 1)
						{
							if (GameCanvas.gameTick % 2 == 1)
							{
								break;
							}
						}
						else if ((int)b > 2)
						{
							b = (sbyte)((int)b + (int)((sbyte)(this.mobId % 2)));
						}
						else if (GameCanvas.gameTick % 2 == 1)
						{
							b = (sbyte)((int)b - 1);
						}
						this.x += (int)b * this.dir;
						if (this.x > this.xFirst + (int)Mob.arrMobTemplate[this.templateId].rangeMove)
						{
							this.dir = -1;
						}
						else if (this.x < this.xFirst - (int)Mob.arrMobTemplate[this.templateId].rangeMove)
						{
							this.dir = 1;
						}
						if (Res.abs(this.x - global::Char.myCharz().cx) < 40 && Res.abs(this.x - this.xFirst) < (int)Mob.arrMobTemplate[this.templateId].rangeMove)
						{
							this.dir = ((this.x <= global::Char.myCharz().cx) ? 1 : -1);
							if (Res.abs(this.x - global::Char.myCharz().cx) < 20)
							{
								this.x -= this.dir * 10;
							}
							this.status = 2;
							this.forceWait = 20;
						}
						this.checkFrameTick((this.w <= 30) ? this.moveFast : this.move);
						break;
					}
					case 4:
					{
						num = 4;
						sbyte b2 = Mob.arrMobTemplate[this.templateId].speed;
						b2 = (sbyte)((int)b2 + (int)((sbyte)(this.mobId % 2)));
						this.x += (int)b2 * this.dir;
						if (GameCanvas.gameTick % 10 > 2)
						{
							this.y += (int)b2 * this.dirV;
						}
						b2 = (sbyte)((int)b2 + (int)((sbyte)((GameCanvas.gameTick + this.mobId) % 2)));
						if (this.x > this.xFirst + (int)Mob.arrMobTemplate[this.templateId].rangeMove)
						{
							this.dir = -1;
							this.status = 2;
							this.forceWait = GameCanvas.gameTick % 20 + 20;
							this.p1 = 0;
						}
						else if (this.x < this.xFirst - (int)Mob.arrMobTemplate[this.templateId].rangeMove)
						{
							this.dir = 1;
							this.status = 2;
							this.forceWait = GameCanvas.gameTick % 20 + 20;
							this.p1 = 0;
						}
						if (this.y > this.yFirst + 24)
						{
							this.dirV = -1;
						}
						else if (this.y < this.yFirst - (20 + GameCanvas.gameTick % 10))
						{
							this.dirV = 1;
						}
						this.checkFrameTick(this.move);
						break;
					}
					case 5:
					{
						num = 5;
						sbyte b3 = Mob.arrMobTemplate[this.templateId].speed;
						b3 = (sbyte)((int)b3 + (int)((sbyte)(this.mobId % 2)));
						this.x += (int)b3 * this.dir;
						b3 = (sbyte)((int)b3 + (int)((sbyte)((GameCanvas.gameTick + this.mobId) % 2)));
						if (GameCanvas.gameTick % 10 > 2)
						{
							this.y += (int)b3 * this.dirV;
						}
						if (this.x > this.xFirst + (int)Mob.arrMobTemplate[this.templateId].rangeMove)
						{
							this.dir = -1;
							this.status = 2;
							this.forceWait = GameCanvas.gameTick % 20 + 20;
							this.p1 = 0;
						}
						else if (this.x < this.xFirst - (int)Mob.arrMobTemplate[this.templateId].rangeMove)
						{
							this.dir = 1;
							this.status = 2;
							this.forceWait = GameCanvas.gameTick % 20 + 20;
							this.p1 = 0;
						}
						if (this.y > this.yFirst + 24)
						{
							this.dirV = -1;
						}
						else if (this.y < this.yFirst - (20 + GameCanvas.gameTick % 10))
						{
							this.dirV = 1;
						}
						if (TileMap.tileTypeAt(this.x, this.y, 2))
						{
							if (GameCanvas.gameTick % 10 > 5)
							{
								this.y = TileMap.tileYofPixel(this.y);
								this.status = 4;
								this.p1 = 0;
								this.dirV = -1;
							}
							else
							{
								this.dirV = -1;
							}
						}
						break;
					}
					}
				}
			}
		}
		catch (Exception ex)
		{
			Cout.println("lineee: " + num);
		}
	}

	// Token: 0x060007A3 RID: 1955 RVA: 0x0000712C File Offset: 0x0000532C
	public MobTemplate getTemplate()
	{
		return Mob.arrMobTemplate[this.templateId];
	}

	// Token: 0x060007A4 RID: 1956 RVA: 0x0006B934 File Offset: 0x00069B34
	public bool isPaint()
	{
		return this.x >= GameScr.cmx && this.x <= GameScr.cmx + GameScr.gW && this.y >= GameScr.cmy && this.y <= GameScr.cmy + GameScr.gH + 30 && Mob.arrMobTemplate[this.templateId] != null && Mob.arrMobTemplate[this.templateId].data != null && Mob.arrMobTemplate[this.templateId].data.img != null && this.status != 0;
	}

	// Token: 0x060007A5 RID: 1957 RVA: 0x0000713A File Offset: 0x0000533A
	public bool isUpdate()
	{
		return Mob.arrMobTemplate[this.templateId] != null && Mob.arrMobTemplate[this.templateId].data != null && this.status != 0;
	}

	// Token: 0x060007A6 RID: 1958 RVA: 0x0000618A File Offset: 0x0000438A
	public bool checkIsBoss()
	{
		return this.isBoss || (int)this.levelBoss > 0;
	}

	// Token: 0x060007A7 RID: 1959 RVA: 0x0006B9F0 File Offset: 0x00069BF0
	public virtual void paint(mGraphics g)
	{
		if (this.isShadown && this.status != 0)
		{
			this.paintShadow(g);
		}
		if (!this.isPaint())
		{
			return;
		}
		if (this.status == 1 && this.p3 > 0 && GameCanvas.gameTick % 3 == 0)
		{
			return;
		}
		g.translate(0, GameCanvas.transY);
		if (!this.changBody)
		{
			Mob.arrMobTemplate[this.templateId].data.paintFrame(g, this.frame, this.x, this.y + this.fy, (this.dir != 1) ? 1 : 0, 2);
		}
		else
		{
			SmallImage.drawSmallImage(g, (int)this.smallBody, this.x, this.y + this.fy - 14, 0, 3);
		}
		g.translate(0, -GameCanvas.transY);
		if (global::Char.myCharz().mobFocus != null && global::Char.myCharz().mobFocus.Equals(this) && this.status != 1)
		{
			int num = (int)((long)this.hp * 100L / (long)this.maxHp) / 10 - 1;
			if (num < 0)
			{
				num = 0;
			}
			if (num > 9)
			{
				num = 9;
			}
			g.drawRegion(Mob.imgHP, 0, 6 * (9 - num), 9, 6, 0, this.x, this.y - this.h - 10, 3);
		}
	}

	// Token: 0x060007A8 RID: 1960 RVA: 0x000061A7 File Offset: 0x000043A7
	public int getHPColor()
	{
		return 16711680;
	}

	// Token: 0x060007A9 RID: 1961 RVA: 0x0006BB68 File Offset: 0x00069D68
	public void startDie()
	{
		this.hp = 0;
		this.injureThenDie = true;
		this.hp = 0;
		this.status = 1;
		Res.outz("MOB DIEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEe");
		this.p1 = -3;
		this.p2 = -this.dir;
		this.p3 = 0;
	}

	// Token: 0x060007AA RID: 1962 RVA: 0x0006BBB8 File Offset: 0x00069DB8
	public void attackOtherMob(Mob mobToAttack)
	{
		this.mobToAttack = mobToAttack;
		this.isBusyAttackSomeOne = true;
		this.cFocus = null;
		this.p1 = 0;
		this.p2 = 0;
		this.status = 3;
		this.tick = 0;
		this.dir = ((mobToAttack.x <= this.x) ? -1 : 1);
		int num = mobToAttack.x;
		int num2 = mobToAttack.y;
		if (Res.abs(num - this.x) < this.w * 2 && Res.abs(num2 - this.y) < this.h * 2)
		{
			if (this.x < num)
			{
				this.x = num - this.w;
			}
			else
			{
				this.x = num + this.w;
			}
			this.p3 = 0;
		}
		else
		{
			this.p3 = 1;
		}
	}

	// Token: 0x060007AB RID: 1963 RVA: 0x000061E8 File Offset: 0x000043E8
	public int getX()
	{
		return this.x;
	}

	// Token: 0x060007AC RID: 1964 RVA: 0x00007175 File Offset: 0x00005375
	public int getY()
	{
		return this.y;
	}

	// Token: 0x060007AD RID: 1965 RVA: 0x0000717D File Offset: 0x0000537D
	public int getH()
	{
		return this.h;
	}

	// Token: 0x060007AE RID: 1966 RVA: 0x00007185 File Offset: 0x00005385
	public int getW()
	{
		return this.w;
	}

	// Token: 0x060007AF RID: 1967 RVA: 0x0006BC98 File Offset: 0x00069E98
	public void stopMoving()
	{
		if (this.status == 5)
		{
			this.status = 2;
			this.p1 = (this.p2 = (this.p3 = 0));
			this.forceWait = 50;
		}
	}

	// Token: 0x060007B0 RID: 1968 RVA: 0x000061FF File Offset: 0x000043FF
	public bool isInvisible()
	{
		return this.status == 0 || this.status == 1;
	}

	// Token: 0x060007B1 RID: 1969 RVA: 0x00006218 File Offset: 0x00004418
	public void removeHoldEff()
	{
		if (this.holdEffID != 0)
		{
			this.holdEffID = 0;
		}
	}

	// Token: 0x060007B2 RID: 1970 RVA: 0x0000718D File Offset: 0x0000538D
	public void removeBlindEff()
	{
		this.blindEff = false;
	}

	// Token: 0x060007B3 RID: 1971 RVA: 0x00007196 File Offset: 0x00005396
	public void removeSleepEff()
	{
		this.sleepEff = false;
	}

	// Token: 0x04000E2D RID: 3629
	public const sbyte TYPE_DUNG = 0;

	// Token: 0x04000E2E RID: 3630
	public const sbyte TYPE_DI = 1;

	// Token: 0x04000E2F RID: 3631
	public const sbyte TYPE_NHAY = 2;

	// Token: 0x04000E30 RID: 3632
	public const sbyte TYPE_LET = 3;

	// Token: 0x04000E31 RID: 3633
	public const sbyte TYPE_BAY = 4;

	// Token: 0x04000E32 RID: 3634
	public const sbyte TYPE_BAY_DAU = 5;

	// Token: 0x04000E33 RID: 3635
	public static MobTemplate[] arrMobTemplate;

	// Token: 0x04000E34 RID: 3636
	public const sbyte MA_INHELL = 0;

	// Token: 0x04000E35 RID: 3637
	public const sbyte MA_DEADFLY = 1;

	// Token: 0x04000E36 RID: 3638
	public const sbyte MA_STANDWAIT = 2;

	// Token: 0x04000E37 RID: 3639
	public const sbyte MA_ATTACK = 3;

	// Token: 0x04000E38 RID: 3640
	public const sbyte MA_STANDFLY = 4;

	// Token: 0x04000E39 RID: 3641
	public const sbyte MA_WALK = 5;

	// Token: 0x04000E3A RID: 3642
	public const sbyte MA_FALL = 6;

	// Token: 0x04000E3B RID: 3643
	public const sbyte MA_INJURE = 7;

	// Token: 0x04000E3C RID: 3644
	public bool changBody;

	// Token: 0x04000E3D RID: 3645
	public short smallBody;

	// Token: 0x04000E3E RID: 3646
	public bool isHintFocus;

	// Token: 0x04000E3F RID: 3647
	public string flystring;

	// Token: 0x04000E40 RID: 3648
	public int flyx;

	// Token: 0x04000E41 RID: 3649
	public int flyy;

	// Token: 0x04000E42 RID: 3650
	public int flyIndex;

	// Token: 0x04000E43 RID: 3651
	public bool isFreez;

	// Token: 0x04000E44 RID: 3652
	public int seconds;

	// Token: 0x04000E45 RID: 3653
	public long last;

	// Token: 0x04000E46 RID: 3654
	public long cur;

	// Token: 0x04000E47 RID: 3655
	public int holdEffID;

	// Token: 0x04000E48 RID: 3656
	public int hp;

	// Token: 0x04000E49 RID: 3657
	public int maxHp;

	// Token: 0x04000E4A RID: 3658
	public int x;

	// Token: 0x04000E4B RID: 3659
	public int y;

	// Token: 0x04000E4C RID: 3660
	public int dir = 1;

	// Token: 0x04000E4D RID: 3661
	public int dirV = 1;

	// Token: 0x04000E4E RID: 3662
	public int status;

	// Token: 0x04000E4F RID: 3663
	public int p1;

	// Token: 0x04000E50 RID: 3664
	public int p2;

	// Token: 0x04000E51 RID: 3665
	public int p3;

	// Token: 0x04000E52 RID: 3666
	public int xFirst;

	// Token: 0x04000E53 RID: 3667
	public int yFirst;

	// Token: 0x04000E54 RID: 3668
	public int vy;

	// Token: 0x04000E55 RID: 3669
	public int exp;

	// Token: 0x04000E56 RID: 3670
	public int w;

	// Token: 0x04000E57 RID: 3671
	public int h;

	// Token: 0x04000E58 RID: 3672
	public int hpInjure;

	// Token: 0x04000E59 RID: 3673
	public int charIndex;

	// Token: 0x04000E5A RID: 3674
	public int timeStatus;

	// Token: 0x04000E5B RID: 3675
	public int mobId;

	// Token: 0x04000E5C RID: 3676
	public bool isx;

	// Token: 0x04000E5D RID: 3677
	public bool isy;

	// Token: 0x04000E5E RID: 3678
	public bool isDisable;

	// Token: 0x04000E5F RID: 3679
	public bool isDontMove;

	// Token: 0x04000E60 RID: 3680
	public bool isFire;

	// Token: 0x04000E61 RID: 3681
	public bool isIce;

	// Token: 0x04000E62 RID: 3682
	public bool isWind;

	// Token: 0x04000E63 RID: 3683
	public bool isDie;

	// Token: 0x04000E64 RID: 3684
	public MyVector vMobMove = new MyVector();

	// Token: 0x04000E65 RID: 3685
	public bool isGo;

	// Token: 0x04000E66 RID: 3686
	public string mobName;

	// Token: 0x04000E67 RID: 3687
	public int templateId;

	// Token: 0x04000E68 RID: 3688
	public short pointx;

	// Token: 0x04000E69 RID: 3689
	public short pointy;

	// Token: 0x04000E6A RID: 3690
	public global::Char cFocus;

	// Token: 0x04000E6B RID: 3691
	public int dame;

	// Token: 0x04000E6C RID: 3692
	public int dameMp;

	// Token: 0x04000E6D RID: 3693
	public int sys;

	// Token: 0x04000E6E RID: 3694
	public sbyte levelBoss;

	// Token: 0x04000E6F RID: 3695
	public sbyte level;

	// Token: 0x04000E70 RID: 3696
	public bool isBoss;

	// Token: 0x04000E71 RID: 3697
	public bool isMobMe;

	// Token: 0x04000E72 RID: 3698
	public static MyVector lastMob = new MyVector();

	// Token: 0x04000E73 RID: 3699
	public static MyVector newMob = new MyVector();

	// Token: 0x04000E74 RID: 3700
	public int xSd;

	// Token: 0x04000E75 RID: 3701
	public int ySd;

	// Token: 0x04000E76 RID: 3702
	private bool isOutMap;

	// Token: 0x04000E77 RID: 3703
	private int wCount;

	// Token: 0x04000E78 RID: 3704
	public bool isShadown = true;

	// Token: 0x04000E79 RID: 3705
	private int tick;

	// Token: 0x04000E7A RID: 3706
	private int frame;

	// Token: 0x04000E7B RID: 3707
	public static Image imgHP = GameCanvas.loadImage("/mainImage/myTexture2dmobHP.png");

	// Token: 0x04000E7C RID: 3708
	private bool wy;

	// Token: 0x04000E7D RID: 3709
	private int wt;

	// Token: 0x04000E7E RID: 3710
	private int fy;

	// Token: 0x04000E7F RID: 3711
	private int ty;

	// Token: 0x04000E80 RID: 3712
	public int typeSuperEff;

	// Token: 0x04000E81 RID: 3713
	public bool isBusyAttackSomeOne = true;

	// Token: 0x04000E82 RID: 3714
	public int[] stand = new int[]
	{
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		1,
		1,
		1,
		1
	};

	// Token: 0x04000E83 RID: 3715
	public int[] move = new int[]
	{
		1,
		1,
		1,
		1,
		2,
		2,
		2,
		2,
		3,
		3,
		3,
		3,
		2,
		2,
		2
	};

	// Token: 0x04000E84 RID: 3716
	public int[] moveFast = new int[]
	{
		1,
		1,
		2,
		2,
		3,
		3,
		2
	};

	// Token: 0x04000E85 RID: 3717
	public int[] attack1 = new int[]
	{
		4,
		5,
		6
	};

	// Token: 0x04000E86 RID: 3718
	public int[] attack2 = new int[]
	{
		7,
		8,
		9
	};

	// Token: 0x04000E87 RID: 3719
	private sbyte[] cou = new sbyte[]
	{
		-1,
		1
	};

	// Token: 0x04000E88 RID: 3720
	public global::Char injureBy;

	// Token: 0x04000E89 RID: 3721
	public bool injureThenDie;

	// Token: 0x04000E8A RID: 3722
	public Mob mobToAttack;

	// Token: 0x04000E8B RID: 3723
	public int forceWait;

	// Token: 0x04000E8C RID: 3724
	public bool blindEff;

	// Token: 0x04000E8D RID: 3725
	public bool sleepEff;
}
