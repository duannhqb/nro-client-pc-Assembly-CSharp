using System;

// Token: 0x020000B9 RID: 185
public class mScreen
{
	// Token: 0x0600090D RID: 2317 RVA: 0x00007952 File Offset: 0x00005B52
	public virtual void switchToMe()
	{
		GameCanvas.clearKeyPressed();
		GameCanvas.clearKeyHold();
		if (GameCanvas.currentScreen != null)
		{
			GameCanvas.currentScreen.unLoad();
		}
		GameCanvas.currentScreen = this;
		Cout.LogError3("cur Screen: " + GameCanvas.currentScreen);
	}

	// Token: 0x0600090E RID: 2318 RVA: 0x00003984 File Offset: 0x00001B84
	public virtual void unLoad()
	{
	}

	// Token: 0x0600090F RID: 2319 RVA: 0x00003984 File Offset: 0x00001B84
	public static void initPos()
	{
	}

	// Token: 0x06000910 RID: 2320 RVA: 0x00003984 File Offset: 0x00001B84
	public virtual void keyPress(int keyCode)
	{
	}

	// Token: 0x06000911 RID: 2321 RVA: 0x00003984 File Offset: 0x00001B84
	public virtual void update()
	{
	}

	// Token: 0x06000912 RID: 2322 RVA: 0x00087AF8 File Offset: 0x00085CF8
	public virtual void updateKey()
	{
		if (GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] || mScreen.getCmdPointerLast(GameCanvas.currentScreen.center))
		{
			GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] = false;
			mScreen.keyTouch = -1;
			GameCanvas.isPointerJustRelease = false;
			if (this.center != null)
			{
				this.center.performAction();
			}
		}
		if (GameCanvas.keyPressed[12] || mScreen.getCmdPointerLast(GameCanvas.currentScreen.left))
		{
			GameCanvas.keyPressed[12] = false;
			mScreen.keyTouch = -1;
			GameCanvas.isPointerJustRelease = false;
			if (ChatTextField.gI().isShow)
			{
				if (ChatTextField.gI().left != null)
				{
					ChatTextField.gI().left.performAction();
				}
			}
			else if (this.left != null)
			{
				this.left.performAction();
			}
		}
		if (GameCanvas.keyPressed[13] || mScreen.getCmdPointerLast(GameCanvas.currentScreen.right))
		{
			GameCanvas.keyPressed[13] = false;
			mScreen.keyTouch = -1;
			GameCanvas.isPointerJustRelease = false;
			if (ChatTextField.gI().isShow)
			{
				if (ChatTextField.gI().right != null)
				{
					ChatTextField.gI().right.performAction();
				}
			}
			else if (this.right != null)
			{
				this.right.performAction();
			}
		}
	}

	// Token: 0x06000913 RID: 2323 RVA: 0x00087C70 File Offset: 0x00085E70
	public static bool getCmdPointerLast(Command cmd)
	{
		if (cmd == null)
		{
			return false;
		}
		if (cmd.x >= 0 && cmd.y != 0)
		{
			return cmd.isPointerPressInside();
		}
		if (GameCanvas.currentDialog != null)
		{
			if (GameCanvas.currentDialog.center != null && GameCanvas.isPointerHoldIn(GameCanvas.w - mScreen.cmdW >> 1, GameCanvas.h - mScreen.cmdH - 5, mScreen.cmdW, mScreen.cmdH + 10))
			{
				mScreen.keyTouch = 1;
				if (cmd == GameCanvas.currentDialog.center && GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
				{
					return true;
				}
			}
			if (GameCanvas.currentDialog.left != null && GameCanvas.isPointerHoldIn(0, GameCanvas.h - mScreen.cmdH - 5, mScreen.cmdW, mScreen.cmdH + 10))
			{
				mScreen.keyTouch = 0;
				if (cmd == GameCanvas.currentDialog.left && GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
				{
					return true;
				}
			}
			if (GameCanvas.currentDialog.right != null && GameCanvas.isPointerHoldIn(GameCanvas.w - mScreen.cmdW, GameCanvas.h - mScreen.cmdH - 5, mScreen.cmdW, mScreen.cmdH + 10))
			{
				mScreen.keyTouch = 2;
				if ((cmd == GameCanvas.currentDialog.right || cmd == ChatTextField.gI().right) && GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
				{
					return true;
				}
			}
		}
		else
		{
			if (cmd == GameCanvas.currentScreen.left && GameCanvas.isPointerHoldIn(0, GameCanvas.h - mScreen.cmdH - 5, mScreen.cmdW, mScreen.cmdH + 10))
			{
				mScreen.keyTouch = 0;
				if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
				{
					return true;
				}
			}
			if (cmd == GameCanvas.currentScreen.right && GameCanvas.isPointerHoldIn(GameCanvas.w - mScreen.cmdW, GameCanvas.h - mScreen.cmdH - 5, mScreen.cmdW, mScreen.cmdH + 10))
			{
				mScreen.keyTouch = 2;
				if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
				{
					return true;
				}
			}
			if ((cmd == GameCanvas.currentScreen.center || ChatPopup.currChatPopup != null) && GameCanvas.isPointerHoldIn(GameCanvas.w - mScreen.cmdW >> 1, GameCanvas.h - mScreen.cmdH - 5, mScreen.cmdW, mScreen.cmdH + 10))
			{
				mScreen.keyTouch = 1;
				if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06000914 RID: 2324 RVA: 0x00087F0C File Offset: 0x0008610C
	public virtual void paint(mGraphics g)
	{
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h + 1);
		if (!ChatTextField.gI().isShow || !Main.isPC)
		{
			if (GameCanvas.currentDialog == null && !GameCanvas.menu.showMenu)
			{
				GameCanvas.paintz.paintCmdBar(g, this.left, this.center, this.right);
			}
		}
	}

	// Token: 0x0400107E RID: 4222
	public Command left;

	// Token: 0x0400107F RID: 4223
	public Command center;

	// Token: 0x04001080 RID: 4224
	public Command right;

	// Token: 0x04001081 RID: 4225
	public Command cmdClose;

	// Token: 0x04001082 RID: 4226
	public static int ITEM_HEIGHT;

	// Token: 0x04001083 RID: 4227
	public static int yOpenKeyBoard = 100;

	// Token: 0x04001084 RID: 4228
	public static int cmdW = 68;

	// Token: 0x04001085 RID: 4229
	public static int cmdH = 26;

	// Token: 0x04001086 RID: 4230
	public static int keyTouch = -1;

	// Token: 0x04001087 RID: 4231
	public static int keyMouse = -1;
}
