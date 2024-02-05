using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WKMR.Coloring
{
    public class ColoringButton : MonoBehaviour
    {
        [SerializeField] private Palette _palette;

        public void TryToColor(Image image)
        {
            if (_palette != null)
            {
                OpenPalette();
                _palette.ColorSend += (color) => ColorImage(image, color);
            }
            else
            {
                return;
            }
        }

        public void TryToColor(ClothTemplate template, Palette palette)
        {
            OpenPalette(palette);

            if (_palette != null)
                _palette.ColorSend += template.SetColor;
            else
                return;
        }

        public void TryToColor(Image image, Palette palette)
        {
            OpenPalette(palette);

            if (_palette != null)
                _palette.ColorSend += (color) => ColorImage(image, color);
            else
                return;
        }

        public void SetDefault(Image image) => image.color = Color.white;

        private void ColorImage(Image image, Color color) => image.color = color;

        private void OpenPalette(Palette palette = null)
        {
            if (palette != null)
                _palette = palette;

            _palette.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(_palette.gameObject);
        }
    }
}