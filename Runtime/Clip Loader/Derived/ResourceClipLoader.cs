using System.IO;
using System.Text;
using UnityEngine;

public class ResourceClipLoader : IClipLoader
{
    private string baseSoundPath;
    private StringBuilder pathBuilder = new StringBuilder();
    
    public ResourceClipLoader(string baseSoundPath) {
        this.baseSoundPath = baseSoundPath;
    }

    public AudioClip LoadClip(string soundID) {
        pathBuilder.Clear();
        pathBuilder.Append(baseSoundPath).Append('/').Append(soundID);
        return Resources.Load<AudioClip>(pathBuilder.ToString());
    }
}
