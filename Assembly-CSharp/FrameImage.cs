using System;

// Token: 0x02000006 RID: 6
public class FrameImage
{
	// Token: 0x0600002A RID: 42 RVA: 0x000082A8 File Offset: 0x000064A8
	public FrameImage(Image img, int width, int height)
	{
		if (img != null)
		{
			this.imgFrame = img;
			this.frameWidth = width;
			this.frameHeight = height;
			this.nFrame = img.getHeight() / height;
			if (this.nFrame < 1)
			{
				this.nFrame = 1;
			}
		}
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00008300 File Offset: 0x00006500
	public FrameImage(Image img, int numW, int numH, int numNull)
	{
		if (img != null)
		{
			this.imgFrame = img;
			this.numWidth = numW;
			this.numHeight = numH;
			this.frameWidth = this.imgFrame.getWidth() / numW;
			this.frameHeight = this.imgFrame.getHeight() / numH;
			this.nFrame = numW * numH - numNull;
		}
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00008368 File Offset: 0x00006568
	public void drawFrame(int idx, int x, int y, int trans, int anchor, mGraphics g)
	{
		try
		{
			if (this.imgFrame != null)
			{
				if (idx > this.nFrame)
				{
					idx = this.nFrame;
				}
				int num = idx * this.frameHeight;
				if (num > this.frameHeight * (this.nFrame - 1) || num < 0)
				{
					num = this.frameHeight * (this.nFrame - 1);
				}
				g.drawRegion(this.imgFrame, 0, idx * this.frameHeight, this.frameWidth, this.frameHeight, trans, x, y, anchor);
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x04000009 RID: 9
	public int frameWidth;

	// Token: 0x0400000A RID: 10
	public int frameHeight;

	// Token: 0x0400000B RID: 11
	public int nFrame;

	// Token: 0x0400000C RID: 12
	public Image imgFrame;

	// Token: 0x0400000D RID: 13
	public int Id = -1;

	// Token: 0x0400000E RID: 14
	public int numWidth;

	// Token: 0x0400000F RID: 15
	public int numHeight;
}
