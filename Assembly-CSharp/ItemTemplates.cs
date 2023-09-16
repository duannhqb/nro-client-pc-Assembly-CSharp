using System;

// Token: 0x02000064 RID: 100
public class ItemTemplates
{
	// Token: 0x06000357 RID: 855 RVA: 0x00005435 File Offset: 0x00003635
	public static void add(ItemTemplate it)
	{
		ItemTemplates.itemTemplates.put(it.id, it);
	}

	// Token: 0x06000358 RID: 856 RVA: 0x0000544D File Offset: 0x0000364D
	public static ItemTemplate get(short id)
	{
		return (ItemTemplate)ItemTemplates.itemTemplates.get(id);
	}

	// Token: 0x06000359 RID: 857 RVA: 0x00005464 File Offset: 0x00003664
	public static short getPart(short itemTemplateID)
	{
		return ItemTemplates.get(itemTemplateID).part;
	}

	// Token: 0x0600035A RID: 858 RVA: 0x00005471 File Offset: 0x00003671
	public static short getIcon(short itemTemplateID)
	{
		return ItemTemplates.get(itemTemplateID).iconID;
	}

	// Token: 0x04000596 RID: 1430
	public static MyHashTable itemTemplates = new MyHashTable();
}
