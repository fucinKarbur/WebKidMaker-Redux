using UnityEngine;
using UnityEngine.UI;
using WKMR.System;

namespace WKMR
{
    public abstract class VolumeChanger : MonoBehaviour
    {
        [SerializeField] protected MusicWindow MusicWindow;
        [SerializeField] protected SoundAssets Assets;
        
        protected Slider Slider;

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