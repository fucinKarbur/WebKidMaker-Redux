using UnityEngine;
using UnityEngine.UI;
using WKMR.Coloring;

namespace WKMR
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(ColoringButton))]
    public class ItemButton : MonoBehaviour
    {
        [SerializeField] protected ItemData Item;
        [SerializeField] protected ClothContainer Container;
        [SerializeField] protected ClothTemplate Template;

        [SerializeField] private Palette _palette;
        [SerializeField] private ClearButton _clearButton;

        private Image _icon;
        private Button _button;
        private ColoringButton _coloringButton;

        private void Awake()
        {
            _icon = GetComponent<Image>();
            _button = GetComponent<Button>();
            _coloringButton = GetComponent<ColoringButton>();

            _icon.sprite = Item.Icon;
        }

        private void OnEnable() => _button.onClick.AddListener(Spawn);

        private void OnDisable() => _button.onClick.RemoveListener(Spawn);

        public virtual void Spawn()
        {
            if (TryToSpawn())
            {
                _clearButton.Clear();

                var spawned = Instantiate(Template, Container.transform.position, Quaternion.identity, Container.transform);
                SetItem(spawned);
            }
        }

        protected virtual void SetItem(ClothTemplate spawned)
        {
            spawned.GetItem(Item);
            spawned.SetImage(Item.Icon);
            spawned.gameObject.name = Item.name;
            spawned.transform.localPosition += Item.Offset;

            if (Item.Colorable)
                _coloringButton.TryToColor(spawned, _palette);
        }

        protected bool TryToSpawn()
        {
            if (Container.gameObject.activeInHierarchy)
            {
                return true;
            }
            else
            {
                MessageManager.Instance.ShowMessage(MessageManager.KidClosed);
                return false;
            }
        }
    }
}