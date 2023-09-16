using System;

// Token: 0x02000071 RID: 113
public class Part
{
	// Token: 0x060003B0 RID: 944 RVA: 0x000204E4 File Offset: 0x0001E6E4
	public Part(int type)
	{
		this.type = type;
		if (type == 0)
		{
			this.pi = new PartImage[3];
		}
		if (type == 1)
		{
			this.pi = new PartImage[17];
		}
		if (type == 2)
		{
			this.pi = new PartImage[14];
		}
		if (type == 3)
		{
			this.pi = new PartImage[2];
		}
	}

	// Token: 0x04000631 RID: 1585
	public int type;

	// Token: 0x04000632 RID: 1586
	public PartImage[] pi;
}
