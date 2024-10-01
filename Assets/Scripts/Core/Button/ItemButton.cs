using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using WKMR.Coloring;

namespace WKMR.Clothing
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Button))]
    public class ItemButton : MonoBehaviour
    {
        private ItemData _data;
        private ItemContainer _container;
        private Image _image;
        private Button _button;

        private Colorer _colorer;
        private ItemSpawner _spawner;

        private ItemTemplate _item;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _button = GetComponent<Button>();
            
            _button.onClick.AddListener(Spawn);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(Spawn);
        }

        public void Initialize(ItemData data, Colorer colorer, ItemTemplate template, ItemContainer container)
        {
            _data = data;
            _colorer = colorer;
            _container = container;
            _spawner = new(template, container);
            SetImage();
        }

        private void SetImage()
        {
            _image.sprite = _data.Icon;
            _image.SetNativeSize();
        }

        private void Spawn()
        {
            if (_container.HasItem(_data, out _item))
                Colorize();
            else
            {
                if (_container.HasItem())
                    _container.Clear();

                _item = _spawner.Spawn(_data);
                Colorize();
            }
        }

        private void Colorize()
        {
            if (_item.Item.Colorable)
                _colorer?.Colorize(_item);
        }
    }
}