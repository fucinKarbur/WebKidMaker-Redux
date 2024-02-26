using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using WKMR.System;
using YG;

namespace WKMR.System
{
    public class KidSaver
    {
        private KidConverter _converter = new();

        public bool TryToSave(Texture2D texture, string name, int health)
        {
            int kidsCount = YandexGame.savesData.Kids.Length;

            if (texture != null)
                Save(texture, name, health);
            else
                return false;

            Debug.Log($"previous - {kidsCount} current - {YandexGame.savesData.Kids.Length} + {YandexGame.savesData.Names.Length} + {YandexGame.savesData.Healthes.Length}.");
            return YandexGame.savesData.Kids.Length != kidsCount;
        }

        private void Save(Texture2D texture, string name, int health)
        {
            SaveKid(texture);
            SaveName(name);
            SaveHealth(health);

            YandexGame.SaveProgress();
        }

        private void SaveKid(Texture2D texture)
        {
            if (texture != null)
            {
                var previousKids = YandexGame.savesData.Kids.ToList();
                previousKids.Add(_converter.ConvertTextureToBytes(texture));

                YandexGame.savesData.Kids = new byte[previousKids.Count][];

                for (int i = 0; i < previousKids.Count; i++)
                    YandexGame.savesData.Kids[i] = previousKids[i];
            }
        }

        private void SaveName(string name)
        {
            if (name == "")
                name = "Kid_" + YandexGame.savesData.Names.Length;

            var previousNames = YandexGame.savesData.Names.ToList();
            previousNames.Add(name);

            YandexGame.savesData.Names = new string[previousNames.Count];

            for (int i = 0; i < previousNames.Count; i++)
                YandexGame.savesData.Names[i] = previousNames[i];
        }

        private void SaveHealth(int health)
        {
            var previousHealth = YandexGame.savesData.Healthes.ToList();
            previousHealth.Add(health);

            YandexGame.savesData.Healthes = new int[previousHealth.Count];

            for (int i = 0; i < previousHealth.Count; i++)
                YandexGame.savesData.Healthes[i] = previousHealth[i];
        }
    }
}