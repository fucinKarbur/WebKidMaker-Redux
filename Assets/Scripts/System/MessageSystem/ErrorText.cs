using System.Collections.Generic;
using UnityEngine;
using YG;

namespace WKMR.Assets.Scripts.System.MessageSystem
{
    public class ErrorText
    {
        private const string Ru = "ru";
        private const string En = "en";
        private const string Tr = "tr";

        private string Language => YandexGame.savesData.language;

        private readonly Dictionary<ErrorType, Dictionary<string, string>> _texts = new()
        {
            { ErrorType.KidClosed, new Dictionary<string, string>()
                {
                    { Ru, "Действие невозможно.\nКид должен быть открыт!" },
                    { En, "Action is impossible.\nThe Kid must be open!" },
                    { Tr, "Harekete geçmek imkansız.\nÇocuk açık olmalı!" }
                }
            },
            { ErrorType.NoEars, new Dictionary<string, string>()
                {
                    { Ru, "Некуда вешать серьги!\nУ кида должны быть уши." },
                    { En, "There's nowhere to put the earrings!\nA kiddo should have ears." },
                    { Tr, "Küpeleri asacak yer yok!\nBir çocuğun kulakları olmalı." }
                }
            },
            { ErrorType.NotHumanEars, new Dictionary<string, string>()
                {
                    { Ru, "Серьги можно надеть только на уши,\nпохожие на человеческие." },
                    { En, "Earrings can only be worn on ears\nthat look like human ears." },
                    { Tr, "Küpeler sadece insan kulağına\nbenzeyen kulaklara takılabilir." }
                }
            },
            { ErrorType.SurgeryMessageOpened, new Dictionary<string, string>()
                {
                    { Ru, "это важный вопрос, влияющий на геймплей.\nпожалуйста, ответьте на него." },
                    { En, "this is an important question that\naffects gameplay. please answer it." },
                    { Tr, "Bu, oyunu etkileyen önemli\nbir soru. Lütfen cevaplayın." }
                }
            },
            { ErrorType.SurgeryWasRefused, new Dictionary<string, string>()
                {
                    { Ru, "вы отказались от этого режима. изменить\nрешение можно в настройках игры." },
                    { En, "you have opted out of this mode. you can\nchange the decision in the game settings." },
                    { Tr, "bu modu iptal ettiniz. oyun ayarlarından\nkararı değiştirebilirsiniz." }
                }
            },
            { ErrorType.IsSurgery, new Dictionary<string, string>()
                {
                    { Ru, "сначала завершите операцию." },
                    { En, "önce işlemi tamamlayın." },
                    { Tr, "complete the operation first." }
                }
            },
        };

        public string GetText(ErrorType errorType)
        {
            return Language switch
            {
                Ru => _texts[errorType][Ru],
                Tr => _texts[errorType][Tr],
                _ => _texts[errorType][En],
            };
        }
    }
}