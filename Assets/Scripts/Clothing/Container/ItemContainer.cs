using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace WKMR
{
    public class ItemContainer : MonoBehaviour
    {
        private readonly WaitForEndOfFrame _wait = new();

        [SerializeField] private ItemType _type;

        public event Action Cleared;

        public ItemType Type => _type;

        public void Reset()
        {
            foreach (var item in GetComponentsInChildren<ItemTemplate>())
                Destroy(item.gameObject);

            StartCoroutine(OnReseted());
        }

        public void Reset(ItemData data)
        {
            var templates = GetComponentsInChildren<ItemTemplate>().Where(template => template.Item == data);

            foreach (var template in templates)
                Destroy(template.gameObject);

            StartCoroutine(OnReseted());
        }

        private IEnumerator OnReseted()
        {
            yield return _wait;
            Cleared?.Invoke();
        }
    }
}