using System;

// Token: 0x0200003D RID: 61
public class EffectFeet : Effect2
{
	// Token: 0x06000279 RID: 633 RVA: 0x000172E0 File Offset: 0x000154E0
	public static void addFeet(int cx, int cy, int ctrans, int timeLengthInSecond, bool isCF)
	{
		EffectFeet effectFeet = new EffectFeet();
		effectFeet.x = cx;
		effectFeet.y = cy;
		effectFeet.trans = ctrans;
		effectFeet.isF = isCF;
		effectFeet.endTime = mSystem.currentTimeMillis() + (long)(timeLengthInSecond * 1000);
		Effect2.vEffectFeet.addElement(effectFeet);
	}

	// Token: 0x0600027A RID: 634 RVA: 0x00004DFE File Offset: 0x00002FFE
	public override void update()
	{
		if (mSystem.currentTimeMillis() - this.endTime > 0L)
		{
			Effect2.vEffectFeet.removeElement(this);
		}
	}

	// Token: 0x0600027B RID: 635 RVA: 0x00017330 File Offset: 0x00015530
	public override void paint(mGraphics g)
	{
		int num = (int)TileMap.size;
		if (TileMap.tileTypeAt(this.x + num / 2, this.y + 1, 4))
		{
			g.setClip(this.x / num * num, (this.y - 30) / num * num, num, 100);
		}
		else if (TileMap.tileTypeAt((this.x - num / 2) / num, (this.y + 1) / num) == 0)
		{
			g.setClip(this.x / num * num, (this.y - 30) / num * num, 100, 100);
		}
		else if (TileMap.tileTypeAt((this.x + num / 2) / num, (this.y + 1) / num) == 0)
		{
			g.setClip(this.x / num * num, (this.y - 30) / num * num, num, 100);
		}
		else if (TileMap.tileTypeAt(this.x - num / 2, this.y + 1, 8))
		{
			g.setClip(this.x / 24 * num, (this.y - 30) / num * num, num, 100);
		}
		g.drawRegion((!this.isF) ? EffectFeet.imgFeet3 : EffectFeet.imgFeet1, 0, 0, EffectFeet.imgFeet1.getWidth(), EffectFeet.imgFeet1.getHeight(), this.trans, this.x, this.y, mGraphics.BOTTOM | mGraphics.HCENTER);
		g.setClip(GameScr.cmx, GameScr.cmy - GameCanvas.transY, GameScr.gW, GameScr.gH + 2 * GameCanvas.transY);
	}

	// Token: 0x040002D1 RID: 721
	private int x;

	// Token: 0x040002D2 RID: 722
	private int y;

	// Token: 0x040002D3 RID: 723
	private int trans;

	// Token: 0x040002D4 RID: 724
	private long endTime;

	// Token: 0x040002D5 RID: 725
	private bool isF;

	// Token: 0x040002D6 RID: 726
	public static Image imgFeet1 = GameCanvas.loadImage("/mainImage/myTexture2dmove-1.png");

	// Token: 0x040002D7 RID: 727
	public static Image imgFeet3 = GameCanvas.loadImage("/mainImage/myTexture2dmove-3.png");
}
