using UnityEngine;
using UnityEngine.EventSystems;
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

        [SerializeField] private Palette _palette;
        [SerializeField] private ClearButton _clearButton;
        [SerializeField] private ClothContainer _container;
        [SerializeField] private ClothTemplate _template;

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

        public void Spawn()
        {
            if (TryToSpawn())
            {
                _clearButton.Clear();

                var spawned = Instantiate(_template, _container.transform.position, Quaternion.identity, _container.transform);
                SetItem(spawned);
            }
        }

        protected virtual void SetItem(ClothTemplate spawned)
        {
            spawned.SetImage(Item.Icon);
            spawned.gameObject.name = Item.name;
            spawned.transform.localPosition += Item.Offset;

            if (Item.Colorable)
                _coloringButton.TryToColor(spawned, _palette);
        }

        private bool TryToSpawn()
        {
            if (_container.gameObject.activeInHierarchy)
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