using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace WKMR
{
    public class ItemRespawner
    {
        private List<ItemContainer> _containers = new();
        private ItemTemplate _template;

        public ItemRespawner(ItemTemplate template, List<ItemContainer> containers)
        {
            _template = template;
            _containers = containers;
        }
    }
}