using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WKMR
{
    public class MessageManager : MonoBehaviour
    {
        public const string Error = "Error";
        public const string KidClosed = "KidClosed";

        public static MessageManager Instance;

        private readonly float _delay = 2;

        [SerializeField] private ErrorMessage _errorMessage;

        private WaitForSeconds _wait;
        private Vector3 _position;

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
            _errorMessage.gameObject.SetActive(false);
        }

        public void ShowMessage(string errorCode)
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
            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            return position;
        }
    }
}
