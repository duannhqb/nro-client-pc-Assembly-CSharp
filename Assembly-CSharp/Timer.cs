using System;

// Token: 0x020000C0 RID: 192
public class Timer
{
	// Token: 0x0600096B RID: 2411 RVA: 0x00007C2D File Offset: 0x00005E2D
	public static void setTimer(IActionListener actionListener, int action, long timeEllapse)
	{
		Timer.timeListener = actionListener;
		Timer.idAction = action;
		Timer.timeExecute = mSystem.currentTimeMillis() + timeEllapse;
		Timer.isON = true;
	}

	// Token: 0x0600096C RID: 2412 RVA: 0x0008BFB4 File Offset: 0x0008A1B4
	public static void update()
	{
		long num = mSystem.currentTimeMillis();
		if (Timer.isON && num > Timer.timeExecute)
		{
			Timer.isON = false;
			try
			{
				if (Timer.idAction > 0)
				{
					GameScr.gI().actionPerform(Timer.idAction, null);
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x0400116B RID: 4459
	public static IActionListener timeListener;

	// Token: 0x0400116C RID: 4460
	public static int idAction;

	// Token: 0x0400116D RID: 4461
	public static long timeExecute;

	// Token: 0x0400116E RID: 4462
	public static bool isON;
}
