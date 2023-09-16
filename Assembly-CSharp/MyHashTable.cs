using System;
using System.Collections;

// Token: 0x0200000D RID: 13
public class MyHashTable
{
	// Token: 0x0600005D RID: 93 RVA: 0x00003C7E File Offset: 0x00001E7E
	public object get(object k)
	{
		return this.h[k];
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00003C8C File Offset: 0x00001E8C
	public void clear()
	{
		this.h.Clear();
	}

	// Token: 0x0600005F RID: 95 RVA: 0x00003C99 File Offset: 0x00001E99
	public IDictionaryEnumerator GetEnumerator()
	{
		return this.h.GetEnumerator();
	}

	// Token: 0x06000060 RID: 96 RVA: 0x00003CA6 File Offset: 0x00001EA6
	public int size()
	{
		return this.h.Count;
	}

	// Token: 0x06000061 RID: 97 RVA: 0x00003CB3 File Offset: 0x00001EB3
	public void put(object k, object v)
	{
		if (this.h.ContainsKey(k))
		{
			this.h.Remove(k);
		}
		this.h.Add(k, v);
	}

	// Token: 0x06000062 RID: 98 RVA: 0x00003CDF File Offset: 0x00001EDF
	public void remove(object k)
	{
		this.h.Remove(k);
	}

	// Token: 0x06000063 RID: 99 RVA: 0x00003CDF File Offset: 0x00001EDF
	public void Remove(string key)
	{
		this.h.Remove(key);
	}

	// Token: 0x06000064 RID: 100 RVA: 0x00003CED File Offset: 0x00001EED
	public bool containsKey(object key)
	{
		return this.h.ContainsKey(key);
	}

	// Token: 0x04000024 RID: 36
	public Hashtable h = new Hashtable();
}
