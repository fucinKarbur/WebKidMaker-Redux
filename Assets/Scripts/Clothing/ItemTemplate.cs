using System;
using System.Linq;
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

        /* public void Initialize(){
            Debug.Log("inited" + gameObject.name);
            SavesManager.Items.Add(this);
        }

        private void OnDestroy() => SavesManager.Items.Remove(this);

        public void Load(ItemData item, Color color)
        {
            GetItem(item);
            SetImage(Item.Icon);
            SetColor(color);
            gameObject.name = Item.name;
            transform.localPosition = Item.Offset;
            Initialize();
        } */

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