using System.Collections.Generic;
using System.Linq;
using _Scripts._Enums.Upgrades;

namespace _Scripts.Upgrades
{
    public class UpgradesStorage
    {
        private readonly Dictionary<UpgradeClass, UpgradeConfig> _perSecondUpgradesMap;
        private readonly Dictionary<UpgradeClass, UpgradeConfig> _perClickUpgradesMap;

        private readonly List<UpgradeConfig> _perSecondUpgrades;
        private readonly List<UpgradeConfig> _perClickUpgrades;

        public UpgradesStorage(IEnumerable<UpgradeConfig> perSecondUpgrades, IEnumerable<UpgradeConfig> perClickUpgrades)
        {
            _perSecondUpgrades = perSecondUpgrades.ToList();
            _perClickUpgrades = perClickUpgrades.ToList();
            
            _perSecondUpgradesMap = _perSecondUpgrades.ToDictionary(u => u.UpgradeClass);
            _perClickUpgradesMap = _perClickUpgrades.ToDictionary(u => u.UpgradeClass);
        }

        public List<UpgradeConfig> GetPerSecondUpgrades()
        {
            return _perSecondUpgrades;
        }

        public List<UpgradeConfig> GetPerClickUpgrades()
        {
            return _perClickUpgrades;
        }

        public UpgradeConfig GetPerSecondUpgrade(UpgradeClass upgradeClass)
        {
            return _perSecondUpgradesMap[upgradeClass];
        }
        
        public UpgradeConfig GetPerClickUpgrade(UpgradeClass upgradeClass)
        {
            return _perClickUpgradesMap[upgradeClass];
        }
    }
}