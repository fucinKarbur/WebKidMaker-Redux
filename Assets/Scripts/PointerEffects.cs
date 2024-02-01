using UnityEngine;
using UnityEngine.EventSystems;

namespace WKMR
{
    public class PointerEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler
    {
        [SerializeField] private bool _changeSize = false;

        private Vector3 _defaultSize;
        private Vector3 _increaseSize = new(.1f, .1f);

        private void Awake()
        {
            _defaultSize = transform.localScale;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
#if UNITY_STANDALONE || UNITY_EDITOR
            IncreaseSize();
#endif
        }

        public void OnPointerExit(PointerEventData eventData)
        {
#if UNITY_STANDALONE || UNITY_EDITOR
            SetDefaultSize();
#endif
        }

        public void OnPointerClick(PointerEventData eventData)
        {
#if UNITY_STANDALONE == false || UNITY_EDITOR == false
            IncreaseSize();
#endif
        }

        public void OnPointerUp(PointerEventData eventData)
        {
#if UNITY_STANDALONE == false || UNITY_EDITOR == false
            SetDefaultSize();
#endif
        }

        private void IncreaseSize()
        {
            if (_changeSize)
                transform.localScale += _increaseSize;
        }

        private void SetDefaultSize()
        {
            if (_changeSize)
                transform.localScale = _defaultSize;
        }
    }
}