using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using WKMR.System;
using YG;

namespace WKMR.System
{
    public class KidSaver : MonoBehaviour
    {
        [SerializeField] private proScreenShot _proScreenshot;
        [SerializeField] private Kid _kid;
        [SerializeField] private Transform _defaultParent;
        [SerializeField] private Transform _shotParent;
        [SerializeField] private FinishAnimation _finish;

        private Texture2D _lastScreenShot;

        public void TakeShot() => StartCoroutine(MakeScreenShot());

        private IEnumerator MakeScreenShot()
        {
            StartCoroutine(SetKidForShot(_shotParent));
            StartCoroutine(DoShot());
            yield return new WaitForEndOfFrame();
            StartCoroutine(SetKidForShot(_defaultParent));

            yield return null;
        }

        private IEnumerator SetKidForShot(Transform parent)
        {
            _kid.transform.SetParent(parent);
            _kid.SetDefault();
            yield return null;
        }

        private IEnumerator DoShot()
        {
            _proScreenshot.MakeScreenShot();
            yield return new WaitForSeconds(0.3f);

            _lastScreenShot = _proScreenshot.GetTextureFromPath(_proScreenshot.GetPathOfLastScreenShot());
            yield return 0;

            if (_lastScreenShot != null)
                TryToSave();
        }

        private void TryToSave()
        {
            var previousKids = YandexGame.savesData.KidInBytes.ToList();
            previousKids.Add(_lastScreenShot.EncodeToPNG());

            YandexGame.savesData.KidInBytes = new byte[previousKids.Count][];

            for (int i = 0; i < previousKids.Count; i++)
                YandexGame.savesData.KidInBytes[i] = previousKids[i];
            YandexGame.SaveProgress();
            _finish.gameObject.SetActive(true);
        }
    }
}