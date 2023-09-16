using System;

// Token: 0x02000057 RID: 87
public class EffectPaint
{
	// Token: 0x060002E8 RID: 744 RVA: 0x00005068 File Offset: 0x00003268
	public int getImgId()
	{
		return this.effCharPaint.arrEfInfo[this.index].idImg;
	}

	// Token: 0x040004CD RID: 1229
	public int index;

	// Token: 0x040004CE RID: 1230
	public Mob eMob;

	// Token: 0x040004CF RID: 1231
	public global::Char eChar;

	// Token: 0x040004D0 RID: 1232
	public EffectCharPaint effCharPaint;

	// Token: 0x040004D1 RID: 1233
	public bool isFly;
}
