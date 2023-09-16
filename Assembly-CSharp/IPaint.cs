using System;

// Token: 0x0200005C RID: 92
public abstract class IPaint
{
	// Token: 0x060002F9 RID: 761
	public abstract void paintDefaultBg(mGraphics g);

	// Token: 0x060002FA RID: 762
	public abstract void paintfillDefaultBg(mGraphics g);

	// Token: 0x060002FB RID: 763
	public abstract void repaintCircleBg();

	// Token: 0x060002FC RID: 764
	public abstract void paintSolidBg(mGraphics g);

	// Token: 0x060002FD RID: 765
	public abstract void paintDefaultPopup(mGraphics g, int x, int y, int w, int h);

	// Token: 0x060002FE RID: 766
	public abstract void paintWhitePopup(mGraphics g, int y, int x, int width, int height);

	// Token: 0x060002FF RID: 767
	public abstract void paintDefaultPopupH(mGraphics g, int h);

	// Token: 0x06000300 RID: 768
	public abstract void paintCmdBar(mGraphics g, Command left, Command center, Command right);

	// Token: 0x06000301 RID: 769
	public abstract void paintSelect(mGraphics g, int x, int y, int w, int h);

	// Token: 0x06000302 RID: 770
	public abstract void paintLogo(mGraphics g, int x, int y);

	// Token: 0x06000303 RID: 771
	public abstract void paintHotline(mGraphics g, string num);

	// Token: 0x06000304 RID: 772
	public abstract void paintInputTf(mGraphics g, bool iss, int x, int y, int w, int h, int xText, int yText, string text);

	// Token: 0x06000305 RID: 773
	public abstract void paintTabSoft(mGraphics g);

	// Token: 0x06000306 RID: 774
	public abstract void paintBackMenu(mGraphics g, int x, int y, int w, int h, bool iss);

	// Token: 0x06000307 RID: 775
	public abstract void paintMsgBG(mGraphics g, int x, int y, int w, int h, string title, string subTitle, string check);

	// Token: 0x06000308 RID: 776
	public abstract void paintDefaultScrLisst(mGraphics g, string title, string subTitle, string check);

	// Token: 0x06000309 RID: 777
	public abstract void paintCheck(mGraphics g, int x, int y, int index);

	// Token: 0x0600030A RID: 778
	public abstract void paintImgMsg(mGraphics g, int x, int y, int index);

	// Token: 0x0600030B RID: 779
	public abstract void paintTitleBoard(mGraphics g, int roomID);

	// Token: 0x0600030C RID: 780
	public abstract void paintCheckPass(mGraphics g, int x, int y, bool check, bool focus);

	// Token: 0x0600030D RID: 781
	public abstract void paintInputDlg(mGraphics g, int x, int y, int w, int h, string[] str);

	// Token: 0x0600030E RID: 782
	public abstract void paintIconMainMenu(mGraphics g, int x, int y, bool iss, bool issSe, int i, int wStr);

	// Token: 0x0600030F RID: 783
	public abstract void paintLineRoom(mGraphics g, int x, int y, int xTo, int yTo);

	// Token: 0x06000310 RID: 784
	public abstract void paintCellContaint(mGraphics g, int x, int y, int w, int h, bool iss);

	// Token: 0x06000311 RID: 785
	public abstract void paintScroll(mGraphics g, int x, int y, int h);

	// Token: 0x06000312 RID: 786
	public abstract int[] getColorMsg();

	// Token: 0x06000313 RID: 787
	public abstract void paintLogo(mGraphics g);

	// Token: 0x06000314 RID: 788
	public abstract void paintTextLogin(mGraphics g, bool issRes);

	// Token: 0x06000315 RID: 789
	public abstract void paintSellectBoard(mGraphics g, int x, int y, int w, int h);

	// Token: 0x06000316 RID: 790
	public abstract int issRegissterUsingWAP();

	// Token: 0x06000317 RID: 791
	public abstract string getCard();

	// Token: 0x06000318 RID: 792
	public abstract void paintSellectedShop(mGraphics g, int x, int y, int w, int h);

	// Token: 0x06000319 RID: 793
	public abstract string getUrlUpdateGame();

	// Token: 0x0600031A RID: 794 RVA: 0x000050FA File Offset: 0x000032FA
	public string getFAQLink()
	{
		return "http://wap.teamobi.com/faqs.php?provider=";
	}

	// Token: 0x0600031B RID: 795
	public abstract void doSelect(int focus);
}
