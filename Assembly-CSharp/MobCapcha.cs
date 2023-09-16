﻿using System;

// Token: 0x02000069 RID: 105
public class MobCapcha
{
	// Token: 0x06000373 RID: 883 RVA: 0x000054DE File Offset: 0x000036DE
	public static void init()
	{
		MobCapcha.imgMob = GameCanvas.loadImage("/mainImage/myTexture2dmobCapcha.png");
	}

	// Token: 0x06000374 RID: 884 RVA: 0x0001E5F0 File Offset: 0x0001C7F0
	public static void paint(mGraphics g, int x, int y)
	{
		if (!MobCapcha.isAttack)
		{
			if (GameCanvas.gameTick % 3 == 0)
			{
				if (global::Char.myCharz().cdir == 1)
				{
					MobCapcha.cmtoX = x - 20 - GameScr.cmx;
				}
				if (global::Char.myCharz().cdir == -1)
				{
					MobCapcha.cmtoX = x + 20 - GameScr.cmx;
				}
			}
			MobCapcha.cmtoY = global::Char.myCharz().cy - 40 - GameScr.cmy;
		}
		else
		{
			MobCapcha.delay++;
			if (MobCapcha.delay == 5)
			{
				MobCapcha.isAttack = false;
				MobCapcha.delay = 0;
			}
			MobCapcha.cmtoX = x - GameScr.cmx;
			MobCapcha.cmtoY = y - GameScr.cmy;
		}
		if (MobCapcha.cmx > x - GameScr.cmx)
		{
			MobCapcha.dir = -1;
		}
		else
		{
			MobCapcha.dir = 1;
		}
		g.drawImage(GameScr.imgCapcha, MobCapcha.cmx, MobCapcha.cmy - 40, 3);
		PopUp.paintPopUp(g, MobCapcha.cmx - 25, MobCapcha.cmy - 70, 50, 20, 16777215, false);
		mFont.tahoma_7b_dark.drawString(g, GameScr.gI().keyInput, MobCapcha.cmx, MobCapcha.cmy - 65, 2);
		if (MobCapcha.isCreateMob)
		{
			MobCapcha.isCreateMob = false;
			EffecMn.addEff(new Effect(18, MobCapcha.cmx + GameScr.cmx, MobCapcha.cmy + GameScr.cmy, 2, 10, -1));
		}
		if (MobCapcha.explode)
		{
			MobCapcha.explode = false;
			EffecMn.addEff(new Effect(18, MobCapcha.cmx + GameScr.cmx, MobCapcha.cmy + GameScr.cmy, 2, 10, -1));
			GameScr.gI().mobCapcha = null;
			MobCapcha.cmtoX = -GameScr.cmx;
			MobCapcha.cmtoY = -GameScr.cmy;
		}
		g.drawRegion(MobCapcha.imgMob, 0, MobCapcha.f * 40, 40, 40, (MobCapcha.dir != 1) ? 2 : 0, MobCapcha.cmx, MobCapcha.cmy + 3 + ((GameCanvas.gameTick % 10 <= 5) ? 0 : 1), 3);
		MobCapcha.moveCamera();
	}

	// Token: 0x06000375 RID: 885 RVA: 0x0001E808 File Offset: 0x0001CA08
	public static void moveCamera()
	{
		if (MobCapcha.cmy != MobCapcha.cmtoY)
		{
			MobCapcha.cmvy = MobCapcha.cmtoY - MobCapcha.cmy << 2;
			MobCapcha.cmdy += MobCapcha.cmvy;
			MobCapcha.cmy += MobCapcha.cmdy >> 4;
			MobCapcha.cmdy &= 15;
		}
		if (MobCapcha.cmx != MobCapcha.cmtoX)
		{
			MobCapcha.cmvx = MobCapcha.cmtoX - MobCapcha.cmx << 2;
			MobCapcha.cmdx += MobCapcha.cmvx;
			MobCapcha.cmx += MobCapcha.cmdx >> 4;
			MobCapcha.cmdx &= 15;
		}
		MobCapcha.tF++;
		if (MobCapcha.tF == 5)
		{
			MobCapcha.tF = 0;
			MobCapcha.f++;
			if (MobCapcha.f > 2)
			{
				MobCapcha.f = 0;
			}
		}
	}

	// Token: 0x040005D6 RID: 1494
	public static Image imgMob;

	// Token: 0x040005D7 RID: 1495
	public static int cmtoY;

	// Token: 0x040005D8 RID: 1496
	public static int cmy;

	// Token: 0x040005D9 RID: 1497
	public static int cmdy;

	// Token: 0x040005DA RID: 1498
	public static int cmvy;

	// Token: 0x040005DB RID: 1499
	public static int cmyLim;

	// Token: 0x040005DC RID: 1500
	public static int cmtoX;

	// Token: 0x040005DD RID: 1501
	public static int cmx;

	// Token: 0x040005DE RID: 1502
	public static int cmdx;

	// Token: 0x040005DF RID: 1503
	public static int cmvx;

	// Token: 0x040005E0 RID: 1504
	public static int cmxLim;

	// Token: 0x040005E1 RID: 1505
	public static bool explode;

	// Token: 0x040005E2 RID: 1506
	public static int delay;

	// Token: 0x040005E3 RID: 1507
	public static bool isCreateMob;

	// Token: 0x040005E4 RID: 1508
	public static int tF;

	// Token: 0x040005E5 RID: 1509
	public static int f;

	// Token: 0x040005E6 RID: 1510
	public static int dir;

	// Token: 0x040005E7 RID: 1511
	public static bool isAttack;
}
