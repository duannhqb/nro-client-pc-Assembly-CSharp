using System;

// Token: 0x02000049 RID: 73
public interface IMessageHandler
{
	// Token: 0x060002B0 RID: 688
	void onMessage(Message message);

	// Token: 0x060002B1 RID: 689
	void onConnectionFail(bool isMain);

	// Token: 0x060002B2 RID: 690
	void onDisconnected(bool isMain);

	// Token: 0x060002B3 RID: 691
	void onConnectOK(bool isMain);
}
