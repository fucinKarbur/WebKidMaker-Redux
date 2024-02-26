using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WKMR.System;

namespace WKMR
{
    public class SceneSwitcher : MonoBehaviour
    {
        private LoadingScreen _screen;

        private void Awake()
        {
            _screen = SystemCanvas.Instance.LoadingScreen;
        }

        public void Replay()
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex);
            SystemCanvas.Instance.Music?.ChangeMusic();
        }

        public void GoToStart()
        {
            LoadScene(0);
        }

        public void GoToDesktop()
        {
            LoadScene(1);
        }

        private void LoadScene(int index)
        {
            if (_screen != null)
                _screen.LoadScene(index);
            else
                SceneManager.LoadScene(index);
        }
    }
}
