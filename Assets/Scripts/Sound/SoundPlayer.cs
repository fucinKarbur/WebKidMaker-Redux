using System.Linq;
using UnityEngine;

namespace WKMR
{
    public class SoundPlayer
    {
        private readonly SoundName _sound;
        private AudioSource _source;

        public SoundPlayer(SoundName name)
        {
            _sound = name;
            _source = SourceProvider.GetSource(_sound);
        }

        public void PlaySound()
        {
            if (_source != null)
                _source.PlayOneShot(GetClip());
            else
                _source = SourceProvider.GetSource(_sound);
        }

        private AudioClip GetClip()
        {
            var variants = SourceProvider.SFXAssets.SoundClips.Where(clip => clip.Name == _sound).ToList();

            if (variants.Count > 1)
                return variants[Random.Range(0, variants.Count)].Clip;
            else
                return _source.clip;
        }
    }
}