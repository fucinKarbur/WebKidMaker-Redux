using UnityEngine;
using UnityEngine.UI;

namespace WKMR
{
    [RequireComponent(typeof(Image))]
    public class ClothTemplate : MonoBehaviour
    {
        public Image Image { get; private set; }

        private void Awake() => Image = GetComponent<Image>();

        public void SetImage(Sprite sprite)
        {
            Image.sprite = sprite;
            Image.SetNativeSize();
        }

        public void SetColor(Color color) => Image.color = color;
    }
}