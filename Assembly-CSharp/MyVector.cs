using System;
using System.Collections;

// Token: 0x02000011 RID: 17
public class MyVector
{
	// Token: 0x0600006E RID: 110 RVA: 0x00003D38 File Offset: 0x00001F38
	public MyVector()
	{
		this.a = new ArrayList();
	}

	// Token: 0x0600006F RID: 111 RVA: 0x00003D38 File Offset: 0x00001F38
	public MyVector(string s)
	{
		this.a = new ArrayList();
	}

	// Token: 0x06000070 RID: 112 RVA: 0x00003D4B File Offset: 0x00001F4B
	public MyVector(ArrayList a)
	{
		this.a = a;
	}

	// Token: 0x06000071 RID: 113 RVA: 0x00003D5A File Offset: 0x00001F5A
	public void addElement(object o)
	{
		this.a.Add(o);
	}

	// Token: 0x06000072 RID: 114 RVA: 0x00003D69 File Offset: 0x00001F69
	public bool contains(object o)
	{
		return this.a.Contains(o);
	}

	// Token: 0x06000073 RID: 115 RVA: 0x00003D7F File Offset: 0x00001F7F
	public int size()
	{
		if (this.a == null)
		{
			return 0;
		}
		return this.a.Count;
	}

	// Token: 0x06000074 RID: 116 RVA: 0x00003D99 File Offset: 0x00001F99
	public object elementAt(int index)
	{
		if (index > -1 && index < this.a.Count)
		{
			return this.a[index];
		}
		return null;
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00003DC1 File Offset: 0x00001FC1
	public void set(int index, object obj)
	{
		if (index > -1 && index < this.a.Count)
		{
			this.a[index] = obj;
		}
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00003DE8 File Offset: 0x00001FE8
	public void setElementAt(object obj, int index)
	{
		if (index > -1 && index < this.a.Count)
		{
			this.a[index] = obj;
		}
	}

	// Token: 0x06000077 RID: 119 RVA: 0x00003E0F File Offset: 0x0000200F
	public int indexOf(object o)
	{
		return this.a.IndexOf(o);
	}

	// Token: 0x06000078 RID: 120 RVA: 0x00003E1D File Offset: 0x0000201D
	public void removeElementAt(int index)
	{
		if (index > -1 && index < this.a.Count)
		{
			this.a.RemoveAt(index);
		}
	}

	// Token: 0x06000079 RID: 121 RVA: 0x00003E43 File Offset: 0x00002043
	public void removeElement(object o)
	{
		this.a.Remove(o);
	}

	// Token: 0x0600007A RID: 122 RVA: 0x00003E51 File Offset: 0x00002051
	public void removeAllElements()
	{
		this.a.Clear();
	}

	// Token: 0x0600007B RID: 123 RVA: 0x00003E5E File Offset: 0x0000205E
	public void insertElementAt(object o, int i)
	{
		this.a.Insert(i, o);
	}

	// Token: 0x0600007C RID: 124 RVA: 0x00003E6D File Offset: 0x0000206D
	public object firstElement()
	{
		return this.a[0];
	}

	// Token: 0x0600007D RID: 125 RVA: 0x00003E7B File Offset: 0x0000207B
	public object lastElement()
	{
		return this.a[this.a.Count - 1];
	}

	// Token: 0x04000027 RID: 39
	private ArrayList a;
}
