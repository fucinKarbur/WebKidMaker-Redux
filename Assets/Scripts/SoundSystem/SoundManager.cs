using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WKMR
{
    public static class SoundManager
    {
        public static VolumeChanger VolumeChanger = new();

        public static void PlayOneShot(Sound sound)
        {
            var source = SourcePool.SFXSources.GetValueOrDefault(sound);

            source?.PlayOneShot(source.clip);
        }

        public static void PlayOneShot(AudioSource source) => source?.PlayOneShot(source.clip);
    }
}