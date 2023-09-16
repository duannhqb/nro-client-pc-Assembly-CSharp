using System;

// Token: 0x020000A9 RID: 169
public class Info_RadaScr
{
	// Token: 0x0600073F RID: 1855 RVA: 0x0006561C File Offset: 0x0006381C
	public void SetInfo(int id, int no, int idIcon, sbyte rank, sbyte typeMonster, short templateId, string name, string info, global::Char charInfo, ItemOption[] itemOption)
	{
		this.id = id;
		this.no = no;
		this.idIcon = idIcon;
		this.rank = rank;
		this.typeMonster = typeMonster;
		if (templateId != -1)
		{
			this.mobInfo = new Mob();
			this.mobInfo.templateId = (int)templateId;
		}
		this.name = name;
		this.info = info;
		this.charInfo = charInfo;
		this.itemOption = itemOption;
		this.addItemDetail();
	}

	// Token: 0x06000740 RID: 1856 RVA: 0x00006F0B File Offset: 0x0000510B
	public void SetAmount(sbyte amount, sbyte max_amount)
	{
		this.amount = amount;
		this.max_amount = max_amount;
	}

	// Token: 0x06000741 RID: 1857 RVA: 0x00006F1B File Offset: 0x0000511B
	public void SetLevel(sbyte level)
	{
		this.level = level;
		this.addItemDetail();
	}

	// Token: 0x06000742 RID: 1858 RVA: 0x00006F2A File Offset: 0x0000512A
	public void SetUse(sbyte isUse)
	{
		this.isUse = isUse;
		this.addItemDetail();
	}

	// Token: 0x06000743 RID: 1859 RVA: 0x00065694 File Offset: 0x00063894
	public static global::Char SetCharInfo(int head, int body, int leg, int bag)
	{
		return new global::Char
		{
			head = head,
			body = body,
			leg = leg,
			bag = bag
		};
	}

	// Token: 0x06000744 RID: 1860 RVA: 0x000656C4 File Offset: 0x000638C4
	public static Info_RadaScr GetInfo(MyVector vec, int id)
	{
		if (vec != null)
		{
			for (int i = 0; i < vec.size(); i++)
			{
				Info_RadaScr info_RadaScr = (Info_RadaScr)vec.elementAt(i);
				if (info_RadaScr != null && info_RadaScr.id == id)
				{
					return info_RadaScr;
				}
			}
		}
		return null;
	}

	// Token: 0x06000745 RID: 1861 RVA: 0x00065710 File Offset: 0x00063910
	public void paintInfo(mGraphics g, int x, int y)
	{
		this.count++;
		if (this.count > this.f.Length - 1)
		{
			this.count = 0;
		}
		if ((int)this.typeMonster == 0)
		{
			if (Mob.arrMobTemplate[this.mobInfo.templateId] != null)
			{
				if (Mob.arrMobTemplate[this.mobInfo.templateId].data != null)
				{
					Mob.arrMobTemplate[this.mobInfo.templateId].data.paintFrame(g, this.f[this.count], x, y, 0, 0);
				}
				else if (this.timeRequest - GameCanvas.timeNow < 0L)
				{
					this.timeRequest = GameCanvas.timeNow + 1500L;
					this.mobInfo.getData();
				}
			}
		}
		else if (this.charInfo != null)
		{
			this.charInfo.paintCharBody(g, x, y, 1, this.f[this.count], true);
		}
	}

	// Token: 0x06000746 RID: 1862 RVA: 0x00065814 File Offset: 0x00063A14
	public void addItemDetail()
	{
		this.cp = new ChatPopup();
		string text = string.Empty;
		string text2 = string.Empty;
		text2 = text2 + "\n|6|" + this.info;
		text2 += "\n--";
		if (this.itemOption != null)
		{
			int num = 0;
			bool flag = true;
			while (flag)
			{
				int num2 = 0;
				for (int i = 0; i < this.itemOption.Length; i++)
				{
					text = this.itemOption[i].getOptionString();
					if (!text.Equals(string.Empty) && num == (int)this.itemOption[i].activeCard)
					{
						num2++;
						break;
					}
				}
				if (num2 == 0)
				{
					break;
				}
				if (num == 0)
				{
					text2 = text2 + "\n|6|2|--" + mResources.unlock + "--";
				}
				else
				{
					string text3 = text2;
					text2 = string.Concat(new object[]
					{
						text3,
						"\n|6|2|--",
						mResources.equip,
						" Lv.",
						num,
						"--"
					});
				}
				for (int j = 0; j < this.itemOption.Length; j++)
				{
					text = this.itemOption[j].getOptionString();
					if (!text.Equals(string.Empty) && num == (int)this.itemOption[j].activeCard)
					{
						string text4 = "1";
						if ((int)this.level == 0)
						{
							text4 = "2";
						}
						else if ((int)this.itemOption[j].activeCard != 0)
						{
							if ((int)this.isUse == 0)
							{
								text4 = "2";
							}
							else if ((int)this.level < (int)this.itemOption[j].activeCard)
							{
								text4 = "2";
							}
						}
						string text3 = text2;
						text2 = string.Concat(new string[]
						{
							text3,
							"\n|",
							text4,
							"|1|",
							text
						});
					}
				}
				if (num2 != 0)
				{
					num++;
				}
			}
		}
		this.popUpDetailInit(this.cp, text2);
	}

	// Token: 0x06000747 RID: 1863 RVA: 0x00065A40 File Offset: 0x00063C40
	public void popUpDetailInit(ChatPopup cp, string chat)
	{
		cp.sayWidth = RadarScr.wText;
		cp.cx = RadarScr.xText;
		cp.says = mFont.tahoma_7.splitFontArray(chat, cp.sayWidth - 8);
		cp.delay = 10000000;
		cp.c = null;
		cp.ch = cp.says.Length * 12;
		cp.cy = RadarScr.yText;
		cp.strY = 10;
		cp.lim = cp.ch - RadarScr.hText;
		if (cp.lim < 0)
		{
			cp.lim = 0;
		}
	}

	// Token: 0x06000748 RID: 1864 RVA: 0x00065AD8 File Offset: 0x00063CD8
	public void SetEff()
	{
		if ((int)this.amount == (int)this.max_amount && this.eff.size() == 0)
		{
			int num = Res.random(1, 5);
			for (int i = 0; i < num; i++)
			{
				Position position = new Position();
				position.x = Res.random(5, 25);
				position.y = Res.random(5, 25);
				position.v = i * Res.random(0, 8);
				position.w = 0;
				position.anchor = -1;
				this.eff.addElement(position);
			}
		}
	}

	// Token: 0x06000749 RID: 1865 RVA: 0x00065B70 File Offset: 0x00063D70
	public void paintEff(mGraphics g, int x, int y)
	{
		this.SetEff();
		for (int i = 0; i < this.eff.size(); i++)
		{
			Position position = (Position)this.eff.elementAt(i);
			if (position != null)
			{
				if (position.w < position.v)
				{
					position.w++;
				}
				if (position.w >= position.v)
				{
					position.anchor = GameCanvas.gameTick / 3 % (RadarScr.fraEff.nFrame + 1);
					if (position.anchor >= RadarScr.fraEff.nFrame)
					{
						this.eff.removeElementAt(i);
						i--;
					}
					else
					{
						RadarScr.fraEff.drawFrame(position.anchor, x + position.x, y + position.y, 0, 3, g);
					}
				}
			}
		}
	}

	// Token: 0x04000D84 RID: 3460
	public const sbyte TYPE_MONSTER = 0;

	// Token: 0x04000D85 RID: 3461
	public const sbyte TYPE_CHARPART = 1;

	// Token: 0x04000D86 RID: 3462
	public sbyte rank;

	// Token: 0x04000D87 RID: 3463
	public sbyte amount;

	// Token: 0x04000D88 RID: 3464
	public sbyte max_amount;

	// Token: 0x04000D89 RID: 3465
	public sbyte typeMonster;

	// Token: 0x04000D8A RID: 3466
	public int id;

	// Token: 0x04000D8B RID: 3467
	public int no;

	// Token: 0x04000D8C RID: 3468
	public int idIcon;

	// Token: 0x04000D8D RID: 3469
	public string name;

	// Token: 0x04000D8E RID: 3470
	public string info;

	// Token: 0x04000D8F RID: 3471
	public sbyte level;

	// Token: 0x04000D90 RID: 3472
	public sbyte isUse;

	// Token: 0x04000D91 RID: 3473
	public global::Char charInfo;

	// Token: 0x04000D92 RID: 3474
	public Mob mobInfo;

	// Token: 0x04000D93 RID: 3475
	public ItemOption[] itemOption;

	// Token: 0x04000D94 RID: 3476
	private int[] f = new int[]
	{
		0,
		0,
		0,
		0,
		0,
		1,
		1,
		1,
		1,
		1
	};

	// Token: 0x04000D95 RID: 3477
	private int count;

	// Token: 0x04000D96 RID: 3478
	private long timeRequest;

	// Token: 0x04000D97 RID: 3479
	public ChatPopup cp;

	// Token: 0x04000D98 RID: 3480
	public MyVector eff = new MyVector(string.Empty);
}
