using System;
using UnityEngine;

namespace BilliotGames
{
    public abstract class AudioSourceContainerBase
    {
        public abstract void InitContainer(int sourcePoolCount = 10);
        public abstract void PlaySound(AudioClip clip);
    }

}
