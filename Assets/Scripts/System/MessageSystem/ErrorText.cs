using System.Collections.Generic;
using UnityEngine;
using YG;

namespace WKMR.System
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
                    { En, "complete the operation first." },
                    { Tr, "önce işlemi tamamlayın." }
                }
            },
            { ErrorType.FeedbackFileError, new Dictionary<string, string>()
                {
                    { Ru, "Ошибка: Не удалось прикрепить файл к отчету!\n" },
                    { En, "Error: Failed to attach file to report!\n" },
                    { Tr, "Hata oluştu: Rapora dosya eklenemedi!\n" }
                }
            },
            { ErrorType.FeedbackSubmitted, new Dictionary<string, string>()
                {
                    { Ru, "Отзыв успешно отправлен!" },
                    { En, "Feedback submitted successfully!" },
                    { Tr, "Geri bildirim başarıyla gönderildi!" }
                }
            },
            { ErrorType.FeedbackSending, new Dictionary<string, string>()
                {
                    { Ru, "Отправка..." },
                    { En, "Submitting..." },
                    { Tr, "Gönderiyorum..." }
                }
            },
            { ErrorType.FeedbackError, new Dictionary<string, string>()
                {
                    { Ru, "Ошибка: Не удалось загрузить отчет!\n" },
                    { En, "Error: Failed to upload report!\n " },
                    { Tr, "Hata oluştu: Rapor yüklenemedi!\n" }
                }
            },
            { ErrorType.FeedbackShotError, new Dictionary<string, string>()
                {
                    { Ru, "Ошибка: Не удалось сделать снимок экрана!\nПодробнее смотрите журнал." },
                    { En, "Error: Failed to capture screenshot!\nSee log for more detail." },
                    { Tr, "Hata: Ekran görüntüsü alınamadı!\nDaha fazla ayrıntı için günlüğe bakın." }
                }
            },
            { ErrorType.NotEnoughItems, new Dictionary<string, string>()
                {
                    { Ru, "Недостоточно предметов\nдля завершения кида!" },
                    { En, "Not enough items to\ncomplete the kid! " },
                    { Tr, "Atışı tamamlamak için\nyeterli eşya yok!" }
                }
            },
            { ErrorType.NotEnoughOrgans, new Dictionary<string, string>()
                {
                    { Ru, "У вас включен режим операции.\nДобавьте хотя бы несколько органов!" },
                    { En, "You have surgery mode enabled.\nAdd at least a few organs!" },
                    { Tr, "Ameliyat modunu etkinleştirdiniz.\nEn azından birkaç organ ekleyin!" }
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