using _Scripts._Enums.Upgrades;
using _Scripts.Upgrades;
using UnityEngine;
using Zenject;

namespace _Installers
{
    public class UpgradesStorageInstaller : MonoInstaller
    {
        [SerializeField] private PerSecondUpgradeConfig[] _perSecondUpgrades;
        [SerializeField] private PerClickUpgradeConfig[] _perClickUpgrades;
        
        public override void InstallBindings()
        {
            Container
                .BindInstance(new UpgradesStorage(_perSecondUpgrades, _perClickUpgrades))
                .AsSingle()
                .NonLazy();
        }
    }
}