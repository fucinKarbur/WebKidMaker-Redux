using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WKMR.Coloring
{
    public class Palette : MonoBehaviour, IDeselectHandler
    {
        [SerializeField] private GameObject[] _variants;

        private Color _color;

        public event Action<Color> ColorSelected;

        private void OnEnable()
        {
            _color = Color.white;

            var palette = _variants[UnityEngine.Random.Range(0, _variants.Length)];
            palette.SetActive(true);
        }

        private void OnDisable()
        {
            ColorSelected = null;
            
            foreach (var variant in _variants)
                variant.SetActive(false);
        }

        public void OnDeselect(BaseEventData eventData) => Deselect(eventData as PointerEventData);

        public void GetColor(Color color)
        {
            _color = color;
            Disable();
        }

        private void Disable()
        {
            ColorSelected?.Invoke(_color);
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