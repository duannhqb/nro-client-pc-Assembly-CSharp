using System;

// Token: 0x0200003C RID: 60
public class EffectData
{
	// Token: 0x0600026F RID: 623 RVA: 0x000165D8 File Offset: 0x000147D8
	public ImageInfo getImageInfo(sbyte id)
	{
		for (int i = 0; i < this.imgInfo.Length; i++)
		{
			if (this.imgInfo[i].ID == (int)id)
			{
				return this.imgInfo[i];
			}
		}
		return null;
	}

	// Token: 0x06000270 RID: 624 RVA: 0x0001661C File Offset: 0x0001481C
	public void readData(string patch)
	{
		DataInputStream dataInputStream = null;
		try
		{
			dataInputStream = MyStream.readFile(patch);
		}
		catch (Exception ex)
		{
			return;
		}
		this.readData(dataInputStream.r);
	}

	// Token: 0x06000271 RID: 625 RVA: 0x0001665C File Offset: 0x0001485C
	public void readData2(string patch)
	{
		DataInputStream dataInputStream = null;
		try
		{
			dataInputStream = MyStream.readFile(patch);
		}
		catch (Exception ex)
		{
			return;
		}
		this.readEffect(dataInputStream.r);
	}

	// Token: 0x06000272 RID: 626 RVA: 0x0001669C File Offset: 0x0001489C
	public void readEffect(myReader msg)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		try
		{
			sbyte b = msg.readByte();
			Res.outz("size IMG==========" + b);
			this.imgInfo = new ImageInfo[(int)b];
			for (int i = 0; i < (int)b; i++)
			{
				this.imgInfo[i] = new ImageInfo();
				this.imgInfo[i].ID = (int)msg.readByte();
				this.imgInfo[i].x0 = (int)msg.readUnsignedByte();
				this.imgInfo[i].y0 = (int)msg.readUnsignedByte();
				this.imgInfo[i].w = (int)msg.readUnsignedByte();
				this.imgInfo[i].h = (int)msg.readUnsignedByte();
			}
			short num5 = msg.readShort();
			this.frame = new Frame[(int)num5];
			for (int j = 0; j < this.frame.Length; j++)
			{
				this.frame[j] = new Frame();
				sbyte b2 = msg.readByte();
				this.frame[j].dx = new short[(int)b2];
				this.frame[j].dy = new short[(int)b2];
				this.frame[j].idImg = new sbyte[(int)b2];
				for (int k = 0; k < (int)b2; k++)
				{
					this.frame[j].dx[k] = msg.readShort();
					this.frame[j].dy[k] = msg.readShort();
					this.frame[j].idImg[k] = msg.readByte();
					if (j == 0)
					{
						if (num > (int)this.frame[j].dx[k])
						{
							num = (int)this.frame[j].dx[k];
						}
						if (num2 > (int)this.frame[j].dy[k])
						{
							num2 = (int)this.frame[j].dy[k];
						}
						if (num3 < (int)this.frame[j].dx[k] + this.imgInfo[(int)this.frame[j].idImg[k]].w)
						{
							num3 = (int)this.frame[j].dx[k] + this.imgInfo[(int)this.frame[j].idImg[k]].w;
						}
						if (num4 < (int)this.frame[j].dy[k] + this.imgInfo[(int)this.frame[j].idImg[k]].h)
						{
							num4 = (int)this.frame[j].dy[k] + this.imgInfo[(int)this.frame[j].idImg[k]].h;
						}
						this.width = num3 - num;
						this.height = num4 - num2;
					}
				}
			}
			this.arrFrame = new short[(int)msg.readShort()];
			for (int l = 0; l < this.arrFrame.Length; l++)
			{
				this.arrFrame[l] = msg.readShort();
			}
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
			Res.outz("1");
		}
	}

	// Token: 0x06000273 RID: 627 RVA: 0x00016A04 File Offset: 0x00014C04
	public void readData(myReader iss)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		try
		{
			sbyte b = iss.readByte();
			this.imgInfo = new ImageInfo[(int)b];
			for (int i = 0; i < (int)b; i++)
			{
				this.imgInfo[i] = new ImageInfo();
				this.imgInfo[i].ID = (int)iss.readByte();
				this.imgInfo[i].x0 = (int)iss.readByte();
				this.imgInfo[i].y0 = (int)iss.readByte();
				this.imgInfo[i].w = (int)iss.readByte();
				this.imgInfo[i].h = (int)iss.readByte();
			}
			short num5 = iss.readShort();
			this.frame = new Frame[(int)num5];
			for (int j = 0; j < (int)num5; j++)
			{
				this.frame[j] = new Frame();
				sbyte b2 = iss.readByte();
				this.frame[j].dx = new short[(int)b2];
				this.frame[j].dy = new short[(int)b2];
				this.frame[j].idImg = new sbyte[(int)b2];
				for (int k = 0; k < (int)b2; k++)
				{
					this.frame[j].dx[k] = iss.readShort();
					this.frame[j].dy[k] = iss.readShort();
					this.frame[j].idImg[k] = iss.readByte();
					if (j == 0)
					{
						if (num > (int)this.frame[j].dx[k])
						{
							num = (int)this.frame[j].dx[k];
						}
						if (num2 > (int)this.frame[j].dy[k])
						{
							num2 = (int)this.frame[j].dy[k];
						}
						if (num3 < (int)this.frame[j].dx[k] + this.imgInfo[(int)this.frame[j].idImg[k]].w)
						{
							num3 = (int)this.frame[j].dx[k] + this.imgInfo[(int)this.frame[j].idImg[k]].w;
						}
						if (num4 < (int)this.frame[j].dy[k] + this.imgInfo[(int)this.frame[j].idImg[k]].h)
						{
							num4 = (int)this.frame[j].dy[k] + this.imgInfo[(int)this.frame[j].idImg[k]].h;
						}
						this.width = num3 - num;
						this.height = num4 - num2;
					}
				}
			}
			short num6 = iss.readShort();
			this.arrFrame = new short[(int)num6];
			for (int l = 0; l < (int)num6; l++)
			{
				this.arrFrame[l] = iss.readShort();
			}
		}
		catch (Exception ex)
		{
			Cout.LogError("LOI TAI readData cua EffectDAta" + ex.ToString());
		}
	}

	// Token: 0x06000274 RID: 628 RVA: 0x00016D54 File Offset: 0x00014F54
	public void readData(sbyte[] data)
	{
		myReader iss = new myReader(data);
		this.readData(iss);
	}

	// Token: 0x06000275 RID: 629 RVA: 0x00016D70 File Offset: 0x00014F70
	public void readDataNewBoss(sbyte[] data, sbyte typeread)
	{
		myReader msg = new myReader(data);
		this.readMobNew(msg, typeread);
	}

	// Token: 0x06000276 RID: 630 RVA: 0x00016D8C File Offset: 0x00014F8C
	public void paintFrame(mGraphics g, int f, int x, int y, int trans, int layer)
	{
		if (this.frame != null && this.frame.Length != 0)
		{
			Frame frame = this.frame[f];
			for (int i = 0; i < frame.dx.Length; i++)
			{
				ImageInfo imageInfo = this.getImageInfo(frame.idImg[i]);
				try
				{
					if (trans == -1)
					{
						g.drawRegion(this.img, imageInfo.x0, imageInfo.y0, imageInfo.w, imageInfo.h, 0, x + (int)frame.dx[i], y + (int)frame.dy[i], 0);
					}
					if (trans == 0)
					{
						g.drawRegion(this.img, imageInfo.x0, imageInfo.y0, imageInfo.w, imageInfo.h, 0, x + (int)frame.dx[i], y + (int)frame.dy[i] - ((layer >= 4 || layer <= 0) ? 0 : GameCanvas.transY), 0);
					}
					if (trans == 1)
					{
						g.drawRegion(this.img, imageInfo.x0, imageInfo.y0, imageInfo.w, imageInfo.h, 2, x - (int)frame.dx[i], y + (int)frame.dy[i] - ((layer >= 4 || layer <= 0) ? 0 : GameCanvas.transY), StaticObj.TOP_RIGHT);
					}
					if (trans == 2)
					{
						g.drawRegion(this.img, imageInfo.x0, imageInfo.y0, imageInfo.w, imageInfo.h, 7, x - (int)frame.dx[i], y + (int)frame.dy[i] - ((layer >= 4 || layer <= 0) ? 0 : GameCanvas.transY), StaticObj.VCENTER_HCENTER);
					}
				}
				catch (Exception ex)
				{
				}
			}
		}
	}

	// Token: 0x06000277 RID: 631 RVA: 0x00016F70 File Offset: 0x00015170
	public void readMobNew(myReader msg, sbyte typeread)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		try
		{
			sbyte b = msg.readByte();
			this.imgInfo = new ImageInfo[(int)b];
			for (int i = 0; i < (int)b; i++)
			{
				this.imgInfo[i] = new ImageInfo();
				this.imgInfo[i].ID = (int)msg.readByte();
				if ((int)typeread == 1)
				{
					this.imgInfo[i].x0 = (int)msg.readUnsignedByte();
					this.imgInfo[i].y0 = (int)msg.readUnsignedByte();
				}
				else
				{
					this.imgInfo[i].x0 = (int)msg.readShort();
					this.imgInfo[i].y0 = (int)msg.readShort();
				}
				this.imgInfo[i].w = (int)msg.readUnsignedByte();
				this.imgInfo[i].h = (int)msg.readUnsignedByte();
			}
			short num5 = msg.readShort();
			this.frame = new Frame[(int)num5];
			for (int j = 0; j < this.frame.Length; j++)
			{
				this.frame[j] = new Frame();
				sbyte b2 = msg.readByte();
				this.frame[j].dx = new short[(int)b2];
				this.frame[j].dy = new short[(int)b2];
				this.frame[j].idImg = new sbyte[(int)b2];
				for (int k = 0; k < (int)b2; k++)
				{
					this.frame[j].dx[k] = msg.readShort();
					this.frame[j].dy[k] = msg.readShort();
					this.frame[j].idImg[k] = msg.readByte();
					if (j == 0)
					{
						if (num > (int)this.frame[j].dx[k])
						{
							num = (int)this.frame[j].dx[k];
						}
						if (num2 > (int)this.frame[j].dy[k])
						{
							num2 = (int)this.frame[j].dy[k];
						}
						if (num3 < (int)this.frame[j].dx[k] + this.imgInfo[(int)this.frame[j].idImg[k]].w)
						{
							num3 = (int)this.frame[j].dx[k] + this.imgInfo[(int)this.frame[j].idImg[k]].w;
						}
						if (num4 < (int)this.frame[j].dy[k] + this.imgInfo[(int)this.frame[j].idImg[k]].h)
						{
							num4 = (int)this.frame[j].dy[k] + this.imgInfo[(int)this.frame[j].idImg[k]].h;
						}
						this.width = num3 - num;
						this.height = num4 - num2;
					}
				}
			}
			this.arrFrame = new short[(int)msg.readShort()];
			for (int l = 0; l < this.arrFrame.Length; l++)
			{
				this.arrFrame[l] = msg.readShort();
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x040002CA RID: 714
	public Image img;

	// Token: 0x040002CB RID: 715
	public ImageInfo[] imgInfo;

	// Token: 0x040002CC RID: 716
	public Frame[] frame;

	// Token: 0x040002CD RID: 717
	public short[] arrFrame;

	// Token: 0x040002CE RID: 718
	public int ID;

	// Token: 0x040002CF RID: 719
	public int width;

	// Token: 0x040002D0 RID: 720
	public int height;
}
