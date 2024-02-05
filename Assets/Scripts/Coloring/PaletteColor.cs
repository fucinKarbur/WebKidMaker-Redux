using UnityEngine;
using UnityEngine.UI;

namespace WKMR.Coloring
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Button))]
    public class PaletteColor : MonoBehaviour
    {
        [SerializeField] private Palette _palette;

        private Button _button;

        public Color Color { get; private set; }

        private void Awake()
        {
            Color = GetComponent<Image>().color;
            _button = GetComponent<Button>();
        }

        private void OnEnable() => _button.onClick.AddListener(SendColor);

        private void OnDisable() => _button.onClick.RemoveListener(SendColor);

        public void SendColor() => _palette.GetColor(Color);
    }
}