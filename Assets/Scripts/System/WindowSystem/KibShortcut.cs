using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WKMR.System;

namespace WKMR.System
{
    public class KibShortcut : Shortcut
    {
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _defaultIcon;
        [SerializeField] private Sprite _surgeonIcon;
        [SerializeField] private Kid _kid;
        [SerializeField] private GameObject[] _defaultComponents;
        [SerializeField] private GameObject[] _surgeonComponents;

        private bool _surgeonMode;

        public bool Surgeon => _surgeonMode;

        private void Awake()
        {
            //_surgeonMode = false;
            _image.sprite = _defaultIcon;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging == false)
                if (IsOpen == false)
                {
                    Window.gameObject.SetActive(true);
                    SetDefaultMode();
                }
                else
                {
                    if (_surgeonMode)
                        SetDefaultMode();
                    else
                        SetSurgeonMode();
                }
        }

        private void SetDefaultMode()
        {
            _surgeonMode = false;
            _kid.SetDefault();
            SwitchIcon(_surgeonIcon);
            SwitchComponents(_defaultComponents, _surgeonComponents);
        }

        private void SetSurgeonMode()
        {
            _surgeonMode = true;
            _kid.PrepareForSurgeon();
            SwitchIcon(_defaultIcon);
            SwitchComponents(_surgeonComponents, _defaultComponents);
        }

        private void SwitchComponents(GameObject[] enable, GameObject[] disable)
        {
            foreach (var item in enable)
                item.SetActive(true);

            foreach (var item in disable)
                item.SetActive(false);
        }

        private void SwitchIcon(Sprite sprite) => _image.sprite = sprite;
    }
}
