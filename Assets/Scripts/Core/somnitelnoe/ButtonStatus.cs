using UnityEngine;

namespace WKMR
{
    //[RequireComponent(typeof(ItemButton))]
    public class ButtonStatus : MonoBehaviour/* , IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler */
    {
        /* [SerializeField] private Material _entered;
        [SerializeField] private Material _selected;

        private ItemButton _button;
        private ItemContainer _container;
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
            _default = _image.material ? _image.material : default;

            _container.Cleared += OnCleared;
        }

        private void OnDestroy()
        {
            if (_container != null)
                _container.Cleared -= OnCleared;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_button.TryToSpawn())
            {
                ChangeMaterial(_selected);
                _clicked = true;
            }

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

        public void OnCleared(ItemData data)
        {
            if (HasSpawned(data))
            {
                ChangeMaterial(_selected);
                _clicked = true;
                return;
            }

            ChangeMaterial(_default);
            _clicked = false;
        }

        public bool HasSpawned(ItemData data)
        {
            ItemTemplate template = null;

            if (HasSpawned())
                template = _container.GetComponentsInChildren<ItemTemplate>().FirstOrDefault(template => template.Item == data);

            return template != null;
        }

        private void OnCleared()
        {
            if (HasSpawned())
            {
                ChangeMaterial(_selected);
                _clicked = true;
                return;
            }

            ChangeMaterial(_default);
            _clicked = false;
        }

        private bool HasSpawned()
        {
            ItemTemplate template = null;

            if (_container.gameObject.activeInHierarchy == false)
                return false;

            if (_container.transform.childCount != 0)
                template = _container.GetComponentsInChildren<ItemTemplate>().FirstOrDefault(template => template.Item == _item);

            return template != null;
        }

        private void ChangeMaterial(Material material)
        {
            _image.material = material;
        } */
    }
}