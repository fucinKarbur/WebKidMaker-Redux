using UnityEngine;
using UnityEngine.EventSystems;

namespace WKMR.System
{
    public class Shortcut : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] protected Window Window;

        public bool IsOpen => Window.gameObject.activeSelf;

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging == false)
                if (IsOpen == false)
                    Window.gameObject.SetActive(true);
        }
    }
}