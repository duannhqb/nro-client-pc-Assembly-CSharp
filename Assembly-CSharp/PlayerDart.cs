using System;

// Token: 0x02000073 RID: 115
public class PlayerDart
{
	// Token: 0x060003B2 RID: 946 RVA: 0x0002054C File Offset: 0x0001E74C
	public PlayerDart(global::Char charBelong, int dartType, SkillPaint sp, int x, int y)
	{
		this.skillPaint = sp;
		this.charBelong = charBelong;
		this.info = GameScr.darts[dartType];
		this.va = this.info.va;
		this.x = x;
		this.y = y;
		IMapObject mapObject;
		if (charBelong.mobFocus == null)
		{
			IMapObject charFocus = charBelong.charFocus;
			mapObject = charFocus;
		}
		else
		{
			mapObject = charBelong.mobFocus;
		}
		IMapObject mapObject2 = mapObject;
		this.setAngle(Res.angle(mapObject2.getX() - x, mapObject2.getY() - y));
	}

	// Token: 0x060003B3 RID: 947 RVA: 0x0000581F File Offset: 0x00003A1F
	public void setAngle(int angle)
	{
		this.angle = angle;
		this.vx = this.va * Res.cos(angle) >> 10;
		this.vy = this.va * Res.sin(angle) >> 10;
	}

	// Token: 0x060003B4 RID: 948 RVA: 0x000205EC File Offset: 0x0001E7EC
	public void update()
	{
		if (!this.isActive)
		{
			return;
		}
		if (this.charBelong.mobFocus == null && this.charBelong.charFocus == null)
		{
			this.endMe();
		}
		else
		{
			IMapObject mapObject;
			if (this.charBelong.mobFocus == null)
			{
				IMapObject charFocus = this.charBelong.charFocus;
				mapObject = charFocus;
			}
			else
			{
				mapObject = this.charBelong.mobFocus;
			}
			IMapObject mapObject2 = mapObject;
			for (int i = 0; i < (int)this.info.nUpdate; i++)
			{
				if (this.info.tail.Length > 0)
				{
					this.darts.addElement(new SmallDart(this.x, this.y));
				}
				int num = (this.charBelong.getX() <= mapObject2.getX()) ? -10 : 10;
				this.dx = mapObject2.getX() + num - this.x;
				this.dy = mapObject2.getY() - mapObject2.getH() / 2 - this.y;
				this.life++;
				if (Res.abs(this.dx) < 20 && Res.abs(this.dy) < 20)
				{
					if (this.charBelong.charFocus != null && this.charBelong.charFocus.me)
					{
						this.charBelong.charFocus.doInjure(this.charBelong.charFocus.damHP, 0, this.charBelong.charFocus.isCrit, this.charBelong.charFocus.isMob);
					}
					this.endMe();
					return;
				}
				int num2 = Res.angle(this.dx, this.dy);
				if (global::Math.abs(num2 - this.angle) < 90 || this.dx * this.dx + this.dy * this.dy > 4096)
				{
					if (global::Math.abs(num2 - this.angle) < 15)
					{
						this.angle = num2;
					}
					else if ((num2 - this.angle >= 0 && num2 - this.angle < 180) || num2 - this.angle < -180)
					{
						this.angle = Res.fixangle(this.angle + 15);
					}
					else
					{
						this.angle = Res.fixangle(this.angle - 15);
					}
				}
				if (!this.isSpeedUp && this.va < 8192)
				{
					this.va += 1024;
				}
				this.vx = this.va * Res.cos(this.angle) >> 10;
				this.vy = this.va * Res.sin(this.angle) >> 10;
				this.dx += this.vx;
				int num3 = this.dx >> 10;
				this.x += num3;
				this.dx &= 1023;
				this.dy += this.vy;
				int num4 = this.dy >> 10;
				this.y += num4;
				this.dy &= 1023;
			}
			for (int j = 0; j < this.darts.size(); j++)
			{
				SmallDart smallDart = (SmallDart)this.darts.elementAt(j);
				smallDart.index++;
				if (smallDart.index >= this.info.tail.Length)
				{
					this.darts.removeElementAt(j);
				}
			}
		}
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x000209B0 File Offset: 0x0001EBB0
	private void endMe()
	{
		if (!this.charBelong.isUseSkillAfterCharge && this.x >= GameScr.cmx && this.x <= GameScr.cmx + GameCanvas.w)
		{
			SoundMn.gI().explode_1();
		}
		this.charBelong.setAttack();
		if (this.charBelong.me)
		{
			this.charBelong.saveLoadPreviousSkill();
		}
		if (this.charBelong.isUseSkillAfterCharge)
		{
			this.charBelong.isUseSkillAfterCharge = false;
			if (this.charBelong.isLockMove && this.charBelong.me && this.charBelong.statusMe != 14 && this.charBelong.statusMe != 5)
			{
				this.charBelong.isLockMove = false;
			}
			GameScr.gI().activeSuperPower(this.x, this.y);
		}
		this.charBelong.dart = null;
		this.charBelong.isCreateDark = false;
		this.charBelong.skillPaint = null;
		this.charBelong.skillPaintRandomPaint = null;
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x00020AD4 File Offset: 0x0001ECD4
	public void paint(mGraphics g)
	{
		if (!this.isActive)
		{
			return;
		}
		int num = MonsterDart.findDirIndexFromAngle(360 - this.angle);
		int num2 = (int)MonsterDart.FRAME[num];
		int transform = MonsterDart.TRANSFORM[num];
		for (int i = this.darts.size() / 2; i < this.darts.size(); i++)
		{
			SmallDart smallDart = (SmallDart)this.darts.elementAt(i);
			SmallImage.drawSmallImage(g, (int)this.info.tailBorder[smallDart.index], smallDart.x, smallDart.y, 0, 3);
		}
		int num3 = GameCanvas.gameTick % this.info.headBorder.Length;
		SmallImage.drawSmallImage(g, (int)this.info.headBorder[num3][num2], this.x, this.y, transform, 3);
		for (int j = 0; j < this.darts.size(); j++)
		{
			SmallDart smallDart2 = (SmallDart)this.darts.elementAt(j);
			SmallImage.drawSmallImage(g, (int)this.info.tail[smallDart2.index], smallDart2.x, smallDart2.y, 0, 3);
		}
		SmallImage.drawSmallImage(g, (int)this.info.head[num3][num2], this.x, this.y, transform, 3);
		for (int k = 0; k < this.darts.size(); k++)
		{
			SmallDart smallDart3 = (SmallDart)this.darts.elementAt(k);
			if (Res.abs(MonsterDart.r.nextInt(100)) < (int)this.info.xdPercent)
			{
				SmallImage.drawSmallImage(g, (int)((GameCanvas.gameTick % 2 != 0) ? this.info.xd2[smallDart3.index] : this.info.xd1[smallDart3.index]), smallDart3.x, smallDart3.y, 0, 3);
			}
		}
		g.setColor(16711680);
	}

	// Token: 0x04000636 RID: 1590
	public global::Char charBelong;

	// Token: 0x04000637 RID: 1591
	public DartInfo info;

	// Token: 0x04000638 RID: 1592
	public MyVector darts = new MyVector();

	// Token: 0x04000639 RID: 1593
	public int angle;

	// Token: 0x0400063A RID: 1594
	public int vx;

	// Token: 0x0400063B RID: 1595
	public int vy;

	// Token: 0x0400063C RID: 1596
	public int va;

	// Token: 0x0400063D RID: 1597
	public int x;

	// Token: 0x0400063E RID: 1598
	public int y;

	// Token: 0x0400063F RID: 1599
	public int z;

	// Token: 0x04000640 RID: 1600
	private int life;

	// Token: 0x04000641 RID: 1601
	private int dx;

	// Token: 0x04000642 RID: 1602
	private int dy;

	// Token: 0x04000643 RID: 1603
	public bool isActive = true;

	// Token: 0x04000644 RID: 1604
	public bool isSpeedUp;

	// Token: 0x04000645 RID: 1605
	public SkillPaint skillPaint;
}
