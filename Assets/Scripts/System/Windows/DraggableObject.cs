using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;

namespace WKMR.System
{
    [RequireComponent(typeof(RectTransform))]
    public class DraggableObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private GameObject _parent;
        [SerializeField] private Material _material;
        [SerializeField] private Image _image;

        private RectTransform _transform;

        public SortingGroup Group { get; private set; }

        private void Awake()
        {
            _transform = _parent == null ?
               GetComponent<RectTransform>() :
               _parent.GetComponent<RectTransform>();

            if(_canvas == null)
                _canvas = GetComponentInParent<Canvas>();

            SetGroup();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            SetOrder();
            SetMaterial(_material);
        }

        public void OnDrag(PointerEventData eventData) => _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;

        public void OnEndDrag(PointerEventData eventData) => SetMaterial();

        private void SetGroup()
        {
            if (_transform.GetComponent<SortingGroup>() == null)
                _transform.gameObject.AddComponent<SortingGroup>();

            Group = _transform.GetComponent<SortingGroup>();
            Group.sortingLayerName = _transform.TryGetComponent(out Shortcut _) ?
             "exe" : "window";
        }

        private void SetOrder()
        {
            List<DraggableObject> others = FindObjectsOfType<DraggableObject>().
                    Where(other => other.Group.sortingLayerName == Group.sortingLayerName).ToList();

            int highestSiblingIndex = 20;

            foreach (var draggable in others)
            {
                int siblingIndex = draggable.transform.GetSiblingIndex();

                if (siblingIndex < highestSiblingIndex)
                    highestSiblingIndex = siblingIndex;
            }

            _transform.SetSiblingIndex(highestSiblingIndex - 1);
        }

        private void SetMaterial(Material material = null)
        {
            if (_image != null)
                _image.material = material;
        }
    }
}