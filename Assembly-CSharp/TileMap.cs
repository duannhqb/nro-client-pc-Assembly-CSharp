using System;

// Token: 0x020000BF RID: 191
public class TileMap
{
	// Token: 0x06000949 RID: 2377 RVA: 0x00007AFA File Offset: 0x00005CFA
	public static void loadBg()
	{
		TileMap.bong = GameCanvas.loadImage("/mainImage/myTexture2dbong.png");
		if (mGraphics.zoomLevel == 1 || Main.isIpod || Main.isIphone4)
		{
			return;
		}
		TileMap.imgLight = GameCanvas.loadImage("/bg/light.png");
	}

	// Token: 0x0600094A RID: 2378 RVA: 0x00007B3A File Offset: 0x00005D3A
	public static bool isTrainingMap()
	{
		return TileMap.mapID == 39 || TileMap.mapID == 40 || TileMap.mapID == 41;
	}

	// Token: 0x0600094B RID: 2379 RVA: 0x0008AD5C File Offset: 0x00088F5C
	public static BgItem getBIById(int id)
	{
		for (int i = 0; i < TileMap.vItemBg.size(); i++)
		{
			BgItem bgItem = (BgItem)TileMap.vItemBg.elementAt(i);
			if (bgItem.id == id)
			{
				return bgItem;
			}
		}
		return null;
	}

	// Token: 0x0600094C RID: 2380 RVA: 0x0008ADA4 File Offset: 0x00088FA4
	public static bool isOfflineMap()
	{
		for (int i = 0; i < TileMap.offlineId.Length; i++)
		{
			if (TileMap.mapID == TileMap.offlineId[i])
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600094D RID: 2381 RVA: 0x0008ADE0 File Offset: 0x00088FE0
	public static bool isHighterMap()
	{
		for (int i = 0; i < TileMap.offlineId.Length; i++)
		{
			if (TileMap.mapID == TileMap.highterId[i])
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600094E RID: 2382 RVA: 0x0008AE1C File Offset: 0x0008901C
	public static bool isToOfflineMap()
	{
		for (int i = 0; i < TileMap.toOfflineId.Length; i++)
		{
			if (TileMap.mapID == TileMap.toOfflineId[i])
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600094F RID: 2383 RVA: 0x00007B63 File Offset: 0x00005D63
	public static void freeTilemap()
	{
		TileMap.imgTile = null;
		mSystem.gcc();
	}

	// Token: 0x06000950 RID: 2384 RVA: 0x00003984 File Offset: 0x00001B84
	public static void loadTileCreatChar()
	{
	}

	// Token: 0x06000951 RID: 2385 RVA: 0x0008AE58 File Offset: 0x00089058
	public static bool isExistMoreOne(int id)
	{
		if (id == 156 || id == 330 || id == 345 || id == 334)
		{
			return false;
		}
		if (TileMap.mapID == 54 || TileMap.mapID == 55 || TileMap.mapID == 56 || TileMap.mapID == 57 || TileMap.mapID == 58 || TileMap.mapID == 59 || TileMap.mapID == 103)
		{
			return false;
		}
		int num = 0;
		for (int i = 0; i < TileMap.vCurrItem.size(); i++)
		{
			BgItem bgItem = (BgItem)TileMap.vCurrItem.elementAt(i);
			if (bgItem.id == id)
			{
				num++;
			}
		}
		return num > 2;
	}

	// Token: 0x06000952 RID: 2386 RVA: 0x0008AF34 File Offset: 0x00089134
	public static void loadTileImage()
	{
		if (TileMap.imgWaterfall == null)
		{
			TileMap.imgWaterfall = GameCanvas.loadImageRMS("/tWater/wtf.png");
		}
		if (TileMap.imgTopWaterfall == null)
		{
			TileMap.imgTopWaterfall = GameCanvas.loadImageRMS("/tWater/twtf.png");
		}
		if (TileMap.imgWaterflow == null)
		{
			TileMap.imgWaterflow = GameCanvas.loadImageRMS("/tWater/wts.png");
		}
		if (TileMap.imgWaterlowN == null)
		{
			TileMap.imgWaterlowN = GameCanvas.loadImageRMS("/tWater/wtsN.png");
		}
		if (TileMap.imgWaterlowN2 == null)
		{
			TileMap.imgWaterlowN2 = GameCanvas.loadImageRMS("/tWater/wtsN2.png");
		}
		mSystem.gcc();
	}

	// Token: 0x06000953 RID: 2387 RVA: 0x0008AFC4 File Offset: 0x000891C4
	public static void setTile(int index, int[] mapsArr, int type)
	{
		for (int i = 0; i < mapsArr.Length; i++)
		{
			if (TileMap.maps[index] == mapsArr[i])
			{
				TileMap.types[index] |= type;
				return;
			}
		}
	}

	// Token: 0x06000954 RID: 2388 RVA: 0x0008B008 File Offset: 0x00089208
	public static void loadMap(int tileId)
	{
		TileMap.pxh = TileMap.tmh * (int)TileMap.size;
		TileMap.pxw = TileMap.tmw * (int)TileMap.size;
		Res.outz("load tile ID= " + TileMap.tileID);
		int num = tileId - 1;
		try
		{
			for (int i = 0; i < TileMap.tmw * TileMap.tmh; i++)
			{
				for (int j = 0; j < TileMap.tileType[num].Length; j++)
				{
					TileMap.setTile(i, TileMap.tileIndex[num][j], TileMap.tileType[num][j]);
				}
			}
		}
		catch (Exception ex)
		{
			Cout.println("Error Load Map");
			GameMidlet.instance.exit();
		}
	}

	// Token: 0x06000955 RID: 2389 RVA: 0x00007B70 File Offset: 0x00005D70
	public static bool isInAirMap()
	{
		return TileMap.mapID == 45 || TileMap.mapID == 46 || TileMap.mapID == 48;
	}

	// Token: 0x06000956 RID: 2390 RVA: 0x0008B0D4 File Offset: 0x000892D4
	public static bool isDoubleMap()
	{
		return TileMap.isMapDouble || TileMap.mapID == 45 || TileMap.mapID == 46 || TileMap.mapID == 48 || TileMap.mapID == 51 || TileMap.mapID == 52 || TileMap.mapID == 103 || TileMap.mapID == 112 || TileMap.mapID == 113 || TileMap.mapID == 115 || TileMap.mapID == 117 || TileMap.mapID == 118 || TileMap.mapID == 119 || TileMap.mapID == 120 || TileMap.mapID == 121 || TileMap.mapID == 125 || TileMap.mapID == 129 || TileMap.mapID == 130;
	}

	// Token: 0x06000957 RID: 2391 RVA: 0x0008B1C0 File Offset: 0x000893C0
	public static void getTile()
	{
		if (Main.typeClient == 3 || Main.typeClient == 5)
		{
			if (mGraphics.zoomLevel == 1)
			{
				TileMap.imgTile = new Image[1];
				TileMap.imgTile[0] = GameCanvas.loadImage("/t/" + TileMap.tileID + ".png");
			}
			else
			{
				TileMap.imgTile = new Image[100];
				for (int i = 0; i < TileMap.imgTile.Length; i++)
				{
					TileMap.imgTile[i] = GameCanvas.loadImage(string.Concat(new object[]
					{
						"/t/",
						TileMap.tileID,
						"/",
						i + 1,
						".png"
					}));
				}
			}
		}
		else
		{
			if (mGraphics.zoomLevel == 1)
			{
				if (TileMap.imgTile != null)
				{
					for (int j = 0; j < TileMap.imgTile.Length; j++)
					{
						if (TileMap.imgTile[j] != null)
						{
							TileMap.imgTile[j].texture = null;
							TileMap.imgTile[j] = null;
						}
					}
					mSystem.gcc();
				}
				TileMap.imgTile = new Image[100];
				string path = string.Empty;
				for (int k = 0; k < TileMap.imgTile.Length; k++)
				{
					if (k < 9)
					{
						path = string.Concat(new object[]
						{
							"/t/",
							TileMap.tileID,
							"/t_0",
							k + 1
						});
					}
					else
					{
						path = string.Concat(new object[]
						{
							"/t/",
							TileMap.tileID,
							"/t_",
							k + 1
						});
					}
					TileMap.imgTile[k] = GameCanvas.loadImage(path);
				}
				return;
			}
			Image image = GameCanvas.loadImageRMS("/t/" + TileMap.tileID + "$1.png");
			if (image != null)
			{
				Rms.DeleteStorage(string.Concat(new object[]
				{
					"x",
					mGraphics.zoomLevel,
					"t",
					TileMap.tileID
				}));
				TileMap.imgTile = new Image[100];
				for (int l = 0; l < TileMap.imgTile.Length; l++)
				{
					TileMap.imgTile[l] = GameCanvas.loadImageRMS(string.Concat(new object[]
					{
						"/t/",
						TileMap.tileID,
						"$",
						l + 1,
						".png"
					}));
				}
			}
			else
			{
				image = GameCanvas.loadImageRMS("/t/" + TileMap.tileID + ".png");
				if (image != null)
				{
					Rms.DeleteStorage("$");
					TileMap.imgTile = new Image[1];
					TileMap.imgTile[0] = image;
				}
			}
		}
	}

	// Token: 0x06000958 RID: 2392 RVA: 0x0008B4B0 File Offset: 0x000896B0
	public static void paintTile(mGraphics g, int frame, int indexX, int indexY)
	{
		if (TileMap.imgTile == null)
		{
			return;
		}
		if (TileMap.imgTile.Length == 1)
		{
			g.drawRegion(TileMap.imgTile[0], 0, frame * (int)TileMap.size, (int)TileMap.size, (int)TileMap.size, 0, indexX * (int)TileMap.size, indexY * (int)TileMap.size, 0);
		}
		else
		{
			g.drawImage(TileMap.imgTile[frame], indexX * (int)TileMap.size, indexY * (int)TileMap.size, 0);
		}
	}

	// Token: 0x06000959 RID: 2393 RVA: 0x0008B52C File Offset: 0x0008972C
	public static void paintTile(mGraphics g, int frame, int x, int y, int w, int h)
	{
		if (TileMap.imgTile == null)
		{
			return;
		}
		if (TileMap.imgTile.Length == 1)
		{
			g.drawRegion(TileMap.imgTile[0], 0, frame * w, w, w, 0, x, y, 0);
		}
		else
		{
			g.drawImage(TileMap.imgTile[frame], x, y, 0);
		}
	}

	// Token: 0x0600095A RID: 2394 RVA: 0x0008B580 File Offset: 0x00089780
	public static void paintTilemapLOW(mGraphics g)
	{
		for (int i = GameScr.gssx; i < GameScr.gssxe; i++)
		{
			for (int j = GameScr.gssy; j < GameScr.gssye; j++)
			{
				int num = TileMap.maps[j * TileMap.tmw + i] - 1;
				if (num != -1)
				{
					TileMap.paintTile(g, num, i, j);
				}
				if ((TileMap.tileTypeAt(i, j) & 32) == 32)
				{
					g.drawRegion(TileMap.imgWaterfall, 0, 24 * (GameCanvas.gameTick % 4), 24, 24, 0, i * (int)TileMap.size, j * (int)TileMap.size, 0);
				}
				else if ((TileMap.tileTypeAt(i, j) & 64) == 64)
				{
					if ((TileMap.tileTypeAt(i, j - 1) & 32) == 32)
					{
						g.drawRegion(TileMap.imgWaterfall, 0, 24 * (GameCanvas.gameTick % 4), 24, 24, 0, i * (int)TileMap.size, j * (int)TileMap.size, 0);
					}
					else if ((TileMap.tileTypeAt(i, j - 1) & 4096) == 4096)
					{
						TileMap.paintTile(g, 21, i, j);
					}
					Image arg;
					if (TileMap.tileID == 5)
					{
						arg = TileMap.imgWaterlowN;
					}
					else if (TileMap.tileID == 8)
					{
						arg = TileMap.imgWaterlowN2;
					}
					else
					{
						arg = TileMap.imgWaterflow;
					}
					g.drawRegion(arg, 0, (GameCanvas.gameTick % 8 >> 2) * 24, 24, 24, 0, i * (int)TileMap.size, j * (int)TileMap.size, 0);
				}
				if ((TileMap.tileTypeAt(i, j) & 2048) == 2048)
				{
					if ((TileMap.tileTypeAt(i, j - 1) & 32) == 32)
					{
						g.drawRegion(TileMap.imgWaterfall, 0, 24 * (GameCanvas.gameTick % 4), 24, 24, 0, i * (int)TileMap.size, j * (int)TileMap.size, 0);
					}
					else if ((TileMap.tileTypeAt(i, j - 1) & 4096) == 4096)
					{
						TileMap.paintTile(g, 21, i, j);
					}
					TileMap.paintTile(g, TileMap.maps[j * TileMap.tmw + i] - 1, i, j);
				}
			}
		}
	}

	// Token: 0x0600095B RID: 2395 RVA: 0x0008B794 File Offset: 0x00089994
	public static void paintTilemap(mGraphics g)
	{
		if (global::Char.isLoadingMap)
		{
			return;
		}
		GameScr.gI().paintBgItem(g, 1);
		for (int i = 0; i < GameScr.vItemMap.size(); i++)
		{
			((ItemMap)GameScr.vItemMap.elementAt(i)).paintAuraItemEff(g);
		}
		for (int j = GameScr.gssx; j < GameScr.gssxe; j++)
		{
			for (int k = GameScr.gssy; k < GameScr.gssye; k++)
			{
				if (j != 0)
				{
					if (j != TileMap.tmw - 1)
					{
						int num = TileMap.maps[k * TileMap.tmw + j] - 1;
						if ((TileMap.tileTypeAt(j, k) & 256) != 256)
						{
							if ((TileMap.tileTypeAt(j, k) & 32) == 32)
							{
								g.drawRegion(TileMap.imgWaterfall, 0, 24 * (GameCanvas.gameTick % 8 >> 1), 24, 24, 0, j * (int)TileMap.size, k * (int)TileMap.size, 0);
							}
							else if ((TileMap.tileTypeAt(j, k) & 128) == 128)
							{
								g.drawRegion(TileMap.imgTopWaterfall, 0, 24 * (GameCanvas.gameTick % 8 >> 1), 24, 24, 0, j * (int)TileMap.size, k * (int)TileMap.size, 0);
							}
							else if (TileMap.tileID == 13)
							{
								if (!GameCanvas.lowGraphic)
								{
									return;
								}
								if (num != -1)
								{
									TileMap.paintTile(g, 0, j, k);
								}
							}
							else
							{
								if (TileMap.tileID == 2 && (TileMap.tileTypeAt(j, k) & 512) == 512 && num != -1)
								{
									TileMap.paintTile(g, num, j * (int)TileMap.size, k * (int)TileMap.size, 24, 1);
									TileMap.paintTile(g, num, j * (int)TileMap.size, k * (int)TileMap.size + 1, 24, 24);
								}
								if (TileMap.tileID == 3)
								{
								}
								if ((TileMap.tileTypeAt(j, k) & 16) == 16)
								{
									TileMap.bx = j * (int)TileMap.size - GameScr.cmx;
									TileMap.dbx = TileMap.bx - GameScr.gW2;
									TileMap.dfx = ((int)TileMap.size - 2) * TileMap.dbx / (int)TileMap.size;
									TileMap.fx = TileMap.dfx + GameScr.gW2;
									TileMap.paintTile(g, num, TileMap.fx + GameScr.cmx, k * (int)TileMap.size, 24, 24);
								}
								else if ((TileMap.tileTypeAt(j, k) & 512) == 512)
								{
									if (num != -1)
									{
										TileMap.paintTile(g, num, j * (int)TileMap.size, k * (int)TileMap.size, 24, 1);
										TileMap.paintTile(g, num, j * (int)TileMap.size, k * (int)TileMap.size + 1, 24, 24);
									}
								}
								else if (num != -1)
								{
									TileMap.paintTile(g, num, j, k);
								}
							}
						}
					}
				}
			}
		}
		if (GameScr.cmx < 24)
		{
			for (int l = GameScr.gssy; l < GameScr.gssye; l++)
			{
				int num2 = TileMap.maps[l * TileMap.tmw + 1] - 1;
				if (num2 != -1)
				{
					TileMap.paintTile(g, num2, 0, l);
				}
			}
		}
		if (GameScr.cmx > GameScr.cmxLim)
		{
			int num3 = TileMap.tmw - 2;
			for (int m = GameScr.gssy; m < GameScr.gssye; m++)
			{
				int num4 = TileMap.maps[m * TileMap.tmw + num3] - 1;
				if (num4 != -1)
				{
					TileMap.paintTile(g, num4, num3 + 1, m);
				}
			}
		}
	}

	// Token: 0x0600095C RID: 2396 RVA: 0x0008BB38 File Offset: 0x00089D38
	public static bool isWaterEff()
	{
		return TileMap.mapID != 54 && TileMap.mapID != 55 && TileMap.mapID != 56 && TileMap.mapID != 57 && TileMap.mapID != 138;
	}

	// Token: 0x0600095D RID: 2397 RVA: 0x0008BB88 File Offset: 0x00089D88
	public static void paintOutTilemap(mGraphics g)
	{
		if (GameCanvas.lowGraphic)
		{
			return;
		}
		int num = 0;
		for (int i = GameScr.gssx; i < GameScr.gssxe; i++)
		{
			for (int j = GameScr.gssy; j < GameScr.gssye; j++)
			{
				num++;
				if ((TileMap.tileTypeAt(i, j) & 64) == 64)
				{
					Image arg;
					if (TileMap.tileID == 5)
					{
						arg = TileMap.imgWaterlowN;
					}
					else if (TileMap.tileID == 8)
					{
						arg = TileMap.imgWaterlowN2;
					}
					else
					{
						arg = TileMap.imgWaterflow;
					}
					if (!TileMap.isWaterEff())
					{
						g.drawRegion(arg, 0, 0, 24, 24, 0, i * (int)TileMap.size, j * (int)TileMap.size - 1, 0);
						g.drawRegion(arg, 0, 0, 24, 24, 0, i * (int)TileMap.size, j * (int)TileMap.size - 3, 0);
					}
					g.drawRegion(arg, 0, (GameCanvas.gameTick % 8 >> 2) * 24, 24, 24, 0, i * (int)TileMap.size, j * (int)TileMap.size - 12, 0);
					if (TileMap.yWater == 0 && TileMap.isWaterEff())
					{
						TileMap.yWater = j * (int)TileMap.size - 12;
						int color = 16777215;
						if (GameCanvas.typeBg == 2)
						{
							color = 10871287;
						}
						else if (GameCanvas.typeBg == 4)
						{
							color = 8111470;
						}
						else if (GameCanvas.typeBg == 7)
						{
							color = 5693125;
						}
						BackgroudEffect.addWater(color, TileMap.yWater + 15);
					}
				}
			}
		}
		BackgroudEffect.paintWaterAll(g);
	}

	// Token: 0x0600095E RID: 2398 RVA: 0x0008BD18 File Offset: 0x00089F18
	public static void loadMapFromResource(int mapID)
	{
		DataInputStream dataInputStream = MyStream.readFile("/mymap/" + mapID);
		TileMap.tmw = (int)((ushort)dataInputStream.read());
		TileMap.tmh = (int)((ushort)dataInputStream.read());
		TileMap.maps = new int[dataInputStream.available()];
		for (int i = 0; i < TileMap.tmw * TileMap.tmh; i++)
		{
			TileMap.maps[i] = (int)((ushort)dataInputStream.read());
		}
		TileMap.types = new int[TileMap.maps.Length];
	}

	// Token: 0x0600095F RID: 2399 RVA: 0x0008BDA0 File Offset: 0x00089FA0
	public static int tileAt(int x, int y)
	{
		int result;
		try
		{
			result = TileMap.maps[y * TileMap.tmw + x];
		}
		catch (Exception ex)
		{
			result = 1000;
		}
		return result;
	}

	// Token: 0x06000960 RID: 2400 RVA: 0x0008BDE0 File Offset: 0x00089FE0
	public static int tileTypeAt(int x, int y)
	{
		int result;
		try
		{
			result = TileMap.types[y * TileMap.tmw + x];
		}
		catch (Exception ex)
		{
			result = 1000;
		}
		return result;
	}

	// Token: 0x06000961 RID: 2401 RVA: 0x0008BE20 File Offset: 0x0008A020
	public static int tileTypeAtPixel(int px, int py)
	{
		int result;
		try
		{
			result = TileMap.types[py / (int)TileMap.size * TileMap.tmw + px / (int)TileMap.size];
		}
		catch (Exception ex)
		{
			result = 1000;
		}
		return result;
	}

	// Token: 0x06000962 RID: 2402 RVA: 0x0008BE70 File Offset: 0x0008A070
	public static bool tileTypeAt(int px, int py, int t)
	{
		bool result;
		try
		{
			result = ((TileMap.types[py / (int)TileMap.size * TileMap.tmw + px / (int)TileMap.size] & t) == t);
		}
		catch (Exception ex)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000963 RID: 2403 RVA: 0x00007B99 File Offset: 0x00005D99
	public static void setTileTypeAtPixel(int px, int py, int t)
	{
		TileMap.types[py / (int)TileMap.size * TileMap.tmw + px / (int)TileMap.size] |= t;
	}

	// Token: 0x06000964 RID: 2404 RVA: 0x00007BC1 File Offset: 0x00005DC1
	public static void setTileTypeAt(int x, int y, int t)
	{
		TileMap.types[y * TileMap.tmw + x] = t;
	}

	// Token: 0x06000965 RID: 2405 RVA: 0x00007BD3 File Offset: 0x00005DD3
	public static void killTileTypeAt(int px, int py, int t)
	{
		TileMap.types[py / (int)TileMap.size * TileMap.tmw + px / (int)TileMap.size] &= ~t;
	}

	// Token: 0x06000966 RID: 2406 RVA: 0x00007BFC File Offset: 0x00005DFC
	public static int tileYofPixel(int py)
	{
		return py / (int)TileMap.size * (int)TileMap.size;
	}

	// Token: 0x06000967 RID: 2407 RVA: 0x00007BFC File Offset: 0x00005DFC
	public static int tileXofPixel(int px)
	{
		return px / (int)TileMap.size * (int)TileMap.size;
	}

	// Token: 0x06000968 RID: 2408 RVA: 0x00007C0D File Offset: 0x00005E0D
	public static void loadMainTile()
	{
		if (TileMap.lastTileID != TileMap.tileID)
		{
			TileMap.getTile();
			TileMap.lastTileID = TileMap.tileID;
		}
	}

	// Token: 0x04001106 RID: 4358
	public const int T_EMPTY = 0;

	// Token: 0x04001107 RID: 4359
	public const int T_TOP = 2;

	// Token: 0x04001108 RID: 4360
	public const int T_LEFT = 4;

	// Token: 0x04001109 RID: 4361
	public const int T_RIGHT = 8;

	// Token: 0x0400110A RID: 4362
	public const int T_TREE = 16;

	// Token: 0x0400110B RID: 4363
	public const int T_WATERFALL = 32;

	// Token: 0x0400110C RID: 4364
	public const int T_WATERFLOW = 64;

	// Token: 0x0400110D RID: 4365
	public const int T_TOPFALL = 128;

	// Token: 0x0400110E RID: 4366
	public const int T_OUTSIDE = 256;

	// Token: 0x0400110F RID: 4367
	public const int T_DOWN1PIXEL = 512;

	// Token: 0x04001110 RID: 4368
	public const int T_BRIDGE = 1024;

	// Token: 0x04001111 RID: 4369
	public const int T_UNDERWATER = 2048;

	// Token: 0x04001112 RID: 4370
	public const int T_SOLIDGROUND = 4096;

	// Token: 0x04001113 RID: 4371
	public const int T_BOTTOM = 8192;

	// Token: 0x04001114 RID: 4372
	public const int T_DIE = 16384;

	// Token: 0x04001115 RID: 4373
	public const int T_HEBI = 32768;

	// Token: 0x04001116 RID: 4374
	public const int T_BANG = 65536;

	// Token: 0x04001117 RID: 4375
	public const int T_JUM8 = 131072;

	// Token: 0x04001118 RID: 4376
	public const int T_NT0 = 262144;

	// Token: 0x04001119 RID: 4377
	public const int T_NT1 = 524288;

	// Token: 0x0400111A RID: 4378
	public const int T_CENTER = 1;

	// Token: 0x0400111B RID: 4379
	public static int tmw;

	// Token: 0x0400111C RID: 4380
	public static int tmh;

	// Token: 0x0400111D RID: 4381
	public static int pxw;

	// Token: 0x0400111E RID: 4382
	public static int pxh;

	// Token: 0x0400111F RID: 4383
	public static int tileID;

	// Token: 0x04001120 RID: 4384
	public static int lastTileID = -1;

	// Token: 0x04001121 RID: 4385
	public static int[] maps;

	// Token: 0x04001122 RID: 4386
	public static int[] types;

	// Token: 0x04001123 RID: 4387
	public static Image[] imgTile;

	// Token: 0x04001124 RID: 4388
	public static Image imgTileSmall;

	// Token: 0x04001125 RID: 4389
	public static Image imgMiniMap;

	// Token: 0x04001126 RID: 4390
	public static Image imgWaterfall;

	// Token: 0x04001127 RID: 4391
	public static Image imgTopWaterfall;

	// Token: 0x04001128 RID: 4392
	public static Image imgWaterflow;

	// Token: 0x04001129 RID: 4393
	public static Image imgWaterlowN;

	// Token: 0x0400112A RID: 4394
	public static Image imgWaterlowN2;

	// Token: 0x0400112B RID: 4395
	public static Image imgWaterF;

	// Token: 0x0400112C RID: 4396
	public static Image imgLeaf;

	// Token: 0x0400112D RID: 4397
	public static sbyte size = 24;

	// Token: 0x0400112E RID: 4398
	private static int bx;

	// Token: 0x0400112F RID: 4399
	private static int dbx;

	// Token: 0x04001130 RID: 4400
	private static int fx;

	// Token: 0x04001131 RID: 4401
	private static int dfx;

	// Token: 0x04001132 RID: 4402
	public static string[] instruction;

	// Token: 0x04001133 RID: 4403
	public static int[] iX;

	// Token: 0x04001134 RID: 4404
	public static int[] iY;

	// Token: 0x04001135 RID: 4405
	public static int[] iW;

	// Token: 0x04001136 RID: 4406
	public static int iCount;

	// Token: 0x04001137 RID: 4407
	public static bool isMapDouble = false;

	// Token: 0x04001138 RID: 4408
	public static string mapName = string.Empty;

	// Token: 0x04001139 RID: 4409
	public static sbyte versionMap = 1;

	// Token: 0x0400113A RID: 4410
	public static int mapID;

	// Token: 0x0400113B RID: 4411
	public static int lastBgID = -1;

	// Token: 0x0400113C RID: 4412
	public static int zoneID;

	// Token: 0x0400113D RID: 4413
	public static int bgID;

	// Token: 0x0400113E RID: 4414
	public static int bgType;

	// Token: 0x0400113F RID: 4415
	public static int lastType = -1;

	// Token: 0x04001140 RID: 4416
	public static int typeMap;

	// Token: 0x04001141 RID: 4417
	public static sbyte planetID;

	// Token: 0x04001142 RID: 4418
	public static sbyte lastPlanetId = -1;

	// Token: 0x04001143 RID: 4419
	public static long timeTranMini;

	// Token: 0x04001144 RID: 4420
	public static MyVector vGo = new MyVector();

	// Token: 0x04001145 RID: 4421
	public static MyVector vItemBg = new MyVector();

	// Token: 0x04001146 RID: 4422
	public static MyVector vCurrItem = new MyVector();

	// Token: 0x04001147 RID: 4423
	public static string[] mapNames;

	// Token: 0x04001148 RID: 4424
	public static sbyte MAP_NORMAL = 0;

	// Token: 0x04001149 RID: 4425
	public static Image bong;

	// Token: 0x0400114A RID: 4426
	public const int TRAIDAT_DOINUI = 0;

	// Token: 0x0400114B RID: 4427
	public const int TRAIDAT_RUNG = 1;

	// Token: 0x0400114C RID: 4428
	public const int TRAIDAT_DAORUA = 2;

	// Token: 0x0400114D RID: 4429
	public const int TRAIDAT_DADO = 3;

	// Token: 0x0400114E RID: 4430
	public const int NAMEK_THUNGLUNG = 5;

	// Token: 0x0400114F RID: 4431
	public const int NAMEK_DOINUI = 4;

	// Token: 0x04001150 RID: 4432
	public const int NAMEK_RUNG = 6;

	// Token: 0x04001151 RID: 4433
	public const int NAMEK_DAO = 7;

	// Token: 0x04001152 RID: 4434
	public const int SAYAI_DOINUI = 8;

	// Token: 0x04001153 RID: 4435
	public const int SAYAI_RUNG = 9;

	// Token: 0x04001154 RID: 4436
	public const int SAYAI_CITY = 10;

	// Token: 0x04001155 RID: 4437
	public const int SAYAI_NIGHT = 11;

	// Token: 0x04001156 RID: 4438
	public const int KAMISAMA = 12;

	// Token: 0x04001157 RID: 4439
	public const int TIME_ROOM = 13;

	// Token: 0x04001158 RID: 4440
	public const int HELL = 15;

	// Token: 0x04001159 RID: 4441
	public const int BEERUS = 16;

	// Token: 0x0400115A RID: 4442
	public static Image[] bgItem = new Image[8];

	// Token: 0x0400115B RID: 4443
	public static MyVector vObject = new MyVector();

	// Token: 0x0400115C RID: 4444
	public static int[] offlineId = new int[]
	{
		21,
		22,
		23,
		39,
		40,
		41
	};

	// Token: 0x0400115D RID: 4445
	public static int[] highterId = new int[]
	{
		21,
		22,
		23,
		24,
		25,
		26
	};

	// Token: 0x0400115E RID: 4446
	public static int[] toOfflineId = new int[]
	{
		0,
		7,
		14
	};

	// Token: 0x0400115F RID: 4447
	public static int[][] tileType;

	// Token: 0x04001160 RID: 4448
	public static int[][][] tileIndex;

	// Token: 0x04001161 RID: 4449
	public static Image imgLight = GameCanvas.loadImage("/bg/light.png");

	// Token: 0x04001162 RID: 4450
	public static int sizeMiniMap = 2;

	// Token: 0x04001163 RID: 4451
	public static int gssx;

	// Token: 0x04001164 RID: 4452
	public static int gssxe;

	// Token: 0x04001165 RID: 4453
	public static int gssy;

	// Token: 0x04001166 RID: 4454
	public static int gssye;

	// Token: 0x04001167 RID: 4455
	public static int countx;

	// Token: 0x04001168 RID: 4456
	public static int county;

	// Token: 0x04001169 RID: 4457
	private static int[] colorMini = new int[]
	{
		5257738,
		8807192
	};

	// Token: 0x0400116A RID: 4458
	public static int yWater = 0;
}
