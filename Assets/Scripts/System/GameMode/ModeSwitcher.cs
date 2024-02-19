using UnityEngine;
using UnityEngine.UI;
using WKMR.System;
using YG;

namespace WKMR
{
    public class ModeSwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject[] _defaultComponents;
        [SerializeField] private GameObject[] _surgeryComponents;
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _defaultIcon;
        [SerializeField] private Sprite _surgeryIcon;
        [SerializeField] private Kid _kid;
        [SerializeField] private SurgeryMessage _message;

        private DefaultMode _defaultMode;
        private SurgeryMode _surgeryMode;
        
        public bool IsSurgery { get; private set; }

        private void Awake()
        {
            SwitchIcon(_defaultIcon);

            _defaultMode = new(_image, _kid, _defaultComponents, _surgeryComponents);
            _surgeryMode = new(_image, _kid, _surgeryComponents, _defaultComponents);
        }

        private void OnEnable() => ModeManager.Instance.ModeChanged += OnModeChanged;

        private void OnDisable() => ModeManager.Instance.ModeChanged -= OnModeChanged;

        public void SetMode()
        {
            if (YandexGame.savesData.ReadyForSurgery == false)
            {
                TryShowMessage();
                return;
            }

            if (IsSurgery)
                SetDefaultMode();
            else
                SetSurgeonMode();
        }

        public void SetDefaultMode()
        {
            IsSurgery = false;
            _defaultMode.Enter();
            SwitchIcon(_surgeryIcon);
        }

        public void OnWindowClosed()
        {
            SetDefaultMode();
            SwitchIcon(_defaultIcon);
        }

        private void SetSurgeonMode()
        {
            IsSurgery = true;
            _surgeryMode.Enter();
            SwitchIcon(_defaultIcon);
        }

        private void TryShowMessage()
        {
            if (YandexGame.savesData.SurgeryRefused == false)
                _message.gameObject.SetActive(true);
            else if (YandexGame.savesData.SurgeryRefused)
                MessageManager.Instance.ShowMessage(ErrorType.SurgeryWasRefused);
            else
                SetDefaultMode();
        }

        private void SwitchIcon(Sprite sprite) => _image.sprite = sprite;

        private void OnModeChanged()
        {
            if (IsSurgery && YandexGame.savesData.SurgeryRefused)
                SetDefaultMode();
        }
    }
}