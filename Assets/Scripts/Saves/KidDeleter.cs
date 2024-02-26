using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using YG;

namespace WKMR
{
    public class KidDeleter : MonoBehaviour
    {
        [SerializeField] private GameObject _applyWindow;
        [SerializeField] private GameObject _succsessMessage;

        private float _delay = 1;
        private WaitForSeconds _wait;

        public event Action KidDeleted;

        private void Awake() => _wait = new(_delay);

        private void OnEnable()
        {
            _applyWindow.SetActive(false);
            _succsessMessage.SetActive(false);
        }

        public void Delete(KidData kid)
        {
            var kids = YandexGame.savesData.Kids.ToList();
            var names = YandexGame.savesData.Names.ToList();
            var healthes = YandexGame.savesData.Healthes.ToList();

            kids.RemoveAt(kid.Index);
            names.RemoveAt(kid.Index);
            healthes.RemoveAt(kid.Index);

            YandexGame.savesData.Kids = kids.ToArray();
            YandexGame.savesData.Names = names.ToArray();
            YandexGame.savesData.Healthes = healthes.ToArray();

            YandexGame.SaveProgress();
            _succsessMessage.SetActive(true);
            StartCoroutine(OnDeleted());
        }

        private IEnumerator OnDeleted()
        {
            yield return _wait;
            KidDeleted?.Invoke();
        }
    }
}