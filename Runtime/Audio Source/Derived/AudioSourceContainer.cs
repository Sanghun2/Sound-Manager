using System;
using System.Collections.Generic;
using UnityEngine;

namespace BilliotGames
{
    public class AudioSourceContainer : AudioSourceContainerBase
    {
        private Transform sourceContainer;
        private List<AudioSource> sourceList;

        public override void InitContainer(int sourcePoolCount = 10) {
            sourceList = new List<AudioSource>(sourcePoolCount);
            if (sourceContainer == null) {
                sourceContainer = new GameObject("Audio Source Container").transform;

                for (int i = 0; i < sourcePoolCount; i++) {
                    var source = CreateSource();
                }
            }
        }

        public override void PlaySound(AudioClip clip) {
            var source = GetOrCreateSource();
            source.clip = clip;
            source.Play();
        }


        private AudioSource GetOrCreateSource() {
            var source = GetSource();

            if (source == null) {
                source = CreateSource();
            }

            return source;
        }
        private AudioSource GetSource() {
            for (int i = 0; i < sourceList.Count; i++) {
                var source = sourceList[i];
                if (source.isPlaying == false) {
                    return source;
                }
            }

            return null;
        }
        private AudioSource CreateSource() {
            var child = new GameObject("Audio Source");
            child.transform.SetParent(sourceContainer);
            var source = child.AddComponent<AudioSource>();
            sourceList.Add(source);
            return source;
        }
    }
}
