using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WKMR.System;
using YG;

namespace WKMR
{
    public class PopupSpawner : MonoBehaviour
    {
        private readonly float _delay = 10;

        [SerializeField] private Canvas _canvas;
        [SerializeField] private Toggle _switcher;
        [SerializeField] private List<Popup> _templates;
        [SerializeField] private List<Sprite> _sprites;

        private WaitForSeconds _wait;
        private PopupMaker _maker;

        private void Awake()
        {
            _wait = new(_delay);
            _maker = new(_templates, _sprites);
            _switcher.isOn = YandexGame.savesData.PopupsAvailable;
        }

        public void SwitchMode()
        {
            if (_switcher.isOn)
            {
                YandexGame.savesData.PopupsAvailable = true;
                YandexGame.SaveProgress();
                StartCoroutine(SpawnPopups());
            }
            else
            {
                YandexGame.savesData.PopupsAvailable = false;
                YandexGame.SaveProgress();
                StopSpawning();
            }
        }

        private IEnumerator SpawnPopups()
        {
            while (true)
            {
                yield return _wait;

                var spawned = Instantiate(_maker.GetPopup(), transform);
                spawned.Transform.anchoredPosition = PositionRandomiser.GetRandomPosition(_canvas);
            }
        }

        private void StopSpawning()
        {
            StopAllCoroutines();

            foreach (var popup in transform.GetComponentsInChildren<Popup>())
                popup?.Close();
        }
    }
}