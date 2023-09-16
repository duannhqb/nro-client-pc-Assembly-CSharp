using System;

namespace Assets.src.g
{
	// Token: 0x020000B5 RID: 181
	public class PetFollow
	{
		// Token: 0x060008BD RID: 2237 RVA: 0x0000769B File Offset: 0x0000589B
		public PetFollow()
		{
			this.f = Res.random(0, 3);
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x000076D9 File Offset: 0x000058D9
		public void SetImg(int fimg, int[] frameNew, int wimg, int himg)
		{
			if (fimg < 1)
			{
				return;
			}
			this.fimg = fimg;
			this.frame = frameNew;
			this.wimg = wimg;
			this.himg = himg;
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x00083C38 File Offset: 0x00081E38
		public void paint(mGraphics g)
		{
			int w = 32;
			int h = 32;
			int num = (GameCanvas.gameTick % 10 <= 5) ? 0 : 1;
			if (this.fimg > 0)
			{
				w = this.wimg;
				h = this.himg;
				num = 0;
			}
			SmallImage.drawSmallImage(g, (int)this.smallID, this.f, this.cmx, this.cmy + 3 + num, w, h, (this.dir != 1) ? 2 : 0, StaticObj.VCENTER_HCENTER);
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x00083CBC File Offset: 0x00081EBC
		public void update()
		{
			this.moveCamera();
			if (GameCanvas.gameTick % 3 == 0)
			{
				this.f = this.frame[this.count];
				this.count++;
			}
			if (this.count >= this.frame.Length)
			{
				this.count = 0;
			}
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x00007700 File Offset: 0x00005900
		public void remove()
		{
			ServerEffect.addServerEffect(60, this.cmx, this.cmy + 3 + ((GameCanvas.gameTick % 10 <= 5) ? 0 : 1), 1);
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x00083D18 File Offset: 0x00081F18
		public void moveCamera()
		{
			if (this.cmy != this.cmtoY)
			{
				this.cmvy = this.cmtoY - this.cmy << 2;
				this.cmdy += this.cmvy;
				this.cmy += this.cmdy >> 4;
				this.cmdy &= 15;
			}
			if (this.cmx != this.cmtoX)
			{
				this.cmvx = this.cmtoX - this.cmx << 2;
				this.cmdx += this.cmvx;
				this.cmx += this.cmdx >> 4;
				this.cmdx &= 15;
			}
		}

		// Token: 0x04000FE6 RID: 4070
		public short smallID;

		// Token: 0x04000FE7 RID: 4071
		public Info info = new Info();

		// Token: 0x04000FE8 RID: 4072
		public int dir;

		// Token: 0x04000FE9 RID: 4073
		public int f;

		// Token: 0x04000FEA RID: 4074
		public int tF;

		// Token: 0x04000FEB RID: 4075
		public int cmtoY;

		// Token: 0x04000FEC RID: 4076
		public int cmy;

		// Token: 0x04000FED RID: 4077
		public int cmdy;

		// Token: 0x04000FEE RID: 4078
		public int cmvy;

		// Token: 0x04000FEF RID: 4079
		public int cmyLim;

		// Token: 0x04000FF0 RID: 4080
		public int cmtoX;

		// Token: 0x04000FF1 RID: 4081
		public int cmx;

		// Token: 0x04000FF2 RID: 4082
		public int cmdx;

		// Token: 0x04000FF3 RID: 4083
		public int cmvx;

		// Token: 0x04000FF4 RID: 4084
		public int cmxLim;

		// Token: 0x04000FF5 RID: 4085
		public int fimg = -1;

		// Token: 0x04000FF6 RID: 4086
		public int wimg;

		// Token: 0x04000FF7 RID: 4087
		public int himg;

		// Token: 0x04000FF8 RID: 4088
		private int[] frame = new int[]
		{
			0,
			1,
			2,
			1
		};

		// Token: 0x04000FF9 RID: 4089
		private int count;
	}
}
