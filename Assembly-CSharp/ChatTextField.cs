using System;

// Token: 0x0200009C RID: 156
public class ChatTextField : IActionListener
{
	// Token: 0x0600063C RID: 1596 RVA: 0x00052454 File Offset: 0x00050654
	public ChatTextField()
	{
		this.tfChat = new TField();
		if (Main.isWindowsPhone)
		{
			this.tfChat.showSubTextField = false;
		}
		if (Main.isIPhone)
		{
			this.tfChat.isPaintMouse = false;
		}
		this.tfChat.name = "chat";
		if (Main.isWindowsPhone)
		{
			this.tfChat.strInfo = this.tfChat.name;
		}
		this.tfChat.width = GameCanvas.w - 6;
		if (Main.isPC && this.tfChat.width > 250)
		{
			this.tfChat.width = 250;
		}
		this.tfChat.height = mScreen.ITEM_HEIGHT + 2;
		this.tfChat.x = GameCanvas.w / 2 - this.tfChat.width / 2;
		this.tfChat.isFocus = true;
		this.tfChat.setMaxTextLenght(80);
	}

	// Token: 0x0600063D RID: 1597 RVA: 0x00052568 File Offset: 0x00050768
	public void initChatTextField()
	{
		this.left = new Command(mResources.OK, this, 8000, null, 1, GameCanvas.h - mScreen.cmdH + 1);
		this.right = new Command(mResources.DELETE, this, 8001, null, GameCanvas.w - 70, GameCanvas.h - mScreen.cmdH + 1);
		this.center = null;
		this.w = this.tfChat.width + 20;
		this.h = this.tfChat.height + 26;
		this.x = GameCanvas.w / 2 - this.w / 2;
		this.y = this.tfChat.y - 18;
		if (Main.isPC && this.w > 320)
		{
			this.w = 320;
		}
		this.left.x = this.x;
		this.right.x = this.x + this.w - 68;
		if (GameCanvas.isTouch)
		{
			this.tfChat.y -= 5;
			this.y -= 20;
			this.h += 30;
			this.left.x = GameCanvas.w / 2 - 68 - 5;
			this.right.x = GameCanvas.w / 2 + 5;
			this.left.y = GameCanvas.h - 30;
			this.right.y = GameCanvas.h - 30;
		}
		this.cmdChat = new Command();
		ActionChat actionChat = delegate(string str)
		{
			this.tfChat.justReturnFromTextBox = false;
			this.tfChat.setText(str);
			this.parentScreen.onChatFromMe(str, this.to);
			this.tfChat.setText(string.Empty);
			this.right.caption = mResources.CLOSE;
		};
		this.cmdChat.actionChat = actionChat;
		this.cmdChat2 = new Command();
		this.cmdChat2.actionChat = delegate(string str)
		{
			this.tfChat.justReturnFromTextBox = false;
			if (this.parentScreen != null)
			{
				this.tfChat.setText(str);
				this.parentScreen.onChatFromMe(str, this.to);
				this.tfChat.setText(string.Empty);
				this.tfChat.clearKb();
				if (this.right != null)
				{
					this.right.performAction();
				}
			}
			this.isShow = false;
		};
		this.yBegin = this.tfChat.y;
		this.yUp = GameCanvas.h / 2 - 2 * this.tfChat.height;
		if (Main.isWindowsPhone)
		{
			this.tfChat.showSubTextField = false;
		}
		if (Main.isIPhone)
		{
			this.tfChat.isPaintMouse = false;
		}
	}

	// Token: 0x0600063E RID: 1598 RVA: 0x00003984 File Offset: 0x00001B84
	public void updateWhenKeyBoardVisible()
	{
	}

	// Token: 0x0600063F RID: 1599 RVA: 0x0005279C File Offset: 0x0005099C
	public void keyPressed(int keyCode)
	{
		if (this.isShow)
		{
			this.tfChat.keyPressed(keyCode);
		}
		if (this.tfChat.getText().Equals(string.Empty))
		{
			this.right.caption = mResources.CLOSE;
		}
		else
		{
			this.right.caption = mResources.DELETE;
		}
	}

	// Token: 0x06000640 RID: 1600 RVA: 0x00006983 File Offset: 0x00004B83
	public static ChatTextField gI()
	{
		return (ChatTextField.instance != null) ? ChatTextField.instance : (ChatTextField.instance = new ChatTextField());
	}

	// Token: 0x06000641 RID: 1601 RVA: 0x00052800 File Offset: 0x00050A00
	public void startChat(int firstCharacter, IChatable parentScreen, string to)
	{
		this.right.caption = mResources.CLOSE;
		this.to = to;
		if (Main.isWindowsPhone)
		{
			this.tfChat.showSubTextField = false;
		}
		if (Main.isIPhone)
		{
			this.tfChat.isPaintMouse = false;
		}
		this.tfChat.keyPressed(firstCharacter);
		if (!this.tfChat.getText().Equals(string.Empty) && GameCanvas.currentDialog == null)
		{
			this.parentScreen = parentScreen;
			this.isShow = true;
		}
	}

	// Token: 0x06000642 RID: 1602 RVA: 0x00052890 File Offset: 0x00050A90
	public void startChat(IChatable parentScreen, string to)
	{
		this.right.caption = mResources.CLOSE;
		this.to = to;
		if (Main.isWindowsPhone)
		{
			this.tfChat.showSubTextField = false;
		}
		if (Main.isIPhone)
		{
			this.tfChat.isPaintMouse = false;
		}
		if (GameCanvas.currentDialog == null)
		{
			this.isShow = true;
			this.tfChat.isFocus = true;
			if (!Main.isPC)
			{
				ipKeyboard.openKeyBoard(this.strChat, ipKeyboard.TEXT, string.Empty, this.cmdChat);
				this.tfChat.setFocusWithKb(true);
			}
		}
		this.tfChat.setText(string.Empty);
		this.tfChat.clearAll();
		this.isPublic = false;
	}

	// Token: 0x06000643 RID: 1603 RVA: 0x00052950 File Offset: 0x00050B50
	public void startChat2(IChatable parentScreen, string to)
	{
		this.tfChat.setFocusWithKb(true);
		this.to = to;
		this.parentScreen = parentScreen;
		if (Main.isWindowsPhone)
		{
			this.tfChat.showSubTextField = false;
		}
		if (Main.isIPhone)
		{
			this.tfChat.isPaintMouse = false;
		}
		if (GameCanvas.currentDialog == null)
		{
			this.isShow = true;
			if (!Main.isPC)
			{
				ipKeyboard.openKeyBoard(this.strChat, ipKeyboard.TEXT, string.Empty, this.cmdChat2);
				this.tfChat.setFocusWithKb(true);
			}
		}
		this.tfChat.setText(string.Empty);
		this.tfChat.clearAll();
		this.isPublic = false;
	}

	// Token: 0x06000644 RID: 1604 RVA: 0x00003984 File Offset: 0x00001B84
	public void updateKey()
	{
	}

	// Token: 0x06000645 RID: 1605 RVA: 0x00052A08 File Offset: 0x00050C08
	public void update()
	{
		if (!this.isShow)
		{
			return;
		}
		this.tfChat.update();
		if (Main.isWindowsPhone)
		{
			this.updateWhenKeyBoardVisible();
		}
		if (this.tfChat.justReturnFromTextBox)
		{
			this.tfChat.justReturnFromTextBox = false;
			this.parentScreen.onChatFromMe(this.tfChat.getText(), this.to);
			this.tfChat.setText(string.Empty);
			this.right.caption = mResources.CLOSE;
		}
		if (Main.isPC)
		{
			if (GameCanvas.keyPressed[15])
			{
				if (this.left != null && this.tfChat.getText() != string.Empty)
				{
					this.left.performAction();
				}
				GameCanvas.keyPressed[15] = false;
				GameCanvas.keyPressed[(!Main.isPC) ? 5 : 25] = false;
			}
			if (GameCanvas.keyPressed[14])
			{
				if (this.right != null)
				{
					this.right.performAction();
				}
				GameCanvas.keyPressed[14] = false;
			}
		}
	}

	// Token: 0x06000646 RID: 1606 RVA: 0x000069A4 File Offset: 0x00004BA4
	public void close()
	{
		this.tfChat.setText(string.Empty);
		this.isShow = false;
	}

	// Token: 0x06000647 RID: 1607 RVA: 0x00052B2C File Offset: 0x00050D2C
	public void paint(mGraphics g)
	{
		if (!this.isShow)
		{
			return;
		}
		if (Main.isIPhone)
		{
			return;
		}
		int num = (!Main.isWindowsPhone) ? (this.y - this.KC) : (this.tfChat.y - 5);
		int num2 = (!Main.isWindowsPhone) ? this.x : 0;
		int num3 = (!Main.isWindowsPhone) ? this.w : GameCanvas.w;
		PopUp.paintPopUp(g, num2, num, num3, this.h, -1, true);
		if (Main.isPC)
		{
			mFont.tahoma_7b_green2.drawString(g, this.strChat + this.to, this.tfChat.x, this.tfChat.y - ((!GameCanvas.isTouch) ? 12 : 17), 0);
			GameCanvas.paintz.paintCmdBar(g, this.left, this.center, this.right);
		}
		this.tfChat.paint(g);
	}

	// Token: 0x06000648 RID: 1608 RVA: 0x00052C38 File Offset: 0x00050E38
	public void perform(int idAction, object p)
	{
		switch (idAction)
		{
		case 8000:
			Cout.LogError("perform chat 8000");
			if (this.parentScreen != null)
			{
				long num = mSystem.currentTimeMillis();
				if (num - this.lastChatTime < 1000L)
				{
					return;
				}
				this.lastChatTime = num;
				this.parentScreen.onChatFromMe(this.tfChat.getText(), this.to);
				this.tfChat.setText(string.Empty);
				this.right.caption = mResources.CLOSE;
				this.tfChat.clearKb();
			}
			break;
		case 8001:
			Cout.LogError("perform chat 8001");
			if (this.tfChat.getText().Equals(string.Empty))
			{
				this.isShow = false;
				this.parentScreen.onCancelChat();
			}
			this.tfChat.clear();
			break;
		}
	}

	// Token: 0x04000B38 RID: 2872
	private static ChatTextField instance;

	// Token: 0x04000B39 RID: 2873
	public TField tfChat;

	// Token: 0x04000B3A RID: 2874
	public bool isShow;

	// Token: 0x04000B3B RID: 2875
	public IChatable parentScreen;

	// Token: 0x04000B3C RID: 2876
	private long lastChatTime;

	// Token: 0x04000B3D RID: 2877
	public Command left;

	// Token: 0x04000B3E RID: 2878
	public Command cmdChat;

	// Token: 0x04000B3F RID: 2879
	public Command right;

	// Token: 0x04000B40 RID: 2880
	public Command center;

	// Token: 0x04000B41 RID: 2881
	private int x;

	// Token: 0x04000B42 RID: 2882
	private int y;

	// Token: 0x04000B43 RID: 2883
	private int w;

	// Token: 0x04000B44 RID: 2884
	private int h;

	// Token: 0x04000B45 RID: 2885
	private bool isPublic;

	// Token: 0x04000B46 RID: 2886
	public Command cmdChat2;

	// Token: 0x04000B47 RID: 2887
	public int yBegin;

	// Token: 0x04000B48 RID: 2888
	public int yUp;

	// Token: 0x04000B49 RID: 2889
	public int KC;

	// Token: 0x04000B4A RID: 2890
	public string to;

	// Token: 0x04000B4B RID: 2891
	public string strChat = "Chat ";
}
