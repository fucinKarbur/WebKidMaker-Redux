using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YG;

namespace WKMR
{
    public class SurgeryMessage : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _overlay;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.pointerEnter == _overlay.gameObject)
                MessageManager.Instance.ShowMessage(ErrorType.SurgeryMessageOpened);
        }

        public void AcceptSurgery()
        {
            YandexGame.savesData.ReadyForSurgery = true;
            YandexGame.savesData.SurgeryRefused = false;
            gameObject.SetActive(false);
            YandexGame.SaveProgress();
        }

        public void RefuseSurgery()
        {
            YandexGame.savesData.ReadyForSurgery = false;
            YandexGame.savesData.SurgeryRefused = true;
            gameObject.SetActive(false);
            YandexGame.SaveProgress();
        }

        public void ChangeMind(bool accept)
        {
            if (accept)
                AcceptSurgery();
            else
                RefuseSurgery();
        }
    }
}