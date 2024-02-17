using UnityEngine;

namespace WKMR
{
    public static class SourceProvider
    {
        public static SFXAssets SFXAssets { get; private set; }
        public static SFXPool Pool => (SFXPool)SFXAssets.Pool;

        public static AudioSource GetSource(SoundName sound)
        {
            if (SFXAssets != null
            && Pool.SFXSources.TryGetValue(sound, out AudioSource source))
                return source;
            else
                return null;
        }

        public static void SetAssets(SFXAssets assets)
        {
            SFXAssets = assets;
        }
    }
}