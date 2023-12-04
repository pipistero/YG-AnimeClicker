using _Enums.Currencies;
using PS.ResourcesFeature.Controller;
using Zenject;

namespace _Installers
{
    public class ResourcesControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ResourcesController<CurrencyType>>()
                .FromInstance(new ResourcesController<CurrencyType>())
                .AsSingle()
                .NonLazy();
        }
    }
}