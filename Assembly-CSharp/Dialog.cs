using System;

// Token: 0x020000A0 RID: 160
public abstract class Dialog
{
	// Token: 0x06000675 RID: 1653 RVA: 0x0005632C File Offset: 0x0005452C
	public virtual void paint(mGraphics g)
	{
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
		GameCanvas.paintz.paintTabSoft(g);
		GameCanvas.paintz.paintCmdBar(g, this.left, this.center, this.right);
	}

	// Token: 0x06000676 RID: 1654 RVA: 0x00056388 File Offset: 0x00054588
	public virtual void keyPress(int keyCode)
	{
		switch (keyCode + 7)
		{
		case 0:
			goto IL_CA;
		case 1:
			goto IL_B7;
		case 2:
			goto IL_DD;
		default:
			if (keyCode == -39)
			{
				goto IL_84;
			}
			if (keyCode != -38)
			{
				if (keyCode == -22)
				{
					goto IL_CA;
				}
				if (keyCode == -21)
				{
					goto IL_B7;
				}
				if (keyCode != 10)
				{
					return;
				}
				goto IL_DD;
			}
			break;
		case 5:
			goto IL_84;
		case 6:
			break;
		}
		GameCanvas.keyHold[(!Main.isPC) ? 2 : 21] = true;
		GameCanvas.keyPressed[(!Main.isPC) ? 2 : 21] = true;
		return;
		IL_84:
		GameCanvas.keyHold[(!Main.isPC) ? 8 : 22] = true;
		GameCanvas.keyPressed[(!Main.isPC) ? 8 : 22] = true;
		return;
		IL_B7:
		GameCanvas.keyHold[12] = true;
		GameCanvas.keyPressed[12] = true;
		return;
		IL_CA:
		GameCanvas.keyHold[13] = true;
		GameCanvas.keyPressed[13] = true;
		return;
		IL_DD:
		GameCanvas.keyHold[(!Main.isPC) ? 5 : 25] = true;
		GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] = true;
	}

	// Token: 0x06000677 RID: 1655 RVA: 0x000564A8 File Offset: 0x000546A8
	public virtual void update()
	{
		if (this.center != null && (GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] || mScreen.getCmdPointerLast(this.center)))
		{
			GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] = false;
			GameCanvas.isPointerClick = false;
			mScreen.keyTouch = -1;
			GameCanvas.isPointerJustRelease = false;
			if (this.center != null)
			{
				this.center.performAction();
			}
			mScreen.keyTouch = -1;
		}
		if (this.left != null && (GameCanvas.keyPressed[12] || mScreen.getCmdPointerLast(this.left)))
		{
			GameCanvas.keyPressed[12] = false;
			GameCanvas.isPointerClick = false;
			mScreen.keyTouch = -1;
			GameCanvas.isPointerJustRelease = false;
			if (this.left != null)
			{
				this.left.performAction();
			}
			mScreen.keyTouch = -1;
		}
		if (this.right != null && (GameCanvas.keyPressed[13] || mScreen.getCmdPointerLast(this.right)))
		{
			GameCanvas.keyPressed[13] = false;
			GameCanvas.isPointerClick = false;
			GameCanvas.isPointerJustRelease = false;
			mScreen.keyTouch = -1;
			if (this.right != null)
			{
				this.right.performAction();
			}
			mScreen.keyTouch = -1;
		}
		GameCanvas.clearKeyPressed();
		GameCanvas.clearKeyHold();
	}

	// Token: 0x06000678 RID: 1656 RVA: 0x00003984 File Offset: 0x00001B84
	public virtual void show()
	{
	}

	// Token: 0x04000B95 RID: 2965
	public Command left;

	// Token: 0x04000B96 RID: 2966
	public Command center;

	// Token: 0x04000B97 RID: 2967
	public Command right;

	// Token: 0x04000B98 RID: 2968
	private int lenCaption;
}
