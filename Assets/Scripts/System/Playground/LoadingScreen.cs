using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

namespace WKMR.System
{

    /// <summary>
    /// вынести визуал в отдельный класс, который будет содержать в себе и
    /// рандомный фон\слайдер и изменение лого в зависимости от языка(опред при первом запуске)
    /// </summary>
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private BackgroundChanger[] _bgChangers;

        private void Awake() => gameObject.SetActive(false);

        private void OnEnable()
        {
            foreach (var changer in _bgChangers)
                changer.ChangeBackground();
        }

        public async void LoadScene(int sceneId)
        {
            gameObject.SetActive(true);
            await LoadAsync(sceneId);
        }

        private async Task LoadAsync(int sceneId)
        {
            var async = SceneManager.LoadSceneAsync(sceneId);

            while (!async.isDone)
            {
                Debug.Log(async.progress);
                _slider.value = async.progress*100;
                await Task.Yield(); // This effectively replaces yield return null;
            }

            gameObject.SetActive(false);
            YandexGame.FullscreenShow();
        }
    }
}
