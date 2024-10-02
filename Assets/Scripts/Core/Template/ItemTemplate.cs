using UnityEngine;
using UnityEngine.UI;

namespace WKMR.Clothing
{
    [RequireComponent(typeof(Image))]
    public class ItemTemplate : MonoBehaviour
    {
        protected Image Image;

        public ItemData Item { get; protected set; }
        public bool Initialized => Item != null;

        private void Awake() => Image = GetComponent<Image>();

        public virtual void Initialize(ItemData data)
        {
            Item = data;

            gameObject.name = Item.name;
            transform.localPosition = Vector3.zero + Item.Offset;
            Image.sprite = Item.Icon;
            Image.SetNativeSize();
        }

        public virtual void SetColor(Color color)
        {
            Image.color = color;
        }
    }
}
