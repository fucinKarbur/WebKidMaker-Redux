using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace WKMR
{
    public class BgClipSwitcher : MonoBehaviour
    {
        private int GetBgClipIndex()
        {
            var source = SourcePool.MusicSource;

            if (source != null)
            {
                var current = SoundAssets.Instance.BgClips.FirstOrDefault(clip => clip.Clip == SourcePool.MusicSource.clip);
                return SoundAssets.Instance.BgClips.IndexOf(current);
            }

            return 0;
        }

        public void NextBgClip()
        {
            var index = GetBgClipIndex();
            index++;

            if (index == SoundAssets.Instance.BgClips.Count)
                index = 0;

            SwitchClip(index);
        }

        public void PreviousBgClip()
        {
            var index = GetBgClipIndex();
            index--;

            if (index < 0)
                index = SoundAssets.Instance.BgClips.Count - 1;

            SwitchClip(index);
        }

        private void SwitchClip(int index)
        {
            if (SourcePool.MusicSource != null)
                SourcePool.MusicSource.clip = SoundAssets.Instance.BgClips[index].Clip;

            SourcePool.MusicSource.Play();
        }
    }
}