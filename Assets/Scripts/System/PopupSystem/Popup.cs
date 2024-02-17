using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WKMR
{
    [RequireComponent(typeof(RectTransform))]
    public class Popup : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _lable;

        private readonly float _lifetime = 20;

        private WaitForSeconds _delay;
        private RectTransform _transform;

        public Image Image => _image;
        public TMP_Text Text => _lable;
        public RectTransform Transform => _transform;

        private void Awake()
        {
            _delay = new(_lifetime);
            _transform = GetComponent<RectTransform>();

            StartCoroutine(DieAfterDelay());
        }

        public void Close() => Destroy(gameObject);

        private IEnumerator DieAfterDelay()
        {
            yield return _delay;
            Close();
        }
    }
}