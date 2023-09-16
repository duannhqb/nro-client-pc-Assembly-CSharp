using System;
using System.Collections;

// Token: 0x02000044 RID: 68
public class ImgByName
{
	// Token: 0x06000293 RID: 659 RVA: 0x00004E59 File Offset: 0x00003059
	public static void SetImage(string name, Image img, sbyte nFrame)
	{
		ImgByName.hashImagePath.put(string.Empty + name, new MainImage(img, nFrame));
	}

	// Token: 0x06000294 RID: 660 RVA: 0x00017E24 File Offset: 0x00016024
	public static MainImage getImagePath(string nameImg, MyHashTable hash)
	{
		MainImage mainImage = (MainImage)hash.get(string.Empty + nameImg);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			MainImage fromRms = ImgByName.getFromRms(nameImg);
			if (fromRms != null)
			{
				mainImage.img = fromRms.img;
				mainImage.nFrame = fromRms.nFrame;
			}
			hash.put(string.Empty + nameImg, mainImage);
		}
		mainImage.count = GameCanvas.timeNow / 1000L;
		if (mainImage.img == null)
		{
			mainImage.timeImageNull--;
			if (mainImage.timeImageNull <= 0)
			{
				Service.gI().getImgByName(nameImg);
				mainImage.timeImageNull = 200;
			}
		}
		return mainImage;
	}

	// Token: 0x06000295 RID: 661 RVA: 0x00017EDC File Offset: 0x000160DC
	public static MainImage getFromRms(string nameImg)
	{
		string filename = mGraphics.zoomLevel + "ImgByName_" + nameImg;
		MainImage mainImage = null;
		sbyte[] array = Rms.loadRMS(filename);
		if (array == null)
		{
			return mainImage;
		}
		try
		{
			mainImage = new MainImage();
			mainImage.nFrame = array[0];
			mainImage.img = Image.createImage(array, 1, array.Length);
		}
		catch (Exception ex)
		{
			return null;
		}
		return mainImage;
	}

	// Token: 0x06000296 RID: 662 RVA: 0x00017F54 File Offset: 0x00016154
	public static void saveRMS(string nameImg, sbyte nFrame, sbyte[] data)
	{
		string filename = mGraphics.zoomLevel + "ImgByName_" + nameImg;
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeByte(nFrame);
			for (int i = 0; i < data.Length; i++)
			{
				dataOutputStream.writeByte(data[i]);
			}
			Rms.saveRMS(filename, dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000297 RID: 663 RVA: 0x00017FD0 File Offset: 0x000161D0
	public static void checkDelHash(MyHashTable hash, int minute, bool isTrue)
	{
		MyVector myVector = new MyVector("checkDelHash");
		if (isTrue)
		{
			hash.clear();
		}
		else
		{
			IDictionaryEnumerator enumerator = hash.GetEnumerator();
			while (enumerator.MoveNext())
			{
				MainImage mainImage = (MainImage)enumerator.Value;
				if (GameCanvas.timeNow / 1000L - mainImage.count > (long)(minute * 60))
				{
					string o = (string)enumerator.Key;
					myVector.addElement(o);
				}
			}
			for (int i = 0; i < myVector.size(); i++)
			{
				hash.remove((string)myVector.elementAt(i));
			}
		}
	}

	// Token: 0x04000317 RID: 791
	public static MyHashTable hashImagePath = new MyHashTable();
}
