using System;

namespace Assets.src.e
{
	// Token: 0x02000081 RID: 129
	public class Small
	{
		// Token: 0x060003F2 RID: 1010 RVA: 0x00005AD4 File Offset: 0x00003CD4
		public Small(Image img, int id)
		{
			this.img = img;
			this.id = id;
			this.timePaint = 0;
			this.timeUpdate = 0;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x000229A0 File Offset: 0x00020BA0
		public void paint(mGraphics g, int transform, int x, int y, int anchor)
		{
			g.drawRegion(this.img, 0, 0, mGraphics.getImageWidth(this.img), mGraphics.getImageHeight(this.img), transform, x, y, anchor);
			if (GameCanvas.gameTick % 1000 == 0)
			{
				this.timePaint++;
				this.timeUpdate = this.timePaint;
			}
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00022A04 File Offset: 0x00020C04
		public void paint(mGraphics g, int transform, int f, int x, int y, int w, int h, int anchor)
		{
			this.paint(g, transform, f, x, y, w, h, anchor, false);
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00022A28 File Offset: 0x00020C28
		public void paint(mGraphics g, int transform, int f, int x, int y, int w, int h, int anchor, bool isClip)
		{
			if (mGraphics.getImageWidth(this.img) == 1)
			{
				return;
			}
			g.drawRegion(this.img, 0, f * w, w, h, transform, x, y, anchor, isClip);
			if (GameCanvas.gameTick % 1000 == 0)
			{
				this.timePaint++;
				this.timeUpdate = this.timePaint;
			}
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00022A90 File Offset: 0x00020C90
		public void update()
		{
			this.timeUpdate++;
			if (this.timeUpdate - this.timePaint > 1 && !global::Char.myCharz().isCharBodyImageID(this.id))
			{
				SmallImage.imgNew[this.id] = null;
			}
		}

		// Token: 0x040006D6 RID: 1750
		public Image img;

		// Token: 0x040006D7 RID: 1751
		public int id;

		// Token: 0x040006D8 RID: 1752
		public int timePaint;

		// Token: 0x040006D9 RID: 1753
		public int timeUpdate;
	}
}
