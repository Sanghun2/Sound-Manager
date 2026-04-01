using System;
using System.Collections.Generic;
using UnityEngine;

namespace BilliotGames
{
    public class AudioSourceContainer : AudioSourceContainerBase
    {
        public override void InitContainer(ISourceStrategy sourceStrategy, int sourcePoolCount = 10) {
            this.sourceStrategy = sourceStrategy;
            sourceStrategy.Init(sourcePoolCount);
            
        }

        public override void PlaySound(AudioClip clip) {
            var source = sourceStrategy.GetSource();
            source.clip = clip;
            source.Play();
        }
    }
}
