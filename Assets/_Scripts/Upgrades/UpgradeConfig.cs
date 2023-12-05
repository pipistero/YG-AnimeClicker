using System.Numerics;
using _Scripts._Enums.Upgrades;
using UnityEngine;

namespace _Scripts.Upgrades
{
    [CreateAssetMenu(menuName = "Upgrades/New upgrade", fileName = "New Upgrade Config")]
    public class UpgradeConfig : ScriptableObject
    {
        [Header("Type")] 
        [SerializeField] private UpgradeType _upgradeType;
        [SerializeField] private PerSecondUpgradeType _perSecondUpgradeType;
        [SerializeField] private PerClickUpgradeType _perClickUpgradeType;

        [Header("Icon")] 
        [SerializeField] private string _icon;

        [Header("Texts")] 
        [SerializeField] private string _name;
        [SerializeField] private string _description;

        [Header("Upgrade")] 
        [SerializeField] private long _value;

        [Header("Price")] 
        [SerializeField] private long _price;

        public UpgradeType UpgradeType => _upgradeType;
        public PerSecondUpgradeType PerSecondUpgradeType => _perSecondUpgradeType;
        public PerClickUpgradeType PerClickUpgradeType => _perClickUpgradeType;

        public string Icon => _icon;

        public string Name => _name;
        public string Description => _description;

        public long Value => _value;
        public long Price => _price;
    }
}