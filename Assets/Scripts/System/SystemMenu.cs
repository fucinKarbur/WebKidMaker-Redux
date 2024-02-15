using UnityEngine;
using UnityEngine.EventSystems;

namespace WKMR.System
{
    public class SystemMenu : MonoBehaviour, IPointerExitHandler
    {
        public void OnPointerExit(PointerEventData eventData)
        {
            gameObject.SetActive(false);
        }
    }
}