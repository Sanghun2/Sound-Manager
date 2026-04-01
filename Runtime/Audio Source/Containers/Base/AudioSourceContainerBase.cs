using System;
using UnityEngine;

namespace BilliotGames
{
    public abstract class AudioSourceContainerBase
    {
        public abstract void InitContainer(ISourceStrategy sourceStrategy, int sourcePoolCount = 10);
        public abstract void PlaySound(AudioClip clip);

        protected ISourceStrategy sourceStrategy;
    }

}
