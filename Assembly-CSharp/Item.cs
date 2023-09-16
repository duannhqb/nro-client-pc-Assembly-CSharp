using System;

// Token: 0x0200005E RID: 94
public class Item
{
	// Token: 0x06000328 RID: 808 RVA: 0x00005197 File Offset: 0x00003397
	public void getCompare()
	{
		this.compare = GameCanvas.panel.getCompare(this);
	}

	// Token: 0x06000329 RID: 809 RVA: 0x0001C438 File Offset: 0x0001A638
	public string getPrice()
	{
		string result = string.Empty;
		if (this.buyCoin <= 0 && this.buyGold <= 0)
		{
			return null;
		}
		if (this.buyCoin > 0 && this.buyGold <= 0)
		{
			result = this.buyCoin + mResources.XU;
		}
		else if (this.buyGold > 0 && this.buyCoin <= 0)
		{
			result = this.buyGold + mResources.LUONG;
		}
		else if (this.buyCoin > 0 && this.buyGold > 0)
		{
			result = string.Concat(new object[]
			{
				this.buyCoin,
				mResources.XU,
				"/",
				this.buyGold,
				mResources.LUONG
			});
		}
		return result;
	}

	// Token: 0x0600032A RID: 810 RVA: 0x0001C524 File Offset: 0x0001A724
	public void paintUpgradeEffect(int x, int y, int upgrade, mGraphics g)
	{
		int num = GameScr.indexSize - 2;
		int num2 = 0;
		int num3 = (upgrade >= 4) ? ((upgrade >= 8) ? ((upgrade >= 12) ? ((upgrade > 14) ? 4 : 3) : 2) : 1) : 0;
		for (int i = num2; i < this.size.Length; i++)
		{
			int num4 = x - num / 2 + this.upgradeEffectX(GameCanvas.gameTick - i * 4);
			int num5 = y - num / 2 + this.upgradeEffectY(GameCanvas.gameTick - i * 4);
			g.setColor(this.colorBorder[num3][i]);
			g.fillRect(num4 - this.size[i] / 2, num5 - this.size[i] / 2, this.size[i], this.size[i]);
		}
		if (upgrade == 4 || upgrade == 8)
		{
			for (int j = num2; j < this.size.Length; j++)
			{
				int num6 = x - num / 2 + this.upgradeEffectX(GameCanvas.gameTick - num * 2 - j * 4);
				int num7 = y - num / 2 + this.upgradeEffectY(GameCanvas.gameTick - num * 2 - j * 4);
				g.setColor(this.colorBorder[num3 - 1][j]);
				g.fillRect(num6 - this.size[j] / 2, num7 - this.size[j] / 2, this.size[j], this.size[j]);
			}
		}
		if (upgrade != 1 && upgrade != 4 && upgrade != 8)
		{
			for (int k = num2; k < this.size.Length; k++)
			{
				int num8 = x - num / 2 + this.upgradeEffectX(GameCanvas.gameTick - num * 2 - k * 4);
				int num9 = y - num / 2 + this.upgradeEffectY(GameCanvas.gameTick - num * 2 - k * 4);
				g.setColor(this.colorBorder[num3][k]);
				g.fillRect(num8 - this.size[k] / 2, num9 - this.size[k] / 2, this.size[k], this.size[k]);
			}
		}
		if (upgrade != 1 && upgrade != 4 && upgrade != 8 && upgrade != 12 && upgrade != 2 && upgrade != 5 && upgrade != 9)
		{
			for (int l = num2; l < this.size.Length; l++)
			{
				int num10 = x - num / 2 + this.upgradeEffectX(GameCanvas.gameTick - num - l * 4);
				int num11 = y - num / 2 + this.upgradeEffectY(GameCanvas.gameTick - num - l * 4);
				g.setColor(this.colorBorder[num3][l]);
				g.fillRect(num10 - this.size[l] / 2, num11 - this.size[l] / 2, this.size[l], this.size[l]);
			}
		}
		if (upgrade != 1 && upgrade != 4 && upgrade != 8 && upgrade != 12 && upgrade != 2 && upgrade != 5 && upgrade != 9 && upgrade != 13 && upgrade != 3 && upgrade != 6 && upgrade != 10 && upgrade != 15)
		{
			for (int m = num2; m < this.size.Length; m++)
			{
				int num12 = x - num / 2 + this.upgradeEffectX(GameCanvas.gameTick - num * 3 - m * 4);
				int num13 = y - num / 2 + this.upgradeEffectY(GameCanvas.gameTick - num * 3 - m * 4);
				g.setColor(this.colorBorder[num3][m]);
				g.fillRect(num12 - this.size[m] / 2, num13 - this.size[m] / 2, this.size[m], this.size[m]);
			}
		}
	}

	// Token: 0x0600032B RID: 811 RVA: 0x0001C91C File Offset: 0x0001AB1C
	private int upgradeEffectY(int tick)
	{
		int num = GameScr.indexSize - 2;
		int num2 = tick % (4 * num);
		if (0 <= num2 && num2 < num)
		{
			return 0;
		}
		if (num <= num2 && num2 < num * 2)
		{
			return num2 % num;
		}
		if (num * 2 <= num2 && num2 < num * 3)
		{
			return num;
		}
		return num - num2 % num;
	}

	// Token: 0x0600032C RID: 812 RVA: 0x0001C974 File Offset: 0x0001AB74
	private int upgradeEffectX(int tick)
	{
		int num = GameScr.indexSize - 2;
		int num2 = tick % (4 * num);
		if (0 <= num2 && num2 < num)
		{
			return num2 % num;
		}
		if (num <= num2 && num2 < num * 2)
		{
			return num;
		}
		if (num * 2 <= num2 && num2 < num * 3)
		{
			return num - num2 % num;
		}
		return 0;
	}

	// Token: 0x0600032D RID: 813 RVA: 0x0001C9CC File Offset: 0x0001ABCC
	public bool isHaveOption(int id)
	{
		for (int i = 0; i < this.itemOption.Length; i++)
		{
			ItemOption itemOption = this.itemOption[i];
			if (itemOption != null && itemOption.optionTemplate.id == id)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600032E RID: 814 RVA: 0x0001CA18 File Offset: 0x0001AC18
	public Item clone()
	{
		Item item = new Item();
		item.template = this.template;
		if (this.options != null)
		{
			item.options = new MyVector();
			for (int i = 0; i < this.options.size(); i++)
			{
				ItemOption itemOption = new ItemOption();
				itemOption.optionTemplate = ((ItemOption)this.options.elementAt(i)).optionTemplate;
				itemOption.param = ((ItemOption)this.options.elementAt(i)).param;
				item.options.addElement(itemOption);
			}
		}
		item.itemId = this.itemId;
		item.playerId = this.playerId;
		item.indexUI = this.indexUI;
		item.quantity = this.quantity;
		item.isLock = this.isLock;
		item.sys = this.sys;
		item.upgrade = this.upgrade;
		item.buyCoin = this.buyCoin;
		item.buyCoinLock = this.buyCoinLock;
		item.buyGold = this.buyGold;
		item.buyGoldLock = this.buyGoldLock;
		item.saleCoinLock = this.saleCoinLock;
		item.typeUI = this.typeUI;
		item.isExpires = this.isExpires;
		return item;
	}

	// Token: 0x0600032F RID: 815 RVA: 0x000051AA File Offset: 0x000033AA
	public bool isTypeBody()
	{
		return (0 <= (int)this.template.type && (int)this.template.type < 6) || (int)this.template.type == 32;
	}

	// Token: 0x06000330 RID: 816 RVA: 0x000051E6 File Offset: 0x000033E6
	public string getLockstring()
	{
		return (!this.isLock) ? mResources.NOLOCK : mResources.LOCKED;
	}

	// Token: 0x06000331 RID: 817 RVA: 0x00005202 File Offset: 0x00003402
	public string getUpgradestring()
	{
		if ((int)this.template.level < 10 || (int)this.template.type >= 10)
		{
			return mResources.NOTUPGRADE;
		}
		if (this.upgrade == 0)
		{
			return mResources.NOUPGRADE;
		}
		return null;
	}

	// Token: 0x06000332 RID: 818 RVA: 0x00005242 File Offset: 0x00003442
	public bool isTypeUIMe()
	{
		return this.typeUI == 5 || this.typeUI == 3 || this.typeUI == 4;
	}

	// Token: 0x06000333 RID: 819 RVA: 0x0000526B File Offset: 0x0000346B
	public bool isTypeUIShopView()
	{
		return this.isTypeUIShop() || (this.isTypeUIStore() || this.isTypeUIBook() || this.isTypeUIFashion());
	}

	// Token: 0x06000334 RID: 820 RVA: 0x0001CB5C File Offset: 0x0001AD5C
	public bool isTypeUIShop()
	{
		return this.typeUI == 20 || this.typeUI == 21 || this.typeUI == 22 || this.typeUI == 23 || this.typeUI == 24 || this.typeUI == 25 || this.typeUI == 26 || this.typeUI == 27 || this.typeUI == 28 || this.typeUI == 29 || this.typeUI == 16 || this.typeUI == 17 || this.typeUI == 18 || this.typeUI == 19 || this.typeUI == 2 || this.typeUI == 6 || this.typeUI == 8;
	}

	// Token: 0x06000335 RID: 821 RVA: 0x0000529E File Offset: 0x0000349E
	public bool isTypeUIShopLock()
	{
		return this.typeUI == 7 || this.typeUI == 9;
	}

	// Token: 0x06000336 RID: 822 RVA: 0x000052BC File Offset: 0x000034BC
	public bool isTypeUIStore()
	{
		return this.typeUI == 14;
	}

	// Token: 0x06000337 RID: 823 RVA: 0x000052CE File Offset: 0x000034CE
	public bool isTypeUIBook()
	{
		return this.typeUI == 15;
	}

	// Token: 0x06000338 RID: 824 RVA: 0x000052E0 File Offset: 0x000034E0
	public bool isTypeUIFashion()
	{
		return this.typeUI == 32;
	}

	// Token: 0x06000339 RID: 825 RVA: 0x000052F2 File Offset: 0x000034F2
	public bool isUpMax()
	{
		return this.getUpMax() == this.upgrade;
	}

	// Token: 0x0600033A RID: 826 RVA: 0x0001CC48 File Offset: 0x0001AE48
	public int getUpMax()
	{
		if ((int)this.template.level >= 1 && (int)this.template.level < 20)
		{
			return 4;
		}
		if ((int)this.template.level >= 20 && (int)this.template.level < 40)
		{
			return 8;
		}
		if ((int)this.template.level >= 40 && (int)this.template.level < 50)
		{
			return 12;
		}
		if ((int)this.template.level >= 50 && (int)this.template.level < 60)
		{
			return 14;
		}
		return 16;
	}

	// Token: 0x0600033B RID: 827 RVA: 0x00005308 File Offset: 0x00003508
	public void setPartTemp(int headTemp, int bodyTemp, int legTemp, int bagTemp)
	{
		this.headTemp = headTemp;
		this.bodyTemp = bodyTemp;
		this.legTemp = legTemp;
		this.bagTemp = bagTemp;
	}

	// Token: 0x04000505 RID: 1285
	public const int TYPE_BODY_MIN = 0;

	// Token: 0x04000506 RID: 1286
	public const int TYPE_BODY_MAX = 6;

	// Token: 0x04000507 RID: 1287
	public const int TYPE_AO = 0;

	// Token: 0x04000508 RID: 1288
	public const int TYPE_QUAN = 1;

	// Token: 0x04000509 RID: 1289
	public const int TYPE_GANGTAY = 2;

	// Token: 0x0400050A RID: 1290
	public const int TYPE_GIAY = 3;

	// Token: 0x0400050B RID: 1291
	public const int TYPE_RADA = 4;

	// Token: 0x0400050C RID: 1292
	public const int TYPE_HAIR = 5;

	// Token: 0x0400050D RID: 1293
	public const int TYPE_DAUTHAN = 6;

	// Token: 0x0400050E RID: 1294
	public const int TYPE_NGOCRONG = 12;

	// Token: 0x0400050F RID: 1295
	public const int TYPE_SACH = 7;

	// Token: 0x04000510 RID: 1296
	public const int TYPE_NHIEMVU = 8;

	// Token: 0x04000511 RID: 1297
	public const int TYPE_GOLD = 9;

	// Token: 0x04000512 RID: 1298
	public const int TYPE_DIAMOND = 10;

	// Token: 0x04000513 RID: 1299
	public const int TYPE_BALO = 11;

	// Token: 0x04000514 RID: 1300
	public const int TYPE_DIAMOND_LOCK = 34;

	// Token: 0x04000515 RID: 1301
	public const sbyte UI_WEAPON = 2;

	// Token: 0x04000516 RID: 1302
	public const sbyte UI_BAG = 3;

	// Token: 0x04000517 RID: 1303
	public const sbyte UI_BOX = 4;

	// Token: 0x04000518 RID: 1304
	public const sbyte UI_BODY = 5;

	// Token: 0x04000519 RID: 1305
	public const sbyte UI_STACK = 6;

	// Token: 0x0400051A RID: 1306
	public const sbyte UI_STACK_LOCK = 7;

	// Token: 0x0400051B RID: 1307
	public const sbyte UI_GROCERY = 8;

	// Token: 0x0400051C RID: 1308
	public const sbyte UI_GROCERY_LOCK = 9;

	// Token: 0x0400051D RID: 1309
	public const sbyte UI_UPGRADE = 10;

	// Token: 0x0400051E RID: 1310
	public const sbyte UI_UPPEARL = 11;

	// Token: 0x0400051F RID: 1311
	public const sbyte UI_UPPEARL_LOCK = 12;

	// Token: 0x04000520 RID: 1312
	public const sbyte UI_SPLIT = 13;

	// Token: 0x04000521 RID: 1313
	public const sbyte UI_STORE = 14;

	// Token: 0x04000522 RID: 1314
	public const sbyte UI_BOOK = 15;

	// Token: 0x04000523 RID: 1315
	public const sbyte UI_LIEN = 16;

	// Token: 0x04000524 RID: 1316
	public const sbyte UI_NHAN = 17;

	// Token: 0x04000525 RID: 1317
	public const sbyte UI_NGOCBOI = 18;

	// Token: 0x04000526 RID: 1318
	public const sbyte UI_PHU = 19;

	// Token: 0x04000527 RID: 1319
	public const sbyte UI_NONNAM = 20;

	// Token: 0x04000528 RID: 1320
	public const sbyte UI_NONNU = 21;

	// Token: 0x04000529 RID: 1321
	public const sbyte UI_AONAM = 22;

	// Token: 0x0400052A RID: 1322
	public const sbyte UI_AONU = 23;

	// Token: 0x0400052B RID: 1323
	public const sbyte UI_GANGTAYNAM = 24;

	// Token: 0x0400052C RID: 1324
	public const sbyte UI_GANGTAYNU = 25;

	// Token: 0x0400052D RID: 1325
	public const sbyte UI_QUANNAM = 26;

	// Token: 0x0400052E RID: 1326
	public const sbyte UI_QUANNU = 27;

	// Token: 0x0400052F RID: 1327
	public const sbyte UI_GIAYNAM = 28;

	// Token: 0x04000530 RID: 1328
	public const sbyte UI_GIAYNU = 29;

	// Token: 0x04000531 RID: 1329
	public const sbyte UI_TRADE = 30;

	// Token: 0x04000532 RID: 1330
	public const sbyte UI_UPGRADE_GOLD = 31;

	// Token: 0x04000533 RID: 1331
	public const sbyte UI_FASHION = 32;

	// Token: 0x04000534 RID: 1332
	public const sbyte UI_CONVERT = 33;

	// Token: 0x04000535 RID: 1333
	public ItemOption[] itemOption;

	// Token: 0x04000536 RID: 1334
	public ItemTemplate template;

	// Token: 0x04000537 RID: 1335
	public MyVector options;

	// Token: 0x04000538 RID: 1336
	public int itemId;

	// Token: 0x04000539 RID: 1337
	public int playerId;

	// Token: 0x0400053A RID: 1338
	public bool isSelect;

	// Token: 0x0400053B RID: 1339
	public int indexUI;

	// Token: 0x0400053C RID: 1340
	public int quantity;

	// Token: 0x0400053D RID: 1341
	public int quantilyToBuy;

	// Token: 0x0400053E RID: 1342
	public long powerRequire;

	// Token: 0x0400053F RID: 1343
	public bool isLock;

	// Token: 0x04000540 RID: 1344
	public int sys;

	// Token: 0x04000541 RID: 1345
	public int upgrade;

	// Token: 0x04000542 RID: 1346
	public int buyCoin;

	// Token: 0x04000543 RID: 1347
	public int buyCoinLock;

	// Token: 0x04000544 RID: 1348
	public int buyGold;

	// Token: 0x04000545 RID: 1349
	public int buyGoldLock;

	// Token: 0x04000546 RID: 1350
	public int saleCoinLock;

	// Token: 0x04000547 RID: 1351
	public int buySpec;

	// Token: 0x04000548 RID: 1352
	public int buyRuby;

	// Token: 0x04000549 RID: 1353
	public short iconSpec = -1;

	// Token: 0x0400054A RID: 1354
	public sbyte buyType = -1;

	// Token: 0x0400054B RID: 1355
	public int typeUI;

	// Token: 0x0400054C RID: 1356
	public bool isExpires;

	// Token: 0x0400054D RID: 1357
	public bool isBuySpec;

	// Token: 0x0400054E RID: 1358
	public EffectCharPaint eff;

	// Token: 0x0400054F RID: 1359
	public int indexEff;

	// Token: 0x04000550 RID: 1360
	public Image img;

	// Token: 0x04000551 RID: 1361
	public string info;

	// Token: 0x04000552 RID: 1362
	public string content;

	// Token: 0x04000553 RID: 1363
	public string reason = string.Empty;

	// Token: 0x04000554 RID: 1364
	public int compare;

	// Token: 0x04000555 RID: 1365
	public sbyte isMe;

	// Token: 0x04000556 RID: 1366
	public bool newItem;

	// Token: 0x04000557 RID: 1367
	public int headTemp = -1;

	// Token: 0x04000558 RID: 1368
	public int bodyTemp = -1;

	// Token: 0x04000559 RID: 1369
	public int legTemp = -1;

	// Token: 0x0400055A RID: 1370
	public int bagTemp = -1;

	// Token: 0x0400055B RID: 1371
	public int wpTemp = -1;

	// Token: 0x0400055C RID: 1372
	private int[] color = new int[]
	{
		0,
		0,
		0,
		0,
		600841,
		600841,
		667658,
		667658,
		3346944,
		3346688,
		4199680,
		5052928,
		3276851,
		3932211,
		4587571,
		5046280,
		6684682,
		3359744
	};

	// Token: 0x0400055D RID: 1373
	private int[][] colorBorder = new int[][]
	{
		new int[]
		{
			18687,
			16869,
			15052,
			13235,
			11161,
			9344
		},
		new int[]
		{
			45824,
			39168,
			32768,
			26112,
			19712,
			13056
		},
		new int[]
		{
			16744192,
			15037184,
			13395456,
			11753728,
			10046464,
			8404992
		},
		new int[]
		{
			13500671,
			12058853,
			10682572,
			9371827,
			7995545,
			6684800
		},
		new int[]
		{
			16711705,
			15007767,
			13369364,
			11730962,
			10027023,
			8388621
		}
	};

	// Token: 0x0400055E RID: 1374
	private int[] size = new int[]
	{
		2,
		1,
		1,
		1,
		1,
		1
	};
}
