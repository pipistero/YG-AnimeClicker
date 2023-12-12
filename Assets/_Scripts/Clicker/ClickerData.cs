using System;
using System.Collections.Generic;
using System.Numerics;
using _Scripts._Enums.Upgrades;
using _Scripts.Levels;
using _Scripts.Upgrades;
using UnityEngine.Assertions.Must;

namespace _Scripts.Clicker
{
    public class ClickerData
    {
        public event Action<BigInteger> PerSecondValueUpdated; 
        public event Action<BigInteger> PerClickValueUpdated;

        public event Action<int> LevelUpdated;

        private LevelConfig _levelConfig;
        
        private int _level;
        public int Level => _level;

        private Dictionary<PerSecondUpgradeType, int> _perSecondUpgradesMap;
        private Dictionary<PerClickUpgradeType, int> _perClickUpgradesMap;

        private readonly UpgradesStorage _upgradesStorage;
        private readonly LevelStorage _levelStorage;

        private BigInteger _perSecondValue;
        public BigInteger PerSecondValue => _perSecondValue;
        
        private BigInteger _perClickValue;
        public BigInteger PerClickValue => _perClickValue;
        
        public void SetLevel(int level)
        {
            _level = level;
            
            LevelUpdated?.Invoke(_level);
        }
        
        public ClickerData(UpgradesStorage upgradesStorage, LevelStorage levelStorage)
        {
            _upgradesStorage = upgradesStorage;
            _levelStorage = levelStorage;
        }

        public void LoadData(
            int level, 
            Dictionary<PerSecondUpgradeType, int> perSecondUpgrades, 
            Dictionary<PerClickUpgradeType, int> perClickUpgrades)
        {
            _level = level;
            //_levelConfig = _levelStorage.GetConfig(_level);
            
            _perSecondUpgradesMap = perSecondUpgrades;
            _perClickUpgradesMap = perClickUpgrades;
            
            CalculatePerSecondValue();
            CalculatePerClickValue();
        }

        public void AddPerSecondUpgrade(PerSecondUpgradeType type)
        {
            if (_perSecondUpgradesMap.ContainsKey(type))
                _perSecondUpgradesMap[type]++;
            else
                _perSecondUpgradesMap.Add(type, 1);

            var config = _upgradesStorage.GetPerSecondUpgrade(type);

            _perSecondValue += config.Value;
            
            PerSecondValueUpdated?.Invoke(_perSecondValue);
        }
        
        public void AddPerClickUpgrade(PerClickUpgradeType type)
        {
            if (_perClickUpgradesMap.ContainsKey(type))
                _perClickUpgradesMap[type]++;
            else
                _perClickUpgradesMap.Add(type, 1);
            
            var config = _upgradesStorage.GetPerClickUpgrade(type);

            _perClickValue += config.Value;
            
            PerClickValueUpdated?.Invoke(_perClickValue);
        }

        public int GetPerSecondUpgradeLevel(PerSecondUpgradeType type)
        {
            if (_perSecondUpgradesMap.ContainsKey(type))
                return _perSecondUpgradesMap[type];

            return 0;
        }

        public int GetPerClickUpgradeLevel(PerClickUpgradeType type)
        {
            if (_perClickUpgradesMap.ContainsKey(type))
                return _perClickUpgradesMap[type];

            return 0;
        }

        private void CalculatePerSecondValue()
        {
            _perSecondValue = new BigInteger(0);
            
            foreach (var upgrade in _perSecondUpgradesMap)
            {
                var upgradeConfig = _upgradesStorage.GetPerSecondUpgrade(upgrade.Key);

                _perSecondValue += upgradeConfig.Value * upgrade.Value;
            }
            
            PerSecondValueUpdated?.Invoke(_perSecondValue);
        }

        private void CalculatePerClickValue()
        {
            _perClickValue = new BigInteger(0);
            
            foreach (var upgrade in _perClickUpgradesMap)
            {
                var upgradeConfig = _upgradesStorage.GetPerClickUpgrade(upgrade.Key);

                _perClickValue += upgradeConfig.Value * upgrade.Value;
            }
            
            PerClickValueUpdated?.Invoke(_perClickValue);
        }
    }
}