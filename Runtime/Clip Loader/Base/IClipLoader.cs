using UnityEngine;

namespace BilliotGames
{
    public interface IClipLoader
    {
        AudioClip[] LoadAllClips(string resourcePath);
        AudioClip LoadClip(string soundID);
    }
}