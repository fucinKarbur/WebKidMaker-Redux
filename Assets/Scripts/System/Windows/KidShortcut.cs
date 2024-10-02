using UnityEngine;
using UnityEngine.EventSystems;

namespace WKMR.System
{
    [RequireComponent(typeof(ModeSwitcher))]
    public class KidShortcut : Shortcut
    {
        private ModeSwitcher _modeSwitcher;

        private void Awake() => _modeSwitcher = GetComponent<ModeSwitcher>();

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging == false)
                if (IsOpen == false)
                {
                    Window.gameObject.SetActive(true);
                    _modeSwitcher.SetDefaultMode();
                }
                else
                {
                    _modeSwitcher.SetMode();
                }
        }

        protected override void OnWindowClosed() => _modeSwitcher.OnWindowClosed();
    }
}