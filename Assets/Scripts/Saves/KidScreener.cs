using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WKMR.System;

namespace WKMR
{
    public class KidScreener : MonoBehaviour
    {
        [SerializeField] private proScreenShot _proScreenshot;
        [SerializeField] private Kid _kid;
        [SerializeField] private ModeSwitcher _switcher;
        [SerializeField] private Transform _defaultParent;
        [SerializeField] private Transform _shotParent;
        [SerializeField] private FinishAnimation _finish;

        public Texture2D LastScreenShot { get; private set; }

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
            _switcher.SetDefaultMode();
            _kid.transform.SetParent(parent);
            _kid.SetDefault();
            yield return new WaitForEndOfFrame();
            _proScreenshot.shotResolution = _kid.transform.lossyScale;
            _proScreenshot.screenOffset = _kid.transform.localPosition;
            yield return null;
        }

        private IEnumerator DoShot()
        {
            _proScreenshot.MakeScreenShot();
            yield return new WaitForSeconds(0.3f);

            LastScreenShot = _proScreenshot.GetTextureFromPath(_proScreenshot.GetPathOfLastScreenShot());
            yield return 0;

            _finish.gameObject.SetActive(true);
        }
    }
}
