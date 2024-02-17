using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WKMR.System;
using YG;

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
        [SerializeField] private SurgeryMessage _message;
        [SerializeField] private Toggle _toggle;

        private bool _surgeonMode;

        private void Awake()
        {
            _image.sprite = _defaultIcon;
            _toggle.isOn = YandexGame.savesData.ReadyForSurgery;
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
                    SetMode();
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

        private void SetMode()
        {
            if (YandexGame.savesData.ReadyForSurgery == false)
            {
                TryShowMessage();
                return;
            }

            if (_surgeonMode)
                SetDefaultMode();
            else
                SetSurgeonMode();
        }

        private void TryShowMessage()
        {
            if (YandexGame.savesData.SurgeryRefused == false)
                _message.gameObject.SetActive(true);
            else
                SetDefaultMode();
        }

        protected override void OnWindowClosed()
        {
            SetDefaultMode();
            _image.sprite = _defaultIcon;
        }
    }
}
