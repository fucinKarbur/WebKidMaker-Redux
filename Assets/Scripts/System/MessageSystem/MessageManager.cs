using System.Collections;
using UnityEngine;

namespace WKMR
{
    public class MessageManager : MonoBehaviour
    {
        public static MessageManager Instance;

        private readonly float _delay = 2;

        [SerializeField] private ErrorMessage _errorMessage;

        private WaitForSeconds _wait;
        private Camera _camera;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _wait = new(_delay);
            _camera = Camera.main;
            _errorMessage.gameObject.SetActive(false);
        }

        public void ShowMessage(ErrorType errorCode)
        {
            _errorMessage.transform.position = GetPosition();
            _errorMessage.gameObject.SetActive(true);

            _errorMessage.Show(errorCode);
            StartCoroutine(HideMessageAfterDelay());
        }

        private IEnumerator HideMessageAfterDelay()
        {
            yield return _wait;
            _errorMessage.gameObject.SetActive(false);
        }

        private Vector3 GetPosition()
        {
            var position = _camera.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            return position;
        }
    }
}
