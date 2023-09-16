using System;

namespace Assets.src.g
{
	// Token: 0x020000A5 RID: 165
	internal class ImageSource
	{
		// Token: 0x06000724 RID: 1828 RVA: 0x00006D72 File Offset: 0x00004F72
		public ImageSource(string ID, sbyte version)
		{
			this.id = ID;
			this.version = version;
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x000645E0 File Offset: 0x000627E0
		public static void checkRMS()
		{
			MyVector myVector = new MyVector();
			sbyte[] array = Rms.loadRMS("ImageSource");
			if (array == null)
			{
				Service.gI().imageSource(myVector);
				return;
			}
			ImageSource.vRms = new MyVector();
			DataInputStream dataInputStream = new DataInputStream(array);
			if (dataInputStream == null)
			{
				return;
			}
			try
			{
				short num = dataInputStream.readShort();
				string[] array2 = new string[(int)num];
				sbyte[] array3 = new sbyte[(int)num];
				for (int i = 0; i < (int)num; i++)
				{
					array2[i] = dataInputStream.readUTF();
					array3[i] = dataInputStream.readByte();
					ImageSource.vRms.addElement(new ImageSource(array2[i], array3[i]));
				}
				dataInputStream.close();
			}
			catch (Exception ex)
			{
				ex.StackTrace.ToString();
			}
			Res.outz(string.Concat(new object[]
			{
				"vS size= ",
				ImageSource.vSource.size(),
				" vRMS size= ",
				ImageSource.vRms.size()
			}));
			for (int j = 0; j < ImageSource.vSource.size(); j++)
			{
				ImageSource imageSource = (ImageSource)ImageSource.vSource.elementAt(j);
				if (!ImageSource.isExistID(imageSource.id))
				{
					myVector.addElement(imageSource);
				}
			}
			for (int k = 0; k < ImageSource.vRms.size(); k++)
			{
				ImageSource imageSource2 = (ImageSource)ImageSource.vRms.elementAt(k);
				if ((int)ImageSource.getVersionRMSByID(imageSource2.id) != (int)ImageSource.getCurrVersionByID(imageSource2.id))
				{
					myVector.addElement(imageSource2);
				}
			}
			Service.gI().imageSource(myVector);
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x000647A8 File Offset: 0x000629A8
		public static sbyte getVersionRMSByID(string id)
		{
			for (int i = 0; i < ImageSource.vRms.size(); i++)
			{
				if (id.Equals(((ImageSource)ImageSource.vRms.elementAt(i)).id))
				{
					return ((ImageSource)ImageSource.vRms.elementAt(i)).version;
				}
			}
			return -1;
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x00064808 File Offset: 0x00062A08
		public static sbyte getCurrVersionByID(string id)
		{
			for (int i = 0; i < ImageSource.vSource.size(); i++)
			{
				if (id.Equals(((ImageSource)ImageSource.vSource.elementAt(i)).id))
				{
					return ((ImageSource)ImageSource.vSource.elementAt(i)).version;
				}
			}
			return -1;
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x00064868 File Offset: 0x00062A68
		public static bool isExistID(string id)
		{
			for (int i = 0; i < ImageSource.vRms.size(); i++)
			{
				if (id.Equals(((ImageSource)ImageSource.vRms.elementAt(i)).id))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x000648B4 File Offset: 0x00062AB4
		public static void saveRMS()
		{
			DataOutputStream dataOutputStream = new DataOutputStream();
			try
			{
				dataOutputStream.writeShort((short)ImageSource.vSource.size());
				for (int i = 0; i < ImageSource.vSource.size(); i++)
				{
					dataOutputStream.writeUTF(((ImageSource)ImageSource.vSource.elementAt(i)).id);
					dataOutputStream.writeByte(((ImageSource)ImageSource.vSource.elementAt(i)).version);
				}
				Rms.saveRMS("ImageSource", dataOutputStream.toByteArray());
				dataOutputStream.close();
			}
			catch (Exception ex)
			{
				ex.StackTrace.ToString();
			}
		}

		// Token: 0x04000D5A RID: 3418
		public sbyte version;

		// Token: 0x04000D5B RID: 3419
		public string id;

		// Token: 0x04000D5C RID: 3420
		public static MyVector vSource = new MyVector();

		// Token: 0x04000D5D RID: 3421
		public static MyVector vRms = new MyVector();
	}
}
