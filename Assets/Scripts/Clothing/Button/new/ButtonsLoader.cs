using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WKMR.Coloring;
using WKMR.System.TabMenu;
using Zenject;

namespace WKMR.Clothing
{
    public class ButtonsLoader : MonoBehaviour
    {
        [SerializeField] private ItemData[] _items;
        [SerializeField] private ClearButton _clearButton;
        [SerializeField] private ItemTemplate _itemTemplate;
        [SerializeField] private ItemButton _buttonTemplate;

        private Colorer _colorer;

        [Inject]
        private void Construct(ItemTemplate itemTemplate, ItemButton buttonTemplate)
        {
            if (_itemTemplate == null)
                _itemTemplate = itemTemplate;

            if (_buttonTemplate == null)
                _buttonTemplate = buttonTemplate;
        }

        private void Awake()
        {
            var palette = GetComponentInParent<PageGroup>().Palette;
            _colorer = new(palette);

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
            button.Initialize(item, _colorer, _itemTemplate, _clearButton.Container);
        }
    }
}