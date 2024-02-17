using UnityEngine.EventSystems;

namespace WKMR.System.PointReacts
{
    public class OnClickApplier : PointerApplier, IPointerClickHandler, IPointerUpHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging == false)
                React();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.dragging == false)
                SetDefault();
        }
    }
}
