using System;
using System.Collections;
using UnityEngine;

namespace WKMR
{
    public class ClothContainer : MonoBehaviour
    {
        private readonly WaitForEndOfFrame _wait = new();

        public event Action Cleared;

        public void Reset()
        {
            foreach (var item in GetComponentsInChildren<ItemTemplate>())
                Destroy(item.gameObject);

            StartCoroutine(OnReseted());
        }

        private IEnumerator OnReseted()
        {
            yield return _wait;
            Cleared?.Invoke();
        }
    }
}