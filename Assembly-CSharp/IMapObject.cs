using System;

// Token: 0x020000A4 RID: 164
public interface IMapObject
{
	// Token: 0x0600071E RID: 1822
	int getX();

	// Token: 0x0600071F RID: 1823
	int getY();

	// Token: 0x06000720 RID: 1824
	int getW();

	// Token: 0x06000721 RID: 1825
	int getH();

	// Token: 0x06000722 RID: 1826
	void stopMoving();

	// Token: 0x06000723 RID: 1827
	bool isInvisible();
}
