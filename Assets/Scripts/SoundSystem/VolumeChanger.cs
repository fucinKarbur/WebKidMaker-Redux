using System;
using UnityEngine;

namespace WKMR
{
    public class VolumeChanger
    {
        public void ChangeSFXVolume(float value)
        {
            foreach (var source in SourcePool.SFXSources)
                SwitchSource(source.Value, value);
        }

        public void ChangeMusicVolume(float value)
        {
            SwitchSource(SourcePool.MusicSource, value);
        }

        private void SwitchSource(AudioSource source, float value)
        {
            if (source != null)
                source.volume = value;
        }
    }
}