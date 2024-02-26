using UnityEngine;
using UnityEngine.UI;

namespace WKMR.System
{
    public class MusicWindow : Window
    {
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _sfxSlider;

        public Slider MusicSlider => _musicSlider;
        public Slider SFXSlider => _sfxSlider;
    }
}
