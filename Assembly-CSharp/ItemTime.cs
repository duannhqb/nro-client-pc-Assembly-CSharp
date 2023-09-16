using System;

// Token: 0x02000065 RID: 101
public class ItemTime
{
	// Token: 0x0600035C RID: 860 RVA: 0x0000397C File Offset: 0x00001B7C
	public ItemTime()
	{
	}

	// Token: 0x0600035D RID: 861 RVA: 0x0001DAA8 File Offset: 0x0001BCA8
	public ItemTime(short idIcon, int s)
	{
		this.idIcon = idIcon;
		this.minute = s / 60;
		this.second = s % 60;
		this.curr = (this.last = mSystem.currentTimeMillis());
	}

	// Token: 0x0600035E RID: 862 RVA: 0x0001DAEC File Offset: 0x0001BCEC
	public void initTimeText(sbyte id, string text, int time)
	{
		if (time == -1)
		{
			this.dontClear = true;
		}
		else
		{
			this.dontClear = false;
		}
		this.isText = true;
		this.minute = time / 60;
		this.second = time % 60;
		this.idIcon = (short)id;
		this.curr = (this.last = mSystem.currentTimeMillis());
		this.text = text;
	}

	// Token: 0x0600035F RID: 863 RVA: 0x0001DB54 File Offset: 0x0001BD54
	public void initTime(int time, bool isText)
	{
		this.minute = time / 60;
		this.second = time % 60;
		this.curr = (this.last = mSystem.currentTimeMillis());
		this.isText = isText;
	}

	// Token: 0x06000360 RID: 864 RVA: 0x0001DB90 File Offset: 0x0001BD90
	public static bool isExistItem(int id)
	{
		for (int i = 0; i < global::Char.vItemTime.size(); i++)
		{
			ItemTime itemTime = (ItemTime)global::Char.vItemTime.elementAt(i);
			if ((int)itemTime.idIcon == id)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000361 RID: 865 RVA: 0x0001DBD8 File Offset: 0x0001BDD8
	public static ItemTime getMessageById(int id)
	{
		for (int i = 0; i < GameScr.textTime.size(); i++)
		{
			ItemTime itemTime = (ItemTime)GameScr.textTime.elementAt(i);
			if ((int)itemTime.idIcon == id)
			{
				return itemTime;
			}
		}
		return null;
	}

	// Token: 0x06000362 RID: 866 RVA: 0x0001DC20 File Offset: 0x0001BE20
	public static bool isExistMessage(int id)
	{
		for (int i = 0; i < GameScr.textTime.size(); i++)
		{
			ItemTime itemTime = (ItemTime)GameScr.textTime.elementAt(i);
			if ((int)itemTime.idIcon == id)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000363 RID: 867 RVA: 0x0001DC68 File Offset: 0x0001BE68
	public static ItemTime getItemById(int id)
	{
		for (int i = 0; i < global::Char.vItemTime.size(); i++)
		{
			ItemTime itemTime = (ItemTime)global::Char.vItemTime.elementAt(i);
			if ((int)itemTime.idIcon == id)
			{
				return itemTime;
			}
		}
		return null;
	}

	// Token: 0x06000364 RID: 868 RVA: 0x0001DCB0 File Offset: 0x0001BEB0
	public void initTime(int time)
	{
		this.minute = time / 60;
		this.second = time % 60;
		this.curr = (this.last = mSystem.currentTimeMillis());
	}

	// Token: 0x06000365 RID: 869 RVA: 0x0001DCE8 File Offset: 0x0001BEE8
	public void paint(mGraphics g, int x, int y)
	{
		SmallImage.drawSmallImage(g, (int)this.idIcon, x, y, 0, 3);
		string st = string.Empty;
		st = this.minute + "'";
		if (this.minute == 0)
		{
			st = this.second + "s";
		}
		mFont.tahoma_7b_white.drawString(g, st, x, y + 15, 2, mFont.tahoma_7b_dark);
	}

	// Token: 0x06000366 RID: 870 RVA: 0x0001DD5C File Offset: 0x0001BF5C
	public void paintText(mGraphics g, int x, int y)
	{
		string str = string.Empty;
		str = this.minute + "'";
		if (this.minute < 1)
		{
			str = this.second + "s";
		}
		if (this.minute < 0)
		{
			str = string.Empty;
		}
		if (this.dontClear)
		{
			str = string.Empty;
		}
		mFont.tahoma_7b_white.drawString(g, this.text + " " + str, x, y, mFont.LEFT, mFont.tahoma_7b_dark);
	}

	// Token: 0x06000367 RID: 871 RVA: 0x0001DDF4 File Offset: 0x0001BFF4
	public void update()
	{
		this.curr = mSystem.currentTimeMillis();
		if (this.curr - this.last >= 1000L)
		{
			this.last = mSystem.currentTimeMillis();
			this.second--;
			if (this.second <= 0)
			{
				this.second = 60;
				this.minute--;
			}
		}
		if (this.minute < 0 && !this.isText)
		{
			global::Char.vItemTime.removeElement(this);
		}
		if (this.minute < 0 && this.isText && !this.dontClear)
		{
			GameScr.textTime.removeElement(this);
		}
	}

	// Token: 0x04000597 RID: 1431
	public short idIcon;

	// Token: 0x04000598 RID: 1432
	public int second;

	// Token: 0x04000599 RID: 1433
	public int minute;

	// Token: 0x0400059A RID: 1434
	private long curr;

	// Token: 0x0400059B RID: 1435
	private long last;

	// Token: 0x0400059C RID: 1436
	private bool isText;

	// Token: 0x0400059D RID: 1437
	private bool dontClear;

	// Token: 0x0400059E RID: 1438
	private string text;
}
