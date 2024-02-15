using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WKMR
{
    [RequireComponent(typeof(ItemButton))]
    public class ButtonStatus : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        [SerializeField] private Material _entered;
        [SerializeField] private Material _selected;

        private ItemButton _button;
        private ClothContainer _container;
        private ItemData _item;
        private Image _image;
        private Material _default;
        private bool _clicked = false;

        private void Start()
        {
            _button = GetComponent<ItemButton>();
            _container = _button.ClothContainer;
            _item = _button.ItemData;
            _image = _button.Image;
            _default = _image.material;

            _container.Cleared += OnCleared;
        }

        private void OnDestroy()
        {
            if (_container != null)
                _container.Cleared -= OnCleared;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ChangeMaterial(_selected);
            _clicked = true;

            if (_button.TryGetComponent(out EarrigsButton _))
                OnCleared();
        }

        public void OnPointerEnter(PointerEventData eventData) => ChangeMaterial(_entered);

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_clicked)
                ChangeMaterial(_selected);
            else
                ChangeMaterial(_default);
        }

        private void OnCleared()
        {
            if (HasSpawned(out ItemTemplate spawned))
            {
                ChangeMaterial(_selected);
                _clicked = true;
                return;
            }

            ChangeMaterial(_default);
            _clicked = false;
        }

        private bool HasSpawned(out ItemTemplate template)
        {
            if (_container.transform.childCount != 0)
            {
                template = _container.GetComponentsInChildren<ItemTemplate>().FirstOrDefault(template => template.Item == _item);
                return template != null;
            }
            else
            {
                template = null;
                return false;
            }
        }

        private void ChangeMaterial(Material material)
        {
            _image.material = material;
        }
    }
}