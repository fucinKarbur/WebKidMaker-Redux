using System;
using UnityEngine;
using YG;

namespace WKMR
{
    public class ModeManager : MonoBehaviour
    {
        public static ModeManager Instance;

        [SerializeField] private SurgeryMessage _message;
        [SerializeField] private ModeSwitcher _switcher;

        public bool IsSurgery => _switcher.IsSurgery;

        public event Action ModeChanged;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void ChangeMind(bool accept)
        {
            if (accept)
                AcceptSurgery();
            else
                RefuseSurgery();
        }

        public void SetLite(bool accept)
        {
            if (accept)
                AcceptLiteMode();
        }

        public void AcceptLiteMode()
        {
            YandexGame.savesData.ReadyForSurgery = true;
            YandexGame.savesData.SurgeryRefused = false;
            YandexGame.savesData.LiteMode = true;
            OnModeChanged();
        }

        public void AcceptSurgery()
        {
            YandexGame.savesData.ReadyForSurgery = true;
            YandexGame.savesData.SurgeryRefused = false;
            YandexGame.savesData.LiteMode = false;
            OnModeChanged();
        }

        public void RefuseSurgery()
        {
            YandexGame.savesData.ReadyForSurgery = false;
            YandexGame.savesData.SurgeryRefused = true;
            YandexGame.savesData.LiteMode = false;
            OnModeChanged();
        }

        private void OnModeChanged()
        {
            _message.gameObject.SetActive(false);
            YandexGame.SaveProgress();
            ModeChanged?.Invoke();
        }
    }
}