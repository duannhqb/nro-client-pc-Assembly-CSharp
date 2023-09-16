using System;

// Token: 0x02000091 RID: 145
public class Waypoint : IActionListener
{
	// Token: 0x06000452 RID: 1106 RVA: 0x00028964 File Offset: 0x00026B64
	public Waypoint(short minX, short minY, short maxX, short maxY, bool isEnter, bool isOffline, string name)
	{
		this.minX = minX;
		this.minY = minY;
		this.maxX = maxX;
		this.maxY = maxY;
		name = Res.changeString(name);
		this.isEnter = isEnter;
		this.isOffline = isOffline;
		if ((TileMap.mapID == 21 || TileMap.mapID == 22 || TileMap.mapID == 23) && this.minX >= 0 && this.minX <= 24)
		{
			return;
		}
		if (((TileMap.mapID == 0 && global::Char.myCharz().cgender != 0) || (TileMap.mapID == 7 && global::Char.myCharz().cgender != 1) || (TileMap.mapID == 14 && global::Char.myCharz().cgender != 2)) && isOffline)
		{
			return;
		}
		if (!TileMap.isInAirMap() && TileMap.mapID != 47)
		{
			if (!isEnter && !isOffline)
			{
				this.popup = new PopUp(name, (int)minX, (int)(minY - 24));
				this.popup.command = new Command(null, this, 1, this);
				this.popup.isWayPoint = true;
				this.popup.isPaint = false;
				PopUp.addPopUp(this.popup);
			}
			else
			{
				if (TileMap.isTrainingMap())
				{
					this.popup = new PopUp(name, (int)minX, (int)(minY - 16));
				}
				else
				{
					int x = (int)(minX + (maxX - minX) / 2);
					this.popup = new PopUp(name, x, (int)(minY - ((minY == 0) ? -32 : 16)));
				}
				this.popup.command = new Command(null, this, 2, this);
				this.popup.isWayPoint = true;
				this.popup.isPaint = false;
				PopUp.addPopUp(this.popup);
			}
			TileMap.vGo.addElement(this);
			return;
		}
		if (minY > 150 && TileMap.isInAirMap())
		{
			return;
		}
		this.popup = new PopUp(name, (int)(minX + (maxX - minX) / 2), (int)(maxY - ((minX <= 100) ? 48 : 24)));
		this.popup.command = new Command(null, this, 1, this);
		this.popup.isWayPoint = true;
		this.popup.isPaint = false;
		PopUp.addPopUp(this.popup);
		TileMap.vGo.addElement(this);
	}

	// Token: 0x06000453 RID: 1107 RVA: 0x00028BC0 File Offset: 0x00026DC0
	public void perform(int idAction, object p)
	{
		if (idAction != 1)
		{
			if (idAction == 2)
			{
				GameScr.gI().auto = 0;
				if (global::Char.myCharz().isInEnterOfflinePoint() != null)
				{
					Service.gI().charMove();
					InfoDlg.showWait();
					Service.gI().getMapOffline();
					global::Char.ischangingMap = true;
				}
				else if (global::Char.myCharz().isInEnterOnlinePoint() != null)
				{
					Service.gI().charMove();
					Service.gI().requestChangeMap();
					global::Char.isLockKey = true;
					global::Char.ischangingMap = true;
					GameCanvas.clearKeyHold();
					GameCanvas.clearKeyPressed();
					InfoDlg.showWait();
				}
				else
				{
					int xEnd = (int)((this.minX + this.maxX) / 2);
					int yEnd = (int)this.maxY;
					global::Char.myCharz().currentMovePoint = new MovePoint(xEnd, yEnd);
					global::Char.myCharz().cdir = ((global::Char.myCharz().cx - global::Char.myCharz().currentMovePoint.xEnd <= 0) ? 1 : -1);
					global::Char.myCharz().endMovePointCommand = new Command(null, this, 2, null);
				}
			}
		}
		else
		{
			int xEnd2 = (int)((this.minX + this.maxX) / 2);
			int yEnd2 = (int)this.maxY;
			if (this.maxY > this.minY + 24)
			{
				yEnd2 = (int)((this.minY + this.maxY) / 2);
			}
			GameScr.gI().auto = 0;
			global::Char.myCharz().currentMovePoint = new MovePoint(xEnd2, yEnd2);
			global::Char.myCharz().cdir = ((global::Char.myCharz().cx - global::Char.myCharz().currentMovePoint.xEnd <= 0) ? 1 : -1);
			Service.gI().charMove();
		}
	}

	// Token: 0x04000749 RID: 1865
	public short minX;

	// Token: 0x0400074A RID: 1866
	public short minY;

	// Token: 0x0400074B RID: 1867
	public short maxX;

	// Token: 0x0400074C RID: 1868
	public short maxY;

	// Token: 0x0400074D RID: 1869
	public bool isEnter;

	// Token: 0x0400074E RID: 1870
	public bool isOffline;

	// Token: 0x0400074F RID: 1871
	public PopUp popup;
}
