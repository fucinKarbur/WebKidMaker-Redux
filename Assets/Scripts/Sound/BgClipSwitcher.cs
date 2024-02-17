using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace WKMR
{
    public class BgClipSwitcher : MonoBehaviour
    {
        [SerializeField] private TMP_Text _indexText;
        [SerializeField] private MusicAssets _assets;

        private AudioSource _source;
        private int _index;
        private int _amount;

        private List<SoundClip> _clips => _assets.SoundClips;

        private void Awake()
        {
            _source = _assets.Pool.Sources.FirstOrDefault();
            _index = GetClipIndex();
            _amount = _clips.Count;

            UpdateDisplay();
        }

        private int GetClipIndex()
        {
            if (_source != null)
            {
                var current = _clips.FirstOrDefault(clip => clip.Clip == _source.clip);
                return _clips.IndexOf(current);
            }

            return 0;
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
                _source.clip = _clips[_index].Clip;

            _source.Play();
            UpdateDisplay();
        }

        private void UpdateDisplay() => _indexText.text = _index + 1 + " / " + _amount;
    }
}