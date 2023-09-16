using System;

namespace Assets.src.g
{
	// Token: 0x0200009D RID: 157
	public class ClientInput : mScreen, IActionListener
	{
		// Token: 0x0600064C RID: 1612 RVA: 0x00052E08 File Offset: 0x00051008
		private void init(string t)
		{
			this.w = GameCanvas.w - 20;
			if (this.w > 320)
			{
				this.w = 320;
			}
			Res.outz("title= " + t);
			this.strPaint = mFont.tahoma_7b_dark.splitFontArray(t, this.w - 20);
			this.x = (GameCanvas.w - this.w) / 2;
			this.tf = new TField[this.nTf];
			this.h = this.tf.Length * 35 + (this.strPaint.Length - 1) * 20 + 40;
			this.y = GameCanvas.h - this.h - 40 - (this.strPaint.Length - 1) * 20;
			for (int i = 0; i < this.tf.Length; i++)
			{
				this.tf[i] = new TField();
				this.tf[i].name = string.Empty;
				this.tf[i].x = this.x + 10;
				this.tf[i].y = this.y + 35 + (this.strPaint.Length - 1) * 20 + i * 35;
				this.tf[i].width = this.w - 20;
				this.tf[i].height = mScreen.ITEM_HEIGHT + 2;
				if (GameCanvas.isTouch)
				{
					this.tf[0].isFocus = false;
				}
				else
				{
					this.tf[0].isFocus = true;
				}
				if (!GameCanvas.isTouch)
				{
					this.right = this.tf[0].cmdClear;
				}
			}
			this.left = new Command(mResources.CLOSE, this, 1, null);
			this.center = new Command(mResources.OK, this, 2, null);
			if (GameCanvas.isTouch)
			{
				this.center.x = GameCanvas.w / 2 + 18;
				this.left.x = GameCanvas.w / 2 - 85;
				this.center.y = (this.left.y = this.y + this.h + 5);
			}
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x000069C5 File Offset: 0x00004BC5
		public static ClientInput gI()
		{
			if (ClientInput.instance == null)
			{
				ClientInput.instance = new ClientInput();
			}
			return ClientInput.instance;
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x000069E0 File Offset: 0x00004BE0
		public override void switchToMe()
		{
			this.focus = 0;
			base.switchToMe();
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x000069EF File Offset: 0x00004BEF
		public void setInput(int type, string title)
		{
			this.nTf = type;
			this.init(title);
			this.switchToMe();
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x00053040 File Offset: 0x00051240
		public override void paint(mGraphics g)
		{
			GameScr.gI().paint(g);
			PopUp.paintPopUp(g, this.x, this.y, this.w, this.h, -1, true);
			for (int i = 0; i < this.strPaint.Length; i++)
			{
				mFont.tahoma_7b_green2.drawString(g, this.strPaint[i], GameCanvas.w / 2, this.y + 15 + i * 20, mFont.CENTER);
			}
			for (int j = 0; j < this.tf.Length; j++)
			{
				this.tf[j].paint(g);
			}
			base.paint(g);
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x000530EC File Offset: 0x000512EC
		public override void update()
		{
			GameScr.gI().update();
			for (int i = 0; i < this.tf.Length; i++)
			{
				this.tf[i].update();
			}
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0005312C File Offset: 0x0005132C
		public override void keyPress(int keyCode)
		{
			for (int i = 0; i < this.tf.Length; i++)
			{
				if (this.tf[i].isFocus)
				{
					this.tf[i].keyPressed(keyCode);
					break;
				}
			}
			base.keyPress(keyCode);
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x00053180 File Offset: 0x00051380
		public override void updateKey()
		{
			if (GameCanvas.keyPressed[2])
			{
				this.focus--;
				if (this.focus < 0)
				{
					this.focus = this.tf.Length - 1;
				}
			}
			else if (GameCanvas.keyPressed[8])
			{
				this.focus++;
				if (this.focus > this.tf.Length - 1)
				{
					this.focus = 0;
				}
			}
			if (GameCanvas.keyPressed[2] || GameCanvas.keyPressed[8])
			{
				GameCanvas.clearKeyPressed();
				for (int i = 0; i < this.tf.Length; i++)
				{
					if (this.focus == i)
					{
						this.tf[i].isFocus = true;
						if (!GameCanvas.isTouch)
						{
							this.right = this.tf[i].cmdClear;
						}
					}
					else
					{
						this.tf[i].isFocus = false;
					}
					if (GameCanvas.isPointerJustRelease && GameCanvas.isPointerHoldIn(this.tf[i].x, this.tf[i].y, this.tf[i].width, this.tf[i].height))
					{
						this.focus = i;
						break;
					}
				}
			}
			base.updateKey();
			GameCanvas.clearKeyPressed();
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x00006A05 File Offset: 0x00004C05
		public void clearScreen()
		{
			ClientInput.instance = null;
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x000532E0 File Offset: 0x000514E0
		public void perform(int idAction, object p)
		{
			if (idAction == 1)
			{
				GameScr.instance.switchToMe();
				this.clearScreen();
			}
			if (idAction == 2)
			{
				for (int i = 0; i < this.tf.Length; i++)
				{
					if (this.tf[i].getText() == null || this.tf[i].getText().Equals(string.Empty))
					{
						GameCanvas.startOKDlg(mResources.vuilongnhapduthongtin);
						return;
					}
				}
				Service.gI().sendClientInput(this.tf);
				GameScr.instance.switchToMe();
			}
		}

		// Token: 0x04000B4C RID: 2892
		public static ClientInput instance;

		// Token: 0x04000B4D RID: 2893
		public TField[] tf;

		// Token: 0x04000B4E RID: 2894
		private int x;

		// Token: 0x04000B4F RID: 2895
		private int y;

		// Token: 0x04000B50 RID: 2896
		private int w;

		// Token: 0x04000B51 RID: 2897
		private int h;

		// Token: 0x04000B52 RID: 2898
		private string[] strPaint;

		// Token: 0x04000B53 RID: 2899
		private int focus;

		// Token: 0x04000B54 RID: 2900
		private int nTf;
	}
}
