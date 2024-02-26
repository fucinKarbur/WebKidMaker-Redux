using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WKMR.System;
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
    }
}