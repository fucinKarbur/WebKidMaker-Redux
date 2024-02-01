using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WKMR
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]
    public class ItemButton : MonoBehaviour
    {
        [SerializeField] private Palette _palette;
        [SerializeField] private ClearButton _clearButton;
        [SerializeField] private ItemData _item;
        [SerializeField] private ClothContainer _container;
        [SerializeField] private ClothTemplate _template;

        private Image _icon;
        private Button _button;

        private void Awake()
        {
            _icon = GetComponent<Image>();
            _button = GetComponent<Button>();

            _icon.sprite = _item.Icon;
        }

        private void OnEnable() => _button.onClick.AddListener(Spawn);

        private void OnDisable() => _button.onClick.RemoveListener(Spawn);

        public void Spawn()
        {
            _clearButton.Clear();

            var spawned = Instantiate(_template, _container.transform.position, Quaternion.identity, _container.transform);
            SetItem(spawned);
        }

        private void SetItem(ClothTemplate spawned)
        {
            spawned.SetImage(_item.Icon);
            spawned.gameObject.name = _item.name;
            spawned.transform.localPosition += _item.Offset;
            TryToColor(spawned);
        }

        private void TryToColor(ClothTemplate template)
        {
            if (_item.Colorable && _palette != null)
            {
                _palette.gameObject.SetActive(true);
                EventSystem.current.SetSelectedGameObject(_palette.gameObject);
                _palette.ColorSend += template.SetColor;
            }
            else
            {
                return;
            }
        }
    }
}