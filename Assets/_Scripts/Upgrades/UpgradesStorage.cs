using System.Collections.Generic;
using System.Linq;
using _Scripts._Enums.Upgrades;

namespace _Scripts.Upgrades
{
    public class UpgradesStorage
    {
        private readonly Dictionary<PerSecondUpgradeType, PerSecondUpgradeConfig> _perSecondUpgradesMap;
        private readonly Dictionary<PerClickUpgradeType, PerClickUpgradeConfig> _perClickUpgradesMap;

        private readonly List<PerSecondUpgradeConfig> _perSecondUpgrades;
        private readonly List<PerClickUpgradeConfig> _perClickUpgrades;

        public UpgradesStorage(IEnumerable<PerSecondUpgradeConfig> perSecondUpgrades, IEnumerable<PerClickUpgradeConfig> perClickUpgrades)
        {
            _perSecondUpgrades = perSecondUpgrades.ToList();
            _perClickUpgrades = perClickUpgrades.ToList();
            
            _perSecondUpgradesMap = _perSecondUpgrades.ToDictionary(u => u.PerSecondUpgradeType);
            _perClickUpgradesMap = _perClickUpgrades.ToDictionary(u => u.PerClickUpgradeType);
        }

        public List<PerSecondUpgradeConfig> GetPerSecondUpgrades()
        {
            return _perSecondUpgrades;
        }

        public List<PerClickUpgradeConfig> GetPerClickUpgrades()
        {
            return _perClickUpgrades;
        }

        public PerSecondUpgradeConfig GetPerSecondUpgrade(PerSecondUpgradeType upgradeClass)
        {
            return _perSecondUpgradesMap[upgradeClass];
        }
        
        public PerClickUpgradeConfig GetPerClickUpgrade(PerClickUpgradeType upgradeClass)
        {
            return _perClickUpgradesMap[upgradeClass];
        }
    }
}