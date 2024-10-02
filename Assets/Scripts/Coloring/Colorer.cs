using UnityEngine;
using UnityEngine.EventSystems;
using WKMR.Clothing;
using Zenject;

namespace WKMR.Coloring
{
    public class Colorer
    {
        private readonly Palette _palette;
        private ItemTemplate _template;

        public Colorer(Palette palette) => _palette = palette;

        public void Colorize(ItemTemplate template)
        {
            if (template.Item.Colorable)
            {
                if (_palette == null)
                {
                    Debug.LogError("Palette is null");
                    return;
                }

                _template = template;
                OpenPalette();
            }
        }

        private void OpenPalette()
        {
            _palette.gameObject.SetActive(true);
            _palette.ColorSelected += SetColor;
            EventSystem.current.SetSelectedGameObject(_palette.gameObject);
        }

        private void SetColor(Color color)
        {
            _template.SetColor(color);
            _palette.ColorSelected -= SetColor;
        }
    }
}