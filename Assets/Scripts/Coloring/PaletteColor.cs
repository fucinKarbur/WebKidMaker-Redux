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

        private void Start() => _button.onClick.AddListener(SendColor);

        private void OnDestroy() => _button.onClick.RemoveListener(SendColor);

/// <summary>
/// плохо, что цвет палитры вызывает у палитры смену цвета
/// </summary>
        public void SendColor() => _palette.SetColor(Color);
    }
}