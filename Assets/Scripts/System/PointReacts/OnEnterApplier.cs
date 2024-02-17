using UnityEngine.EventSystems;
using YG;

namespace WKMR.System.PointReacts
{
    public class OnEnterApplier : PointerApplier, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (YandexGame.EnvironmentData.isDesktop)
                React();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            SetDefault();
        }
    }
}
