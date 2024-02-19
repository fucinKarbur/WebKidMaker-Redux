using UnityEngine;
using UnityEngine.UI;
using YG;

namespace WKMR
{
    [RequireComponent(typeof(Toggle))]
    public class ModeToggle : MonoBehaviour
    {
        [SerializeField] private ModeManager _manager;
        [SerializeField] private Toggle _liteModeToggle;

        private Toggle _toggle;

        private void Awake() => _toggle = GetComponent<Toggle>();

        private void OnEnable() => _toggle.isOn = YandexGame.savesData.ReadyForSurgery;

        public void OnValueChanged()
        {
            _manager.ChangeMind(_toggle.isOn);

            _liteModeToggle.interactable = _toggle.isOn;
        }
    }
}