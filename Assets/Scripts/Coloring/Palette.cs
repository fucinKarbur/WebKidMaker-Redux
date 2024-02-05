using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WKMR.Coloring
{
    public class Palette : MonoBehaviour, IDeselectHandler
    {
        private Color _color;

        public event Action<Color> ColorSend;

        private void OnEnable() => _color = Color.white;

        private void OnDisable() => ColorSend = null;

        public void OnDeselect(BaseEventData eventData) => Deselect(eventData as PointerEventData);

        public void GetColor(Color color)
        {
            _color = color;
            Disable();
        }

        private void Disable()
        {
            ColorSend?.Invoke(_color);
            gameObject.SetActive(false);
        }

        private void Deselect(PointerEventData eventData)
        {
            if (eventData.pointerEnter.TryGetComponent(out PaletteColor color))
                GetColor(color.Color);
            else
                Disable();
        }
    }
}