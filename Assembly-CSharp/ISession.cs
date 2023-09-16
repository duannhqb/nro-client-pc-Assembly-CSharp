using System;

// Token: 0x0200004A RID: 74
public interface ISession
{
	// Token: 0x060002B4 RID: 692
	bool isConnected();

	// Token: 0x060002B5 RID: 693
	void setHandler(IMessageHandler messageHandler);

	// Token: 0x060002B6 RID: 694
	void connect(string host, int port);

	// Token: 0x060002B7 RID: 695
	void sendMessage(Message message);

	// Token: 0x060002B8 RID: 696
	void close();
}
