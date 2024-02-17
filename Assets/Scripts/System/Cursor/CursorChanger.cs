using UnityEngine;
using UnityEngine.EventSystems;

namespace WKMR
{
    public class CursorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        public void OnPointerEnter(PointerEventData eventData) => ChangeCursor(CursorType.Enter);

        public void OnPointerExit(PointerEventData eventData) => ChangeCursor(CursorType.Default);

        public void OnBeginDrag(PointerEventData eventData) => ChangeCursor(CursorType.Drag);

        public void OnEndDrag(PointerEventData eventData) => ChangeCursor(CursorType.Default);

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.dragging == false)
                ChangeCursor(CursorType.Click);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.selectedObject == gameObject)
                ChangeCursor(CursorType.Enter);
            else
                ChangeCursor(CursorType.Default);
        }

        private void ChangeCursor(CursorType type) => CursorManager.Instance.ChangeCursor(type);
    }
}