using UnityEngine;
using WKMR.Coloring;
using Zenject;

namespace WKMR
{
    public class PalettesInstaller : MonoInstaller
    {
        [SerializeField] private Palette _palette;

        public override void InstallBindings()
        {
            Container
            .Bind<Palette>()
            .FromInstance(_palette)
            .AsSingle()
            .NonLazy();
        }
    }
}
