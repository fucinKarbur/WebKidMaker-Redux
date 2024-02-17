using UnityEngine;

namespace WKMR
{
    public class ScaleButton : MonoBehaviour
    {
        [SerializeField] private RectTransform _kid;
        [SerializeField] private RectTransform _content;

        private readonly Vector3 _maxScale = new(3, 3, 0);
        private readonly Vector3 _minScale = new(.6f, .6f, 0);
        private readonly Vector3 _defaultScale = new(1, 1, 0);
        private readonly Vector3 _step = new(.2f, .2f, 0);
        private Vector3 _defaultPosition = new(0, 0, 0);

        private void Awake() => Reset();

        public void IncreaseScale()
        {
            if (CanIncrease())
                _kid.localScale += _step;
            else
                DecreaseScale();
        }
        
        public void ChangeScale(Vector3 value)
        {
            _kid.localScale = value;
        }

        public void DecreaseScale()
        {
            if (CanDecrease())
                _kid.localScale -= _step;
            else
                IncreaseScale();
        }

        public void Reset()
        {
            _kid.localScale = _defaultScale;
            _kid.anchoredPosition = _defaultPosition;
            _content.anchoredPosition = _defaultPosition;
        }

        private bool CanIncrease()
        {
            var newScale = _kid.localScale + _step;
            return newScale.x <= _maxScale.x && newScale.y <= _maxScale.y;
        }

        private bool CanDecrease()
        {
            var newScale = _kid.localScale - _step;
            return newScale.x >= _minScale.x && newScale.y >= _minScale.y;
        }
    }
}