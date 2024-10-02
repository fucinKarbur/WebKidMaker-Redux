using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WKMR.Coloring
{
    public class Palette : MonoBehaviour, IDeselectHandler
    {
        [SerializeField] private GameObject[] _variants;

        private Color _color;
        private GameObject _currentVariant;

        public event Action<Color> ColorSelected;

        private void OnEnable()
        {
            _color = Color.white;
            SetPaletteVariant();
        }

        private void SetPaletteVariant()
        {
            _currentVariant = _variants[UnityEngine.Random.Range(0, _variants.Length)];

            foreach (var variant in _variants)
                variant.SetActive(variant == _currentVariant);
        }

        public void OnDeselect(BaseEventData eventData) => Deselect(eventData as PointerEventData);

        public void SetColor(Color color) => _color = color == null ? Color.white : color;

        private void Disable()
        {
            ColorSelected?.Invoke(_color);
            gameObject.SetActive(false);
        }

        private void Deselect(PointerEventData eventData)
        {
            if (eventData == null || eventData.pointerEnter == null || !TryGetColor(eventData, out var color))
            {
                Disable();
                return;
            }

            SetColor(color.Color);
            Disable();
        }

        private bool TryGetColor(PointerEventData eventData, out PaletteColor color) => eventData.pointerEnter.TryGetComponent(out color);
    }
}