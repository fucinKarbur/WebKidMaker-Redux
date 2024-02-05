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
            if (sprite != null && Image != null)
            {
                Image.sprite = sprite;
                Image.SetNativeSize();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SetColor(Color color) => Image.color = color;
    }
}