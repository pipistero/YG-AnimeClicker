using System.Collections.Generic;
using _Scripts._Enums.Upgrades;
using _Scripts.Clicker;
using UnityEngine;
using Zenject;

namespace _Scripts._Bootstrap
{
    public class ClickerDataBootstrap : MonoBehaviour
    {
        [Inject]
        private void Construct(ClickerData clickerData)
        {
            var perSecondUpgrades = new Dictionary<PerSecondUpgradeType, int>()
            {
                [PerSecondUpgradeType.FlowersGarden] = 2
            };
            
            var perClickUpgrades = new Dictionary<PerClickUpgradeType, int>()
            {
                [PerClickUpgradeType.Flowers] = 1,
            };
            
            clickerData.LoadData(1, perSecondUpgrades, perClickUpgrades);
        }
    }
}