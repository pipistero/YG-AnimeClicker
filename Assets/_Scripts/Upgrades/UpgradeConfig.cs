using System.Numerics;
using _Scripts._Enums.Upgrades;
using UnityEngine;

namespace _Scripts.Upgrades
{
    public abstract class UpgradeConfig : ScriptableObject
    {
        [Header("Icon")] 
        [SerializeField] private string _icon;

        [Header("Texts")] 
        [SerializeField] private string _name;
        [SerializeField] private string _description;

        [Header("Upgrade")] 
        [SerializeField] private long _value;

        [Header("Price")] 
        [SerializeField] private long _price;

        public abstract UpgradeType UpgradeType { get; }

        public string Icon => _icon;

        public string Name => _name;
        public string Description => _description;

        public long Value => _value;
        public long Price => _price;
    }
}