using System;

// Token: 0x0200005F RID: 95
public class ItemMap : IMapObject
{
	// Token: 0x0600033C RID: 828 RVA: 0x0001CCF8 File Offset: 0x0001AEF8
	public ItemMap(short itemMapID, short itemTemplateID, int x, int y, int xEnd, int yEnd)
	{
		this.itemMapID = (int)itemMapID;
		this.template = ItemTemplates.get(itemTemplateID);
		this.x = xEnd;
		this.y = y;
		this.xEnd = xEnd;
		this.yEnd = yEnd;
		this.vx = xEnd - x >> 2;
		this.vy = 5;
		Res.outz(string.Concat(new object[]
		{
			"playerid=  ",
			this.playerId,
			" myid= ",
			global::Char.myCharz().charID
		}));
	}

	// Token: 0x0600033D RID: 829 RVA: 0x0001CD94 File Offset: 0x0001AF94
	public ItemMap(int playerId, short itemMapID, short itemTemplateID, int x, int y, short r)
	{
		Res.outz(string.Concat(new object[]
		{
			"item map item= ",
			itemMapID,
			" template= ",
			itemTemplateID,
			" x= ",
			x,
			" y= ",
			y
		}));
		this.itemMapID = (int)itemMapID;
		this.template = ItemTemplates.get(itemTemplateID);
		Res.outz(string.Concat(new object[]
		{
			"playerid=  ",
			playerId,
			" myid= ",
			global::Char.myCharz().charID
		}));
		this.xEnd = x;
		this.x = x;
		this.yEnd = y;
		this.y = y;
		this.status = 1;
		this.playerId = playerId;
		if (this.isAuraItem())
		{
			this.rO = (int)r;
			this.setAuraItem();
		}
	}

	// Token: 0x0600033E RID: 830 RVA: 0x00005327 File Offset: 0x00003527
	public void setPoint(int xEnd, int yEnd)
	{
		this.xEnd = xEnd;
		this.yEnd = yEnd;
		this.vx = xEnd - this.x >> 2;
		this.vy = yEnd - this.y >> 2;
		this.status = 2;
	}

	// Token: 0x0600033F RID: 831 RVA: 0x0001CE94 File Offset: 0x0001B094
	public void update()
	{
		if ((int)this.status == 2 && this.x == this.xEnd && this.y == this.yEnd)
		{
			GameScr.vItemMap.removeElement(this);
			if (global::Char.myCharz().itemFocus != null && global::Char.myCharz().itemFocus.Equals(this))
			{
				global::Char.myCharz().itemFocus = null;
			}
			return;
		}
		if ((int)this.status > 0)
		{
			if (this.vx == 0)
			{
				this.x = this.xEnd;
			}
			if (this.vy == 0)
			{
				this.y = this.yEnd;
			}
			if (this.x != this.xEnd)
			{
				this.x += this.vx;
				if ((this.vx > 0 && this.x > this.xEnd) || (this.vx < 0 && this.x < this.xEnd))
				{
					this.x = this.xEnd;
				}
			}
			if (this.y != this.yEnd)
			{
				this.y += this.vy;
				if ((this.vy > 0 && this.y > this.yEnd) || (this.vy < 0 && this.y < this.yEnd))
				{
					this.y = this.yEnd;
				}
			}
		}
		else
		{
			this.status = (sbyte)((int)this.status - 4);
			if ((int)this.status < -12)
			{
				this.y -= 12;
				this.status = 1;
			}
		}
		if (this.isAuraItem())
		{
			this.updateAuraItemEff();
		}
	}

	// Token: 0x06000340 RID: 832 RVA: 0x0001D064 File Offset: 0x0001B264
	public void paint(mGraphics g)
	{
		if (this.isAuraItem())
		{
			g.drawImage(TileMap.bong, this.x + 3, this.y, mGraphics.VCENTER | mGraphics.HCENTER);
			if ((int)this.status <= 0)
			{
				if (this.countAura < 10)
				{
					g.drawImage(ItemMap.imageAuraItem1, this.x, this.y + (int)this.status + 3, mGraphics.BOTTOM | mGraphics.HCENTER);
				}
				else
				{
					g.drawImage(ItemMap.imageAuraItem2, this.x, this.y + (int)this.status + 3, mGraphics.BOTTOM | mGraphics.HCENTER);
				}
			}
			else if (this.countAura < 10)
			{
				g.drawImage(ItemMap.imageAuraItem1, this.x, this.y + 3, mGraphics.BOTTOM | mGraphics.HCENTER);
			}
			else
			{
				g.drawImage(ItemMap.imageAuraItem2, this.x, this.y + 3, mGraphics.BOTTOM | mGraphics.HCENTER);
			}
		}
		else if (!this.isAuraItem())
		{
			if (GameCanvas.gameTick % 4 == 0)
			{
				g.drawImage(ItemMap.imageFlare, this.x, this.y + (int)this.status + 13, mGraphics.BOTTOM | mGraphics.HCENTER);
			}
			if ((int)this.status <= 0)
			{
				SmallImage.drawSmallImage(g, (int)this.template.iconID, this.x, this.y + (int)this.status + 3, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
			}
			else
			{
				SmallImage.drawSmallImage(g, (int)this.template.iconID, this.x, this.y + 3, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
			}
			if (global::Char.myCharz().itemFocus != null && global::Char.myCharz().itemFocus.Equals(this) && (int)this.status != 2)
			{
				g.drawRegion(Mob.imgHP, 0, 24, 9, 6, 0, this.x, this.y - 17, 3);
			}
		}
	}

	// Token: 0x06000341 RID: 833 RVA: 0x0001D284 File Offset: 0x0001B484
	private bool isAuraItem()
	{
		return (int)this.template.type == 22;
	}

	// Token: 0x06000342 RID: 834 RVA: 0x0001D2B0 File Offset: 0x0001B4B0
	private void setAuraItem()
	{
		this.xO = this.x;
		this.yO = this.y;
		this.iDot = 120;
		this.angle = 0;
		if (!GameCanvas.lowGraphic)
		{
			this.iAngle = 360 / this.iDot;
			this.xArg = new int[this.iDot];
			this.yArg = new int[this.iDot];
			this.xDot = new int[this.iDot];
			this.yDot = new int[this.iDot];
			this.setDotPosition();
		}
	}

	// Token: 0x06000343 RID: 835 RVA: 0x0001D34C File Offset: 0x0001B54C
	private void updateAuraItemEff()
	{
		this.count++;
		this.countAura++;
		if (this.countAura >= 40)
		{
			this.countAura = 0;
		}
		if (this.count >= this.iDot)
		{
			this.count = 0;
		}
		if (this.count % 10 == 0 && !GameCanvas.lowGraphic)
		{
			ServerEffect.addServerEffect(114, this.x - 5, this.y - 30, 1);
		}
	}

	// Token: 0x06000344 RID: 836 RVA: 0x0001D3D4 File Offset: 0x0001B5D4
	public void paintAuraItemEff(mGraphics g)
	{
		if (!GameCanvas.lowGraphic && this.isAuraItem())
		{
			for (int i = 0; i < this.yArg.Length; i++)
			{
				if (this.count == i)
				{
					if (this.countAura <= 20)
					{
						g.drawImage(ItemMap.imageAuraItem3, this.xDot[i], this.yDot[i] + 3, mGraphics.BOTTOM | mGraphics.HCENTER);
					}
					else
					{
						SmallImage.drawSmallImage(g, (int)this.template.iconID, this.xDot[i], this.yDot[i] + 3, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
					}
				}
			}
		}
	}

	// Token: 0x06000345 RID: 837 RVA: 0x0001D484 File Offset: 0x0001B684
	private void setDotPosition()
	{
		if (!GameCanvas.lowGraphic)
		{
			for (int i = 0; i < this.yArg.Length; i++)
			{
				this.yArg[i] = Res.abs(this.rO * Res.sin(this.angle) / 1024);
				this.xArg[i] = Res.abs(this.rO * Res.cos(this.angle) / 1024);
				if (this.angle < 90)
				{
					this.xDot[i] = this.xO + this.xArg[i];
					this.yDot[i] = this.yO - this.yArg[i];
				}
				else if (this.angle >= 90 && this.angle < 180)
				{
					this.xDot[i] = this.xO - this.xArg[i];
					this.yDot[i] = this.yO - this.yArg[i];
				}
				else if (this.angle >= 180 && this.angle < 270)
				{
					this.xDot[i] = this.xO - this.xArg[i];
					this.yDot[i] = this.yO + this.yArg[i];
				}
				else
				{
					this.xDot[i] = this.xO + this.xArg[i];
					this.yDot[i] = this.yO + this.yArg[i];
				}
				this.angle += this.iAngle;
			}
		}
	}

	// Token: 0x06000346 RID: 838 RVA: 0x0000535E File Offset: 0x0000355E
	public int getX()
	{
		return this.x;
	}

	// Token: 0x06000347 RID: 839 RVA: 0x00005366 File Offset: 0x00003566
	public int getY()
	{
		return this.y;
	}

	// Token: 0x06000348 RID: 840 RVA: 0x0000536E File Offset: 0x0000356E
	public int getH()
	{
		return 20;
	}

	// Token: 0x06000349 RID: 841 RVA: 0x0000536E File Offset: 0x0000356E
	public int getW()
	{
		return 20;
	}

	// Token: 0x0600034A RID: 842 RVA: 0x00003984 File Offset: 0x00001B84
	public void stopMoving()
	{
	}

	// Token: 0x0600034B RID: 843 RVA: 0x00003C68 File Offset: 0x00001E68
	public bool isInvisible()
	{
		return false;
	}

	// Token: 0x0400055F RID: 1375
	public int x;

	// Token: 0x04000560 RID: 1376
	public int y;

	// Token: 0x04000561 RID: 1377
	public int xEnd;

	// Token: 0x04000562 RID: 1378
	public int yEnd;

	// Token: 0x04000563 RID: 1379
	public int f;

	// Token: 0x04000564 RID: 1380
	public int vx;

	// Token: 0x04000565 RID: 1381
	public int vy;

	// Token: 0x04000566 RID: 1382
	public int playerId;

	// Token: 0x04000567 RID: 1383
	public int itemMapID;

	// Token: 0x04000568 RID: 1384
	public int IdCharMove;

	// Token: 0x04000569 RID: 1385
	public ItemTemplate template;

	// Token: 0x0400056A RID: 1386
	public sbyte status;

	// Token: 0x0400056B RID: 1387
	public bool isHintFocus;

	// Token: 0x0400056C RID: 1388
	public int rO;

	// Token: 0x0400056D RID: 1389
	public int xO;

	// Token: 0x0400056E RID: 1390
	public int yO;

	// Token: 0x0400056F RID: 1391
	public int angle;

	// Token: 0x04000570 RID: 1392
	public int iAngle;

	// Token: 0x04000571 RID: 1393
	public int iDot;

	// Token: 0x04000572 RID: 1394
	public int[] xArg;

	// Token: 0x04000573 RID: 1395
	public int[] yArg;

	// Token: 0x04000574 RID: 1396
	public int[] xDot;

	// Token: 0x04000575 RID: 1397
	public int[] yDot;

	// Token: 0x04000576 RID: 1398
	public int count;

	// Token: 0x04000577 RID: 1399
	public int countAura;

	// Token: 0x04000578 RID: 1400
	public static Image imageFlare = GameCanvas.loadImage("/mainImage/myTexture2dflare.png");

	// Token: 0x04000579 RID: 1401
	public static Image imageAuraItem1 = GameCanvas.loadImage("/mainImage/myTexture2ditemaura1.png");

	// Token: 0x0400057A RID: 1402
	public static Image imageAuraItem2 = GameCanvas.loadImage("/mainImage/myTexture2ditemaura2.png");

	// Token: 0x0400057B RID: 1403
	public static Image imageAuraItem3 = GameCanvas.loadImage("/mainImage/myTexture2ditemaura3.png");
}
