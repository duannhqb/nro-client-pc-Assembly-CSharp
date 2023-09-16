using System;

// Token: 0x020000B1 RID: 177
public class MoneyCharge : mScreen, IActionListener
{
	// Token: 0x060007B5 RID: 1973 RVA: 0x0006BCDC File Offset: 0x00069EDC
	public MoneyCharge()
	{
		this.w = GameCanvas.w - 20;
		if (this.w > 320)
		{
			this.w = 320;
		}
		this.strPaint = mFont.tahoma_7b_green2.splitFontArray(mResources.pay_card, this.w - 20);
		this.x = (GameCanvas.w - this.w) / 2;
		this.y = GameCanvas.h - 150 - (this.strPaint.Length - 1) * 20;
		this.h = 110 + (this.strPaint.Length - 1) * 20;
		this.yP = this.y;
		this.tfSerial = new TField();
		this.tfSerial.name = mResources.SERI_NUM;
		this.tfSerial.x = this.x + 10;
		this.tfSerial.y = this.y + 35 + (this.strPaint.Length - 1) * 20;
		this.yt = this.tfSerial.y;
		this.tfSerial.width = this.w - 20;
		this.tfSerial.height = mScreen.ITEM_HEIGHT + 2;
		if (GameCanvas.isTouch)
		{
			this.tfSerial.isFocus = false;
		}
		else
		{
			this.tfSerial.isFocus = true;
		}
		this.tfSerial.setIputType(TField.INPUT_TYPE_ANY);
		if (Main.isWindowsPhone)
		{
			this.tfSerial.showSubTextField = false;
		}
		if (Main.isIPhone)
		{
			this.tfSerial.isPaintMouse = false;
		}
		if (!GameCanvas.isTouch)
		{
			this.right = this.tfSerial.cmdClear;
		}
		this.tfCode = new TField();
		this.tfCode.name = mResources.CARD_CODE;
		this.tfCode.x = this.x + 10;
		this.tfCode.y = this.tfSerial.y + 35;
		this.tfCode.width = this.w - 20;
		this.tfCode.height = mScreen.ITEM_HEIGHT + 2;
		this.tfCode.isFocus = false;
		this.tfCode.setIputType(TField.INPUT_TYPE_ANY);
		if (Main.isWindowsPhone)
		{
			this.tfCode.showSubTextField = false;
		}
		if (Main.isIPhone)
		{
			this.tfCode.isPaintMouse = false;
		}
		this.left = new Command(mResources.CLOSE, this, 1, null);
		this.center = new Command(mResources.pay_card2, this, 2, null);
		if (GameCanvas.isTouch)
		{
			this.center.x = GameCanvas.w / 2 + 18;
			this.left.x = GameCanvas.w / 2 - 85;
			this.center.y = (this.left.y = this.y + this.h + 5);
		}
		this.freeAreaHeight = this.tfSerial.y - (4 * this.tfSerial.height - 10);
		this.yP = this.tfSerial.y;
	}

	// Token: 0x060007B6 RID: 1974 RVA: 0x000071C4 File Offset: 0x000053C4
	public static MoneyCharge gI()
	{
		if (MoneyCharge.instance == null)
		{
			MoneyCharge.instance = new MoneyCharge();
		}
		return MoneyCharge.instance;
	}

	// Token: 0x060007B7 RID: 1975 RVA: 0x000071DF File Offset: 0x000053DF
	public override void switchToMe()
	{
		this.focus = 0;
		base.switchToMe();
	}

	// Token: 0x060007B8 RID: 1976 RVA: 0x00003984 File Offset: 0x00001B84
	public void updateTfWhenOpenKb()
	{
	}

	// Token: 0x060007B9 RID: 1977 RVA: 0x0006C010 File Offset: 0x0006A210
	public override void paint(mGraphics g)
	{
		GameScr.gI().paint(g);
		PopUp.paintPopUp(g, this.x, this.y, this.w, this.h, -1, true);
		for (int i = 0; i < this.strPaint.Length; i++)
		{
			mFont.tahoma_7b_green2.drawString(g, this.strPaint[i], GameCanvas.w / 2, this.y + 15 + i * 20, mFont.CENTER);
		}
		this.tfSerial.paint(g);
		this.tfCode.paint(g);
		base.paint(g);
	}

	// Token: 0x060007BA RID: 1978 RVA: 0x000071EE File Offset: 0x000053EE
	public override void update()
	{
		GameScr.gI().update();
		this.tfSerial.update();
		this.tfCode.update();
		if (Main.isWindowsPhone)
		{
			this.updateTfWhenOpenKb();
		}
	}

	// Token: 0x060007BB RID: 1979 RVA: 0x0006C0B0 File Offset: 0x0006A2B0
	public override void keyPress(int keyCode)
	{
		if (this.tfSerial.isFocus)
		{
			this.tfSerial.keyPressed(keyCode);
		}
		else if (this.tfCode.isFocus)
		{
			this.tfCode.keyPressed(keyCode);
		}
		base.keyPress(keyCode);
	}

	// Token: 0x060007BC RID: 1980 RVA: 0x0006C104 File Offset: 0x0006A304
	public override void updateKey()
	{
		if (GameCanvas.keyPressed[(!Main.isPC) ? 2 : 21])
		{
			this.focus--;
			if (this.focus < 0)
			{
				this.focus = 1;
			}
		}
		else if (GameCanvas.keyPressed[(!Main.isPC) ? 8 : 22])
		{
			this.focus++;
			if (this.focus > 1)
			{
				this.focus = 1;
			}
		}
		if (GameCanvas.keyPressed[(!Main.isPC) ? 2 : 21] || GameCanvas.keyPressed[(!Main.isPC) ? 8 : 22])
		{
			GameCanvas.clearKeyPressed();
			if (this.focus == 1)
			{
				this.tfSerial.isFocus = false;
				this.tfCode.isFocus = true;
				if (!GameCanvas.isTouch)
				{
					this.right = this.tfCode.cmdClear;
				}
			}
			else if (this.focus == 0)
			{
				this.tfSerial.isFocus = true;
				this.tfCode.isFocus = false;
				if (!GameCanvas.isTouch)
				{
					this.right = this.tfSerial.cmdClear;
				}
			}
			else
			{
				this.tfSerial.isFocus = false;
				this.tfCode.isFocus = false;
			}
		}
		if (GameCanvas.isPointerJustRelease)
		{
			if (GameCanvas.isPointerHoldIn(this.tfSerial.x, this.tfSerial.y, this.tfSerial.width, this.tfSerial.height))
			{
				this.focus = 0;
			}
			else if (GameCanvas.isPointerHoldIn(this.tfCode.x, this.tfCode.y, this.tfCode.width, this.tfCode.height))
			{
				this.focus = 1;
			}
		}
		base.updateKey();
		GameCanvas.clearKeyPressed();
	}

	// Token: 0x060007BD RID: 1981 RVA: 0x00007220 File Offset: 0x00005420
	public void clearScreen()
	{
		MoneyCharge.instance = null;
	}

	// Token: 0x060007BE RID: 1982 RVA: 0x0006C304 File Offset: 0x0006A504
	public void perform(int idAction, object p)
	{
		if (idAction == 1)
		{
			GameScr.instance.switchToMe();
			this.clearScreen();
		}
		if (idAction == 2)
		{
			if (this.tfSerial.getText() == null || this.tfSerial.getText().Equals(string.Empty))
			{
				GameCanvas.startOKDlg(mResources.serial_blank);
				return;
			}
			if (this.tfCode.getText() == null || this.tfCode.getText().Equals(string.Empty))
			{
				GameCanvas.startOKDlg(mResources.card_code_blank);
				return;
			}
			Service.gI().sendCardInfo(this.tfSerial.getText(), this.tfCode.getText());
			GameScr.instance.switchToMe();
			this.clearScreen();
		}
	}

	// Token: 0x04000E8E RID: 3726
	public static MoneyCharge instance;

	// Token: 0x04000E8F RID: 3727
	public TField tfSerial;

	// Token: 0x04000E90 RID: 3728
	public TField tfCode;

	// Token: 0x04000E91 RID: 3729
	private int x;

	// Token: 0x04000E92 RID: 3730
	private int y;

	// Token: 0x04000E93 RID: 3731
	private int w;

	// Token: 0x04000E94 RID: 3732
	private int h;

	// Token: 0x04000E95 RID: 3733
	private string[] strPaint;

	// Token: 0x04000E96 RID: 3734
	private int focus;

	// Token: 0x04000E97 RID: 3735
	private int yt;

	// Token: 0x04000E98 RID: 3736
	private int freeAreaHeight;

	// Token: 0x04000E99 RID: 3737
	private int yy = GameCanvas.hh - mScreen.ITEM_HEIGHT - 5;

	// Token: 0x04000E9A RID: 3738
	private int yP;
}
