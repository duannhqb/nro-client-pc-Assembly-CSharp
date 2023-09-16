using System;

// Token: 0x02000097 RID: 151
public class BachTuoc : Mob, IMapObject
{
	// Token: 0x06000520 RID: 1312 RVA: 0x000416C4 File Offset: 0x0003F8C4
	public BachTuoc(int id, short px, short py, int templateID, int hp, int maxHp, int s)
	{
		this.mobId = id;
		this.xFirst = (this.x = (int)(px + 20));
		this.y = (int)py;
		this.yFirst = (int)py;
		this.xTo = this.x;
		this.yTo = this.y;
		this.maxHp = maxHp;
		this.hp = hp;
		this.templateId = templateID;
		this.getDataB();
		this.status = 2;
	}

	// Token: 0x06000521 RID: 1313 RVA: 0x000417D8 File Offset: 0x0003F9D8
	public void getDataB()
	{
		BachTuoc.data = null;
		BachTuoc.data = new EffectData();
		string patch = string.Concat(new object[]
		{
			"/x",
			mGraphics.zoomLevel,
			"/effectdata/",
			108,
			"/data"
		});
		try
		{
			BachTuoc.data.readData2(patch);
			BachTuoc.data.img = GameCanvas.loadImage("/effectdata/" + 108 + "/img.png");
		}
		catch (Exception ex)
		{
			Service.gI().requestModTemplate(this.templateId);
		}
		this.w = BachTuoc.data.width;
		this.h = BachTuoc.data.height;
	}

	// Token: 0x06000522 RID: 1314 RVA: 0x000060C5 File Offset: 0x000042C5
	public new void setBody(short id)
	{
		this.changBody = true;
		this.smallBody = id;
	}

	// Token: 0x06000523 RID: 1315 RVA: 0x000060D5 File Offset: 0x000042D5
	public new void clearBody()
	{
		this.changBody = false;
	}

	// Token: 0x06000524 RID: 1316 RVA: 0x000418AC File Offset: 0x0003FAAC
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

	// Token: 0x06000525 RID: 1317 RVA: 0x000060DE File Offset: 0x000042DE
	public new void checkFrameTick(int[] array)
	{
		this.tick++;
		if (this.tick > array.Length - 1)
		{
			this.tick = 0;
		}
		this.frame = array[this.tick];
	}

	// Token: 0x06000526 RID: 1318 RVA: 0x000418F4 File Offset: 0x0003FAF4
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

	// Token: 0x06000527 RID: 1319 RVA: 0x00041A2C File Offset: 0x0003FC2C
	private void paintShadow(mGraphics g)
	{
		int num = (int)TileMap.size;
		g.drawImage(BachTuoc.shadowBig, this.xSd, this.yFirst, 3);
		g.setClip(GameScr.cmx, GameScr.cmy - GameCanvas.transY, GameScr.gW, GameScr.gH + 2 * GameCanvas.transY);
	}

	// Token: 0x06000528 RID: 1320 RVA: 0x00003984 File Offset: 0x00001B84
	public new void updateSuperEff()
	{
	}

	// Token: 0x06000529 RID: 1321 RVA: 0x00041A80 File Offset: 0x0003FC80
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

	// Token: 0x0600052A RID: 1322 RVA: 0x00041B68 File Offset: 0x0003FD68
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

	// Token: 0x0600052B RID: 1323 RVA: 0x00003984 File Offset: 0x00001B84
	public new void setInjure()
	{
	}

	// Token: 0x0600052C RID: 1324 RVA: 0x00041C38 File Offset: 0x0003FE38
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

	// Token: 0x0600052D RID: 1325 RVA: 0x00006113 File Offset: 0x00004313
	private bool isSpecial()
	{
		return (this.templateId >= 58 && this.templateId <= 65) || this.templateId == 67 || this.templateId == 68;
	}

	// Token: 0x0600052E RID: 1326 RVA: 0x00003984 File Offset: 0x00001B84
	private void updateInjure()
	{
	}

	// Token: 0x0600052F RID: 1327 RVA: 0x00041D18 File Offset: 0x0003FF18
	private void updateMobStandWait()
	{
		this.checkFrameTick(this.stand);
		if (this.x != this.xTo || this.y != this.yTo)
		{
			this.x += (this.xTo - this.x) / 4;
			this.y += (this.yTo - this.y) / 4;
		}
	}

	// Token: 0x06000530 RID: 1328 RVA: 0x0000614C File Offset: 0x0000434C
	public void setFly()
	{
		this.status = 4;
		this.flyUp = true;
	}

	// Token: 0x06000531 RID: 1329 RVA: 0x0000615C File Offset: 0x0000435C
	public void setAttack(global::Char[] cAttack, int[] dame, sbyte type)
	{
		this.charAttack = cAttack;
		this.dameHP = dame;
		this.type = type;
		this.status = 3;
	}

	// Token: 0x06000532 RID: 1330 RVA: 0x00041D8C File Offset: 0x0003FF8C
	public new void updateMobAttack()
	{
		if ((int)this.type == 3)
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
		if ((int)this.type == 4)
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
					this.charAttack[j].doInjure(this.dameHP[j], 0, false, false);
					ServerEffect.addServerEffect(102, this.charAttack[j].cx, this.charAttack[j].cy, 1);
				}
			}
		}
	}

	// Token: 0x06000533 RID: 1331 RVA: 0x00041F60 File Offset: 0x00040160
	public new void updateMobWalk()
	{
		this.checkFrameTick(this.movee);
		this.x += ((this.x >= this.xTo) ? -2 : 2);
		this.y = this.yTo;
		this.dir = ((this.x >= this.xTo) ? -1 : 1);
		if (Res.abs(this.x - this.xTo) <= 1)
		{
			this.x = this.xTo;
			this.status = 2;
		}
	}

	// Token: 0x06000534 RID: 1332 RVA: 0x00041FF4 File Offset: 0x000401F4
	public new bool isPaint()
	{
		return this.x >= GameScr.cmx && this.x <= GameScr.cmx + GameScr.gW && this.y >= GameScr.cmy && this.y <= GameScr.cmy + GameScr.gH + 30 && this.status != 0;
	}

	// Token: 0x06000535 RID: 1333 RVA: 0x0000617A File Offset: 0x0000437A
	public new bool isUpdate()
	{
		return this.status != 0;
	}

	// Token: 0x06000536 RID: 1334 RVA: 0x0000618A File Offset: 0x0000438A
	public new bool checkIsBoss()
	{
		return this.isBoss || (int)this.levelBoss > 0;
	}

	// Token: 0x06000537 RID: 1335 RVA: 0x00042068 File Offset: 0x00040268
	public override void paint(mGraphics g)
	{
		if (BachTuoc.data == null)
		{
			return;
		}
		if (this.isShadown && this.status != 0)
		{
			this.paintShadow(g);
		}
		g.translate(0, GameCanvas.transY);
		BachTuoc.data.paintFrame(g, this.frame, this.x, this.y + this.fy, (this.dir != 1) ? 1 : 0, 2);
		g.translate(0, -GameCanvas.transY);
		int num = (int)((long)this.hp * 50L / (long)this.maxHp);
		if (num != 0)
		{
			g.setColor(0);
			g.fillRect(this.x - 27, this.y - 82, 54, 8);
			g.setColor(16711680);
			g.setClip(this.x - 25, this.y - 80, num, 4);
			g.fillRect(this.x - 25, this.y - 80, 50, 4);
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

	// Token: 0x06000538 RID: 1336 RVA: 0x000061A7 File Offset: 0x000043A7
	public new int getHPColor()
	{
		return 16711680;
	}

	// Token: 0x06000539 RID: 1337 RVA: 0x000061AE File Offset: 0x000043AE
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

	// Token: 0x0600053A RID: 1338 RVA: 0x00042230 File Offset: 0x00040430
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

	// Token: 0x0600053B RID: 1339 RVA: 0x000061E8 File Offset: 0x000043E8
	public new int getX()
	{
		return this.x;
	}

	// Token: 0x0600053C RID: 1340 RVA: 0x000061F0 File Offset: 0x000043F0
	public new int getY()
	{
		return this.y - 40;
	}

	// Token: 0x0600053D RID: 1341 RVA: 0x000061FB File Offset: 0x000043FB
	public new int getH()
	{
		return 40;
	}

	// Token: 0x0600053E RID: 1342 RVA: 0x000061FB File Offset: 0x000043FB
	public new int getW()
	{
		return 40;
	}

	// Token: 0x0600053F RID: 1343 RVA: 0x00042310 File Offset: 0x00040510
	public new void stopMoving()
	{
		if (this.status == 5)
		{
			this.status = 2;
			this.p1 = (this.p2 = (this.p3 = 0));
			this.forceWait = 50;
		}
	}

	// Token: 0x06000540 RID: 1344 RVA: 0x000061FF File Offset: 0x000043FF
	public new bool isInvisible()
	{
		return this.status == 0 || this.status == 1;
	}

	// Token: 0x06000541 RID: 1345 RVA: 0x00006218 File Offset: 0x00004418
	public new void removeHoldEff()
	{
		if (this.holdEffID != 0)
		{
			this.holdEffID = 0;
		}
	}

	// Token: 0x06000542 RID: 1346 RVA: 0x0000622C File Offset: 0x0000442C
	public new void removeBlindEff()
	{
		this.blindEff = false;
	}

	// Token: 0x06000543 RID: 1347 RVA: 0x00006235 File Offset: 0x00004435
	public new void removeSleepEff()
	{
		this.sleepEff = false;
	}

	// Token: 0x06000544 RID: 1348 RVA: 0x0000623E File Offset: 0x0000443E
	public new void move(short xMoveTo)
	{
		this.xTo = (int)xMoveTo;
		this.status = 5;
	}

	// Token: 0x0400091E RID: 2334
	public static Image shadowBig = GameCanvas.loadImage("/mainImage/shadowBig.png");

	// Token: 0x0400091F RID: 2335
	public static EffectData data;

	// Token: 0x04000920 RID: 2336
	public int xTo;

	// Token: 0x04000921 RID: 2337
	public int yTo;

	// Token: 0x04000922 RID: 2338
	public bool haftBody;

	// Token: 0x04000923 RID: 2339
	public bool change;

	// Token: 0x04000924 RID: 2340
	private Mob mob1;

	// Token: 0x04000925 RID: 2341
	public new int xSd;

	// Token: 0x04000926 RID: 2342
	public new int ySd;

	// Token: 0x04000927 RID: 2343
	private bool isOutMap;

	// Token: 0x04000928 RID: 2344
	private int wCount;

	// Token: 0x04000929 RID: 2345
	public new bool isShadown = true;

	// Token: 0x0400092A RID: 2346
	private int tick;

	// Token: 0x0400092B RID: 2347
	private int frame;

	// Token: 0x0400092C RID: 2348
	public new static Image imgHP = GameCanvas.loadImage("/mainImage/myTexture2dmobHP.png");

	// Token: 0x0400092D RID: 2349
	private bool wy;

	// Token: 0x0400092E RID: 2350
	private int wt;

	// Token: 0x0400092F RID: 2351
	private int fy;

	// Token: 0x04000930 RID: 2352
	private int ty;

	// Token: 0x04000931 RID: 2353
	public new int typeSuperEff;

	// Token: 0x04000932 RID: 2354
	private global::Char focus;

	// Token: 0x04000933 RID: 2355
	private bool flyUp;

	// Token: 0x04000934 RID: 2356
	private bool flyDown;

	// Token: 0x04000935 RID: 2357
	private int dy;

	// Token: 0x04000936 RID: 2358
	public bool changePos;

	// Token: 0x04000937 RID: 2359
	private int tShock;

	// Token: 0x04000938 RID: 2360
	public new bool isBusyAttackSomeOne = true;

	// Token: 0x04000939 RID: 2361
	private int tA;

	// Token: 0x0400093A RID: 2362
	private global::Char[] charAttack;

	// Token: 0x0400093B RID: 2363
	private int[] dameHP;

	// Token: 0x0400093C RID: 2364
	private sbyte type;

	// Token: 0x0400093D RID: 2365
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

	// Token: 0x0400093E RID: 2366
	public int[] movee = new int[]
	{
		0,
		0,
		0,
		2,
		2,
		2,
		3,
		3,
		3,
		4,
		4,
		4
	};

	// Token: 0x0400093F RID: 2367
	public new int[] attack1 = new int[]
	{
		0,
		0,
		0,
		4,
		4,
		4,
		5,
		5,
		5,
		6,
		6,
		6
	};

	// Token: 0x04000940 RID: 2368
	public new int[] attack2 = new int[]
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
		9,
		10,
		10,
		10,
		11,
		11
	};

	// Token: 0x04000941 RID: 2369
	public int[] hurt = new int[]
	{
		1,
		1,
		7,
		7
	};

	// Token: 0x04000942 RID: 2370
	private bool shock;

	// Token: 0x04000943 RID: 2371
	private sbyte[] cou = new sbyte[]
	{
		-1,
		1
	};

	// Token: 0x04000944 RID: 2372
	public new global::Char injureBy;

	// Token: 0x04000945 RID: 2373
	public new bool injureThenDie;

	// Token: 0x04000946 RID: 2374
	public new Mob mobToAttack;

	// Token: 0x04000947 RID: 2375
	public new int forceWait;

	// Token: 0x04000948 RID: 2376
	public new bool blindEff;

	// Token: 0x04000949 RID: 2377
	public new bool sleepEff;
}
