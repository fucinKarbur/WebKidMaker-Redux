using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

namespace WKMR
{
    public class ErrorMessage : MonoBehaviour
    {
        private TMP_Text _text;
        private string _language;

        private Dictionary<string, Dictionary<string, string>> _messages = new()
        {{
    MessageManager.KidClosed, new Dictionary<string, string>()
    {
        { "ru", "Привет" },
        { "en", "Hello" },
        { "tr", "Merhaba" }
    }},
        };

        private void Awake()
        {
            _text = GetComponentInChildren<TMP_Text>();
            _language = YandexGame.EnvironmentData.language;
        }

        public void Show(string errorCode)
        {
            _text.text = Message(errorCode);
        }

        private string Message(string errorCode)
        {
            return _messages[errorCode][_language];
        }
    }
}
