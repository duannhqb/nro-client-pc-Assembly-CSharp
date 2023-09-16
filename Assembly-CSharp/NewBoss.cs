using System;

// Token: 0x020000B3 RID: 179
public class NewBoss : Mob, IMapObject
{
	// Token: 0x060007C6 RID: 1990 RVA: 0x0006C688 File Offset: 0x0006A888
	public NewBoss(int id, short px, short py, int templateID, int hp, int maxHp, int s)
	{
		this.mobId = id;
		this.x = (this.xFirst = (int)(px + 20));
		this.yFirst = (int)py;
		this.y = (int)py;
		this.xTo = this.x;
		this.yTo = this.y;
		this.maxHp = maxHp;
		this.hp = hp;
		this.templateId = templateID;
		if (Mob.arrMobTemplate[this.templateId].data == null)
		{
			Service.gI().requestModTemplate(this.templateId);
		}
		this.status = 2;
		this.frameArr = null;
	}

	// Token: 0x060007C7 RID: 1991 RVA: 0x000060C5 File Offset: 0x000042C5
	public new void setBody(short id)
	{
		this.changBody = true;
		this.smallBody = id;
	}

	// Token: 0x060007C8 RID: 1992 RVA: 0x000060D5 File Offset: 0x000042D5
	public new void clearBody()
	{
		this.changBody = false;
	}

	// Token: 0x060007C9 RID: 1993 RVA: 0x000418AC File Offset: 0x0003FAAC
	public new static bool isExistNewMob(string id)
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

	// Token: 0x060007CA RID: 1994 RVA: 0x0000728A File Offset: 0x0000548A
	public new void checkFrameTick(int[] array)
	{
		this.tick++;
		if (this.tick > array.Length - 1)
		{
			this.tick = 0;
		}
		this.frame = array[this.tick];
	}

	// Token: 0x060007CB RID: 1995 RVA: 0x0006C8B4 File Offset: 0x0006AAB4
	public void updateShadown()
	{
		int i = 0;
		this.xSd = this.x;
		if (TileMap.tileTypeAt(this.x, this.y, 2))
		{
			this.ySd = this.y;
			return;
		}
		this.ySd = this.y;
		while (i < 30)
		{
			i++;
			this.ySd += 24;
			if (TileMap.tileTypeAt(this.xSd, this.ySd, 2))
			{
				if (this.ySd % 24 != 0)
				{
					this.ySd -= this.ySd % 24;
				}
				break;
			}
		}
	}

	// Token: 0x060007CC RID: 1996 RVA: 0x0006C960 File Offset: 0x0006AB60
	private void paintShadow(mGraphics g)
	{
		int num = (int)TileMap.size;
		if ((TileMap.mapID < 114 || TileMap.mapID > 120) && TileMap.mapID != 127 && TileMap.mapID != 128)
		{
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
		}
		g.drawImage(NewBoss.shadowBig, this.xSd, this.ySd - 5, 3);
		g.setClip(GameScr.cmx, GameScr.cmy - GameCanvas.transY, GameScr.gW, GameScr.gH + 2 * GameCanvas.transY);
	}

	// Token: 0x060007CD RID: 1997 RVA: 0x00003984 File Offset: 0x00001B84
	public new void updateSuperEff()
	{
	}

	// Token: 0x060007CE RID: 1998 RVA: 0x0006CAF4 File Offset: 0x0006ACF4
	public override void update()
	{
		if (this.frameArr == null && Mob.arrMobTemplate[this.templateId].data != null)
		{
			this.GetFrame();
		}
		if (this.frameArr == null)
		{
			return;
		}
		if (!this.isUpdate())
		{
			return;
		}
		this.updateShadown();
		switch (this.status)
		{
		case 0:
		case 1:
			this.updateDead();
			break;
		case 2:
			this.updateMobStandWait();
			break;
		case 3:
			this.updateMobAttack();
			break;
		case 4:
			this.updateMobFly();
			break;
		case 5:
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

	// Token: 0x060007CF RID: 1999 RVA: 0x0006CC1C File Offset: 0x0006AE1C
	private void updateDead()
	{
		this.tick++;
		if (this.tick > this.frameArr[13].Length - 1)
		{
			this.tick = this.frameArr[13].Length - 1;
		}
		this.frame = this.frameArr[13][this.tick];
		if (this.x != this.xTo || this.y != this.yTo)
		{
			this.x += (this.xTo - this.x) / 4;
			this.y += (this.yTo - this.y) / 4;
		}
	}

	// Token: 0x060007D0 RID: 2000 RVA: 0x00003984 File Offset: 0x00001B84
	private void updateMobFly()
	{
	}

	// Token: 0x060007D1 RID: 2001 RVA: 0x0006CCD4 File Offset: 0x0006AED4
	public new void setAttack(global::Char cFocus)
	{
		this.isBusyAttackSomeOne = true;
		this.mobToAttack = null;
		this.cFocus = cFocus;
		this.p1 = 0;
		this.p2 = 0;
		this.status = 3;
		this.tick = 0;
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

	// Token: 0x060007D2 RID: 2002 RVA: 0x00003984 File Offset: 0x00001B84
	private void updateInjure()
	{
	}

	// Token: 0x060007D3 RID: 2003 RVA: 0x0006CD94 File Offset: 0x0006AF94
	private void updateMobStandWait()
	{
		this.checkFrameTick(this.frameArr[0]);
		if (this.x != this.xTo || this.y != this.yTo)
		{
			this.x += (this.xTo - this.x) / 4;
			this.y += (this.yTo - this.y) / 4;
		}
	}

	// Token: 0x060007D4 RID: 2004 RVA: 0x000072BF File Offset: 0x000054BF
	public void setFly()
	{
		this.status = 4;
		this.flyUp = true;
	}

	// Token: 0x060007D5 RID: 2005 RVA: 0x0006CE0C File Offset: 0x0006B00C
	public void setAttack(global::Char[] cAttack, int[] dame, sbyte type, sbyte dir)
	{
		this.charAttack = cAttack;
		this.dameHP = dame;
		this.type = type;
		this.dir = (int)dir;
		this.status = 3;
		if (this.x != this.xTo || this.y != this.yTo)
		{
			this.x += (this.xTo - this.x) / 4;
			this.y += (this.yTo - this.y) / 4;
		}
	}

	// Token: 0x060007D6 RID: 2006 RVA: 0x0006CE98 File Offset: 0x0006B098
	public new void updateMobAttack()
	{
		if (this.tick == this.frameArr[(int)this.type + 1].Length - 1)
		{
			this.status = 2;
		}
		this.checkFrameTick(this.frameArr[(int)this.type + 1]);
		if (this.tick == this.frameArr[15][(int)this.type - 1])
		{
			for (int i = 0; i < this.charAttack.Length; i++)
			{
				this.charAttack[i].doInjure(this.dameHP[i], 0, false, false);
				ServerEffect.addServerEffect(this.frameArr[16][(int)this.type - 1], this.charAttack[i].cx, this.charAttack[i].cy, 1);
			}
		}
	}

	// Token: 0x060007D7 RID: 2007 RVA: 0x0006CF64 File Offset: 0x0006B164
	public new void updateMobWalk()
	{
		this.checkFrameTick(this.frameArr[1]);
		sbyte speed = Mob.arrMobTemplate[this.templateId].speed;
		int num = (int)speed;
		if (Res.abs(this.x - this.xTo) < (int)speed)
		{
			num = Res.abs(this.x - this.xTo);
		}
		this.x += ((this.x >= this.xTo) ? (-num) : num);
		this.y = this.yTo;
		if (this.x < this.xTo)
		{
			this.dir = 1;
		}
		else if (this.x > this.xTo)
		{
			this.dir = -1;
		}
		if (Res.abs(this.x - this.xTo) <= 1)
		{
			this.x = this.xTo;
			this.status = 2;
		}
	}

	// Token: 0x060007D8 RID: 2008 RVA: 0x00041FF4 File Offset: 0x000401F4
	public new bool isPaint()
	{
		return this.x >= GameScr.cmx && this.x <= GameScr.cmx + GameScr.gW && this.y >= GameScr.cmy && this.y <= GameScr.cmy + GameScr.gH + 30 && this.status != 0;
	}

	// Token: 0x060007D9 RID: 2009 RVA: 0x0000617A File Offset: 0x0000437A
	public new bool isUpdate()
	{
		return this.status != 0;
	}

	// Token: 0x060007DA RID: 2010 RVA: 0x0006D054 File Offset: 0x0006B254
	public override void paint(mGraphics g)
	{
		if (Mob.arrMobTemplate[this.templateId].data == null)
		{
			return;
		}
		if (this.isShadown)
		{
			this.paintShadow(g);
		}
		g.translate(0, GameCanvas.transY);
		Mob.arrMobTemplate[this.templateId].data.paintFrame(g, this.frame, this.x, this.y + this.fy, (this.dir != 1) ? 1 : 0, 2);
		g.translate(0, -GameCanvas.transY);
		int num = (int)((long)this.hp * 50L / (long)this.maxHp);
		if (num != 0)
		{
			int num2 = this.y - this.h - 5;
			g.setColor(0);
			g.fillRect(this.x - 27, num2 - 2, 54, 8);
			g.setColor(16711680);
			g.fillRect(this.x - 25, num2, num, 4);
		}
	}

	// Token: 0x060007DB RID: 2011 RVA: 0x000061A7 File Offset: 0x000043A7
	public new int getHPColor()
	{
		return 16711680;
	}

	// Token: 0x060007DC RID: 2012 RVA: 0x000072CF File Offset: 0x000054CF
	public new void startDie()
	{
		this.hp = 0;
		this.injureThenDie = true;
		this.hp = 0;
		this.status = 1;
		this.p1 = -3;
		this.p2 = -this.dir;
		this.p3 = 0;
	}

	// Token: 0x060007DD RID: 2013 RVA: 0x0006D14C File Offset: 0x0006B34C
	public new void attackOtherMob(Mob mobToAttack)
	{
		this.mobToAttack = mobToAttack;
		this.isBusyAttackSomeOne = true;
		this.cFocus = null;
		this.p1 = 0;
		this.p2 = 0;
		this.status = 3;
		this.tick = 0;
		int x = mobToAttack.x;
		int y = mobToAttack.y;
		if (Res.abs(x - this.x) < this.w * 2 && Res.abs(y - this.y) < this.h * 2)
		{
			if (this.x < x)
			{
				this.x = x - this.w;
			}
			else
			{
				this.x = x + this.w;
			}
			this.p3 = 0;
		}
		else
		{
			this.p3 = 1;
		}
	}

	// Token: 0x060007DE RID: 2014 RVA: 0x000061E8 File Offset: 0x000043E8
	public new int getX()
	{
		return this.x;
	}

	// Token: 0x060007DF RID: 2015 RVA: 0x00007175 File Offset: 0x00005375
	public new int getY()
	{
		return this.y;
	}

	// Token: 0x060007E0 RID: 2016 RVA: 0x0000717D File Offset: 0x0000537D
	public new int getH()
	{
		return this.h;
	}

	// Token: 0x060007E1 RID: 2017 RVA: 0x00007185 File Offset: 0x00005385
	public new int getW()
	{
		return this.w;
	}

	// Token: 0x060007E2 RID: 2018 RVA: 0x0006D20C File Offset: 0x0006B40C
	public new void stopMoving()
	{
		if (this.status == 5)
		{
			this.status = 2;
			this.p1 = (this.p2 = (this.p3 = 0));
			this.forceWait = 50;
		}
	}

	// Token: 0x060007E3 RID: 2019 RVA: 0x000061FF File Offset: 0x000043FF
	public new bool isInvisible()
	{
		return this.status == 0 || this.status == 1;
	}

	// Token: 0x060007E4 RID: 2020 RVA: 0x00006218 File Offset: 0x00004418
	public new void removeHoldEff()
	{
		if (this.holdEffID != 0)
		{
			this.holdEffID = 0;
		}
	}

	// Token: 0x060007E5 RID: 2021 RVA: 0x00007309 File Offset: 0x00005509
	public new void removeBlindEff()
	{
		this.blindEff = false;
	}

	// Token: 0x060007E6 RID: 2022 RVA: 0x00007312 File Offset: 0x00005512
	public new void removeSleepEff()
	{
		this.sleepEff = false;
	}

	// Token: 0x060007E7 RID: 2023 RVA: 0x0006D250 File Offset: 0x0006B450
	public new void move(short xMoveTo, short yMoveTo)
	{
		if (yMoveTo != -1)
		{
			if (Res.distance(this.x, this.y, this.xTo, this.yTo) > 100)
			{
				this.x = (int)xMoveTo;
				this.y = (int)yMoveTo;
				this.status = 2;
			}
			else
			{
				this.xTo = (int)xMoveTo;
				this.yTo = (int)yMoveTo;
				this.status = 5;
			}
		}
		else
		{
			this.xTo = (int)xMoveTo;
			this.status = 5;
		}
	}

	// Token: 0x060007E8 RID: 2024 RVA: 0x0006D2CC File Offset: 0x0006B4CC
	public void GetFrame()
	{
		this.frameArr = (int[][])Controller.frameHT_NEWBOSS.get(this.templateId + string.Empty);
		this.w = Mob.arrMobTemplate[this.templateId].data.width;
		this.h = Mob.arrMobTemplate[this.templateId].data.height;
	}

	// Token: 0x060007E9 RID: 2025 RVA: 0x0000731B File Offset: 0x0000551B
	public void setDie()
	{
		this.status = 0;
	}

	// Token: 0x04000EA0 RID: 3744
	public static Image shadowBig = mSystem.loadImage("/mainImage/shadowBig.png");

	// Token: 0x04000EA1 RID: 3745
	public int xTo;

	// Token: 0x04000EA2 RID: 3746
	public int yTo;

	// Token: 0x04000EA3 RID: 3747
	public bool haftBody;

	// Token: 0x04000EA4 RID: 3748
	public bool change;

	// Token: 0x04000EA5 RID: 3749
	public new int xSd;

	// Token: 0x04000EA6 RID: 3750
	public new int ySd;

	// Token: 0x04000EA7 RID: 3751
	private int wCount;

	// Token: 0x04000EA8 RID: 3752
	public new bool isShadown = true;

	// Token: 0x04000EA9 RID: 3753
	private int tick;

	// Token: 0x04000EAA RID: 3754
	private int frame;

	// Token: 0x04000EAB RID: 3755
	public new static Image imgHP = mSystem.loadImage("/mainImage/myTexture2dmobHP.png");

	// Token: 0x04000EAC RID: 3756
	private bool wy;

	// Token: 0x04000EAD RID: 3757
	private int wt;

	// Token: 0x04000EAE RID: 3758
	private int fy;

	// Token: 0x04000EAF RID: 3759
	private int ty;

	// Token: 0x04000EB0 RID: 3760
	public new int typeSuperEff;

	// Token: 0x04000EB1 RID: 3761
	private global::Char focus;

	// Token: 0x04000EB2 RID: 3762
	private bool flyUp;

	// Token: 0x04000EB3 RID: 3763
	private bool flyDown;

	// Token: 0x04000EB4 RID: 3764
	private int dy;

	// Token: 0x04000EB5 RID: 3765
	public bool changePos;

	// Token: 0x04000EB6 RID: 3766
	private int tShock;

	// Token: 0x04000EB7 RID: 3767
	public new bool isBusyAttackSomeOne = true;

	// Token: 0x04000EB8 RID: 3768
	private int tA;

	// Token: 0x04000EB9 RID: 3769
	private global::Char[] charAttack;

	// Token: 0x04000EBA RID: 3770
	private int[] dameHP;

	// Token: 0x04000EBB RID: 3771
	private sbyte type;

	// Token: 0x04000EBC RID: 3772
	private int ff;

	// Token: 0x04000EBD RID: 3773
	private sbyte[] cou = new sbyte[]
	{
		-1,
		1
	};

	// Token: 0x04000EBE RID: 3774
	public new global::Char injureBy;

	// Token: 0x04000EBF RID: 3775
	public new bool injureThenDie;

	// Token: 0x04000EC0 RID: 3776
	public new Mob mobToAttack;

	// Token: 0x04000EC1 RID: 3777
	public new int forceWait;

	// Token: 0x04000EC2 RID: 3778
	public new bool blindEff;

	// Token: 0x04000EC3 RID: 3779
	public new bool sleepEff;

	// Token: 0x04000EC4 RID: 3780
	private int[][] frameArr = new int[][]
	{
		new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		}
	};

	// Token: 0x04000EC5 RID: 3781
	public new const sbyte stand = 0;

	// Token: 0x04000EC6 RID: 3782
	public const sbyte moveFra = 1;

	// Token: 0x04000EC7 RID: 3783
	public new const sbyte attack1 = 2;

	// Token: 0x04000EC8 RID: 3784
	public new const sbyte attack2 = 3;

	// Token: 0x04000EC9 RID: 3785
	public const sbyte attack3 = 4;

	// Token: 0x04000ECA RID: 3786
	public const sbyte attack4 = 5;

	// Token: 0x04000ECB RID: 3787
	public const sbyte attack5 = 6;

	// Token: 0x04000ECC RID: 3788
	public const sbyte attack6 = 7;

	// Token: 0x04000ECD RID: 3789
	public const sbyte attack7 = 8;

	// Token: 0x04000ECE RID: 3790
	public const sbyte attack8 = 9;

	// Token: 0x04000ECF RID: 3791
	public const sbyte attack9 = 10;

	// Token: 0x04000ED0 RID: 3792
	public const sbyte attack10 = 11;

	// Token: 0x04000ED1 RID: 3793
	public const sbyte hurt = 12;

	// Token: 0x04000ED2 RID: 3794
	public const sbyte die = 13;

	// Token: 0x04000ED3 RID: 3795
	public const sbyte fly = 14;

	// Token: 0x04000ED4 RID: 3796
	public const sbyte adddame = 15;

	// Token: 0x04000ED5 RID: 3797
	public const sbyte typeEff = 16;
}
