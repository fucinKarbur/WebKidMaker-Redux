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

        private readonly Dictionary<string, Dictionary<string, string>> _messages = new()
        {
            { MessageManager.KidClosed, new Dictionary<string, string>()
                {
                    { "ru", "Действие невозможно.\nКид должен быть открыт!" },
                    { "en", "Action is impossible.\nThe Kid must be open!" },
                    { "tr", "Harekete geçmek imkansız.\nÇocuk açık olmalı!" }
                }
            },
            { MessageManager.NoEars, new Dictionary<string, string>()
                {
                    { "ru", "Некуда вешать серьги!\nУ кида должны быть уши." },
                    { "en", "There's nowhere to put the earrings!\nA kiddo should have ears." },
                    { "tr", "Küpeleri asacak yer yok!\nBir çocuğun kulakları olmalı." }
                }
            },
            { MessageManager.NotHumanEars, new Dictionary<string, string>()
                {
                    { "ru", "Серьги можно надеть только на уши,\nпохожие на человеческие." },
                    { "en", "Earrings can only be worn on ears\nthat look like human ears." },
                    { "tr", "Küpeler sadece insan kulağına\nbenzeyen kulaklara takılabilir." }
                }
            },
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
