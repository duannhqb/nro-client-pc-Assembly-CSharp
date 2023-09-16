using System;

namespace Assets.src.g
{
	// Token: 0x020000AE RID: 174
	internal class Mabu : global::Char
	{
		// Token: 0x06000772 RID: 1906 RVA: 0x0000704D File Offset: 0x0000524D
		public Mabu()
		{
			this.getData1();
			this.getData2();
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x00067D18 File Offset: 0x00065F18
		public void eat(int id)
		{
			this.effEat = new Effect(105, this.cx, this.cy + 20, 2, 1, -1);
			EffecMn.addEff(this.effEat);
			if (id == global::Char.myCharz().charID)
			{
				this.focus = global::Char.myCharz();
			}
			else
			{
				this.focus = GameScr.findCharInMap(id);
			}
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x00067D7C File Offset: 0x00065F7C
		public new void checkFrameTick(int[] array)
		{
			if ((int)this.skillID == 0)
			{
				if (this.tick == 11)
				{
					this.addFoot = true;
					Effect me = new Effect(19, this.cx, this.cy + 20, 2, 1, -1);
					EffecMn.addEff(me);
				}
				if (this.tick >= array.Length - 1)
				{
					this.skillID = 2;
					return;
				}
			}
			if ((int)this.skillID == 1 && this.tick == array.Length - 1)
			{
				this.skillID = 3;
				this.cy -= 15;
				return;
			}
			this.tick++;
			if (this.tick > array.Length - 1)
			{
				this.tick = 0;
			}
			this.frame = array[this.tick];
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x00067E48 File Offset: 0x00066048
		public void getData1()
		{
			Mabu.data1 = null;
			Mabu.data1 = new EffectData();
			string patch = string.Concat(new object[]
			{
				"/x",
				mGraphics.zoomLevel,
				"/effectdata/",
				102,
				"/data"
			});
			try
			{
				Mabu.data1.readData2(patch);
				Mabu.data1.img = GameCanvas.loadImage("/effectdata/" + 102 + "/img.png");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x00067EEC File Offset: 0x000660EC
		public void setSkill(sbyte id, short x, short y, global::Char[] charHit, int[] damageHit)
		{
			this.skillID = id;
			this.xTo = (int)x;
			this.yTo = (int)y;
			this.lastDir = this.cdir;
			this.cdir = ((this.xTo <= this.cx) ? -1 : 1);
			this.charAttack = charHit;
			this.damageAttack = damageHit;
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x00067F48 File Offset: 0x00066148
		public void getData2()
		{
			Mabu.data2 = null;
			Mabu.data2 = new EffectData();
			string patch = string.Concat(new object[]
			{
				"/x",
				mGraphics.zoomLevel,
				"/effectdata/",
				103,
				"/data"
			});
			try
			{
				Mabu.data2.readData2(patch);
				Mabu.data2.img = GameCanvas.loadImage("/effectdata/" + 103 + "/img.png");
				Res.outz("read xong data");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x00067FF8 File Offset: 0x000661F8
		public override void update()
		{
			if (this.focus != null)
			{
				if (this.effEat.t >= 30)
				{
					this.effEat.x += (this.cx - this.effEat.x) / 4;
					this.effEat.y += (this.cy - this.effEat.y) / 4;
					this.focus.cx = this.effEat.x;
					this.focus.cy = this.effEat.y;
					this.focus.isMabuHold = true;
				}
				else
				{
					this.effEat.trans = ((this.effEat.x <= this.focus.cx) ? 0 : 1);
					this.effEat.x += (this.focus.cx - this.effEat.x) / 3;
					this.effEat.y += (this.focus.cy - this.effEat.y) / 3;
				}
			}
			if ((int)this.skillID != -1)
			{
				if ((int)this.skillID == 0 && this.addFoot && GameCanvas.gameTick % 2 == 0)
				{
					this.dx += ((this.xTo <= this.cx) ? -30 : 30);
					EffecMn.addEff(new Effect(103, this.cx + this.dx, this.cy + 20, 2, 1, -1)
					{
						trans = ((this.xTo <= this.cx) ? 1 : 0)
					});
					if ((this.cdir == 1 && this.cx + this.dx >= this.xTo) || (this.cdir == -1 && this.cx + this.dx <= this.xTo))
					{
						this.addFoot = false;
						this.skillID = -1;
						this.dx = 0;
						this.tick = 0;
						this.cdir = this.lastDir;
						for (int i = 0; i < this.charAttack.Length; i++)
						{
							this.charAttack[i].doInjure(this.damageAttack[i], 0, false, false);
						}
					}
				}
				if ((int)this.skillID == 3)
				{
					this.xTo = this.charAttack[this.pIndex].cx;
					this.yTo = this.charAttack[this.pIndex].cy;
					this.cx += (this.xTo - this.cx) / 3;
					this.cy += (this.yTo - this.cy) / 3;
					if (GameCanvas.gameTick % 5 == 0)
					{
						Effect me = new Effect(19, this.cx, this.cy, 2, 1, -1);
						EffecMn.addEff(me);
					}
					if (Res.abs(this.cx - this.xTo) <= 20 && Res.abs(this.cy - this.yTo) <= 20)
					{
						this.cx = this.xTo;
						this.cy = this.yTo;
						this.charAttack[this.pIndex].doInjure(this.damageAttack[this.pIndex], 0, false, false);
						this.pIndex++;
						if (this.pIndex == this.charAttack.Length)
						{
							this.skillID = -1;
							this.pIndex = 0;
						}
					}
				}
				return;
			}
			base.update();
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x000683AC File Offset: 0x000665AC
		public override void paint(mGraphics g)
		{
			if ((int)this.skillID != -1)
			{
				base.paintShadow(g);
				g.translate(0, GameCanvas.transY);
				this.checkFrameTick(Mabu.skills[(int)this.skillID]);
				if ((int)this.skillID == 0 || (int)this.skillID == 1)
				{
					Mabu.data1.paintFrame(g, this.frame, this.cx, this.cy + this.fy, (this.cdir != 1) ? 1 : 0, 2);
				}
				else
				{
					Mabu.data2.paintFrame(g, this.frame, this.cx, this.cy + this.fy, (this.cdir != 1) ? 1 : 0, 2);
				}
				g.translate(0, -GameCanvas.transY);
			}
			else
			{
				base.paint(g);
			}
		}

		// Token: 0x04000DF1 RID: 3569
		public static EffectData data1;

		// Token: 0x04000DF2 RID: 3570
		public static EffectData data2;

		// Token: 0x04000DF3 RID: 3571
		private new int tick;

		// Token: 0x04000DF4 RID: 3572
		private int lastDir;

		// Token: 0x04000DF5 RID: 3573
		private bool addFoot;

		// Token: 0x04000DF6 RID: 3574
		private Effect effEat;

		// Token: 0x04000DF7 RID: 3575
		private new global::Char focus;

		// Token: 0x04000DF8 RID: 3576
		public int xTo;

		// Token: 0x04000DF9 RID: 3577
		public int yTo;

		// Token: 0x04000DFA RID: 3578
		public bool haftBody;

		// Token: 0x04000DFB RID: 3579
		public bool change;

		// Token: 0x04000DFC RID: 3580
		private global::Char[] charAttack;

		// Token: 0x04000DFD RID: 3581
		private int[] damageAttack;

		// Token: 0x04000DFE RID: 3582
		private int dx;

		// Token: 0x04000DFF RID: 3583
		public static int[] skill1 = new int[]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5
		};

		// Token: 0x04000E00 RID: 3584
		public static int[] skill2 = new int[]
		{
			0,
			0,
			6,
			6,
			7,
			7,
			8,
			8,
			9,
			9,
			9,
			9,
			9,
			10,
			10
		};

		// Token: 0x04000E01 RID: 3585
		public static int[] skill3 = new int[]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			5,
			6,
			6,
			7,
			7,
			8,
			8,
			9,
			9,
			10,
			10,
			11,
			11,
			12,
			12
		};

		// Token: 0x04000E02 RID: 3586
		public static int[] skill4 = new int[]
		{
			13,
			13,
			14,
			14,
			15,
			15,
			16,
			16
		};

		// Token: 0x04000E03 RID: 3587
		public static int[][] skills = new int[][]
		{
			Mabu.skill1,
			Mabu.skill2,
			Mabu.skill3,
			Mabu.skill4
		};

		// Token: 0x04000E04 RID: 3588
		public sbyte skillID = -1;

		// Token: 0x04000E05 RID: 3589
		private int frame;

		// Token: 0x04000E06 RID: 3590
		private int pIndex;
	}
}
