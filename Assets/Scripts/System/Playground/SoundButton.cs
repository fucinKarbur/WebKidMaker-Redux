using UnityEngine;
using UnityEngine.UI;
using WKMR.System;

namespace WKMR
{
    [RequireComponent(typeof(Button))]
    public class SoundButton : MonoBehaviour
    {
        private Button _button;
        private MusicWindow _window;

        private void Awake() => _button = GetComponent<Button>();

        private void Start()
        {
            if (_window == null)
                _window = SystemCanvas.Instance.MusicWindow;

            _button.onClick.AddListener(() => _window.gameObject.SetActive(true));
        }

        private void OnDisable() => _button.onClick.RemoveListener(() => _window.gameObject.SetActive(true));
    }
}
