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

        public void OnTimerStart()
        {
            _system.enabled = false;
        }

        public void OnAdStart()
        {
            AudioListener.volume = 0;
            _system.enabled = false;
        }

        public void OnAdClose()
        {
            AudioListener.volume = 1;
            _system.enabled = true;
        }
    }
}