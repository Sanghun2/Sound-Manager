using UnityEngine;

public class DedicatedSource : ISourceStrategy
{
    private AudioSource bgmSource;

    public AudioSource GetSource() {
        return bgmSource;
    }

    public void Init(int _) {
        bgmSource = new GameObject("BGM Source").AddComponent<AudioSource>();
    }
}
