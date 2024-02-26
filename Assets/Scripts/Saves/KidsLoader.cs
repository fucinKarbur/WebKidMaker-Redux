using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace WKMR
{
    public class KidsLoader : MonoBehaviour
    {
        [SerializeField] private KidData _template;
        [SerializeField] private GameObject _noKidsMessage;
        [SerializeField] private Transform _container;

        private KidData[] _kids;

        private void OnEnable() => LoadKids();

        private void OnDestroy() => ResetKidsList();

        private void LoadKids()
        {
            _kids = new KidData[YandexGame.savesData.Kids.Length];

            if (TryToLoad())
            {
                for (int i = 0; i < _kids.Length; i++)
                {
                    var kid = Instantiate(_template, _container);
                    kid.SetData(YandexGame.savesData.Kids[i], YandexGame.savesData.Names[i], YandexGame.savesData.Healthes[i], i);
                    kid.Deleter.KidDeleted += UpdateKidsList;

                    _kids[i] = kid;
                }
            }
        }

        private void ResetKidsList()
        {
            foreach (var kid in _kids)
            {
                Destroy(kid.gameObject);
                kid.Deleter.KidDeleted -= UpdateKidsList;
            }

            _kids = null;
        }

        private void UpdateKidsList()
        {
            ResetKidsList();
            LoadKids();
        }

        private bool TryToLoad()
        {
            if (_kids == null || _kids.Length == 0)
            {
                _noKidsMessage.SetActive(true);
                return false;
            }
            else
            {
                _noKidsMessage.SetActive(false);
                return true;
            }
        }
    }
}