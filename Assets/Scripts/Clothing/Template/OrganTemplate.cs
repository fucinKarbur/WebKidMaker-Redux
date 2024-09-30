using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YG;

namespace WKMR.Clothing
{
    public class OrganTemplate : ItemTemplate, IPointerClickHandler
    {
        [SerializeField] private Material _default;
        [SerializeField] private Material _lite;

        private BloodClick _bloodClick;

        public OrganData Organ { get; private set; }

        public void GetOrgan(OrganData data) => Organ = data;

        private void Start()
        {
            _bloodClick = GetComponentInParent<OrganContainer>().BloodClick;
            SetMaterialByMode();
        }

        private void OnEnable() => ModeManager.Instance.ModeChanged += SetMaterialByMode;

        private void OnDisable() => ModeManager.Instance.ModeChanged -= SetMaterialByMode;

        private void SetMaterialByMode()
        {
            if (YandexGame.savesData.LiteMode)
                Image.material = _lite;
            else
                Image.material = _default;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPosition);
            _bloodClick?.DoSplash(rectTransform.TransformPoint(localPosition));
            Debug.Log("click");
        }
    }
}