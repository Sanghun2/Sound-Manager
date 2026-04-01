using System.Collections.Generic;
using UnityEngine;

public class PooledSourceStrategy : ISourceStrategy
{
    private Transform sourceContainer;
    private List<AudioSource> sourceList;


    public void Init(int sourcePoolCount) {
        sourceList = new List<AudioSource>(sourcePoolCount);
        if (sourceContainer == null) {
            sourceContainer = new GameObject("Audio Source Container").transform;

            for (int i = 0; i < sourcePoolCount; i++) {
                var source = CreateSource();
            }
        }
    }

    public AudioSource GetSource() {
        for (int i = 0; i < sourceList.Count; i++) {
            var source = sourceList[i];
            if (source.isPlaying == false) {
                return source;
            }
        }

        return CreateSource();
    }
    private AudioSource CreateSource() {
        var child = new GameObject("Audio Source");
        child.transform.SetParent(sourceContainer);
        var source = child.AddComponent<AudioSource>();
        sourceList.Add(source);
        return source;
    }

}
