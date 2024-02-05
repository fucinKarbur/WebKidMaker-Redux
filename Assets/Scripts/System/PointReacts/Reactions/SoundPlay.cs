using UnityEngine;

namespace WKMR.System.PointReacts.Reactions
{
    public class SoundPlay : Reaction
    {
        private readonly AudioClip _clip;
        private readonly AudioSource _source;

        public SoundPlay(AudioClip clip, AudioSource source)
        {
            _clip = clip;
            _source = source;
        }

        public override void React() => _source.PlayOneShot(_clip);

        public override void SetDefault() { }
    }
}