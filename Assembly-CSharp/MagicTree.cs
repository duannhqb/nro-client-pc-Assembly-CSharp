using System;

// Token: 0x02000067 RID: 103
public class MagicTree : Npc, IActionListener
{
	// Token: 0x0600036B RID: 875 RVA: 0x0001DF44 File Offset: 0x0001C144
	public MagicTree(int npcId, int status, int cx, int cy, int templateId, int iconId) : base(npcId, status, cx, cy, templateId, iconId)
	{
		this.p = new PopUp(string.Empty, 0, 0);
		this.p.command = new Command(null, this, 1, null);
		PopUp.addPopUp(this.p);
	}

	// Token: 0x0600036C RID: 876 RVA: 0x0001DF94 File Offset: 0x0001C194
	public override void paint(mGraphics g)
	{
		if (this.id == 0)
		{
			return;
		}
		SmallImage.drawSmallImage(g, this.id, this.cx, this.cy, 0, StaticObj.BOTTOM_HCENTER);
		if (global::Char.myCharz().npcFocus != null && global::Char.myCharz().npcFocus.Equals(this))
		{
			g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 0, this.cx, this.cy - SmallImage.smallImg[this.id][4] - 1, mGraphics.BOTTOM | mGraphics.HCENTER);
			if (this.name != null)
			{
				mFont.tahoma_7b_white.drawString(g, this.name, this.cx, this.cy - SmallImage.smallImg[this.id][4] - 20, mFont.CENTER, mFont.tahoma_7_grey);
			}
		}
		else if (this.name != null)
		{
			mFont.tahoma_7b_white.drawString(g, this.name, this.cx, this.cy - SmallImage.smallImg[this.id][4] - 17, mFont.CENTER, mFont.tahoma_7_grey);
		}
		try
		{
			for (int i = 0; i < this.currPeas; i++)
			{
				g.drawImage(MagicTree.pea, this.cx + this.peaPostionX[i] - SmallImage.smallImg[this.id][3] / 2, this.cy + this.peaPostionY[i] - SmallImage.smallImg[this.id][4], 0);
			}
		}
		catch (Exception ex)
		{
		}
		if (this.indexEffTask >= 0 && this.effTask != null && (int)this.cTypePk == 0)
		{
			SmallImage.drawSmallImage(g, this.effTask.arrEfInfo[this.indexEffTask].idImg, this.cx + this.effTask.arrEfInfo[this.indexEffTask].dx + SmallImage.smallImg[this.id][3] / 2 + 5, this.cy - 15 + this.effTask.arrEfInfo[this.indexEffTask].dy, 0, mGraphics.VCENTER | mGraphics.HCENTER);
			if (GameCanvas.gameTick % 2 == 0)
			{
				this.indexEffTask++;
				if (this.indexEffTask >= this.effTask.arrEfInfo.Length)
				{
					this.indexEffTask = 0;
				}
			}
		}
	}

	// Token: 0x0600036D RID: 877 RVA: 0x0001E208 File Offset: 0x0001C408
	public override void update()
	{
		this.p.isPaint = MagicTree.isPaint;
		this.cur = mSystem.currentTimeMillis();
		if (this.cur - this.last >= 1000L)
		{
			this.seconds--;
			this.last = this.cur;
			if (this.seconds < 0)
			{
				this.seconds = 0;
			}
		}
		if (!this.isUpdate)
		{
			if (this.currPeas < this.maxPeas && this.seconds == 0)
			{
				this.waitToUpdate = true;
			}
		}
		else if (this.seconds == 0)
		{
			this.isUpdate = false;
			this.waitToUpdate = true;
		}
		if (this.waitToUpdate)
		{
			this.delay++;
			if (this.delay == 20)
			{
				this.delay = 0;
				this.waitToUpdate = false;
				Service.gI().getMagicTree(2);
			}
		}
		this.num = ((this.peaPostionX == null) ? 0 : (this.peaPostionX.Length * this.currPeas / this.maxPeas));
		if (this.isUpdateTree)
		{
			this.isUpdateTree = false;
			if ((this.seconds >= 0 && this.currPeas < this.maxPeas) || (this.seconds >= 0 && this.isUpdate) || this.isPeasEffect)
			{
				this.p.updateXYWH(new string[]
				{
					this.isUpdate ? mResources.UPGRADING : (this.currPeas + "/" + this.maxPeas),
					NinjaUtil.getTime(this.seconds)
				}, this.cx, this.cy - 20 - SmallImage.smallImg[this.id][4]);
			}
			else if (this.currPeas == this.maxPeas && !this.isUpdate)
			{
				this.p.updateXYWH(new string[]
				{
					mResources.can_harvest,
					this.currPeas + "/" + this.maxPeas
				}, this.cx, this.cy - 20 - SmallImage.smallImg[this.id][4]);
			}
		}
		if ((this.seconds >= 0 && this.currPeas < this.maxPeas) || (this.seconds >= 0 && this.isUpdate))
		{
			this.p.says[this.p.says.Length - 1] = NinjaUtil.getTime(this.seconds);
		}
		if (this.isPeasEffect)
		{
			this.p.isPaint = false;
			ServerEffect.addServerEffect(98, this.cx + this.peaPostionX[this.currPeas - 1] - SmallImage.smallImg[this.id][3] / 2, this.cy + this.peaPostionY[this.currPeas - 1] - SmallImage.smallImg[this.id][4], 1);
			this.currPeas--;
			if (GameCanvas.gameTick % 2 == 0)
			{
				SoundMn.gI().HP_MPup();
			}
			if (this.currPeas == this.remainPeas)
			{
				this.p.isPaint = true;
				this.isUpdateTree = true;
				this.isPeasEffect = false;
			}
		}
		base.update();
	}

	// Token: 0x0600036E RID: 878 RVA: 0x000054B3 File Offset: 0x000036B3
	public void perform(int idAction, object p)
	{
		if (idAction == 1)
		{
			Service.gI().magicTree(1);
		}
	}

	// Token: 0x040005B4 RID: 1460
	public static Image imgMagicTree;

	// Token: 0x040005B5 RID: 1461
	public static Image pea = GameCanvas.loadImage("/mainImage/myTexture2dhatdau.png");

	// Token: 0x040005B6 RID: 1462
	public int id;

	// Token: 0x040005B7 RID: 1463
	public int level;

	// Token: 0x040005B8 RID: 1464
	public int x;

	// Token: 0x040005B9 RID: 1465
	public int y;

	// Token: 0x040005BA RID: 1466
	public int currPeas;

	// Token: 0x040005BB RID: 1467
	public int remainPeas;

	// Token: 0x040005BC RID: 1468
	public int maxPeas;

	// Token: 0x040005BD RID: 1469
	public new string strInfo;

	// Token: 0x040005BE RID: 1470
	public string name;

	// Token: 0x040005BF RID: 1471
	public int timeToRecieve;

	// Token: 0x040005C0 RID: 1472
	public bool isUpdate;

	// Token: 0x040005C1 RID: 1473
	public int[] peaPostionX;

	// Token: 0x040005C2 RID: 1474
	public int[] peaPostionY;

	// Token: 0x040005C3 RID: 1475
	private int num;

	// Token: 0x040005C4 RID: 1476
	public PopUp p;

	// Token: 0x040005C5 RID: 1477
	public bool isUpdateTree;

	// Token: 0x040005C6 RID: 1478
	public new static bool isPaint = true;

	// Token: 0x040005C7 RID: 1479
	public bool isPeasEffect;

	// Token: 0x040005C8 RID: 1480
	public new int seconds;

	// Token: 0x040005C9 RID: 1481
	public new long last;

	// Token: 0x040005CA RID: 1482
	public new long cur;

	// Token: 0x040005CB RID: 1483
	private int wPopUp;

	// Token: 0x040005CC RID: 1484
	private bool waitToUpdate;

	// Token: 0x040005CD RID: 1485
	private int delay;
}
