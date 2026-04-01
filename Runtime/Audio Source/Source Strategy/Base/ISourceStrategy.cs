using UnityEngine;

public interface ISourceStrategy
{
    AudioSource GetSource();
    public void Init(int sourcePoolCount);
}
