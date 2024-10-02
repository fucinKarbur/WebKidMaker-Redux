using UnityEngine;
using WKMR.Clothing;
using WKMR.Coloring;
using WKMR.System.TabMenu;
using Zenject;

namespace WKMR
{
    public class Page : MonoBehaviour
    {
        [SerializeField] private ItemData[] _items;
        [SerializeField] private ClearButton _clearButton;
        [SerializeField] private ItemTemplate _itemTemplate;
        [SerializeField] private ItemButton _buttonTemplate;
        [SerializeField] private Palette _palette;

        private Colorer _colorer;

        [Inject]
        private void Construct(ItemTemplate itemTemplate, ItemButton buttonTemplate, Palette palette)
        {
            if (_itemTemplate == null)
                _itemTemplate = itemTemplate;

            if (_buttonTemplate == null)
                _buttonTemplate = buttonTemplate;

            if (_palette == null)
                _palette = palette;
        }

        private void Awake()
        {
            _colorer = new(_palette);
            Load();
        }

        private void Load()
        {
            foreach (var item in _items)
                SetButton(item);
        }

        private void SetButton(ItemData item)
        {
            var button = Instantiate(_buttonTemplate, transform);
            var spawner = new ItemSpawner(_itemTemplate, _clearButton.Container, _colorer);

            button.Initialize(item, spawner);
        }
    }
}