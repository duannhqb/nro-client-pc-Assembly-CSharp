using System;

// Token: 0x0200005A RID: 90
public class Hint
{
	// Token: 0x060002ED RID: 749 RVA: 0x000050BC File Offset: 0x000032BC
	public static bool isOnTask(int tastId, int index)
	{
		return global::Char.myCharz().taskMaint != null && (int)global::Char.myCharz().taskMaint.taskId == tastId && global::Char.myCharz().taskMaint.index == index;
	}

	// Token: 0x060002EE RID: 750 RVA: 0x0001AA3C File Offset: 0x00018C3C
	public static bool isPaintz()
	{
		return (!Hint.isOnTask(0, 3) || GameCanvas.panel.currentTabIndex != 0 || (GameCanvas.panel.cmy >= 0 && GameCanvas.panel.cmy <= 30)) && (!Hint.isOnTask(2, 0) || !GameCanvas.panel.isShow || GameCanvas.panel.currentTabIndex == 0);
	}

	// Token: 0x060002EF RID: 751 RVA: 0x0001AAB4 File Offset: 0x00018CB4
	public static void clickNpc()
	{
		if (GameCanvas.panel.isShow)
		{
			Hint.isPaint = false;
		}
		if (GameScr.getNpcTask() != null)
		{
			Hint.x = GameScr.getNpcTask().cx;
			Hint.y = GameScr.getNpcTask().cy;
			Hint.trans = 0;
			Hint.isCamera = true;
			Hint.type = ((!GameCanvas.isTouch) ? 0 : 1);
		}
	}

	// Token: 0x060002F0 RID: 752 RVA: 0x0001AB20 File Offset: 0x00018D20
	public static void nextMap(int index)
	{
		if (GameCanvas.panel.isShow)
		{
			return;
		}
		if (PopUp.vPopups.size() - 1 < index)
		{
			return;
		}
		PopUp popUp = (PopUp)PopUp.vPopups.elementAt(index);
		Hint.x = popUp.cx + popUp.sayWidth / 2;
		Hint.y = popUp.cy + 30;
		if (popUp.isHide || !popUp.isPaint)
		{
			Hint.isPaint = false;
		}
		else
		{
			Hint.isPaint = true;
		}
		Hint.type = 0;
		Hint.isCamera = true;
		Hint.trans = 0;
		if (!GameCanvas.isTouch)
		{
			Hint.isPaint = false;
		}
	}

	// Token: 0x060002F1 RID: 753 RVA: 0x0001ABCC File Offset: 0x00018DCC
	public static void clickMob()
	{
		Hint.type = 1;
		if (GameCanvas.panel.isShow)
		{
			Hint.isPaint = false;
		}
		bool flag = false;
		for (int i = 0; i < GameScr.vMob.size(); i++)
		{
			Mob mob = (Mob)GameScr.vMob.elementAt(i);
			if (mob.isHintFocus)
			{
				flag = true;
				break;
			}
		}
		for (int j = 0; j < GameScr.vMob.size(); j++)
		{
			Mob mob2 = (Mob)GameScr.vMob.elementAt(j);
			if (mob2.isHintFocus)
			{
				Hint.x = mob2.x;
				Hint.y = mob2.y + 5;
				Hint.isCamera = true;
				if (mob2.status == 0)
				{
					mob2.isHintFocus = false;
				}
				break;
			}
			if (!flag)
			{
				if (mob2.status != 0)
				{
					mob2.isHintFocus = true;
					break;
				}
				mob2.isHintFocus = false;
			}
		}
	}

	// Token: 0x060002F2 RID: 754 RVA: 0x0001ACD4 File Offset: 0x00018ED4
	public static bool isHaveItem()
	{
		if (GameCanvas.panel.isShow)
		{
			Hint.isPaint = false;
		}
		for (int i = 0; i < GameScr.vItemMap.size(); i++)
		{
			ItemMap itemMap = (ItemMap)GameScr.vItemMap.elementAt(i);
			if (itemMap.playerId == global::Char.myCharz().charID && itemMap.template.id == 73)
			{
				Hint.type = 1;
				Hint.x = itemMap.x;
				Hint.y = itemMap.y + 5;
				Hint.isCamera = true;
				return true;
			}
		}
		return false;
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x0001AD70 File Offset: 0x00018F70
	public static void paintArrowPointToHint(mGraphics g)
	{
		try
		{
			if (Hint.isPaintArrow)
			{
				if (Hint.x <= GameScr.cmx || Hint.x >= GameScr.cmx + GameScr.gW || Hint.y <= GameScr.cmy || Hint.y >= GameScr.cmy + GameScr.gH)
				{
					if (GameCanvas.gameTick % 10 >= 5)
					{
						if (ChatPopup.currChatPopup == null)
						{
							if (ChatPopup.serverChatPopUp == null)
							{
								if (!GameCanvas.panel.isShow)
								{
									if (Hint.isCamera)
									{
										int num = Hint.x - global::Char.myCharz().cx;
										int num2 = Hint.y - global::Char.myCharz().cy;
										int num3 = 0;
										int num4 = 0;
										int arg = 0;
										if (num > 0 && num2 >= 0)
										{
											if (Res.abs(num) >= Res.abs(num2))
											{
												num3 = GameScr.gW - 10;
												num4 = GameScr.gH / 2 + 30;
												if (GameCanvas.isTouch)
												{
													num4 = GameScr.gH / 2 + 10;
												}
												arg = 0;
											}
											else
											{
												num3 = GameScr.gW / 2;
												num4 = GameScr.gH - 10;
												arg = 5;
											}
										}
										else if (num >= 0 && num2 < 0)
										{
											if (Res.abs(num) >= Res.abs(num2))
											{
												num3 = GameScr.gW - 10;
												num4 = GameScr.gH / 2 + 30;
												if (GameCanvas.isTouch)
												{
													num4 = GameScr.gH / 2 + 10;
												}
												arg = 0;
											}
											else
											{
												num3 = GameScr.gW / 2;
												num4 = 10;
												arg = 6;
											}
										}
										if (num < 0 && num2 >= 0)
										{
											if (Res.abs(num) >= Res.abs(num2))
											{
												num3 = 10;
												num4 = GameScr.gH / 2 + 30;
												if (GameCanvas.isTouch)
												{
													num4 = GameScr.gH / 2 + 10;
												}
												arg = 3;
											}
											else
											{
												num3 = GameScr.gW / 2;
												num4 = GameScr.gH - 10;
												arg = 5;
											}
										}
										else if (num <= 0 && num2 < 0)
										{
											if (Res.abs(num) >= Res.abs(num2))
											{
												num3 = 10;
												num4 = GameScr.gH / 2 + 30;
												if (GameCanvas.isTouch)
												{
													num4 = GameScr.gH / 2 + 10;
												}
												arg = 3;
											}
											else
											{
												num3 = GameScr.gW / 2;
												num4 = 10;
												arg = 6;
											}
										}
										GameScr.resetTranslate(g);
										g.drawRegion(GameScr.arrow, 0, 0, 13, 16, arg, num3, num4, StaticObj.VCENTER_HCENTER);
									}
								}
							}
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060002F4 RID: 756 RVA: 0x0001B020 File Offset: 0x00019220
	public static void paint(mGraphics g)
	{
		if (ChatPopup.serverChatPopUp != null)
		{
			return;
		}
		if (global::Char.myCharz().isUsePlane || global::Char.myCharz().isTeleport)
		{
			return;
		}
		Hint.paintArrowPointToHint(g);
		if (GameCanvas.menu.tDelay != 0)
		{
			return;
		}
		if (!Hint.isPaint)
		{
			return;
		}
		if (ChatPopup.scr != null)
		{
			return;
		}
		if (global::Char.ischangingMap)
		{
			return;
		}
		if (GameCanvas.currentScreen != GameScr.gI())
		{
			return;
		}
		if (GameCanvas.panel.isShow && GameCanvas.panel.cmx != 0)
		{
			return;
		}
		if (Hint.isCamera)
		{
			g.translate(-GameScr.cmx, -GameScr.cmy);
		}
		if (Hint.trans == 0)
		{
			g.drawImage(Panel.imgBantay, Hint.x - 15, Hint.y, 0);
		}
		if (Hint.trans == 1)
		{
			g.drawRegion(Panel.imgBantay, 0, 0, 14, 16, 2, Hint.x + 15, Hint.y, StaticObj.TOP_RIGHT);
		}
		if (Hint.paintFlare)
		{
			g.drawImage(ItemMap.imageFlare, Hint.x, Hint.y, 3);
		}
	}

	// Token: 0x060002F5 RID: 757 RVA: 0x0001B14C File Offset: 0x0001934C
	public static void hint()
	{
		if (global::Char.myCharz().taskMaint != null && GameCanvas.currentScreen == GameScr.instance)
		{
			int taskId = (int)global::Char.myCharz().taskMaint.taskId;
			int index = global::Char.myCharz().taskMaint.index;
			Hint.isCamera = false;
			Hint.trans = 0;
			Hint.type = 0;
			Hint.isPaint = true;
			Hint.isPaintArrow = true;
			if (GameCanvas.menu.showMenu && taskId > 0)
			{
				Hint.isPaint = false;
			}
			switch (taskId)
			{
			case 0:
				if (ChatPopup.currChatPopup != null || global::Char.myCharz().statusMe == 14)
				{
					Hint.x = GameCanvas.w / 2;
					Hint.y = GameCanvas.h - 15;
				}
				else
				{
					if (index == 0 && TileMap.vGo.size() != 0)
					{
						Hint.x = (int)(((Waypoint)TileMap.vGo.elementAt(0)).minX - 100);
						Hint.y = (int)(((Waypoint)TileMap.vGo.elementAt(0)).minY + 40);
						Hint.isCamera = true;
					}
					if (index == 1)
					{
						Hint.nextMap(0);
					}
					if (index == 2)
					{
						Hint.clickNpc();
					}
					if (index == 3)
					{
						if (!GameCanvas.panel.isShow)
						{
							Hint.clickNpc();
						}
						else if (GameCanvas.panel.currentTabIndex == 0)
						{
							if (GameCanvas.panel.cp == null)
							{
								Hint.x = GameCanvas.panel.xScroll + GameCanvas.panel.wScroll / 2;
								Hint.y = GameCanvas.panel.yScroll + 20;
							}
							else if (GameCanvas.menu.tDelay != 0)
							{
								Hint.x = GameCanvas.panel.xScroll + 25;
								Hint.y = GameCanvas.panel.yScroll + 60;
							}
						}
						else if (GameCanvas.panel.currentTabIndex == 1)
						{
							Hint.x = GameCanvas.panel.startTabPos + 10;
							Hint.y = 65;
						}
					}
					if (index == 4)
					{
						if (GameCanvas.panel.isShow)
						{
							Hint.x = GameCanvas.panel.cmdClose.x + 5;
							Hint.y = GameCanvas.panel.cmdClose.y + 5;
						}
						else if (GameCanvas.menu.showMenu)
						{
							Hint.x = GameCanvas.w / 2;
							Hint.y = GameCanvas.h - 20;
						}
						else
						{
							Hint.clickNpc();
						}
					}
					if (index == 5)
					{
						Hint.clickNpc();
					}
				}
				break;
			case 1:
				if (ChatPopup.currChatPopup != null || global::Char.myCharz().statusMe == 14)
				{
					Hint.x = GameCanvas.w / 2;
					Hint.y = GameCanvas.h - 15;
				}
				else
				{
					if (index == 0)
					{
						if (TileMap.isOfflineMap())
						{
							Hint.nextMap(0);
						}
						else
						{
							Hint.clickMob();
						}
					}
					if (index == 1)
					{
						if (!TileMap.isOfflineMap())
						{
							Hint.nextMap(1);
						}
						else
						{
							Hint.clickNpc();
						}
					}
				}
				break;
			case 2:
				if (ChatPopup.currChatPopup != null || global::Char.myCharz().statusMe == 14)
				{
					Hint.x = GameCanvas.w / 2;
					Hint.y = GameCanvas.h - 15;
				}
				else
				{
					if (index == 0)
					{
						if (!TileMap.isOfflineMap())
						{
							Hint.isViewMap = true;
						}
						if (!GameCanvas.panel.isShow)
						{
							if (!Hint.isViewMap)
							{
								Hint.x = GameScr.gI().cmdMenu.x;
								Hint.y = GameScr.gI().cmdMenu.y + 13;
								Hint.trans = 1;
							}
							else
							{
								if (GameScr.getTaskMapId() == TileMap.mapID)
								{
									if (!Hint.isHaveItem())
									{
										Hint.clickMob();
									}
								}
								else
								{
									Hint.nextMap(0);
								}
								if (Hint.isViewMap)
								{
									Hint.isCloseMap = true;
								}
							}
						}
						else if (!Hint.isViewMap)
						{
							if (GameCanvas.panel.currentTabIndex == 0)
							{
								int num = (GameCanvas.h <= 300) ? 10 : 15;
								Hint.x = GameCanvas.panel.xScroll + GameCanvas.panel.wScroll / 2;
								Hint.y = GameCanvas.panel.yScroll + GameCanvas.panel.hScroll - num;
							}
							else
							{
								Hint.x = GameCanvas.panel.startTabPos + 10;
								Hint.y = 65;
							}
						}
						else if (!Hint.isCloseMap)
						{
							Hint.x = GameCanvas.panel.cmdClose.x + 5;
							Hint.y = GameCanvas.panel.cmdClose.y + 5;
						}
						else
						{
							Hint.isPaint = false;
						}
						if (global::Char.myCharz().cMP <= 0)
						{
							Hint.x = GameScr.xHP + 5;
							Hint.y = GameScr.yHP + 13;
							Hint.isCamera = false;
						}
					}
					if (index == 1)
					{
						Hint.isPaint = false;
						Hint.isPaintArrow = false;
					}
				}
				break;
			default:
				if (global::Char.myCharz().taskMaint.taskId == 9 && global::Char.myCharz().taskMaint.index == 2)
				{
					for (int i = 0; i < PopUp.vPopups.size(); i++)
					{
						PopUp popUp = (PopUp)PopUp.vPopups.elementAt(i);
						if (popUp.cy <= 24)
						{
							Hint.x = popUp.cx + popUp.sayWidth / 2;
							Hint.y = popUp.cy + 30;
							Hint.isCamera = true;
							Hint.isPaint = false;
							Hint.isPaintArrow = true;
							return;
						}
					}
				}
				Hint.isPaint = false;
				Hint.isPaintArrow = false;
				break;
			}
		}
		else
		{
			Hint.isPaint = false;
			Hint.isPaintArrow = false;
		}
	}

	// Token: 0x060002F6 RID: 758 RVA: 0x0001B71C File Offset: 0x0001991C
	public static void update()
	{
		Hint.hint();
		int num = (Hint.trans != 0) ? -2 : 2;
		if (!Hint.activeClick)
		{
			Hint.paintFlare = false;
			Hint.t++;
			if (Hint.t == 50)
			{
				Hint.t = 0;
				Hint.activeClick = true;
			}
		}
		else
		{
			Hint.t++;
			if (Hint.type == 0)
			{
				if (Hint.t == 2)
				{
					Hint.x += 2 * num;
					Hint.y -= 4;
					Hint.paintFlare = true;
				}
				if (Hint.t == 4)
				{
					Hint.x -= 2 * num;
					Hint.y += 4;
					Hint.activeClick = false;
					Hint.paintFlare = false;
					Hint.t = 0;
				}
				if (Hint.t > 4)
				{
					Hint.activeClick = false;
				}
			}
			if (Hint.type == 1)
			{
				if (Hint.t == 2)
				{
					if (GameCanvas.isTouch)
					{
						GameScr.startFlyText(mResources.press_twice, Hint.x, Hint.y + 10, 0, 20, mFont.MISS_ME);
					}
					Hint.paintFlare = true;
					Hint.x += 2 * num;
					Hint.y -= 4;
				}
				if (Hint.t == 4)
				{
					Hint.paintFlare = false;
					Hint.x -= num;
					Hint.y += 2;
				}
				if (Hint.t == 6)
				{
					Hint.paintFlare = true;
					Hint.x += num;
					Hint.y -= 2;
				}
				if (Hint.t == 8)
				{
					Hint.paintFlare = false;
					Hint.x -= num;
					Hint.y += 2;
				}
				if (Hint.t == 10)
				{
					Hint.x -= num;
					Hint.y += 2;
					Hint.activeClick = false;
					Hint.t = 0;
				}
			}
		}
	}

	// Token: 0x040004D8 RID: 1240
	public static int x;

	// Token: 0x040004D9 RID: 1241
	public static int y;

	// Token: 0x040004DA RID: 1242
	public static int type;

	// Token: 0x040004DB RID: 1243
	public static int t;

	// Token: 0x040004DC RID: 1244
	public static int xF;

	// Token: 0x040004DD RID: 1245
	public static int yF;

	// Token: 0x040004DE RID: 1246
	public static bool isShow;

	// Token: 0x040004DF RID: 1247
	public static bool activeClick;

	// Token: 0x040004E0 RID: 1248
	public static bool isViewMap;

	// Token: 0x040004E1 RID: 1249
	public static bool isCloseMap;

	// Token: 0x040004E2 RID: 1250
	public static bool isPaint;

	// Token: 0x040004E3 RID: 1251
	public static bool isCamera;

	// Token: 0x040004E4 RID: 1252
	public static int trans;

	// Token: 0x040004E5 RID: 1253
	public static bool paintFlare;

	// Token: 0x040004E6 RID: 1254
	public static bool isPaintArrow;

	// Token: 0x040004E7 RID: 1255
	private int s = 2;
}
