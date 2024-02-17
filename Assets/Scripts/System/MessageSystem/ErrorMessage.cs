using TMPro;
using UnityEngine;
using WKMR.Assets.Scripts.System.MessageSystem;
using YG;

namespace WKMR
{
    public class ErrorMessage : MonoBehaviour
    {
        private TMP_Text _text;
        private ErrorText _errorText;
        private SoundPlayer _player;

        private void Awake()
        {
            _text = GetComponentInChildren<TMP_Text>();
            _errorText = new (YandexGame.EnvironmentData.language);
            _player = new(SoundName.Error);
        }

        public void Show(ErrorType type)
        {
            _text.text = _errorText.GetText(type);
            _player.PlaySound();
        }
    }
}