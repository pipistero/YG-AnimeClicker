using _Scripts.Levels;
using UnityEngine;
using Zenject;

namespace _Installers
{
    public class LevelStorageInstaller : MonoInstaller
    {
        [SerializeField] private LevelConfig[] _levelConfigs;
        
        public override void InstallBindings()
        {
            Container
                .BindInstance(new LevelStorage(_levelConfigs))
                .AsSingle()
                .NonLazy();
        }
    }
}