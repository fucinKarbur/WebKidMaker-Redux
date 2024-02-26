using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace WKMR
{
    [Serializable]
    public class AnimationElement
    {
        [SerializeField] private RawImage _image;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;
        [SerializeField] private float _duration;
        [SerializeField] private Vector3 _scale;
        [SerializeField] private Vector3 _rotation;

        public IEnumerator Play()
        {
            _image.transform.localPosition = _startPoint.position;
            _image.transform.localScale = _scale;
            _image.transform.eulerAngles = _rotation;
            yield return new WaitForEndOfFrame();

            _image.transform.DOMove(_startPoint.position, .1f);
            _image.transform.DOMove(_endPoint.position, _duration * 2);
        }

        public void Stop()
        {
            _image.transform.localPosition = _endPoint.position;
        }

        public void SetImage(Texture2D texture)
        {
            _image.texture = texture;
            _image.SetNativeSize();
        }
    }
}