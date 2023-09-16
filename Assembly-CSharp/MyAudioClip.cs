using System;
using UnityEngine;

// Token: 0x0200000C RID: 12
public class MyAudioClip
{
	// Token: 0x06000059 RID: 89 RVA: 0x00003C26 File Offset: 0x00001E26
	public MyAudioClip(string filename)
	{
		this.clip = (AudioClip)Resources.Load(filename);
		this.name = filename;
	}

	// Token: 0x0600005A RID: 90 RVA: 0x00003C46 File Offset: 0x00001E46
	public void Play()
	{
		Main.main.GetComponent<AudioSource>().PlayOneShot(this.clip);
		this.timeStart = mSystem.currentTimeMillis();
	}

	// Token: 0x0600005B RID: 91 RVA: 0x00003C68 File Offset: 0x00001E68
	public bool isPlaying()
	{
		return false;
	}

	// Token: 0x04000021 RID: 33
	public string name;

	// Token: 0x04000022 RID: 34
	public AudioClip clip;

	// Token: 0x04000023 RID: 35
	public long timeStart;
}
