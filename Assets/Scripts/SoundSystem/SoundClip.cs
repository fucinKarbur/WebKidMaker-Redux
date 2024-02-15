using System;
using UnityEngine;

namespace WKMR
{
    [Serializable]
    public class SoundClip
    {
        [SerializeField] private Sound _sound;
        [SerializeField] private AudioClip _clip;

        public Sound Sound => _sound;
        public AudioClip Clip => _clip;
    }
}