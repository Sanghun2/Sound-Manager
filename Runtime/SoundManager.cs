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
        private AudioSourceContainerBase sfxSourceContainer;
        private AudioSourceContainerBase bgmSourceContainer;
        private IClipLoader clipLoader;

        public void ClearClips() {
            clips.Clear();
        }
        public void SetSFXSourceContainer(AudioSourceContainerBase sourceContainer, ISourceStrategy sourceStrategy, int poolCount) {
            sfxSourceContainer = sourceContainer;
            sourceContainer.InitContainer(sourceStrategy, poolCount);
        }
        public void SetBGMSourceContainer(AudioSourceContainerBase sourceContainer, ISourceStrategy sourceStrategy, int poolCount) {
            bgmSourceContainer = sourceContainer;
            sourceContainer.InitContainer(sourceStrategy, poolCount);
        }
        public void SetClipLoader(IClipLoader clipLoader) {
            this.clipLoader = clipLoader;
        }

        public void RegisterSound(string soundID, AudioClip clip) {
            clips[soundID] = clip;
        }
        public void UnregisterSound(string soundID) {
            clips.Remove(soundID);
        }
        public void PlaySound(string soundID, Sound.Type type=Sound.Type.SFX) {
            if (TryGetClip(soundID, out AudioClip clip)) {
                var container = type == Sound.Type.BGM ? bgmSourceContainer : sfxSourceContainer;
                container.PlaySound(clip);
            }
            else {
                Debug.LogError($"<color=red>({soundID})에 해당하는 clip 없음</color>");
            }
        }

        private bool TryGetClip(string soundID, out AudioClip clip) {
            if (clips.TryGetValue(soundID, out clip)) {
                return true;
            }

            clip = clipLoader.LoadClip(soundID);
            if (clip != null) {
                RegisterSound(soundID, clip);
                return true;
            }

            Debug.LogError($"<color=red>no audio clip named ({soundID}) exist</color>");
            return false;
        }
    }
}
