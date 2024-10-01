using System;
using System.Linq;
using UnityEngine;
using WKMR.System;

namespace WKMR.Clothing
{
    public class ItemSpawner
    {
        private readonly ItemTemplate _template;
        private readonly ItemContainer _container;

        public ItemSpawner(ItemTemplate template, ItemContainer container)
        {
            _template = template;
            _container = container;
        }

        public ItemTemplate Spawn(ItemData data)
        {
            if (_container == null)
                throw new NullReferenceException("container is null");

            if (TryToSpawn())
                if (_container.HasItem(data, out ItemTemplate template))
                {
                    return template;
                }
                else
                {
                    var item = UnityEngine.Object.Instantiate(_template, _container.transform);
                    item.Initialize(data);

                    return item;
                }
            else
                return null;
        }

        public bool TryToSpawn()
        {
            if (_container.gameObject.activeInHierarchy == false)
            {
                if (ModeManager.Instance.IsSurgery)
                    MessageManager.Instance.ShowMessage(ErrorType.IsSurgery);
                else
                    MessageManager.Instance.ShowMessage(ErrorType.KidClosed);

                return false;
            }

            return true;
        }
    }
}
