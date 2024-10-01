using UnityEngine;
using UnityEngine.UI;

namespace WKMR.System
{
    public class MusicWindow : Window
    {
        [field: SerializeField] public Slider MusicSlider { get; private set; }
        [field: SerializeField] public Slider SfxSlider { get; private set; }
    }
}
