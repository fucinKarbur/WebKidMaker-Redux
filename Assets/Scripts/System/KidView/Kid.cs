using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace WKMR.System
{
    [RequireComponent(typeof(RectTransform))]
    public class Kid : MonoBehaviour
    {
        [SerializeField] private ScaleButton _scaleButton;
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private GameObject[] _defaultComponents;

        private RectTransform _transform;
        private Vector3 _surgeonScale = new(1.7f, 1.7f, 0);
        private Vector3 _surgeonPosition = new(0, -170, 0);

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
        }

        public void PrepareForSurgeon()
        {
            _transform.anchoredPosition = _surgeonPosition;
            _scaleButton.ChangeScale(_surgeonScale);
            _scrollRect.enabled = false;
            SwitchCloth(false);
        }

        public void SetDefault()
        {
            _scaleButton.Reset();
            _scrollRect.enabled = true;
            SwitchCloth(true);
        }

        private void SwitchCloth(bool enable)
        {
            foreach (var item in _defaultComponents)
                item.SetActive(enable);
        }
    }
}