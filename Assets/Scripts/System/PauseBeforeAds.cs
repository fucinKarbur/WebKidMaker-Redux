using UnityEngine;
using UnityEngine.EventSystems;

namespace WKMR
{
    public class PauseBeforeAds : MonoBehaviour
    {
        [SerializeField] private SoundAssets[] _assets;
        [SerializeField] private EventSystem _eventSystem;

        public void OnTimerStart()
        {
            _eventSystem.enabled = false;
        }

        public void OnAdStart()
        {
            MuteSources();
            _eventSystem.enabled = false;
        }

        public void OnAdClose()
        {
            MuteSources(false);
            _eventSystem.enabled = true;
        }

        private void MuteSources(bool enable = true)
        {
            foreach (var asset in _assets)
            {
                foreach (var source in asset.Pool.Sources)
                    source.mute = enable;
            }
        }
    }
}