using UnityEngine;
using UnityEngine.UI;

namespace WKMR
{
    public class VolumeChanger : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private SoundAssets _assets;

        private void Awake()
        {
            ChangeVolume();
        }

        public void ChangeVolume()
        {
            foreach (var source in _assets.Pool.Sources)
                source.volume = _slider.value;
        }
    }
}