using System;

// Token: 0x020000C5 RID: 197
public class MotherCanvas
{
	// Token: 0x060009D5 RID: 2517 RVA: 0x00008008 File Offset: 0x00006208
	public MotherCanvas()
	{
		this.checkZoomLevel(this.getWidth(), this.getHeight());
	}

	// Token: 0x060009D6 RID: 2518 RVA: 0x00092464 File Offset: 0x00090664
	public void checkZoomLevel(int w, int h)
	{
		if (Main.isWindowsPhone)
		{
			mGraphics.zoomLevel = 2;
			if (w * h >= 2073600)
			{
				mGraphics.zoomLevel = 4;
			}
			else if (w * h > 384000)
			{
				mGraphics.zoomLevel = 3;
			}
		}
		else if (!Main.isPC)
		{
			if (Main.isIpod)
			{
				mGraphics.zoomLevel = 2;
			}
			else if (w * h >= 2073600)
			{
				mGraphics.zoomLevel = 4;
			}
			else if (w * h >= 691200)
			{
				mGraphics.zoomLevel = 3;
			}
			else if (w * h > 153600)
			{
				mGraphics.zoomLevel = 2;
			}
		}
		else
		{
			mGraphics.zoomLevel = 2;
			if (w * h < 480000)
			{
				mGraphics.zoomLevel = 1;
			}
		}
	}

	// Token: 0x060009D7 RID: 2519 RVA: 0x00007CEA File Offset: 0x00005EEA
	public int getWidth()
	{
		return (int)ScaleGUI.WIDTH;
	}

	// Token: 0x060009D8 RID: 2520 RVA: 0x00007CF2 File Offset: 0x00005EF2
	public int getHeight()
	{
		return (int)ScaleGUI.HEIGHT;
	}

	// Token: 0x060009D9 RID: 2521 RVA: 0x00008031 File Offset: 0x00006231
	public void setChildCanvas(GameCanvas tCanvas)
	{
		this.tCanvas = tCanvas;
	}

	// Token: 0x060009DA RID: 2522 RVA: 0x0000803A File Offset: 0x0000623A
	protected void paint(mGraphics g)
	{
		this.tCanvas.paint(g);
	}

	// Token: 0x060009DB RID: 2523 RVA: 0x00008048 File Offset: 0x00006248
	protected void keyPressed(int keyCode)
	{
		this.tCanvas.keyPressedz(keyCode);
	}

	// Token: 0x060009DC RID: 2524 RVA: 0x00008056 File Offset: 0x00006256
	protected void keyReleased(int keyCode)
	{
		this.tCanvas.keyReleasedz(keyCode);
	}

	// Token: 0x060009DD RID: 2525 RVA: 0x00008064 File Offset: 0x00006264
	protected void pointerDragged(int x, int y)
	{
		x /= mGraphics.zoomLevel;
		y /= mGraphics.zoomLevel;
		this.tCanvas.pointerDragged(x, y);
	}

	// Token: 0x060009DE RID: 2526 RVA: 0x00008085 File Offset: 0x00006285
	protected void pointerPressed(int x, int y)
	{
		x /= mGraphics.zoomLevel;
		y /= mGraphics.zoomLevel;
		this.tCanvas.pointerPressed(x, y);
	}

	// Token: 0x060009DF RID: 2527 RVA: 0x000080A6 File Offset: 0x000062A6
	protected void pointerReleased(int x, int y)
	{
		x /= mGraphics.zoomLevel;
		y /= mGraphics.zoomLevel;
		this.tCanvas.pointerReleased(x, y);
	}

	// Token: 0x060009E0 RID: 2528 RVA: 0x00092534 File Offset: 0x00090734
	public int getWidthz()
	{
		int width = this.getWidth();
		return width / mGraphics.zoomLevel + width % mGraphics.zoomLevel;
	}

	// Token: 0x060009E1 RID: 2529 RVA: 0x00092558 File Offset: 0x00090758
	public int getHeightz()
	{
		int height = this.getHeight();
		return height / mGraphics.zoomLevel + height % mGraphics.zoomLevel;
	}

	// Token: 0x0400124A RID: 4682
	public static MotherCanvas instance;

	// Token: 0x0400124B RID: 4683
	public GameCanvas tCanvas;

	// Token: 0x0400124C RID: 4684
	public int zoomLevel = 1;

	// Token: 0x0400124D RID: 4685
	public Image imgCache;

	// Token: 0x0400124E RID: 4686
	private int[] imgRGBCache;

	// Token: 0x0400124F RID: 4687
	private int newWidth;

	// Token: 0x04001250 RID: 4688
	private int newHeight;

	// Token: 0x04001251 RID: 4689
	private int[] output;

	// Token: 0x04001252 RID: 4690
	private int OUTPUTSIZE = 20;
}
