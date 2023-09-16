using System;

// Token: 0x0200003B RID: 59
public abstract class Effect2
{
	// Token: 0x0600026B RID: 619 RVA: 0x00003984 File Offset: 0x00001B84
	public virtual void update()
	{
	}

	// Token: 0x0600026C RID: 620 RVA: 0x00003984 File Offset: 0x00001B84
	public virtual void paint(mGraphics g)
	{
	}

	// Token: 0x040002C4 RID: 708
	public static MyVector vEffect3 = new MyVector();

	// Token: 0x040002C5 RID: 709
	public static MyVector vEffect2 = new MyVector();

	// Token: 0x040002C6 RID: 710
	public static MyVector vRemoveEffect2 = new MyVector();

	// Token: 0x040002C7 RID: 711
	public static MyVector vEffect2Outside = new MyVector();

	// Token: 0x040002C8 RID: 712
	public static MyVector vAnimateEffect = new MyVector();

	// Token: 0x040002C9 RID: 713
	public static MyVector vEffectFeet = new MyVector();
}
