using UnityEngine;
using UnityEngine.UI;
using YG;

namespace WKMR
{
    [RequireComponent(typeof(Toggle))]
    public class ModeToggle : MonoBehaviour
    {
        [SerializeField] private SurgeryMessage _switcher;

        private Toggle _toggle;

        private void Awake() => _toggle = GetComponent<Toggle>();

        private void OnEnable() => _toggle.isOn = YandexGame.savesData.ReadyForSurgery;

        public void OnValueChanged() => _switcher.ChangeMind(_toggle.isOn);
    }
}