using System;

// Token: 0x020000AA RID: 170
public class InputDlg : Dialog
{
	// Token: 0x0600074A RID: 1866 RVA: 0x00065C50 File Offset: 0x00063E50
	public InputDlg()
	{
		this.padLeft = 40;
		if (GameCanvas.w <= 176)
		{
			this.padLeft = 10;
		}
		this.tfInput = new TField();
		this.tfInput.x = this.padLeft + 10;
		this.tfInput.y = GameCanvas.h - mScreen.ITEM_HEIGHT - 43;
		this.tfInput.width = GameCanvas.w - 2 * (this.padLeft + 10);
		this.tfInput.height = mScreen.ITEM_HEIGHT + 2;
		this.tfInput.isFocus = true;
		this.right = this.tfInput.cmdClear;
	}

	// Token: 0x0600074B RID: 1867 RVA: 0x00065D08 File Offset: 0x00063F08
	public void show(string info, Command ok, int type)
	{
		this.tfInput.setText(string.Empty);
		this.tfInput.setIputType(type);
		this.info = mFont.tahoma_8b.splitFontArray(info, GameCanvas.w - this.padLeft * 2);
		this.left = new Command(mResources.CLOSE, GameCanvas.gI(), 8882, null);
		this.center = ok;
		this.show();
	}

	// Token: 0x0600074C RID: 1868 RVA: 0x00065D78 File Offset: 0x00063F78
	public override void paint(mGraphics g)
	{
		GameCanvas.paintz.paintInputDlg(g, this.padLeft, GameCanvas.h - 77 - mScreen.cmdH, GameCanvas.w - this.padLeft * 2, 69, this.info);
		this.tfInput.paint(g);
		base.paint(g);
	}

	// Token: 0x0600074D RID: 1869 RVA: 0x00006F39 File Offset: 0x00005139
	public override void keyPress(int keyCode)
	{
		this.tfInput.keyPressed(keyCode);
		base.keyPress(keyCode);
	}

	// Token: 0x0600074E RID: 1870 RVA: 0x00006F4F File Offset: 0x0000514F
	public override void update()
	{
		this.tfInput.update();
		base.update();
	}

	// Token: 0x0600074F RID: 1871 RVA: 0x00006F62 File Offset: 0x00005162
	public override void show()
	{
		GameCanvas.currentDialog = this;
	}

	// Token: 0x06000750 RID: 1872 RVA: 0x0000607A File Offset: 0x0000427A
	public void hide()
	{
		GameCanvas.endDlg();
	}

	// Token: 0x04000D99 RID: 3481
	protected string[] info;

	// Token: 0x04000D9A RID: 3482
	public TField tfInput;

	// Token: 0x04000D9B RID: 3483
	private int padLeft;
}
