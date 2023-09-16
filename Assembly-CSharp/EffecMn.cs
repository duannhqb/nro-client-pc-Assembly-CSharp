using System;

// Token: 0x02000039 RID: 57
public class EffecMn
{
	// Token: 0x06000253 RID: 595 RVA: 0x00004D52 File Offset: 0x00002F52
	public static void addEff(Effect me)
	{
		EffecMn.vEff.addElement(me);
	}

	// Token: 0x06000254 RID: 596 RVA: 0x00004D5F File Offset: 0x00002F5F
	public static void removeEff(int id)
	{
		if (EffecMn.getEffById(id) != null)
		{
			EffecMn.vEff.removeElement(EffecMn.getEffById(id));
		}
	}

	// Token: 0x06000255 RID: 597 RVA: 0x0001576C File Offset: 0x0001396C
	public static Effect getEffById(int id)
	{
		for (int i = 0; i < EffecMn.vEff.size(); i++)
		{
			Effect effect = (Effect)EffecMn.vEff.elementAt(i);
			if (effect.effId == id)
			{
				return effect;
			}
		}
		return null;
	}

	// Token: 0x06000256 RID: 598 RVA: 0x000157B4 File Offset: 0x000139B4
	public static void paintBackGroundUnderLayer(mGraphics g, int x, int y, int layer)
	{
		for (int i = 0; i < EffecMn.vEff.size(); i++)
		{
			if (((Effect)EffecMn.vEff.elementAt(i)).layer == -layer)
			{
				((Effect)EffecMn.vEff.elementAt(i)).paintUnderBackground(g, x, y);
			}
		}
	}

	// Token: 0x06000257 RID: 599 RVA: 0x00015810 File Offset: 0x00013A10
	public static void paintLayer1(mGraphics g)
	{
		for (int i = 0; i < EffecMn.vEff.size(); i++)
		{
			if (((Effect)EffecMn.vEff.elementAt(i)).layer == 1)
			{
				((Effect)EffecMn.vEff.elementAt(i)).paint(g);
			}
		}
	}

	// Token: 0x06000258 RID: 600 RVA: 0x0001586C File Offset: 0x00013A6C
	public static void paintLayer2(mGraphics g)
	{
		for (int i = 0; i < EffecMn.vEff.size(); i++)
		{
			if (((Effect)EffecMn.vEff.elementAt(i)).layer == 2)
			{
				((Effect)EffecMn.vEff.elementAt(i)).paint(g);
			}
		}
	}

	// Token: 0x06000259 RID: 601 RVA: 0x000158C8 File Offset: 0x00013AC8
	public static void paintLayer3(mGraphics g)
	{
		for (int i = 0; i < EffecMn.vEff.size(); i++)
		{
			if (((Effect)EffecMn.vEff.elementAt(i)).layer == 3)
			{
				((Effect)EffecMn.vEff.elementAt(i)).paint(g);
			}
		}
	}

	// Token: 0x0600025A RID: 602 RVA: 0x00015924 File Offset: 0x00013B24
	public static void paintLayer4(mGraphics g)
	{
		for (int i = 0; i < EffecMn.vEff.size(); i++)
		{
			if (((Effect)EffecMn.vEff.elementAt(i)).layer == 4)
			{
				((Effect)EffecMn.vEff.elementAt(i)).paint(g);
			}
		}
	}

	// Token: 0x0600025B RID: 603 RVA: 0x00015980 File Offset: 0x00013B80
	public static void update()
	{
		for (int i = 0; i < EffecMn.vEff.size(); i++)
		{
			((Effect)EffecMn.vEff.elementAt(i)).update();
		}
	}

	// Token: 0x04000287 RID: 647
	public static MyVector vEff = new MyVector();
}
