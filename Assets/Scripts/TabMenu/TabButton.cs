using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WKMR
{
    [RequireComponent(typeof(Image))]
    public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        [SerializeField] private PageGroup _pageGroup;

        private TabGroup _group;

        public Image Background { get; private set; }
        public PageGroup PageGroup => _pageGroup;

        private void Awake()
        {
            Background = GetComponent<Image>();
            _group = GetComponentInParent<TabGroup>();
        }

        public void OnPointerClick(PointerEventData eventData) => _group.OnSelected(this);

        public void OnPointerEnter(PointerEventData eventData) => _group.OnEnter(this);

        public void OnPointerExit(PointerEventData eventData) => _group.OnExit();
    }
}