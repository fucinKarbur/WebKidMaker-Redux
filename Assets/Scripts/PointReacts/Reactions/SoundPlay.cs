using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace WKMR.PointReacts.Reactions
{
    public class SoundPlay : Reaction
    {
        private AudioClip _clip;
        private AudioSource _source;

        public SoundPlay(AudioClip clip, AudioSource source)
        {
            _clip = clip;
            _source = source;
        }

        public override void React()
        {
            _source.PlayOneShot(_clip);
        }

        public override void SetDefault()
        {
        }
    }
}