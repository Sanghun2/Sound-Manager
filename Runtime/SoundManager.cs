using System;
using System.Collections.Generic;
using UnityEngine;

namespace BilliotGames
{
    public class Sound {
        public enum Type {
            SFX,
            BGM,
        }
    }

    public class SoundManager
    {
        private Dictionary<string, AudioClip> clips = new();
        private AudioSourceContainerBase sourceContainer;

        public void SetSourceContainer(AudioSourceContainerBase sourceContainer) {
            this.sourceContainer = sourceContainer;
            sourceContainer.InitContainer();
        }
        public void ClearClips() {
            clips.Clear();
        }

        public void PlaySound(string soundID, Sound.Type type=Sound.Type.SFX) {
            if (TryGetClip(soundID, out AudioClip clip)) {
                sourceContainer.PlaySound(clip);
            }
            else {
                Debug.LogError($"<color=red>({soundID})에 해당하는 clip 없음</color>");
            }
        }

        private bool TryGetClip(string soundID, out AudioClip clip) {
            return clips.TryGetValue(soundID, out clip);
        }
    }
}
