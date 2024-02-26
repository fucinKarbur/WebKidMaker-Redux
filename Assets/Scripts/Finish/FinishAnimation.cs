using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using WKMR.System;
using YG;

namespace WKMR
{
    public class FinishAnimation : MonoBehaviour
    {
        [SerializeField] private AudioClip _clip;
        [SerializeField] private List<AnimationElement> _elements = new();
        [SerializeField] private KidScreener _screener;
        [SerializeField] private ReviewWindow _reviewWindow;

        private Texture2D _texture => _screener.LastScreenShot;
        private MusicAssets _music;
        private float _duration = 7;

        private void Awake() => _music = SystemCanvas.Instance.Music;

        private void OnEnable() => StartCoroutine(Play());

        public void Skip()
        {
            foreach (var element in _elements)
                element.Stop();

            _reviewWindow.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        private IEnumerator Play()
        {
            if (_texture != null)
                foreach (var element in _elements)
                    element.SetImage(_texture);

            foreach (var element in _elements)
                StartCoroutine(element.Play());

            _music.ChangeMusic(_clip);

            yield return new WaitForSeconds(_duration);

            Skip();
        }
    }
}