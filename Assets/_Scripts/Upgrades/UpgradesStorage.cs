using System.Collections.Generic;
using System.Linq;
using _Scripts._Enums.Upgrades;

namespace _Scripts.Upgrades
{
    public class UpgradesStorage
    {
        private readonly Dictionary<PerSecondUpgradeType, UpgradeConfig> _perSecondUpgradesMap;
        private readonly Dictionary<PerClickUpgradeType, UpgradeConfig> _perClickUpgradesMap;

        private readonly List<UpgradeConfig> _perSecondUpgrades;
        private readonly List<UpgradeConfig> _perClickUpgrades;

        public UpgradesStorage(IEnumerable<UpgradeConfig> perSecondUpgrades, IEnumerable<UpgradeConfig> perClickUpgrades)
        {
            _perSecondUpgrades = perSecondUpgrades.ToList();
            _perClickUpgrades = perClickUpgrades.ToList();
            
            _perSecondUpgradesMap = _perSecondUpgrades.ToDictionary(u => u.PerSecondUpgradeType);
            _perClickUpgradesMap = _perClickUpgrades.ToDictionary(u => u.PerClickUpgradeType);
        }

        public List<UpgradeConfig> GetPerSecondUpgrades()
        {
            return _perSecondUpgrades;
        }

        public List<UpgradeConfig> GetPerClickUpgrades()
        {
            return _perClickUpgrades;
        }

        public UpgradeConfig GetPerSecondUpgrade(PerSecondUpgradeType upgradeClass)
        {
            return _perSecondUpgradesMap[upgradeClass];
        }
        
        public UpgradeConfig GetPerClickUpgrade(PerClickUpgradeType upgradeClass)
        {
            return _perClickUpgradesMap[upgradeClass];
        }
    }
}