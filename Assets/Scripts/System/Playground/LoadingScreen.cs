using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

namespace WKMR.System
{
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

        public void LoadScene(int sceneId)
        {
            gameObject.SetActive(true);
            StartCoroutine(LoadAsync(sceneId));
        }

        private IEnumerator LoadAsync(int sceneId)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(sceneId);

            while (async.isDone == false)
            {
                _slider.value = async.progress;

                yield return null;
            }

            gameObject.SetActive(false);
            ShowAddBetweenScenes();
            StopAllCoroutines();
        }

        private void ShowAddBetweenScenes() => YandexGame.FullscreenShow();
    }
}
