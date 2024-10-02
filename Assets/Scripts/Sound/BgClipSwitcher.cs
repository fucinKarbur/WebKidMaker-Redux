using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace WKMR
{
    public class BgClipSwitcher : MonoBehaviour
    {
        [SerializeField] private TMP_Text _indexText;
        [SerializeField] private MusicAssets _assets;
        [SerializeField] private Toggle _autoSwitcher;

        private AudioSource _source;
        private WaitForSeconds _clipPlaytime;
        private int _index;
        private int _amount;
        private bool _autoPlay;

        private List<SoundClip> _clips => _assets.SoundClips;

        private void Awake()
        {
            _source = _assets.Pool.Sources.FirstOrDefault();
            _autoSwitcher.isOn = _autoPlay = YandexGame.savesData.AutoBGPlay;
            _index = GetClipIndex();
            _amount = _clips.Count;

            SwitchAutoPlay();
            UpdateDisplay();
        }

        public void SwitchAutoPlay()
        {
            /* if (value != _autoPlay)
            { */
            _autoPlay = _autoSwitcher.isOn;

            if (_autoPlay)
                StartCoroutine(AutoChangeMusic());
            else
                StopCoroutine(AutoChangeMusic());

            YandexGame.savesData.AutoBGPlay = _autoPlay;
            YandexGame.SaveProgress();
            /* } */
        }

        public void NextClip()
        {
            _index++;

            if (_index == _amount)
                _index = 0;

            SwitchClip();
        }

        public void PreviousClip()
        {
            _index--;

            if (_index < 0)
                _index = _amount - 1;

            SwitchClip();
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

        private void SwitchClip()
        {
            if (_source != null)
                _source.clip = _clips[_index].Clip;

            _source.Play();
            UpdateDisplay();
        }

        private void UpdateDisplay() => _indexText.text = _index + 1 + " / " + _amount;

        private IEnumerator AutoChangeMusic()
        {
            var volume = _source.volume;
            var duration = 1f;

            while (_autoPlay)
            {
                _clipPlaytime = new(_source.clip.length * 3 - duration);
                //_source.DOFade(.1f, duration);
                yield return _clipPlaytime;
                NextClip();
                //_source.DOFade(volume, duration);
            }
        }
    }
}