using UnityEngine;
using UnityEngine.UI;

namespace WKMR
{
    [RequireComponent(typeof(Image))]
    public class ItemTemplate : MonoBehaviour
    {
        public Image Image { get; private set; }
        public ItemData Item { get; private set; }

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

        public virtual void SetColor(Color color) => Image.color = color;

        public void GetItem(ItemData data) => Item = data;
    }
}