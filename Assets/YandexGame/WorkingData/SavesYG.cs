﻿
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Ваши сохранения

        public bool ReadyForSurgery;
        public bool SurgeryRefused;
        public bool LiteMode;

        public bool PopupsAvailable;

        public float SFXVolume;
        public float MusicVolume;


        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            ReadyForSurgery = false;
            SurgeryRefused = false;
            LiteMode = false;

            PopupsAvailable = true;

            SFXVolume = 1;
            MusicVolume = .5f;
        }
    }
}