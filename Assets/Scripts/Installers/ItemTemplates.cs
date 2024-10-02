using UnityEngine;
using Zenject;

namespace WKMR.Clothing
{
    public class ItemTemplates : MonoInstaller
    {
        [SerializeField] private ItemButton _itemButton;
        [SerializeField] private ItemTemplate _itemTemplate;

        public override void InstallBindings()
        {
            Container.Bind<ItemButton>().FromInstance(_itemButton);
            Container.Bind<ItemTemplate>().FromInstance(_itemTemplate);
        }
    }
}