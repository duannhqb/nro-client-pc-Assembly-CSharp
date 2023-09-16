using System;

// Token: 0x02000045 RID: 69
public class MainImage
{
	// Token: 0x06000299 RID: 665 RVA: 0x00004E83 File Offset: 0x00003083
	public MainImage()
	{
	}

	// Token: 0x0600029A RID: 666 RVA: 0x00004EA5 File Offset: 0x000030A5
	public MainImage(Image im, sbyte nFrame)
	{
		this.img = im;
		this.count = 0L;
		this.nFrame = nFrame;
	}

	// Token: 0x04000318 RID: 792
	public Image img;

	// Token: 0x04000319 RID: 793
	public long count = -1L;

	// Token: 0x0400031A RID: 794
	public int timeImageNull;

	// Token: 0x0400031B RID: 795
	public int idImage;

	// Token: 0x0400031C RID: 796
	public long timerequest;

	// Token: 0x0400031D RID: 797
	public sbyte nFrame = 1;

	// Token: 0x0400031E RID: 798
	public long timeUse = mSystem.currentTimeMillis();
}
