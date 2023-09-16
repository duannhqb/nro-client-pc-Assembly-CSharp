﻿using System;

// Token: 0x0200006D RID: 109
public class Npc : global::Char
{
	// Token: 0x0600037B RID: 891 RVA: 0x0001E8F0 File Offset: 0x0001CAF0
	public Npc(int npcId, int status, int cx, int cy, int templateId, int avatar)
	{
		this.isShadown = true;
		this.npcId = npcId;
		this.avatar = avatar;
		this.cx = cx;
		this.cy = cy;
		this.xSd = cx;
		this.ySd = cy;
		this.statusMe = status;
		if (npcId != -1)
		{
			this.template = Npc.arrNpcTemplate[templateId];
		}
		if (templateId == 23 || templateId == 42)
		{
			this.ch = 45;
		}
		if (templateId == 51)
		{
			this.isShadown = false;
			this.duaHauIndex = status;
		}
		if (this.template != null)
		{
			if (this.template.name == null)
			{
				this.template.name = string.Empty;
			}
			this.template.name = Res.changeString(this.template.name);
		}
	}

	// Token: 0x0600037C RID: 892 RVA: 0x0001E9D4 File Offset: 0x0001CBD4
	public void setStatus(sbyte s, int sc)
	{
		this.duaHauIndex = (int)s;
		this.last = (this.cur = mSystem.currentTimeMillis());
		this.seconds = sc;
	}

	// Token: 0x0600037D RID: 893 RVA: 0x0001EA04 File Offset: 0x0001CC04
	public static void clearEffTask()
	{
		for (int i = 0; i < GameScr.vNpc.size(); i++)
		{
			Npc npc = (Npc)GameScr.vNpc.elementAt(i);
			npc.effTask = null;
			npc.indexEffTask = -1;
		}
	}

	// Token: 0x0600037E RID: 894 RVA: 0x0001EA4C File Offset: 0x0001CC4C
	public override void update()
	{
		if (this.template.npcTemplateId == 51)
		{
			this.cur = mSystem.currentTimeMillis();
			if (this.cur - this.last >= 1000L)
			{
				this.seconds--;
				this.last = this.cur;
				if (this.seconds < 0)
				{
					this.seconds = 0;
				}
			}
		}
		if (this.isShadown)
		{
			base.updateShadown();
		}
		if (this.effTask == null)
		{
			sbyte[] array = new sbyte[]
			{
				-1,
				9,
				9,
				10,
				10,
				11,
				11
			};
			if (global::Char.myCharz().ctaskId >= 9 && global::Char.myCharz().ctaskId <= 10 && global::Char.myCharz().nClass.classId > 0 && (int)array[global::Char.myCharz().nClass.classId] == this.template.npcTemplateId)
			{
				if (global::Char.myCharz().taskMaint == null)
				{
					this.effTask = GameScr.efs[57];
					this.indexEffTask = 0;
				}
				else if (global::Char.myCharz().taskMaint != null && global::Char.myCharz().taskMaint.index + 1 == global::Char.myCharz().taskMaint.subNames.Length)
				{
					this.effTask = GameScr.efs[62];
					this.indexEffTask = 0;
				}
			}
			else
			{
				sbyte taskNpcId = GameScr.getTaskNpcId();
				if (global::Char.myCharz().taskMaint == null && (int)taskNpcId == this.template.npcTemplateId)
				{
					this.indexEffTask = 0;
				}
				else if (global::Char.myCharz().taskMaint != null && (int)taskNpcId == this.template.npcTemplateId)
				{
					if (global::Char.myCharz().taskMaint.index + 1 == global::Char.myCharz().taskMaint.subNames.Length)
					{
						this.effTask = GameScr.efs[98];
					}
					else
					{
						this.effTask = GameScr.efs[98];
					}
					this.indexEffTask = 0;
				}
			}
		}
		base.update();
		if (TileMap.mapID == 51)
		{
			if (this.cx > global::Char.myCharz().cx)
			{
				this.cdir = -1;
			}
			else
			{
				this.cdir = 1;
			}
			if (this.template.npcTemplateId % 2 == 0)
			{
				if (this.cf == 1)
				{
					this.cf = 0;
				}
				else
				{
					this.cf = 1;
				}
			}
		}
	}

	// Token: 0x0600037F RID: 895 RVA: 0x0001ECCC File Offset: 0x0001CECC
	public void paintHead(mGraphics g, int xStart, int yStart)
	{
		Part part = GameScr.parts[this.template.headId];
		if (this.cdir == 1)
		{
			SmallImage.drawSmallImage(g, (int)part.pi[global::Char.CharInfo[this.cf][0][0]].id, GameCanvas.w - 31 - g.getTranslateX(), 2 - g.getTranslateY(), 0, 0);
		}
		else
		{
			SmallImage.drawSmallImage(g, (int)part.pi[global::Char.CharInfo[this.cf][0][0]].id, GameCanvas.w - 31 - g.getTranslateX(), 2 - g.getTranslateY(), 2, 24);
		}
	}

	// Token: 0x06000380 RID: 896 RVA: 0x0001ED74 File Offset: 0x0001CF74
	public override void paint(mGraphics g)
	{
		if (global::Char.isLoadingMap)
		{
			return;
		}
		if (this.isHide)
		{
			return;
		}
		if (!base.isPaint())
		{
			return;
		}
		if (this.statusMe == 15)
		{
			return;
		}
		if ((int)this.cTypePk != 0)
		{
			base.paint(g);
			return;
		}
		if (this.template == null)
		{
			return;
		}
		if (this.template.npcTemplateId != 4 && this.template.npcTemplateId != 51 && this.template.npcTemplateId != 50)
		{
			g.drawImage(TileMap.bong, this.cx, this.cy, 3);
		}
		if (this.template.npcTemplateId == 3)
		{
			SmallImage.drawSmallImage(g, 265, this.cx, this.cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
			if (global::Char.myCharz().npcFocus != null && global::Char.myCharz().npcFocus.Equals(this))
			{
				if (ChatPopup.currChatPopup == null)
				{
					g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 0, this.cx, this.cy - this.ch + 4, mGraphics.BOTTOM | mGraphics.HCENTER);
				}
			}
			this.dyEff = 60;
		}
		else if (this.template.npcTemplateId != 4)
		{
			if (this.template.npcTemplateId == 50 || this.template.npcTemplateId == 51)
			{
				if (this.duahau != null)
				{
					if (this.template.npcTemplateId == 50 && Npc.mabuEff)
					{
						Npc.tMabuEff++;
						if (GameCanvas.gameTick % 3 == 0)
						{
							Effect me = new Effect(19, this.cx + Res.random(-50, 50), this.cy, 2, 1, -1);
							EffecMn.addEff(me);
						}
						if (GameCanvas.gameTick % 15 == 0)
						{
							Effect me2 = new Effect(18, this.cx + Res.random(-5, 5), this.cy + Res.random(-90, 0), 2, 1, -1);
							EffecMn.addEff(me2);
						}
						if (Npc.tMabuEff == 100)
						{
							GameScr.gI().activeSuperPower(this.cx, this.cy);
						}
						if (Npc.tMabuEff == 110)
						{
							Npc.mabuEff = false;
							this.template.npcTemplateId = 4;
						}
					}
					int num = 0;
					if (SmallImage.imgNew[this.duahau[this.duaHauIndex]] != null && SmallImage.imgNew[this.duahau[this.duaHauIndex]].img != null)
					{
						num = mGraphics.getImageHeight(SmallImage.imgNew[this.duahau[this.duaHauIndex]].img);
					}
					SmallImage.drawSmallImage(g, this.duahau[this.duaHauIndex], this.cx + Res.random(-1, 1), this.cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
					if (global::Char.myCharz().npcFocus != null && global::Char.myCharz().npcFocus.Equals(this))
					{
						if (ChatPopup.currChatPopup == null)
						{
							g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 0, this.cx, this.cy - this.ch - 9 + 16 - num, mGraphics.BOTTOM | mGraphics.HCENTER);
						}
						mFont.tahoma_7b_white.drawString(g, NinjaUtil.getTime(this.seconds), this.cx, this.cy - this.ch - 16 - mFont.tahoma_7.getHeight() - 20 - num + 16, mFont.CENTER, mFont.tahoma_7b_dark);
					}
					else
					{
						mFont.tahoma_7b_white.drawString(g, NinjaUtil.getTime(this.seconds), this.cx, this.cy - this.ch - 8 - mFont.tahoma_7.getHeight() - 20 - num + 16, mFont.CENTER, mFont.tahoma_7b_dark);
					}
				}
			}
			else if (this.template.npcTemplateId == 6)
			{
				SmallImage.drawSmallImage(g, 545, this.cx, this.cy + 5, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
				if (global::Char.myCharz().npcFocus != null && global::Char.myCharz().npcFocus.Equals(this))
				{
					if (ChatPopup.currChatPopup == null)
					{
						g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 0, this.cx, this.cy - this.ch - 9, mGraphics.BOTTOM | mGraphics.HCENTER);
					}
				}
				mFont.tahoma_7b_white.drawString(g, TileMap.zoneID + string.Empty, this.cx, this.cy - this.ch + 19 - mFont.tahoma_7.getHeight(), mFont.CENTER);
			}
			else
			{
				int headId = this.template.headId;
				int legId = this.template.legId;
				int bodyId = this.template.bodyId;
				Part part = GameScr.parts[headId];
				Part part2 = GameScr.parts[legId];
				Part part3 = GameScr.parts[bodyId];
				if (this.cdir == 1)
				{
					SmallImage.drawSmallImage(g, (int)part.pi[global::Char.CharInfo[this.cf][0][0]].id, this.cx + global::Char.CharInfo[this.cf][0][1] + (int)part.pi[global::Char.CharInfo[this.cf][0][0]].dx, this.cy - global::Char.CharInfo[this.cf][0][2] + (int)part.pi[global::Char.CharInfo[this.cf][0][0]].dy, 0, 0);
					SmallImage.drawSmallImage(g, (int)part2.pi[global::Char.CharInfo[this.cf][1][0]].id, this.cx + global::Char.CharInfo[this.cf][1][1] + (int)part2.pi[global::Char.CharInfo[this.cf][1][0]].dx, this.cy - global::Char.CharInfo[this.cf][1][2] + (int)part2.pi[global::Char.CharInfo[this.cf][1][0]].dy, 0, 0);
					SmallImage.drawSmallImage(g, (int)part3.pi[global::Char.CharInfo[this.cf][2][0]].id, this.cx + global::Char.CharInfo[this.cf][2][1] + (int)part3.pi[global::Char.CharInfo[this.cf][2][0]].dx, this.cy - global::Char.CharInfo[this.cf][2][2] + (int)part3.pi[global::Char.CharInfo[this.cf][2][0]].dy, 0, 0);
				}
				else
				{
					SmallImage.drawSmallImage(g, (int)part.pi[global::Char.CharInfo[this.cf][0][0]].id, this.cx - global::Char.CharInfo[this.cf][0][1] - (int)part.pi[global::Char.CharInfo[this.cf][0][0]].dx, this.cy - global::Char.CharInfo[this.cf][0][2] + (int)part.pi[global::Char.CharInfo[this.cf][0][0]].dy, 2, 24);
					SmallImage.drawSmallImage(g, (int)part2.pi[global::Char.CharInfo[this.cf][1][0]].id, this.cx - global::Char.CharInfo[this.cf][1][1] - (int)part2.pi[global::Char.CharInfo[this.cf][1][0]].dx, this.cy - global::Char.CharInfo[this.cf][1][2] + (int)part2.pi[global::Char.CharInfo[this.cf][1][0]].dy, 2, 24);
					SmallImage.drawSmallImage(g, (int)part3.pi[global::Char.CharInfo[this.cf][2][0]].id, this.cx - global::Char.CharInfo[this.cf][2][1] - (int)part3.pi[global::Char.CharInfo[this.cf][2][0]].dx, this.cy - global::Char.CharInfo[this.cf][2][2] + (int)part3.pi[global::Char.CharInfo[this.cf][2][0]].dy, 2, 24);
				}
				if (TileMap.mapID != 51)
				{
					int num2 = 15;
					if (this.template.npcTemplateId == 47)
					{
						num2 = 47;
					}
					if (global::Char.myCharz().npcFocus != null && global::Char.myCharz().npcFocus.Equals(this))
					{
						if (ChatPopup.currChatPopup == null)
						{
							g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 0, this.cx, this.cy - this.ch - (num2 - 8), mGraphics.BOTTOM | mGraphics.HCENTER);
						}
					}
					else if (this.template.npcTemplateId == 47)
					{
					}
				}
				this.dyEff = 65;
			}
		}
		if (this.indexEffTask >= 0 && this.effTask != null && (int)this.cTypePk == 0)
		{
			SmallImage.drawSmallImage(g, this.effTask.arrEfInfo[this.indexEffTask].idImg, this.cx + this.effTask.arrEfInfo[this.indexEffTask].dx, this.cy + this.effTask.arrEfInfo[this.indexEffTask].dy - this.dyEff, 0, mGraphics.VCENTER | mGraphics.HCENTER);
			if (GameCanvas.gameTick % 2 == 0)
			{
				this.indexEffTask++;
				if (this.indexEffTask >= this.effTask.arrEfInfo.Length)
				{
					this.indexEffTask = 0;
				}
			}
		}
	}

	// Token: 0x06000381 RID: 897 RVA: 0x0001F780 File Offset: 0x0001D980
	public new void paintName(mGraphics g)
	{
		if (global::Char.isLoadingMap)
		{
			return;
		}
		if (this.isHide)
		{
			return;
		}
		if (!base.isPaint())
		{
			return;
		}
		if (this.statusMe == 15)
		{
			return;
		}
		if (this.template == null)
		{
			return;
		}
		if (this.template.npcTemplateId == 3)
		{
			if (global::Char.myCharz().npcFocus != null && global::Char.myCharz().npcFocus.Equals(this))
			{
				mFont.tahoma_7_yellow.drawString(g, this.template.name, this.cx, this.cy - this.ch - mFont.tahoma_7.getHeight() - 5, mFont.CENTER, mFont.tahoma_7_grey);
			}
			else
			{
				mFont.tahoma_7_yellow.drawString(g, this.template.name, this.cx, this.cy - this.ch - 3 - mFont.tahoma_7.getHeight(), mFont.CENTER, mFont.tahoma_7_grey);
			}
			this.dyEff = 60;
		}
		else if (this.template.npcTemplateId != 4)
		{
			if (this.template.npcTemplateId == 50 || this.template.npcTemplateId == 51)
			{
				if (this.duahau != null)
				{
					int num = 0;
					if (SmallImage.imgNew[this.duahau[this.duaHauIndex]] != null && SmallImage.imgNew[this.duahau[this.duaHauIndex]].img != null)
					{
						num = mGraphics.getImageHeight(SmallImage.imgNew[this.duahau[this.duaHauIndex]].img);
					}
					if (global::Char.myCharz().npcFocus != null && global::Char.myCharz().npcFocus.Equals(this))
					{
						mFont.tahoma_7_yellow.drawString(g, this.template.name, this.cx, this.cy - this.ch - mFont.tahoma_7.getHeight() - num, mFont.CENTER, mFont.tahoma_7_grey);
					}
					else
					{
						mFont.tahoma_7_yellow.drawString(g, this.template.name, this.cx, this.cy - this.ch - 8 - mFont.tahoma_7.getHeight() - num + 16, mFont.CENTER, mFont.tahoma_7_grey);
					}
				}
			}
			else if (this.template.npcTemplateId == 6)
			{
				if (global::Char.myCharz().npcFocus != null && global::Char.myCharz().npcFocus.Equals(this))
				{
					mFont.tahoma_7_yellow.drawString(g, this.template.name, this.cx, this.cy - this.ch - mFont.tahoma_7.getHeight() - 16, mFont.CENTER, mFont.tahoma_7_grey);
				}
				else
				{
					mFont.tahoma_7_yellow.drawString(g, this.template.name, this.cx, this.cy - this.ch - 8 - mFont.tahoma_7.getHeight(), mFont.CENTER, mFont.tahoma_7_grey);
				}
			}
			else
			{
				if (TileMap.mapID != 51)
				{
					int num2 = 15;
					if (this.template.npcTemplateId == 47)
					{
						num2 = 47;
					}
					if (global::Char.myCharz().npcFocus != null && global::Char.myCharz().npcFocus.Equals(this))
					{
						if (TileMap.mapID != 113)
						{
							mFont.tahoma_7_yellow.drawString(g, this.template.name, this.cx, this.cy - this.ch - mFont.tahoma_7.getHeight() - num2, mFont.CENTER, mFont.tahoma_7_grey);
						}
					}
					else
					{
						num2 = 8;
						if (this.template.npcTemplateId == 47)
						{
							num2 = 40;
						}
						if (TileMap.mapID != 113)
						{
							mFont.tahoma_7_yellow.drawString(g, this.template.name, this.cx, this.cy - this.ch - num2 - mFont.tahoma_7.getHeight(), mFont.CENTER, mFont.tahoma_7_grey);
						}
					}
				}
				this.dyEff = 65;
			}
		}
	}

	// Token: 0x06000382 RID: 898 RVA: 0x0000552A File Offset: 0x0000372A
	public new void hide()
	{
		this.statusMe = 15;
		global::Char.chatPopup = null;
	}

	// Token: 0x040005F9 RID: 1529
	public const sbyte BINH_KHI = 0;

	// Token: 0x040005FA RID: 1530
	public const sbyte PHONG_CU = 1;

	// Token: 0x040005FB RID: 1531
	public const sbyte TRANG_SUC = 2;

	// Token: 0x040005FC RID: 1532
	public const sbyte DUOC_PHAM = 3;

	// Token: 0x040005FD RID: 1533
	public const sbyte TAP_HOA = 4;

	// Token: 0x040005FE RID: 1534
	public const sbyte THU_KHO = 5;

	// Token: 0x040005FF RID: 1535
	public const sbyte DA_LUYEN = 6;

	// Token: 0x04000600 RID: 1536
	public NpcTemplate template;

	// Token: 0x04000601 RID: 1537
	public int npcId;

	// Token: 0x04000602 RID: 1538
	public bool isFocus = true;

	// Token: 0x04000603 RID: 1539
	public static NpcTemplate[] arrNpcTemplate;

	// Token: 0x04000604 RID: 1540
	public int sys;

	// Token: 0x04000605 RID: 1541
	public bool isHide;

	// Token: 0x04000606 RID: 1542
	private int duaHauIndex;

	// Token: 0x04000607 RID: 1543
	private int dyEff;

	// Token: 0x04000608 RID: 1544
	public static bool mabuEff;

	// Token: 0x04000609 RID: 1545
	public static int tMabuEff;

	// Token: 0x0400060A RID: 1546
	private static int[] shock_x = new int[]
	{
		1,
		-1,
		1,
		-1
	};

	// Token: 0x0400060B RID: 1547
	private static int[] shock_y = new int[]
	{
		1,
		-1,
		-1,
		1
	};

	// Token: 0x0400060C RID: 1548
	public static int shock_scr;

	// Token: 0x0400060D RID: 1549
	public int[] duahau;

	// Token: 0x0400060E RID: 1550
	public new int seconds;

	// Token: 0x0400060F RID: 1551
	public new long last;

	// Token: 0x04000610 RID: 1552
	public new long cur;

	// Token: 0x04000611 RID: 1553
	public int idItem;
}
