using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace WKMR
{
    public class FinishAnimation : MonoBehaviour
    {
        //[SerializeField] List<RawImage> imagesToAnimate;
        [SerializeField] private List<AnimationElement> _elements = new();

        private Texture2D _texture;

        private void Awake()
        {
            KidConverter converter = new();
            Debug.Log(YandexGame.savesData.KidInBytes.Length);
            _texture = converter.ConvertBytesToTexture(YandexGame.savesData.KidInBytes[^1]);
        }

        private void Start()
        {
            if (_texture != null)
                foreach (var element in _elements)
                    element.SetImage(_texture);

            foreach (var element in _elements)
                StartCoroutine(element.Play());
        }

        public void Skip()
        {
            foreach (var element in _elements)
                StopAllCoroutines();
        }
    }
}
