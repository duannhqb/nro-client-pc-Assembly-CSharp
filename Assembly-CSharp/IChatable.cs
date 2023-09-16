using System;

// Token: 0x020000A3 RID: 163
public interface IChatable
{
	// Token: 0x0600071C RID: 1820
	void onChatFromMe(string text, string to);

	// Token: 0x0600071D RID: 1821
	void onCancelChat();
}
