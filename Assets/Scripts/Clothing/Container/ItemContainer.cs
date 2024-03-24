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

        public void Clear()
        {
            foreach (var item in GetComponentsInChildren<ItemTemplate>())
                Destroy(item.gameObject);

            StartCoroutine(OnCleared());
        }

        public void Clear(ItemData data)
        {
            var templates = GetComponentsInChildren<ItemTemplate>().Where(template => template.Item == data);

            foreach (var template in templates)
                Destroy(template.gameObject);

            StartCoroutine(OnCleared());
        }

        public virtual bool HasItem() => GetComponentsInChildren<ItemTemplate>().FirstOrDefault(template => template.Item.Type == _type) != null;

        private IEnumerator OnCleared()
        {
            yield return _wait;
            Cleared?.Invoke();
        }
    }
}