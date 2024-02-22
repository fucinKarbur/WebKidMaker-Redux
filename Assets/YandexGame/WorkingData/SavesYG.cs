
using UnityEngine;
using WKMR;

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

        //public Texture2D[] KidTextures;
        public byte[][] KidInBytes;

        public SavesYG()
        {
            ReadyForSurgery = false;
            SurgeryRefused = false;
            LiteMode = false;

            PopupsAvailable = true;

            SFXVolume = 1;
            MusicVolume = .5f;

            KidInBytes = new byte[0][];
            //KidTextures = new Texture2D[0];
        }
    }
}