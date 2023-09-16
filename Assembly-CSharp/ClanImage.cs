using System;

// Token: 0x02000031 RID: 49
public class ClanImage
{
	// Token: 0x0600021A RID: 538 RVA: 0x00004B9F File Offset: 0x00002D9F
	public static void addClanImage(ClanImage cm)
	{
		Service.gI().clanImage((sbyte)cm.ID);
		ClanImage.vClanImage.addElement(cm);
	}

	// Token: 0x0600021B RID: 539 RVA: 0x00012204 File Offset: 0x00010404
	public static ClanImage getClanImage(sbyte ID)
	{
		for (int i = 0; i < ClanImage.vClanImage.size(); i++)
		{
			ClanImage clanImage = (ClanImage)ClanImage.vClanImage.elementAt(i);
			if (clanImage.ID == (int)ID)
			{
				return clanImage;
			}
		}
		return null;
	}

	// Token: 0x0600021C RID: 540 RVA: 0x00012250 File Offset: 0x00010450
	public static bool isExistClanImage(int ID)
	{
		for (int i = 0; i < ClanImage.vClanImage.size(); i++)
		{
			ClanImage clanImage = (ClanImage)ClanImage.vClanImage.elementAt(i);
			if (clanImage.ID == ID)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x040001F2 RID: 498
	public int ID;

	// Token: 0x040001F3 RID: 499
	public string name;

	// Token: 0x040001F4 RID: 500
	public short[] idImage;

	// Token: 0x040001F5 RID: 501
	public int xu;

	// Token: 0x040001F6 RID: 502
	public int luong;

	// Token: 0x040001F7 RID: 503
	public static MyVector vClanImage = new MyVector();

	// Token: 0x040001F8 RID: 504
	public static MyHashTable idImages = new MyHashTable();
}
