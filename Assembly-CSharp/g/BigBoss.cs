using System;

namespace Assets.src.g
{
	// Token: 0x02000099 RID: 153
	public class BigBoss : Mob, IMapObject
	{
		// Token: 0x06000549 RID: 1353 RVA: 0x000423E4 File Offset: 0x000405E4
		public BigBoss(int id, short px, short py, int templateID, int hp, int maxhp, int s)
		{
			this.xFirst = (this.x = (int)(px + 20));
			this.y = (int)py;
			this.yFirst = (int)py;
			this.mobId = id;
			this.hp = hp;
			this.maxHp = maxhp;
			this.templateId = templateID;
			if (s == 0)
			{
				this.getDataB();
			}
			if (s == 1)
			{
				this.getDataB2();
			}
			if (s == 2)
			{
				this.getDataB2();
				this.haftBody = true;
			}
			this.status = 2;
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x00042598 File Offset: 0x00040798
		public void getDataB2()
		{
			BigBoss.data = null;
			BigBoss.data = new EffectData();
			string patch = string.Concat(new object[]
			{
				"/x",
				mGraphics.zoomLevel,
				"/effectdata/",
				100,
				"/data"
			});
			try
			{
				BigBoss.data.readData2(patch);
				BigBoss.data.img = GameCanvas.loadImage("/effectdata/" + 100 + "/img.png");
			}
			catch (Exception ex)
			{
				Service.gI().requestModTemplate(this.templateId);
			}
			this.status = 2;
			this.w = BigBoss.data.width;
			this.h = BigBoss.data.height;
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x00042674 File Offset: 0x00040874
		public void getDataB()
		{
			BigBoss.data = null;
			BigBoss.data = new EffectData();
			string patch = string.Concat(new object[]
			{
				"/x",
				mGraphics.zoomLevel,
				"/effectdata/",
				101,
				"/data"
			});
			try
			{
				BigBoss.data.readData2(patch);
				BigBoss.data.img = GameCanvas.loadImage("/effectdata/" + 101 + "/img.png");
				Res.outz("read xong data");
			}
			catch (Exception ex)
			{
				Service.gI().requestModTemplate(this.templateId);
			}
			this.w = BigBoss.data.width;
			this.h = BigBoss.data.height;
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x000060C5 File Offset: 0x000042C5
		public new void setBody(short id)
		{
			this.changBody = true;
			this.smallBody = id;
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x000060D5 File Offset: 0x000042D5
		public new void clearBody()
		{
			this.changBody = false;
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x000418AC File Offset: 0x0003FAAC
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

		// Token: 0x0600054F RID: 1359 RVA: 0x000062B7 File Offset: 0x000044B7
		public new void checkFrameTick(int[] array)
		{
			this.tick++;
			if (this.tick > array.Length - 1)
			{
				this.tick = 0;
			}
			this.frame = array[this.tick];
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x00042754 File Offset: 0x00040954
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

		// Token: 0x06000551 RID: 1361 RVA: 0x0004288C File Offset: 0x00040A8C
		private void paintShadow(mGraphics g)
		{
			g.drawImage(BigBoss.shadowBig, this.xSd, this.yFirst, 3);
			g.setClip(GameScr.cmx, GameScr.cmy - GameCanvas.transY, GameScr.gW, GameScr.gH + 2 * GameCanvas.transY);
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x00003984 File Offset: 0x00001B84
		public new void updateSuperEff()
		{
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x000428DC File Offset: 0x00040ADC
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

		// Token: 0x06000554 RID: 1364 RVA: 0x000429D8 File Offset: 0x00040BD8
		private void updateDead()
		{
			this.checkFrameTick((!this.haftBody) ? this.stand : this.stand_1);
			if (GameCanvas.gameTick % 5 == 0)
			{
				ServerEffect.addServerEffect(167, Res.random(this.x - this.getW() / 2, this.x + this.getW() / 2), Res.random(this.getY() + this.getH() / 2, this.getY() + this.getH()), 1);
			}
			if (this.x != this.xFirst || this.y != this.yFirst)
			{
				this.x += (this.xFirst - this.x) / 4;
				this.y += (this.yFirst - this.y) / 4;
			}
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x00042ABC File Offset: 0x00040CBC
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

		// Token: 0x06000556 RID: 1366 RVA: 0x00003984 File Offset: 0x00001B84
		public new void setInjure()
		{
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x00042BAC File Offset: 0x00040DAC
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

		// Token: 0x06000558 RID: 1368 RVA: 0x00006113 File Offset: 0x00004313
		private bool isSpecial()
		{
			return (this.templateId >= 58 && this.templateId <= 65) || this.templateId == 67 || this.templateId == 68;
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00003984 File Offset: 0x00001B84
		private void updateInjure()
		{
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x00042C8C File Offset: 0x00040E8C
		private void updateMobStandWait()
		{
			this.checkFrameTick((!this.haftBody) ? this.stand : this.stand_1);
			if (this.x != this.xFirst || this.y != this.yFirst)
			{
				this.x += (this.xFirst - this.x) / 4;
				this.y += (this.yFirst - this.y) / 4;
			}
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x000062EC File Offset: 0x000044EC
		public void setFly()
		{
			this.status = 4;
			this.flyUp = true;
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x00042D18 File Offset: 0x00040F18
		public void setAttack(global::Char[] cAttack, int[] dame, sbyte type)
		{
			this.charAttack = cAttack;
			this.dameHP = dame;
			this.type = type;
			this.tick = 0;
			if ((int)type < 3)
			{
				this.status = 3;
			}
			if ((int)type == 3)
			{
				this.flyUp = true;
				this.status = 4;
			}
			if ((int)type == 4)
			{
				for (int i = 0; i < this.charAttack.Length; i++)
				{
					this.charAttack[i].doInjure(this.dameHP[i], 0, false, false);
				}
			}
			if ((int)type == 7)
			{
				this.status = 3;
			}
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x00042DB0 File Offset: 0x00040FB0
		public new void updateMobAttack()
		{
			if ((int)this.type == 7)
			{
				if (this.tick > 8)
				{
					this.tick = 8;
				}
				this.checkFrameTick(this.attack1);
				if (GameCanvas.gameTick % 4 == 0)
				{
					ServerEffect.addServerEffect(70, this.x + ((this.dir != 1) ? -15 : 15), this.y - 40, 1);
				}
			}
			if ((int)this.type == 0)
			{
				if (this.tick == this.attack1.Length - 1)
				{
					this.status = 2;
				}
				this.dir = ((this.x >= this.charAttack[0].cx) ? -1 : 1);
				this.checkFrameTick(this.attack1);
				if (this.tick == 8)
				{
					for (int i = 0; i < this.charAttack.Length; i++)
					{
						MonsterDart.addMonsterDart(this.x + ((this.dir != 1) ? -45 : 45), this.y - 30, true, this.dameHP[i], 0, this.charAttack[i], 24);
					}
				}
			}
			if ((int)this.type == 1)
			{
				if (this.tick == ((!this.haftBody) ? (this.attack2.Length - 1) : (this.attack2_1.Length - 1)))
				{
					this.status = 2;
				}
				this.dir = ((this.x >= this.charAttack[0].cx) ? -1 : 1);
				this.checkFrameTick((!this.haftBody) ? this.attack2 : this.attack2_1);
				this.x += (this.charAttack[0].cx - this.x) / 4;
				this.y += (this.charAttack[0].cy - this.y) / 4;
				if (this.tick == 18)
				{
					for (int j = 0; j < this.charAttack.Length; j++)
					{
						this.charAttack[j].doInjure(this.dameHP[j], 0, false, false);
						ServerEffect.addServerEffect(102, this.charAttack[j].cx, this.charAttack[j].cy, 1);
					}
				}
			}
			if ((int)this.type == 8)
			{
			}
			if ((int)this.type == 2)
			{
				if (this.tick == ((!this.haftBody) ? (this.attack3.Length - 1) : (this.attack3_1.Length - 1)))
				{
					this.status = 2;
				}
				this.dir = ((this.x >= this.charAttack[0].cx) ? -1 : 1);
				this.checkFrameTick((!this.haftBody) ? this.attack3 : this.attack3_1);
				if (this.tick == 13)
				{
					GameScr.shock_scr = 10;
					this.shock = true;
					for (int k = 0; k < this.charAttack.Length; k++)
					{
						this.charAttack[k].doInjure(this.dameHP[k], 0, false, false);
					}
				}
			}
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x00003984 File Offset: 0x00001B84
		public new void updateMobWalk()
		{
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x00041FF4 File Offset: 0x000401F4
		public new bool isPaint()
		{
			return this.x >= GameScr.cmx && this.x <= GameScr.cmx + GameScr.gW && this.y >= GameScr.cmy && this.y <= GameScr.cmy + GameScr.gH + 30 && this.status != 0;
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x0000617A File Offset: 0x0000437A
		public new bool isUpdate()
		{
			return this.status != 0;
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x0000618A File Offset: 0x0000438A
		public new bool checkIsBoss()
		{
			return this.isBoss || (int)this.levelBoss > 0;
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x000430F4 File Offset: 0x000412F4
		public override void paint(mGraphics g)
		{
			if (BigBoss.data == null)
			{
				return;
			}
			if (this.isShadown && this.status != 0)
			{
				this.paintShadow(g);
			}
			g.translate(0, GameCanvas.transY);
			BigBoss.data.paintFrame(g, this.frame, this.x, this.y + this.fy, (this.dir != 1) ? 1 : 0, 2);
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
				Res.outz("type= " + this.type);
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

		// Token: 0x06000563 RID: 1379 RVA: 0x000061A7 File Offset: 0x000043A7
		public new int getHPColor()
		{
			return 16711680;
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x000062FC File Offset: 0x000044FC
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

		// Token: 0x06000565 RID: 1381 RVA: 0x000432D4 File Offset: 0x000414D4
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

		// Token: 0x06000566 RID: 1382 RVA: 0x000061E8 File Offset: 0x000043E8
		public new int getX()
		{
			return this.x;
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x00006336 File Offset: 0x00004536
		public new int getY()
		{
			return (!this.haftBody) ? (this.y - 60) : (this.y - 20);
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x000061FB File Offset: 0x000043FB
		public new int getH()
		{
			return 40;
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x0000635A File Offset: 0x0000455A
		public new int getW()
		{
			return 60;
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x000433B4 File Offset: 0x000415B4
		public new void stopMoving()
		{
			if (this.status == 5)
			{
				this.status = 2;
				this.p1 = (this.p2 = (this.p3 = 0));
				this.forceWait = 50;
			}
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x000061FF File Offset: 0x000043FF
		public new bool isInvisible()
		{
			return this.status == 0 || this.status == 1;
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x00006218 File Offset: 0x00004418
		public new void removeHoldEff()
		{
			if (this.holdEffID != 0)
			{
				this.holdEffID = 0;
			}
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0000635E File Offset: 0x0000455E
		public new void removeBlindEff()
		{
			this.blindEff = false;
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x00006367 File Offset: 0x00004567
		public new void removeSleepEff()
		{
			this.sleepEff = false;
		}

		// Token: 0x04000957 RID: 2391
		public static Image shadowBig = GameCanvas.loadImage("/mainImage/shadowBig.png");

		// Token: 0x04000958 RID: 2392
		public static EffectData data;

		// Token: 0x04000959 RID: 2393
		public int xTo;

		// Token: 0x0400095A RID: 2394
		public int yTo;

		// Token: 0x0400095B RID: 2395
		public bool haftBody;

		// Token: 0x0400095C RID: 2396
		public bool change;

		// Token: 0x0400095D RID: 2397
		public new int xSd;

		// Token: 0x0400095E RID: 2398
		public new int ySd;

		// Token: 0x0400095F RID: 2399
		private bool isOutMap;

		// Token: 0x04000960 RID: 2400
		private int wCount;

		// Token: 0x04000961 RID: 2401
		public new bool isShadown = true;

		// Token: 0x04000962 RID: 2402
		private int tick;

		// Token: 0x04000963 RID: 2403
		private int frame;

		// Token: 0x04000964 RID: 2404
		private bool wy;

		// Token: 0x04000965 RID: 2405
		private int wt;

		// Token: 0x04000966 RID: 2406
		private int fy;

		// Token: 0x04000967 RID: 2407
		private int ty;

		// Token: 0x04000968 RID: 2408
		public new int typeSuperEff;

		// Token: 0x04000969 RID: 2409
		private global::Char focus;

		// Token: 0x0400096A RID: 2410
		private bool flyUp;

		// Token: 0x0400096B RID: 2411
		private bool flyDown;

		// Token: 0x0400096C RID: 2412
		private int dy;

		// Token: 0x0400096D RID: 2413
		public bool changePos;

		// Token: 0x0400096E RID: 2414
		private int tShock;

		// Token: 0x0400096F RID: 2415
		public new bool isBusyAttackSomeOne = true;

		// Token: 0x04000970 RID: 2416
		private int tA;

		// Token: 0x04000971 RID: 2417
		private global::Char[] charAttack;

		// Token: 0x04000972 RID: 2418
		private int[] dameHP;

		// Token: 0x04000973 RID: 2419
		private sbyte type;

		// Token: 0x04000974 RID: 2420
		public new int[] stand = new int[]
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

		// Token: 0x04000975 RID: 2421
		public int[] stand_1 = new int[]
		{
			37,
			37,
			37,
			38,
			38,
			38,
			39,
			39,
			40,
			40,
			40,
			39,
			39,
			39,
			38,
			38,
			38
		};

		// Token: 0x04000976 RID: 2422
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

		// Token: 0x04000977 RID: 2423
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

		// Token: 0x04000978 RID: 2424
		public new int[] attack1 = new int[]
		{
			0,
			0,
			34,
			34,
			35,
			35,
			36,
			36,
			2,
			2,
			1,
			1
		};

		// Token: 0x04000979 RID: 2425
		public new int[] attack2 = new int[]
		{
			0,
			0,
			0,
			4,
			4,
			6,
			6,
			9,
			9,
			10,
			10,
			13,
			13,
			15,
			15,
			17,
			17,
			19,
			19,
			21,
			21,
			23,
			23
		};

		// Token: 0x0400097A RID: 2426
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

		// Token: 0x0400097B RID: 2427
		public int[] attack2_1 = new int[]
		{
			37,
			37,
			5,
			5,
			7,
			7,
			11,
			11,
			14,
			14,
			16,
			16,
			18,
			18,
			20,
			20,
			22,
			22,
			24,
			24
		};

		// Token: 0x0400097C RID: 2428
		public int[] attack3_1 = new int[]
		{
			37,
			37,
			37,
			38,
			38,
			5,
			5,
			7,
			7,
			11,
			11,
			27,
			27,
			29,
			29,
			31,
			31,
			33,
			33,
			38,
			38
		};

		// Token: 0x0400097D RID: 2429
		public int[] fly = new int[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			12,
			12
		};

		// Token: 0x0400097E RID: 2430
		public int[] hitground = new int[]
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

		// Token: 0x0400097F RID: 2431
		private bool shock;

		// Token: 0x04000980 RID: 2432
		private sbyte[] cou = new sbyte[]
		{
			-1,
			1
		};

		// Token: 0x04000981 RID: 2433
		public new global::Char injureBy;

		// Token: 0x04000982 RID: 2434
		public new bool injureThenDie;

		// Token: 0x04000983 RID: 2435
		public new Mob mobToAttack;

		// Token: 0x04000984 RID: 2436
		public new int forceWait;

		// Token: 0x04000985 RID: 2437
		public new bool blindEff;

		// Token: 0x04000986 RID: 2438
		public new bool sleepEff;
	}
}
