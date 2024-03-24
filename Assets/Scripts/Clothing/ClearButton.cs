using System.Collections.Generic;
using UnityEngine;

namespace WKMR
{
    public class ClearButton : MonoBehaviour
    {
        [SerializeField] private List<ItemContainer> _containers;

        public void Clear()
        {
            foreach (var container in _containers)
                if (container.gameObject.activeInHierarchy)
                    container.Clear();
        }
    }
}