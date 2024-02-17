using System.Collections;
using System.Collections.Generic;
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

        private void Awake()
        {
            _text = GetComponentInChildren<TMP_Text>();
            _errorText = new (YandexGame.EnvironmentData.language);
        }

        public void Show(ErrorType type)
        {
            _text.text = _errorText.GetText(type);
        }
    }
}
