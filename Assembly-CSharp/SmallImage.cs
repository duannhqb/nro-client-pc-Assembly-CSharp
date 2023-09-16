using System;
using Assets.src.e;

// Token: 0x02000082 RID: 130
public class SmallImage
{
	// Token: 0x060003F7 RID: 1015 RVA: 0x00005AF8 File Offset: 0x00003CF8
	public SmallImage()
	{
		this.readImage();
	}

	// Token: 0x060003F8 RID: 1016 RVA: 0x00022AE0 File Offset: 0x00020CE0
	public static void loadBigRMS()
	{
		if (SmallImage.imgbig == null)
		{
			SmallImage.imgbig = new Image[]
			{
				GameCanvas.loadImageRMS("/img/Big0.png"),
				GameCanvas.loadImageRMS("/img/Big1.png"),
				GameCanvas.loadImageRMS("/img/Big2.png"),
				GameCanvas.loadImageRMS("/img/Big3.png"),
				GameCanvas.loadImageRMS("/img/Big4.png")
			};
		}
	}

	// Token: 0x060003F9 RID: 1017 RVA: 0x00005B06 File Offset: 0x00003D06
	public static void freeBig()
	{
		SmallImage.imgbig = null;
		mSystem.gcc();
	}

	// Token: 0x060003FA RID: 1018 RVA: 0x00005B13 File Offset: 0x00003D13
	public static void loadBigImage()
	{
		SmallImage.imgEmpty = Image.createRGBImage(new int[1], 1, 1, true);
	}

	// Token: 0x060003FB RID: 1019 RVA: 0x00005B28 File Offset: 0x00003D28
	public static void init()
	{
		SmallImage.instance = null;
		SmallImage.instance = new SmallImage();
	}

	// Token: 0x060003FC RID: 1020 RVA: 0x00003984 File Offset: 0x00001B84
	public void readData(byte[] data)
	{
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x00022B44 File Offset: 0x00020D44
	public void readImage()
	{
		int num = 0;
		try
		{
			DataInputStream dataInputStream = new DataInputStream(Rms.loadRMS("NR_image"));
			short num2 = dataInputStream.readShort();
			SmallImage.smallImg = new int[(int)num2][];
			for (int i = 0; i < SmallImage.smallImg.Length; i++)
			{
				SmallImage.smallImg[i] = new int[5];
			}
			for (int j = 0; j < (int)num2; j++)
			{
				num++;
				SmallImage.smallImg[j][0] = dataInputStream.readUnsignedByte();
				SmallImage.smallImg[j][1] = (int)dataInputStream.readShort();
				SmallImage.smallImg[j][2] = (int)dataInputStream.readShort();
				SmallImage.smallImg[j][3] = (int)dataInputStream.readShort();
				SmallImage.smallImg[j][4] = (int)dataInputStream.readShort();
			}
		}
		catch (Exception ex)
		{
			Cout.LogError3(string.Concat(new object[]
			{
				"Loi readImage: ",
				ex.ToString(),
				"i= ",
				num
			}));
		}
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x00003984 File Offset: 0x00001B84
	public static void clearHastable()
	{
	}

	// Token: 0x060003FF RID: 1023 RVA: 0x00022C54 File Offset: 0x00020E54
	public static void createImage(int id)
	{
		Res.outz(string.Concat(new object[]
		{
			"is request =",
			id,
			" zoom=",
			mGraphics.zoomLevel
		}));
		if (mGraphics.zoomLevel == 1)
		{
			Image image = GameCanvas.loadImage("/SmallImage/Small" + id + ".png");
			if (image != null)
			{
				SmallImage.imgNew[id] = new Small(image, id);
			}
			else
			{
				SmallImage.imgNew[id] = new Small(SmallImage.imgEmpty, id);
				Service.gI().requestIcon(id);
			}
		}
		else
		{
			Image image2 = GameCanvas.loadImage("/SmallImage/Small" + id + ".png");
			if (image2 != null)
			{
				SmallImage.imgNew[id] = new Small(image2, id);
			}
			else
			{
				bool flag = false;
				sbyte[] array = Rms.loadRMS(mGraphics.zoomLevel + "Small" + id);
				if (array != null)
				{
					if (SmallImage.newSmallVersion != null && array.Length % 127 != (int)SmallImage.newSmallVersion[id])
					{
						flag = true;
					}
					if (!flag)
					{
						Image image3 = Image.createImage(array, 0, array.Length);
						if (image3 != null)
						{
							SmallImage.imgNew[id] = new Small(image3, id);
						}
						else
						{
							flag = true;
						}
					}
				}
				else
				{
					flag = true;
				}
				if (flag)
				{
					SmallImage.imgNew[id] = new Small(SmallImage.imgEmpty, id);
					Service.gI().requestIcon(id);
				}
			}
		}
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x00022DCC File Offset: 0x00020FCC
	public static void drawSmallImage(mGraphics g, int id, int x, int y, int transform, int anchor)
	{
		if (SmallImage.imgbig == null)
		{
			Small small = SmallImage.imgNew[id];
			if (small == null)
			{
				SmallImage.createImage(id);
			}
			else
			{
				g.drawRegion(small, 0, 0, mGraphics.getImageWidth(small.img), mGraphics.getImageHeight(small.img), transform, x, y, anchor);
			}
			return;
		}
		if (SmallImage.smallImg != null)
		{
			if (id >= SmallImage.smallImg.Length || SmallImage.smallImg[id][1] >= 256 || SmallImage.smallImg[id][3] >= 256 || SmallImage.smallImg[id][2] >= 256 || SmallImage.smallImg[id][4] >= 256)
			{
				Small small2 = SmallImage.imgNew[id];
				if (small2 == null)
				{
					SmallImage.createImage(id);
				}
				else
				{
					small2.paint(g, transform, x, y, anchor);
				}
			}
			else if (SmallImage.imgbig[SmallImage.smallImg[id][0]] != null)
			{
				g.drawRegion(SmallImage.imgbig[SmallImage.smallImg[id][0]], SmallImage.smallImg[id][1], SmallImage.smallImg[id][2], SmallImage.smallImg[id][3], SmallImage.smallImg[id][4], transform, x, y, anchor);
			}
		}
		else if (GameCanvas.currentScreen != GameScr.gI())
		{
			Small small3 = SmallImage.imgNew[id];
			if (small3 == null)
			{
				SmallImage.createImage(id);
			}
			else
			{
				small3.paint(g, transform, x, y, anchor);
			}
		}
	}

	// Token: 0x06000401 RID: 1025 RVA: 0x00022F40 File Offset: 0x00021140
	public static void drawSmallImage(mGraphics g, int id, int f, int x, int y, int w, int h, int transform, int anchor)
	{
		if (SmallImage.imgbig == null)
		{
			Small small = SmallImage.imgNew[id];
			if (small == null)
			{
				SmallImage.createImage(id);
			}
			else
			{
				g.drawRegion(small.img, 0, f * w, w, h, transform, x, y, anchor);
			}
			return;
		}
		if (SmallImage.smallImg != null)
		{
			if (id >= SmallImage.smallImg.Length || SmallImage.smallImg[id] == null || SmallImage.smallImg[id][1] >= 256 || SmallImage.smallImg[id][3] >= 256 || SmallImage.smallImg[id][2] >= 256 || SmallImage.smallImg[id][4] >= 256)
			{
				Small small2 = SmallImage.imgNew[id];
				if (small2 == null)
				{
					SmallImage.createImage(id);
				}
				else
				{
					small2.paint(g, transform, f, x, y, w, h, anchor);
				}
			}
			else if (SmallImage.smallImg[id][0] != 4 && SmallImage.imgbig[SmallImage.smallImg[id][0]] != null)
			{
				g.drawRegion(SmallImage.imgbig[SmallImage.smallImg[id][0]], 0, f * w, w, h, transform, x, y, anchor);
			}
			else
			{
				Small small3 = SmallImage.imgNew[id];
				if (small3 == null)
				{
					SmallImage.createImage(id);
				}
				else
				{
					small3.paint(g, transform, f, x, y, w, h, anchor);
				}
			}
		}
		else if (GameCanvas.currentScreen != GameScr.gI())
		{
			Small small4 = SmallImage.imgNew[id];
			if (small4 == null)
			{
				SmallImage.createImage(id);
			}
			else
			{
				small4.paint(g, transform, f, x, y, w, h, anchor);
			}
		}
	}

	// Token: 0x06000402 RID: 1026 RVA: 0x000230E8 File Offset: 0x000212E8
	public static void update()
	{
		int num = 0;
		if (GameCanvas.gameTick % 1000 == 0)
		{
			for (int i = 0; i < SmallImage.imgNew.Length; i++)
			{
				if (SmallImage.imgNew[i] != null)
				{
					num++;
					SmallImage.imgNew[i].update();
					SmallImage.smallCount++;
				}
			}
			if (num > 200 && GameCanvas.lowGraphic)
			{
				SmallImage.imgNew = new Small[(int)SmallImage.maxSmall];
			}
		}
	}

	// Token: 0x040006DA RID: 1754
	public static int[][] smallImg;

	// Token: 0x040006DB RID: 1755
	public static SmallImage instance;

	// Token: 0x040006DC RID: 1756
	public static Image[] imgbig;

	// Token: 0x040006DD RID: 1757
	public static Small[] imgNew;

	// Token: 0x040006DE RID: 1758
	public static MyVector vKeys = new MyVector();

	// Token: 0x040006DF RID: 1759
	public static Image imgEmpty = null;

	// Token: 0x040006E0 RID: 1760
	public static sbyte[] newSmallVersion;

	// Token: 0x040006E1 RID: 1761
	public static int smallCount;

	// Token: 0x040006E2 RID: 1762
	public static short maxSmall;
}
