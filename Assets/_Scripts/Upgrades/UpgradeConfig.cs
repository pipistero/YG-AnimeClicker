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
        [SerializeField] private UpgradeClass _upgradeClass;

        [Header("Icon")] 
        [SerializeField] private Sprite _icon;

        [Header("Texts")] 
        [SerializeField] private string _name;
        [SerializeField] private string _description;

        [Header("Upgrade")] 
        [SerializeField] private long _value;

        [Header("Price")] 
        [SerializeField] private long _price;

        public UpgradeType UpgradeType => _upgradeType;
        public UpgradeClass UpgradeClass => _upgradeClass;

        public Sprite Icon => _icon;

        public string Name => _name;
        public string Description => _description;

        public long Value => _value;
        public long Price => _price;
    }
}