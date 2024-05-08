using System.Collections;
using UnityEngine;

namespace WKMR
{
    public class MusicAssets : SoundAssets
    {
        protected MusicPool _sourcePool;

        private AudioClip _currentClip;

        private void Awake()
        {
            _sourcePool = new MusicPool(Container, this);
            SourcePool = _sourcePool;
        }

        public void ChangeMusic(AudioClip clip = null)
        {
            if (clip == null)
            {
                _sourcePool.Sources[0].clip = _currentClip;
            }
            else
            {
                _currentClip = _sourcePool.Sources[0].clip;
                _sourcePool.Sources[0].clip = clip;
            }

            _sourcePool.Sources[0].Play();
        }
    }
}
