using System;
using WKMR.Coloring;
using WKMR.System;

namespace WKMR.Clothing
{
    public class ItemSpawner
    {
        private readonly ItemTemplate _template;
        private readonly ItemContainer _container;
        private readonly Colorer _colorer;

        private ItemTemplate _item;

        public ItemSpawner(ItemTemplate template, ItemContainer container, Colorer colorer)
        {
            _template = template;
            _container = container;
            _colorer = colorer;
        }

        public void Spawn(ItemData data)
        {
            if (AbleToSpawn())
            {
                if (_container.HasItem(data, out _item) == false)
                {
                    _container.Clear();
                    _item = UnityEngine.Object.Instantiate(_template, _container.transform);
                    _item.Initialize(data);
                }

                _colorer.Colorize(_item);
            }
        }

        public bool AbleToSpawn()
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
