using System;
using Assets.src.g;
using UnityEngine;

// Token: 0x020000B4 RID: 180
public class Panel : IActionListener, IChatable
{
	// Token: 0x060007EB RID: 2027 RVA: 0x0006D33C File Offset: 0x0006B53C
	public Panel()
	{
		this.init();
		this.cmdClose = new Command(string.Empty, this, 1003, null);
		this.cmdClose.img = GameCanvas.loadImage("/mainImage/myTexture2dbtX.png");
		this.cmdClose.cmdClosePanel = true;
	}

	// Token: 0x060007EC RID: 2028 RVA: 0x0006D708 File Offset: 0x0006B908
	public static void loadBg()
	{
		Panel.imgMap = GameCanvas.loadImage("/img/map" + TileMap.planetID + ".png");
		Panel.imgBantay = GameCanvas.loadImage("/mainImage/myTexture2dbantay.png");
		Panel.imgX = GameCanvas.loadImage("/mainImage/myTexture2dbtX.png");
		Panel.imgXu = GameCanvas.loadImage("/mainImage/myTexture2dimgMoney.png");
		Panel.imgLuong = GameCanvas.loadImage("/mainImage/myTexture2dimgDiamond.png");
		Panel.imgLuongKhoa = GameCanvas.loadImage("/mainImage/luongkhoa.png");
		Panel.imgUp = GameCanvas.loadImage("/mainImage/myTexture2dup.png");
		Panel.imgDown = GameCanvas.loadImage("/mainImage/myTexture2ddown.png");
		Panel.imgStar = GameCanvas.loadImage("/mainImage/star.png");
		Panel.imgMaxStar = GameCanvas.loadImage("/mainImage/starE.png");
		Panel.imgNew = GameCanvas.loadImage("/mainImage/new.png");
		Panel.imgTicket = GameCanvas.loadImage("/mainImage/ticket12.png");
	}

	// Token: 0x060007ED RID: 2029 RVA: 0x0006D7E0 File Offset: 0x0006B9E0
	public void init()
	{
		this.pX = GameCanvas.pxLast + this.cmxMap;
		this.pY = GameCanvas.pyLast + this.cmyMap;
		this.lastTabIndex = new int[this.tabName.Length];
		for (int i = 0; i < this.lastTabIndex.Length; i++)
		{
			this.lastTabIndex[i] = -1;
		}
	}

	// Token: 0x060007EE RID: 2030 RVA: 0x0006D848 File Offset: 0x0006BA48
	public int getXMap()
	{
		for (int i = 0; i < Panel.mapId[(int)TileMap.planetID].Length; i++)
		{
			if (TileMap.mapID == Panel.mapId[(int)TileMap.planetID][i])
			{
				return Panel.mapX[(int)TileMap.planetID][i];
			}
		}
		return -1;
	}

	// Token: 0x060007EF RID: 2031 RVA: 0x0006D89C File Offset: 0x0006BA9C
	public int getYMap()
	{
		for (int i = 0; i < Panel.mapId[(int)TileMap.planetID].Length; i++)
		{
			if (TileMap.mapID == Panel.mapId[(int)TileMap.planetID][i])
			{
				return Panel.mapY[(int)TileMap.planetID][i];
			}
		}
		return -1;
	}

	// Token: 0x060007F0 RID: 2032 RVA: 0x0006D8F0 File Offset: 0x0006BAF0
	public int getXMapTask()
	{
		if (global::Char.myCharz().taskMaint == null)
		{
			return -1;
		}
		for (int i = 0; i < Panel.mapId[(int)TileMap.planetID].Length; i++)
		{
			if (GameScr.mapTasks[global::Char.myCharz().taskMaint.index] == Panel.mapId[(int)TileMap.planetID][i])
			{
				return Panel.mapX[(int)TileMap.planetID][i];
			}
		}
		return -1;
	}

	// Token: 0x060007F1 RID: 2033 RVA: 0x0006D968 File Offset: 0x0006BB68
	public int getYMapTask()
	{
		if (global::Char.myCharz().taskMaint == null)
		{
			return -1;
		}
		for (int i = 0; i < Panel.mapId[(int)TileMap.planetID].Length; i++)
		{
			if (GameScr.mapTasks[global::Char.myCharz().taskMaint.index] == Panel.mapId[(int)TileMap.planetID][i])
			{
				return Panel.mapY[(int)TileMap.planetID][i];
			}
		}
		return -1;
	}

	// Token: 0x060007F2 RID: 2034 RVA: 0x0006D9E0 File Offset: 0x0006BBE0
	private void setType(int position)
	{
		this.typeShop = -1;
		this.W = Panel.WIDTH_PANEL;
		this.H = GameCanvas.h;
		this.X = 0;
		this.Y = 0;
		this.ITEM_HEIGHT = 24;
		this.position = position;
		if (position == 0)
		{
			this.xScroll = 2;
			this.yScroll = 80;
			this.wScroll = this.W - 4;
			this.hScroll = this.H - 96;
			this.cmx = this.wScroll;
			this.cmtoX = 0;
			this.X = 0;
		}
		else if (position == 1)
		{
			this.wScroll = this.W - 4;
			this.xScroll = GameCanvas.w - this.wScroll;
			this.yScroll = 80;
			this.hScroll = this.H - 96;
			this.X = this.xScroll - 2;
			this.cmx = -(GameCanvas.w + this.W);
			this.cmtoX = GameCanvas.w - this.W;
		}
		this.TAB_W = this.W / 5 - 1;
		this.currentTabIndex = 0;
		this.currentTabName = this.tabName[this.type];
		if (this.currentTabName.Length < 5)
		{
			this.TAB_W += 5;
		}
		this.startTabPos = this.xScroll + this.wScroll / 2 - this.currentTabName.Length * this.TAB_W / 2;
		this.lastSelect = new int[this.currentTabName.Length];
		this.cmyLast = new int[this.currentTabName.Length];
		for (int i = 0; i < this.currentTabName.Length; i++)
		{
			this.lastSelect[i] = ((!GameCanvas.isTouch) ? 0 : -1);
		}
		if (this.lastTabIndex[this.type] != -1)
		{
			this.currentTabIndex = this.lastTabIndex[this.type];
		}
		if (this.currentTabIndex < 0)
		{
			this.currentTabIndex = 0;
		}
		if (this.currentTabIndex > this.currentTabName.Length - 1)
		{
			this.currentTabIndex = this.currentTabName.Length - 1;
		}
		this.scroll = null;
	}

	// Token: 0x060007F3 RID: 2035 RVA: 0x0006DC14 File Offset: 0x0006BE14
	public void setTypeMapTrans()
	{
		this.type = 14;
		this.setType(0);
		this.setTabMapTrans();
		this.cmx = (this.cmtoX = 0);
	}

	// Token: 0x060007F4 RID: 2036 RVA: 0x00007344 File Offset: 0x00005544
	public void setTypeInfomatioin()
	{
		this.type = 6;
		this.cmx = this.wScroll;
		this.cmtoX = 0;
	}

	// Token: 0x060007F5 RID: 2037 RVA: 0x0006DC48 File Offset: 0x0006BE48
	public void setTypeMap()
	{
		if (GameScr.gI().isMapFize())
		{
			return;
		}
		if (!Panel.isPaintMap)
		{
			return;
		}
		if (Hint.isOnTask(2, 0))
		{
			Hint.isViewMap = true;
			GameScr.info1.addInfo(mResources.go_to_quest, 0);
		}
		this.type = 4;
		this.currentTabName = this.tabName[this.type];
		this.startTabPos = this.xScroll + this.wScroll / 2 - this.currentTabName.Length * this.TAB_W / 2;
		this.cmx = (this.cmtoX = 0);
		this.setTabMap();
	}

	// Token: 0x060007F6 RID: 2038 RVA: 0x0006DCEC File Offset: 0x0006BEEC
	public void setTypeArchivement()
	{
		this.currentListLength = global::Char.myCharz().arrArchive.Length;
		this.setType(0);
		this.type = 9;
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = 0);
		}
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
	}

	// Token: 0x060007F7 RID: 2039 RVA: 0x00007360 File Offset: 0x00005560
	public void setTypeKiGuiOnly()
	{
		this.type = 17;
		this.setType(1);
		this.setTabKiGui();
		this.typeShop = 2;
		this.currentTabIndex = 0;
	}

	// Token: 0x060007F8 RID: 2040 RVA: 0x0006DDB8 File Offset: 0x0006BFB8
	public void setTabKiGui()
	{
		this.ITEM_HEIGHT = 24;
		this.currentListLength = global::Char.myCharz().arrItemShop[4].Length;
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
	}

	// Token: 0x060007F9 RID: 2041 RVA: 0x00007385 File Offset: 0x00005585
	public void setTypeBodyOnly()
	{
		this.type = 7;
		this.setType(1);
		this.setTabInventory();
		this.currentTabIndex = 0;
	}

	// Token: 0x060007FA RID: 2042 RVA: 0x000073A2 File Offset: 0x000055A2
	public void addChatMessage(InfoItem info)
	{
		this.logChat.insertElementAt(info, 0);
		if (this.logChat.size() > 20)
		{
			this.logChat.removeElementAt(this.logChat.size() - 1);
		}
	}

	// Token: 0x060007FB RID: 2043 RVA: 0x000073DB File Offset: 0x000055DB
	public void addPlayerMenu(Command pm)
	{
		this.vPlayerMenu.addElement(pm);
	}

	// Token: 0x060007FC RID: 2044 RVA: 0x0006DE84 File Offset: 0x0006C084
	public void setTabPlayerMenu()
	{
		this.ITEM_HEIGHT = 24;
		this.currentListLength = this.vPlayerMenu.size();
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
	}

	// Token: 0x060007FD RID: 2045 RVA: 0x000073E9 File Offset: 0x000055E9
	public void setTypeFlag()
	{
		this.type = 18;
		this.setType(0);
		this.ITEM_HEIGHT = 24;
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
		this.setTabFlag();
	}

	// Token: 0x060007FE RID: 2046 RVA: 0x0006DF4C File Offset: 0x0006C14C
	public void setTabFlag()
	{
		this.currentListLength = this.vFlag.size();
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
		if (this.selected > this.currentListLength - 1)
		{
			this.selected = this.currentListLength - 1;
		}
		this.cmx = (this.cmtoX = 0);
	}

	// Token: 0x060007FF RID: 2047 RVA: 0x0000741F File Offset: 0x0000561F
	public void setTypePlayerMenu(global::Char c)
	{
		this.type = 10;
		this.setType(0);
		this.setTabPlayerMenu();
		this.charMenu = c;
	}

	// Token: 0x06000800 RID: 2048 RVA: 0x0000743D File Offset: 0x0000563D
	public void setTypeFriend()
	{
		this.type = 11;
		this.setType(0);
		this.ITEM_HEIGHT = 24;
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
		this.setTabFriend();
	}

	// Token: 0x06000801 RID: 2049 RVA: 0x00007473 File Offset: 0x00005673
	public void setTypeEnemy()
	{
		this.type = 16;
		this.setType(0);
		this.ITEM_HEIGHT = 24;
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
		this.setTabEnemy();
	}

	// Token: 0x06000802 RID: 2050 RVA: 0x0006E028 File Offset: 0x0006C228
	public void setTypeTop(sbyte t)
	{
		this.type = 15;
		this.setType(0);
		this.ITEM_HEIGHT = 24;
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
		this.setTabTop();
		this.isThachDau = ((int)t != 0);
	}

	// Token: 0x06000803 RID: 2051 RVA: 0x0006E080 File Offset: 0x0006C280
	public void setTabTop()
	{
		this.currentListLength = this.vTop.size();
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
		if (this.selected > this.currentListLength - 1)
		{
			this.selected = this.currentListLength - 1;
		}
		this.cmx = (this.cmtoX = 0);
	}

	// Token: 0x06000804 RID: 2052 RVA: 0x0006E15C File Offset: 0x0006C35C
	public void setTabFriend()
	{
		this.currentListLength = this.vFriend.size();
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
		if (this.selected > this.currentListLength - 1)
		{
			this.selected = this.currentListLength - 1;
		}
		this.cmx = (this.cmtoX = 0);
	}

	// Token: 0x06000805 RID: 2053 RVA: 0x0006E238 File Offset: 0x0006C438
	public void setTabEnemy()
	{
		this.currentListLength = this.vEnemy.size();
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
		if (this.selected > this.currentListLength - 1)
		{
			this.selected = this.currentListLength - 1;
		}
		this.cmx = (this.cmtoX = 0);
	}

	// Token: 0x06000806 RID: 2054 RVA: 0x000074A9 File Offset: 0x000056A9
	public void setTypeMessage()
	{
		this.type = 8;
		this.setType(0);
		this.setTabMessage();
		this.currentTabIndex = 0;
	}

	// Token: 0x06000807 RID: 2055 RVA: 0x000074A9 File Offset: 0x000056A9
	public void setTypeLockInventory()
	{
		this.type = 8;
		this.setType(0);
		this.setTabMessage();
		this.currentTabIndex = 0;
	}

	// Token: 0x06000808 RID: 2056 RVA: 0x000074C6 File Offset: 0x000056C6
	public void setTypeShop(int typeShop)
	{
		this.type = 1;
		this.setType(0);
		this.setTabShop();
		this.currentTabIndex = 0;
		this.typeShop = typeShop;
	}

	// Token: 0x06000809 RID: 2057 RVA: 0x0006E314 File Offset: 0x0006C514
	public void setTypeBox()
	{
		this.type = 2;
		if (GameCanvas.w > 2 * Panel.WIDTH_PANEL)
		{
			Panel.boxTabName = new string[][]
			{
				mResources.chestt
			};
		}
		else
		{
			Panel.boxTabName = new string[][]
			{
				mResources.chestt,
				mResources.inventory
			};
		}
		this.tabName[2] = Panel.boxTabName;
		this.setType(0);
		if (this.currentTabIndex == 0)
		{
			this.setTabBox();
		}
		if (this.currentTabIndex == 1)
		{
			this.setTabInventory();
		}
		if (GameCanvas.w > 2 * Panel.WIDTH_PANEL)
		{
			GameCanvas.panel2 = new Panel();
			GameCanvas.panel2.tabName[7] = new string[][]
			{
				new string[]
				{
					string.Empty
				}
			};
			GameCanvas.panel2.setTypeBodyOnly();
			GameCanvas.panel2.show();
		}
	}

	// Token: 0x0600080A RID: 2058 RVA: 0x0006E3F8 File Offset: 0x0006C5F8
	public void setTypeCombine()
	{
		this.type = 12;
		if (GameCanvas.w > 2 * Panel.WIDTH_PANEL)
		{
			Panel.boxCombine = new string[][]
			{
				mResources.combine
			};
		}
		else
		{
			Panel.boxCombine = new string[][]
			{
				mResources.combine,
				mResources.inventory
			};
		}
		this.tabName[this.type] = Panel.boxCombine;
		this.setType(0);
		if (this.currentTabIndex == 0)
		{
			this.setTabCombine();
		}
		if (this.currentTabIndex == 1)
		{
			this.setTabInventory();
		}
		if (GameCanvas.w > 2 * Panel.WIDTH_PANEL)
		{
			GameCanvas.panel2 = new Panel();
			GameCanvas.panel2.tabName[7] = new string[][]
			{
				new string[]
				{
					string.Empty
				}
			};
			GameCanvas.panel2.setTypeBodyOnly();
			GameCanvas.panel2.show();
		}
		this.combineSuccess = -1;
		this.isDoneCombine = true;
	}

	// Token: 0x0600080B RID: 2059 RVA: 0x0006E4F0 File Offset: 0x0006C6F0
	public void setTabCombine()
	{
		this.currentListLength = this.vItemCombine.size() + 1;
		this.ITEM_HEIGHT = 24;
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 9;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
	}

	// Token: 0x0600080C RID: 2060 RVA: 0x0006E5BC File Offset: 0x0006C7BC
	public void setTypeAuto()
	{
		this.type = 22;
		this.setType(0);
		this.setTabAuto();
		this.cmx = (this.cmtoX = 0);
	}

	// Token: 0x0600080D RID: 2061 RVA: 0x0006E5F0 File Offset: 0x0006C7F0
	private void setTabAuto()
	{
		this.currentListLength = Panel.strAuto.Length;
		this.ITEM_HEIGHT = 24;
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
	}

	// Token: 0x0600080E RID: 2062 RVA: 0x0006E6B4 File Offset: 0x0006C8B4
	public void setTypePetMain()
	{
		this.type = 21;
		if (GameCanvas.panel2 != null)
		{
			Panel.boxPet = mResources.petMainTab2;
		}
		else
		{
			Panel.boxPet = mResources.petMainTab;
		}
		this.tabName[21] = Panel.boxPet;
		if (global::Char.myCharz().cgender == 1)
		{
			this.strStatus = new string[]
			{
				mResources.follow,
				mResources.defend,
				mResources.attack,
				mResources.gohome,
				mResources.fusion,
				mResources.fusionForever
			};
		}
		else
		{
			this.strStatus = new string[]
			{
				mResources.follow,
				mResources.defend,
				mResources.attack,
				mResources.gohome,
				mResources.fusion
			};
		}
		this.setType(2);
		if (this.currentTabIndex == 0)
		{
			this.setTabPetInventory();
		}
		if (this.currentTabIndex == 1)
		{
			this.setTabPetStatus();
		}
		if (this.currentTabIndex == 2)
		{
			this.setTabInventory();
		}
	}

	// Token: 0x0600080F RID: 2063 RVA: 0x0006E7BC File Offset: 0x0006C9BC
	public void setTypeMain()
	{
		this.type = 0;
		this.setType(0);
		if (this.currentTabIndex == 1)
		{
			this.setTabInventory();
		}
		if (this.currentTabIndex == 2)
		{
			this.setTabSkill();
		}
		if (this.currentTabIndex == 3)
		{
			if (this.mainTabName.Length == 4)
			{
				this.setTabTool();
			}
			else
			{
				this.setTabClans();
			}
		}
		if (this.currentTabIndex == 4)
		{
			this.setTabTool();
		}
	}

	// Token: 0x06000810 RID: 2064 RVA: 0x0006E838 File Offset: 0x0006CA38
	public void setTypeZone()
	{
		this.type = 3;
		this.setType(0);
		this.setTabZone();
		this.cmx = (this.cmtoX = 0);
	}

	// Token: 0x06000811 RID: 2065 RVA: 0x0006E86C File Offset: 0x0006CA6C
	public void addItemDetail(Item item)
	{
		this.cp = new ChatPopup();
		string text = string.Empty;
		string text2 = string.Empty;
		if ((int)item.template.gender != global::Char.myCharz().cgender)
		{
			if ((int)item.template.gender == 0)
			{
				text2 = text2 + "\n|7|1|" + mResources.from_earth;
			}
			else if ((int)item.template.gender == 1)
			{
				text2 = text2 + "\n|7|1|" + mResources.from_namec;
			}
			else if ((int)item.template.gender == 2)
			{
				text2 = text2 + "\n|7|1|" + mResources.from_sayda;
			}
		}
		string str = string.Empty;
		if (item.itemOption != null)
		{
			for (int i = 0; i < item.itemOption.Length; i++)
			{
				if (item.itemOption[i].optionTemplate.id == 72)
				{
					str = " [+" + item.itemOption[i].param + "]";
				}
			}
		}
		text2 = text2 + "|0|1|" + item.template.name + str;
		if (item.itemOption != null)
		{
			for (int j = 0; j < item.itemOption.Length; j++)
			{
				bool flag = item.itemOption[j].optionTemplate.name.StartsWith("$");
				if (flag)
				{
					text = item.itemOption[j].getOptiongColor();
					if (item.itemOption[j].param == 1)
					{
						text2 = text2 + "\n|1|1|" + text;
					}
					if (item.itemOption[j].param == 0)
					{
						text2 = text2 + "\n|0|1|" + text;
					}
				}
				else
				{
					text = item.itemOption[j].getOptionString();
					if (!text.Equals(string.Empty))
					{
						if (item.itemOption[j].optionTemplate.id != 72)
						{
							if (item.itemOption[j].optionTemplate.id == 102)
							{
								this.cp.starSlot = (sbyte)item.itemOption[j].param;
								Res.outz("STAR SLOT= " + this.cp.starSlot);
							}
							else if (item.itemOption[j].optionTemplate.id == 107)
							{
								this.cp.maxStarSlot = (sbyte)item.itemOption[j].param;
								Res.outz("STAR SLOT= " + this.cp.maxStarSlot);
							}
							else
							{
								text2 = text2 + "\n|1|1|" + text;
							}
						}
					}
				}
			}
		}
		if (this.currItem.template.strRequire > 1)
		{
			string str2 = mResources.pow_request + ": " + this.currItem.template.strRequire;
			if ((long)this.currItem.template.strRequire > global::Char.myCharz().cPower)
			{
				text2 = text2 + "\n|3|1|" + str2;
				string text3 = text2;
				text2 = string.Concat(new object[]
				{
					text3,
					"\n|3|1|",
					mResources.your_pow,
					": ",
					global::Char.myCharz().cPower
				});
			}
			else
			{
				text2 = text2 + "\n|6|1|" + str2;
			}
		}
		else
		{
			text2 += "\n|6|1|";
		}
		this.currItem.compare = this.getCompare(this.currItem);
		text2 += "\n--";
		text2 = text2 + "\n|6|" + item.template.description;
		if (!item.reason.Equals(string.Empty))
		{
			if (!item.template.description.Equals(string.Empty))
			{
				text2 += "\n--";
			}
			text2 = text2 + "\n|2|" + item.reason;
		}
		if ((int)this.cp.maxStarSlot > 0)
		{
			text2 += "\n\n";
		}
		this.popUpDetailInit(this.cp, text2);
		this.idIcon = (int)item.template.iconID;
		this.partID = null;
		this.charInfo = null;
	}

	// Token: 0x06000812 RID: 2066 RVA: 0x0006ECE4 File Offset: 0x0006CEE4
	public void popUpDetailInit(ChatPopup cp, string chat)
	{
		cp.isClip = false;
		cp.sayWidth = 180;
		cp.cx = 3 + this.X;
		cp.says = mFont.tahoma_7_red.splitFontArray(chat, cp.sayWidth - 10);
		cp.delay = 10000000;
		cp.c = null;
		cp.sayRun = 7;
		cp.ch = 15 - cp.sayRun + cp.says.Length * 12 + 10;
		if (cp.ch > GameCanvas.h - 80)
		{
			cp.ch = GameCanvas.h - 80;
			cp.lim = cp.says.Length * 12 - cp.ch + 17;
			if (cp.lim < 0)
			{
				cp.lim = 0;
			}
			ChatPopup.cmyText = 0;
			cp.isClip = true;
		}
		cp.cy = GameCanvas.menu.menuY - cp.ch;
		while (cp.cy < 10)
		{
			cp.cy++;
			GameCanvas.menu.menuY++;
		}
		cp.mH = 0;
		cp.strY = 10;
	}

	// Token: 0x06000813 RID: 2067 RVA: 0x0006EE18 File Offset: 0x0006D018
	public void popUpDetailInitArray(ChatPopup cp, string[] chat)
	{
		cp.sayWidth = 160;
		cp.cx = 3 + this.X;
		cp.says = chat;
		cp.delay = 10000000;
		cp.c = null;
		cp.sayRun = 7;
		cp.ch = 15 - cp.sayRun + cp.says.Length * 12 + 10;
		cp.cy = GameCanvas.menu.menuY - cp.ch;
		cp.mH = 0;
		cp.strY = 10;
	}

	// Token: 0x06000814 RID: 2068 RVA: 0x0006EEA4 File Offset: 0x0006D0A4
	public void addMessageDetail(ClanMessage cm)
	{
		this.cp = new ChatPopup();
		string text = "|0|" + cm.playerName;
		text = text + "\n|1|" + Member.getRole((int)cm.role);
		for (int i = 0; i < this.myMember.size(); i++)
		{
			Member member = (Member)this.myMember.elementAt(i);
			if (cm.playerId == member.ID)
			{
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n|5|",
					mResources.clan_capsuledonate,
					": ",
					member.clanPoint
				});
				text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n|5|",
					mResources.clan_capsuleself,
					": ",
					member.curClanPoint
				});
				text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n|4|",
					mResources.give_pea,
					": ",
					member.donate,
					mResources.time
				});
				text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n|4|",
					mResources.receive_pea,
					": ",
					member.receive_donate,
					mResources.time
				});
				this.partID = new int[]
				{
					(int)member.head,
					(int)member.leg,
					(int)member.body
				};
				break;
			}
		}
		text += "\n--";
		for (int j = 0; j < cm.chat.Length; j++)
		{
			text = text + "\n" + cm.chat[j];
		}
		if (cm.type == 1)
		{
			string text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"\n|6|",
				mResources.received,
				" ",
				cm.recieve,
				"/",
				cm.maxCap
			});
		}
		this.popUpDetailInit(this.cp, text);
		this.charInfo = null;
	}

	// Token: 0x06000815 RID: 2069 RVA: 0x0006F0EC File Offset: 0x0006D2EC
	public void addThachDauDetail(TopInfo t)
	{
		string text = "|0|1|" + t.name;
		text = text + "\n|1|Top " + t.rank;
		text = text + "\n|1|" + t.info;
		text = text + "\n|2|" + t.info2;
		this.cp = new ChatPopup();
		this.popUpDetailInit(this.cp, text);
		this.partID = new int[]
		{
			t.headID,
			(int)t.leg,
			(int)t.body
		};
		this.currItem = null;
		this.charInfo = null;
	}

	// Token: 0x06000816 RID: 2070 RVA: 0x0006F194 File Offset: 0x0006D394
	public void addClanMemberDetail(Member m)
	{
		string text = "|0|1|" + m.name;
		string str = "\n|2|1|";
		if ((int)m.role == 0)
		{
			str = "\n|7|1|";
		}
		if ((int)m.role == 1)
		{
			str = "\n|1|1|";
		}
		if ((int)m.role == 2)
		{
			str = "\n|0|1|";
		}
		text = text + str + Member.getRole((int)m.role);
		string text2 = text;
		text = string.Concat(new string[]
		{
			text2,
			"\n|2|1|",
			mResources.power,
			": ",
			m.powerPoint
		});
		text += "\n--";
		text2 = text;
		text = string.Concat(new object[]
		{
			text2,
			"\n|5|",
			mResources.clan_capsuledonate,
			": ",
			m.clanPoint
		});
		text2 = text;
		text = string.Concat(new object[]
		{
			text2,
			"\n|5|",
			mResources.clan_capsuleself,
			": ",
			m.curClanPoint
		});
		text2 = text;
		text = string.Concat(new object[]
		{
			text2,
			"\n|4|",
			mResources.give_pea,
			": ",
			m.donate,
			mResources.time
		});
		text2 = text;
		text = string.Concat(new object[]
		{
			text2,
			"\n|4|",
			mResources.receive_pea,
			": ",
			m.receive_donate,
			mResources.time
		});
		text2 = text;
		text = string.Concat(new string[]
		{
			text2,
			"\n|6|",
			mResources.join_date,
			": ",
			m.joinTime
		});
		this.cp = new ChatPopup();
		this.popUpDetailInit(this.cp, text);
		this.partID = new int[]
		{
			(int)m.head,
			(int)m.leg,
			(int)m.body
		};
		this.currItem = null;
		this.charInfo = null;
	}

	// Token: 0x06000817 RID: 2071 RVA: 0x0006F3B4 File Offset: 0x0006D5B4
	public void addClanDetail(Clan cl)
	{
		string text = "|0|" + cl.name;
		string[] array = mFont.tahoma_7_green.splitFontArray(cl.slogan, this.wScroll - 60);
		for (int i = 0; i < array.Length; i++)
		{
			text = text + "\n|2|" + array[i];
		}
		text += "\n--";
		string text2 = text;
		text = string.Concat(new string[]
		{
			text2,
			"\n|7|",
			mResources.clan_leader,
			": ",
			cl.leaderName
		});
		text2 = text;
		text = string.Concat(new string[]
		{
			text2,
			"\n|1|",
			mResources.power_point,
			": ",
			cl.powerPoint
		});
		text2 = text;
		text = string.Concat(new object[]
		{
			text2,
			"\n|4|",
			mResources.member,
			": ",
			cl.currMember,
			"/",
			cl.maxMember
		});
		text2 = text;
		text = string.Concat(new object[]
		{
			text2,
			"\n|4|",
			mResources.level,
			": ",
			cl.level
		});
		text2 = text;
		text = string.Concat(new string[]
		{
			text2,
			"\n|4|",
			mResources.clan_birthday,
			": ",
			NinjaUtil.getDate(cl.date)
		});
		this.cp = new ChatPopup();
		this.popUpDetailInit(this.cp, text);
		this.idIcon = (int)ClanImage.getClanImage((sbyte)cl.imgID).idImage[0];
		this.currItem = null;
	}

	// Token: 0x06000818 RID: 2072 RVA: 0x0006F578 File Offset: 0x0006D778
	public void addSkillDetail(SkillTemplate tp, Skill skill, Skill nextSkill)
	{
		string text = "|0|" + tp.name;
		for (int i = 0; i < tp.description.Length; i++)
		{
			text = text + "\n|4|" + tp.description[i];
		}
		text += "\n--";
		if (skill != null)
		{
			string text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"\n|2|",
				mResources.cap_do,
				": ",
				skill.point
			});
			text = text + "\n|5|" + NinjaUtil.replace(tp.damInfo, "#", skill.damage + string.Empty);
			text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"\n|5|",
				mResources.KI_consume,
				skill.manaUse,
				(tp.manaUseType != 1) ? string.Empty : "%"
			});
			text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"\n|5|",
				mResources.speed,
				": ",
				skill.coolDown,
				mResources.milisecond
			});
			text += "\n--";
			if (skill.point == tp.maxPoint)
			{
				text = text + "\n|0|" + mResources.max_level_reach;
			}
			else
			{
				text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					"\n|1|",
					mResources.next_level_require,
					Res.formatNumber(nextSkill.powRequire),
					" ",
					mResources.potential
				});
				text = text + "\n|4|" + NinjaUtil.replace(tp.damInfo, "#", nextSkill.damage + string.Empty);
			}
		}
		else
		{
			text = text + "\n|2|" + mResources.not_learn;
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"\n|1|",
				mResources.learn_require,
				Res.formatNumber(nextSkill.powRequire),
				" ",
				mResources.potential
			});
			text = text + "\n|4|" + NinjaUtil.replace(tp.damInfo, "#", nextSkill.damage + string.Empty);
			text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"\n|4|",
				mResources.KI_consume,
				nextSkill.manaUse,
				(tp.manaUseType != 1) ? string.Empty : "%"
			});
			text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"\n|4|",
				mResources.speed,
				": ",
				nextSkill.coolDown,
				mResources.milisecond
			});
		}
		this.currItem = null;
		this.partID = null;
		this.charInfo = null;
		this.cp = new ChatPopup();
		this.popUpDetailInit(this.cp, text);
		this.idIcon = 0;
	}

	// Token: 0x06000819 RID: 2073 RVA: 0x0006F8BC File Offset: 0x0006DABC
	public void show()
	{
		if (GameCanvas.isTouch)
		{
			this.cmdClose.x = 156;
			this.cmdClose.y = 3;
		}
		else
		{
			this.cmdClose.x = GameCanvas.w - 19;
			this.cmdClose.y = GameCanvas.h - 19;
		}
		this.cmdClose.isPlaySoundButton = false;
		ChatPopup.currChatPopup = null;
		InfoDlg.hide();
		this.timeShow = 20;
		this.isShow = true;
		this.isClose = false;
		SoundMn.gI().panelOpen();
		if (this.isTypeShop())
		{
			global::Char.myCharz().setPartOld();
		}
	}

	// Token: 0x0600081A RID: 2074 RVA: 0x0006F968 File Offset: 0x0006DB68
	public void chatTFUpdateKey()
	{
		if (this.chatTField != null && this.chatTField.isShow)
		{
			if (this.chatTField.left != null && (GameCanvas.keyPressed[12] || mScreen.getCmdPointerLast(this.chatTField.left)) && this.chatTField.left != null)
			{
				this.chatTField.left.performAction();
			}
			if (this.chatTField.right != null && (GameCanvas.keyPressed[13] || mScreen.getCmdPointerLast(this.chatTField.right)) && this.chatTField.right != null)
			{
				this.chatTField.right.performAction();
			}
			if (this.chatTField.center != null && (GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] || mScreen.getCmdPointerLast(this.chatTField.center)) && this.chatTField.center != null)
			{
				this.chatTField.center.performAction();
			}
			if (this.chatTField.isShow && GameCanvas.keyAsciiPress != 0)
			{
				this.chatTField.keyPressed(GameCanvas.keyAsciiPress);
				GameCanvas.keyAsciiPress = 0;
			}
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			return;
		}
	}

	// Token: 0x0600081B RID: 2075 RVA: 0x0006FAD4 File Offset: 0x0006DCD4
	public void updateKey()
	{
		if (this.chatTField != null && this.chatTField.isShow)
		{
			return;
		}
		if (!GameCanvas.panel.isDoneCombine)
		{
			return;
		}
		if (InfoDlg.isShow)
		{
			return;
		}
		if (this.tabIcon != null && this.tabIcon.isShow)
		{
			this.tabIcon.updateKey();
			return;
		}
		if (this.isClose)
		{
			return;
		}
		if (!this.isShow)
		{
			return;
		}
		if (this.cmdClose.isPointerPressInside())
		{
			this.cmdClose.performAction();
			return;
		}
		if (GameCanvas.keyPressed[13])
		{
			if (this.type != 4)
			{
				this.hide();
				return;
			}
			this.setTypeMain();
			this.cmx = (this.cmtoX = 0);
		}
		if (GameCanvas.keyPressed[12] || GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25])
		{
			if (this.left.idAction > 0)
			{
				this.perform(this.left.idAction, this.left.p);
			}
			else
			{
				this.waitToPerform = 2;
			}
		}
		if (this.Equals(GameCanvas.panel) && GameCanvas.panel2 == null && GameCanvas.isPointerJustRelease && !GameCanvas.isPointer(this.X, this.Y, this.W, this.H) && !this.pointerIsDowning)
		{
			this.hide();
			return;
		}
		if (!this.isClanOption)
		{
			this.updateKeyInTabBar();
		}
		switch (this.type)
		{
		case 0:
			if (this.currentTabIndex == 0)
			{
				this.updateKeyQuest();
				GameCanvas.clearKeyPressed();
				return;
			}
			if (this.currentTabIndex == 1)
			{
				this.updateKeyScrollView();
			}
			if (this.currentTabIndex == 2)
			{
				this.updateKeySkill();
			}
			if (this.currentTabIndex == 3)
			{
				if (this.mainTabName.Length == 4)
				{
					this.updateKeyTool();
				}
				else
				{
					this.updateKeyClans();
				}
			}
			if (this.currentTabIndex == 4)
			{
				this.updateKeyTool();
			}
			break;
		case 1:
		case 17:
		case 25:
			this.updateKeyScrollView();
			break;
		case 2:
			this.updateKeyScrollView();
			break;
		case 3:
			this.updateKeyScrollView();
			break;
		case 4:
			this.updateKeyMap();
			GameCanvas.clearKeyPressed();
			return;
		case 7:
			this.updateKeyScrollView();
			break;
		case 8:
			this.updateKeyScrollView();
			break;
		case 9:
			this.updateKeyScrollView();
			break;
		case 10:
			this.updateKeyScrollView();
			break;
		case 11:
		case 16:
			this.updateKeyScrollView();
			break;
		case 12:
			this.updateKeyCombine();
			break;
		case 13:
			this.updateKeyGiaoDich();
			break;
		case 14:
			this.updateKeyScrollView();
			break;
		case 15:
			this.updateKeyScrollView();
			break;
		case 18:
			this.updateKeyScrollView();
			break;
		case 19:
			this.updateKeyOption();
			break;
		case 20:
			this.updateKeyOption();
			break;
		case 21:
			if (this.currentTabIndex == 0)
			{
				this.updateKeyScrollView();
			}
			if (this.currentTabIndex == 1)
			{
				this.updateKeyPetStatus();
			}
			if (this.currentTabIndex == 2)
			{
				this.updateKeyScrollView();
			}
			break;
		case 22:
			this.updateKeyAuto();
			break;
		case 23:
		case 24:
			this.updateKeyScrollView();
			break;
		}
		GameCanvas.clearKeyHold();
		for (int i = 0; i < GameCanvas.keyPressed.Length; i++)
		{
			GameCanvas.keyPressed[i] = false;
		}
	}

	// Token: 0x0600081C RID: 2076 RVA: 0x00003984 File Offset: 0x00001B84
	private void updateKeyAuto()
	{
	}

	// Token: 0x0600081D RID: 2077 RVA: 0x000074EA File Offset: 0x000056EA
	private void updateKeyPetStatus()
	{
		this.updateKeyScrollView();
	}

	// Token: 0x0600081E RID: 2078 RVA: 0x00003984 File Offset: 0x00001B84
	private void updateKeyPetSkill()
	{
	}

	// Token: 0x0600081F RID: 2079 RVA: 0x000074EA File Offset: 0x000056EA
	private void keyGiaodich()
	{
		this.updateKeyScrollView();
	}

	// Token: 0x06000820 RID: 2080 RVA: 0x0006FE9C File Offset: 0x0006E09C
	private void updateKeyGiaoDich()
	{
		if (this.currentTabIndex == 0)
		{
			if (this.Equals(GameCanvas.panel))
			{
				this.updateKeyScrollView();
			}
			if (this.Equals(GameCanvas.panel2))
			{
				this.keyGiaodich();
			}
		}
		if (this.currentTabIndex == 1 || this.currentTabIndex == 2)
		{
			this.keyGiaodich();
		}
	}

	// Token: 0x06000821 RID: 2081 RVA: 0x000074EA File Offset: 0x000056EA
	private void updateKeyTool()
	{
		this.updateKeyScrollView();
	}

	// Token: 0x06000822 RID: 2082 RVA: 0x000074EA File Offset: 0x000056EA
	private void updateKeySkill()
	{
		this.updateKeyScrollView();
	}

	// Token: 0x06000823 RID: 2083 RVA: 0x000074EA File Offset: 0x000056EA
	private void updateKeyClanIcon()
	{
		this.updateKeyScrollView();
	}

	// Token: 0x06000824 RID: 2084 RVA: 0x0006FF00 File Offset: 0x0006E100
	public void setTabGiaoDich(bool isMe)
	{
		this.currentListLength = ((!isMe) ? (this.vFriendGD.size() + 3) : (this.vMyGD.size() + 3));
		this.ITEM_HEIGHT = 24;
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
	}

	// Token: 0x06000825 RID: 2085 RVA: 0x0006FFE4 File Offset: 0x0006E1E4
	public void setTypeGiaoDich(global::Char cGD)
	{
		this.type = 13;
		this.tabName[this.type] = Panel.boxGD;
		this.isAccept = false;
		this.isLock = false;
		this.isFriendLock = false;
		this.vMyGD.removeAllElements();
		this.vFriendGD.removeAllElements();
		this.moneyGD = 0;
		this.friendMoneyGD = 0;
		if (GameCanvas.w > 2 * Panel.WIDTH_PANEL)
		{
			GameCanvas.panel2 = new Panel();
			GameCanvas.panel2.type = 13;
			GameCanvas.panel2.tabName[this.type] = new string[][]
			{
				mResources.item_receive
			};
			GameCanvas.panel2.setType(1);
			GameCanvas.panel2.setTabGiaoDich(false);
			GameCanvas.panel.tabName[this.type] = new string[][]
			{
				mResources.inventory,
				mResources.item_give
			};
			GameCanvas.panel2.show();
			GameCanvas.panel2.charMenu = cGD;
		}
		if (this.Equals(GameCanvas.panel))
		{
			this.setType(0);
		}
		if (this.currentTabIndex == 0)
		{
			this.setTabInventory();
		}
		if (this.currentTabIndex == 1)
		{
			this.setTabGiaoDich(true);
		}
		if (this.currentTabIndex == 2)
		{
			this.setTabGiaoDich(false);
		}
		this.charMenu = cGD;
	}

	// Token: 0x06000826 RID: 2086 RVA: 0x00070134 File Offset: 0x0006E334
	private void paintGiaoDich(mGraphics g, bool isMe)
	{
		g.setColor(16711680);
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		MyVector myVector = (!isMe) ? this.vFriendGD : this.vMyGD;
		for (int i = 0; i < this.currentListLength; i++)
		{
			int num = this.xScroll + 36;
			int num2 = this.yScroll + i * this.ITEM_HEIGHT;
			int num3 = this.wScroll - 36;
			int num4 = this.ITEM_HEIGHT - 1;
			int num5 = this.xScroll;
			int num6 = this.yScroll + i * this.ITEM_HEIGHT;
			int num7 = 34;
			int num8 = this.ITEM_HEIGHT - 1;
			if (num2 - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num2 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					if (i == this.currentListLength - 1)
					{
						if (isMe)
						{
							g.setColor(15196114);
							g.fillRect(num5, num2, this.wScroll, num4);
							if (!this.isLock)
							{
								if (!this.isFriendLock)
								{
									mFont.tahoma_7_grey.drawString(g, mResources.opponent + mResources.not_lock_trade, this.xScroll + this.wScroll / 2, num2 + num4 / 2 - 4, mFont.CENTER);
								}
								else
								{
									mFont.tahoma_7_grey.drawString(g, mResources.opponent + mResources.locked_trade, this.xScroll + this.wScroll / 2, num2 + num4 / 2 - 4, mFont.CENTER);
								}
							}
							else if (this.isFriendLock)
							{
								g.setColor(15196114);
								g.fillRect(num5, num2, this.wScroll, num4);
								g.drawImage((i != this.selected) ? GameScr.imgLbtn2 : GameScr.imgLbtnFocus2, this.xScroll + this.wScroll - 5, num2 + 2, StaticObj.TOP_RIGHT);
								((i != this.selected) ? mFont.tahoma_7b_dark : mFont.tahoma_7b_green2).drawString(g, mResources.done, this.xScroll + this.wScroll - 22, num2 + 7, 2);
								mFont.tahoma_7_grey.drawString(g, mResources.opponent + mResources.locked_trade, this.xScroll + 5, num2 + num4 / 2 - 4, mFont.LEFT);
							}
							else
							{
								mFont.tahoma_7_grey.drawString(g, mResources.opponent + mResources.not_lock_trade, this.xScroll + this.wScroll / 2, num2 + num4 / 2 - 4, mFont.CENTER);
							}
						}
					}
					else if (i == this.currentListLength - 2)
					{
						if (isMe)
						{
							g.setColor(15196114);
							g.fillRect(num5, num2, this.wScroll, num4);
							if (!this.isAccept)
							{
								if (!this.isLock)
								{
									g.drawImage((i != this.selected) ? GameScr.imgLbtn2 : GameScr.imgLbtnFocus2, this.xScroll + this.wScroll - 5, num2 + 2, StaticObj.TOP_RIGHT);
									((i != this.selected) ? mFont.tahoma_7b_dark : mFont.tahoma_7b_green2).drawString(g, mResources.mlock, this.xScroll + this.wScroll - 22, num2 + 7, 2);
									mFont.tahoma_7_grey.drawString(g, mResources.you + mResources.not_lock_trade, this.xScroll + 5, num2 + num4 / 2 - 4, mFont.LEFT);
								}
								else
								{
									g.drawImage((i != this.selected) ? GameScr.imgLbtn2 : GameScr.imgLbtnFocus2, this.xScroll + this.wScroll - 5, num2 + 2, StaticObj.TOP_RIGHT);
									((i != this.selected) ? mFont.tahoma_7b_dark : mFont.tahoma_7b_green2).drawString(g, mResources.CANCEL, this.xScroll + this.wScroll - 22, num2 + 7, 2);
									mFont.tahoma_7_grey.drawString(g, mResources.you + mResources.locked_trade, this.xScroll + 5, num2 + num4 / 2 - 4, mFont.LEFT);
								}
							}
						}
						else if (!this.isFriendLock)
						{
							mFont.tahoma_7b_dark.drawString(g, mResources.not_lock_trade_upper, this.xScroll + this.wScroll / 2, num2 + num4 / 2 - 4, mFont.CENTER);
						}
						else
						{
							mFont.tahoma_7b_dark.drawString(g, mResources.locked_trade_upper, this.xScroll + this.wScroll / 2, num2 + num4 / 2 - 4, mFont.CENTER);
						}
					}
					else if (i == this.currentListLength - 3)
					{
						if (this.isLock)
						{
							g.setColor(13748667);
						}
						else
						{
							g.setColor((i != this.selected) ? 15196114 : 16383818);
						}
						g.fillRect(num, num2, num3, num4);
						if (this.isLock)
						{
							g.setColor(13748667);
						}
						else
						{
							g.setColor((i != this.selected) ? 9993045 : 7300181);
						}
						g.fillRect(num5, num6, num7, num8);
						g.drawImage(Panel.imgXu, num5 + num7 / 2, num6 + num8 / 2, 3);
						mFont.tahoma_7_green2.drawString(g, NinjaUtil.getMoneys((long)((!isMe) ? this.friendMoneyGD : this.moneyGD)) + " " + mResources.XU, num + 5, num2 + 11, 0);
						mFont.tahoma_7_green.drawString(g, mResources.money_trade, num + 5, num2, 0);
					}
					else
					{
						if (myVector.size() == 0)
						{
							return;
						}
						if (this.isLock)
						{
							g.setColor(13748667);
						}
						else
						{
							g.setColor((i != this.selected) ? 15196114 : 16383818);
						}
						g.fillRect(num, num2, num3, num4);
						if (this.isLock)
						{
							g.setColor(13748667);
						}
						else
						{
							g.setColor((i != this.selected) ? 9993045 : 9541120);
						}
						g.fillRect(num5, num6, num7, num8);
						Item item = (Item)myVector.elementAt(i);
						if (item != null)
						{
							string str = string.Empty;
							if (item.itemOption != null)
							{
								for (int j = 0; j < item.itemOption.Length; j++)
								{
									if (item.itemOption[j].optionTemplate.id == 72)
									{
										str = " [+" + item.itemOption[j].param + "]";
									}
								}
							}
							mFont.tahoma_7_green2.drawString(g, item.template.name + str, num + 5, num2 + 1, 0);
							string text = string.Empty;
							if (item.itemOption != null)
							{
								if (item.itemOption.Length > 0 && item.itemOption[0] != null)
								{
									text += item.itemOption[0].getOptionString();
								}
								mFont mFont = mFont.tahoma_7_blue;
								if (item.compare < 0 && (int)item.template.type != 5)
								{
									mFont = mFont.tahoma_7_red;
								}
								if (item.itemOption.Length > 1)
								{
									for (int k = 1; k < item.itemOption.Length; k++)
									{
										if (item.itemOption[k] != null && item.itemOption[k].optionTemplate.id != 102 && item.itemOption[k].optionTemplate.id != 107)
										{
											text = text + "," + item.itemOption[k].getOptionString();
										}
									}
								}
								mFont.drawString(g, text, num + 5, num2 + 11, mFont.LEFT);
							}
							SmallImage.drawSmallImage(g, (int)item.template.iconID, num5 + num7 / 2 - ((item.quantity <= 1) ? 0 : 8), num6 + num8 / 2, 0, 3);
							if (item.quantity > 1)
							{
								mFont.tahoma_7_yellow.drawString(g, "x" + item.quantity, num5 + num7 - 15, num6 + 6, 0);
							}
						}
					}
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x06000827 RID: 2087 RVA: 0x000709F4 File Offset: 0x0006EBF4
	private void updateKeyMap()
	{
		if (GameCanvas.keyHold[(!Main.isPC) ? 2 : 21])
		{
			this.yMove -= 5;
			this.cmyMap = this.yMove - (this.yScroll + this.hScroll / 2);
			if (this.yMove < this.yScroll)
			{
				this.yMove = this.yScroll;
			}
		}
		if (GameCanvas.keyHold[(!Main.isPC) ? 8 : 22])
		{
			this.yMove += 5;
			this.cmyMap = this.yMove - (this.yScroll + this.hScroll / 2);
			if (this.yMove > this.yScroll + 200)
			{
				this.yMove = this.yScroll + 200;
			}
		}
		if (GameCanvas.keyHold[(!Main.isPC) ? 4 : 23])
		{
			this.xMove -= 5;
			this.cmxMap = this.xMove - this.wScroll / 2;
			if (this.xMove < 16)
			{
				this.xMove = 16;
			}
		}
		if (GameCanvas.keyHold[(!Main.isPC) ? 6 : 24])
		{
			this.xMove += 5;
			this.cmxMap = this.xMove - this.wScroll / 2;
			if (this.xMove > 250)
			{
				this.xMove = 250;
			}
		}
		if (GameCanvas.isPointerDown)
		{
			this.pointerIsDowning = true;
			if (!this.trans)
			{
				this.pa1 = this.cmxMap;
				this.pa2 = this.cmyMap;
				this.trans = true;
			}
			this.cmxMap = this.pa1 + (GameCanvas.pxLast - GameCanvas.px);
			this.cmyMap = this.pa2 + (GameCanvas.pyLast - GameCanvas.py);
		}
		if (GameCanvas.isPointerJustRelease)
		{
			this.trans = false;
			GameCanvas.pxLast = GameCanvas.px;
			GameCanvas.pyLast = GameCanvas.py;
			this.pX = GameCanvas.pxLast + this.cmxMap;
			this.pY = GameCanvas.pyLast + this.cmyMap;
		}
		if (GameCanvas.isPointerClick)
		{
			this.pointerIsDowning = false;
		}
		if (this.cmxMap < 0)
		{
			this.cmxMap = 0;
		}
		if (this.cmxMap > this.cmxMapLim)
		{
			this.cmxMap = this.cmxMapLim;
		}
		if (this.cmyMap < 0)
		{
			this.cmyMap = 0;
		}
		if (this.cmyMap > this.cmyMapLim)
		{
			this.cmyMap = this.cmyMapLim;
		}
	}

	// Token: 0x06000828 RID: 2088 RVA: 0x00070CAC File Offset: 0x0006EEAC
	private void updateKeyCombine()
	{
		if (this.currentTabIndex == 0)
		{
			this.updateKeyScrollView();
			this.keyTouchCombine = -1;
			if (this.selected == this.vItemCombine.size() && GameCanvas.isPointerClick)
			{
				GameCanvas.isPointerClick = false;
				this.keyTouchCombine = 1;
			}
		}
		if (this.currentTabIndex == 1)
		{
			this.updateKeyScrollView();
		}
	}

	// Token: 0x06000829 RID: 2089 RVA: 0x00070D10 File Offset: 0x0006EF10
	private void updateKeyQuest()
	{
		if (GameCanvas.keyHold[(!Main.isPC) ? 2 : 21])
		{
			this.cmyQuest -= 5;
		}
		if (GameCanvas.keyHold[(!Main.isPC) ? 8 : 22])
		{
			this.cmyQuest += 5;
		}
		if (this.cmyQuest < 0)
		{
			this.cmyQuest = 0;
		}
		int num = this.indexRowMax * 12 - (this.hScroll - 60);
		if (num < 0)
		{
			num = 0;
		}
		if (this.cmyQuest > num)
		{
			this.cmyQuest = num;
		}
		if (this.scroll != null)
		{
			if (!GameCanvas.isTouch)
			{
				this.scroll.cmy = this.cmyQuest;
			}
			this.scroll.updateKey();
		}
		int num2 = this.xScroll + this.wScroll / 2 - 35;
		int num3 = (GameCanvas.h <= 300) ? 15 : 20;
		int num4 = this.yScroll + this.hScroll - num3 - 15;
		int px = GameCanvas.px;
		int py = GameCanvas.py;
		this.keyTouchMapButton = -1;
		if (Panel.isPaintMap && !GameScr.gI().isMapDocNhan() && px >= num2 && px <= num2 + 70 && py >= num4 && py <= num4 + 30)
		{
			if (this.scroll != null && this.scroll.pointerIsDowning)
			{
				return;
			}
			this.keyTouchMapButton = 1;
			if (GameCanvas.isPointerJustRelease)
			{
				SoundMn.gI().buttonClick();
				this.waitToPerform = 2;
				GameCanvas.clearAllPointerEvent();
			}
		}
	}

	// Token: 0x0600082A RID: 2090 RVA: 0x00070EC0 File Offset: 0x0006F0C0
	private void getCurrClanOtion()
	{
		this.isClanOption = false;
		if (this.type == 0 && this.mainTabName.Length == 5 && this.currentTabIndex == 3)
		{
			this.isClanOption = false;
			if (this.selected == 0)
			{
				this.currClanOption = new int[this.clansOption.Length];
				for (int i = 0; i < this.currClanOption.Length; i++)
				{
					this.currClanOption[i] = i;
				}
				if (!this.isViewMember)
				{
					this.isClanOption = true;
				}
			}
			else if (this.selected != 1)
			{
				if (this.isSearchClan)
				{
					return;
				}
				if (this.selected > 0)
				{
					this.currClanOption = new int[1];
					for (int j = 0; j < this.currClanOption.Length; j++)
					{
						this.currClanOption[j] = j;
					}
					this.isClanOption = true;
				}
			}
		}
	}

	// Token: 0x0600082B RID: 2091 RVA: 0x00070FB8 File Offset: 0x0006F1B8
	private void updateKeyClansOption()
	{
		if (this.currClanOption == null)
		{
			return;
		}
		if (GameCanvas.keyPressed[(!Main.isPC) ? 4 : 23])
		{
			this.currMess = this.getCurrMessage();
			this.cSelected--;
			if (this.selected == 0 && this.cSelected < 0)
			{
				this.cSelected = this.currClanOption.Length - 1;
			}
			if (this.selected > 1 && this.isMessage && this.currMess.option != null && this.cSelected < 0)
			{
				this.cSelected = this.currMess.option.Length - 1;
			}
		}
		else if (GameCanvas.keyPressed[(!Main.isPC) ? 6 : 24])
		{
			this.currMess = this.getCurrMessage();
			this.cSelected++;
			if (this.selected == 0 && this.cSelected > this.currClanOption.Length - 1)
			{
				this.cSelected = 0;
			}
			if (this.selected > 1 && this.isMessage && this.currMess.option != null && this.cSelected > this.currMess.option.Length - 1)
			{
				this.cSelected = 0;
			}
		}
	}

	// Token: 0x0600082C RID: 2092 RVA: 0x000074F2 File Offset: 0x000056F2
	private void updateKeyClans()
	{
		this.updateKeyScrollView();
		this.updateKeyClansOption();
	}

	// Token: 0x0600082D RID: 2093 RVA: 0x00071124 File Offset: 0x0006F324
	private void checkOptionSelect()
	{
		if (this.type == 0 && this.currentTabIndex == 3 && this.mainTabName.Length == 5)
		{
			if (this.selected == -1)
			{
				return;
			}
			int num = 0;
			if (this.selected == 0)
			{
				num = this.xScroll + this.wScroll / 2 - this.clansOption.Length * this.TAB_W / 2;
				this.cSelected = (GameCanvas.px - num) / this.TAB_W;
			}
			else
			{
				this.currMess = this.getCurrMessage();
				if (this.currMess != null && this.currMess.option != null)
				{
					num = this.xScroll + this.wScroll - 2 - this.currMess.option.Length * 40;
					this.cSelected = (GameCanvas.px - num) / 40;
				}
			}
			if (GameCanvas.px < num)
			{
				this.cSelected = -1;
			}
		}
	}

	// Token: 0x0600082E RID: 2094 RVA: 0x00071218 File Offset: 0x0006F418
	public void updateScroolMouse(int a)
	{
		bool flag = false;
		if (GameCanvas.pxMouse > this.wScroll)
		{
			return;
		}
		if (this.indexMouse == -1)
		{
			this.indexMouse = this.selected;
		}
		if (a > 0)
		{
			this.indexMouse -= a;
			flag = true;
		}
		else if (a < 0)
		{
			this.indexMouse += -a;
			flag = true;
		}
		if (this.indexMouse < 0)
		{
			this.indexMouse = 0;
		}
		if (!flag)
		{
			return;
		}
		this.cmtoY = this.indexMouse * 12;
		if (this.cmtoY > this.cmyLim)
		{
			this.cmtoY = this.cmyLim;
		}
		if (this.cmtoY < 0)
		{
			this.cmtoY = 0;
		}
	}

	// Token: 0x0600082F RID: 2095 RVA: 0x000712E0 File Offset: 0x0006F4E0
	private void updateKeyScrollView()
	{
		if (this.currentListLength <= 0)
		{
			return;
		}
		bool flag = false;
		if (GameCanvas.keyPressed[(!Main.isPC) ? 2 : 21])
		{
			flag = true;
			this.selected--;
			if (this.type == 24)
			{
				this.selected -= 2;
				if (this.selected < 0)
				{
					this.selected = 0;
				}
			}
			else if (this.selected < 0)
			{
				if (this.Equals(GameCanvas.panel) && this.typeShop == 2 && this.currentTabIndex <= 3 && this.maxPageShop[this.currentTabIndex] > 1)
				{
					InfoDlg.showWait();
					if (this.currPageShop[this.currentTabIndex] <= 0)
					{
						Service.gI().kigui(4, -1, (sbyte)this.currentTabIndex, this.maxPageShop[this.currentTabIndex] - 1, -1);
					}
					else
					{
						Service.gI().kigui(4, -1, (sbyte)this.currentTabIndex, this.currPageShop[this.currentTabIndex] - 1, -1);
					}
					return;
				}
				this.selected = this.currentListLength - 1;
				if (this.isClanOption)
				{
					this.selected = -1;
				}
			}
			this.lastSelect[this.currentTabIndex] = this.selected;
			this.cSelected = 0;
			this.getCurrClanOtion();
		}
		else if (GameCanvas.keyPressed[(!Main.isPC) ? 8 : 22])
		{
			flag = true;
			this.selected++;
			if (this.type == 24)
			{
				this.selected += 2;
				if (this.selected > this.currentListLength - 1)
				{
					this.selected = this.currentListLength - 1;
				}
			}
			else if (this.selected > this.currentListLength - 1)
			{
				if (this.Equals(GameCanvas.panel) && this.typeShop == 2 && this.currentTabIndex <= 3 && this.maxPageShop[this.currentTabIndex] > 1)
				{
					InfoDlg.showWait();
					if (this.currPageShop[this.currentTabIndex] >= this.maxPageShop[this.currentTabIndex] - 1)
					{
						Service.gI().kigui(4, -1, (sbyte)this.currentTabIndex, 0, -1);
					}
					else
					{
						Service.gI().kigui(4, -1, (sbyte)this.currentTabIndex, this.currPageShop[this.currentTabIndex] + 1, -1);
					}
					return;
				}
				this.selected = 0;
			}
			this.lastSelect[this.currentTabIndex] = this.selected;
			this.cSelected = 0;
			this.getCurrClanOtion();
		}
		if (flag)
		{
			this.cmtoY = this.selected * this.ITEM_HEIGHT - this.hScroll / 2;
			if (this.cmtoY > this.cmyLim)
			{
				this.cmtoY = this.cmyLim;
			}
			if (this.cmtoY < 0)
			{
				this.cmtoY = 0;
			}
			if (this.selected == this.currentListLength || this.selected == 0)
			{
				this.cmy = this.cmtoY;
			}
		}
		if (GameCanvas.isPointerDown)
		{
			this.justRelease = false;
			if (!this.pointerIsDowning && GameCanvas.isPointer(this.xScroll, this.yScroll, this.wScroll, this.hScroll))
			{
				for (int i = 0; i < this.pointerDownLastX.Length; i++)
				{
					this.pointerDownLastX[0] = GameCanvas.py;
				}
				this.pointerDownFirstX = GameCanvas.py;
				this.pointerIsDowning = true;
				this.isDownWhenRunning = (this.cmRun != 0);
				this.cmRun = 0;
			}
			else if (this.pointerIsDowning)
			{
				this.pointerDownTime++;
				if (this.pointerDownTime > 5 && this.pointerDownFirstX == GameCanvas.py && !this.isDownWhenRunning)
				{
					this.pointerDownFirstX = -1000;
					this.selected = (this.cmtoY + GameCanvas.py - this.yScroll) / this.ITEM_HEIGHT;
					if (this.selected >= this.currentListLength)
					{
						this.selected = -1;
					}
					this.checkOptionSelect();
				}
				else
				{
					this.indexMouse = -1;
				}
				int num = GameCanvas.py - this.pointerDownLastX[0];
				if (num != 0 && this.selected != -1)
				{
					this.selected = -1;
					this.cSelected = -1;
				}
				for (int j = this.pointerDownLastX.Length - 1; j > 0; j--)
				{
					this.pointerDownLastX[j] = this.pointerDownLastX[j - 1];
				}
				this.pointerDownLastX[0] = GameCanvas.py;
				this.cmtoY -= num;
				if (this.cmtoY < 0)
				{
					this.cmtoY = 0;
				}
				if (this.cmtoY > this.cmyLim)
				{
					this.cmtoY = this.cmyLim;
				}
				if (this.cmy < 0 || this.cmy > this.cmyLim)
				{
					num /= 2;
				}
				this.cmy -= num;
				if (this.cmy < -(GameCanvas.h / 3))
				{
					this.wantUpdateList = true;
				}
				else
				{
					this.wantUpdateList = false;
				}
			}
		}
		if (GameCanvas.isPointerJustRelease && this.pointerIsDowning)
		{
			this.justRelease = true;
			int i2 = GameCanvas.py - this.pointerDownLastX[0];
			GameCanvas.isPointerJustRelease = false;
			if (Res.abs(i2) < 20 && Res.abs(GameCanvas.py - this.pointerDownFirstX) < 20 && !this.isDownWhenRunning)
			{
				this.cmRun = 0;
				this.cmtoY = this.cmy;
				this.pointerDownFirstX = -1000;
				this.selected = (this.cmtoY + GameCanvas.py - this.yScroll) / this.ITEM_HEIGHT;
				if (this.selected >= this.currentListLength)
				{
					this.selected = -1;
				}
				this.checkOptionSelect();
				this.pointerDownTime = 0;
				this.waitToPerform = 10;
				SoundMn.gI().panelClick();
			}
			else if (this.selected != -1 && this.pointerDownTime > 5)
			{
				this.pointerDownTime = 0;
				this.waitToPerform = 1;
			}
			else if (this.selected == -1 && !this.isDownWhenRunning)
			{
				if (this.cmy < 0)
				{
					this.cmtoY = 0;
				}
				else if (this.cmy > this.cmyLim)
				{
					this.cmtoY = this.cmyLim;
				}
				else
				{
					int num2 = GameCanvas.py - this.pointerDownLastX[0] + (this.pointerDownLastX[0] - this.pointerDownLastX[1]) + (this.pointerDownLastX[1] - this.pointerDownLastX[2]);
					if (num2 > 10)
					{
						num2 = 10;
					}
					else if (num2 < -10)
					{
						num2 = -10;
					}
					else
					{
						num2 = 0;
					}
					this.cmRun = -num2 * 100;
				}
			}
			this.pointerIsDowning = false;
			this.pointerDownTime = 0;
			GameCanvas.isPointerJustRelease = false;
		}
	}

	// Token: 0x06000830 RID: 2096 RVA: 0x00003ED1 File Offset: 0x000020D1
	public string subArray(string[] str)
	{
		return null;
	}

	// Token: 0x06000831 RID: 2097 RVA: 0x00071A08 File Offset: 0x0006FC08
	private void updateKeyInTabBar()
	{
		if (this.scroll != null && this.scroll.pointerIsDowning)
		{
			return;
		}
		if (this.pointerIsDowning)
		{
			return;
		}
		int num = this.currentTabIndex;
		if (GameCanvas.keyPressed[(!Main.isPC) ? 6 : 24])
		{
			this.currentTabIndex++;
			if (this.currentTabIndex >= this.currentTabName.Length)
			{
				if (GameCanvas.panel2 != null)
				{
					this.currentTabIndex = this.currentTabName.Length - 1;
					GameCanvas.isFocusPanel2 = true;
				}
				else
				{
					this.currentTabIndex = 0;
				}
			}
			this.selected = this.lastSelect[this.currentTabIndex];
			this.lastTabIndex[this.type] = this.currentTabIndex;
		}
		if (GameCanvas.keyPressed[(!Main.isPC) ? 4 : 23])
		{
			this.currentTabIndex--;
			if (this.currentTabIndex < 0)
			{
				this.currentTabIndex = this.currentTabName.Length - 1;
			}
			if (GameCanvas.isFocusPanel2)
			{
				GameCanvas.isFocusPanel2 = false;
			}
			this.selected = this.lastSelect[this.currentTabIndex];
			this.lastTabIndex[this.type] = this.currentTabIndex;
		}
		this.keyTouchTab = -1;
		for (int i = 0; i < this.currentTabName.Length; i++)
		{
			if (GameCanvas.isPointer(this.startTabPos + i * this.TAB_W, 52, this.TAB_W - 1, 25))
			{
				this.keyTouchTab = i;
				if (GameCanvas.isPointerJustRelease)
				{
					this.currentTabIndex = i;
					this.lastTabIndex[this.type] = i;
					GameCanvas.isPointerJustRelease = false;
					this.selected = this.lastSelect[this.currentTabIndex];
					if (num == this.currentTabIndex && this.cmRun == 0)
					{
						this.cmtoY = 0;
						this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
					}
					break;
				}
			}
		}
		if (num != this.currentTabIndex)
		{
			SoundMn.gI().panelClick();
			int num2 = this.type;
			switch (num2)
			{
			case 0:
				if (this.currentTabIndex == 0)
				{
					this.setTabTask();
				}
				if (this.currentTabIndex == 1)
				{
					this.setTabInventory();
				}
				if (this.currentTabIndex == 2)
				{
					this.setTabSkill();
				}
				if (this.currentTabIndex == 3)
				{
					if (this.mainTabName.Length > 4)
					{
						this.setTabClans();
					}
					else
					{
						this.setTabTool();
					}
				}
				if (this.currentTabIndex == 4)
				{
					this.setTabTool();
				}
				break;
			case 1:
				this.setTabShop();
				break;
			case 2:
				if (this.currentTabIndex == 0)
				{
					this.setTabBox();
				}
				if (this.currentTabIndex == 1)
				{
					this.setTabInventory();
				}
				break;
			case 3:
				this.setTabZone();
				break;
			default:
				if (num2 != 12)
				{
					if (num2 != 13)
					{
						if (num2 != 21)
						{
							if (num2 == 25)
							{
								this.setTabSpeacialSkill();
							}
						}
						else
						{
							if (this.currentTabIndex == 0)
							{
								this.setTabPetInventory();
							}
							if (this.currentTabIndex == 1)
							{
								this.setTabPetStatus();
							}
							if (this.currentTabIndex == 2)
							{
								this.setTabInventory();
							}
						}
					}
					else
					{
						if (this.currentTabIndex == 0)
						{
							if (this.Equals(GameCanvas.panel))
							{
								this.setTabInventory();
							}
							else if (this.Equals(GameCanvas.panel2))
							{
								this.setTabGiaoDich(false);
							}
						}
						if (this.currentTabIndex == 1)
						{
							this.setTabGiaoDich(true);
						}
						if (this.currentTabIndex == 2)
						{
							this.setTabGiaoDich(false);
						}
					}
				}
				else
				{
					if (this.currentTabIndex == 0)
					{
						this.setTabCombine();
					}
					if (this.currentTabIndex == 1)
					{
						this.setTabInventory();
					}
				}
				break;
			}
			this.selected = this.lastSelect[this.currentTabIndex];
		}
	}

	// Token: 0x06000832 RID: 2098 RVA: 0x00071E0C File Offset: 0x0007000C
	private void setTabPetStatus()
	{
		this.currentListLength = this.strStatus.Length;
		this.ITEM_HEIGHT = 24;
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
	}

	// Token: 0x06000833 RID: 2099 RVA: 0x00003984 File Offset: 0x00001B84
	private void setTabPetSkill()
	{
	}

	// Token: 0x06000834 RID: 2100 RVA: 0x00071ED4 File Offset: 0x000700D4
	private void setTabTool()
	{
		SoundMn.gI().getSoundOption();
		this.currentListLength = Panel.strTool.Length;
		this.ITEM_HEIGHT = 24;
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
	}

	// Token: 0x06000835 RID: 2101 RVA: 0x00071FA4 File Offset: 0x000701A4
	public void initTabClans()
	{
		if (this.isSearchClan)
		{
			this.currentListLength = ((this.clans != null) ? (this.clans.Length + 2) : 2);
			this.clanInfo = mResources.clan_list;
		}
		else if (this.isViewMember)
		{
			this.clanReport = string.Empty;
			this.currentListLength = ((this.member != null) ? this.member.size() : this.myMember.size()) + 2;
			this.clanInfo = mResources.member + " " + ((this.currClan == null) ? global::Char.myCharz().clan.name : this.currClan.name);
		}
		else if (this.isMessage)
		{
			this.currentListLength = ClanMessage.vMessage.size() + 2;
			this.clanInfo = mResources.msg;
			this.clanReport = string.Empty;
		}
		if (global::Char.myCharz().clan == null)
		{
			this.clansOption = new string[][]
			{
				mResources.findClan,
				mResources.createClan
			};
		}
		else if (!this.isViewMember)
		{
			if (this.myMember.size() > 1)
			{
				this.clansOption = new string[][]
				{
					mResources.chatClan,
					mResources.request_pea2,
					mResources.memberr
				};
			}
			else
			{
				this.clansOption = new string[][]
				{
					mResources.memberr
				};
			}
		}
		else if ((int)global::Char.myCharz().role > 0)
		{
			this.clansOption = new string[][]
			{
				mResources.msgg,
				mResources.leaveClan
			};
		}
		else if (this.myMember.size() > 1)
		{
			this.clansOption = new string[][]
			{
				mResources.msgg,
				mResources.leaveClan,
				mResources.khau_hieuu,
				mResources.bieu_tuongg
			};
		}
		else
		{
			this.clansOption = new string[][]
			{
				mResources.msgg,
				mResources.khau_hieuu,
				mResources.bieu_tuongg
			};
		}
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
	}

	// Token: 0x06000836 RID: 2102 RVA: 0x0007225C File Offset: 0x0007045C
	public void setTabClans()
	{
		GameScr.isNewClanMessage = false;
		this.ITEM_HEIGHT = 24;
		if (this.lastSelect != null && this.lastSelect[3] == 0)
		{
			this.lastSelect[3] = -1;
		}
		this.currentListLength = 2;
		if (global::Char.myCharz().clan != null)
		{
			this.isMessage = true;
			this.isViewMember = false;
			this.isSearchClan = false;
		}
		else
		{
			this.isMessage = false;
			this.isViewMember = false;
			this.isSearchClan = true;
		}
		if (global::Char.myCharz().clan != null)
		{
			this.currentListLength = ClanMessage.vMessage.size() + 2;
		}
		this.initTabClans();
		this.cSelected = -1;
		if (this.chatTField == null)
		{
			this.chatTField = new ChatTextField();
			this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
			this.chatTField.initChatTextField();
			this.chatTField.parentScreen = GameCanvas.panel;
		}
		if (global::Char.myCharz().clan == null)
		{
			this.clanReport = mResources.findingClan;
			Service.gI().searchClan(string.Empty);
		}
		this.selected = this.lastSelect[this.currentTabIndex];
		if (GameCanvas.isTouch)
		{
			this.selected = -1;
		}
	}

	// Token: 0x06000837 RID: 2103 RVA: 0x000723B4 File Offset: 0x000705B4
	public void initLogMessage()
	{
		this.currentListLength = this.logChat.size() + 1;
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
		this.cmx = (this.cmtoX = 0);
	}

	// Token: 0x06000838 RID: 2104 RVA: 0x00007500 File Offset: 0x00005700
	private void setTabMessage()
	{
		this.ITEM_HEIGHT = 24;
		this.initLogMessage();
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
	}

	// Token: 0x06000839 RID: 2105 RVA: 0x00072470 File Offset: 0x00070670
	public void setTabShop()
	{
		this.ITEM_HEIGHT = 24;
		if (this.currentTabIndex == this.currentTabName.Length - 1 && GameCanvas.panel2 == null && this.typeShop != 2)
		{
			this.currentListLength = global::Char.myCharz().arrItemBag.Length + global::Char.myCharz().arrItemBody.Length;
		}
		else
		{
			this.currentListLength = global::Char.myCharz().arrItemShop[this.currentTabIndex].Length;
		}
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
	}

	// Token: 0x0600083A RID: 2106 RVA: 0x00072590 File Offset: 0x00070790
	private void setTabSkill()
	{
		this.ITEM_HEIGHT = 30;
		this.currentListLength = global::Char.myCharz().nClass.skillTemplates.Length + 6;
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = this.cmyLim;
		}
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
	}

	// Token: 0x0600083B RID: 2107 RVA: 0x00072658 File Offset: 0x00070858
	private void setTabMapTrans()
	{
		this.ITEM_HEIGHT = 24;
		this.currentListLength = this.mapNames.Length;
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		this.cmy = (this.cmtoY = 0);
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
	}

	// Token: 0x0600083C RID: 2108 RVA: 0x000726BC File Offset: 0x000708BC
	private void setTabZone()
	{
		this.ITEM_HEIGHT = 24;
		this.currentListLength = GameScr.gI().zones.Length;
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		this.cmy = (this.cmtoY = 0);
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
	}

	// Token: 0x0600083D RID: 2109 RVA: 0x00072724 File Offset: 0x00070924
	private void setTabBox()
	{
		Item[] arrItemBox = global::Char.myCharz().arrItemBox;
		this.currentListLength = arrItemBox.Length;
		this.ITEM_HEIGHT = 24;
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 9;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
	}

	// Token: 0x0600083E RID: 2110 RVA: 0x000727F0 File Offset: 0x000709F0
	private void setTabPetInventory()
	{
		this.ITEM_HEIGHT = 30;
		Item[] arrItemBody = global::Char.myPetz().arrItemBody;
		Skill[] arrPetSkill = global::Char.myPetz().arrPetSkill;
		this.currentListLength = arrItemBody.Length + arrPetSkill.Length;
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = 0);
		}
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
	}

	// Token: 0x0600083F RID: 2111 RVA: 0x000728C8 File Offset: 0x00070AC8
	private void setTabInventory()
	{
		this.ITEM_HEIGHT = 24;
		Item[] arrItemBody = global::Char.myCharz().arrItemBody;
		Item[] arrItemBag = global::Char.myCharz().arrItemBag;
		this.currentListLength = arrItemBody.Length + arrItemBag.Length;
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = 0);
		}
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
	}

	// Token: 0x06000840 RID: 2112 RVA: 0x000729A0 File Offset: 0x00070BA0
	private void setTabMap()
	{
		if (!Panel.isPaintMap)
		{
			return;
		}
		if ((int)TileMap.lastPlanetId != (int)TileMap.planetID)
		{
			Res.outz("LOAD TAM HINH");
			Panel.imgMap = GameCanvas.loadImageRMS("/img/map" + TileMap.planetID + ".png");
			TileMap.lastPlanetId = TileMap.planetID;
		}
		this.cmxMap = this.getXMap() - this.wScroll / 2;
		this.cmyMap = this.getYMap() + this.yScroll - (this.yScroll + this.hScroll / 2);
		this.pa1 = this.cmxMap;
		this.pa2 = this.cmyMap;
		this.cmxMapLim = 250 - this.wScroll;
		this.cmyMapLim = 220 - this.hScroll;
		if (this.cmxMapLim < 0)
		{
			this.cmxMapLim = 0;
		}
		if (this.cmyMapLim < 0)
		{
			this.cmyMapLim = 0;
		}
		for (int i = 0; i < Panel.mapId[(int)TileMap.planetID].Length; i++)
		{
			if (TileMap.mapID == Panel.mapId[(int)TileMap.planetID][i])
			{
				this.xMove = Panel.mapX[(int)TileMap.planetID][i] + this.xScroll;
				this.yMove = Panel.mapY[(int)TileMap.planetID][i] + this.yScroll + 5;
				break;
			}
		}
		this.xMap = this.getXMap() + this.xScroll;
		this.yMap = this.getYMap() + this.yScroll;
		this.xMapTask = this.getXMapTask() + this.xScroll;
		this.yMapTask = this.getYMapTask() + this.yScroll;
		Resources.UnloadUnusedAssets();
		GC.Collect();
	}

	// Token: 0x06000841 RID: 2113 RVA: 0x00007527 File Offset: 0x00005727
	private void setTabTask()
	{
		this.cmyQuest = 0;
	}

	// Token: 0x06000842 RID: 2114 RVA: 0x00072B68 File Offset: 0x00070D68
	public void moveCamera()
	{
		if (this.timeShow > 0)
		{
			this.timeShow--;
		}
		if (this.justRelease && this.Equals(GameCanvas.panel) && this.typeShop == 2 && this.maxPageShop[this.currentTabIndex] > 1)
		{
			if (this.cmy < -50)
			{
				InfoDlg.showWait();
				this.justRelease = false;
				if (this.currPageShop[this.currentTabIndex] <= 0)
				{
					Service.gI().kigui(4, -1, (sbyte)this.currentTabIndex, this.maxPageShop[this.currentTabIndex] - 1, -1);
				}
				else
				{
					Service.gI().kigui(4, -1, (sbyte)this.currentTabIndex, this.currPageShop[this.currentTabIndex] - 1, -1);
				}
			}
			else if (this.cmy > this.cmyLim + 50)
			{
				this.justRelease = false;
				InfoDlg.showWait();
				if (this.currPageShop[this.currentTabIndex] >= this.maxPageShop[this.currentTabIndex] - 1)
				{
					Service.gI().kigui(4, -1, (sbyte)this.currentTabIndex, 0, -1);
				}
				else
				{
					Service.gI().kigui(4, -1, (sbyte)this.currentTabIndex, this.currPageShop[this.currentTabIndex] + 1, -1);
				}
			}
		}
		if (this.cmx != this.cmtoX && !this.pointerIsDowning)
		{
			this.cmvx = this.cmtoX - this.cmx << 2;
			this.cmdx += this.cmvx;
			this.cmx += this.cmdx >> 3;
			this.cmdx &= 15;
		}
		if (global::Math.abs(this.cmtoX - this.cmx) < 10)
		{
			this.cmx = this.cmtoX;
		}
		if (this.isClose)
		{
			this.isClose = false;
			this.cmtoX = this.wScroll;
		}
		if (this.cmtoX >= this.wScroll - 10 && this.cmx >= this.wScroll - 10 && this.position == 0)
		{
			this.isShow = false;
			this.cleanCombine();
			if (this.isChangeZone)
			{
				this.isChangeZone = false;
				if (global::Char.myCharz().cHP > 0 && global::Char.myCharz().statusMe != 14)
				{
					InfoDlg.showWait();
					if (this.type == 3)
					{
						Service.gI().requestChangeZone(this.selected, -1);
					}
					else if (this.type == 14)
					{
						Service.gI().requestMapSelect(this.selected);
					}
				}
			}
			if (this.isSelectPlayerMenu)
			{
				this.isSelectPlayerMenu = false;
				Command command = (Command)this.vPlayerMenu.elementAt(this.selected);
				command.performAction();
			}
			this.vPlayerMenu.removeAllElements();
			this.charMenu = null;
		}
		if (this.cmRun != 0 && !this.pointerIsDowning)
		{
			this.cmtoY += this.cmRun / 100;
			if (this.cmtoY < 0)
			{
				this.cmtoY = 0;
			}
			else if (this.cmtoY > this.cmyLim)
			{
				this.cmtoY = this.cmyLim;
			}
			else
			{
				this.cmy = this.cmtoY;
			}
			this.cmRun = this.cmRun * 9 / 10;
			if (this.cmRun < 100 && this.cmRun > -100)
			{
				this.cmRun = 0;
			}
		}
		if (this.cmy != this.cmtoY && !this.pointerIsDowning)
		{
			this.cmvy = this.cmtoY - this.cmy << 2;
			this.cmdy += this.cmvy;
			this.cmy += this.cmdy >> 4;
			this.cmdy &= 15;
		}
		this.cmyLast[this.currentTabIndex] = this.cmy;
	}

	// Token: 0x06000843 RID: 2115 RVA: 0x00072F88 File Offset: 0x00071188
	public void paintDetail(mGraphics g)
	{
		if (this.cp != null)
		{
			if (this.cp.says == null)
			{
				return;
			}
			this.cp.paint(g);
			int num = this.cp.cx + 13;
			int num2 = this.cp.cy + 11;
			if (this.type == 15)
			{
				num += 5;
				num2 += 26;
			}
			if (this.type == 0 && this.currentTabIndex == 3)
			{
				if (this.isSearchClan)
				{
					num -= 5;
				}
				else if (this.partID != null || this.charInfo != null)
				{
					num = this.cp.cx + 21;
					num2 = this.cp.cy + 40;
				}
			}
			if (this.partID != null)
			{
				Part part = GameScr.parts[this.partID[0]];
				Part part2 = GameScr.parts[this.partID[1]];
				Part part3 = GameScr.parts[this.partID[2]];
				SmallImage.drawSmallImage(g, (int)part.pi[global::Char.CharInfo[0][0][0]].id, num + global::Char.CharInfo[0][0][1] + (int)part.pi[global::Char.CharInfo[0][0][0]].dx, num2 - global::Char.CharInfo[0][0][2] + (int)part.pi[global::Char.CharInfo[0][0][0]].dy, 0, 0);
				SmallImage.drawSmallImage(g, (int)part2.pi[global::Char.CharInfo[0][1][0]].id, num + global::Char.CharInfo[0][1][1] + (int)part2.pi[global::Char.CharInfo[0][1][0]].dx, num2 - global::Char.CharInfo[0][1][2] + (int)part2.pi[global::Char.CharInfo[0][1][0]].dy, 0, 0);
				SmallImage.drawSmallImage(g, (int)part3.pi[global::Char.CharInfo[0][2][0]].id, num + global::Char.CharInfo[0][2][1] + (int)part3.pi[global::Char.CharInfo[0][2][0]].dx, num2 - global::Char.CharInfo[0][2][2] + (int)part3.pi[global::Char.CharInfo[0][2][0]].dy, 0, 0);
			}
			else if (this.charInfo != null)
			{
				this.charInfo.paintCharBody(g, num + 5, num2 + 25, 1, 0, true);
			}
			else if (this.idIcon != -1)
			{
				SmallImage.drawSmallImage(g, this.idIcon, num, num2, 0, 3);
			}
			if (this.currItem != null && (int)this.currItem.template.type != 5)
			{
				if (this.currItem.compare > 0)
				{
					g.drawImage(Panel.imgUp, num - 7, num2 + 13, 3);
					mFont.tahoma_7b_green.drawString(g, Res.abs(this.currItem.compare) + string.Empty, num + 1, num2 + 8, 0);
				}
				else if (this.currItem.compare < 0 && this.currItem.compare != -1)
				{
					g.drawImage(Panel.imgDown, num - 7, num2 + 13, 3);
					mFont.tahoma_7b_red.drawString(g, Res.abs(this.currItem.compare) + string.Empty, num + 1, num2 + 8, 0);
				}
			}
		}
	}

	// Token: 0x06000844 RID: 2116 RVA: 0x000732F8 File Offset: 0x000714F8
	public void paintTop(mGraphics g)
	{
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		g.setColor(0);
		if (this.currentListLength == 0)
		{
			return;
		}
		int num = (this.cmy + this.hScroll) / 24 + 1;
		if (num < this.hScroll / 24 + 1)
		{
			num = this.hScroll / 24 + 1;
		}
		if (num > this.currentListLength)
		{
			num = this.currentListLength;
		}
		int num2 = this.cmy / 24;
		if (num2 >= num)
		{
			num2 = num - 1;
		}
		if (num2 < 0)
		{
			num2 = 0;
		}
		for (int i = num2; i < num; i++)
		{
			int num3 = this.xScroll;
			int num4 = this.yScroll + i * this.ITEM_HEIGHT;
			int num5 = 24;
			int h = this.ITEM_HEIGHT - 1;
			int num6 = this.xScroll + num5;
			int num7 = this.yScroll + i * this.ITEM_HEIGHT;
			int num8 = this.wScroll - num5;
			int num9 = this.ITEM_HEIGHT - 1;
			g.setColor((i != this.selected) ? 15196114 : 16383818);
			g.fillRect(num6, num7, num8, num9);
			g.setColor((i != this.selected) ? 9993045 : 9541120);
			g.fillRect(num3, num4, num5, h);
			TopInfo topInfo = (TopInfo)this.vTop.elementAt(i);
			Part part = GameScr.parts[topInfo.headID];
			SmallImage.drawSmallImage(g, (int)part.pi[global::Char.CharInfo[0][0][0]].id, num3 + (int)part.pi[global::Char.CharInfo[0][0][0]].dx, num4 + num9 - 1, 0, mGraphics.BOTTOM | mGraphics.LEFT);
			g.setClip(this.xScroll, this.yScroll + this.cmy, this.wScroll, this.hScroll);
			if (topInfo.pId != global::Char.myCharz().charID)
			{
				mFont.tahoma_7b_green.drawString(g, topInfo.name, num6 + 5, num7, 0);
			}
			else
			{
				mFont.tahoma_7b_red.drawString(g, topInfo.name, num6 + 5, num7, 0);
			}
			mFont.tahoma_7_blue.drawString(g, topInfo.info, num6 + num8 - 5, num7 + 11, 1);
			mFont.tahoma_7_green2.drawString(g, string.Concat(new object[]
			{
				mResources.rank,
				": ",
				topInfo.rank,
				string.Empty
			}), num6 + 5, num7 + 11, 0);
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x06000845 RID: 2117 RVA: 0x000735B8 File Offset: 0x000717B8
	public void paint(mGraphics g)
	{
		g.translate(-g.getTranslateX(), -g.getTranslateY() + mGraphics.addYWhenOpenKeyBoard);
		g.translate(-this.cmx, 0);
		g.translate(this.X, this.Y);
		if ((int)GameCanvas.panel.combineSuccess != -1)
		{
			if (this.Equals(GameCanvas.panel))
			{
				this.paintCombineEff(g);
			}
		}
		else
		{
			GameCanvas.paintz.paintFrameSimple(this.X, this.Y, this.W, this.H, g);
			this.paintTopInfo(g);
			this.paintBottomMoneyInfo(g);
			this.paintTab(g);
			switch (this.type)
			{
			case 0:
				if (this.currentTabIndex == 0)
				{
					this.paintTask(g);
				}
				if (this.currentTabIndex == 1)
				{
					this.paintInventory(g);
				}
				if (this.currentTabIndex == 2)
				{
					this.paintSkill(g);
				}
				if (this.currentTabIndex == 3)
				{
					if (this.mainTabName.Length == 4)
					{
						this.paintTools(g);
					}
					else
					{
						this.paintClans(g);
					}
				}
				if (this.currentTabIndex == 4)
				{
					this.paintTools(g);
				}
				break;
			case 1:
				this.paintShop(g);
				break;
			case 2:
				if (this.currentTabIndex == 0)
				{
					this.paintBox(g);
				}
				if (this.currentTabIndex == 1)
				{
					this.paintInventory(g);
				}
				break;
			case 3:
				this.paintZone(g);
				break;
			case 4:
				this.paintMap(g);
				break;
			case 7:
				this.paintInventory(g);
				break;
			case 8:
				this.paintLogChat(g);
				break;
			case 9:
				this.paintArchivement(g);
				break;
			case 10:
				this.paintPlayerMenu(g);
				break;
			case 11:
				this.paintFriend(g);
				break;
			case 12:
				if (this.currentTabIndex == 0)
				{
					this.paintCombine(g);
				}
				if (this.currentTabIndex == 1)
				{
					this.paintInventory(g);
				}
				break;
			case 13:
				if (this.currentTabIndex == 0)
				{
					if (this.Equals(GameCanvas.panel))
					{
						this.paintInventory(g);
					}
					else
					{
						this.paintGiaoDich(g, false);
					}
				}
				if (this.currentTabIndex == 1)
				{
					this.paintGiaoDich(g, true);
				}
				if (this.currentTabIndex == 2)
				{
					this.paintGiaoDich(g, false);
				}
				break;
			case 14:
				this.paintMapTrans(g);
				break;
			case 15:
				this.paintTop(g);
				break;
			case 16:
				this.paintEnemy(g);
				break;
			case 17:
				this.paintShop(g);
				break;
			case 18:
				this.paintFlagChange(g);
				break;
			case 19:
				this.paintOption(g);
				break;
			case 20:
				this.paintAccount(g);
				break;
			case 21:
				if (this.currentTabIndex == 0)
				{
					this.paintPetInventory(g);
				}
				if (this.currentTabIndex == 1)
				{
					this.paintPetStatus(g);
				}
				if (this.currentTabIndex == 2)
				{
					this.paintInventory(g);
				}
				break;
			case 22:
				this.paintAuto(g);
				break;
			case 23:
				this.paintGameInfo(g);
				break;
			case 24:
				this.paintGameSubInfo(g);
				break;
			case 25:
				this.paintSpeacialSkill(g);
				break;
			}
			GameScr.resetTranslate(g);
			this.paintDetail(g);
			if (this.cmx == this.cmtoX)
			{
				this.cmdClose.paint(g);
			}
			if (this.tabIcon != null && this.tabIcon.isShow)
			{
				this.tabIcon.paint(g);
			}
		}
	}

	// Token: 0x06000846 RID: 2118 RVA: 0x00073988 File Offset: 0x00071B88
	private void paintShop(mGraphics g)
	{
		if (this.type == 1 && this.currentTabIndex == this.currentTabName.Length - 1 && GameCanvas.panel2 == null && this.typeShop != 2)
		{
			this.paintInventory(g);
			return;
		}
		g.setColor(16711680);
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		if (this.typeShop == 2 && this.Equals(GameCanvas.panel))
		{
			if (this.currentTabIndex <= 3 && GameCanvas.isTouch)
			{
				if (this.cmy < -50)
				{
					GameCanvas.paintShukiren(this.xScroll + this.wScroll / 2, this.yScroll + 30, g);
				}
				else if (this.cmy < 0)
				{
					mFont.tahoma_7_grey.drawString(g, mResources.getDown, this.xScroll + this.wScroll / 2, this.yScroll + 15, 2);
				}
				else if (this.cmyLim >= 0)
				{
					if (this.cmy > this.cmyLim + 50)
					{
						GameCanvas.paintShukiren(this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll - 30, g);
					}
					else if (this.cmy > this.cmyLim)
					{
						mFont.tahoma_7_grey.drawString(g, mResources.getUp, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll - 25, 2);
					}
				}
			}
			if (global::Char.myCharz().arrItemShop[this.currentTabIndex].Length == 0 && this.type != 17)
			{
				mFont.tahoma_7_grey.drawString(g, mResources.notYetSell, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll / 2 - 10, 2);
				return;
			}
		}
		g.translate(0, -this.cmy);
		Item[] array = global::Char.myCharz().arrItemShop[this.currentTabIndex];
		if (this.typeShop == 2 && (this.currentTabIndex == 4 || this.type == 17))
		{
			array = global::Char.myCharz().arrItemShop[4];
			if (array.Length == 0)
			{
				mFont.tahoma_7_grey.drawString(g, mResources.notYetSell, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll / 2 - 10, 2);
				return;
			}
		}
		int num = array.Length;
		for (int i = 0; i < num; i++)
		{
			int num2 = this.xScroll + 26;
			int num3 = this.yScroll + i * this.ITEM_HEIGHT;
			int num4 = this.wScroll - 26;
			int h = this.ITEM_HEIGHT - 1;
			int num5 = this.xScroll;
			int num6 = this.yScroll + i * this.ITEM_HEIGHT;
			int num7 = 24;
			int num8 = this.ITEM_HEIGHT - 1;
			if (num3 - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num3 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					g.setColor((i != this.selected) ? 15196114 : 16383818);
					g.fillRect(num2, num3, num4, h);
					g.setColor((i != this.selected) ? 9993045 : 9541120);
					g.fillRect(num5, num6, num7, num8);
					Item item = array[i];
					if (item != null)
					{
						string str = string.Empty;
						if (item.itemOption != null)
						{
							for (int j = 0; j < item.itemOption.Length; j++)
							{
								if (item.itemOption[j].optionTemplate.id == 72)
								{
									str = " [+" + item.itemOption[j].param + "]";
								}
							}
						}
						if ((int)item.isMe != 0 && this.typeShop == 2 && this.currentTabIndex <= 3 && !this.Equals(GameCanvas.panel2))
						{
							mFont.tahoma_7b_green.drawString(g, item.template.name + str, num2 + 5, num3 + 1, 0);
						}
						else
						{
							mFont.tahoma_7_green2.drawString(g, item.template.name + str, num2 + 5, num3 + 1, 0);
						}
						string text = string.Empty;
						if (item.itemOption != null && item.itemOption.Length >= 1)
						{
							if (item.itemOption[0] != null && item.itemOption[0].optionTemplate.id != 102 && item.itemOption[0].optionTemplate.id != 107)
							{
								text += item.itemOption[0].getOptionString();
							}
							mFont mFont = mFont.tahoma_7_blue;
							if (item.compare < 0 && (int)item.template.type != 5)
							{
								mFont = mFont.tahoma_7_red;
							}
							if (this.typeShop == 2 && item.itemOption.Length > 1 && (int)item.buyType != -1)
							{
								text += string.Empty;
							}
							if (this.typeShop != 2 || (this.typeShop == 2 && (int)item.buyType <= 1))
							{
								mFont.drawString(g, text, num2 + 5, num3 + 11, 0);
							}
						}
						if (item.buySpec > 0)
						{
							SmallImage.drawSmallImage(g, (int)item.iconSpec, num2 + num4 - 7, num3 + 9, 0, 3);
							mFont.tahoma_7b_blue.drawString(g, Res.formatNumber((long)item.buySpec), num2 + num4 - 15, num3 + 1, mFont.RIGHT);
						}
						if (item.buyCoin != 0 || item.buyGold != 0)
						{
							if (this.typeShop != 2 && item.powerRequire == 0L)
							{
								if (item.buyCoin > 0)
								{
									g.drawImage(Panel.imgXu, num2 + num4 - 7, num3 + 7, 3);
									mFont.tahoma_7b_yellow.drawString(g, Res.formatNumber((long)item.buyCoin), num2 + num4 - 15, num3 + 1, mFont.RIGHT);
								}
								if (item.buyGold > 0)
								{
									g.drawImage(Panel.imgLuong, num2 + num4 - 7, num3 + 7, 3);
									mFont.tahoma_7b_green.drawString(g, Res.formatNumber((long)item.buyGold), num2 + num4 - 15, num3 + 1, mFont.RIGHT);
								}
							}
							if (this.typeShop == 2 && this.currentTabIndex <= 3 && !this.Equals(GameCanvas.panel2))
							{
								if (item.buyCoin > 0)
								{
									g.drawImage(Panel.imgXu, num2 + num4 - 7, num3 + 7, 3);
									mFont.tahoma_7b_yellow.drawString(g, Res.formatNumber2((long)item.buyCoin), num2 + num4 - 15, num3 + 1, mFont.RIGHT);
								}
								if (item.buyGold > 0)
								{
									g.drawImage(Panel.imgLuong, num2 + num4 - 7, num3 + 7, 3);
									mFont.tahoma_7b_green.drawString(g, Res.formatNumber2((long)item.buyGold), num2 + num4 - 15, num3 + 1, mFont.RIGHT);
								}
							}
						}
						SmallImage.drawSmallImage(g, (int)item.template.iconID, num5 + num7 / 2 - ((item.quantity <= 1) ? 0 : 8), num6 + num8 / 2, 0, 3);
						if (item.quantity > 1)
						{
							mFont.tahoma_7_yellow.drawString(g, "x" + item.quantity, num5 + num7 - 15, num6 + 6, 0);
						}
						if (item.newItem && GameCanvas.gameTick % 10 > 5)
						{
							g.drawImage(Panel.imgNew, num5 + num7 / 2, num3 + 19, 3);
						}
					}
					if (this.typeShop == 2 && (this.Equals(GameCanvas.panel2) || this.currentTabIndex == 4))
					{
						if ((int)item.buyType != 0)
						{
							if ((int)item.buyType == 1)
							{
								mFont.tahoma_7_green.drawString(g, mResources.dangban, num2 + num4 - 5, num3 + 1, mFont.RIGHT);
								if (item.buyCoin != -1)
								{
									g.drawImage(Panel.imgXu, num2 + num4 - 7, num3 + 19, 3);
									mFont.tahoma_7b_yellow.drawString(g, Res.formatNumber2((long)item.buyCoin), num2 + num4 - 15, num3 + 13, mFont.RIGHT);
								}
								else if (item.buyGold != -1)
								{
									g.drawImage(Panel.imgLuongKhoa, num2 + num4 - 7, num3 + 17, 3);
									mFont.tahoma_7b_red.drawString(g, Res.formatNumber2((long)item.buyGold), num2 + num4 - 15, num3 + 11, mFont.RIGHT);
								}
							}
							else if ((int)item.buyType == 2)
							{
								mFont.tahoma_7b_blue.drawString(g, mResources.daban, num2 + num4 - 5, num3 + 1, mFont.RIGHT);
								if (item.buyCoin != -1)
								{
									g.drawImage(Panel.imgXu, num2 + num4 - 7, num3 + 17, 3);
									mFont.tahoma_7b_yellow.drawString(g, Res.formatNumber2((long)item.buyCoin), num2 + num4 - 15, num3 + 11, mFont.RIGHT);
								}
								else if (item.buyGold != -1)
								{
									g.drawImage(Panel.imgLuongKhoa, num2 + num4 - 7, num3 + 17, 3);
									mFont.tahoma_7b_red.drawString(g, Res.formatNumber2((long)item.buyGold), num2 + num4 - 15, num3 + 11, mFont.RIGHT);
								}
							}
						}
					}
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x06000847 RID: 2119 RVA: 0x00003984 File Offset: 0x00001B84
	private void paintAuto(mGraphics g)
	{
	}

	// Token: 0x06000848 RID: 2120 RVA: 0x0007438C File Offset: 0x0007258C
	private void paintPetStatus(mGraphics g)
	{
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		for (int i = 0; i < this.strStatus.Length; i++)
		{
			int x = this.xScroll;
			int num = this.yScroll + i * this.ITEM_HEIGHT;
			int num2 = this.wScroll - 1;
			int h = this.ITEM_HEIGHT - 1;
			if (num - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					g.setColor((i != this.selected) ? 15196114 : 16383818);
					g.fillRect(x, num, num2, h);
					mFont.tahoma_7b_dark.drawString(g, this.strStatus[i], this.xScroll + this.wScroll / 2, num + 6, mFont.CENTER);
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x06000849 RID: 2121 RVA: 0x00003984 File Offset: 0x00001B84
	private void paintPetSkill()
	{
	}

	// Token: 0x0600084A RID: 2122 RVA: 0x000744A4 File Offset: 0x000726A4
	private void paintPetInventory(mGraphics g)
	{
		g.setColor(16711680);
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		Item[] arrItemBody = global::Char.myPetz().arrItemBody;
		Skill[] arrPetSkill = global::Char.myPetz().arrPetSkill;
		for (int i = 0; i < arrItemBody.Length + arrPetSkill.Length; i++)
		{
			bool flag = i < arrItemBody.Length;
			int num = i;
			int num2 = i - arrItemBody.Length;
			int num3 = this.xScroll + 36;
			int num4 = this.yScroll + i * this.ITEM_HEIGHT;
			int num5 = this.wScroll - 36;
			int h = this.ITEM_HEIGHT - 1;
			int num6 = this.xScroll;
			int num7 = this.yScroll + i * this.ITEM_HEIGHT;
			int num8 = 34;
			int num9 = this.ITEM_HEIGHT - 1;
			if (num4 - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num4 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					Item item = (!flag) ? null : arrItemBody[num];
					g.setColor((i != this.selected) ? ((!flag) ? 15723751 : 15196114) : 16383818);
					g.fillRect(num3, num4, num5, h);
					g.setColor((i != this.selected) ? ((!flag) ? 11837316 : 9993045) : 9541120);
					if (item != null)
					{
						if (item.isHaveOption(34))
						{
							g.setColor((i != this.selected) ? Panel.color1[0] : Panel.color2[0]);
						}
						else if (item.isHaveOption(35))
						{
							g.setColor((i != this.selected) ? Panel.color1[1] : Panel.color2[1]);
						}
						else if (item.isHaveOption(36))
						{
							g.setColor((i != this.selected) ? Panel.color1[2] : Panel.color2[2]);
						}
					}
					g.fillRect(num6, num7, num8, num9);
					if (item != null && item.isSelect && GameCanvas.panel.type == 12)
					{
						g.setColor((i != this.selected) ? 6047789 : 7040779);
						g.fillRect(num6, num7, num8, num9);
					}
					if (item != null)
					{
						string text = string.Empty;
						if (item.itemOption != null)
						{
							for (int j = 0; j < item.itemOption.Length; j++)
							{
								if (item.itemOption[j].optionTemplate.id == 72)
								{
									text = " [+" + item.itemOption[j].param + "]";
								}
							}
						}
						mFont.tahoma_7_green2.drawString(g, text + item.template.name + text, num3 + 5, num4 + 1, 0);
						string text2 = string.Empty;
						if (item.itemOption != null)
						{
							if (item.itemOption.Length > 0 && item.itemOption[0] != null && item.itemOption[0].optionTemplate.id != 102 && item.itemOption[0].optionTemplate.id != 107)
							{
								text2 += item.itemOption[0].getOptionString();
							}
							mFont mFont = mFont.tahoma_7_blue;
							if (item.compare < 0 && (int)item.template.type != 5)
							{
								mFont = mFont.tahoma_7_red;
							}
							if (item.itemOption.Length > 1)
							{
								for (int k = 1; k < 2; k++)
								{
									if (item.itemOption[k] != null && item.itemOption[k].optionTemplate.id != 102 && item.itemOption[k].optionTemplate.id != 107)
									{
										text2 = text2 + "," + item.itemOption[k].getOptionString();
									}
								}
							}
							mFont.drawString(g, text2, num3 + 5, num4 + 11, mFont.LEFT);
						}
						SmallImage.drawSmallImage(g, (int)item.template.iconID, num6 + num8 / 2 - ((item.quantity <= 1) ? 0 : 8), num7 + num9 / 2, 0, 3);
						if (item.quantity > 1)
						{
							mFont.tahoma_7_yellow.drawString(g, "x" + item.quantity, num6 + num8 - 15, num7 + 6, 0);
						}
					}
					else if (!flag)
					{
						Skill skill = arrPetSkill[num2];
						g.drawImage(GameScr.imgSkill, num6 + num8 / 2, num7 + num9 / 2, 3);
						if (skill.template != null)
						{
							mFont.tahoma_7_blue.drawString(g, skill.template.name, num3 + 5, num4 + 1, 0);
							mFont.tahoma_7_green2.drawString(g, string.Concat(new object[]
							{
								mResources.level,
								": ",
								skill.point,
								string.Empty
							}), num3 + 5, num4 + 11, 0);
							SmallImage.drawSmallImage(g, skill.template.iconId, num6 + num8 / 2, num7 + num9 / 2, 0, 3);
						}
						else
						{
							mFont.tahoma_7_green2.drawString(g, skill.moreInfo, num3 + 5, num4 + 5, 0);
							SmallImage.drawSmallImage(g, GameScr.efs[98].arrEfInfo[0].idImg, num6 + num8 / 2, num7 + num9 / 2, 0, 3);
						}
					}
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x0600084B RID: 2123 RVA: 0x00074AB8 File Offset: 0x00072CB8
	private void paintScrollArrow(mGraphics g)
	{
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		if ((this.cmy > 24 && this.currentListLength > 0) || (this.Equals(GameCanvas.panel) && this.typeShop == 2 && this.maxPageShop[this.currentTabIndex] > 1))
		{
			g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 1, this.xScroll + this.wScroll - 12, this.yScroll + 3, 0);
		}
		if ((this.cmy < this.cmyLim && this.currentListLength > 0) || (this.Equals(GameCanvas.panel) && this.typeShop == 2 && this.maxPageShop[this.currentTabIndex] > 1))
		{
			g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 0, this.xScroll + this.wScroll - 12, this.yScroll + this.hScroll - 8, 0);
		}
	}

	// Token: 0x0600084C RID: 2124 RVA: 0x00074BC8 File Offset: 0x00072DC8
	private void paintTools(mGraphics g)
	{
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		for (int i = 0; i < Panel.strTool.Length; i++)
		{
			int num = this.xScroll;
			int num2 = this.yScroll + i * this.ITEM_HEIGHT;
			int num3 = this.wScroll - 1;
			int h = this.ITEM_HEIGHT - 1;
			if (num2 - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num2 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					g.setColor((i != this.selected) ? 15196114 : 16383818);
					g.fillRect(num, num2, num3, h);
					mFont.tahoma_7b_dark.drawString(g, Panel.strTool[i], this.xScroll + this.wScroll / 2, num2 + 6, mFont.CENTER);
					if (Panel.strTool[i].Equals(mResources.gameInfo))
					{
						for (int j = 0; j < Panel.vGameInfo.size(); j++)
						{
							GameInfo gameInfo = (GameInfo)Panel.vGameInfo.elementAt(j);
							if (!gameInfo.hasRead)
							{
								if (GameCanvas.gameTick % 20 > 10)
								{
									g.drawImage(Panel.imgNew, num + 10, num2 + 10, 3);
								}
								break;
							}
						}
					}
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x0600084D RID: 2125 RVA: 0x00074D5C File Offset: 0x00072F5C
	private void paintGameSubInfo(mGraphics g)
	{
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		for (int i = 0; i < Panel.contenInfo.Length; i++)
		{
			int num = this.xScroll;
			int num2 = this.yScroll + i * 15;
			int num3 = this.wScroll - 1;
			int num4 = this.ITEM_HEIGHT - 1;
			if (num2 - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num2 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					mFont.tahoma_7b_dark.drawString(g, Panel.contenInfo[i], this.xScroll + 5, num2 + 6, mFont.LEFT);
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x0600084E RID: 2126 RVA: 0x00074E3C File Offset: 0x0007303C
	private void paintGameInfo(mGraphics g)
	{
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		for (int i = 0; i < Panel.vGameInfo.size(); i++)
		{
			GameInfo gameInfo = (GameInfo)Panel.vGameInfo.elementAt(i);
			int num = this.xScroll;
			int num2 = this.yScroll + i * this.ITEM_HEIGHT;
			int num3 = this.wScroll - 1;
			int h = this.ITEM_HEIGHT - 1;
			if (num2 - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num2 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					g.setColor((i != this.selected) ? 15196114 : 16383818);
					g.fillRect(num, num2, num3, h);
					mFont.tahoma_7b_dark.drawString(g, gameInfo.main, this.xScroll + this.wScroll / 2, num2 + 6, mFont.CENTER);
					if (!gameInfo.hasRead && GameCanvas.gameTick % 20 > 10)
					{
						g.drawImage(Panel.imgNew, num + 10, num2 + 10, 3);
					}
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x0600084F RID: 2127 RVA: 0x00074F94 File Offset: 0x00073194
	private void paintSkill(mGraphics g)
	{
		g.setColor(16711680);
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		int num = global::Char.myCharz().nClass.skillTemplates.Length;
		for (int i = 0; i < num + 6; i++)
		{
			int num2 = this.xScroll + 30;
			int num3 = this.yScroll + i * this.ITEM_HEIGHT;
			int num4 = this.wScroll - 30;
			int h = this.ITEM_HEIGHT - 1;
			int num5 = this.xScroll;
			int num6 = this.yScroll + i * this.ITEM_HEIGHT;
			int num7 = this.ITEM_HEIGHT - 1;
			if (num3 - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num3 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					g.setColor((i != this.selected) ? 15196114 : 16383818);
					if (i == 5)
					{
						g.setColor((i != this.selected) ? 16765060 : 16776068);
					}
					g.fillRect(num2, num3, num4, h);
					g.drawImage(GameScr.imgSkill, num5, num6, 0);
					if (i == 0)
					{
						SmallImage.drawSmallImage(g, 567, num5 + 4, num6 + 4, 0, 0);
						string st = string.Concat(new string[]
						{
							mResources.HP,
							" ",
							mResources.root,
							": ",
							NinjaUtil.getMoneys((long)global::Char.myCharz().cHPGoc)
						});
						mFont.tahoma_7b_blue.drawString(g, st, num2 + 5, num3 + 3, 0);
						mFont.tahoma_7_green2.drawString(g, string.Concat(new object[]
						{
							NinjaUtil.getMoneys((long)(global::Char.myCharz().cHPGoc + 1000)),
							" ",
							mResources.potential,
							": ",
							mResources.increase,
							" ",
							global::Char.myCharz().hpFrom1000TiemNang
						}), num2 + 5, num3 + 15, 0);
					}
					if (i == 1)
					{
						SmallImage.drawSmallImage(g, 569, num5 + 4, num6 + 4, 0, 0);
						string st2 = string.Concat(new string[]
						{
							mResources.KI,
							" ",
							mResources.root,
							": ",
							NinjaUtil.getMoneys((long)global::Char.myCharz().cMPGoc)
						});
						mFont.tahoma_7b_blue.drawString(g, st2, num2 + 5, num3 + 3, 0);
						mFont.tahoma_7_green2.drawString(g, string.Concat(new object[]
						{
							NinjaUtil.getMoneys((long)(global::Char.myCharz().cMPGoc + 1000)),
							" ",
							mResources.potential,
							": ",
							mResources.increase,
							" ",
							global::Char.myCharz().mpFrom1000TiemNang
						}), num2 + 5, num3 + 15, 0);
					}
					if (i == 2)
					{
						SmallImage.drawSmallImage(g, 568, num5 + 4, num6 + 4, 0, 0);
						string st3 = string.Concat(new string[]
						{
							mResources.hit_point,
							" ",
							mResources.root,
							": ",
							NinjaUtil.getMoneys((long)global::Char.myCharz().cDamGoc)
						});
						mFont.tahoma_7b_blue.drawString(g, st3, num2 + 5, num3 + 3, 0);
						mFont.tahoma_7_green2.drawString(g, string.Concat(new object[]
						{
							NinjaUtil.getMoneys((long)(global::Char.myCharz().cDamGoc * 100)),
							" ",
							mResources.potential,
							": ",
							mResources.increase,
							" ",
							global::Char.myCharz().damFrom1000TiemNang
						}), num2 + 5, num3 + 15, 0);
					}
					if (i == 3)
					{
						SmallImage.drawSmallImage(g, 721, num5 + 4, num6 + 4, 0, 0);
						string st4 = string.Concat(new string[]
						{
							mResources.armor,
							" ",
							mResources.root,
							": ",
							NinjaUtil.getMoneys((long)global::Char.myCharz().cDefGoc)
						});
						mFont.tahoma_7b_blue.drawString(g, st4, num2 + 5, num3 + 3, 0);
						mFont.tahoma_7_green2.drawString(g, string.Concat(new object[]
						{
							NinjaUtil.getMoneys((long)(500000 + global::Char.myCharz().cDefGoc * 100000)),
							" ",
							mResources.potential,
							": ",
							mResources.increase,
							" ",
							global::Char.myCharz().defFrom1000TiemNang
						}), num2 + 5, num3 + 15, 0);
					}
					if (i == 4)
					{
						SmallImage.drawSmallImage(g, 719, num5 + 4, num6 + 4, 0, 0);
						string st5 = string.Concat(new object[]
						{
							mResources.critical,
							" ",
							mResources.root,
							": ",
							global::Char.myCharz().cCriticalGoc,
							"%"
						});
						long num8 = 50000000L;
						for (int j = 0; j < global::Char.myCharz().cCriticalGoc; j++)
						{
							num8 *= 5L;
						}
						mFont.tahoma_7b_blue.drawString(g, st5, num2 + 5, num3 + 3, 0);
						long m = num8;
						mFont.tahoma_7_green2.drawString(g, string.Concat(new object[]
						{
							NinjaUtil.getMoneys(m),
							" ",
							mResources.potential,
							": ",
							mResources.increase,
							" ",
							global::Char.myCharz().criticalFrom1000Tiemnang
						}), num2 + 5, num3 + 15, 0);
					}
					if (i == 5)
					{
						if (Panel.specialInfo != null)
						{
							SmallImage.drawSmallImage(g, (int)Panel.spearcialImage, num5 + 4, num6 + 4, 0, 0);
							string[] array = mFont.tahoma_7.splitFontArray(Panel.specialInfo, 120);
							for (int k = 0; k < array.Length; k++)
							{
								mFont.tahoma_7_green2.drawString(g, array[k], num2 + 5, num3 + 3 + k * 12, 0);
							}
						}
						else
						{
							mFont.tahoma_7_green2.drawString(g, string.Empty, num2 + 5, num3 + 9, 0);
						}
					}
					if (i >= 6)
					{
						int num9 = i - 6;
						SkillTemplate skillTemplate = global::Char.myCharz().nClass.skillTemplates[num9];
						SmallImage.drawSmallImage(g, skillTemplate.iconId, num5 + 4, num6 + 4, 0, 0);
						Skill skill = global::Char.myCharz().getSkill(skillTemplate);
						if (skill != null)
						{
							mFont.tahoma_7b_blue.drawString(g, skillTemplate.name, num2 + 5, num3 + 3, 0);
							mFont.tahoma_7_blue.drawString(g, mResources.level + ": " + skill.point, num2 + num4 - 5, num3 + 3, mFont.RIGHT);
							if (skill.point == skillTemplate.maxPoint)
							{
								mFont.tahoma_7_green2.drawString(g, mResources.max_level_reach, num2 + 5, num3 + 15, 0);
							}
							else
							{
								Skill skill2 = skillTemplate.skills[skill.point];
								mFont.tahoma_7_green2.drawString(g, string.Concat(new object[]
								{
									mResources.level,
									" ",
									skill.point + 1,
									" ",
									mResources.need,
									" ",
									Res.formatNumber2(skill2.powRequire),
									" ",
									mResources.potential
								}), num2 + 5, num3 + 15, 0);
							}
						}
						else
						{
							Skill skill3 = skillTemplate.skills[0];
							mFont.tahoma_7b_green.drawString(g, skillTemplate.name, num2 + 5, num3 + 3, 0);
							mFont.tahoma_7_green2.drawString(g, string.Concat(new string[]
							{
								mResources.need_upper,
								" ",
								Res.formatNumber2(skill3.powRequire),
								" ",
								mResources.potential_to_learn
							}), num2 + 5, num3 + 15, 0);
						}
					}
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x06000850 RID: 2128 RVA: 0x000757E4 File Offset: 0x000739E4
	private void paintMapTrans(mGraphics g)
	{
		g.setColor(16711680);
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		for (int i = 0; i < this.mapNames.Length; i++)
		{
			int num = this.xScroll + 36;
			int num2 = this.yScroll + i * this.ITEM_HEIGHT;
			int num3 = this.wScroll - 36;
			int h = this.ITEM_HEIGHT - 1;
			int num4 = this.xScroll;
			int num5 = this.yScroll + i * this.ITEM_HEIGHT;
			int num6 = this.ITEM_HEIGHT - 1;
			if (num2 - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num2 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					g.setColor((i != this.selected) ? 15196114 : 16383818);
					g.fillRect(this.xScroll, num2, this.wScroll, h);
					mFont.tahoma_7b_blue.drawString(g, this.mapNames[i], 5, num2 + 1, 0);
					mFont.tahoma_7_grey.drawString(g, this.planetNames[i], 5, num2 + 11, 0);
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x06000851 RID: 2129 RVA: 0x00075944 File Offset: 0x00073B44
	private void paintZone(mGraphics g)
	{
		g.setColor(16711680);
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		int[] zones = GameScr.gI().zones;
		int[] pts = GameScr.gI().pts;
		for (int i = 0; i < pts.Length; i++)
		{
			int num = this.xScroll + 36;
			int num2 = this.yScroll + i * this.ITEM_HEIGHT;
			int num3 = this.wScroll - 36;
			int h = this.ITEM_HEIGHT - 1;
			int num4 = this.xScroll;
			int y = this.yScroll + i * this.ITEM_HEIGHT;
			int num5 = 34;
			int h2 = this.ITEM_HEIGHT - 1;
			if (num2 - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num2 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					g.setColor((i != this.selected) ? 15196114 : 16383818);
					g.fillRect(num, num2, num3, h);
					g.setColor(this.zoneColor[pts[i]]);
					g.fillRect(num4, y, num5, h2);
					if (zones[i] != -1)
					{
						if (pts[i] != 1)
						{
							mFont.tahoma_7_yellow.drawString(g, zones[i] + string.Empty, num4 + num5 / 2, num2 + 6, mFont.CENTER);
						}
						else
						{
							mFont.tahoma_7_grey.drawString(g, zones[i] + string.Empty, num4 + num5 / 2, num2 + 6, mFont.CENTER);
						}
						mFont.tahoma_7_green2.drawString(g, GameScr.gI().numPlayer[i] + "/" + GameScr.gI().maxPlayer[i], num + 5, num2 + 6, 0);
					}
					if (GameScr.gI().rankName1[i] != null)
					{
						mFont.tahoma_7_grey.drawString(g, string.Concat(new object[]
						{
							GameScr.gI().rankName1[i],
							"(Top ",
							GameScr.gI().rank1[i],
							")"
						}), num + num3 - 2, num2 + 1, mFont.RIGHT);
						mFont.tahoma_7_grey.drawString(g, string.Concat(new object[]
						{
							GameScr.gI().rankName2[i],
							"(Top ",
							GameScr.gI().rank2[i],
							")"
						}), num + num3 - 2, num2 + 11, mFont.RIGHT);
					}
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x06000852 RID: 2130 RVA: 0x00075C10 File Offset: 0x00073E10
	private void paintSpeacialSkill(mGraphics g)
	{
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		g.setColor(0);
		if (this.currentListLength == 0)
		{
			return;
		}
		int num = (this.cmy + this.hScroll) / 24 + 1;
		if (num < this.hScroll / 24 + 1)
		{
			num = this.hScroll / 24 + 1;
		}
		if (num > this.currentListLength)
		{
			num = this.currentListLength;
		}
		int num2 = this.cmy / 24;
		if (num2 >= num)
		{
			num2 = num - 1;
		}
		if (num2 < 0)
		{
			num2 = 0;
		}
		for (int i = num2; i < num; i++)
		{
			int num3 = this.xScroll;
			int num4 = this.yScroll + i * this.ITEM_HEIGHT;
			int num5 = 24;
			int num6 = this.ITEM_HEIGHT - 1;
			int num7 = this.xScroll + num5;
			int num8 = this.yScroll + i * this.ITEM_HEIGHT;
			int num9 = this.wScroll - num5;
			int h = this.ITEM_HEIGHT - 1;
			g.setColor((i != this.selected) ? 15196114 : 16383818);
			g.fillRect(num7, num8, num9, h);
			g.setColor((i != this.selected) ? 9993045 : 9541120);
			g.fillRect(num3, num4, num5, num6);
			SmallImage.drawSmallImage(g, (int)global::Char.myCharz().imgSpeacialSkill[this.currentTabIndex][i], num3 + num5 / 2, num4 + num6 / 2, 0, 3);
			string[] array = mFont.tahoma_7_grey.splitFontArray(global::Char.myCharz().infoSpeacialSkill[this.currentTabIndex][i], 140);
			for (int j = 0; j < array.Length; j++)
			{
				mFont.tahoma_7_grey.drawString(g, array[j], num7 + 5, num8 + 1 + j * 11, 0);
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x06000853 RID: 2131 RVA: 0x00075E10 File Offset: 0x00074010
	private void paintBox(mGraphics g)
	{
		g.setColor(16711680);
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		Item[] arrItemBox = global::Char.myCharz().arrItemBox;
		int num = arrItemBox.Length;
		for (int i = 0; i < num; i++)
		{
			int num2 = this.xScroll + 36;
			int num3 = this.yScroll + i * this.ITEM_HEIGHT;
			int num4 = this.wScroll - 36;
			int h = this.ITEM_HEIGHT - 1;
			int num5 = this.xScroll;
			int num6 = this.yScroll + i * this.ITEM_HEIGHT;
			int num7 = 34;
			int num8 = this.ITEM_HEIGHT - 1;
			if (num3 - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num3 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					g.setColor((i != this.selected) ? 15196114 : 16383818);
					g.fillRect(num2, num3, num4, h);
					Item item = arrItemBox[i];
					g.setColor((i != this.selected) ? 9993045 : 9541120);
					if (item != null)
					{
						if (item.isHaveOption(34))
						{
							g.setColor((i != this.selected) ? Panel.color1[0] : Panel.color2[0]);
						}
						else if (item.isHaveOption(35))
						{
							g.setColor((i != this.selected) ? Panel.color1[1] : Panel.color2[1]);
						}
						else if (item.isHaveOption(36))
						{
							g.setColor((i != this.selected) ? Panel.color1[2] : Panel.color2[2]);
						}
					}
					g.fillRect(num5, num6, num7, num8);
					if (item != null)
					{
						string str = string.Empty;
						if (item.itemOption != null)
						{
							for (int j = 0; j < item.itemOption.Length; j++)
							{
								if (item.itemOption[j].optionTemplate.id == 72)
								{
									str = " [" + item.itemOption[j].getOptionString() + "]";
								}
							}
						}
						mFont.tahoma_7_green2.drawString(g, str + item.template.name, num2 + 5, num3 + 1, 0);
						string text = string.Empty;
						if (item.itemOption != null)
						{
							if (item.itemOption.Length > 0 && item.itemOption[0] != null)
							{
								text += item.itemOption[0].getOptionString();
							}
							mFont mFont = mFont.tahoma_7_blue;
							if (item.compare < 0 && (int)item.template.type != 5)
							{
								mFont = mFont.tahoma_7_red;
							}
							if (item.itemOption.Length > 1)
							{
								for (int k = 1; k < item.itemOption.Length; k++)
								{
									if (item.itemOption[k] != null && item.itemOption[k].optionTemplate.id != 102 && item.itemOption[k].optionTemplate.id != 107)
									{
										text = text + "," + item.itemOption[k].getOptionString();
									}
								}
							}
							mFont.drawString(g, text, num2 + 5, num3 + 11, mFont.LEFT);
						}
						SmallImage.drawSmallImage(g, (int)item.template.iconID, num5 + num7 / 2 - ((item.quantity <= 1) ? 0 : 8), num6 + num8 / 2, 0, 3);
						if (item.quantity > 1)
						{
							mFont.tahoma_7_yellow.drawString(g, "x" + item.quantity, num5 + num7 - 15, num6 + 6, 0);
						}
					}
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x06000854 RID: 2132 RVA: 0x00076248 File Offset: 0x00074448
	public Member getCurrMember()
	{
		if (this.selected < 2)
		{
			return null;
		}
		if (this.selected > ((this.member == null) ? this.myMember.size() : this.member.size()) + 1)
		{
			return null;
		}
		return (this.member == null) ? ((Member)this.myMember.elementAt(this.selected - 2)) : ((Member)this.member.elementAt(this.selected - 2));
	}

	// Token: 0x06000855 RID: 2133 RVA: 0x00007530 File Offset: 0x00005730
	public ClanMessage getCurrMessage()
	{
		if (this.selected < 2)
		{
			return null;
		}
		if (this.selected > ClanMessage.vMessage.size() + 1)
		{
			return null;
		}
		return (ClanMessage)ClanMessage.vMessage.elementAt(this.selected - 2);
	}

	// Token: 0x06000856 RID: 2134 RVA: 0x00007570 File Offset: 0x00005770
	public Clan getCurrClan()
	{
		if (this.selected < 2)
		{
			return null;
		}
		if (this.selected > this.clans.Length + 1)
		{
			return null;
		}
		return this.clans[this.selected - 2];
	}

	// Token: 0x06000857 RID: 2135 RVA: 0x000762D8 File Offset: 0x000744D8
	private void paintLogChat(mGraphics g)
	{
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		g.setColor(0);
		if (this.logChat.size() == 0)
		{
			mFont.tahoma_7_green2.drawString(g, mResources.no_msg, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll / 2 - mFont.tahoma_7.getHeight() / 2 + 24, 2);
		}
		for (int i = 0; i < this.currentListLength; i++)
		{
			int num = this.xScroll;
			int num2 = this.yScroll + i * this.ITEM_HEIGHT;
			int num3 = 24;
			int h = this.ITEM_HEIGHT - 1;
			int num4 = this.xScroll + num3;
			int num5 = this.yScroll + i * this.ITEM_HEIGHT;
			int num6 = this.wScroll - num3;
			int num7 = this.ITEM_HEIGHT - 1;
			if (i == 0)
			{
				g.setColor(15196114);
				g.fillRect(num, num5, this.wScroll, num7);
				g.drawImage((i != this.selected) ? GameScr.imgLbtn2 : GameScr.imgLbtnFocus2, this.xScroll + this.wScroll - 5, num5 + 2, StaticObj.TOP_RIGHT);
				((i != this.selected) ? mFont.tahoma_7b_dark : mFont.tahoma_7b_green2).drawString(g, (!this.isViewChatServer) ? mResources.on : mResources.off, this.xScroll + this.wScroll - 22, num5 + 7, 2);
				mFont.tahoma_7_grey.drawString(g, (!this.isViewChatServer) ? mResources.onPlease : mResources.offPlease, this.xScroll + 5, num5 + num7 / 2 - 4, mFont.LEFT);
			}
			else
			{
				g.setColor((i != this.selected) ? 15196114 : 16383818);
				g.fillRect(num4, num5, num6, num7);
				g.setColor((i != this.selected) ? 9993045 : 9541120);
				g.fillRect(num, num2, num3, h);
				InfoItem infoItem = (InfoItem)this.logChat.elementAt(i - 1);
				Part part = GameScr.parts[infoItem.charInfo.head];
				SmallImage.drawSmallImage(g, (int)part.pi[global::Char.CharInfo[0][0][0]].id, num + (int)part.pi[global::Char.CharInfo[0][0][0]].dx, num2 + 3 + (int)part.pi[global::Char.CharInfo[0][0][0]].dy, 0, 0);
				g.setClip(this.xScroll, this.yScroll + this.cmy, this.wScroll, this.hScroll);
				mFont mFont = mFont.tahoma_7b_dark;
				mFont = mFont.tahoma_7b_green2;
				mFont.drawString(g, infoItem.charInfo.cName, num4 + 5, num5, 0);
				if (!infoItem.isChatServer)
				{
					mFont.tahoma_7_blue.drawString(g, Res.split(infoItem.s, "|", 0)[2], num4 + 5, num5 + 11, 0);
				}
				else
				{
					mFont.tahoma_7_red.drawString(g, Res.split(infoItem.s, "|", 0)[2], num4 + 5, num5 + 11, 0);
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x06000858 RID: 2136 RVA: 0x00076650 File Offset: 0x00074850
	private void paintFlagChange(mGraphics g)
	{
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		g.setColor(0);
		for (int i = 0; i < this.currentListLength; i++)
		{
			int num = this.xScroll + 26;
			int num2 = this.yScroll + i * this.ITEM_HEIGHT;
			int num3 = this.wScroll - 26;
			int h = this.ITEM_HEIGHT - 1;
			int num4 = this.xScroll;
			int num5 = this.yScroll + i * this.ITEM_HEIGHT;
			int num6 = 24;
			int num7 = this.ITEM_HEIGHT - 1;
			if (num2 - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num2 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					g.setColor((i != this.selected) ? 15196114 : 16383818);
					g.fillRect(num, num2, num3, h);
					g.setColor((i != this.selected) ? 9993045 : 9541120);
					g.fillRect(num4, num5, num6, num7);
					Item item = (Item)this.vFlag.elementAt(i);
					if (item != null)
					{
						mFont.tahoma_7_green2.drawString(g, item.template.name, num + 5, num2 + 1, 0);
						string text = string.Empty;
						if (item.itemOption != null && item.itemOption.Length >= 1)
						{
							if (item.itemOption[0] != null && item.itemOption[0].optionTemplate.id != 102 && item.itemOption[0].optionTemplate.id != 107)
							{
								text += item.itemOption[0].getOptionString();
							}
							mFont tahoma_7_blue = mFont.tahoma_7_blue;
							tahoma_7_blue.drawString(g, text, num + 5, num2 + 11, 0);
							SmallImage.drawSmallImage(g, (int)item.template.iconID, num4 + num6 / 2 - ((item.quantity <= 1) ? 0 : 8), num5 + num7 / 2, 0, 3);
						}
					}
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x06000859 RID: 2137 RVA: 0x000768A0 File Offset: 0x00074AA0
	private void paintEnemy(mGraphics g)
	{
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		g.setColor(0);
		if (this.currentListLength == 0)
		{
			mFont.tahoma_7_green2.drawString(g, mResources.no_enemy, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll / 2 - mFont.tahoma_7.getHeight() / 2, 2);
			return;
		}
		for (int i = 0; i < this.currentListLength; i++)
		{
			int num = this.xScroll;
			int num2 = this.yScroll + i * this.ITEM_HEIGHT;
			int num3 = 24;
			int h = this.ITEM_HEIGHT - 1;
			int num4 = this.xScroll + num3;
			int num5 = this.yScroll + i * this.ITEM_HEIGHT;
			int num6 = this.wScroll - num3;
			int h2 = this.ITEM_HEIGHT - 1;
			g.setColor((i != this.selected) ? 15196114 : 16383818);
			g.fillRect(num4, num5, num6, h2);
			g.setColor((i != this.selected) ? 9993045 : 9541120);
			g.fillRect(num, num2, num3, h);
			InfoItem infoItem = (InfoItem)this.vEnemy.elementAt(i);
			Part part = GameScr.parts[infoItem.charInfo.head];
			if (mSystem.clientType != 7)
			{
				SmallImage.drawSmallImage(g, (int)part.pi[global::Char.CharInfo[0][0][0]].id, num + (int)part.pi[global::Char.CharInfo[0][0][0]].dx, num2 + 3 + (int)part.pi[global::Char.CharInfo[0][0][0]].dy, 0, 0);
			}
			g.setClip(this.xScroll, this.yScroll + this.cmy, this.wScroll, this.hScroll);
			if (infoItem.isOnline)
			{
				mFont.tahoma_7b_green.drawString(g, infoItem.charInfo.cName, num4 + 5, num5, 0);
				mFont.tahoma_7_blue.drawString(g, infoItem.s, num4 + 5, num5 + 11, 0);
			}
			else
			{
				mFont.tahoma_7_grey.drawString(g, infoItem.charInfo.cName, num4 + 5, num5, 0);
				mFont.tahoma_7_grey.drawString(g, infoItem.s, num4 + 5, num5 + 11, 0);
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x0600085A RID: 2138 RVA: 0x00076B28 File Offset: 0x00074D28
	private void paintFriend(mGraphics g)
	{
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		g.setColor(0);
		if (this.currentListLength == 0)
		{
			mFont.tahoma_7_green2.drawString(g, mResources.no_friend, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll / 2 - mFont.tahoma_7.getHeight() / 2, 2);
			return;
		}
		for (int i = 0; i < this.currentListLength; i++)
		{
			int num = this.xScroll;
			int num2 = this.yScroll + i * this.ITEM_HEIGHT;
			int num3 = 24;
			int h = this.ITEM_HEIGHT - 1;
			int num4 = this.xScroll + num3;
			int num5 = this.yScroll + i * this.ITEM_HEIGHT;
			int num6 = this.wScroll - num3;
			int h2 = this.ITEM_HEIGHT - 1;
			g.setColor((i != this.selected) ? 15196114 : 16383818);
			g.fillRect(num4, num5, num6, h2);
			g.setColor((i != this.selected) ? 9993045 : 9541120);
			g.fillRect(num, num2, num3, h);
			InfoItem infoItem = (InfoItem)this.vFriend.elementAt(i);
			Part part = GameScr.parts[infoItem.charInfo.head];
			if (mSystem.clientType != 7)
			{
				SmallImage.drawSmallImage(g, (int)part.pi[global::Char.CharInfo[0][0][0]].id, num + (int)part.pi[global::Char.CharInfo[0][0][0]].dx, num2 + 3 + (int)part.pi[global::Char.CharInfo[0][0][0]].dy, 0, 0);
			}
			g.setClip(this.xScroll, this.yScroll + this.cmy, this.wScroll, this.hScroll);
			if (infoItem.isOnline)
			{
				mFont.tahoma_7b_green.drawString(g, infoItem.charInfo.cName, num4 + 5, num5, 0);
				mFont.tahoma_7_blue.drawString(g, infoItem.s, num4 + 5, num5 + 11, 0);
			}
			else
			{
				mFont.tahoma_7_grey.drawString(g, infoItem.charInfo.cName, num4 + 5, num5, 0);
				mFont.tahoma_7_grey.drawString(g, infoItem.s, num4 + 5, num5 + 11, 0);
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x0600085B RID: 2139 RVA: 0x00076DB0 File Offset: 0x00074FB0
	public void paintPlayerMenu(mGraphics g)
	{
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		for (int i = 0; i < this.vPlayerMenu.size(); i++)
		{
			int x = this.xScroll;
			int num = this.yScroll + i * this.ITEM_HEIGHT;
			int num2 = this.wScroll - 1;
			int h = this.ITEM_HEIGHT - 1;
			if (num - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					Command command = (Command)this.vPlayerMenu.elementAt(i);
					g.setColor((i != this.selected) ? 15196114 : 16383818);
					g.fillRect(x, num, num2, h);
					if (command.caption2.Equals(string.Empty))
					{
						mFont.tahoma_7b_dark.drawString(g, command.caption, this.xScroll + this.wScroll / 2, num + 6, mFont.CENTER);
					}
					else
					{
						mFont.tahoma_7b_dark.drawString(g, command.caption, this.xScroll + this.wScroll / 2, num + 1, mFont.CENTER);
						mFont.tahoma_7b_dark.drawString(g, command.caption2, this.xScroll + this.wScroll / 2, num + 11, mFont.CENTER);
					}
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x0600085C RID: 2140 RVA: 0x00076F4C File Offset: 0x0007514C
	private void paintClans(mGraphics g)
	{
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(-this.cmx, -this.cmy);
		g.setColor(0);
		int num = this.xScroll + this.wScroll / 2 - this.clansOption.Length * this.TAB_W / 2;
		if (this.currentListLength == 2)
		{
			mFont.tahoma_7_green2.drawString(g, this.clanReport, this.xScroll + this.wScroll / 2, this.yScroll + 24 + this.hScroll / 2 - mFont.tahoma_7.getHeight() / 2, 2);
			if (this.isMessage && this.myMember.size() == 1)
			{
				for (int i = 0; i < mResources.clanEmpty.Length; i++)
				{
					mFont.tahoma_7b_dark.drawString(g, mResources.clanEmpty[i], this.xScroll + this.wScroll / 2, this.yScroll + 24 + this.hScroll / 2 - mResources.clanEmpty.Length * 12 / 2 + i * 12, mFont.CENTER);
				}
			}
		}
		for (int j = 0; j < this.currentListLength; j++)
		{
			int num2 = this.xScroll;
			int num3 = this.yScroll + j * this.ITEM_HEIGHT;
			int num4 = 24;
			int num5 = this.ITEM_HEIGHT - 1;
			int num6 = this.xScroll + num4;
			int num7 = this.yScroll + j * this.ITEM_HEIGHT;
			int num8 = this.wScroll - num4;
			int num9 = this.ITEM_HEIGHT - 1;
			if (num7 - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num7 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					if (j == 0)
					{
						for (int k = 0; k < this.clansOption.Length; k++)
						{
							g.setColor((k != this.cSelected || j != this.selected) ? 15723751 : 16383818);
							g.fillRect(num + k * this.TAB_W, num7, this.TAB_W - 1, 23);
							for (int l = 0; l < this.clansOption[k].Length; l++)
							{
								mFont.tahoma_7_grey.drawString(g, this.clansOption[k][l], num + k * this.TAB_W + this.TAB_W / 2, this.yScroll + l * 11, mFont.CENTER);
							}
						}
					}
					else if (j == 1)
					{
						g.setColor((j != this.selected) ? 15196114 : 16383818);
						g.fillRect(this.xScroll, num7, this.wScroll, num9);
						if (this.clanInfo != null)
						{
							mFont.tahoma_7b_dark.drawString(g, this.clanInfo, this.xScroll + this.wScroll / 2, num7 + 6, mFont.CENTER);
						}
					}
					else if (this.isSearchClan)
					{
						if (this.clans != null)
						{
							if (this.clans.Length != 0)
							{
								g.setColor((j != this.selected) ? 15196114 : 16383818);
								g.fillRect(num6, num7, num8, num9);
								g.setColor((j != this.selected) ? 9993045 : 9541120);
								g.fillRect(num2, num3, num4, num5);
								if (ClanImage.isExistClanImage(this.clans[j - 2].imgID))
								{
									if (ClanImage.getClanImage((sbyte)this.clans[j - 2].imgID).idImage != null)
									{
										SmallImage.drawSmallImage(g, (int)ClanImage.getClanImage((sbyte)this.clans[j - 2].imgID).idImage[0], num2 + num4 / 2, num3 + num5 / 2, 0, StaticObj.VCENTER_HCENTER);
									}
								}
								else
								{
									ClanImage clanImage = new ClanImage();
									clanImage.ID = this.clans[j - 2].imgID;
									if (!ClanImage.isExistClanImage(clanImage.ID))
									{
										ClanImage.addClanImage(clanImage);
									}
								}
								mFont.tahoma_7b_green2.drawString(g, this.clans[j - 2].name, num6 + 5, num7, 0);
								g.setClip(num6, num7, num8 - 10, num9);
								mFont.tahoma_7_blue.drawString(g, this.clans[j - 2].slogan, num6 + 5, num7 + 11, 0);
								g.setClip(this.xScroll, this.yScroll + this.cmy, this.wScroll, this.hScroll);
								mFont.tahoma_7_green2.drawString(g, this.clans[j - 2].currMember + "/" + this.clans[j - 2].maxMember, num6 + num8 - 5, num7, mFont.RIGHT);
							}
						}
					}
					else if (this.isViewMember)
					{
						g.setColor((j != this.selected) ? 15196114 : 16383818);
						g.fillRect(num6, num7, num8, num9);
						g.setColor((j != this.selected) ? 9993045 : 9541120);
						g.fillRect(num2, num3, num4, num5);
						Member member = (this.member == null) ? ((Member)this.myMember.elementAt(j - 2)) : ((Member)this.member.elementAt(j - 2));
						Part part = GameScr.parts[(int)member.head];
						SmallImage.drawSmallImage(g, (int)part.pi[global::Char.CharInfo[0][0][0]].id, num2 + (int)part.pi[global::Char.CharInfo[0][0][0]].dx, num3 + 3 + (int)part.pi[global::Char.CharInfo[0][0][0]].dy, 0, 0);
						g.setClip(this.xScroll, this.yScroll + this.cmy, this.wScroll, this.hScroll);
						mFont mFont = mFont.tahoma_7b_dark;
						if ((int)member.role == 0)
						{
							mFont = mFont.tahoma_7b_red;
						}
						else if ((int)member.role == 1)
						{
							mFont = mFont.tahoma_7b_green;
						}
						else if ((int)member.role == 2)
						{
							mFont = mFont.tahoma_7b_green2;
						}
						mFont.drawString(g, member.name, num6 + 5, num7, 0);
						mFont.tahoma_7_blue.drawString(g, mResources.power + ": " + member.powerPoint, num6 + 5, num7 + 11, 0);
						SmallImage.drawSmallImage(g, 7223, num6 + num8 - 7, num7 + 12, 0, 3);
						mFont.tahoma_7_blue.drawString(g, string.Empty + member.clanPoint, num6 + num8 - 15, num7 + 6, mFont.RIGHT);
					}
					else if (this.isMessage && ClanMessage.vMessage.size() != 0)
					{
						ClanMessage clanMessage = (ClanMessage)ClanMessage.vMessage.elementAt(j - 2);
						g.setColor((j != this.selected || clanMessage.option != null) ? 15196114 : 16383818);
						g.fillRect(num2, num3, num8 + num4, num9);
						clanMessage.paint(g, num2, num3);
						if (clanMessage.option != null)
						{
							int num10 = this.xScroll + this.wScroll - 2 - clanMessage.option.Length * 40;
							for (int m = 0; m < clanMessage.option.Length; m++)
							{
								if (m == this.cSelected && j == this.selected)
								{
									g.drawImage(GameScr.imgLbtnFocus2, num10 + m * 40 + 20, num7 + num9 / 2, StaticObj.VCENTER_HCENTER);
									mFont.tahoma_7b_green2.drawString(g, clanMessage.option[m], num10 + m * 40 + 20, num7 + 6, mFont.CENTER);
								}
								else
								{
									g.drawImage(GameScr.imgLbtn2, num10 + m * 40 + 20, num7 + num9 / 2, StaticObj.VCENTER_HCENTER);
									mFont.tahoma_7b_dark.drawString(g, clanMessage.option[m], num10 + m * 40 + 20, num7 + 6, mFont.CENTER);
								}
							}
						}
					}
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x0600085D RID: 2141 RVA: 0x000777F0 File Offset: 0x000759F0
	private void paintArchivement(mGraphics g)
	{
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		g.setColor(0);
		if (this.currentListLength == 0)
		{
			mFont.tahoma_7_green2.drawString(g, mResources.no_mission, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll / 2 - mFont.tahoma_7.getHeight() / 2, 2);
			return;
		}
		if (global::Char.myCharz().arrArchive == null)
		{
			return;
		}
		if (global::Char.myCharz().arrArchive.Length != this.currentListLength)
		{
			return;
		}
		for (int i = 0; i < this.currentListLength; i++)
		{
			int num = this.xScroll;
			int num2 = this.yScroll + i * this.ITEM_HEIGHT;
			int num3 = this.wScroll;
			int num4 = this.ITEM_HEIGHT - 1;
			Archivement archivement = global::Char.myCharz().arrArchive[i];
			g.setColor((i != this.selected || ((archivement.isRecieve || archivement.isFinish) && (!archivement.isRecieve || !archivement.isFinish))) ? 15196114 : 16383818);
			g.fillRect(num, num2, num3, num4);
			if (archivement != null)
			{
				if (!archivement.isFinish)
				{
					mFont.tahoma_7.drawString(g, archivement.info1, num + 5, num2, 0);
					mFont.tahoma_7_green.drawString(g, archivement.money + " " + mResources.RUBY, num + num3 - 5, num2, mFont.RIGHT);
					mFont.tahoma_7_red.drawString(g, archivement.info2, num + 5, num2 + 11, 0);
				}
				else if (archivement.isFinish && !archivement.isRecieve)
				{
					mFont.tahoma_7.drawString(g, archivement.info1, num + 5, num2, 0);
					mFont.tahoma_7_blue.drawString(g, string.Concat(new object[]
					{
						mResources.reward_mission,
						archivement.money,
						" ",
						mResources.RUBY
					}), num + 5, num2 + 11, 0);
					if (i == this.selected)
					{
						mFont.tahoma_7b_green2.drawString(g, mResources.receive_upper, num + num3 - 20, num2 + 6, mFont.CENTER);
						mFont.tahoma_7b_dark.drawString(g, mResources.receive_upper, num + num3 - 20, num2 + 6, mFont.CENTER);
					}
					else
					{
						g.drawImage(GameScr.imgLbtn2, num + num3 - 20, num2 + num4 / 2, StaticObj.VCENTER_HCENTER);
						mFont.tahoma_7b_dark.drawString(g, mResources.receive_upper, num + num3 - 20, num2 + 6, mFont.CENTER);
					}
				}
				else if (archivement.isFinish && archivement.isRecieve)
				{
					mFont.tahoma_7_green.drawString(g, archivement.info1, num + 5, num2, 0);
					mFont.tahoma_7_green.drawString(g, archivement.info2, num + 5, num2 + 11, 0);
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x0600085E RID: 2142 RVA: 0x00077B14 File Offset: 0x00075D14
	private void paintCombine(mGraphics g)
	{
		g.setColor(16711680);
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		if (this.vItemCombine.size() == 0)
		{
			if (this.combineInfo != null)
			{
				for (int i = 0; i < this.combineInfo.Length; i++)
				{
					mFont.tahoma_7b_dark.drawString(g, this.combineInfo[i], this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll / 2 - this.combineInfo.Length * 14 / 2 + i * 14 + 5, 2);
				}
			}
			return;
		}
		for (int j = 0; j < this.vItemCombine.size() + 1; j++)
		{
			int num = this.xScroll + 36;
			int num2 = this.yScroll + j * this.ITEM_HEIGHT;
			int num3 = this.wScroll - 36;
			int num4 = this.ITEM_HEIGHT - 1;
			int num5 = this.xScroll;
			int num6 = this.yScroll + j * this.ITEM_HEIGHT;
			int num7 = 34;
			int num8 = this.ITEM_HEIGHT - 1;
			if (num2 - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num2 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					if (j == this.vItemCombine.size())
					{
						if (this.vItemCombine.size() > 0)
						{
							if (!GameCanvas.isTouch && j == this.selected)
							{
								g.setColor(16383818);
								g.fillRect(num5, num2, this.wScroll, num4 + 2);
							}
							if ((j == this.selected && this.keyTouchCombine == 1) || (!GameCanvas.isTouch && j == this.selected))
							{
								g.drawImage(GameScr.imgLbtnFocus, this.xScroll + this.wScroll / 2, num2 + num4 / 2 + 1, StaticObj.VCENTER_HCENTER);
								mFont.tahoma_7b_green2.drawString(g, mResources.UPGRADE, this.xScroll + this.wScroll / 2, num2 + num4 / 2 - 4, mFont.CENTER);
							}
							else
							{
								g.drawImage(GameScr.imgLbtn, this.xScroll + this.wScroll / 2, num2 + num4 / 2 + 1, StaticObj.VCENTER_HCENTER);
								mFont.tahoma_7b_dark.drawString(g, mResources.UPGRADE, this.xScroll + this.wScroll / 2, num2 + num4 / 2 - 4, mFont.CENTER);
							}
						}
					}
					else
					{
						g.setColor((j != this.selected) ? 15196114 : 16383818);
						g.fillRect(num, num2, num3, num4);
						g.setColor((j != this.selected) ? 9993045 : 9541120);
						Item item = (Item)this.vItemCombine.elementAt(j);
						if (item != null)
						{
							if (item.isHaveOption(34))
							{
								g.setColor((j != this.selected) ? Panel.color1[0] : Panel.color2[0]);
							}
							else if (item.isHaveOption(35))
							{
								g.setColor((j != this.selected) ? Panel.color1[1] : Panel.color2[1]);
							}
							else if (item.isHaveOption(36))
							{
								g.setColor((j != this.selected) ? Panel.color1[2] : Panel.color2[2]);
							}
						}
						g.fillRect(num5, num6, num7, num8);
						if (item != null)
						{
							string str = string.Empty;
							if (item.itemOption != null)
							{
								for (int k = 0; k < item.itemOption.Length; k++)
								{
									if (item.itemOption[k].optionTemplate.id == 72)
									{
										str = " [+" + item.itemOption[k].param + "]";
									}
								}
							}
							mFont.tahoma_7_green2.drawString(g, item.template.name + str, num + 5, num2 + 1, 0);
							string text = string.Empty;
							if (item.itemOption != null)
							{
								if (item.itemOption.Length > 0 && item.itemOption[0] != null && item.itemOption[0].optionTemplate.id != 102 && item.itemOption[0].optionTemplate.id != 107)
								{
									text += item.itemOption[0].getOptionString();
								}
								mFont mFont = mFont.tahoma_7_blue;
								if (item.compare < 0 && (int)item.template.type != 5)
								{
									mFont = mFont.tahoma_7_red;
								}
								if (item.itemOption.Length > 1)
								{
									for (int l = 1; l < item.itemOption.Length; l++)
									{
										if (item.itemOption[l] != null && item.itemOption[l].optionTemplate.id != 102 && item.itemOption[l].optionTemplate.id != 107)
										{
											text = text + "," + item.itemOption[l].getOptionString();
										}
									}
								}
								g.setClip(num, num2, num3, num4);
								mFont.drawString(g, text, num + 5, num2 + 11, mFont.LEFT);
								g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
							}
							SmallImage.drawSmallImage(g, (int)item.template.iconID, num5 + num7 / 2 - ((item.quantity <= 1) ? 0 : 8), num6 + num8 / 2, 0, 3);
							if (item.quantity > 1)
							{
								mFont.tahoma_7_yellow.drawString(g, "x" + item.quantity, num5 + num7 - 15, num6 + 6, 0);
							}
						}
					}
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x0600085F RID: 2143 RVA: 0x00078164 File Offset: 0x00076364
	private void paintInventory(mGraphics g)
	{
		g.setColor(16711680);
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		Item[] arrItemBody = global::Char.myCharz().arrItemBody;
		Item[] arrItemBag = global::Char.myCharz().arrItemBag;
		for (int i = 0; i < arrItemBody.Length + arrItemBag.Length; i++)
		{
			bool flag = i < arrItemBody.Length;
			int num = i;
			int num2 = i - arrItemBody.Length;
			int num3 = this.xScroll + 36;
			int num4 = this.yScroll + i * this.ITEM_HEIGHT;
			int num5 = this.wScroll - 36;
			int h = this.ITEM_HEIGHT - 1;
			int num6 = this.xScroll;
			int num7 = this.yScroll + i * this.ITEM_HEIGHT;
			int num8 = 34;
			int num9 = this.ITEM_HEIGHT - 1;
			if (num4 - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num4 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					Item item = (!flag) ? arrItemBag[num2] : arrItemBody[num];
					g.setColor((i != this.selected) ? ((!flag) ? 15723751 : 15196114) : 16383818);
					g.fillRect(num3, num4, num5, h);
					g.setColor((i != this.selected) ? ((!flag) ? 11837316 : 9993045) : 9541120);
					if (item != null)
					{
						if (item.isHaveOption(34))
						{
							g.setColor((i != this.selected) ? Panel.color1[0] : Panel.color2[0]);
						}
						else if (item.isHaveOption(35))
						{
							g.setColor((i != this.selected) ? Panel.color1[1] : Panel.color2[1]);
						}
						else if (item.isHaveOption(36))
						{
							g.setColor((i != this.selected) ? Panel.color1[2] : Panel.color2[2]);
						}
					}
					g.fillRect(num6, num7, num8, num9);
					if (item != null && item.isSelect && GameCanvas.panel.type == 12)
					{
						g.setColor((i != this.selected) ? 6047789 : 7040779);
						g.fillRect(num6, num7, num8, num9);
					}
					if (item != null)
					{
						string str = string.Empty;
						if (item.itemOption != null)
						{
							for (int j = 0; j < item.itemOption.Length; j++)
							{
								if (item.itemOption[j].optionTemplate.id == 72)
								{
									str = " [+" + item.itemOption[j].param + "]";
								}
							}
						}
						mFont.tahoma_7_green2.drawString(g, item.template.name + str, num3 + 5, num4 + 1, 0);
						string text = string.Empty;
						if (item.itemOption != null)
						{
							if (item.itemOption.Length > 0 && item.itemOption[0] != null && item.itemOption[0].optionTemplate.id != 102 && item.itemOption[0].optionTemplate.id != 107)
							{
								text += item.itemOption[0].getOptionString();
							}
							mFont mFont = mFont.tahoma_7_blue;
							if (item.compare < 0 && (int)item.template.type != 5)
							{
								mFont = mFont.tahoma_7_red;
							}
							if (item.itemOption.Length > 1)
							{
								for (int k = 1; k < 2; k++)
								{
									if (item.itemOption[k] != null && item.itemOption[k].optionTemplate.id != 102 && item.itemOption[k].optionTemplate.id != 107)
									{
										text = text + "," + item.itemOption[k].getOptionString();
									}
								}
							}
							mFont.drawString(g, text, num3 + 5, num4 + 11, mFont.LEFT);
						}
						SmallImage.drawSmallImage(g, (int)item.template.iconID, num6 + num8 / 2, num7 + num9 / 2, 0, 3);
						if (item.quantity > 1)
						{
							mFont.tahoma_7_yellow.drawString(g, "x" + item.quantity, num6 + num8, num7 + num9 - mFont.tahoma_7_yellow.getHeight(), 1);
						}
					}
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x06000860 RID: 2144 RVA: 0x00078664 File Offset: 0x00076864
	private void paintTab(mGraphics g)
	{
		if (this.type == 23 || this.type == 24)
		{
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
			mFont.tahoma_7b_dark.drawString(g, mResources.gameInfo, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
		}
		else if (this.type == 20)
		{
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
			mFont.tahoma_7b_dark.drawString(g, mResources.account, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
		}
		else if (this.type == 22)
		{
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
			mFont.tahoma_7b_dark.drawString(g, mResources.autoFunction, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
		}
		else if (this.type == 19)
		{
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
			mFont.tahoma_7b_dark.drawString(g, mResources.option, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
		}
		else if (this.type == 18)
		{
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
			mFont.tahoma_7b_dark.drawString(g, mResources.change_flag, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
		}
		else if (this.type == 13 && this.Equals(GameCanvas.panel2))
		{
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
			mFont.tahoma_7b_dark.drawString(g, mResources.item_receive2, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
		}
		else if (this.type == 12 && GameCanvas.panel2 != null)
		{
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
			mFont.tahoma_7b_dark.drawString(g, mResources.UPGRADE, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
		}
		else if (this.type == 11)
		{
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
			mFont.tahoma_7b_dark.drawString(g, mResources.friend, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
		}
		else if (this.type == 16)
		{
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
			mFont.tahoma_7b_dark.drawString(g, mResources.enemy, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
		}
		else if (this.type == 15)
		{
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
			mFont.tahoma_7b_dark.drawString(g, this.topName, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
		}
		else if (this.type == 2 && GameCanvas.panel2 != null)
		{
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
			mFont.tahoma_7b_dark.drawString(g, mResources.chest, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
		}
		else if (this.type == 9)
		{
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
			mFont.tahoma_7b_dark.drawString(g, mResources.achievement_mission, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
		}
		else if (this.type == 3)
		{
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
			mFont.tahoma_7b_dark.drawString(g, mResources.select_zone, this.startTabPos + this.TAB_W / 2, 59, mFont.CENTER);
		}
		else if (this.type == 14)
		{
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
			mFont.tahoma_7b_dark.drawString(g, mResources.select_map, this.startTabPos + this.TAB_W / 2, 59, mFont.CENTER);
		}
		else if (this.type == 4)
		{
			mFont.tahoma_7b_dark.drawString(g, mResources.map, this.startTabPos + this.TAB_W / 2, 59, mFont.CENTER);
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
		}
		else if (this.type == 7)
		{
			mFont.tahoma_7b_dark.drawString(g, mResources.trangbi, this.startTabPos + this.TAB_W / 2, 59, mFont.CENTER);
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
		}
		else if (this.type == 17)
		{
			mFont.tahoma_7b_dark.drawString(g, mResources.kigui, this.startTabPos + this.TAB_W / 2, 59, mFont.CENTER);
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
		}
		else if (this.type == 8)
		{
			mFont.tahoma_7b_dark.drawString(g, mResources.msg, this.startTabPos + this.TAB_W / 2, 59, mFont.CENTER);
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
		}
		else if (this.type == 10)
		{
			mFont.tahoma_7b_dark.drawString(g, mResources.wat_do_u_want, this.startTabPos + this.TAB_W / 2, 59, mFont.CENTER);
			g.setColor(13524492);
			g.fillRect(this.X + 1, 78, this.W - 2, 1);
		}
		else
		{
			if (this.currentTabIndex == 3 && this.mainTabName.Length != 4)
			{
				g.translate(-this.cmx, 0);
			}
			for (int i = 0; i < this.currentTabName.Length; i++)
			{
				g.setColor((i != this.currentTabIndex) ? 16773296 : 6805896);
				PopUp.paintPopUp(g, this.startTabPos + i * this.TAB_W, 52, this.TAB_W - 1, 25, (i != this.currentTabIndex) ? 0 : 1, true);
				if (i == this.keyTouchTab)
				{
					g.drawImage(ItemMap.imageFlare, this.startTabPos + i * this.TAB_W + this.TAB_W / 2, 62, 3);
				}
				mFont mFont = (i != this.currentTabIndex) ? mFont.tahoma_7_grey : mFont.tahoma_7_green2;
				if (!this.currentTabName[i][1].Equals(string.Empty))
				{
					mFont.drawString(g, this.currentTabName[i][0], this.startTabPos + i * this.TAB_W + this.TAB_W / 2, 53, mFont.CENTER);
					mFont.drawString(g, this.currentTabName[i][1], this.startTabPos + i * this.TAB_W + this.TAB_W / 2, 64, mFont.CENTER);
				}
				else
				{
					mFont.drawString(g, this.currentTabName[i][0], this.startTabPos + i * this.TAB_W + this.TAB_W / 2, 59, mFont.CENTER);
				}
				if (this.type == 0 && this.currentTabName.Length == 5 && GameScr.isNewClanMessage && GameCanvas.gameTick % 4 == 0)
				{
					g.drawImage(ItemMap.imageFlare, this.startTabPos + 3 * this.TAB_W + this.TAB_W / 2, 77, mGraphics.BOTTOM | mGraphics.HCENTER);
				}
			}
			g.setColor(13524492);
			g.fillRect(1, 78, this.W - 2, 1);
		}
	}

	// Token: 0x06000861 RID: 2145 RVA: 0x00078F84 File Offset: 0x00077184
	private void paintBottomMoneyInfo(mGraphics g)
	{
		if (this.type == 13 && (this.currentTabIndex == 2 || this.Equals(GameCanvas.panel2)))
		{
			return;
		}
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
		g.setColor(11837316);
		g.fillRect(this.X + 1, this.H - 15, this.W - 2, 14);
		g.setColor(13524492);
		g.fillRect(this.X + 1, this.H - 15, this.W - 2, 1);
		g.drawImage(Panel.imgXu, this.X + 11, this.H - 7, 3);
		g.drawImage(Panel.imgLuong, this.X + 90, this.H - 8, 3);
		mFont.tahoma_7_yellow.drawString(g, global::Char.myCharz().xu + string.Empty, this.X + 24, this.H - 13, mFont.LEFT, mFont.tahoma_7_grey);
		mFont.tahoma_7_yellow.drawString(g, global::Char.myCharz().luong + string.Empty, this.X + 100, this.H - 13, mFont.LEFT, mFont.tahoma_7_grey);
		g.drawImage(Panel.imgLuongKhoa, this.X + 140, this.H - 8, 3);
		mFont.tahoma_7_yellow.drawString(g, global::Char.myCharz().luongKhoa + string.Empty, this.X + 150, this.H - 13, mFont.LEFT, mFont.tahoma_7_grey);
	}

	// Token: 0x06000862 RID: 2146 RVA: 0x00079144 File Offset: 0x00077344
	private void paintClanInfo(mGraphics g)
	{
		if (global::Char.myCharz().clan == null)
		{
			SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), 25, 50, 0, 33);
			mFont.tahoma_7b_white.drawString(g, mResources.not_join_clan, (this.wScroll - 50) / 2 + 50, 20, mFont.CENTER);
		}
		else if (!this.isViewMember)
		{
			Clan clan = global::Char.myCharz().clan;
			if (clan != null)
			{
				SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), 25, 50, 0, 33);
				mFont.tahoma_7b_white.drawString(g, clan.name, 60, 4, mFont.LEFT, mFont.tahoma_7b_dark);
				mFont.tahoma_7_yellow.drawString(g, mResources.achievement_point + ": " + clan.powerPoint, 60, 16, mFont.LEFT, mFont.tahoma_7_grey);
				mFont.tahoma_7_yellow.drawString(g, mResources.clan_point + ": " + clan.clanPoint, 60, 27, mFont.LEFT, mFont.tahoma_7_grey);
				mFont.tahoma_7_yellow.drawString(g, mResources.level + ": " + clan.level, 60, 38, mFont.LEFT, mFont.tahoma_7_grey);
				TextInfo.paint(g, clan.slogan, 60, 38, this.wScroll - 70, this.ITEM_HEIGHT, mFont.tahoma_7_yellow);
			}
		}
		else
		{
			Clan clan2 = (this.currClan == null) ? global::Char.myCharz().clan : this.currClan;
			SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), 25, 51, 0, 33);
			mFont.tahoma_7b_white.drawString(g, clan2.name, 60, 4, mFont.LEFT, mFont.tahoma_7b_dark);
			mFont.tahoma_7_yellow.drawString(g, string.Concat(new object[]
			{
				mResources.member,
				": ",
				clan2.currMember,
				"/",
				clan2.maxMember
			}), 60, 16, mFont.LEFT, mFont.tahoma_7_grey);
			mFont.tahoma_7_yellow.drawString(g, mResources.clan_leader + ": " + clan2.leaderName, 60, 27, mFont.LEFT, mFont.tahoma_7_grey);
			TextInfo.paint(g, clan2.slogan, 60, 38, this.wScroll - 70, this.ITEM_HEIGHT, mFont.tahoma_7_yellow);
		}
	}

	// Token: 0x06000863 RID: 2147 RVA: 0x000793B0 File Offset: 0x000775B0
	private void paintToolInfo(mGraphics g)
	{
		mFont.tahoma_7b_white.drawString(g, mResources.dragon_ball + " " + GameMidlet.VERSION, 60, 4, mFont.LEFT, mFont.tahoma_7b_dark);
		mFont.tahoma_7_yellow.drawString(g, mResources.character + ": " + global::Char.myCharz().cName, 60, 16, mFont.LEFT, mFont.tahoma_7_grey);
		mFont.tahoma_7_yellow.drawString(g, mResources.account_server + " " + ServerListScreen.nameServer[ServerListScreen.ipSelect] + ":", 60, 27, mFont.LEFT, mFont.tahoma_7_grey);
		mFont.tahoma_7_yellow.drawString(g, (!GameCanvas.loginScr.tfUser.getText().Equals(string.Empty)) ? GameCanvas.loginScr.tfUser.getText() : mResources.not_register_yet, 60, 39, mFont.LEFT, mFont.tahoma_7_grey);
	}

	// Token: 0x06000864 RID: 2148 RVA: 0x000794A4 File Offset: 0x000776A4
	private void paintGiaoDichInfo(mGraphics g)
	{
		mFont.tahoma_7_yellow.drawString(g, mResources.select_item, 60, 4, mFont.LEFT, mFont.tahoma_7_grey);
		mFont.tahoma_7_yellow.drawString(g, mResources.lock_trade, 60, 16, mFont.LEFT, mFont.tahoma_7_grey);
		mFont.tahoma_7_yellow.drawString(g, mResources.wait_opp_lock_trade, 60, 27, mFont.LEFT, mFont.tahoma_7_grey);
		mFont.tahoma_7_yellow.drawString(g, mResources.press_done, 60, 38, mFont.LEFT, mFont.tahoma_7_grey);
	}

	// Token: 0x06000865 RID: 2149 RVA: 0x000075A6 File Offset: 0x000057A6
	private void paintMyInfo(mGraphics g)
	{
		this.paintCharInfo(g, global::Char.myCharz());
	}

	// Token: 0x06000866 RID: 2150 RVA: 0x00079528 File Offset: 0x00077728
	private void paintPetInfo(mGraphics g)
	{
		mFont.tahoma_7_yellow.drawString(g, mResources.power + ": " + NinjaUtil.getMoneys(global::Char.myPetz().cPower), this.X + 60, 4, mFont.LEFT, mFont.tahoma_7_grey);
		if (global::Char.myPetz().cPower > 0L)
		{
			mFont.tahoma_7_yellow.drawString(g, (!global::Char.myPetz().me) ? global::Char.myPetz().currStrLevel : global::Char.myPetz().getStrLevel(), this.X + 60, 16, mFont.LEFT, mFont.tahoma_7_grey);
		}
		if (global::Char.myPetz().cDamFull > 0)
		{
			mFont.tahoma_7_yellow.drawString(g, mResources.hit_point + " :" + global::Char.myPetz().cDamFull, this.X + 60, 27, mFont.LEFT, mFont.tahoma_7_grey);
		}
		if (global::Char.myPetz().cMaxStamina > 0)
		{
			mFont.tahoma_7_yellow.drawString(g, mResources.vitality, this.X + 60, 38, mFont.LEFT, mFont.tahoma_7_grey);
			g.drawImage(GameScr.imgMPLost, this.X + 100, 41, 0);
			int num = global::Char.myPetz().cStamina * mGraphics.getImageWidth(GameScr.imgMP) / (int)global::Char.myPetz().cMaxStamina;
			g.setClip(100, this.X + 41, num, 20);
			g.drawImage(GameScr.imgMP, this.X + 100, 41, 0);
		}
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
	}

	// Token: 0x06000867 RID: 2151 RVA: 0x000796C4 File Offset: 0x000778C4
	private void paintCharInfo(mGraphics g, global::Char c)
	{
		mFont.tahoma_7b_white.drawString(g, (((int)GameScr.isNewMember == 1) ? "       " : string.Empty) + c.cName, this.X + 60, 4, mFont.LEFT, mFont.tahoma_7b_dark);
		if ((int)GameScr.isNewMember == 1)
		{
			SmallImage.drawSmallImage(g, 5427, this.X + 55, 4, 0, 0);
		}
		if (c.cMaxStamina > 0)
		{
			mFont.tahoma_7_yellow.drawString(g, mResources.vitality, this.X + 60, 16, mFont.LEFT, mFont.tahoma_7_grey);
			g.drawImage(GameScr.imgMPLost, this.X + 95, 19, 0);
			int num = c.cStamina * mGraphics.getImageWidth(GameScr.imgMP) / (int)c.cMaxStamina;
			g.setClip(95, this.X + 19, num, 20);
			g.drawImage(GameScr.imgMP, this.X + 95, 19, 0);
		}
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
		if (c.cPower > 0L)
		{
			mFont.tahoma_7_yellow.drawString(g, (!c.me) ? c.currStrLevel : c.getStrLevel(), this.X + 60, 27, mFont.LEFT, mFont.tahoma_7_grey);
		}
		mFont.tahoma_7_yellow.drawString(g, mResources.power + ": " + NinjaUtil.getMoneys(c.cPower), this.X + 60, 38, mFont.LEFT, mFont.tahoma_7_grey);
	}

	// Token: 0x06000868 RID: 2152 RVA: 0x0007985C File Offset: 0x00077A5C
	private void paintZoneInfo(mGraphics g)
	{
		mFont.tahoma_7b_white.drawString(g, mResources.zone + " " + TileMap.zoneID, 60, 4, mFont.LEFT, mFont.tahoma_7b_dark);
		mFont.tahoma_7_yellow.drawString(g, TileMap.mapName, 60, 16, mFont.LEFT, mFont.tahoma_7_grey);
		mFont.tahoma_7b_white.drawString(g, TileMap.zoneID + string.Empty, 25, 27, mFont.CENTER);
	}

	// Token: 0x06000869 RID: 2153 RVA: 0x000798E0 File Offset: 0x00077AE0
	public int getCompare(Item item)
	{
		if (item == null)
		{
			return -1;
		}
		if (!item.isTypeBody())
		{
			return 0;
		}
		if (item.itemOption == null)
		{
			return -1;
		}
		ItemOption itemOption = item.itemOption[0];
		if (itemOption.optionTemplate.id == 22)
		{
			itemOption.optionTemplate = GameScr.gI().iOptionTemplates[6];
			itemOption.param *= 1000;
		}
		if (itemOption.optionTemplate.id == 23)
		{
			itemOption.optionTemplate = GameScr.gI().iOptionTemplates[7];
			itemOption.param *= 1000;
		}
		Item item2 = null;
		for (int i = 0; i < global::Char.myCharz().arrItemBody.Length; i++)
		{
			Item item3 = global::Char.myCharz().arrItemBody[i];
			if (itemOption.optionTemplate.id == 22)
			{
				itemOption.optionTemplate = GameScr.gI().iOptionTemplates[6];
				itemOption.param *= 1000;
			}
			if (itemOption.optionTemplate.id == 23)
			{
				itemOption.optionTemplate = GameScr.gI().iOptionTemplates[7];
				itemOption.param *= 1000;
			}
			if (item3 != null && item3.itemOption != null && (int)item3.template.type == (int)item.template.type)
			{
				item2 = item3;
				break;
			}
		}
		if (item2 == null)
		{
			Res.outz("5");
			this.isUp = true;
			return itemOption.param;
		}
		int num;
		if (item2 != null && item2.itemOption != null)
		{
			num = itemOption.param - item2.itemOption[0].param;
		}
		else
		{
			num = itemOption.param;
		}
		if (num < 0)
		{
			this.isUp = false;
		}
		else
		{
			this.isUp = true;
		}
		return num;
	}

	// Token: 0x0600086A RID: 2154 RVA: 0x00079AC4 File Offset: 0x00077CC4
	private void paintMapInfo(mGraphics g)
	{
		mFont.tahoma_7b_white.drawString(g, mResources.MENUGENDER[(int)TileMap.planetID], 60, 4, mFont.LEFT);
		string str = string.Empty;
		if (TileMap.mapID >= 135 && TileMap.mapID <= 138)
		{
			str = " " + mResources.tang + TileMap.zoneID;
		}
		mFont.tahoma_7_yellow.drawString(g, TileMap.mapName + str, 60, 16, mFont.LEFT);
		mFont.tahoma_7b_white.drawString(g, mResources.quest_place + ": ", 60, 27, mFont.LEFT);
		if (GameScr.getTaskMapId() >= 0 && GameScr.getTaskMapId() <= TileMap.mapNames.Length - 1)
		{
			mFont.tahoma_7_yellow.drawString(g, TileMap.mapNames[GameScr.getTaskMapId()], 60, 38, mFont.LEFT);
		}
		else
		{
			mFont.tahoma_7_yellow.drawString(g, mResources.random, 60, 38, mFont.LEFT);
		}
	}

	// Token: 0x0600086B RID: 2155 RVA: 0x00079BCC File Offset: 0x00077DCC
	private void paintShopInfo(mGraphics g)
	{
		if (this.currentTabIndex == this.currentTabName.Length - 1 && GameCanvas.panel2 == null)
		{
			this.paintMyInfo(g);
			return;
		}
		if (this.selected < 0)
		{
			if (this.typeShop != 2)
			{
				mFont.tahoma_7_white.drawString(g, mResources.say_hello, this.X + 60, 14, 0);
				mFont.tahoma_7_white.drawString(g, Panel.strWantToBuy, this.X + 60, 26, 0);
			}
			else
			{
				mFont.tahoma_7_white.drawString(g, mResources.say_hello, this.X + 60, 5, 0);
				mFont.tahoma_7_white.drawString(g, Panel.strWantToBuy, this.X + 60, 17, 0);
				mFont.tahoma_7_white.drawString(g, string.Concat(new object[]
				{
					mResources.page,
					" ",
					this.currPageShop[this.currentTabIndex] + 1,
					"/",
					this.maxPageShop[this.currentTabIndex]
				}), this.X + 60, 29, 0);
			}
			return;
		}
		if (this.currentTabIndex >= 0 && this.currentTabIndex <= global::Char.myCharz().arrItemShop.Length - 1 && this.selected >= 0 && this.selected <= global::Char.myCharz().arrItemShop[this.currentTabIndex].Length - 1)
		{
			Item item = global::Char.myCharz().arrItemShop[this.currentTabIndex][this.selected];
			if (item != null)
			{
				if (this.Equals(GameCanvas.panel) && this.currentTabIndex <= 3 && this.typeShop == 2)
				{
					mFont.tahoma_7b_white.drawString(g, string.Concat(new object[]
					{
						mResources.page,
						" ",
						this.currPageShop[this.currentTabIndex] + 1,
						"/",
						this.maxPageShop[this.currentTabIndex]
					}), this.X + 55, 4, 0);
				}
				mFont.tahoma_7b_white.drawString(g, item.template.name, this.X + 55, 24, 0);
				string st = mResources.pow_request + " " + Res.formatNumber((long)item.template.strRequire);
				if ((long)item.template.strRequire > global::Char.myCharz().cPower)
				{
					mFont.tahoma_7_yellow.drawString(g, st, this.X + 55, 35, 0);
				}
				else
				{
					mFont.tahoma_7_green.drawString(g, st, this.X + 55, 35, 0);
				}
			}
		}
	}

	// Token: 0x0600086C RID: 2156 RVA: 0x00079E88 File Offset: 0x00078088
	private void paintItemBoxInfo(mGraphics g)
	{
		string st = string.Concat(new object[]
		{
			mResources.used,
			": ",
			this.hasUse,
			"/",
			global::Char.myCharz().arrItemBox.Length,
			" ",
			mResources.place
		});
		mFont.tahoma_7b_white.drawString(g, mResources.chest, 60, 4, 0);
		mFont.tahoma_7_yellow.drawString(g, st, 60, 16, 0);
	}

	// Token: 0x0600086D RID: 2157 RVA: 0x00079F10 File Offset: 0x00078110
	private void paintSkillInfo(mGraphics g)
	{
		mFont.tahoma_7_white.drawString(g, "Top " + global::Char.myCharz().rank, this.X + 45 + (this.W - 50) / 2, 2, mFont.CENTER);
		mFont.tahoma_7_yellow.drawString(g, mResources.potential_point, this.X + 45 + (this.W - 50) / 2, 14, mFont.CENTER);
		mFont.tahoma_7_white.drawString(g, string.Empty + NinjaUtil.getMoneys(global::Char.myCharz().cTiemNang), this.X + ((GameCanvas.gameTick % 20 <= 10) ? 0 : (GameCanvas.gameTick % 4 / 2)) + 45 + (this.W - 50) / 2, 26, mFont.CENTER);
		mFont.tahoma_7_yellow.drawString(g, mResources.active_point + ": " + NinjaUtil.getMoneys(global::Char.myCharz().cNangdong), this.X + ((GameCanvas.gameTick % 20 <= 10) ? 0 : (GameCanvas.gameTick % 4 / 2)) + 45 + (this.W - 50) / 2, 38, mFont.CENTER);
	}

	// Token: 0x0600086E RID: 2158 RVA: 0x0007A04C File Offset: 0x0007824C
	private void paintItemBodyBagInfo(mGraphics g)
	{
		mFont.tahoma_7_yellow.drawString(g, string.Concat(new object[]
		{
			mResources.HP,
			": ",
			global::Char.myCharz().cHP,
			" / ",
			global::Char.myCharz().cHPFull
		}), this.X + 60, 2, mFont.LEFT, mFont.tahoma_7_grey);
		mFont.tahoma_7_yellow.drawString(g, string.Concat(new object[]
		{
			mResources.KI,
			": ",
			global::Char.myCharz().cMP,
			" / ",
			global::Char.myCharz().cMPFull
		}), this.X + 60, 14, mFont.LEFT, mFont.tahoma_7_grey);
		mFont.tahoma_7_yellow.drawString(g, mResources.hit_point + ": " + global::Char.myCharz().cDamFull, this.X + 60, 26, mFont.LEFT, mFont.tahoma_7_grey);
		mFont.tahoma_7_yellow.drawString(g, string.Concat(new object[]
		{
			mResources.armor,
			": ",
			global::Char.myCharz().cDefull,
			", ",
			mResources.critical,
			": ",
			global::Char.myCharz().cCriticalFull,
			"%"
		}), this.X + 60, 38, mFont.LEFT, mFont.tahoma_7_grey);
	}

	// Token: 0x0600086F RID: 2159 RVA: 0x0007A1E4 File Offset: 0x000783E4
	private void paintTopInfo(mGraphics g)
	{
		g.setClip(this.X + 1, this.Y, this.W - 2, this.yScroll - 2);
		g.setColor(9993045);
		g.fillRect(this.X, this.Y, this.W - 2, 50);
		switch (this.type)
		{
		case 0:
			if (this.currentTabIndex == 0)
			{
				SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
				this.paintMyInfo(g);
			}
			if (this.currentTabIndex == 1)
			{
				SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
				this.paintItemBodyBagInfo(g);
			}
			if (this.currentTabIndex == 2)
			{
				SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
				this.paintSkillInfo(g);
			}
			if (this.currentTabIndex == 3)
			{
				if (this.mainTabName.Length == 5)
				{
					this.paintClanInfo(g);
				}
				else
				{
					SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
					this.paintToolInfo(g);
				}
			}
			if (this.currentTabIndex == 4)
			{
				SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
				this.paintToolInfo(g);
			}
			break;
		case 1:
			if (this.currentTabIndex == this.currentTabName.Length - 1 && GameCanvas.panel2 == null)
			{
				SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
			}
			else
			{
				SmallImage.drawSmallImage(g, global::Char.myCharz().npcFocus.avatar, this.X + 25, 50, 0, 33);
			}
			this.paintShopInfo(g);
			break;
		case 2:
			if (this.currentTabIndex == 0)
			{
				SmallImage.drawSmallImage(g, 526, this.X + 25, 50, 0, 33);
				this.paintItemBoxInfo(g);
			}
			if (this.currentTabIndex == 1)
			{
				SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
				this.paintItemBodyBagInfo(g);
			}
			break;
		case 3:
			SmallImage.drawSmallImage(g, 561, this.X + 25, 50, 0, 33);
			this.paintZoneInfo(g);
			break;
		case 4:
			SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
			this.paintMapInfo(g);
			break;
		case 7:
		case 17:
			SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
			this.paintMyInfo(g);
			break;
		case 8:
			SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
			this.paintMyInfo(g);
			break;
		case 9:
			SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
			this.paintMyInfo(g);
			break;
		case 10:
			if (this.charMenu != null)
			{
				SmallImage.drawSmallImage(g, this.charMenu.avatarz(), this.X + 25, 50, 0, 33);
				this.paintCharInfo(g, this.charMenu);
			}
			break;
		case 11:
		case 16:
		case 23:
		case 24:
			SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
			this.paintMyInfo(g);
			break;
		case 12:
			if (this.currentTabIndex == 0)
			{
				SmallImage.drawSmallImage(g, 1410, this.X + 25, 50, 0, 33);
				this.paintCombineInfo(g);
			}
			if (this.currentTabIndex == 1)
			{
				SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
				this.paintMyInfo(g);
			}
			break;
		case 13:
			if (this.currentTabIndex == 0 || this.currentTabIndex == 1)
			{
				if (this.Equals(GameCanvas.panel))
				{
					SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
					this.paintGiaoDichInfo(g);
				}
				if (this.Equals(GameCanvas.panel2) && this.charMenu != null)
				{
					SmallImage.drawSmallImage(g, this.charMenu.avatarz(), this.X + 25, 50, 0, 33);
					this.paintCharInfo(g, this.charMenu);
				}
			}
			if (this.currentTabIndex == 2 && this.charMenu != null)
			{
				SmallImage.drawSmallImage(g, this.charMenu.avatarz(), this.X + 25, 50, 0, 33);
				this.paintCharInfo(g, this.charMenu);
			}
			break;
		case 14:
			SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
			this.paintMapInfo(g);
			break;
		case 15:
			SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
			this.paintMyInfo(g);
			break;
		case 18:
			SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
			this.paintMyInfo(g);
			break;
		case 19:
			SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
			this.paintToolInfo(g);
			break;
		case 20:
			SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
			this.paintToolInfo(g);
			break;
		case 21:
			if (this.currentTabIndex == 0)
			{
				SmallImage.drawSmallImage(g, global::Char.myPetz().avatarz(), this.X + 25, 50, 0, 33);
				this.paintPetInfo(g);
			}
			if (this.currentTabIndex == 1)
			{
				SmallImage.drawSmallImage(g, global::Char.myPetz().avatarz(), this.X + 25, 50, 0, 33);
				this.paintPetStatusInfo(g);
			}
			if (this.currentTabIndex == 2)
			{
				SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
				this.paintItemBodyBagInfo(g);
			}
			break;
		case 22:
			SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
			this.paintToolInfo(g);
			break;
		case 25:
			SmallImage.drawSmallImage(g, global::Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
			this.paintMyInfo(g);
			break;
		}
	}

	// Token: 0x06000870 RID: 2160 RVA: 0x000075B4 File Offset: 0x000057B4
	private string getStatus(int status)
	{
		switch (status)
		{
		case 0:
			return mResources.follow;
		case 1:
			return mResources.defend;
		case 2:
			return mResources.attack;
		case 3:
			return mResources.gohome;
		default:
			return "aaa";
		}
	}

	// Token: 0x06000871 RID: 2161 RVA: 0x0007A8D4 File Offset: 0x00078AD4
	private void paintPetStatusInfo(mGraphics g)
	{
		mFont.tahoma_7b_white.drawString(g, string.Concat(new object[]
		{
			"HP: ",
			global::Char.myPetz().cHP,
			"/",
			global::Char.myPetz().cHPFull
		}), this.X + 60, 4, mFont.LEFT, mFont.tahoma_7b_dark);
		mFont.tahoma_7b_white.drawString(g, string.Concat(new object[]
		{
			"MP: ",
			global::Char.myPetz().cMP,
			"/",
			global::Char.myPetz().cMPFull
		}), this.X + 60, 16, mFont.LEFT, mFont.tahoma_7b_dark);
		mFont.tahoma_7_yellow.drawString(g, string.Concat(new object[]
		{
			mResources.critical,
			": ",
			global::Char.myPetz().cCriticalFull,
			"   ",
			mResources.armor,
			": ",
			global::Char.myPetz().cDefull
		}), this.X + 60, 27, mFont.LEFT, mFont.tahoma_7_grey);
		mFont.tahoma_7_yellow.drawString(g, mResources.status + " :" + this.strStatus[(int)global::Char.myPetz().petStatus], this.X + 60, 38, mFont.LEFT, mFont.tahoma_7_grey);
	}

	// Token: 0x06000872 RID: 2162 RVA: 0x0007AA58 File Offset: 0x00078C58
	private void paintCombineInfo(mGraphics g)
	{
		if (this.combineTopInfo != null)
		{
			for (int i = 0; i < this.combineTopInfo.Length; i++)
			{
				mFont.tahoma_7_white.drawString(g, this.combineTopInfo[i], this.X + 45 + (this.W - 50) / 2, 5 + i * 14, mFont.CENTER);
			}
		}
	}

	// Token: 0x06000873 RID: 2163 RVA: 0x00003984 File Offset: 0x00001B84
	private void paintInfomation(mGraphics g)
	{
	}

	// Token: 0x06000874 RID: 2164 RVA: 0x0007AABC File Offset: 0x00078CBC
	public void paintMap(mGraphics g)
	{
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(-this.cmxMap, -this.cmyMap);
		g.drawImage(Panel.imgMap, this.xScroll, this.yScroll, 0);
		int head = global::Char.myCharz().head;
		Part part = GameScr.parts[head];
		SmallImage.drawSmallImage(g, (int)part.pi[global::Char.CharInfo[0][0][0]].id, this.xMap, this.yMap + 5, 0, 3);
		int align = mFont.CENTER;
		if (this.xMap <= 40)
		{
			align = mFont.LEFT;
		}
		if (this.xMap >= 220)
		{
			align = mFont.RIGHT;
		}
		mFont.tahoma_7b_yellow.drawString(g, TileMap.mapName, this.xMap, this.yMap - 12, align, mFont.tahoma_7_grey);
		int num = -1;
		if (GameScr.getTaskMapId() != -1)
		{
			for (int i = 0; i < Panel.mapId[(int)TileMap.planetID].Length; i++)
			{
				if (Panel.mapId[(int)TileMap.planetID][i] == GameScr.getTaskMapId())
				{
					num = i;
					break;
				}
				num = 4;
			}
			if (GameCanvas.gameTick % 4 > 0)
			{
				g.drawImage(ItemMap.imageFlare, this.xScroll + Panel.mapX[(int)TileMap.planetID][num], this.yScroll + Panel.mapY[(int)TileMap.planetID][num], 3);
			}
		}
		if (!GameCanvas.isTouch)
		{
			g.drawImage(Panel.imgBantay, this.xMove, this.yMove, StaticObj.TOP_RIGHT);
			for (int j = 0; j < Panel.mapX[(int)TileMap.planetID].Length; j++)
			{
				int num2 = Panel.mapX[(int)TileMap.planetID][j] + this.xScroll;
				int num3 = Panel.mapY[(int)TileMap.planetID][j] + this.yScroll;
				if (Res.inRect(num2 - 15, num3 - 15, 30, 30, this.xMove, this.yMove))
				{
					align = mFont.CENTER;
					if (num2 <= 20)
					{
						align = mFont.LEFT;
					}
					if (num2 >= 220)
					{
						align = mFont.RIGHT;
					}
					mFont.tahoma_7b_yellow.drawString(g, TileMap.mapNames[Panel.mapId[(int)TileMap.planetID][j]], num2, num3 - 12, align, mFont.tahoma_7_grey);
					break;
				}
			}
		}
		else if (!this.trans)
		{
			for (int k = 0; k < Panel.mapX[(int)TileMap.planetID].Length; k++)
			{
				int num4 = Panel.mapX[(int)TileMap.planetID][k] + this.xScroll;
				int num5 = Panel.mapY[(int)TileMap.planetID][k] + this.yScroll;
				if (Res.inRect(num4 - 15, num5 - 15, 30, 30, this.pX, this.pY))
				{
					align = mFont.CENTER;
					if (num4 <= 30)
					{
						align = mFont.LEFT;
					}
					if (num4 >= 220)
					{
						align = mFont.RIGHT;
					}
					g.drawImage(Panel.imgBantay, num4, num5, StaticObj.TOP_RIGHT);
					mFont.tahoma_7b_yellow.drawString(g, TileMap.mapNames[Panel.mapId[(int)TileMap.planetID][k]], num4, num5 - 12, align, mFont.tahoma_7_grey);
					break;
				}
			}
		}
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		if (num != -1)
		{
			if (Panel.mapX[(int)TileMap.planetID][num] + this.xScroll < this.cmxMap)
			{
				g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 5, this.xScroll + 5, this.yScroll + this.hScroll / 2 - 4, 0);
			}
			if (this.cmxMap + this.wScroll < Panel.mapX[(int)TileMap.planetID][num] + this.xScroll)
			{
				g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 6, this.xScroll + this.wScroll - 5, this.yScroll + this.hScroll / 2 - 4, StaticObj.TOP_RIGHT);
			}
			if (Panel.mapY[(int)TileMap.planetID][num] < this.cmyMap)
			{
				g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 1, this.xScroll + this.wScroll / 2, this.yScroll + 5, StaticObj.TOP_CENTER);
			}
			if (Panel.mapY[(int)TileMap.planetID][num] > this.cmyMap + this.hScroll)
			{
				g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 0, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll - 5, StaticObj.BOTTOM_HCENTER);
			}
		}
	}

	// Token: 0x06000875 RID: 2165 RVA: 0x0007AF84 File Offset: 0x00079184
	public void paintTask(mGraphics g)
	{
		int num = (GameCanvas.h <= 300) ? 15 : 20;
		if (Panel.isPaintMap && !GameScr.gI().isMapDocNhan() && !GameScr.gI().isMapFize())
		{
			g.drawImage((this.keyTouchMapButton != 1) ? GameScr.imgLbtn : GameScr.imgLbtnFocus, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll - num, 3);
			mFont.tahoma_7b_dark.drawString(g, mResources.map, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll - (num + 5), mFont.CENTER);
		}
		this.xstart = this.xScroll + 5;
		this.ystart = this.yScroll + 14;
		this.yPaint = this.ystart;
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll - 35);
		if (this.scroll != null)
		{
			if (this.scroll.cmy > 0)
			{
				g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 1, this.xScroll + this.wScroll - 12, this.yScroll + 3, 0);
			}
			if (this.scroll.cmy < this.scroll.cmyLim)
			{
				g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 0, this.xScroll + this.wScroll - 12, this.yScroll + this.hScroll - 45, 0);
			}
			g.translate(0, -this.scroll.cmy);
		}
		this.indexRowMax = 0;
		if (this.indexMenu == 0)
		{
			bool flag = false;
			if (global::Char.myCharz().taskMaint != null)
			{
				for (int i = 0; i < global::Char.myCharz().taskMaint.names.Length; i++)
				{
					mFont.tahoma_7_grey.drawString(g, global::Char.myCharz().taskMaint.names[i], this.xScroll + this.wScroll / 2, this.yPaint - 5 + i * 12, mFont.CENTER);
					this.indexRowMax++;
				}
				this.yPaint += (global::Char.myCharz().taskMaint.names.Length - 1) * 12;
				int num2 = 0;
				string text = string.Empty;
				for (int j = 0; j < global::Char.myCharz().taskMaint.subNames.Length; j++)
				{
					if (global::Char.myCharz().taskMaint.subNames[j] != null)
					{
						num2 = j;
						text = "- " + global::Char.myCharz().taskMaint.subNames[j];
						if (global::Char.myCharz().taskMaint.counts[j] != -1)
						{
							if (global::Char.myCharz().taskMaint.index == j)
							{
								if (global::Char.myCharz().taskMaint.counts[j] != 1)
								{
									string text2 = text;
									text = string.Concat(new object[]
									{
										text2,
										" (",
										global::Char.myCharz().taskMaint.count,
										"/",
										global::Char.myCharz().taskMaint.counts[j],
										")"
									});
								}
								if (global::Char.myCharz().taskMaint.count == global::Char.myCharz().taskMaint.counts[j])
								{
									mFont.tahoma_7.drawString(g, text, this.xstart + 5, this.yPaint += 12, 0);
								}
								else
								{
									mFont mFont = mFont.tahoma_7_grey;
									if (!flag)
									{
										flag = true;
										mFont = mFont.tahoma_7_blue;
										mFont.drawString(g, text, this.xstart + 5 + ((mFont != mFont.tahoma_7_blue || GameCanvas.gameTick % 20 <= 10) ? 0 : (GameCanvas.gameTick % 4 / 2)), this.yPaint += 12, 0);
									}
									else
									{
										mFont.drawString(g, "- ...", this.xstart + 5 + ((mFont != mFont.tahoma_7_blue || GameCanvas.gameTick % 20 <= 10) ? 0 : (GameCanvas.gameTick % 4 / 2)), this.yPaint += 12, 0);
									}
								}
							}
							else if (global::Char.myCharz().taskMaint.index > j)
							{
								if (global::Char.myCharz().taskMaint.counts[j] != 1)
								{
									string text2 = text;
									text = string.Concat(new object[]
									{
										text2,
										" (",
										global::Char.myCharz().taskMaint.counts[j],
										"/",
										global::Char.myCharz().taskMaint.counts[j],
										")"
									});
								}
								mFont.tahoma_7_white.drawString(g, text, this.xstart + 5, this.yPaint += 12, 0);
							}
							else
							{
								if (global::Char.myCharz().taskMaint.counts[j] != 1)
								{
									text = text + " 0/" + global::Char.myCharz().taskMaint.counts[j];
								}
								mFont mFont2 = mFont.tahoma_7_grey;
								if (!flag)
								{
									flag = true;
									mFont2 = mFont.tahoma_7_blue;
									mFont2.drawString(g, text, this.xstart + 5 + ((mFont2 != mFont.tahoma_7_blue || GameCanvas.gameTick % 20 <= 10) ? 0 : (GameCanvas.gameTick % 4 / 2)), this.yPaint += 12, 0);
								}
								else
								{
									mFont2.drawString(g, "- ...", this.xstart + 5 + ((mFont2 != mFont.tahoma_7_blue || GameCanvas.gameTick % 20 <= 10) ? 0 : (GameCanvas.gameTick % 4 / 2)), this.yPaint += 12, 0);
								}
							}
						}
						else if (global::Char.myCharz().taskMaint.index > j)
						{
							mFont.tahoma_7_white.drawString(g, text, this.xstart + 5, this.yPaint += 12, 0);
						}
						else
						{
							mFont mFont3 = mFont.tahoma_7_grey;
							if (!flag)
							{
								flag = true;
								mFont3 = mFont.tahoma_7_blue;
								mFont3.drawString(g, text, this.xstart + 5 + ((mFont3 != mFont.tahoma_7_blue || GameCanvas.gameTick % 20 <= 10) ? 0 : (GameCanvas.gameTick % 4 / 2)), this.yPaint += 12, 0);
							}
							else
							{
								mFont3.drawString(g, "- ...", this.xstart + 5 + ((mFont3 != mFont.tahoma_7_blue || GameCanvas.gameTick % 20 <= 10) ? 0 : (GameCanvas.gameTick % 4 / 2)), this.yPaint += 12, 0);
							}
						}
						this.indexRowMax++;
					}
					else if (global::Char.myCharz().taskMaint.index <= j)
					{
						text = "- " + global::Char.myCharz().taskMaint.subNames[num2];
						mFont mFont4 = mFont.tahoma_7_grey;
						if (!flag)
						{
							flag = true;
							mFont4 = mFont.tahoma_7_blue;
						}
						mFont4.drawString(g, text, this.xstart + 5 + ((mFont4 != mFont.tahoma_7_blue || GameCanvas.gameTick % 20 <= 10) ? 0 : (GameCanvas.gameTick % 4 / 2)), this.yPaint += 12, 0);
					}
				}
				this.yPaint += 5;
				for (int k = 0; k < global::Char.myCharz().taskMaint.details.Length; k++)
				{
					mFont.tahoma_7_green2.drawString(g, global::Char.myCharz().taskMaint.details[k], this.xstart + 5, this.yPaint += 12, 0);
					this.indexRowMax++;
				}
			}
			else
			{
				int taskMapId = GameScr.getTaskMapId();
				sbyte taskNpcId = GameScr.getTaskNpcId();
				string src = string.Empty;
				if (taskMapId == -3 || (int)taskNpcId == -3)
				{
					src = mResources.DES_TASK[3];
				}
				else if (global::Char.myCharz().taskMaint == null && global::Char.myCharz().ctaskId == 9 && global::Char.myCharz().nClass.classId == 0)
				{
					src = mResources.TASK_INPUT_CLASS;
				}
				else
				{
					if ((int)taskNpcId < 0 || taskMapId < 0)
					{
						return;
					}
					src = string.Concat(new string[]
					{
						mResources.DES_TASK[0],
						Npc.arrNpcTemplate[(int)taskNpcId].name,
						mResources.DES_TASK[1],
						TileMap.mapNames[taskMapId],
						mResources.DES_TASK[2]
					});
				}
				string[] array = mFont.tahoma_7_white.splitFontArray(src, 150);
				for (int l = 0; l < array.Length; l++)
				{
					if (l == 0)
					{
						mFont.tahoma_7_white.drawString(g, array[l], this.xstart + 5, this.yPaint = this.ystart, 0);
					}
					else
					{
						mFont.tahoma_7_white.drawString(g, array[l], this.xstart + 5, this.yPaint += 12, 0);
					}
				}
			}
		}
		else if (this.indexMenu == 1)
		{
			this.yPaint = this.ystart - 12;
			for (int m = 0; m < global::Char.myCharz().taskOrders.size(); m++)
			{
				TaskOrder taskOrder = (TaskOrder)global::Char.myCharz().taskOrders.elementAt(m);
				mFont.tahoma_7_white.drawString(g, taskOrder.name, this.xstart + 5, this.yPaint += 12, 0);
				if (taskOrder.count == (int)taskOrder.maxCount)
				{
					mFont.tahoma_7_white.drawString(g, string.Concat(new object[]
					{
						(taskOrder.taskId != 0) ? mResources.KILLBOSS : mResources.KILL,
						" ",
						Mob.arrMobTemplate[taskOrder.killId].name,
						" (",
						taskOrder.count,
						"/",
						taskOrder.maxCount,
						")"
					}), this.xstart + 5, this.yPaint += 12, 0);
				}
				else
				{
					mFont.tahoma_7_blue.drawString(g, string.Concat(new object[]
					{
						(taskOrder.taskId != 0) ? mResources.KILLBOSS : mResources.KILL,
						" ",
						Mob.arrMobTemplate[taskOrder.killId].name,
						" (",
						taskOrder.count,
						"/",
						taskOrder.maxCount,
						")"
					}), this.xstart + 5, this.yPaint += 12, 0);
				}
				this.indexRowMax += 3;
				this.inforW = this.popupW - 25;
				this.paintMultiLine(g, mFont.tahoma_7_grey, taskOrder.description, this.xstart + 5, this.yPaint += 12, 0);
				this.yPaint += 12;
			}
		}
		if (this.scroll == null)
		{
			this.scroll = new Scroll();
			this.scroll.setStyle(this.indexRowMax, 12, this.xScroll, this.yScroll, this.wScroll, this.hScroll - num - 40, true, 1);
		}
	}

	// Token: 0x06000876 RID: 2166 RVA: 0x0007BC00 File Offset: 0x00079E00
	public void paintMultiLine(mGraphics g, mFont f, string[] arr, string str, int x, int y, int align)
	{
		for (int i = 0; i < arr.Length; i++)
		{
			string text = arr[i];
			if (text.StartsWith("c"))
			{
				if (text.StartsWith("c0"))
				{
					text = text.Substring(2);
					f = mFont.tahoma_7b_dark;
				}
				else if (text.StartsWith("c1"))
				{
					text = text.Substring(2);
					f = mFont.tahoma_7b_yellow;
				}
				else if (text.StartsWith("c2"))
				{
					text = text.Substring(2);
					f = mFont.tahoma_7b_green;
				}
			}
			if (i == 0)
			{
				f.drawString(g, text, x, y, align);
			}
			else
			{
				if (i < this.indexRow + 30 && i > this.indexRow - 30)
				{
					f.drawString(g, text, x, y += 12, align);
				}
				else
				{
					y += 12;
				}
				this.yPaint += 12;
				this.indexRowMax++;
			}
		}
	}

	// Token: 0x06000877 RID: 2167 RVA: 0x0007BD10 File Offset: 0x00079F10
	public void paintMultiLine(mGraphics g, mFont f, string str, int x, int y, int align)
	{
		int num = (!GameCanvas.isTouch || GameCanvas.w < 320) ? 10 : 20;
		string[] array = f.splitFontArray(str, this.inforW - num);
		for (int i = 0; i < array.Length; i++)
		{
			if (i == 0)
			{
				f.drawString(g, array[i], x, y, align);
			}
			else
			{
				if (i < this.indexRow + 15 && i > this.indexRow - 15)
				{
					f.drawString(g, array[i], x, y += 12, align);
				}
				else
				{
					y += 12;
				}
				this.yPaint += 12;
				this.indexRowMax++;
			}
		}
	}

	// Token: 0x06000878 RID: 2168 RVA: 0x0007BDDC File Offset: 0x00079FDC
	public void cleanCombine()
	{
		for (int i = 0; i < this.vItemCombine.size(); i++)
		{
			((Item)this.vItemCombine.elementAt(i)).isSelect = false;
		}
		this.vItemCombine.removeAllElements();
	}

	// Token: 0x06000879 RID: 2169 RVA: 0x0007BE28 File Offset: 0x0007A028
	public void hideNow()
	{
		if (this.timeShow > 0)
		{
			this.isClose = false;
			return;
		}
		if (this.isTypeShop())
		{
			global::Char.myCharz().resetPartTemp();
		}
		if (this.chatTField != null && this.type == 13 && this.chatTField.isShow)
		{
			this.chatTField = null;
		}
		if (this.type == 13 && !this.isAccept)
		{
			Service.gI().giaodich(3, -1, -1, -1);
		}
		Res.outz("HIDE PANELLLLLLLLLLLLLLLLLLLLLL");
		SoundMn.gI().buttonClose();
		GameScr.isPaint = true;
		TileMap.lastPlanetId = -1;
		Panel.imgMap = null;
		mSystem.gcc();
		this.isClanOption = false;
		this.isClose = true;
		Hint.clickNpc();
		GameCanvas.panel2 = null;
		GameCanvas.clearAllPointerEvent();
		GameCanvas.clearKeyPressed();
		this.pointerDownTime = (this.pointerDownFirstX = 0);
		this.pointerIsDowning = false;
		this.isShow = false;
		if ((global::Char.myCharz().cHP <= 0 || global::Char.myCharz().statusMe == 14 || global::Char.myCharz().statusMe == 5) && global::Char.myCharz().meDead)
		{
			Command center = new Command(mResources.DIES[0], 11038, GameScr.gI());
			GameScr.gI().center = center;
			global::Char.myCharz().cHP = 0;
		}
	}

	// Token: 0x0600087A RID: 2170 RVA: 0x0007BF8C File Offset: 0x0007A18C
	public void hide()
	{
		if (this.timeShow > 0)
		{
			this.isClose = false;
			return;
		}
		if (this.isTypeShop())
		{
			global::Char.myCharz().resetPartTemp();
		}
		if (this.chatTField != null && this.type == 13 && this.chatTField.isShow)
		{
			this.chatTField = null;
		}
		if (this.type == 13 && !this.isAccept)
		{
			Service.gI().giaodich(3, -1, -1, -1);
		}
		if (this.type == 15)
		{
			Service.gI().sendThachDau(-1);
		}
		SoundMn.gI().buttonClose();
		GameScr.isPaint = true;
		TileMap.lastPlanetId = -1;
		if (Panel.imgMap != null)
		{
			Panel.imgMap.texture = null;
			Panel.imgMap = null;
		}
		mSystem.gcc();
		this.isClanOption = false;
		if (this.type != 4)
		{
			if (this.type == 24)
			{
				this.setTypeGameInfo();
			}
			else if (this.type == 23)
			{
				this.setTypeMain();
			}
			else if (this.type == 3 || this.type == 14)
			{
				if (this.isChangeZone)
				{
					this.isClose = true;
				}
				else
				{
					this.setTypeMain();
					this.cmx = (this.cmtoX = 0);
				}
			}
			else if (this.type == 18 || this.type == 19 || this.type == 20 || this.type == 21)
			{
				this.setTypeMain();
				this.cmx = (this.cmtoX = 0);
			}
			else if (this.type == 8 || this.type == 11 || this.type == 16)
			{
				this.setTypeAccount();
				this.cmx = (this.cmtoX = 0);
			}
			else
			{
				this.isClose = true;
			}
		}
		else
		{
			this.setTypeMain();
			this.cmx = (this.cmtoX = 0);
		}
		Hint.clickNpc();
		GameCanvas.panel2 = null;
		GameCanvas.clearAllPointerEvent();
		GameCanvas.clearKeyPressed();
		this.pointerDownTime = (this.pointerDownFirstX = 0);
		this.pointerIsDowning = false;
		if ((global::Char.myCharz().cHP <= 0 || global::Char.myCharz().statusMe == 14 || global::Char.myCharz().statusMe == 5) && global::Char.myCharz().meDead)
		{
			Command center = new Command(mResources.DIES[0], 11038, GameScr.gI());
			GameScr.gI().center = center;
			global::Char.myCharz().cHP = 0;
		}
	}

	// Token: 0x0600087B RID: 2171 RVA: 0x0007C240 File Offset: 0x0007A440
	public void update()
	{
		if (this.chatTField != null && this.chatTField.isShow)
		{
			this.chatTField.update();
			return;
		}
		if (this.isKiguiXu)
		{
			this.delayKigui++;
			if (this.delayKigui == 10)
			{
				this.delayKigui = 0;
				this.isKiguiXu = false;
				this.chatTField.tfChat.setText(string.Empty);
				this.chatTField.strChat = mResources.kiguiXuchat + " ";
				this.chatTField.tfChat.name = mResources.input_money;
				this.chatTField.to = string.Empty;
				this.chatTField.isShow = true;
				this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_NUMERIC);
				this.chatTField.tfChat.setMaxTextLenght(9);
				if (GameCanvas.isTouch)
				{
					this.chatTField.tfChat.doChangeToTextBox();
				}
				if (Main.isWindowsPhone)
				{
					this.chatTField.tfChat.strInfo = this.chatTField.strChat;
				}
				if (!Main.isPC)
				{
					this.chatTField.startChat2(this, string.Empty);
				}
			}
			return;
		}
		if (this.isKiguiLuong)
		{
			this.delayKigui++;
			if (this.delayKigui == 10)
			{
				this.delayKigui = 0;
				this.isKiguiLuong = false;
				this.chatTField.tfChat.setText(string.Empty);
				this.chatTField.strChat = mResources.kiguiLuongchat + "  ";
				this.chatTField.tfChat.name = mResources.input_money;
				this.chatTField.to = string.Empty;
				this.chatTField.isShow = true;
				this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_NUMERIC);
				this.chatTField.tfChat.setMaxTextLenght(9);
				if (GameCanvas.isTouch)
				{
					this.chatTField.tfChat.doChangeToTextBox();
				}
				if (Main.isWindowsPhone)
				{
					this.chatTField.tfChat.strInfo = this.chatTField.strChat;
				}
				if (!Main.isPC)
				{
					this.chatTField.startChat2(this, string.Empty);
				}
			}
			return;
		}
		if (this.scroll != null)
		{
			this.scroll.updatecm();
		}
		if (this.tabIcon != null && this.tabIcon.isShow)
		{
			this.tabIcon.update();
			return;
		}
		this.moveCamera();
		if (this.waitToPerform > 0)
		{
			this.waitToPerform--;
			if (this.waitToPerform == 0)
			{
				this.lastSelect[this.currentTabIndex] = this.selected;
				switch (this.type)
				{
				case 0:
					this.doFireMain();
					break;
				case 1:
				case 17:
					this.doFireShop();
					break;
				case 2:
					this.doFireBox();
					break;
				case 3:
					this.doFireZone();
					break;
				case 4:
					this.doFireMap();
					break;
				case 7:
					if (this.Equals(GameCanvas.panel2) && GameCanvas.panel.type == 2)
					{
						this.doFireBox();
						return;
					}
					this.doFireInventory();
					break;
				case 8:
					this.doFireLogMessage();
					break;
				case 9:
					this.doFireArchivement();
					break;
				case 10:
					this.doFirePlayerMenu();
					break;
				case 11:
					this.doFireFriend();
					break;
				case 12:
					this.doFireCombine();
					break;
				case 13:
					this.doFireGiaoDich();
					break;
				case 14:
					this.doFireMapTrans();
					break;
				case 15:
					this.doFireTop();
					break;
				case 16:
					this.doFireEnemy();
					break;
				case 18:
					this.doFireChangeFlag();
					break;
				case 19:
					this.doFireOption();
					break;
				case 20:
					this.doFireAccount();
					break;
				case 21:
					this.doFirePetMain();
					break;
				case 22:
					this.doFireAuto();
					break;
				case 23:
					this.doFireGameInfo();
					break;
				case 25:
					this.doSpeacialSkill();
					break;
				}
			}
		}
		for (int i = 0; i < ClanMessage.vMessage.size(); i++)
		{
			((ClanMessage)ClanMessage.vMessage.elementAt(i)).update();
		}
		this.updateCombineEff();
	}

	// Token: 0x0600087C RID: 2172 RVA: 0x00003984 File Offset: 0x00001B84
	private void doSpeacialSkill()
	{
	}

	// Token: 0x0600087D RID: 2173 RVA: 0x0007C6EC File Offset: 0x0007A8EC
	private void doFireGameInfo()
	{
		if (this.selected == -1)
		{
			return;
		}
		this.infoSelect = this.selected;
		((GameInfo)Panel.vGameInfo.elementAt(this.infoSelect)).hasRead = true;
		Rms.saveRMSInt(((GameInfo)Panel.vGameInfo.elementAt(this.infoSelect)).id + string.Empty, 1);
		this.setTypeGameSubInfo();
	}

	// Token: 0x0600087E RID: 2174 RVA: 0x00003984 File Offset: 0x00001B84
	private void doFireAuto()
	{
	}

	// Token: 0x0600087F RID: 2175 RVA: 0x0007C764 File Offset: 0x0007A964
	private void doFirePetMain()
	{
		if (this.currentTabIndex == 0)
		{
			if (this.selected == -1)
			{
				return;
			}
			if (this.selected > global::Char.myPetz().arrItemBody.Length - 1)
			{
				return;
			}
			MyVector myVector = new MyVector(string.Empty);
			Item item = global::Char.myPetz().arrItemBody[this.selected];
			this.currItem = item;
			if (this.currItem != null)
			{
				myVector.addElement(new Command(mResources.MOVEOUT, this, 2006, this.currItem));
				GameCanvas.menu.startAt(myVector, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
				this.addItemDetail(this.currItem);
			}
			else
			{
				this.cp = null;
			}
		}
		if (this.currentTabIndex == 1)
		{
			this.doFirePetStatus();
		}
		if (this.currentTabIndex == 2)
		{
			this.doFireInventory();
		}
	}

	// Token: 0x06000880 RID: 2176 RVA: 0x0007C858 File Offset: 0x0007AA58
	private void doFirePetStatus()
	{
		if (this.selected == -1)
		{
			return;
		}
		if (this.selected == 5)
		{
			GameCanvas.startYesNoDlg(mResources.sure_fusion, new Command(mResources.YES, 888351), new Command(mResources.NO, 2001));
			return;
		}
		Service.gI().petStatus((sbyte)this.selected);
		if (this.selected < 4)
		{
			global::Char.myPetz().petStatus = (sbyte)this.selected;
		}
	}

	// Token: 0x06000881 RID: 2177 RVA: 0x0007C8D8 File Offset: 0x0007AAD8
	private void doFireTop()
	{
		if (this.selected < -1)
		{
			return;
		}
		if (this.isThachDau)
		{
			Service.gI().sendTop(this.topName, (sbyte)this.selected);
		}
		else
		{
			MyVector myVector = new MyVector(string.Empty);
			myVector.addElement(new Command(mResources.CHAR_ORDER[0], this, 9999, (TopInfo)this.vTop.elementAt(this.selected)));
			GameCanvas.menu.startAt(myVector, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
			this.addThachDauDetail((TopInfo)this.vTop.elementAt(this.selected));
		}
	}

	// Token: 0x06000882 RID: 2178 RVA: 0x000075EE File Offset: 0x000057EE
	private void doFireMapTrans()
	{
		this.doFireZone();
	}

	// Token: 0x06000883 RID: 2179 RVA: 0x0007C99C File Offset: 0x0007AB9C
	private void doFireGiaoDich()
	{
		if (this.currentTabIndex == 0 && this.Equals(GameCanvas.panel))
		{
			this.doFireInventory();
			return;
		}
		if ((this.currentTabIndex == 0 && this.Equals(GameCanvas.panel2)) || this.currentTabIndex == 2)
		{
			if (this.Equals(GameCanvas.panel2))
			{
				this.currItem = (Item)GameCanvas.panel2.vFriendGD.elementAt(this.selected);
			}
			else
			{
				this.currItem = (Item)GameCanvas.panel.vFriendGD.elementAt(this.selected);
			}
			Res.outz2("toi day select= " + this.selected);
			MyVector myVector = new MyVector();
			myVector.addElement(new Command(mResources.CLOSE, this, 8000, this.currItem));
			if (this.currItem != null)
			{
				GameCanvas.menu.startAt(myVector, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
				this.addItemDetail(this.currItem);
			}
			else
			{
				this.cp = null;
			}
		}
		if (this.currentTabIndex == 1)
		{
			if (this.selected == this.currentListLength - 3)
			{
				if (this.isLock)
				{
					return;
				}
				this.putMoney();
			}
			else if (this.selected == this.currentListLength - 2)
			{
				if (!this.isAccept)
				{
					this.isLock = !this.isLock;
					if (this.isLock)
					{
						Service.gI().giaodich(5, -1, -1, -1);
					}
					else
					{
						this.hide();
						InfoDlg.showWait();
						Service.gI().giaodich(3, -1, -1, -1);
					}
				}
				else
				{
					this.isAccept = false;
				}
			}
			else if (this.selected == this.currentListLength - 1)
			{
				if (this.isLock && !this.isAccept && this.isFriendLock)
				{
					GameCanvas.startYesNoDlg(mResources.do_u_sure_to_trade, new Command(mResources.YES, this, 7002, null), new Command(mResources.NO, this, 4005, null));
				}
			}
			else
			{
				if (this.isLock)
				{
					return;
				}
				this.currItem = (Item)GameCanvas.panel.vMyGD.elementAt(this.selected);
				MyVector myVector2 = new MyVector();
				myVector2.addElement(new Command(mResources.CLOSE, this, 8000, this.currItem));
				if (this.currItem != null)
				{
					GameCanvas.menu.startAt(myVector2, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
					this.addItemDetail(this.currItem);
				}
				else
				{
					this.cp = null;
				}
			}
		}
		if (GameCanvas.isTouch)
		{
			this.selected = -1;
		}
	}

	// Token: 0x06000884 RID: 2180 RVA: 0x0007CC94 File Offset: 0x0007AE94
	private void doFireCombine()
	{
		if (this.currentTabIndex == 0)
		{
			if (this.selected == -1)
			{
				return;
			}
			if (this.vItemCombine.size() == 0)
			{
				return;
			}
			if (this.selected == this.vItemCombine.size())
			{
				this.keyTouchCombine = -1;
				this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
				InfoDlg.showWait();
				Service.gI().combine(1, this.vItemCombine);
				return;
			}
			if (this.selected > this.vItemCombine.size() - 1)
			{
				return;
			}
			this.currItem = (Item)GameCanvas.panel.vItemCombine.elementAt(this.selected);
			MyVector myVector = new MyVector();
			myVector.addElement(new Command(mResources.GETOUT, this, 6001, this.currItem));
			if (this.currItem != null)
			{
				GameCanvas.menu.startAt(myVector, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
				this.addItemDetail(this.currItem);
			}
			else
			{
				this.cp = null;
			}
		}
		if (this.currentTabIndex == 1)
		{
			this.doFireInventory();
		}
	}

	// Token: 0x06000885 RID: 2181 RVA: 0x000075F6 File Offset: 0x000057F6
	private void doFirePlayerMenu()
	{
		if (this.selected == -1)
		{
			return;
		}
		this.isSelectPlayerMenu = true;
		this.hide();
	}

	// Token: 0x06000886 RID: 2182 RVA: 0x0007CDD4 File Offset: 0x0007AFD4
	private void doFireShop()
	{
		this.currItem = null;
		if (this.selected < 0)
		{
			return;
		}
		MyVector myVector = new MyVector();
		if (this.currentTabIndex < this.currentTabName.Length - ((GameCanvas.panel2 == null) ? 1 : 0) && this.type != 17)
		{
			this.currItem = global::Char.myCharz().arrItemShop[this.currentTabIndex][this.selected];
			if (this.currItem != null)
			{
				if (this.currItem.isBuySpec)
				{
					if (this.currItem.buySpec > 0)
					{
						myVector.addElement(new Command(mResources.buy_with + "\n" + Res.formatNumber2((long)this.currItem.buySpec), this, 3005, this.currItem));
					}
				}
				else if (this.typeShop == 4)
				{
					myVector.addElement(new Command(mResources.receive_upper, this, 30001, this.currItem));
					myVector.addElement(new Command(mResources.DELETE, this, 30002, this.currItem));
					myVector.addElement(new Command(mResources.receive_all, this, 30003, this.currItem));
				}
				else if (this.currItem.buyCoin == 0 && this.currItem.buyGold == 0)
				{
					if (this.currItem.powerRequire != 0L)
					{
						myVector.addElement(new Command(string.Concat(new string[]
						{
							mResources.learn_with,
							"\n",
							Res.formatNumber(this.currItem.powerRequire),
							" \n",
							mResources.potential
						}), this, 3004, this.currItem));
					}
					else
					{
						myVector.addElement(new Command(mResources.receive_upper + "\n" + mResources.free, this, 3000, this.currItem));
					}
				}
				else if (this.typeShop != 2)
				{
					if (this.currItem.buyCoin > 0)
					{
						myVector.addElement(new Command(string.Concat(new string[]
						{
							mResources.buy_with,
							"\n",
							Res.formatNumber2((long)this.currItem.buyCoin),
							"\n",
							mResources.XU
						}), this, 3000, this.currItem));
					}
					if (this.currItem.buyGold > 0)
					{
						myVector.addElement(new Command(string.Concat(new string[]
						{
							mResources.buy_with,
							"\n",
							Res.formatNumber2((long)this.currItem.buyGold),
							"\n",
							mResources.LUONG
						}), this, 3001, this.currItem));
					}
				}
				else
				{
					if (this.currItem.buyCoin != -1)
					{
						myVector.addElement(new Command(string.Concat(new string[]
						{
							mResources.buy_with,
							"\n",
							Res.formatNumber2((long)this.currItem.buyCoin),
							"\n",
							mResources.XU
						}), this, 10016, this.currItem));
					}
					if (this.currItem.buyGold != -1)
					{
						myVector.addElement(new Command(string.Concat(new string[]
						{
							mResources.buy_with,
							"\n",
							Res.formatNumber2((long)this.currItem.buyGold),
							"\n",
							mResources.LUONG
						}), this, 10017, this.currItem));
					}
				}
			}
		}
		else if (this.typeShop == 0)
		{
			Item[] arrItemBody = global::Char.myCharz().arrItemBody;
			if (this.selected >= arrItemBody.Length)
			{
				sbyte b = (sbyte)(this.selected - arrItemBody.Length);
				Item item = global::Char.myCharz().arrItemBag[(int)b];
				if (item != null)
				{
					this.currItem = item;
				}
			}
			else
			{
				Item item2 = global::Char.myCharz().arrItemBody[this.selected];
				if (item2 != null)
				{
					this.currItem = item2;
				}
			}
			if (this.currItem != null)
			{
				myVector.addElement(new Command(mResources.SALE, this, 3002, this.currItem));
			}
		}
		else
		{
			if (this.type == 17)
			{
				this.currItem = global::Char.myCharz().arrItemShop[4][this.selected];
			}
			else
			{
				this.currItem = global::Char.myCharz().arrItemShop[this.currentTabIndex][this.selected];
			}
			if ((int)this.currItem.buyType == 0)
			{
				if (this.currItem.isHaveOption(87))
				{
					myVector.addElement(new Command(mResources.kiguiLuong, this, 10013, this.currItem));
				}
				else
				{
					myVector.addElement(new Command(mResources.kiguiXu, this, 10012, this.currItem));
				}
			}
			else if ((int)this.currItem.buyType == 1)
			{
				myVector.addElement(new Command(mResources.huykigui, this, 10014, this.currItem));
				myVector.addElement(new Command(mResources.upTop, this, 10018, this.currItem));
			}
			else if ((int)this.currItem.buyType == 2)
			{
				myVector.addElement(new Command(mResources.nhantien, this, 10015, this.currItem));
			}
		}
		if (this.currItem != null)
		{
			global::Char.myCharz().setPartTemp(this.currItem.headTemp, this.currItem.bodyTemp, this.currItem.legTemp, this.currItem.bagTemp);
			GameCanvas.menu.startAt(myVector, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
			this.addItemDetail(this.currItem);
		}
		else
		{
			this.cp = null;
		}
	}

	// Token: 0x06000887 RID: 2183 RVA: 0x0007D3E0 File Offset: 0x0007B5E0
	private void doFireArchivement()
	{
		if (this.selected < 0)
		{
			return;
		}
		if (global::Char.myCharz().arrArchive[this.selected].isFinish && !global::Char.myCharz().arrArchive[this.selected].isRecieve)
		{
			if (!GameCanvas.isTouch)
			{
				Service.gI().getArchivemnt(this.selected);
			}
			else if (GameCanvas.px > this.xScroll + this.wScroll - 40)
			{
				Service.gI().getArchivemnt(this.selected);
			}
		}
	}

	// Token: 0x06000888 RID: 2184 RVA: 0x0007D47C File Offset: 0x0007B67C
	private void doFireInventory()
	{
		Res.outz("fire inventory");
		if (global::Char.myCharz().statusMe == 14)
		{
			GameCanvas.startOKDlg(mResources.can_not_do_when_die);
			return;
		}
		if (this.selected == -1)
		{
			return;
		}
		this.currItem = null;
		MyVector myVector = new MyVector();
		Item[] arrItemBody = global::Char.myCharz().arrItemBody;
		if (this.selected >= arrItemBody.Length)
		{
			sbyte b = (sbyte)(this.selected - arrItemBody.Length);
			Item item = global::Char.myCharz().arrItemBag[(int)b];
			if (item != null)
			{
				this.currItem = item;
				if (GameCanvas.panel.type == 12)
				{
					myVector.addElement(new Command(mResources.use_for_combine, this, 6000, this.currItem));
				}
				else if (GameCanvas.panel.type == 13)
				{
					myVector.addElement(new Command(mResources.use_for_trade, this, 7000, this.currItem));
				}
				else if (item.isTypeBody())
				{
					myVector.addElement(new Command(mResources.USE, this, 2000, this.currItem));
					if (global::Char.myCharz().havePet)
					{
						myVector.addElement(new Command(mResources.MOVEFORPET, this, 2005, this.currItem));
					}
				}
				else
				{
					myVector.addElement(new Command(mResources.USE, this, 2001, this.currItem));
				}
			}
		}
		else
		{
			Item item2 = global::Char.myCharz().arrItemBody[this.selected];
			if (item2 != null)
			{
				this.currItem = item2;
				myVector.addElement(new Command(mResources.GETOUT, this, 2002, this.currItem));
			}
		}
		if (this.currItem != null)
		{
			global::Char.myCharz().setPartTemp(this.currItem.headTemp, this.currItem.bodyTemp, this.currItem.legTemp, this.currItem.bagTemp);
			if (GameCanvas.panel.type != 12 && GameCanvas.panel.type != 13)
			{
				if (this.position == 0)
				{
					myVector.addElement(new Command(mResources.MOVEOUT, this, 2003, this.currItem));
				}
				if (this.position == 1)
				{
					myVector.addElement(new Command(mResources.SALE, this, 3002, this.currItem));
				}
			}
			GameCanvas.menu.startAt(myVector, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
			this.addItemDetail(this.currItem);
		}
		else
		{
			this.cp = null;
		}
	}

	// Token: 0x06000889 RID: 2185 RVA: 0x0007D724 File Offset: 0x0007B924
	private void doRada()
	{
		this.hide();
		if (RadarScr.list == null || RadarScr.list.size() == 0)
		{
			Service.gI().SendRada(0, -1);
			RadarScr.gI().switchToMe();
		}
		else
		{
			RadarScr.gI().switchToMe();
		}
	}

	// Token: 0x0600088A RID: 2186 RVA: 0x0007D778 File Offset: 0x0007B978
	private void doFireTool()
	{
		if (this.selected < 0)
		{
			return;
		}
		if (!global::Char.myCharz().havePet)
		{
			switch (this.selected)
			{
			case 0:
				this.doRada();
				break;
			case 1:
				this.hide();
				Service.gI().openMenu(54);
				break;
			case 2:
				this.setTypeGameInfo();
				break;
			case 3:
				Service.gI().getFlag(0, -1);
				InfoDlg.showWait();
				break;
			case 4:
				if (global::Char.myCharz().statusMe == 14)
				{
					GameCanvas.startOKDlg(mResources.can_not_do_when_die);
					return;
				}
				Service.gI().openUIZone();
				break;
			case 5:
				GameCanvas.endDlg();
				if (global::Char.myCharz().checkLuong() < 5)
				{
					GameCanvas.startOKDlg(mResources.not_enough_luong_world_channel);
					return;
				}
				if (this.chatTField == null)
				{
					this.chatTField = new ChatTextField();
					this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
					this.chatTField.initChatTextField();
					this.chatTField.parentScreen = GameCanvas.panel;
				}
				this.chatTField.strChat = mResources.world_channel_5_luong;
				this.chatTField.tfChat.name = mResources.CHAT;
				this.chatTField.to = string.Empty;
				this.chatTField.isShow = true;
				this.chatTField.tfChat.isFocus = true;
				this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
				if (Main.isWindowsPhone)
				{
					this.chatTField.tfChat.strInfo = this.chatTField.strChat;
				}
				if (!Main.isPC)
				{
					this.chatTField.startChat2(this, string.Empty);
				}
				else if (GameCanvas.isTouch)
				{
					this.chatTField.tfChat.doChangeToTextBox();
				}
				break;
			case 6:
				this.setTypeAccount();
				break;
			case 7:
				this.setTypeOption();
				break;
			case 8:
				GameCanvas.loginScr.backToRegister();
				break;
			case 9:
				if (GameCanvas.loginScr.isLogin2)
				{
					SoundMn.gI().backToRegister();
				}
				break;
			}
		}
		else
		{
			switch (this.selected)
			{
			case 0:
				this.doRada();
				break;
			case 1:
				this.hide();
				Service.gI().openMenu(54);
				break;
			case 2:
				this.setTypeGameInfo();
				break;
			case 3:
				this.doFirePet();
				break;
			case 4:
				Service.gI().getFlag(0, -1);
				InfoDlg.showWait();
				break;
			case 5:
				if (global::Char.myCharz().statusMe == 14)
				{
					GameCanvas.startOKDlg(mResources.can_not_do_when_die);
					return;
				}
				Service.gI().openUIZone();
				break;
			case 6:
				GameCanvas.endDlg();
				if (global::Char.myCharz().checkLuong() < 5)
				{
					GameCanvas.startOKDlg(mResources.not_enough_luong_world_channel);
					return;
				}
				if (this.chatTField == null)
				{
					this.chatTField = new ChatTextField();
					this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
					this.chatTField.initChatTextField();
					this.chatTField.parentScreen = GameCanvas.panel;
				}
				this.chatTField.strChat = mResources.world_channel_5_luong;
				this.chatTField.tfChat.name = mResources.CHAT;
				this.chatTField.to = string.Empty;
				this.chatTField.isShow = true;
				this.chatTField.tfChat.isFocus = true;
				this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
				if (Main.isWindowsPhone)
				{
					this.chatTField.tfChat.strInfo = this.chatTField.strChat;
				}
				if (!Main.isPC)
				{
					this.chatTField.startChat2(this, string.Empty);
				}
				else if (GameCanvas.isTouch)
				{
					this.chatTField.tfChat.doChangeToTextBox();
				}
				break;
			case 7:
				this.setTypeAccount();
				break;
			case 8:
				this.setTypeOption();
				break;
			case 9:
				GameCanvas.loginScr.backToRegister();
				break;
			case 10:
				if (GameCanvas.loginScr.isLogin2)
				{
					SoundMn.gI().backToRegister();
				}
				break;
			}
		}
	}

	// Token: 0x0600088B RID: 2187 RVA: 0x0007DC20 File Offset: 0x0007BE20
	private void setTypeGameSubInfo()
	{
		string content = ((GameInfo)Panel.vGameInfo.elementAt(this.infoSelect)).content;
		Panel.contenInfo = mFont.tahoma_7_grey.splitFontArray(content, this.wScroll - 40);
		this.currentListLength = Panel.contenInfo.Length;
		this.ITEM_HEIGHT = 16;
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
		this.type = 24;
		this.setType(0);
	}

	// Token: 0x0600088C RID: 2188 RVA: 0x0007DD0C File Offset: 0x0007BF0C
	private void setTypeGameInfo()
	{
		this.currentListLength = Panel.vGameInfo.size();
		this.ITEM_HEIGHT = 24;
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
		this.type = 23;
		this.setType(0);
	}

	// Token: 0x0600088D RID: 2189 RVA: 0x00007612 File Offset: 0x00005812
	private void doFirePet()
	{
		InfoDlg.showWait();
		Service.gI().petInfo();
		this.timeShow = 20;
	}

	// Token: 0x0600088E RID: 2190 RVA: 0x0007DDC8 File Offset: 0x0007BFC8
	private void searchClan()
	{
		this.chatTField.strChat = mResources.input_clan_name;
		this.chatTField.tfChat.name = mResources.clan_name;
		this.chatTField.to = string.Empty;
		this.chatTField.isShow = true;
		this.chatTField.tfChat.isFocus = true;
		this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
		if (Main.isWindowsPhone)
		{
			this.chatTField.tfChat.strInfo = this.chatTField.strChat;
		}
		if (!Main.isPC)
		{
			this.chatTField.startChat2(this, string.Empty);
		}
	}

	// Token: 0x0600088F RID: 2191 RVA: 0x0007DE7C File Offset: 0x0007C07C
	private void chatClan()
	{
		this.chatTField.strChat = mResources.chat_clan;
		this.chatTField.tfChat.name = mResources.CHAT;
		this.chatTField.to = string.Empty;
		this.chatTField.isShow = true;
		this.chatTField.tfChat.isFocus = true;
		this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
		if (Main.isWindowsPhone)
		{
			this.chatTField.tfChat.strInfo = this.chatTField.strChat;
		}
		if (!Main.isPC)
		{
			this.chatTField.startChat2(this, string.Empty);
		}
	}

	// Token: 0x06000890 RID: 2192 RVA: 0x0007DF30 File Offset: 0x0007C130
	public void creatClan()
	{
		this.chatTField.strChat = mResources.input_clan_name_to_create;
		this.chatTField.tfChat.name = mResources.input_clan_name;
		this.chatTField.to = string.Empty;
		this.chatTField.isShow = true;
		this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
		if (Main.isWindowsPhone)
		{
			this.chatTField.tfChat.strInfo = this.chatTField.strChat;
		}
		if (!Main.isPC)
		{
			this.chatTField.startChat2(this, string.Empty);
		}
	}

	// Token: 0x06000891 RID: 2193 RVA: 0x0007DFD4 File Offset: 0x0007C1D4
	public void putMoney()
	{
		if (this.chatTField == null)
		{
			this.chatTField = new ChatTextField();
			this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
			this.chatTField.initChatTextField();
			this.chatTField.parentScreen = GameCanvas.panel;
		}
		this.chatTField.strChat = mResources.input_money_to_trade;
		this.chatTField.tfChat.name = mResources.input_money;
		this.chatTField.to = string.Empty;
		this.chatTField.isShow = true;
		this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_NUMERIC);
		this.chatTField.tfChat.setMaxTextLenght(9);
		if (GameCanvas.isTouch)
		{
			this.chatTField.tfChat.doChangeToTextBox();
		}
		if (Main.isWindowsPhone)
		{
			this.chatTField.tfChat.strInfo = this.chatTField.strChat;
		}
		if (!Main.isPC)
		{
			this.chatTField.startChat2(this, string.Empty);
		}
	}

	// Token: 0x06000892 RID: 2194 RVA: 0x0007E0FC File Offset: 0x0007C2FC
	public void putQuantily()
	{
		if (this.chatTField == null)
		{
			this.chatTField = new ChatTextField();
			this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
			this.chatTField.initChatTextField();
			this.chatTField.parentScreen = GameCanvas.panel;
		}
		this.chatTField.strChat = mResources.input_quantity_to_trade;
		this.chatTField.tfChat.name = mResources.input_quantity;
		this.chatTField.to = string.Empty;
		this.chatTField.isShow = true;
		this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_NUMERIC);
		if (GameCanvas.isTouch)
		{
			this.chatTField.tfChat.doChangeToTextBox();
		}
		if (Main.isWindowsPhone)
		{
			this.chatTField.tfChat.strInfo = this.chatTField.strChat;
		}
		if (!Main.isPC)
		{
			this.chatTField.startChat2(this, string.Empty);
		}
	}

	// Token: 0x06000893 RID: 2195 RVA: 0x0007E214 File Offset: 0x0007C414
	public void chagenSlogan()
	{
		this.chatTField.strChat = mResources.input_clan_slogan;
		this.chatTField.tfChat.name = mResources.input_clan_slogan;
		this.chatTField.to = string.Empty;
		this.chatTField.isShow = true;
		this.chatTField.tfChat.isFocus = true;
		this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
		if (Main.isWindowsPhone)
		{
			this.chatTField.tfChat.strInfo = this.chatTField.strChat;
		}
		if (!Main.isPC)
		{
			this.chatTField.startChat2(this, string.Empty);
		}
	}

	// Token: 0x06000894 RID: 2196 RVA: 0x0007E2C8 File Offset: 0x0007C4C8
	public void changeIcon()
	{
		if (this.tabIcon == null)
		{
			this.tabIcon = new TabClanIcon();
		}
		this.tabIcon.text = this.chatTField.tfChat.getText();
		this.tabIcon.show(false);
		this.chatTField.isShow = false;
	}

	// Token: 0x06000895 RID: 2197 RVA: 0x0007E320 File Offset: 0x0007C520
	private void addFriend(InfoItem info)
	{
		string text = "|0|1|" + info.charInfo.cName;
		text += "\n";
		if (info.isOnline)
		{
			text = text + "|4|1|" + mResources.is_online;
		}
		else
		{
			text = text + "|3|1|" + mResources.is_offline;
		}
		text += "\n--";
		string text2 = text;
		text = string.Concat(new string[]
		{
			text2,
			"\n|5|",
			mResources.power,
			": ",
			info.s
		});
		this.cp = new ChatPopup();
		this.popUpDetailInit(this.cp, text);
		this.charInfo = info.charInfo;
		this.currItem = null;
	}

	// Token: 0x06000896 RID: 2198 RVA: 0x0007E3EC File Offset: 0x0007C5EC
	private void doFireEnemy()
	{
		if (this.selected < 0)
		{
			return;
		}
		if (this.vEnemy.size() == 0)
		{
			return;
		}
		MyVector myVector = new MyVector();
		this.currInfoItem = this.selected;
		myVector.addElement(new Command(mResources.REVENGE, this, 10000, (InfoItem)this.vEnemy.elementAt(this.currInfoItem)));
		myVector.addElement(new Command(mResources.DELETE, this, 10001, (InfoItem)this.vEnemy.elementAt(this.currInfoItem)));
		GameCanvas.menu.startAt(myVector, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
		this.addFriend((InfoItem)this.vEnemy.elementAt(this.selected));
	}

	// Token: 0x06000897 RID: 2199 RVA: 0x0007E4CC File Offset: 0x0007C6CC
	private void doFireFriend()
	{
		if (this.selected < 0)
		{
			return;
		}
		if (this.vFriend.size() == 0)
		{
			return;
		}
		MyVector myVector = new MyVector();
		this.currInfoItem = this.selected;
		myVector.addElement(new Command(mResources.CHAT, this, 8001, (InfoItem)this.vFriend.elementAt(this.currInfoItem)));
		myVector.addElement(new Command(mResources.DELETE, this, 8002, (InfoItem)this.vFriend.elementAt(this.currInfoItem)));
		myVector.addElement(new Command(mResources.den, this, 8004, (InfoItem)this.vFriend.elementAt(this.currInfoItem)));
		GameCanvas.menu.startAt(myVector, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
		this.addFriend((InfoItem)this.vFriend.elementAt(this.selected));
	}

	// Token: 0x06000898 RID: 2200 RVA: 0x0007E5D8 File Offset: 0x0007C7D8
	private void doFireChangeFlag()
	{
		if (this.selected < 0)
		{
			return;
		}
		MyVector myVector = new MyVector();
		this.currInfoItem = this.selected;
		myVector.addElement(new Command(mResources.change_flag, this, 10030, null));
		myVector.addElement(new Command(mResources.BACK, this, 10031, null));
		GameCanvas.menu.startAt(myVector, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
	}

	// Token: 0x06000899 RID: 2201 RVA: 0x0007E660 File Offset: 0x0007C860
	private void doFireLogMessage()
	{
		if (this.selected == 0)
		{
			this.isViewChatServer = !this.isViewChatServer;
			Rms.saveRMSInt("viewchat", (!this.isViewChatServer) ? 0 : 1);
			if (GameCanvas.isTouch)
			{
				this.selected = -1;
			}
			return;
		}
		if (this.selected < 0)
		{
			return;
		}
		if (this.logChat.size() == 0)
		{
			return;
		}
		MyVector myVector = new MyVector();
		this.currInfoItem = this.selected - 1;
		myVector.addElement(new Command(mResources.CHAT, this, 8001, (InfoItem)this.logChat.elementAt(this.currInfoItem)));
		myVector.addElement(new Command(mResources.make_friend, this, 8003, (InfoItem)this.logChat.elementAt(this.currInfoItem)));
		GameCanvas.menu.startAt(myVector, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
		this.addLogMessage((InfoItem)this.logChat.elementAt(this.selected - 1));
	}

	// Token: 0x0600089A RID: 2202 RVA: 0x0007E78C File Offset: 0x0007C98C
	private void doFireClanOption()
	{
		this.partID = null;
		this.charInfo = null;
		Res.outz("cSelect= " + this.cSelected);
		if (this.selected < 0)
		{
			this.cSelected = -1;
			return;
		}
		if (global::Char.myCharz().clan == null)
		{
			if (this.selected == 0)
			{
				if (this.cSelected == 0)
				{
					this.searchClan();
				}
				else if (this.cSelected == 1)
				{
					InfoDlg.showWait();
					this.creatClan();
					Service.gI().getClan(1, -1, null);
				}
			}
			else if (this.selected != -1)
			{
				if (this.selected == 1)
				{
					if (this.isSearchClan)
					{
						Service.gI().searchClan(string.Empty);
					}
					else if (this.isViewMember && this.currClan != null)
					{
						GameCanvas.startYesNoDlg(mResources.do_u_want_join_clan + this.currClan.name, new Command(mResources.YES, this, 4000, this.currClan), new Command(mResources.NO, this, 4005, this.currClan));
					}
				}
				else if (this.isSearchClan)
				{
					this.currClan = this.getCurrClan();
					if (this.currClan != null)
					{
						MyVector myVector = new MyVector();
						myVector.addElement(new Command(mResources.request_join_clan, this, 4000, this.currClan));
						myVector.addElement(new Command(mResources.view_clan_member, this, 4001, this.currClan));
						GameCanvas.menu.startAt(myVector, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
						this.addClanDetail(this.getCurrClan());
					}
				}
				else if (this.isViewMember)
				{
					this.currMem = this.getCurrMember();
					if (this.currMem != null)
					{
						MyVector myVector2 = new MyVector();
						myVector2.addElement(new Command(mResources.CLOSE, this, 8000, this.currClan));
						GameCanvas.menu.startAt(myVector2, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
						GameCanvas.menu.startAt(myVector2, 0, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
						this.addClanMemberDetail(this.currMem);
					}
				}
			}
		}
		else if (this.selected == 0)
		{
			if (this.isMessage)
			{
				if (this.cSelected == 0)
				{
					if (this.myMember.size() > 1)
					{
						this.chatClan();
					}
					else
					{
						this.member = null;
						this.isSearchClan = false;
						this.isViewMember = true;
						this.isMessage = false;
						this.currentListLength = this.myMember.size() + 2;
						this.initTabClans();
					}
				}
				if (this.cSelected == 1)
				{
					Service.gI().clanMessage(1, null, -1);
				}
				if (this.cSelected == 2)
				{
					this.member = null;
					this.isSearchClan = false;
					this.isViewMember = true;
					this.isMessage = false;
					this.currentListLength = this.myMember.size() + 2;
					this.initTabClans();
					this.getCurrClanOtion();
				}
			}
			else if (this.isViewMember)
			{
				if (this.cSelected == 0)
				{
					this.isSearchClan = false;
					this.isViewMember = false;
					this.isMessage = true;
					this.currentListLength = ClanMessage.vMessage.size() + 2;
					this.initTabClans();
				}
				if (this.cSelected == 1)
				{
					if (this.myMember.size() > 1)
					{
						Service.gI().leaveClan();
					}
					else
					{
						this.chagenSlogan();
					}
				}
				if (this.cSelected == 2)
				{
					if (this.myMember.size() > 1)
					{
						this.chagenSlogan();
					}
					else
					{
						Service.gI().getClan(3, -1, null);
					}
				}
				if (this.cSelected == 3)
				{
					Service.gI().getClan(3, -1, null);
				}
			}
		}
		else if (this.selected == 1)
		{
			if (this.isSearchClan)
			{
				Service.gI().searchClan(string.Empty);
			}
		}
		else if (this.isSearchClan)
		{
			this.currClan = this.getCurrClan();
			if (this.currClan != null)
			{
				MyVector myVector3 = new MyVector();
				myVector3.addElement(new Command(mResources.view_clan_member, this, 4001, this.currClan));
				GameCanvas.menu.startAt(myVector3, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
				this.addClanDetail(this.getCurrClan());
			}
		}
		else if (this.isViewMember)
		{
			Res.outz("TOI DAY 1");
			this.currMem = this.getCurrMember();
			if (this.currMem != null)
			{
				MyVector myVector4 = new MyVector();
				Res.outz("TOI DAY 2");
				if (this.member != null)
				{
					myVector4.addElement(new Command(mResources.CLOSE, this, 8000, null));
					Res.outz("TOI DAY 3");
				}
				else if (this.myMember != null)
				{
					Res.outz("TOI DAY 4");
					Res.outz("my role= " + global::Char.myCharz().role);
					if (global::Char.myCharz().charID == this.currMem.ID || (int)global::Char.myCharz().role == 2)
					{
						myVector4.addElement(new Command(mResources.CLOSE, this, 8000, this.currMem));
					}
					if ((int)global::Char.myCharz().role < 2 && global::Char.myCharz().charID != this.currMem.ID)
					{
						Res.outz("TOI DAY");
						if ((int)this.currMem.role == 0 || (int)this.currMem.role == 1)
						{
							myVector4.addElement(new Command(mResources.CLOSE, this, 8000, this.currMem));
						}
						if ((int)this.currMem.role == 2)
						{
							myVector4.addElement(new Command(mResources.create_clan_co_leader, this, 5002, this.currMem));
						}
						if ((int)global::Char.myCharz().role == 0)
						{
							myVector4.addElement(new Command(mResources.create_clan_leader, this, 5001, this.currMem));
							if ((int)this.currMem.role == 1)
							{
								myVector4.addElement(new Command(mResources.disable_clan_mastership, this, 5003, this.currMem));
							}
						}
					}
					if ((int)global::Char.myCharz().role < (int)this.currMem.role)
					{
						myVector4.addElement(new Command(mResources.kick_clan_mem, this, 5004, this.currMem));
					}
				}
				GameCanvas.menu.startAt(myVector4, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
				this.addClanMemberDetail(this.currMem);
			}
		}
		else if (this.isMessage)
		{
			this.currMess = this.getCurrMessage();
			if (this.currMess != null)
			{
				if (this.currMess.type == 0)
				{
					MyVector myVector5 = new MyVector();
					myVector5.addElement(new Command(mResources.CLOSE, this, 8000, this.currMess));
					GameCanvas.menu.startAt(myVector5, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
					this.addMessageDetail(this.currMess);
				}
				else if (this.currMess.type == 1)
				{
					if (this.currMess.playerId != global::Char.myCharz().charID && this.cSelected != -1)
					{
						Service.gI().clanDonate(this.currMess.id);
					}
				}
				else if (this.currMess.type == 2 && this.currMess.option != null)
				{
					if (this.cSelected == 0)
					{
						Service.gI().joinClan(this.currMess.id, 1);
					}
					else if (this.cSelected == 1)
					{
						Service.gI().joinClan(this.currMess.id, 0);
					}
				}
			}
		}
		if (GameCanvas.isTouch)
		{
			this.cSelected = -1;
			this.selected = -1;
		}
	}

	// Token: 0x0600089B RID: 2203 RVA: 0x0007F020 File Offset: 0x0007D220
	private void doFireMain()
	{
		if (this.currentTabIndex == 0)
		{
			this.setTypeMap();
		}
		if (this.currentTabIndex == 1)
		{
			this.doFireInventory();
		}
		if (this.currentTabIndex == 2)
		{
			this.doFireSkill();
		}
		if (this.currentTabIndex == 3)
		{
			if (this.mainTabName.Length == 4)
			{
				this.doFireTool();
			}
			else
			{
				this.doFireClanOption();
			}
		}
		if (this.currentTabIndex == 4)
		{
			this.doFireTool();
		}
	}

	// Token: 0x0600089C RID: 2204 RVA: 0x0007F0A0 File Offset: 0x0007D2A0
	private void doFireSkill()
	{
		if (this.selected < 0)
		{
			return;
		}
		if (global::Char.myCharz().statusMe == 14)
		{
			GameCanvas.startOKDlg(mResources.can_not_do_when_die);
			return;
		}
		if (this.selected != 0 && this.selected != 1 && this.selected != 2 && this.selected != 3 && this.selected != 4 && this.selected != 5)
		{
			int num = this.selected - 6;
			SkillTemplate skillTemplate = global::Char.myCharz().nClass.skillTemplates[num];
			Skill skill = global::Char.myCharz().getSkill(skillTemplate);
			Skill skill2 = null;
			MyVector myVector = new MyVector();
			if (skill != null)
			{
				if (skill.point == skillTemplate.maxPoint)
				{
					myVector.addElement(new Command(mResources.make_shortcut, this, 9003, skill.template));
					myVector.addElement(new Command(mResources.CLOSE, 2));
				}
				else
				{
					skill2 = skillTemplate.skills[skill.point];
					myVector.addElement(new Command(mResources.UPGRADE, this, 9002, skill2));
					myVector.addElement(new Command(mResources.make_shortcut, this, 9003, skill.template));
				}
			}
			else
			{
				skill2 = skillTemplate.skills[0];
				myVector.addElement(new Command(mResources.learn, this, 9004, skill2));
			}
			GameCanvas.menu.startAt(myVector, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
			this.addSkillDetail(skillTemplate, skill, skill2);
			return;
		}
		long cTiemNang = global::Char.myCharz().cTiemNang;
		int cHPGoc = global::Char.myCharz().cHPGoc;
		int cMPGoc = global::Char.myCharz().cMPGoc;
		int cDamGoc = global::Char.myCharz().cDamGoc;
		int cDefGoc = global::Char.myCharz().cDefGoc;
		int cCriticalGoc = global::Char.myCharz().cCriticalGoc;
		int num2 = 1000;
		if (this.selected == 0)
		{
			if (cTiemNang < (long)(global::Char.myCharz().cHPGoc + num2))
			{
				GameCanvas.startOKDlg(string.Concat(new object[]
				{
					mResources.not_enough_potential_point1,
					global::Char.myCharz().cTiemNang,
					mResources.not_enough_potential_point2,
					global::Char.myCharz().cHPGoc + num2
				}), false);
				return;
			}
			if (cTiemNang > (long)cHPGoc && cTiemNang < (long)(10 * (2 * (cHPGoc + num2) + 180) / 2))
			{
				GameCanvas.startYesNoDlg(string.Concat(new object[]
				{
					mResources.use_potential_point_for1,
					cHPGoc + num2,
					mResources.use_potential_point_for2,
					global::Char.myCharz().hpFrom1000TiemNang,
					mResources.for_HP
				}), new Command(mResources.increase_upper, this, 9000, null), new Command(mResources.CANCEL, this, 4007, null));
				return;
			}
			if (cTiemNang >= (long)(10 * (2 * (cHPGoc + num2) + 180) / 2) && cTiemNang < (long)(100 * (2 * (cHPGoc + num2) + 1980) / 2))
			{
				MyVector myVector2 = new MyVector();
				myVector2.addElement(new Command(string.Concat(new object[]
				{
					mResources.increase_upper,
					"\n",
					global::Char.myCharz().hpFrom1000TiemNang,
					mResources.HP,
					"\n-",
					cHPGoc + num2
				}), this, 9000, null));
				myVector2.addElement(new Command(string.Concat(new object[]
				{
					mResources.increase_upper,
					"\n",
					10 * (int)global::Char.myCharz().hpFrom1000TiemNang,
					mResources.HP,
					"\n-",
					10 * (2 * (cHPGoc + num2) + 180) / 2
				}), this, 9006, null));
				GameCanvas.menu.startAt(myVector2, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
				this.addSkillDetail2(this.selected);
			}
			if (cTiemNang >= (long)(100 * (2 * (cHPGoc + num2) + 1980) / 2))
			{
				MyVector myVector3 = new MyVector();
				myVector3.addElement(new Command(string.Concat(new object[]
				{
					mResources.increase_upper,
					"\n",
					global::Char.myCharz().hpFrom1000TiemNang,
					mResources.HP,
					"\n-",
					cHPGoc + num2
				}), this, 9000, null));
				myVector3.addElement(new Command(string.Concat(new object[]
				{
					mResources.increase_upper,
					"\n",
					10 * (int)global::Char.myCharz().hpFrom1000TiemNang,
					mResources.HP,
					"\n-",
					10 * (2 * (cHPGoc + num2) + 180) / 2
				}), this, 9006, null));
				myVector3.addElement(new Command(string.Concat(new object[]
				{
					mResources.increase_upper,
					"\n",
					100 * (int)global::Char.myCharz().hpFrom1000TiemNang,
					mResources.HP,
					"\n-",
					100 * (2 * (cHPGoc + num2) + 1980) / 2
				}), this, 9007, null));
				GameCanvas.menu.startAt(myVector3, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
				this.addSkillDetail2(this.selected);
			}
		}
		if (this.selected == 1)
		{
			if (global::Char.myCharz().cTiemNang < (long)(global::Char.myCharz().cMPGoc + num2))
			{
				GameCanvas.startOKDlg(string.Concat(new object[]
				{
					mResources.not_enough_potential_point1,
					global::Char.myCharz().cTiemNang,
					mResources.not_enough_potential_point2,
					global::Char.myCharz().cMPGoc + num2
				}), false);
				return;
			}
			if (cTiemNang > (long)cMPGoc && cTiemNang < (long)(10 * (2 * (cMPGoc + num2) + 180) / 2))
			{
				GameCanvas.startYesNoDlg(string.Concat(new object[]
				{
					mResources.use_potential_point_for1,
					cMPGoc + num2,
					mResources.use_potential_point_for2,
					global::Char.myCharz().mpFrom1000TiemNang,
					mResources.for_KI
				}), new Command(mResources.increase_upper, this, 9000, null), new Command(mResources.CANCEL, this, 4007, null));
				return;
			}
			if (cTiemNang >= (long)(10 * (2 * (cMPGoc + num2) + 180) / 2) && cTiemNang < (long)(100 * (2 * (cMPGoc + num2) + 1980) / 2))
			{
				MyVector myVector4 = new MyVector();
				myVector4.addElement(new Command(string.Concat(new object[]
				{
					mResources.increase_upper,
					"\n",
					global::Char.myCharz().mpFrom1000TiemNang,
					mResources.KI,
					"\n-",
					cHPGoc + num2
				}), this, 9000, null));
				myVector4.addElement(new Command(string.Concat(new object[]
				{
					mResources.increase_upper,
					"\n",
					10 * (int)global::Char.myCharz().mpFrom1000TiemNang,
					mResources.KI,
					"\n-",
					10 * (2 * (cHPGoc + num2) + 180) / 2
				}), this, 9006, null));
				GameCanvas.menu.startAt(myVector4, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
				this.addSkillDetail2(this.selected);
			}
			if (cTiemNang >= (long)(100 * (2 * (cMPGoc + num2) + 1980) / 2))
			{
				MyVector myVector5 = new MyVector();
				myVector5.addElement(new Command(string.Concat(new object[]
				{
					mResources.increase_upper,
					"\n",
					global::Char.myCharz().mpFrom1000TiemNang,
					mResources.KI,
					"\n-",
					cMPGoc + num2
				}), this, 9000, null));
				myVector5.addElement(new Command(string.Concat(new object[]
				{
					mResources.increase_upper,
					"\n",
					10 * (int)global::Char.myCharz().mpFrom1000TiemNang,
					mResources.KI,
					"\n-",
					10 * (2 * (cMPGoc + num2) + 180) / 2
				}), this, 9006, null));
				myVector5.addElement(new Command(string.Concat(new object[]
				{
					mResources.increase_upper,
					"\n",
					100 * (int)global::Char.myCharz().mpFrom1000TiemNang,
					mResources.KI,
					"\n-",
					100 * (2 * (cMPGoc + num2) + 1980) / 2
				}), this, 9007, null));
				GameCanvas.menu.startAt(myVector5, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
				this.addSkillDetail2(this.selected);
			}
		}
		if (this.selected == 2)
		{
			if (global::Char.myCharz().cTiemNang < (long)(global::Char.myCharz().cDamGoc * (int)global::Char.myCharz().expForOneAdd))
			{
				GameCanvas.startOKDlg(string.Concat(new object[]
				{
					mResources.not_enough_potential_point1,
					global::Char.myCharz().cTiemNang,
					mResources.not_enough_potential_point2,
					cDamGoc * 100
				}), false);
				return;
			}
			if (cTiemNang > (long)cDamGoc && cTiemNang < (long)(10 * (2 * cDamGoc + 9) / 2 * (int)global::Char.myCharz().expForOneAdd))
			{
				GameCanvas.startYesNoDlg(string.Concat(new object[]
				{
					mResources.use_potential_point_for1,
					cDamGoc * 100,
					mResources.use_potential_point_for2,
					global::Char.myCharz().damFrom1000TiemNang,
					mResources.for_hit_point
				}), new Command(mResources.increase_upper, this, 9000, null), new Command(mResources.CANCEL, this, 4007, null));
				return;
			}
			if (cTiemNang >= (long)(10 * (2 * cDamGoc + 9) / 2 * (int)global::Char.myCharz().expForOneAdd) && cTiemNang < (long)(100 * (2 * cDamGoc + 99) / 2 * (int)global::Char.myCharz().expForOneAdd))
			{
				MyVector myVector6 = new MyVector();
				myVector6.addElement(new Command(string.Concat(new object[]
				{
					mResources.increase_upper,
					"\n",
					global::Char.myCharz().damFrom1000TiemNang,
					"\n",
					mResources.hit_point,
					"\n-",
					cDamGoc * 100
				}), this, 9000, null));
				myVector6.addElement(new Command(string.Concat(new object[]
				{
					mResources.increase_upper,
					"\n",
					10 * (int)global::Char.myCharz().damFrom1000TiemNang,
					"\n",
					mResources.hit_point,
					"\n-",
					10 * (2 * cDamGoc + 9) / 2 * (int)global::Char.myCharz().expForOneAdd
				}), this, 9006, null));
				GameCanvas.menu.startAt(myVector6, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
				this.addSkillDetail2(this.selected);
			}
			if (cTiemNang >= (long)(100 * (2 * cDamGoc + 99) / 2 * (int)global::Char.myCharz().expForOneAdd))
			{
				MyVector myVector7 = new MyVector();
				myVector7.addElement(new Command(string.Concat(new object[]
				{
					mResources.increase_upper,
					"\n",
					global::Char.myCharz().damFrom1000TiemNang,
					"\n",
					mResources.hit_point,
					"\n-",
					cDamGoc * 100
				}), this, 9000, null));
				myVector7.addElement(new Command(string.Concat(new object[]
				{
					mResources.increase_upper,
					"\n",
					10 * (int)global::Char.myCharz().damFrom1000TiemNang,
					"\n",
					mResources.hit_point,
					"\n-",
					10 * (2 * cDamGoc + 9) / 2 * (int)global::Char.myCharz().expForOneAdd
				}), this, 9006, null));
				myVector7.addElement(new Command(string.Concat(new object[]
				{
					mResources.increase_upper,
					"\n",
					100 * (int)global::Char.myCharz().damFrom1000TiemNang,
					"\n",
					mResources.hit_point,
					"\n-",
					100 * (2 * cDamGoc + 99) / 2 * (int)global::Char.myCharz().expForOneAdd
				}), this, 9007, null));
				GameCanvas.menu.startAt(myVector7, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
				this.addSkillDetail2(this.selected);
			}
		}
		if (this.selected == 3)
		{
			if (global::Char.myCharz().cTiemNang < (long)(50000 + global::Char.myCharz().cDefGoc * 1000))
			{
				GameCanvas.startOKDlg(mResources.not_enough_potential_point1 + NinjaUtil.getMoneys(global::Char.myCharz().cTiemNang) + mResources.not_enough_potential_point2 + NinjaUtil.getMoneys((long)(50000 + global::Char.myCharz().cDefGoc * 1000)), false);
				return;
			}
			int num3 = 2 * (cDefGoc + 5) / 2 * 100000;
			GameCanvas.startYesNoDlg(string.Concat(new object[]
			{
				mResources.use_potential_point_for1,
				NinjaUtil.getMoneys((long)num3),
				mResources.use_potential_point_for2,
				global::Char.myCharz().defFrom1000TiemNang,
				mResources.for_armor
			}), new Command(mResources.increase_upper, this, 9000, null), new Command(mResources.CANCEL, this, 4007, null));
			return;
		}
		else
		{
			if (this.selected != 4)
			{
				if (this.selected == 5)
				{
					Service.gI().speacialSkill(0);
				}
				return;
			}
			long num4 = 50000000L;
			for (int i = 0; i < global::Char.myCharz().cCriticalGoc; i++)
			{
				num4 *= 5L;
			}
			if (global::Char.myCharz().cTiemNang < num4)
			{
				GameCanvas.startOKDlg(mResources.not_enough_potential_point1 + NinjaUtil.getMoneys(global::Char.myCharz().cTiemNang) + mResources.not_enough_potential_point2 + NinjaUtil.getMoneys(num4), false);
				return;
			}
			GameCanvas.startYesNoDlg(string.Concat(new object[]
			{
				mResources.use_potential_point_for1,
				NinjaUtil.getMoneys(num4),
				mResources.use_potential_point_for2,
				global::Char.myCharz().criticalFrom1000Tiemnang,
				mResources.for_crit
			}), new Command(mResources.increase_upper, this, 9000, null), new Command(mResources.CANCEL, this, 4007, null));
			return;
		}
	}

	// Token: 0x0600089D RID: 2205 RVA: 0x00080010 File Offset: 0x0007E210
	private void addLogMessage(InfoItem info)
	{
		string text = "|0|1|" + info.charInfo.cName;
		text += "\n";
		text += "\n--";
		text = text + "\n|5|" + Res.split(info.s, "|", 0)[2];
		this.cp = new ChatPopup();
		this.popUpDetailInit(this.cp, text);
		this.charInfo = info.charInfo;
		this.currItem = null;
	}

	// Token: 0x0600089E RID: 2206 RVA: 0x00080098 File Offset: 0x0007E298
	private void addSkillDetail2(int type)
	{
		string text = string.Empty;
		int num = 0;
		if (this.selected == 0)
		{
			num = global::Char.myCharz().cHPGoc + 1000;
		}
		if (this.selected == 1)
		{
			num = global::Char.myCharz().cMPGoc + 1000;
		}
		if (this.selected == 2)
		{
			num = global::Char.myCharz().cDamGoc * (int)global::Char.myCharz().expForOneAdd;
		}
		string text2 = text;
		text = string.Concat(new object[]
		{
			text2,
			"|5|2|",
			mResources.USE,
			" ",
			num,
			" ",
			mResources.potential
		});
		if (type == 0)
		{
			text = text + "\n|5|2|" + mResources.to_gain_20hp;
		}
		if (type == 1)
		{
			text = text + "\n|5|2|" + mResources.to_gain_20mp;
		}
		if (type == 2)
		{
			text = text + "\n|5|2|" + mResources.to_gain_1pow;
		}
		this.currItem = null;
		this.partID = null;
		this.charInfo = null;
		this.idIcon = -1;
		this.cp = new ChatPopup();
		this.popUpDetailInit(this.cp, text);
	}

	// Token: 0x0600089F RID: 2207 RVA: 0x00003984 File Offset: 0x00001B84
	private void doFireClanIcon()
	{
	}

	// Token: 0x060008A0 RID: 2208 RVA: 0x000801C8 File Offset: 0x0007E3C8
	private void doFireMap()
	{
		if (Panel.imgMap != null)
		{
			Panel.imgMap.texture = null;
			Panel.imgMap = null;
		}
		TileMap.lastPlanetId = -1;
		mSystem.gcc();
		SmallImage.loadBigRMS();
		this.setTypeMain();
		this.cmx = (this.cmtoX = 0);
	}

	// Token: 0x060008A1 RID: 2209 RVA: 0x0000762B File Offset: 0x0000582B
	private void doFireZone()
	{
		if (this.selected == -1)
		{
			return;
		}
		Res.outz("FIRE ZONE");
		this.isChangeZone = true;
		GameCanvas.panel.hide();
	}

	// Token: 0x060008A2 RID: 2210 RVA: 0x00080218 File Offset: 0x0007E418
	public void updateRequest(int recieve, int maxCap)
	{
		this.cp.says[this.cp.says.Length - 1] = string.Concat(new object[]
		{
			mResources.received,
			" ",
			recieve,
			"/",
			maxCap
		});
	}

	// Token: 0x060008A3 RID: 2211 RVA: 0x00080278 File Offset: 0x0007E478
	private void doFireBox()
	{
		if (this.selected < 0)
		{
			return;
		}
		this.currItem = null;
		MyVector myVector = new MyVector();
		if (this.currentTabIndex == 0 && !this.Equals(GameCanvas.panel2))
		{
			Item item = global::Char.myCharz().arrItemBox[this.selected];
			if (item != null)
			{
				if (item.isTypeBody())
				{
					if (global::Char.myCharz().arrItemBody[item.itemOption[0].optionTemplate.type] != null)
					{
						myVector.addElement(new Command(mResources.GETOUT, this, 1000, item));
					}
					else
					{
						myVector.addElement(new Command(mResources.GETOUT, this, 1000, item));
					}
				}
				else if (this.isBoxClan)
				{
					myVector.addElement(new Command(mResources.GETOUT, this, 1000, item));
					myVector.addElement(new Command(mResources.USE, this, 2010, item));
				}
				else
				{
					myVector.addElement(new Command(mResources.GETOUT, this, 1000, item));
					myVector.addElement(new Command(mResources.USE, this, 2010, item));
				}
				this.currItem = item;
			}
		}
		if (this.currentTabIndex == 1 || this.Equals(GameCanvas.panel2))
		{
			Item[] arrItemBody = global::Char.myCharz().arrItemBody;
			if (this.selected >= arrItemBody.Length)
			{
				sbyte b = (sbyte)(this.selected - arrItemBody.Length);
				Item item2 = global::Char.myCharz().arrItemBag[(int)b];
				if (item2 != null)
				{
					myVector.addElement(new Command(mResources.move_to_chest, this, 1001, item2));
					if (item2.isTypeBody())
					{
						myVector.addElement(new Command(mResources.USE, this, 2000, item2));
					}
					else
					{
						myVector.addElement(new Command(mResources.USE, this, 2001, item2));
					}
					this.currItem = item2;
				}
			}
			else
			{
				Item item3 = global::Char.myCharz().arrItemBody[this.selected];
				if (item3 != null)
				{
					myVector.addElement(new Command(mResources.move_to_chest2, this, 1002, item3));
					this.currItem = item3;
				}
			}
		}
		if (this.currItem != null)
		{
			global::Char.myCharz().setPartTemp(this.currItem.headTemp, this.currItem.bodyTemp, this.currItem.legTemp, this.currItem.bagTemp);
			if (this.isBoxClan)
			{
				myVector.addElement(new Command(mResources.MOVEOUT, this, 2011, this.currItem));
			}
			else
			{
				myVector.addElement(new Command(mResources.MOVEOUT, this, 2003, this.currItem));
			}
			GameCanvas.menu.startAt(myVector, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
			this.addItemDetail(this.currItem);
		}
		else
		{
			this.cp = null;
		}
	}

	// Token: 0x060008A4 RID: 2212 RVA: 0x00080578 File Offset: 0x0007E778
	public void itemRequest(sbyte itemAction, string info, sbyte where, sbyte index)
	{
		GameCanvas.endDlg();
		ItemObject itemObject = new ItemObject();
		itemObject.type = (int)itemAction;
		itemObject.id = (int)index;
		itemObject.where = (int)where;
		GameCanvas.startYesNoDlg(info, new Command(mResources.YES, this, 2004, itemObject), new Command(mResources.NO, this, 4005, null));
	}

	// Token: 0x060008A5 RID: 2213 RVA: 0x000805D4 File Offset: 0x0007E7D4
	public void saleRequest(sbyte type, string info, short id)
	{
		ItemObject itemObject = new ItemObject();
		itemObject.type = (int)type;
		itemObject.id = (int)id;
		GameCanvas.startYesNoDlg(info, new Command(mResources.YES, this, 3003, itemObject), new Command(mResources.NO, this, 4005, null));
	}

	// Token: 0x060008A6 RID: 2214 RVA: 0x00080620 File Offset: 0x0007E820
	public void perform(int idAction, object p)
	{
		if (idAction == 9999)
		{
			TopInfo topInfo = (TopInfo)p;
			Service.gI().sendThachDau(topInfo.pId);
		}
		if (idAction == 170391)
		{
			Rms.clearAll();
			if (mGraphics.zoomLevel > 1)
			{
				Rms.saveRMSInt("levelScreenKN", 1);
			}
			else
			{
				Rms.saveRMSInt("levelScreenKN", 0);
			}
			GameMidlet.instance.exit();
		}
		if (idAction == 6001)
		{
			Item item = (Item)p;
			item.isSelect = false;
			GameCanvas.panel.vItemCombine.removeElement(item);
			if (GameCanvas.panel.currentTabIndex == 0)
			{
				GameCanvas.panel.setTabCombine();
			}
		}
		if (idAction == 6000)
		{
			Item item2 = (Item)p;
			for (int i = 0; i < GameCanvas.panel.vItemCombine.size(); i++)
			{
				Item item3 = (Item)GameCanvas.panel.vItemCombine.elementAt(i);
				if (item3.template.id == item2.template.id)
				{
					GameCanvas.startOKDlg(mResources.already_has_item);
					return;
				}
			}
			item2.isSelect = true;
			GameCanvas.panel.vItemCombine.addElement(item2);
			if (GameCanvas.panel.currentTabIndex == 0)
			{
				GameCanvas.panel.setTabCombine();
			}
		}
		if (idAction == 7000)
		{
			if (this.isLock)
			{
				GameCanvas.startOKDlg(mResources.unlock_item_to_trade);
				return;
			}
			Item item4 = (Item)p;
			for (int j = 0; j < GameCanvas.panel.vMyGD.size(); j++)
			{
				Item item5 = (Item)GameCanvas.panel.vMyGD.elementAt(j);
				if (item5.indexUI == item4.indexUI)
				{
					GameCanvas.startOKDlg(mResources.already_has_item);
					return;
				}
			}
			if (item4.quantity > 1)
			{
				this.putQuantily();
				return;
			}
			item4.isSelect = true;
			Item item6 = new Item();
			item6.template = item4.template;
			item6.itemOption = item4.itemOption;
			item6.indexUI = item4.indexUI;
			GameCanvas.panel.vMyGD.addElement(item6);
			Service.gI().giaodich(2, -1, (sbyte)item6.indexUI, item6.quantity);
		}
		if (idAction == 7001)
		{
			Item item7 = (Item)p;
			item7.isSelect = false;
			GameCanvas.panel.vMyGD.removeElement(item7);
			if (GameCanvas.panel.currentTabIndex == 1)
			{
				GameCanvas.panel.setTabGiaoDich(true);
			}
			Service.gI().giaodich(4, -1, (sbyte)item7.indexUI, -1);
		}
		if (idAction == 7002)
		{
			this.isAccept = true;
			GameCanvas.endDlg();
			Service.gI().giaodich(7, -1, -1, -1);
			this.hide();
		}
		if (idAction == 8003)
		{
			InfoItem infoItem = (InfoItem)p;
			Service.gI().friend(1, infoItem.charInfo.charID);
			if (this.type == 8)
			{
			}
		}
		if (idAction == 8002)
		{
			InfoItem infoItem2 = (InfoItem)p;
			Service.gI().friend(2, infoItem2.charInfo.charID);
		}
		if (idAction == 8004)
		{
			InfoItem infoItem3 = (InfoItem)p;
			Service.gI().gotoPlayer(infoItem3.charInfo.charID);
		}
		if (idAction == 8001)
		{
			Res.outz("chat player");
			InfoItem infoItem4 = (InfoItem)p;
			if (this.chatTField == null)
			{
				this.chatTField = new ChatTextField();
				this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
				this.chatTField.initChatTextField();
				this.chatTField.parentScreen = GameCanvas.panel;
			}
			this.chatTField.strChat = mResources.chat_player;
			this.chatTField.tfChat.name = mResources.chat_with + " " + infoItem4.charInfo.cName;
			this.chatTField.to = string.Empty;
			this.chatTField.isShow = true;
			this.chatTField.tfChat.isFocus = true;
			this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
			if (Main.isWindowsPhone)
			{
				this.chatTField.tfChat.strInfo = this.chatTField.strChat;
			}
			if (!Main.isPC)
			{
				this.chatTField.startChat2(this, string.Empty);
			}
		}
		if (idAction == 1000)
		{
			Service.gI().getItem(Panel.BOX_BAG, (sbyte)this.selected);
		}
		if (idAction == 1001)
		{
			Item[] arrItemBody = global::Char.myCharz().arrItemBody;
			sbyte id = (sbyte)(this.selected - arrItemBody.Length);
			Service.gI().getItem(Panel.BAG_BOX, id);
		}
		if (idAction == 1003)
		{
			this.hide();
		}
		if (idAction == 1002)
		{
			Service.gI().getItem(Panel.BODY_BOX, (sbyte)this.selected);
		}
		if (idAction == 2011)
		{
			Service.gI().useItem(1, 2, (sbyte)this.selected, -1);
		}
		if (idAction == 2010)
		{
			Service.gI().useItem(0, 2, (sbyte)this.selected, -1);
			Item item8 = (Item)p;
			if (item8 != null && (item8.template.id == 193 || item8.template.id == 194))
			{
				GameCanvas.panel.hide();
			}
		}
		if (idAction == 2000)
		{
			Item[] arrItemBody2 = global::Char.myCharz().arrItemBody;
			sbyte id2 = (sbyte)(this.selected - arrItemBody2.Length);
			Service.gI().getItem(Panel.BAG_BODY, id2);
		}
		if (idAction == 2001)
		{
			Res.outz("use item");
			Item item9 = (Item)p;
			bool flag = this.selected < global::Char.myCharz().arrItemBody.Length;
			sbyte b = 0;
			if (!flag)
			{
				b = (sbyte)(this.selected - global::Char.myCharz().arrItemBody.Length);
			}
			Service.gI().useItem(0, (!flag) ? 1 : 0, (sbyte)((!flag) ? ((int)b) : this.selected), -1);
			if (item9.template.id == 193 || item9.template.id == 194)
			{
				GameCanvas.panel.hide();
			}
		}
		if (idAction == 2005)
		{
			Item[] arrItemBody3 = global::Char.myCharz().arrItemBody;
			sbyte id3 = (sbyte)(this.selected - arrItemBody3.Length);
			Service.gI().getItem(Panel.BAG_PET, id3);
		}
		if (idAction == 2006)
		{
			Item[] arrItemBody4 = global::Char.myPetz().arrItemBody;
			sbyte id4 = (sbyte)this.selected;
			Service.gI().getItem(Panel.PET_BAG, id4);
		}
		if (idAction == 2002)
		{
			Service.gI().getItem(Panel.BODY_BAG, (sbyte)this.selected);
		}
		if (idAction == 2003)
		{
			Res.outz("remove item");
			bool flag2 = this.selected < global::Char.myCharz().arrItemBody.Length;
			sbyte b2 = 0;
			if (!flag2)
			{
				b2 = (sbyte)(this.selected - global::Char.myCharz().arrItemBody.Length);
			}
			Service.gI().useItem(1, (!flag2) ? 1 : 0, (sbyte)((!flag2) ? ((int)b2) : this.selected), -1);
		}
		if (idAction == 2004)
		{
			GameCanvas.endDlg();
			ItemObject itemObject = (ItemObject)p;
			sbyte where = (sbyte)itemObject.where;
			sbyte index = (sbyte)itemObject.id;
			Service.gI().useItem((itemObject.type != 0) ? 2 : 3, where, index, -1);
		}
		if (idAction == 30001)
		{
			Res.outz("nhan do");
			Service.gI().buyItem(0, this.selected, 0);
		}
		if (idAction == 30002)
		{
			Res.outz("xoa do");
			Service.gI().buyItem(1, this.selected, 0);
		}
		if (idAction == 30003)
		{
			Res.outz("nhan tat");
			Service.gI().buyItem(2, this.selected, 0);
		}
		if (idAction == 3000)
		{
			Res.outz("mua do");
			Item item10 = (Item)p;
			Service.gI().buyItem(0, (int)item10.template.id, 0);
		}
		if (idAction == 3001)
		{
			Item item11 = (Item)p;
			GameCanvas.msgdlg.pleasewait();
			Service.gI().buyItem(1, (int)item11.template.id, 0);
		}
		if (idAction == 3002)
		{
			GameCanvas.endDlg();
			Item item12 = (Item)p;
			Service.gI().saleItem(0, (this.selected > 6) ? 1 : 0, (short)((this.selected >= 7) ? (this.selected - 6 - 1) : this.selected));
		}
		if (idAction == 3003)
		{
			GameCanvas.endDlg();
			ItemObject itemObject2 = (ItemObject)p;
			Service.gI().saleItem(1, (sbyte)itemObject2.type, (short)itemObject2.id);
		}
		if (idAction == 3004)
		{
			Item item13 = (Item)p;
			Service.gI().buyItem(3, (int)item13.template.id, 0);
		}
		if (idAction == 3005)
		{
			Res.outz("mua do");
			Item item14 = (Item)p;
			Service.gI().buyItem(3, (int)item14.template.id, 0);
		}
		if (idAction == 4000)
		{
			Clan clan = (Clan)p;
			if (clan != null)
			{
				GameCanvas.endDlg();
				Service.gI().clanMessage(2, null, clan.ID);
			}
		}
		if (idAction == 4001)
		{
			Clan clan2 = (Clan)p;
			if (clan2 != null)
			{
				InfoDlg.showWait();
				this.clanReport = mResources.PLEASEWAIT;
				Service.gI().clanMember(clan2.ID);
			}
		}
		if (idAction == 4005)
		{
			GameCanvas.endDlg();
		}
		if (idAction == 4007)
		{
			GameCanvas.endDlg();
		}
		if (idAction == 4006)
		{
			ClanMessage clanMessage = (ClanMessage)p;
			Service.gI().clanDonate(clanMessage.id);
		}
		if (idAction == 5001)
		{
			Member member = (Member)p;
			Service.gI().clanRemote(member.ID, 0);
		}
		if (idAction == 5002)
		{
			Member member2 = (Member)p;
			Service.gI().clanRemote(member2.ID, 1);
		}
		if (idAction == 5003)
		{
			Member member3 = (Member)p;
			Service.gI().clanRemote(member3.ID, 2);
		}
		if (idAction == 5004)
		{
			Member member4 = (Member)p;
			Service.gI().clanRemote(member4.ID, -1);
		}
		if (idAction == 9000)
		{
			Service.gI().upPotential(this.selected, 1);
			GameCanvas.endDlg();
			InfoDlg.showWait();
		}
		if (idAction == 9006)
		{
			Service.gI().upPotential(this.selected, 10);
			GameCanvas.endDlg();
			InfoDlg.showWait();
		}
		if (idAction == 9007)
		{
			Service.gI().upPotential(this.selected, 100);
			GameCanvas.endDlg();
			InfoDlg.showWait();
		}
		if (idAction == 9002)
		{
			Skill skill = (Skill)p;
			GameCanvas.startOKDlg(string.Concat(new object[]
			{
				mResources.can_buy_from_Uron1,
				skill.powRequire,
				mResources.can_buy_from_Uron2,
				skill.moreInfo,
				mResources.can_buy_from_Uron3
			}));
		}
		if (idAction == 9003)
		{
			if (GameCanvas.isTouch && !Main.isPC)
			{
				GameScr.gI().doSetOnScreenSkill((SkillTemplate)p);
			}
			else
			{
				GameScr.gI().doSetKeySkill((SkillTemplate)p);
			}
		}
		if (idAction == 9004)
		{
			Skill skill2 = (Skill)p;
			GameCanvas.startOKDlg(string.Concat(new object[]
			{
				mResources.can_buy_from_Uron1,
				skill2.powRequire,
				mResources.can_buy_from_Uron2,
				skill2.moreInfo,
				mResources.can_buy_from_Uron3
			}));
		}
		if (idAction == 10000)
		{
			InfoItem infoItem5 = (InfoItem)p;
			Service.gI().enemy(1, infoItem5.charInfo.charID);
			GameCanvas.panel.hideNow();
		}
		if (idAction == 10001)
		{
			InfoItem infoItem6 = (InfoItem)p;
			Service.gI().enemy(2, infoItem6.charInfo.charID);
			InfoDlg.showWait();
		}
		if (idAction == 10021)
		{
		}
		if (idAction == 10012)
		{
			if (this.chatTField == null)
			{
				this.chatTField = new ChatTextField();
				this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
				this.chatTField.initChatTextField();
				this.chatTField.parentScreen = ((GameCanvas.panel2 != null) ? GameCanvas.panel2 : GameCanvas.panel);
			}
			if (this.currItem.quantity == 1)
			{
				this.chatTField.strChat = mResources.kiguiXuchat;
				this.chatTField.tfChat.name = mResources.input_money;
			}
			else
			{
				this.chatTField.strChat = mResources.input_quantity + " ";
				this.chatTField.tfChat.name = mResources.input_quantity;
			}
			this.chatTField.tfChat.setMaxTextLenght(9);
			this.chatTField.to = string.Empty;
			this.chatTField.isShow = true;
			this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_NUMERIC);
			if (GameCanvas.isTouch)
			{
				this.chatTField.tfChat.doChangeToTextBox();
			}
			if (Main.isWindowsPhone)
			{
				this.chatTField.tfChat.strInfo = this.chatTField.strChat;
			}
			if (!Main.isPC)
			{
				this.chatTField.startChat2(this, string.Empty);
			}
		}
		if (idAction == 10013)
		{
			if (this.chatTField == null)
			{
				this.chatTField = new ChatTextField();
				this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
				this.chatTField.initChatTextField();
				this.chatTField.parentScreen = ((GameCanvas.panel2 != null) ? GameCanvas.panel2 : GameCanvas.panel);
			}
			if (this.currItem.quantity == 1)
			{
				this.chatTField.strChat = mResources.kiguiLuongchat;
				this.chatTField.tfChat.name = mResources.input_money;
			}
			else
			{
				this.chatTField.strChat = mResources.input_quantity + "  ";
				this.chatTField.tfChat.name = mResources.input_quantity;
			}
			this.chatTField.to = string.Empty;
			this.chatTField.isShow = true;
			this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_NUMERIC);
			if (GameCanvas.isTouch)
			{
				this.chatTField.tfChat.doChangeToTextBox();
			}
			if (Main.isWindowsPhone)
			{
				this.chatTField.tfChat.strInfo = this.chatTField.strChat;
			}
			if (!Main.isPC)
			{
				this.chatTField.startChat2(this, string.Empty);
			}
		}
		if (idAction == 10014)
		{
			Item item15 = (Item)p;
			Service.gI().kigui(1, item15.itemId, -1, -1, -1);
			InfoDlg.showWait();
		}
		if (idAction == 10015)
		{
			Item item16 = (Item)p;
			Service.gI().kigui(2, item16.itemId, -1, -1, -1);
			InfoDlg.showWait();
		}
		if (idAction == 10016)
		{
			Item item17 = (Item)p;
			Service.gI().kigui(3, item17.itemId, 0, item17.buyCoin, -1);
			InfoDlg.showWait();
		}
		if (idAction == 10017)
		{
			Item item18 = (Item)p;
			Service.gI().kigui(3, item18.itemId, 1, item18.buyGold, -1);
			InfoDlg.showWait();
		}
		if (idAction == 10018)
		{
			Item item19 = (Item)p;
			Service.gI().kigui(5, item19.itemId, -1, -1, -1);
			InfoDlg.showWait();
		}
		if (idAction == 10019)
		{
			Session_ME.gI().close();
			Rms.saveRMSString("acc", string.Empty);
			Rms.saveRMSString("pass", string.Empty);
			GameCanvas.loginScr.tfPass.setText(string.Empty);
			GameCanvas.loginScr.tfUser.setText(string.Empty);
			GameCanvas.loginScr.isLogin2 = false;
			GameCanvas.loginScr.switchToMe();
			GameCanvas.endDlg();
			this.hide();
		}
		if (idAction == 10020)
		{
			GameCanvas.endDlg();
		}
		if (idAction == 10030)
		{
			Service.gI().getFlag(1, (sbyte)this.selected);
			GameCanvas.panel.hideNow();
		}
		if (idAction == 10031)
		{
			Session_ME.gI().close();
		}
		if (idAction == 11000)
		{
			Service.gI().kigui(0, this.currItem.itemId, 1, this.currItem.buyRuby, 1);
			GameCanvas.endDlg();
		}
		if (idAction == 11001)
		{
			Service.gI().kigui(0, this.currItem.itemId, 1, this.currItem.buyRuby, (int)((byte)this.currItem.quantilyToBuy));
			GameCanvas.endDlg();
		}
		if (idAction == 11002)
		{
			this.chatTField.isShow = false;
			GameCanvas.endDlg();
		}
	}

	// Token: 0x060008A7 RID: 2215 RVA: 0x0008180C File Offset: 0x0007FA0C
	public void onChatFromMe(string text, string to)
	{
		if (this.chatTField.tfChat.getText() == null || this.chatTField.tfChat.getText().Equals(string.Empty) || text.Equals(string.Empty) || text == null)
		{
			this.chatTField.isShow = false;
			return;
		}
		if (this.chatTField.strChat.Equals(mResources.input_clan_name))
		{
			InfoDlg.showWait();
			this.chatTField.isShow = false;
			Service.gI().searchClan(text);
		}
		else if (this.chatTField.strChat.Equals(mResources.chat_clan))
		{
			InfoDlg.showWait();
			this.chatTField.isShow = false;
			Service.gI().clanMessage(0, text, -1);
		}
		else if (this.chatTField.strChat.Equals(mResources.input_clan_name_to_create))
		{
			if (this.chatTField.tfChat.getText() == string.Empty)
			{
				GameScr.info1.addInfo(mResources.clan_name_blank, 0);
			}
			else
			{
				if (this.tabIcon == null)
				{
					this.tabIcon = new TabClanIcon();
				}
				this.tabIcon.text = this.chatTField.tfChat.getText();
				this.tabIcon.show(false);
				this.chatTField.isShow = false;
			}
		}
		else if (this.chatTField.strChat.Equals(mResources.input_clan_slogan))
		{
			if (this.chatTField.tfChat.getText() == string.Empty)
			{
				GameScr.info1.addInfo(mResources.clan_slogan_blank, 0);
			}
			else
			{
				Service.gI().getClan(4, (sbyte)global::Char.myCharz().clan.imgID, this.chatTField.tfChat.getText());
				this.chatTField.isShow = false;
			}
		}
		else if (this.chatTField.strChat.Equals(mResources.input_Inventory_Pass))
		{
			try
			{
				int lockInventory = int.Parse(this.chatTField.tfChat.getText());
				if (this.chatTField.tfChat.getText().Length != 6 || this.chatTField.tfChat.getText().Equals(string.Empty))
				{
					GameCanvas.startOKDlg(mResources.input_Inventory_Pass_wrong);
				}
				else
				{
					Service.gI().setLockInventory(lockInventory);
					this.chatTField.isShow = false;
					this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
					this.hide();
				}
			}
			catch (Exception ex)
			{
				GameCanvas.startOKDlg(mResources.ALERT_PRIVATE_PASS_2);
			}
		}
		else if (this.chatTField.strChat.Equals(mResources.world_channel_5_luong))
		{
			if (this.chatTField.tfChat.getText().Equals(string.Empty))
			{
				return;
			}
			Service.gI().chatGlobal(this.chatTField.tfChat.getText());
			this.chatTField.isShow = false;
			this.hide();
		}
		else if (this.chatTField.strChat.Equals(mResources.chat_player))
		{
			this.chatTField.isShow = false;
			InfoItem infoItem = null;
			if (this.type == 8)
			{
				infoItem = (InfoItem)this.logChat.elementAt(this.currInfoItem);
			}
			else if (this.type == 11)
			{
				infoItem = (InfoItem)this.vFriend.elementAt(this.currInfoItem);
			}
			if (infoItem.charInfo.charID == global::Char.myCharz().charID)
			{
				return;
			}
			Service.gI().chatPlayer(text, infoItem.charInfo.charID);
		}
		else if (this.chatTField.strChat.Equals(mResources.input_quantity_to_trade))
		{
			int num = 0;
			try
			{
				num = int.Parse(this.chatTField.tfChat.getText());
			}
			catch (Exception ex2)
			{
				GameCanvas.startOKDlg(mResources.input_quantity_wrong);
				this.chatTField.isShow = false;
				this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
				return;
			}
			if (num <= 0 || num > this.currItem.quantity)
			{
				GameCanvas.startOKDlg(mResources.input_quantity_wrong);
				this.chatTField.isShow = false;
				this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
				return;
			}
			this.currItem.isSelect = true;
			Item item = new Item();
			item.template = this.currItem.template;
			item.quantity = num;
			item.indexUI = this.currItem.indexUI;
			item.itemOption = this.currItem.itemOption;
			GameCanvas.panel.vMyGD.addElement(item);
			Service.gI().giaodich(2, -1, (sbyte)item.indexUI, item.quantity);
			this.chatTField.isShow = false;
			this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
		}
		else if (this.chatTField.strChat == mResources.input_money_to_trade)
		{
			int num2 = 0;
			try
			{
				num2 = int.Parse(this.chatTField.tfChat.getText());
			}
			catch (Exception ex3)
			{
				GameCanvas.startOKDlg(mResources.input_money_wrong);
				this.chatTField.isShow = false;
				this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
				return;
			}
			if (num2 > global::Char.myCharz().xu)
			{
				GameCanvas.startOKDlg(mResources.not_enough_money);
				this.chatTField.isShow = false;
				this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
				return;
			}
			this.moneyGD = num2;
			Service.gI().giaodich(2, -1, -1, num2);
			this.chatTField.isShow = false;
			this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
		}
		else if (this.chatTField.strChat.Equals(mResources.kiguiXuchat))
		{
			Service.gI().kigui(0, this.currItem.itemId, 0, int.Parse(this.chatTField.tfChat.getText()), 1);
			this.chatTField.isShow = false;
		}
		else if (this.chatTField.strChat.Equals(mResources.kiguiXuchat + " "))
		{
			Service.gI().kigui(0, this.currItem.itemId, 0, int.Parse(this.chatTField.tfChat.getText()), (int)((sbyte)this.currItem.quantilyToBuy));
			this.chatTField.isShow = false;
		}
		else if (this.chatTField.strChat.Equals(mResources.kiguiLuongchat))
		{
			this.doNotiRuby(0);
			this.chatTField.isShow = false;
		}
		else if (this.chatTField.strChat.Equals(mResources.kiguiLuongchat + "  "))
		{
			this.doNotiRuby(1);
			this.chatTField.isShow = false;
		}
		else if (this.chatTField.strChat.Equals(mResources.input_quantity + " "))
		{
			this.currItem.quantilyToBuy = int.Parse(this.chatTField.tfChat.getText());
			if (this.currItem.quantilyToBuy > this.currItem.quantity)
			{
				GameCanvas.startOKDlg(mResources.input_quantity_wrong);
				return;
			}
			this.isKiguiXu = true;
			this.chatTField.isShow = false;
		}
		else if (this.chatTField.strChat.Equals(mResources.input_quantity + "  "))
		{
			this.currItem.quantilyToBuy = int.Parse(this.chatTField.tfChat.getText());
			if (this.currItem.quantilyToBuy > this.currItem.quantity)
			{
				GameCanvas.startOKDlg(mResources.input_quantity_wrong);
				return;
			}
			this.isKiguiLuong = true;
			this.chatTField.isShow = false;
		}
	}

	// Token: 0x060008A8 RID: 2216 RVA: 0x00007655 File Offset: 0x00005855
	public void onCancelChat()
	{
		this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
	}

	// Token: 0x060008A9 RID: 2217 RVA: 0x00082078 File Offset: 0x00080278
	public void setCombineEff(int type)
	{
		this.typeCombine = type;
		this.rS = 90;
		if (this.typeCombine == 0)
		{
			this.iDotS = 5;
			this.angleS = (this.angleO = 90);
			this.time = 2;
			for (int i = 0; i < this.vItemCombine.size(); i++)
			{
				Item item = (Item)this.vItemCombine.elementAt(i);
				if (item != null)
				{
					if ((int)item.template.type == 14)
					{
						this.iconID2 = item.template.iconID;
					}
					else
					{
						this.iconID1 = item.template.iconID;
					}
				}
			}
		}
		else if (this.typeCombine == 1)
		{
			this.iDotS = 2;
			this.angleS = (this.angleO = 0);
			this.time = 1;
			for (int j = 0; j < this.vItemCombine.size(); j++)
			{
				Item item2 = (Item)this.vItemCombine.elementAt(j);
				if (item2 != null)
				{
					if (j == 0)
					{
						this.iconID1 = item2.template.iconID;
					}
					else
					{
						this.iconID2 = item2.template.iconID;
					}
				}
			}
		}
		else if (this.typeCombine == 2)
		{
			this.iDotS = 7;
			this.angleS = (this.angleO = 25);
			this.time = 1;
			for (int k = 0; k < this.vItemCombine.size(); k++)
			{
				Item item3 = (Item)this.vItemCombine.elementAt(k);
				if (item3 != null)
				{
					this.iconID1 = item3.template.iconID;
				}
			}
		}
		else if (this.typeCombine == 3)
		{
			this.xS = GameCanvas.hw;
			this.yS = GameCanvas.hh;
			this.iDotS = 1;
			this.angleS = (this.angleO = 1);
			this.time = 4;
			for (int l = 0; l < this.vItemCombine.size(); l++)
			{
				Item item4 = (Item)this.vItemCombine.elementAt(l);
				if (item4 != null)
				{
					this.iconID1 = item4.template.iconID;
				}
			}
		}
		this.speed = 1;
		this.isSpeedCombine = true;
		this.isDoneCombine = false;
		this.isCompleteEffCombine = false;
		this.iAngleS = 360 / this.iDotS;
		this.xArgS = new int[this.iDotS];
		this.yArgS = new int[this.iDotS];
		this.xDotS = new int[this.iDotS];
		this.yDotS = new int[this.iDotS];
		this.setDotStar();
		this.isPaintCombine = true;
		this.countUpdate = 10;
		this.countR = 30;
		this.countWait = 10;
		this.addTextCombineNPC(this.idNPC, mResources.combineSpell);
	}

	// Token: 0x060008AA RID: 2218 RVA: 0x00082378 File Offset: 0x00080578
	private void updateCombineEff()
	{
		this.countUpdate--;
		if (this.countUpdate < 0)
		{
			this.countUpdate = 0;
		}
		this.countR--;
		if (this.countR < 0)
		{
			this.countR = 0;
		}
		if (this.countUpdate == 0)
		{
			if (!this.isCompleteEffCombine)
			{
				if (this.time > 0)
				{
					if ((int)this.combineSuccess != -1)
					{
						if (this.typeCombine == 3)
						{
							if (GameCanvas.gameTick % 10 == 0)
							{
								Effect me = new Effect(21, this.xS - 10, this.yS + 25, 4, 1, 1);
								EffecMn.addEff(me);
								this.time--;
							}
						}
						else
						{
							if (GameCanvas.gameTick % 2 == 0)
							{
								if (this.isSpeedCombine)
								{
									if (this.speed < 40)
									{
										this.speed += 2;
									}
								}
								else if (this.speed > 10)
								{
									this.speed -= 2;
								}
							}
							if (this.countR == 0)
							{
								if (this.isSpeedCombine)
								{
									if (this.rS > 0)
									{
										this.rS -= 5;
									}
									else if (GameCanvas.gameTick % 10 == 0)
									{
										this.isSpeedCombine = false;
										this.time--;
										this.countR = 5;
										this.countWait = 10;
									}
								}
								else if (this.rS < 90)
								{
									this.rS += 5;
								}
								else if (GameCanvas.gameTick % 10 == 0)
								{
									this.isSpeedCombine = true;
									this.countR = 10;
								}
							}
							this.angleS = this.angleO;
							this.angleS -= this.speed;
							if (this.angleS >= 360)
							{
								this.angleS -= 360;
							}
							if (this.angleS < 0)
							{
								this.angleS = 360 + this.angleS;
							}
							this.angleO = this.angleS;
							this.setDotStar();
						}
					}
				}
				else if (GameCanvas.gameTick % 20 == 0)
				{
					this.isCompleteEffCombine = true;
				}
				if (GameCanvas.gameTick % 20 == 0)
				{
					if (this.typeCombine != 3)
					{
						EffectPanel.addServerEffect(132, this.xS, this.yS, 2);
					}
					EffectPanel.addServerEffect(114, this.xS, this.yS + 20, 2);
				}
			}
			else if (this.isCompleteEffCombine)
			{
				if ((int)this.combineSuccess == 1)
				{
					if (this.countWait == 10)
					{
						Effect me2 = new Effect(22, this.xS - 3, this.yS + 25, 4, 1, 1);
						EffecMn.addEff(me2);
					}
					this.countWait--;
					if (this.countWait < 0)
					{
						this.countWait = 0;
					}
					if (this.rS < 300)
					{
						this.rS = Res.abs(this.rS + 10);
						if (this.rS == 20)
						{
							this.addTextCombineNPC(this.idNPC, mResources.combineFail);
						}
					}
					else if (GameCanvas.gameTick % 20 == 0)
					{
						if (GameCanvas.w > 2 * Panel.WIDTH_PANEL)
						{
							GameCanvas.panel2 = new Panel();
							GameCanvas.panel2.tabName[7] = new string[][]
							{
								new string[]
								{
									string.Empty
								}
							};
							GameCanvas.panel2.setTypeBodyOnly();
							GameCanvas.panel2.show();
						}
						this.combineSuccess = -1;
						this.isDoneCombine = true;
					}
					this.setDotStar();
				}
				else if ((int)this.combineSuccess == 0)
				{
					if (this.countWait == 10)
					{
						if (this.typeCombine == 2)
						{
							Effect me3 = new Effect(20, this.xS - 3, this.yS + 15, 4, 2, 1);
							EffecMn.addEff(me3);
						}
						else
						{
							Effect me4 = new Effect(21, this.xS - 10, this.yS + 25, 4, 1, 1);
							EffecMn.addEff(me4);
						}
						this.addTextCombineNPC(this.idNPC, mResources.combineSuccess);
						this.isPaintCombine = false;
					}
					if (!this.isPaintCombine)
					{
						this.countWait--;
						if (this.countWait < -50)
						{
							this.countWait = -50;
							if (this.typeCombine < 3 && GameCanvas.w > 2 * Panel.WIDTH_PANEL)
							{
								GameCanvas.panel2 = new Panel();
								GameCanvas.panel2.tabName[7] = new string[][]
								{
									new string[]
									{
										string.Empty
									}
								};
								GameCanvas.panel2.setTypeBodyOnly();
								GameCanvas.panel2.show();
							}
							this.combineSuccess = -1;
							this.isDoneCombine = true;
						}
					}
				}
			}
		}
	}

	// Token: 0x060008AB RID: 2219 RVA: 0x0008285C File Offset: 0x00080A5C
	public void paintCombineEff(mGraphics g)
	{
		GameScr.gI().paintBlackSky(g);
		this.paintCombineNPC(g);
		if (this.typeCombine == 0)
		{
			for (int i = 0; i < this.yArgS.Length; i++)
			{
				SmallImage.drawSmallImage(g, (int)this.iconID1, this.xS, this.yS, 0, mGraphics.VCENTER | mGraphics.HCENTER);
				if (this.isPaintCombine)
				{
					SmallImage.drawSmallImage(g, (int)this.iconID2, this.xDotS[i], this.yDotS[i], 0, mGraphics.VCENTER | mGraphics.HCENTER);
				}
			}
		}
		else if (this.typeCombine == 1)
		{
			if (!this.isPaintCombine)
			{
				SmallImage.drawSmallImage(g, (int)this.iconID3, this.xS, this.yS, 0, mGraphics.VCENTER | mGraphics.HCENTER);
			}
			else
			{
				for (int j = 0; j < this.yArgS.Length; j++)
				{
					SmallImage.drawSmallImage(g, (int)this.iconID1, this.xDotS[0], this.yDotS[0], 0, mGraphics.VCENTER | mGraphics.HCENTER);
					SmallImage.drawSmallImage(g, (int)this.iconID2, this.xDotS[1], this.yDotS[1], 0, mGraphics.VCENTER | mGraphics.HCENTER);
				}
			}
		}
		else if (this.typeCombine == 2)
		{
			if (!this.isPaintCombine)
			{
				SmallImage.drawSmallImage(g, (int)this.iconID3, this.xS, this.yS, 0, mGraphics.VCENTER | mGraphics.HCENTER);
			}
			else
			{
				for (int k = 0; k < this.yArgS.Length; k++)
				{
					SmallImage.drawSmallImage(g, (int)this.iconID1, this.xDotS[k], this.yDotS[k], 0, mGraphics.VCENTER | mGraphics.HCENTER);
				}
			}
		}
		else if (this.typeCombine == 3)
		{
			if (!this.isPaintCombine)
			{
				SmallImage.drawSmallImage(g, (int)this.iconID3, this.xS, this.yS, 0, mGraphics.VCENTER | mGraphics.HCENTER);
			}
			else
			{
				SmallImage.drawSmallImage(g, (int)this.iconID1, this.xS, this.yS, 0, mGraphics.VCENTER | mGraphics.HCENTER);
			}
		}
	}

	// Token: 0x060008AC RID: 2220 RVA: 0x00082A94 File Offset: 0x00080C94
	private void setDotStar()
	{
		for (int i = 0; i < this.yArgS.Length; i++)
		{
			if (this.angleS >= 360)
			{
				this.angleS -= 360;
			}
			if (this.angleS < 0)
			{
				this.angleS = 360 + this.angleS;
			}
			this.yArgS[i] = Res.abs(this.rS * Res.sin(this.angleS) / 1024);
			this.xArgS[i] = Res.abs(this.rS * Res.cos(this.angleS) / 1024);
			if (this.angleS < 90)
			{
				this.xDotS[i] = this.xS + this.xArgS[i];
				this.yDotS[i] = this.yS - this.yArgS[i];
			}
			else if (this.angleS >= 90 && this.angleS < 180)
			{
				this.xDotS[i] = this.xS - this.xArgS[i];
				this.yDotS[i] = this.yS - this.yArgS[i];
			}
			else if (this.angleS >= 180 && this.angleS < 270)
			{
				this.xDotS[i] = this.xS - this.xArgS[i];
				this.yDotS[i] = this.yS + this.yArgS[i];
			}
			else
			{
				this.xDotS[i] = this.xS + this.xArgS[i];
				this.yDotS[i] = this.yS + this.yArgS[i];
			}
			this.angleS -= this.iAngleS;
		}
	}

	// Token: 0x060008AD RID: 2221 RVA: 0x00082C68 File Offset: 0x00080E68
	public void paintCombineNPC(mGraphics g)
	{
		g.translate(-GameScr.cmx, -GameScr.cmy);
		if (this.typeCombine < 3)
		{
			for (int i = 0; i < GameScr.vNpc.size(); i++)
			{
				Npc npc = (Npc)GameScr.vNpc.elementAt(i);
				if (npc.template.npcTemplateId == this.idNPC)
				{
					npc.paint(g);
					if (npc.chatInfo != null)
					{
						npc.chatInfo.paint(g, npc.cx, npc.cy - npc.ch, npc.cdir);
					}
				}
			}
		}
		GameCanvas.resetTrans(g);
		if (GameCanvas.gameTick % 4 == 0)
		{
			g.drawImage(ItemMap.imageFlare, this.xS - 5, this.yS + 15, mGraphics.BOTTOM | mGraphics.HCENTER);
			g.drawImage(ItemMap.imageFlare, this.xS + 5, this.yS + 15, mGraphics.BOTTOM | mGraphics.HCENTER);
			g.drawImage(ItemMap.imageFlare, this.xS, this.yS + 15, mGraphics.BOTTOM | mGraphics.HCENTER);
		}
		for (int j = 0; j < Effect2.vEffect3.size(); j++)
		{
			Effect2 effect = (Effect2)Effect2.vEffect3.elementAt(j);
			effect.paint(g);
		}
	}

	// Token: 0x060008AE RID: 2222 RVA: 0x00082DC4 File Offset: 0x00080FC4
	public void addTextCombineNPC(int idNPC, string text)
	{
		if (this.typeCombine < 3)
		{
			for (int i = 0; i < GameScr.vNpc.size(); i++)
			{
				Npc npc = (Npc)GameScr.vNpc.elementAt(i);
				if (npc.template.npcTemplateId == idNPC)
				{
					npc.addInfo(text);
				}
			}
		}
	}

	// Token: 0x060008AF RID: 2223 RVA: 0x00082E24 File Offset: 0x00081024
	public void setTypeOption()
	{
		this.type = 19;
		this.setType(0);
		this.setTabOption();
		this.cmx = (this.cmtoX = 0);
	}

	// Token: 0x060008B0 RID: 2224 RVA: 0x00082E58 File Offset: 0x00081058
	private void setTabOption()
	{
		SoundMn.gI().getStrOption();
		this.currentListLength = Panel.strCauhinh.Length;
		this.ITEM_HEIGHT = 24;
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
	}

	// Token: 0x060008B1 RID: 2225 RVA: 0x00082F28 File Offset: 0x00081128
	private void paintOption(mGraphics g)
	{
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		for (int i = 0; i < Panel.strCauhinh.Length; i++)
		{
			int x = this.xScroll;
			int num = this.yScroll + i * this.ITEM_HEIGHT;
			int num2 = this.wScroll - 1;
			int h = this.ITEM_HEIGHT - 1;
			if (num - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					g.setColor((i != this.selected) ? 15196114 : 16383818);
					g.fillRect(x, num, num2, h);
					mFont.tahoma_7b_dark.drawString(g, Panel.strCauhinh[i], this.xScroll + this.wScroll / 2, num + 6, mFont.CENTER);
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x060008B2 RID: 2226 RVA: 0x00083040 File Offset: 0x00081240
	private void doFireOption()
	{
		if (this.selected < 0)
		{
			return;
		}
		switch (this.selected)
		{
		case 0:
			SoundMn.gI().AuraToolOption();
			break;
		case 1:
			SoundMn.gI().soundToolOption();
			break;
		case 2:
			if (Main.isPC)
			{
				GameCanvas.startYesNoDlg(mResources.changeSizeScreen, new Command(mResources.YES, this, 170391, null), new Command(mResources.NO, this, 4005, null));
			}
			else if (GameScr.isAnalog == 0)
			{
				Panel.strCauhinh[2] = mResources.turnOffAnalog;
				GameScr.isAnalog = 1;
				Rms.saveRMSInt("analog", GameScr.isAnalog);
				GameScr.setSkillBarPosition();
			}
			else
			{
				Panel.strCauhinh[2] = mResources.turnOnAnalog;
				GameScr.isAnalog = 0;
				Rms.saveRMSInt("analog", GameScr.isAnalog);
				GameScr.setSkillBarPosition();
			}
			break;
		}
	}

	// Token: 0x060008B3 RID: 2227 RVA: 0x00083138 File Offset: 0x00081338
	public void setTypeAccount()
	{
		this.type = 20;
		this.setType(0);
		this.setTabAccount();
		this.cmx = (this.cmtoX = 0);
	}

	// Token: 0x060008B4 RID: 2228 RVA: 0x0008316C File Offset: 0x0008136C
	private void setTabAccount()
	{
		if (Main.IphoneVersionApp)
		{
			Panel.strAccount = new string[]
			{
				mResources.inventory_Pass,
				mResources.friend,
				mResources.enemy,
				mResources.msg
			};
			if (GameScr.canAutoPlay)
			{
				Panel.strAccount = new string[]
				{
					mResources.inventory_Pass,
					mResources.friend,
					mResources.enemy,
					mResources.msg,
					mResources.autoFunction
				};
			}
		}
		else
		{
			Panel.strAccount = new string[]
			{
				mResources.inventory_Pass,
				mResources.friend,
				mResources.enemy,
				mResources.msg,
				mResources.charger
			};
			if (GameScr.canAutoPlay)
			{
				Panel.strAccount = new string[]
				{
					mResources.inventory_Pass,
					mResources.friend,
					mResources.enemy,
					mResources.msg,
					mResources.charger,
					mResources.autoFunction
				};
			}
			if ((mSystem.clientType == 2 || mSystem.clientType == 7) && (int)mResources.language != 2)
			{
				Panel.strAccount = new string[]
				{
					mResources.inventory_Pass,
					mResources.friend,
					mResources.enemy,
					mResources.msg,
					mResources.charger
				};
				if (GameScr.canAutoPlay)
				{
					Panel.strAccount = new string[]
					{
						mResources.inventory_Pass,
						mResources.friend,
						mResources.enemy,
						mResources.msg,
						mResources.charger,
						mResources.autoFunction
					};
				}
			}
		}
		this.currentListLength = Panel.strAccount.Length;
		this.ITEM_HEIGHT = 24;
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
	}

	// Token: 0x060008B5 RID: 2229 RVA: 0x000833BC File Offset: 0x000815BC
	private void paintAccount(mGraphics g)
	{
		g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
		g.translate(0, -this.cmy);
		for (int i = 0; i < Panel.strAccount.Length; i++)
		{
			int x = this.xScroll;
			int num = this.yScroll + i * this.ITEM_HEIGHT;
			int num2 = this.wScroll - 1;
			int h = this.ITEM_HEIGHT - 1;
			if (num - this.cmy <= this.yScroll + this.hScroll)
			{
				if (num - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
				{
					g.setColor((i != this.selected) ? 15196114 : 16383818);
					g.fillRect(x, num, num2, h);
					mFont.tahoma_7b_dark.drawString(g, Panel.strAccount[i], this.xScroll + this.wScroll / 2, num + 6, mFont.CENTER);
				}
			}
		}
		this.paintScrollArrow(g);
	}

	// Token: 0x060008B6 RID: 2230 RVA: 0x000834D4 File Offset: 0x000816D4
	private void doFireAccount()
	{
		if (this.selected < 0)
		{
			return;
		}
		switch (this.selected)
		{
		case 0:
			GameCanvas.endDlg();
			if (this.chatTField == null)
			{
				this.chatTField = new ChatTextField();
				this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
				this.chatTField.initChatTextField();
				this.chatTField.parentScreen = GameCanvas.panel;
			}
			this.chatTField.tfChat.setText(string.Empty);
			this.chatTField.strChat = mResources.input_Inventory_Pass;
			this.chatTField.tfChat.name = mResources.input_Inventory_Pass;
			this.chatTField.to = string.Empty;
			this.chatTField.isShow = true;
			this.chatTField.tfChat.isFocus = true;
			this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_NUMERIC);
			if (GameCanvas.isTouch)
			{
				this.chatTField.tfChat.doChangeToTextBox();
			}
			if (!Main.isPC)
			{
				this.chatTField.startChat2(this, string.Empty);
			}
			if (Main.isWindowsPhone)
			{
				this.chatTField.tfChat.strInfo = this.chatTField.strChat;
			}
			break;
		case 1:
			Service.gI().friend(0, -1);
			InfoDlg.showWait();
			break;
		case 2:
			Service.gI().enemy(0, -1);
			InfoDlg.showWait();
			break;
		case 3:
			this.setTypeMessage();
			if (this.chatTField == null)
			{
				this.chatTField = new ChatTextField();
				this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
				this.chatTField.initChatTextField();
				this.chatTField.parentScreen = GameCanvas.panel;
			}
			break;
		case 4:
			if ((int)mResources.language == 2)
			{
				string url = "http://dragonball.indonaga.com/coda/?username=" + GameCanvas.loginScr.tfUser.getText();
				this.hideNow();
				try
				{
					GameMidlet.instance.platformRequest(url);
				}
				catch (Exception ex)
				{
					ex.StackTrace.ToString();
				}
			}
			else
			{
				this.hideNow();
				if (global::Char.myCharz().taskMaint.taskId <= 10)
				{
					GameCanvas.startOKDlg(mResources.finishBomong);
				}
				else
				{
					MoneyCharge.gI().switchToMe();
				}
			}
			break;
		case 5:
			this.setTypeAuto();
			break;
		}
	}

	// Token: 0x060008B7 RID: 2231 RVA: 0x000074EA File Offset: 0x000056EA
	private void updateKeyOption()
	{
		this.updateKeyScrollView();
	}

	// Token: 0x060008B8 RID: 2232 RVA: 0x0000766C File Offset: 0x0000586C
	public void setTypeSpeacialSkill()
	{
		this.type = 25;
		this.setType(0);
		this.setTabSpeacialSkill();
		this.currentTabIndex = 0;
	}

	// Token: 0x060008B9 RID: 2233 RVA: 0x0008378C File Offset: 0x0008198C
	private void setTabSpeacialSkill()
	{
		this.ITEM_HEIGHT = 24;
		this.currentListLength = global::Char.myCharz().infoSpeacialSkill[this.currentTabIndex].Length;
		this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		this.cmy = (this.cmtoY = this.cmyLast[this.currentTabIndex]);
		if (this.cmy < 0)
		{
			this.cmy = (this.cmtoY = 0);
		}
		if (this.cmy > this.cmyLim)
		{
			this.cmy = (this.cmtoY = this.cmyLim);
		}
		this.selected = ((!GameCanvas.isTouch) ? 0 : -1);
	}

	// Token: 0x060008BA RID: 2234 RVA: 0x0000768A File Offset: 0x0000588A
	public bool isTypeShop()
	{
		return this.type == 1;
	}

	// Token: 0x060008BB RID: 2235 RVA: 0x0008385C File Offset: 0x00081A5C
	private void doNotiRuby(int type)
	{
		try
		{
			this.currItem.buyRuby = int.Parse(this.chatTField.tfChat.getText());
		}
		catch (Exception ex)
		{
			GameCanvas.startOKDlg(mResources.input_money_wrong);
			this.chatTField.isShow = false;
			return;
		}
		Command cmdYes = new Command(mResources.YES, this, (type != 0) ? 11001 : 11000, null);
		Command cmdNo = new Command(mResources.NO, this, 11002, null);
		GameCanvas.startYesNoDlg(mResources.notiRuby, cmdYes, cmdNo);
	}

	// Token: 0x04000ED6 RID: 3798
	public bool isShow;

	// Token: 0x04000ED7 RID: 3799
	public int X;

	// Token: 0x04000ED8 RID: 3800
	public int Y;

	// Token: 0x04000ED9 RID: 3801
	public int W;

	// Token: 0x04000EDA RID: 3802
	public int H;

	// Token: 0x04000EDB RID: 3803
	public int ITEM_HEIGHT;

	// Token: 0x04000EDC RID: 3804
	public int TAB_W;

	// Token: 0x04000EDD RID: 3805
	public int cmtoY;

	// Token: 0x04000EDE RID: 3806
	public int cmy;

	// Token: 0x04000EDF RID: 3807
	public int cmdy;

	// Token: 0x04000EE0 RID: 3808
	public int cmvy;

	// Token: 0x04000EE1 RID: 3809
	public int cmyLim;

	// Token: 0x04000EE2 RID: 3810
	public int xc;

	// Token: 0x04000EE3 RID: 3811
	public int[] cmyLast;

	// Token: 0x04000EE4 RID: 3812
	public int cmtoX;

	// Token: 0x04000EE5 RID: 3813
	public int cmx;

	// Token: 0x04000EE6 RID: 3814
	public int cmxLim;

	// Token: 0x04000EE7 RID: 3815
	public int cmxMap;

	// Token: 0x04000EE8 RID: 3816
	public int cmyMap;

	// Token: 0x04000EE9 RID: 3817
	public int cmxMapLim;

	// Token: 0x04000EEA RID: 3818
	public int cmyMapLim;

	// Token: 0x04000EEB RID: 3819
	public int cmyQuest;

	// Token: 0x04000EEC RID: 3820
	public static Image imgBantay;

	// Token: 0x04000EED RID: 3821
	public static Image imgX;

	// Token: 0x04000EEE RID: 3822
	public static Image imgMap;

	// Token: 0x04000EEF RID: 3823
	public TabClanIcon tabIcon;

	// Token: 0x04000EF0 RID: 3824
	public MyVector vItemCombine = new MyVector();

	// Token: 0x04000EF1 RID: 3825
	public int moneyGD;

	// Token: 0x04000EF2 RID: 3826
	public int friendMoneyGD;

	// Token: 0x04000EF3 RID: 3827
	public bool isLock;

	// Token: 0x04000EF4 RID: 3828
	public bool isFriendLock;

	// Token: 0x04000EF5 RID: 3829
	public bool isAccept;

	// Token: 0x04000EF6 RID: 3830
	public bool isFriendAccep;

	// Token: 0x04000EF7 RID: 3831
	public string topName;

	// Token: 0x04000EF8 RID: 3832
	public ChatTextField chatTField;

	// Token: 0x04000EF9 RID: 3833
	public static string specialInfo;

	// Token: 0x04000EFA RID: 3834
	public static short spearcialImage;

	// Token: 0x04000EFB RID: 3835
	public static Image imgStar;

	// Token: 0x04000EFC RID: 3836
	public static Image imgMaxStar;

	// Token: 0x04000EFD RID: 3837
	public static Image imgNew;

	// Token: 0x04000EFE RID: 3838
	public static Image imgXu;

	// Token: 0x04000EFF RID: 3839
	public static Image imgTicket;

	// Token: 0x04000F00 RID: 3840
	public static Image imgLuong;

	// Token: 0x04000F01 RID: 3841
	public static Image imgLuongKhoa;

	// Token: 0x04000F02 RID: 3842
	private static Image imgUp;

	// Token: 0x04000F03 RID: 3843
	private static Image imgDown;

	// Token: 0x04000F04 RID: 3844
	private int pa1;

	// Token: 0x04000F05 RID: 3845
	private int pa2;

	// Token: 0x04000F06 RID: 3846
	private bool trans;

	// Token: 0x04000F07 RID: 3847
	private int pX;

	// Token: 0x04000F08 RID: 3848
	private int pY;

	// Token: 0x04000F09 RID: 3849
	private Command left = new Command(mResources.SELECT, 0);

	// Token: 0x04000F0A RID: 3850
	public int type;

	// Token: 0x04000F0B RID: 3851
	public int currentTabIndex;

	// Token: 0x04000F0C RID: 3852
	public int startTabPos;

	// Token: 0x04000F0D RID: 3853
	public int[] lastTabIndex;

	// Token: 0x04000F0E RID: 3854
	public string[][] currentTabName;

	// Token: 0x04000F0F RID: 3855
	private int[] currClanOption;

	// Token: 0x04000F10 RID: 3856
	public int mainTabPos = 4;

	// Token: 0x04000F11 RID: 3857
	public int shopTabPos = 50;

	// Token: 0x04000F12 RID: 3858
	public int boxTabPos = 50;

	// Token: 0x04000F13 RID: 3859
	public string[][] mainTabName;

	// Token: 0x04000F14 RID: 3860
	public string[] mapNames;

	// Token: 0x04000F15 RID: 3861
	public string[] planetNames;

	// Token: 0x04000F16 RID: 3862
	public static string[] strTool = new string[]
	{
		mResources.gameInfo,
		mResources.change_flag,
		mResources.change_zone,
		mResources.chat_world,
		mResources.account,
		mResources.option,
		mResources.change_account
	};

	// Token: 0x04000F17 RID: 3863
	public static string[] strCauhinh = new string[]
	{
		(!GameCanvas.isPlaySound) ? mResources.turnOnSound : mResources.turnOffSound,
		mResources.increase_vga,
		mResources.analog,
		(mGraphics.zoomLevel <= 1) ? mResources.x2Screen : mResources.x1Screen
	};

	// Token: 0x04000F18 RID: 3864
	public static string[] strAccount = new string[]
	{
		mResources.inventory_Pass,
		mResources.friend,
		mResources.enemy,
		mResources.msg,
		mResources.charger
	};

	// Token: 0x04000F19 RID: 3865
	public static string[] strAuto = new string[]
	{
		mResources.useGem
	};

	// Token: 0x04000F1A RID: 3866
	public static int graphics = 0;

	// Token: 0x04000F1B RID: 3867
	public string[][] shopTabName;

	// Token: 0x04000F1C RID: 3868
	public int[] maxPageShop;

	// Token: 0x04000F1D RID: 3869
	public int[] currPageShop;

	// Token: 0x04000F1E RID: 3870
	private static string[][] boxTabName = new string[][]
	{
		mResources.chestt,
		mResources.inventory
	};

	// Token: 0x04000F1F RID: 3871
	private static string[][] boxCombine = new string[][]
	{
		mResources.combine,
		mResources.inventory
	};

	// Token: 0x04000F20 RID: 3872
	private static string[][] boxZone = new string[][]
	{
		mResources.zonee
	};

	// Token: 0x04000F21 RID: 3873
	private static string[][] boxMap = new string[][]
	{
		mResources.mapp
	};

	// Token: 0x04000F22 RID: 3874
	private static string[][] boxGD = new string[][]
	{
		mResources.inventory,
		mResources.item_give,
		mResources.item_receive
	};

	// Token: 0x04000F23 RID: 3875
	private static string[][] boxPet = mResources.petMainTab;

	// Token: 0x04000F24 RID: 3876
	public string[][][] tabName = new string[][][]
	{
		null,
		null,
		Panel.boxTabName,
		Panel.boxZone,
		Panel.boxMap,
		null,
		null,
		new string[][]
		{
			new string[]
			{
				string.Empty
			}
		},
		new string[][]
		{
			new string[]
			{
				string.Empty
			}
		},
		new string[][]
		{
			new string[]
			{
				string.Empty
			}
		},
		new string[][]
		{
			new string[]
			{
				string.Empty
			}
		},
		new string[][]
		{
			new string[]
			{
				string.Empty
			}
		},
		Panel.boxCombine,
		Panel.boxGD,
		new string[][]
		{
			new string[]
			{
				string.Empty
			}
		},
		new string[][]
		{
			new string[]
			{
				string.Empty
			}
		},
		new string[][]
		{
			new string[]
			{
				string.Empty
			}
		},
		new string[][]
		{
			new string[]
			{
				string.Empty
			}
		},
		new string[][]
		{
			new string[]
			{
				string.Empty
			}
		},
		new string[][]
		{
			new string[]
			{
				string.Empty
			}
		},
		new string[][]
		{
			new string[]
			{
				string.Empty
			}
		},
		Panel.boxPet,
		new string[][]
		{
			new string[]
			{
				string.Empty
			}
		},
		new string[][]
		{
			new string[]
			{
				string.Empty
			}
		},
		new string[][]
		{
			new string[]
			{
				string.Empty
			}
		},
		new string[][]
		{
			new string[]
			{
				string.Empty
			}
		},
		new string[][]
		{
			new string[]
			{
				string.Empty
			}
		}
	};

	// Token: 0x04000F25 RID: 3877
	private static sbyte BOX_BAG = 0;

	// Token: 0x04000F26 RID: 3878
	private static sbyte BAG_BOX = 1;

	// Token: 0x04000F27 RID: 3879
	private static sbyte BOX_BODY = 2;

	// Token: 0x04000F28 RID: 3880
	private static sbyte BODY_BOX = 3;

	// Token: 0x04000F29 RID: 3881
	private static sbyte BAG_BODY = 4;

	// Token: 0x04000F2A RID: 3882
	private static sbyte BODY_BAG = 5;

	// Token: 0x04000F2B RID: 3883
	private static sbyte BAG_PET = 6;

	// Token: 0x04000F2C RID: 3884
	private static sbyte PET_BAG = 7;

	// Token: 0x04000F2D RID: 3885
	public int hasUse;

	// Token: 0x04000F2E RID: 3886
	public int hasUseBag;

	// Token: 0x04000F2F RID: 3887
	public int currentListLength;

	// Token: 0x04000F30 RID: 3888
	private int[] lastSelect;

	// Token: 0x04000F31 RID: 3889
	public static int[] mapIdTraidat = new int[]
	{
		21,
		0,
		1,
		2,
		24,
		3,
		4,
		5,
		6,
		27,
		28,
		29,
		30,
		42,
		47,
		46
	};

	// Token: 0x04000F32 RID: 3890
	public static int[] mapXTraidat = new int[]
	{
		39,
		42,
		105,
		93,
		61,
		93,
		142,
		165,
		210,
		100,
		165,
		220,
		233,
		10,
		125,
		125
	};

	// Token: 0x04000F33 RID: 3891
	public static int[] mapYTraidat = new int[]
	{
		28,
		60,
		48,
		96,
		88,
		131,
		136,
		95,
		32,
		200,
		189,
		167,
		120,
		110,
		20,
		20
	};

	// Token: 0x04000F34 RID: 3892
	public static int[] mapIdNamek = new int[]
	{
		22,
		7,
		8,
		9,
		25,
		11,
		12,
		13,
		10,
		31,
		32,
		33,
		34,
		43
	};

	// Token: 0x04000F35 RID: 3893
	public static int[] mapXNamek = new int[]
	{
		55,
		30,
		93,
		80,
		24,
		149,
		219,
		220,
		233,
		170,
		148,
		195,
		148,
		10
	};

	// Token: 0x04000F36 RID: 3894
	public static int[] mapYNamek = new int[]
	{
		136,
		84,
		69,
		34,
		25,
		42,
		32,
		110,
		192,
		70,
		106,
		156,
		210,
		57
	};

	// Token: 0x04000F37 RID: 3895
	public static int[] mapIdSaya = new int[]
	{
		23,
		14,
		15,
		16,
		26,
		17,
		18,
		20,
		19,
		35,
		36,
		37,
		38,
		44
	};

	// Token: 0x04000F38 RID: 3896
	public static int[] mapXSaya = new int[]
	{
		90,
		95,
		144,
		234,
		231,
		122,
		176,
		158,
		205,
		54,
		105,
		159,
		231,
		27
	};

	// Token: 0x04000F39 RID: 3897
	public static int[] mapYSaya = new int[]
	{
		10,
		43,
		20,
		36,
		69,
		87,
		112,
		167,
		160,
		151,
		173,
		207,
		194,
		29
	};

	// Token: 0x04000F3A RID: 3898
	public static int[][] mapId = new int[][]
	{
		Panel.mapIdTraidat,
		Panel.mapIdNamek,
		Panel.mapIdSaya
	};

	// Token: 0x04000F3B RID: 3899
	public static int[][] mapX = new int[][]
	{
		Panel.mapXTraidat,
		Panel.mapXNamek,
		Panel.mapXSaya
	};

	// Token: 0x04000F3C RID: 3900
	public static int[][] mapY = new int[][]
	{
		Panel.mapYTraidat,
		Panel.mapYNamek,
		Panel.mapYSaya
	};

	// Token: 0x04000F3D RID: 3901
	public Item currItem;

	// Token: 0x04000F3E RID: 3902
	public Clan currClan;

	// Token: 0x04000F3F RID: 3903
	public ClanMessage currMess;

	// Token: 0x04000F40 RID: 3904
	public Member currMem;

	// Token: 0x04000F41 RID: 3905
	public Clan[] clans;

	// Token: 0x04000F42 RID: 3906
	public MyVector member;

	// Token: 0x04000F43 RID: 3907
	public MyVector myMember;

	// Token: 0x04000F44 RID: 3908
	public MyVector logChat = new MyVector();

	// Token: 0x04000F45 RID: 3909
	public MyVector vPlayerMenu = new MyVector();

	// Token: 0x04000F46 RID: 3910
	public MyVector vFriend = new MyVector();

	// Token: 0x04000F47 RID: 3911
	public MyVector vMyGD = new MyVector();

	// Token: 0x04000F48 RID: 3912
	public MyVector vFriendGD = new MyVector();

	// Token: 0x04000F49 RID: 3913
	public MyVector vTop = new MyVector();

	// Token: 0x04000F4A RID: 3914
	public MyVector vEnemy = new MyVector();

	// Token: 0x04000F4B RID: 3915
	public MyVector vFlag = new MyVector();

	// Token: 0x04000F4C RID: 3916
	public Command cmdClose;

	// Token: 0x04000F4D RID: 3917
	public static bool CanNapTien = false;

	// Token: 0x04000F4E RID: 3918
	public static int WIDTH_PANEL = 240;

	// Token: 0x04000F4F RID: 3919
	private int position;

	// Token: 0x04000F50 RID: 3920
	public global::Char charMenu;

	// Token: 0x04000F51 RID: 3921
	private bool isThachDau;

	// Token: 0x04000F52 RID: 3922
	public int typeShop = -1;

	// Token: 0x04000F53 RID: 3923
	public int xScroll;

	// Token: 0x04000F54 RID: 3924
	public int yScroll;

	// Token: 0x04000F55 RID: 3925
	public int wScroll;

	// Token: 0x04000F56 RID: 3926
	public int hScroll;

	// Token: 0x04000F57 RID: 3927
	public ChatPopup cp;

	// Token: 0x04000F58 RID: 3928
	public int idIcon;

	// Token: 0x04000F59 RID: 3929
	public int[] partID;

	// Token: 0x04000F5A RID: 3930
	private int timeShow;

	// Token: 0x04000F5B RID: 3931
	public bool isBoxClan;

	// Token: 0x04000F5C RID: 3932
	public int w;

	// Token: 0x04000F5D RID: 3933
	private int pa;

	// Token: 0x04000F5E RID: 3934
	public int selected;

	// Token: 0x04000F5F RID: 3935
	private int cSelected;

	// Token: 0x04000F60 RID: 3936
	private bool isClanOption;

	// Token: 0x04000F61 RID: 3937
	public bool isSearchClan;

	// Token: 0x04000F62 RID: 3938
	public bool isMessage;

	// Token: 0x04000F63 RID: 3939
	public bool isViewMember;

	// Token: 0x04000F64 RID: 3940
	public const int TYPE_MAIN = 0;

	// Token: 0x04000F65 RID: 3941
	public const int TYPE_SHOP = 1;

	// Token: 0x04000F66 RID: 3942
	public const int TYPE_BOX = 2;

	// Token: 0x04000F67 RID: 3943
	public const int TYPE_ZONE = 3;

	// Token: 0x04000F68 RID: 3944
	public const int TYPE_MAP = 4;

	// Token: 0x04000F69 RID: 3945
	public const int TYPE_CLANS = 5;

	// Token: 0x04000F6A RID: 3946
	public const int TYPE_INFOMATION = 6;

	// Token: 0x04000F6B RID: 3947
	public const int TYPE_BODY = 7;

	// Token: 0x04000F6C RID: 3948
	public const int TYPE_MESS = 8;

	// Token: 0x04000F6D RID: 3949
	public const int TYPE_ARCHIVEMENT = 9;

	// Token: 0x04000F6E RID: 3950
	public const int PLAYER_MENU = 10;

	// Token: 0x04000F6F RID: 3951
	public const int TYPE_FRIEND = 11;

	// Token: 0x04000F70 RID: 3952
	public const int TYPE_COMBINE = 12;

	// Token: 0x04000F71 RID: 3953
	public const int TYPE_GIAODICH = 13;

	// Token: 0x04000F72 RID: 3954
	public const int TYPE_MAPTRANS = 14;

	// Token: 0x04000F73 RID: 3955
	public const int TYPE_TOP = 15;

	// Token: 0x04000F74 RID: 3956
	public const int TYPE_ENEMY = 16;

	// Token: 0x04000F75 RID: 3957
	public const int TYPE_KIGUI = 17;

	// Token: 0x04000F76 RID: 3958
	public const int TYPE_FLAG = 18;

	// Token: 0x04000F77 RID: 3959
	public const int TYPE_OPTION = 19;

	// Token: 0x04000F78 RID: 3960
	public const int TYPE_ACCOUNT = 20;

	// Token: 0x04000F79 RID: 3961
	public const int TYPE_PET_MAIN = 21;

	// Token: 0x04000F7A RID: 3962
	public const int TYPE_AUTO = 22;

	// Token: 0x04000F7B RID: 3963
	public const int TYPE_GAMEINFO = 23;

	// Token: 0x04000F7C RID: 3964
	public const int TYPE_GAMEINFOSUB = 24;

	// Token: 0x04000F7D RID: 3965
	public const int TYPE_SPEACIALSKILL = 25;

	// Token: 0x04000F7E RID: 3966
	private int pointerDownTime;

	// Token: 0x04000F7F RID: 3967
	private int pointerDownFirstX;

	// Token: 0x04000F80 RID: 3968
	private int[] pointerDownLastX = new int[3];

	// Token: 0x04000F81 RID: 3969
	private bool pointerIsDowning;

	// Token: 0x04000F82 RID: 3970
	private bool isDownWhenRunning;

	// Token: 0x04000F83 RID: 3971
	private bool wantUpdateList;

	// Token: 0x04000F84 RID: 3972
	private int waitToPerform;

	// Token: 0x04000F85 RID: 3973
	private int cmRun;

	// Token: 0x04000F86 RID: 3974
	private int keyTouchLock = -1;

	// Token: 0x04000F87 RID: 3975
	private int keyToundGD = -1;

	// Token: 0x04000F88 RID: 3976
	private int keyTouchCombine = -1;

	// Token: 0x04000F89 RID: 3977
	private int keyTouchMapButton = -1;

	// Token: 0x04000F8A RID: 3978
	public int indexMouse = -1;

	// Token: 0x04000F8B RID: 3979
	private bool justRelease;

	// Token: 0x04000F8C RID: 3980
	private int keyTouchTab = -1;

	// Token: 0x04000F8D RID: 3981
	public string[][] clansOption;

	// Token: 0x04000F8E RID: 3982
	public string clanInfo = string.Empty;

	// Token: 0x04000F8F RID: 3983
	public string clanReport = string.Empty;

	// Token: 0x04000F90 RID: 3984
	private bool isHaveClan;

	// Token: 0x04000F91 RID: 3985
	private Scroll scroll;

	// Token: 0x04000F92 RID: 3986
	private int cmvx;

	// Token: 0x04000F93 RID: 3987
	private int cmdx;

	// Token: 0x04000F94 RID: 3988
	private bool isSelectPlayerMenu;

	// Token: 0x04000F95 RID: 3989
	private string[] strStatus = new string[]
	{
		mResources.follow,
		mResources.defend,
		mResources.attack,
		mResources.gohome,
		mResources.fusion,
		mResources.fusionForever
	};

	// Token: 0x04000F96 RID: 3990
	private int currentButtonPress;

	// Token: 0x04000F97 RID: 3991
	private int[] zoneColor = new int[]
	{
		43520,
		14743570,
		14155776
	};

	// Token: 0x04000F98 RID: 3992
	public string[] combineInfo;

	// Token: 0x04000F99 RID: 3993
	public string[] combineTopInfo;

	// Token: 0x04000F9A RID: 3994
	public static int[] color1 = new int[]
	{
		2327248,
		8982199,
		16713222
	};

	// Token: 0x04000F9B RID: 3995
	public static int[] color2 = new int[]
	{
		4583423,
		16719103,
		16714764
	};

	// Token: 0x04000F9C RID: 3996
	private bool isUp;

	// Token: 0x04000F9D RID: 3997
	private int compare;

	// Token: 0x04000F9E RID: 3998
	public static string strWantToBuy = string.Empty;

	// Token: 0x04000F9F RID: 3999
	public int xstart;

	// Token: 0x04000FA0 RID: 4000
	public int ystart;

	// Token: 0x04000FA1 RID: 4001
	public int popupW = 140;

	// Token: 0x04000FA2 RID: 4002
	public int popupH = 160;

	// Token: 0x04000FA3 RID: 4003
	public int cmySK;

	// Token: 0x04000FA4 RID: 4004
	public int cmtoYSK;

	// Token: 0x04000FA5 RID: 4005
	public int cmdySK;

	// Token: 0x04000FA6 RID: 4006
	public int cmvySK;

	// Token: 0x04000FA7 RID: 4007
	public int cmyLimSK;

	// Token: 0x04000FA8 RID: 4008
	public int popupY;

	// Token: 0x04000FA9 RID: 4009
	public int popupX;

	// Token: 0x04000FAA RID: 4010
	public int isborderIndex;

	// Token: 0x04000FAB RID: 4011
	public int isselectedRow;

	// Token: 0x04000FAC RID: 4012
	public int indexSize = 28;

	// Token: 0x04000FAD RID: 4013
	public int indexTitle;

	// Token: 0x04000FAE RID: 4014
	public int indexSelect;

	// Token: 0x04000FAF RID: 4015
	public int indexRow = -1;

	// Token: 0x04000FB0 RID: 4016
	public int indexRowMax;

	// Token: 0x04000FB1 RID: 4017
	public int indexMenu;

	// Token: 0x04000FB2 RID: 4018
	public int columns = 6;

	// Token: 0x04000FB3 RID: 4019
	public int rows;

	// Token: 0x04000FB4 RID: 4020
	public int inforX;

	// Token: 0x04000FB5 RID: 4021
	public int inforY;

	// Token: 0x04000FB6 RID: 4022
	public int inforW;

	// Token: 0x04000FB7 RID: 4023
	public int inforH;

	// Token: 0x04000FB8 RID: 4024
	private int yPaint;

	// Token: 0x04000FB9 RID: 4025
	private int xMap;

	// Token: 0x04000FBA RID: 4026
	private int yMap;

	// Token: 0x04000FBB RID: 4027
	private int xMapTask;

	// Token: 0x04000FBC RID: 4028
	private int yMapTask;

	// Token: 0x04000FBD RID: 4029
	private int xMove;

	// Token: 0x04000FBE RID: 4030
	private int yMove;

	// Token: 0x04000FBF RID: 4031
	public static bool isPaintMap = true;

	// Token: 0x04000FC0 RID: 4032
	public bool isClose;

	// Token: 0x04000FC1 RID: 4033
	private int infoSelect;

	// Token: 0x04000FC2 RID: 4034
	public static MyVector vGameInfo = new MyVector(string.Empty);

	// Token: 0x04000FC3 RID: 4035
	public static string[] contenInfo;

	// Token: 0x04000FC4 RID: 4036
	public bool isViewChatServer;

	// Token: 0x04000FC5 RID: 4037
	private int currInfoItem;

	// Token: 0x04000FC6 RID: 4038
	public global::Char charInfo;

	// Token: 0x04000FC7 RID: 4039
	private bool isChangeZone;

	// Token: 0x04000FC8 RID: 4040
	private bool isKiguiXu;

	// Token: 0x04000FC9 RID: 4041
	private bool isKiguiLuong;

	// Token: 0x04000FCA RID: 4042
	private int delayKigui;

	// Token: 0x04000FCB RID: 4043
	public sbyte combineSuccess = -1;

	// Token: 0x04000FCC RID: 4044
	public int idNPC;

	// Token: 0x04000FCD RID: 4045
	public int xS;

	// Token: 0x04000FCE RID: 4046
	public int yS;

	// Token: 0x04000FCF RID: 4047
	private int rS;

	// Token: 0x04000FD0 RID: 4048
	private int angleS;

	// Token: 0x04000FD1 RID: 4049
	private int angleO;

	// Token: 0x04000FD2 RID: 4050
	private int iAngleS;

	// Token: 0x04000FD3 RID: 4051
	private int iDotS;

	// Token: 0x04000FD4 RID: 4052
	private int speed;

	// Token: 0x04000FD5 RID: 4053
	private int[] xArgS;

	// Token: 0x04000FD6 RID: 4054
	private int[] yArgS;

	// Token: 0x04000FD7 RID: 4055
	private int[] xDotS;

	// Token: 0x04000FD8 RID: 4056
	private int[] yDotS;

	// Token: 0x04000FD9 RID: 4057
	private int time;

	// Token: 0x04000FDA RID: 4058
	private int typeCombine;

	// Token: 0x04000FDB RID: 4059
	private int countUpdate;

	// Token: 0x04000FDC RID: 4060
	private int countR;

	// Token: 0x04000FDD RID: 4061
	private int countWait;

	// Token: 0x04000FDE RID: 4062
	private bool isSpeedCombine;

	// Token: 0x04000FDF RID: 4063
	private bool isCompleteEffCombine = true;

	// Token: 0x04000FE0 RID: 4064
	private bool isPaintCombine;

	// Token: 0x04000FE1 RID: 4065
	public bool isDoneCombine = true;

	// Token: 0x04000FE2 RID: 4066
	public short iconID1;

	// Token: 0x04000FE3 RID: 4067
	public short iconID2;

	// Token: 0x04000FE4 RID: 4068
	public short iconID3;

	// Token: 0x04000FE5 RID: 4069
	public string[][] speacialTabName;
}
