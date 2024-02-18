using YG;

namespace WKMR
{
    public class MusicVolume : VolumeChanger
    {
        protected override float GetValue() => YandexGame.savesData.MusicVolume;

        protected override void SaveVolume()
        {
            YandexGame.savesData.MusicVolume = Slider.value;
            YandexGame.SaveProgress();
        }
    }
}