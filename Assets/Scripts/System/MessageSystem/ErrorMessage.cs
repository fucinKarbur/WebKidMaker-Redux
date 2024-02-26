using TMPro;
using UnityEngine;

namespace WKMR.System
{
    public class ErrorMessage : MonoBehaviour
    {
        private TMP_Text _text;
        private ErrorText _errorText;
        private SoundPlayer _player;

        private void Awake()
        {
            _text = GetComponentInChildren<TMP_Text>();
            _errorText = new ();
            _player = new(SoundName.Error);
        }

        public void Show(ErrorType type)
        {
            _text.text = _errorText.GetText(type);
            _player.PlaySound();
        }
    }
}