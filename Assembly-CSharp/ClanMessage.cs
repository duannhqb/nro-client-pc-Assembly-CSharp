using System;

// Token: 0x02000033 RID: 51
public class ClanMessage : IActionListener
{
	// Token: 0x06000220 RID: 544 RVA: 0x00012298 File Offset: 0x00010498
	public static void addMessage(ClanMessage cm, int index, bool upToTop)
	{
		for (int i = 0; i < ClanMessage.vMessage.size(); i++)
		{
			ClanMessage clanMessage = (ClanMessage)ClanMessage.vMessage.elementAt(i);
			if (clanMessage.id == cm.id)
			{
				ClanMessage.vMessage.removeElement(clanMessage);
				if (!upToTop)
				{
					ClanMessage.vMessage.insertElementAt(cm, i);
				}
				else
				{
					ClanMessage.vMessage.insertElementAt(cm, 0);
				}
				return;
			}
			if (clanMessage.maxCap != 0 && clanMessage.recieve == clanMessage.maxCap)
			{
				ClanMessage.vMessage.removeElement(clanMessage);
			}
		}
		if (index == -1)
		{
			ClanMessage.vMessage.addElement(cm);
		}
		else
		{
			ClanMessage.vMessage.insertElementAt(cm, 0);
		}
		if (ClanMessage.vMessage.size() > 20)
		{
			ClanMessage.vMessage.removeElementAt(ClanMessage.vMessage.size() - 1);
		}
	}

	// Token: 0x06000221 RID: 545 RVA: 0x00012384 File Offset: 0x00010584
	public void paint(mGraphics g, int x, int y)
	{
		mFont mFont = mFont.tahoma_7b_dark;
		if ((int)this.role == 0)
		{
			mFont = mFont.tahoma_7b_red;
		}
		else if ((int)this.role == 1)
		{
			mFont = mFont.tahoma_7b_green;
		}
		else if ((int)this.role == 2)
		{
			mFont = mFont.tahoma_7b_green2;
		}
		if (this.type == 0)
		{
			mFont.drawString(g, this.playerName, x + 3, y + 1, 0);
			if ((int)this.color == 0)
			{
				mFont.tahoma_7_grey.drawString(g, this.chat[0] + ((this.chat.Length <= 1) ? string.Empty : "..."), x + 3, y + 11, 0);
			}
			else
			{
				mFont.tahoma_7_red.drawString(g, this.chat[0] + ((this.chat.Length <= 1) ? string.Empty : "..."), x + 3, y + 11, 0);
			}
			mFont.tahoma_7_grey.drawString(g, NinjaUtil.getTimeAgo(this.timeAgo) + " " + mResources.ago, x + GameCanvas.panel.wScroll - 3, y + 1, mFont.RIGHT);
		}
		if (this.type == 1)
		{
			mFont.drawString(g, string.Concat(new object[]
			{
				this.playerName,
				" (",
				this.recieve,
				"/",
				this.maxCap,
				")"
			}), x + 3, y + 1, 0);
			mFont.tahoma_7_blue.drawString(g, string.Concat(new string[]
			{
				mResources.request_pea,
				" ",
				NinjaUtil.getTimeAgo(this.timeAgo),
				" ",
				mResources.ago
			}), x + 3, y + 11, 0);
		}
		if (this.type == 2)
		{
			mFont.drawString(g, this.playerName, x + 3, y + 1, 0);
			mFont.tahoma_7_blue.drawString(g, mResources.request_join_clan, x + 3, y + 11, 0);
		}
	}

	// Token: 0x06000222 RID: 546 RVA: 0x00003984 File Offset: 0x00001B84
	public void perform(int idAction, object p)
	{
	}

	// Token: 0x06000223 RID: 547 RVA: 0x00004BD3 File Offset: 0x00002DD3
	public void update()
	{
		if (this.time != 0L)
		{
			this.timeAgo = (int)(mSystem.currentTimeMillis() / 1000L - this.time);
		}
	}

	// Token: 0x040001FA RID: 506
	public int id;

	// Token: 0x040001FB RID: 507
	public int type;

	// Token: 0x040001FC RID: 508
	public int playerId;

	// Token: 0x040001FD RID: 509
	public string playerName;

	// Token: 0x040001FE RID: 510
	public long time;

	// Token: 0x040001FF RID: 511
	public int headId;

	// Token: 0x04000200 RID: 512
	public string[] chat;

	// Token: 0x04000201 RID: 513
	public sbyte color;

	// Token: 0x04000202 RID: 514
	public sbyte role;

	// Token: 0x04000203 RID: 515
	private int timeAgo;

	// Token: 0x04000204 RID: 516
	public int recieve;

	// Token: 0x04000205 RID: 517
	public int maxCap;

	// Token: 0x04000206 RID: 518
	public string[] option;

	// Token: 0x04000207 RID: 519
	public static MyVector vMessage = new MyVector();
}
