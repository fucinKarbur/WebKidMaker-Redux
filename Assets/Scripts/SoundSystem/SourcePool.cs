using System.Collections.Generic;
using UnityEngine;

namespace WKMR
{
    public static class SourcePool
    {
        private static readonly Dictionary<Sound, AudioSource> _sfxSources = new();
        private static AudioSource _musicSource;

        public static Dictionary<Sound, AudioSource> SFXSources => _sfxSources;
        public static AudioSource MusicSource => _musicSource;

        public static void Initiallize(Transform container)
        {
            foreach (var sound in SoundAssets.Instance.SoundClips)
            {
                if (_sfxSources.ContainsKey(sound.Sound))
                    continue;

                _sfxSources.Add(sound.Sound, SetSource(sound, container));
            }

            if (_musicSource == null)
                SetMusicSource(GetRandomBgClip(), container);
        }

        private static void SetMusicSource(SoundClip sound, Transform container)
        {
            _musicSource = SetSource(sound, container);
            _musicSource.playOnAwake = true;
            _musicSource.loop = true;
            _musicSource.Play();
        }

        private static AudioSource SetSource(SoundClip sound, Transform container)
        {
            GameObject soundObject = new(sound.Sound.ToString());
            soundObject.transform.parent = container;

            var source = soundObject.AddComponent<AudioSource>();
            source.clip = sound.Clip;

            return source;
        }

        private static SoundClip GetRandomBgClip()
            => SoundAssets.Instance.BgClips[Random.Range(0, SoundAssets.Instance.BgClips.Count)];
    }
}