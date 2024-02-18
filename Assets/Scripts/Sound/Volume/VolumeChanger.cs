using UnityEngine;
using UnityEngine.UI;

namespace WKMR
{
    public abstract class VolumeChanger : MonoBehaviour
    {
        [SerializeField] protected Slider Slider;
        [SerializeField] protected SoundAssets Assets;

        private void Start()
        {
            Slider.value = GetValue();
            ChangeVolume();
        }

        public virtual void ChangeVolume()
        {
            foreach (var source in Assets.Pool.Sources)
                source.volume = Slider.value;

            SaveVolume();
        }

        protected abstract float GetValue();

        protected abstract void SaveVolume();
    }
}