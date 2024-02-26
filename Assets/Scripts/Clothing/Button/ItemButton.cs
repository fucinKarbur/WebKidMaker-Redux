using UnityEngine;
using UnityEngine.UI;
using WKMR.Coloring;
using WKMR.System;

namespace WKMR
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(ColoringButton))]
    public class ItemButton : MonoBehaviour
    {
        [SerializeField] protected ItemData Item;
        [SerializeField] protected ItemContainer Container;
        [SerializeField] protected ItemTemplate Template;

        [SerializeField] private Palette _palette;
        [SerializeField] private ClearButton _clearButton;

        private Image _image;
        private Button _button;
        private ColoringButton _coloringButton;

        public ItemContainer ClothContainer => Container;
        public ItemData ItemData => Item;
        public Image Image => _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _button = GetComponent<Button>();
            _coloringButton = GetComponent<ColoringButton>();

            _image.sprite = Item.Icon;
        }

        protected virtual void OnEnable() => _button.onClick.AddListener(Spawn);

        protected virtual void OnDisable() => _button.onClick.RemoveListener(Spawn);

        public virtual void Spawn()
        {
            if (TryToSpawn())
            {
                _clearButton.Clear();

                var spawned = Instantiate(Template, Container.transform.position, Quaternion.identity, Container.transform);
                SetItem(spawned);
            }
        }

        protected virtual void SetItem(ItemTemplate spawned)
        {
            spawned.GetItem(Item);
            spawned.SetImage(Item.Icon);
            spawned.gameObject.name = Item.name;
            spawned.transform.localPosition += Item.Offset;

            if (Item.Colorable)
                _coloringButton.TryToColor(spawned, _palette);

                //spawned.Initialize();
        }

        public bool TryToSpawn()
        {
            if (Container.gameObject.activeInHierarchy == false)
            {
                if (ModeManager.Instance.IsSurgery)
                    MessageManager.Instance.ShowMessage(ErrorType.IsSurgery);
                else
                    MessageManager.Instance.ShowMessage(ErrorType.KidClosed);

                return false;
            }
            
            return true;
        }
    }
}