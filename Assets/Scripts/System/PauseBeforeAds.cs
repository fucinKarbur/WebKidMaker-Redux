using UnityEngine;
using UnityEngine.EventSystems;
using YG;

namespace WKMR
{
    public class PauseBeforeAds : MonoBehaviour
    {
        [SerializeField] private EventSystem _system;

        private void Awake()
        {
            if (YandexGame.SDKEnabled == false)
                Destroy(gameObject);
        }

        public void OnTimerStart() => _system.enabled = false;

        public void OnAdStart()
        {
            AudioListener.pause = true;
            _system.enabled = false;
        }

        public void OnAdClose()
        {
            AudioListener.pause = false;
            _system.enabled = true;
        }
    }
}