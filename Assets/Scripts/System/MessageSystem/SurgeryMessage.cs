using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YG;

namespace WKMR
{
    public class SurgeryMessage : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _overlay;

        public void AcceptSurgery()
        {
            YandexGame.savesData.ReadyForSurgery = true;
            gameObject.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.pointerEnter == _overlay.gameObject)
                MessageManager.Instance.ShowMessage(ErrorType.SurgeryMessageOpened);
        }

        public void RefuseSurgery()
        {
            YandexGame.savesData.SurgeryRefused = true;
            gameObject.SetActive(false);
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
