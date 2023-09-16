using System;

// Token: 0x0200009A RID: 154
public class BigBoss2 : Mob, IMapObject
{
	// Token: 0x06000570 RID: 1392 RVA: 0x000433F8 File Offset: 0x000415F8
	public BigBoss2(int id, short px, short py, int templateID, int hp, int maxHp, int s)
	{
		if (BigBoss2.shadowBig == null)
		{
			BigBoss2.shadowBig = GameCanvas.loadImage("/mainImage/shadowBig.png");
		}
		this.mobId = id;
		this.xTo = (this.x = (int)(px + 20));
		this.y = (int)py;
		this.yTo = (int)py;
		this.yFirst = (int)py;
		this.hp = hp;
		this.maxHp = maxHp;
		this.templateId = templateID;
		this.getDataB();
		this.status = 2;
	}

	// Token: 0x06000571 RID: 1393 RVA: 0x0004355C File Offset: 0x0004175C
	public void getDataB()
	{
		BigBoss2.data = null;
		BigBoss2.data = new EffectData();
		string patch = string.Concat(new object[]
		{
			"/x",
			mGraphics.zoomLevel,
			"/effectdata/",
			109,
			"/data"
		});
		try
		{
			BigBoss2.data.readData2(patch);
			BigBoss2.data.img = GameCanvas.loadImage("/effectdata/" + 109 + "/img.png");
		}
		catch (Exception ex)
		{
			Service.gI().requestModTemplate(this.templateId);
		}
		this.w = BigBoss2.data.width;
		this.h = BigBoss2.data.height;
	}

	// Token: 0x06000572 RID: 1394 RVA: 0x000060C5 File Offset: 0x000042C5
	public new void setBody(short id)
	{
		this.changBody = true;
		this.smallBody = id;
	}

	// Token: 0x06000573 RID: 1395 RVA: 0x000060D5 File Offset: 0x000042D5
	public new void clearBody()
	{
		this.changBody = false;
	}

	// Token: 0x06000574 RID: 1396 RVA: 0x000418AC File Offset: 0x0003FAAC
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

	// Token: 0x06000575 RID: 1397 RVA: 0x00006381 File Offset: 0x00004581
	public new void checkFrameTick(int[] array)
	{
		this.tick++;
		if (this.tick > array.Length - 1)
		{
			this.tick = 0;
		}
		this.frame = array[this.tick];
	}

	// Token: 0x06000576 RID: 1398 RVA: 0x00043630 File Offset: 0x00041830
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

	// Token: 0x06000577 RID: 1399 RVA: 0x00043768 File Offset: 0x00041968
	private void paintShadow(mGraphics g)
	{
		int num = (int)TileMap.size;
		g.drawImage(BigBoss2.shadowBig, this.xSd, this.yFirst, 3);
		g.setClip(GameScr.cmx, GameScr.cmy - GameCanvas.transY, GameScr.gW, GameScr.gH + 2 * GameCanvas.transY);
	}

	// Token: 0x06000578 RID: 1400 RVA: 0x00003984 File Offset: 0x00001B84
	public new void updateSuperEff()
	{
	}

	// Token: 0x06000579 RID: 1401 RVA: 0x000437BC File Offset: 0x000419BC
	public override void update()
	{
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
			this.timeStatus = 0;
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

	// Token: 0x0600057A RID: 1402 RVA: 0x000438B8 File Offset: 0x00041AB8
	private void updateDead()
	{
		this.checkFrameTick(this.stand);
		if (GameCanvas.gameTick % 5 == 0)
		{
			ServerEffect.addServerEffect(167, Res.random(this.x - this.getW() / 2, this.x + this.getW() / 2), Res.random(this.getY() + this.getH() / 2, this.getY() + this.getH()), 1);
		}
		if (this.x != this.xTo || this.y != this.yTo)
		{
			this.x += (this.xTo - this.x) / 4;
			this.y += (this.yTo - this.y) / 4;
		}
	}

	// Token: 0x0600057B RID: 1403 RVA: 0x00043988 File Offset: 0x00041B88
	private void updateMobFly()
	{
		if (this.flyUp)
		{
			this.dy++;
			this.y -= this.dy;
			this.checkFrameTick(this.fly);
			if (this.y <= -500)
			{
				this.flyUp = false;
				this.flyDown = true;
				this.dy = 0;
			}
		}
		if (this.flyDown)
		{
			this.x = this.xTo;
			this.dy += 2;
			this.y += this.dy;
			this.checkFrameTick(this.hitground);
			if (this.y > this.yFirst)
			{
				this.y = this.yFirst;
				this.flyDown = false;
				this.dy = 0;
				this.status = 2;
				GameScr.shock_scr = 10;
				this.shock = true;
			}
		}
	}

	// Token: 0x0600057C RID: 1404 RVA: 0x00003984 File Offset: 0x00001B84
	public new void setInjure()
	{
	}

	// Token: 0x0600057D RID: 1405 RVA: 0x00043A78 File Offset: 0x00041C78
	public new void setAttack(global::Char cFocus)
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

	// Token: 0x0600057E RID: 1406 RVA: 0x00006113 File Offset: 0x00004313
	private bool isSpecial()
	{
		return (this.templateId >= 58 && this.templateId <= 65) || this.templateId == 67 || this.templateId == 68;
	}

	// Token: 0x0600057F RID: 1407 RVA: 0x00003984 File Offset: 0x00001B84
	private void updateInjure()
	{
	}

	// Token: 0x06000580 RID: 1408 RVA: 0x00043B58 File Offset: 0x00041D58
	private void updateMobStandWait()
	{
		this.checkFrameTick(this.stand);
		if (this.x != this.xTo || this.y != this.yTo)
		{
			this.x += (this.xTo - this.x) / 4;
			this.y += (this.yTo - this.y) / 4;
		}
	}

	// Token: 0x06000581 RID: 1409 RVA: 0x000063B6 File Offset: 0x000045B6
	public void setFly()
	{
		this.status = 4;
		this.flyUp = true;
	}

	// Token: 0x06000582 RID: 1410 RVA: 0x000063C6 File Offset: 0x000045C6
	public void setAttack(global::Char[] cAttack, int[] dame, sbyte type)
	{
		this.status = 3;
		this.charAttack = cAttack;
		this.dameHP = dame;
		this.type = type;
		this.tick = 0;
	}

	// Token: 0x06000583 RID: 1411 RVA: 0x00043BCC File Offset: 0x00041DCC
	public new void updateMobAttack()
	{
		if ((int)this.type == 0)
		{
			if (this.tick == this.attack1.Length - 1)
			{
				this.status = 2;
			}
			this.dir = ((this.x >= this.charAttack[0].cx) ? -1 : 1);
			this.checkFrameTick(this.attack1);
			this.x += (this.charAttack[0].cx - this.x) / 4;
			this.y += (this.charAttack[0].cy - this.y) / 4;
			this.xTo = this.x;
			if (this.tick == 8)
			{
				for (int i = 0; i < this.charAttack.Length; i++)
				{
					this.charAttack[i].doInjure(this.dameHP[i], 0, false, false);
					ServerEffect.addServerEffect(102, this.charAttack[i].cx, this.charAttack[i].cy, 1);
				}
			}
		}
		if ((int)this.type == 1)
		{
			if (this.tick == this.attack2.Length - 1)
			{
				this.status = 2;
			}
			this.dir = ((this.x >= this.charAttack[0].cx) ? -1 : 1);
			this.checkFrameTick(this.attack2);
			if (this.tick == 8)
			{
				for (int j = 0; j < this.charAttack.Length; j++)
				{
					MonsterDart.addMonsterDart(this.x + ((this.dir != 1) ? -45 : 45), this.y - 25, true, this.dameHP[j], 0, this.charAttack[j], 24);
				}
			}
		}
		if ((int)this.type == 2)
		{
			if (this.tick == this.fly.Length - 1)
			{
				this.status = 2;
			}
			this.dir = ((this.x >= this.charAttack[0].cx) ? -1 : 1);
			this.checkFrameTick(this.fly);
			this.x += (this.charAttack[0].cx - this.x) / 4;
			this.xTo = this.x;
			this.yTo = this.y;
			if (this.tick == 12)
			{
				for (int k = 0; k < this.charAttack.Length; k++)
				{
					this.charAttack[k].doInjure(this.dameHP[k], 0, false, false);
					ServerEffect.addServerEffect(102, this.charAttack[k].cx, this.charAttack[k].cy, 1);
				}
			}
		}
	}

	// Token: 0x06000584 RID: 1412 RVA: 0x00003984 File Offset: 0x00001B84
	public new void updateMobWalk()
	{
	}

	// Token: 0x06000585 RID: 1413 RVA: 0x00041FF4 File Offset: 0x000401F4
	public new bool isPaint()
	{
		return this.x >= GameScr.cmx && this.x <= GameScr.cmx + GameScr.gW && this.y >= GameScr.cmy && this.y <= GameScr.cmy + GameScr.gH + 30 && this.status != 0;
	}

	// Token: 0x06000586 RID: 1414 RVA: 0x0000617A File Offset: 0x0000437A
	public new bool isUpdate()
	{
		return this.status != 0;
	}

	// Token: 0x06000587 RID: 1415 RVA: 0x0000618A File Offset: 0x0000438A
	public new bool checkIsBoss()
	{
		return this.isBoss || (int)this.levelBoss > 0;
	}

	// Token: 0x06000588 RID: 1416 RVA: 0x00043E98 File Offset: 0x00042098
	public override void paint(mGraphics g)
	{
		if (BigBoss2.data == null)
		{
			return;
		}
		if (this.isShadown && this.status != 0)
		{
			this.paintShadow(g);
		}
		g.translate(0, GameCanvas.transY);
		BigBoss2.data.paintFrame(g, this.frame, this.x, this.y + this.fy, (this.dir != 1) ? 1 : 0, 2);
		g.translate(0, -GameCanvas.transY);
		int num = (int)((long)this.hp * 50L / (long)this.maxHp);
		if (num != 0)
		{
			g.setColor(0);
			g.fillRect(this.x - 27, this.y - 112, 54, 8);
			g.setColor(16711680);
			g.setClip(this.x - 25, this.y - 110, num, 4);
			g.fillRect(this.x - 25, this.y - 110, 50, 4);
			g.setClip(0, 0, 3000, 3000);
		}
		if (this.shock)
		{
			this.tShock++;
			Effect me = new Effect(((int)this.type != 2) ? 22 : 19, this.x + this.tShock * 50, this.y + 25, 2, 1, -1);
			EffecMn.addEff(me);
			Effect me2 = new Effect(((int)this.type != 2) ? 22 : 19, this.x - this.tShock * 50, this.y + 25, 2, 1, -1);
			EffecMn.addEff(me2);
			if (this.tShock == 50)
			{
				this.tShock = 0;
				this.shock = false;
			}
		}
	}

	// Token: 0x06000589 RID: 1417 RVA: 0x000061A7 File Offset: 0x000043A7
	public new int getHPColor()
	{
		return 16711680;
	}

	// Token: 0x0600058A RID: 1418 RVA: 0x000063EB File Offset: 0x000045EB
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

	// Token: 0x0600058B RID: 1419 RVA: 0x00044060 File Offset: 0x00042260
	public new void attackOtherMob(Mob mobToAttack)
	{
		this.mobToAttack = mobToAttack;
		this.isBusyAttackSomeOne = true;
		this.cFocus = null;
		this.p1 = 0;
		this.p2 = 0;
		this.status = 3;
		this.tick = 0;
		this.dir = ((mobToAttack.x <= this.x) ? -1 : 1);
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

	// Token: 0x0600058C RID: 1420 RVA: 0x000061E8 File Offset: 0x000043E8
	public new int getX()
	{
		return this.x;
	}

	// Token: 0x0600058D RID: 1421 RVA: 0x00006425 File Offset: 0x00004625
	public new int getY()
	{
		return this.y - 50;
	}

	// Token: 0x0600058E RID: 1422 RVA: 0x000061FB File Offset: 0x000043FB
	public new int getH()
	{
		return 40;
	}

	// Token: 0x0600058F RID: 1423 RVA: 0x00006430 File Offset: 0x00004630
	public new int getW()
	{
		return 50;
	}

	// Token: 0x06000590 RID: 1424 RVA: 0x00044140 File Offset: 0x00042340
	public new void stopMoving()
	{
		if (this.status == 5)
		{
			this.status = 2;
			this.p1 = (this.p2 = (this.p3 = 0));
			this.forceWait = 50;
		}
	}

	// Token: 0x06000591 RID: 1425 RVA: 0x000061FF File Offset: 0x000043FF
	public new bool isInvisible()
	{
		return this.status == 0 || this.status == 1;
	}

	// Token: 0x06000592 RID: 1426 RVA: 0x00006218 File Offset: 0x00004418
	public new void removeHoldEff()
	{
		if (this.holdEffID != 0)
		{
			this.holdEffID = 0;
		}
	}

	// Token: 0x06000593 RID: 1427 RVA: 0x00006434 File Offset: 0x00004634
	public new void removeBlindEff()
	{
		this.blindEff = false;
	}

	// Token: 0x06000594 RID: 1428 RVA: 0x0000643D File Offset: 0x0000463D
	public new void removeSleepEff()
	{
		this.sleepEff = false;
	}

	// Token: 0x04000987 RID: 2439
	public static Image shadowBig;

	// Token: 0x04000988 RID: 2440
	public static EffectData data;

	// Token: 0x04000989 RID: 2441
	public int xTo;

	// Token: 0x0400098A RID: 2442
	public int yTo;

	// Token: 0x0400098B RID: 2443
	public bool haftBody;

	// Token: 0x0400098C RID: 2444
	public bool change;

	// Token: 0x0400098D RID: 2445
	private Mob mob1;

	// Token: 0x0400098E RID: 2446
	public new int xSd;

	// Token: 0x0400098F RID: 2447
	public new int ySd;

	// Token: 0x04000990 RID: 2448
	private bool isOutMap;

	// Token: 0x04000991 RID: 2449
	private int wCount;

	// Token: 0x04000992 RID: 2450
	public new bool isShadown = true;

	// Token: 0x04000993 RID: 2451
	private int tick;

	// Token: 0x04000994 RID: 2452
	private int frame;

	// Token: 0x04000995 RID: 2453
	public new static Image imgHP = GameCanvas.loadImage("/mainImage/myTexture2dmobHP.png");

	// Token: 0x04000996 RID: 2454
	private bool wy;

	// Token: 0x04000997 RID: 2455
	private int wt;

	// Token: 0x04000998 RID: 2456
	private int fy;

	// Token: 0x04000999 RID: 2457
	private int ty;

	// Token: 0x0400099A RID: 2458
	public new int typeSuperEff;

	// Token: 0x0400099B RID: 2459
	private global::Char focus;

	// Token: 0x0400099C RID: 2460
	private int timeDead;

	// Token: 0x0400099D RID: 2461
	private bool flyUp;

	// Token: 0x0400099E RID: 2462
	private bool flyDown;

	// Token: 0x0400099F RID: 2463
	private int dy;

	// Token: 0x040009A0 RID: 2464
	public bool changePos;

	// Token: 0x040009A1 RID: 2465
	private int tShock;

	// Token: 0x040009A2 RID: 2466
	public new bool isBusyAttackSomeOne = true;

	// Token: 0x040009A3 RID: 2467
	private int tA;

	// Token: 0x040009A4 RID: 2468
	private global::Char[] charAttack;

	// Token: 0x040009A5 RID: 2469
	private int[] dameHP;

	// Token: 0x040009A6 RID: 2470
	private sbyte type;

	// Token: 0x040009A7 RID: 2471
	public new int[] stand = new int[]
	{
		0,
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
		1
	};

	// Token: 0x040009A8 RID: 2472
	public new int[] move = new int[]
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

	// Token: 0x040009A9 RID: 2473
	public new int[] moveFast = new int[]
	{
		1,
		1,
		2,
		2,
		3,
		3,
		2
	};

	// Token: 0x040009AA RID: 2474
	public new int[] attack1 = new int[]
	{
		0,
		0,
		0,
		7,
		7,
		7,
		8,
		8,
		8,
		9,
		9,
		9
	};

	// Token: 0x040009AB RID: 2475
	public new int[] attack2 = new int[]
	{
		0,
		0,
		0,
		10,
		10,
		10,
		11,
		11,
		11,
		12,
		12,
		12
	};

	// Token: 0x040009AC RID: 2476
	public int[] attack3 = new int[]
	{
		0,
		0,
		1,
		1,
		4,
		4,
		6,
		6,
		8,
		8,
		25,
		25,
		26,
		26,
		28,
		28,
		30,
		30,
		32,
		32,
		2,
		2,
		1,
		1
	};

	// Token: 0x040009AD RID: 2477
	public int[] fly = new int[]
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
		6,
		6,
		3,
		3,
		3,
		2,
		2,
		2,
		1,
		1,
		1
	};

	// Token: 0x040009AE RID: 2478
	public int[] hitground = new int[]
	{
		6,
		6,
		6,
		3,
		3,
		3,
		2,
		2,
		2,
		1,
		1,
		1
	};

	// Token: 0x040009AF RID: 2479
	private bool shock;

	// Token: 0x040009B0 RID: 2480
	private sbyte[] cou = new sbyte[]
	{
		-1,
		1
	};

	// Token: 0x040009B1 RID: 2481
	public new global::Char injureBy;

	// Token: 0x040009B2 RID: 2482
	public new bool injureThenDie;

	// Token: 0x040009B3 RID: 2483
	public new Mob mobToAttack;

	// Token: 0x040009B4 RID: 2484
	public new int forceWait;

	// Token: 0x040009B5 RID: 2485
	public new bool blindEff;

	// Token: 0x040009B6 RID: 2486
	public new bool sleepEff;
}
