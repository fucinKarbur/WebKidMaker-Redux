using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace WKMR.Coloring
{
    public class Colorer
    {
        private readonly Palette _palette;

        public Colorer(Palette palette) => _palette = palette;

        public void TryToColor(ItemTemplate template)
        {
            if (_palette == null)
            {
                Debug.LogError("Palette is null");
                return;
            }

            OpenPalette();
            _palette.ColorSelected += template.SetColor;
        }

        public void SetDefault(Image image) => image.color = Color.white;

        private void OpenPalette()
        {
            _palette.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(_palette.gameObject);
        }
    }
}