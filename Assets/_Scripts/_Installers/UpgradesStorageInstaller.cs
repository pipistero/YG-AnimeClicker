using _Scripts.Upgrades;
using UnityEngine;
using Zenject;

namespace _Installers
{
    public class UpgradesStorageInstaller : MonoInstaller
    {
        [SerializeField] private UpgradeConfig[] _perSecondUpgrades;
        [SerializeField] private UpgradeConfig[] _perClickUpgrades;
        
        public override void InstallBindings()
        {
            Container
                .BindInstance(new UpgradesStorage(_perSecondUpgrades, _perClickUpgrades))
                .AsSingle()
                .NonLazy();
        }
    }
}