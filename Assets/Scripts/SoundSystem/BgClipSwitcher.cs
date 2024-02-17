using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace WKMR
{
    public class BgClipSwitcher : MonoBehaviour
    {
        [SerializeField] private TMP_Text _indexText;

        private AudioSource _source;
        private List<AudioClip> _clips = new();
        private int _index;
        private int _amount;

        private void OnEnable()
        {
            _source = SourcePool.MusicSource;
            GetClips();
            _index = GetClipIndex();
            _amount = _clips.Count;

            UpdateDisplay();
        }

        private int GetClipIndex()
        {
            if (_source != null)
            {
                var current = SoundAssets.Instance.BgClips.FirstOrDefault(clip => clip.Clip == SourcePool.MusicSource.clip);
                return SoundAssets.Instance.BgClips.IndexOf(current);
            }

            return 0;
        }

        private void GetClips()
        {
            foreach (var sound in SoundAssets.Instance.BgClips)
                    _clips.Add(sound.Clip);
        }

        public void NextBgClip()
        {
            _index++;

            if (_index == _amount)
                _index = 0;

            SwitchClip();
        }

        public void PreviousBgClip()
        {
            _index--;

            if (_index < 0)
                _index = _amount - 1;

            SwitchClip();
        }

        private void SwitchClip()
        {
            if (_source != null)
                _source.clip = _clips[_index];

            SourcePool.MusicSource.Play();
            UpdateDisplay();
        }

        private void UpdateDisplay() => _indexText.text = _index + 1 + " / " + _amount;
    }
}