using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WKMR.System;

namespace WKMR
{
    [RequireComponent(typeof(Canvas))]
    public class SystemCanvas : MonoBehaviour
    {
        public static SystemCanvas Instance;

        [SerializeField] private LoadingScreen _loadingScreen;
        [SerializeField] private MusicWindow _musicWindow;
        [SerializeField] private MusicAssets _music;

        private Canvas _canvas;

        public MusicWindow MusicWindow => _musicWindow;
        public LoadingScreen LoadingScreen => _loadingScreen;
        public MusicAssets Music => _music;

        private void OnEnable()
        {
            SceneManager.sceneLoaded += GetCamera;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= GetCamera;
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);


            _canvas = GetComponent<Canvas>();
        }

        private void GetCamera(Scene arg0, LoadSceneMode arg1) => _canvas.worldCamera = Camera.main;
    }
}