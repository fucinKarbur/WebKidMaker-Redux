using UnityEngine;
using UnityEngine.EventSystems;

namespace WKMR.System
{
    public class Shortcut : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] protected Window Window;

        public bool IsOpen => Window.gameObject.activeSelf;

        private void OnEnable() => Window.Closed += OnWindowClosed;

        private void OnDisable() => Window.Closed -= OnWindowClosed;

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging == false)
                if (IsOpen == false)
                    Window.gameObject.SetActive(true);
        }

        protected virtual void OnWindowClosed() { }
    }
}