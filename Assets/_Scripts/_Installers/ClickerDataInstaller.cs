using _Scripts.Clicker;
using Zenject;

namespace _Installers
{
    public class ClickerDataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ClickerData>()
                .AsSingle()
                .NonLazy();
        }
    }
}