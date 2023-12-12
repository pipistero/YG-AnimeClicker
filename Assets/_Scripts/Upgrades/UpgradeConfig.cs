using System;
using System.Numerics;
using _Scripts._Enums.Upgrades;
using _Scripts.Extensions;
using UnityEngine;

namespace _Scripts.Upgrades
{
    public abstract class UpgradeConfig : ScriptableObject
    {
        [Header("Basic")] 
        [SerializeField] private int _id;
        
        [Header("Icon")] 
        [SerializeField] private string _icon;

        [Header("Texts")] 
        [SerializeField] private string _name;

        [Header("Upgrade")] 
        [SerializeField] private long _value;

        [Header("Price")] 
        [SerializeField] private long _price;

        [Header("Open condition")] 
        [SerializeField] private int _level;

        private void OnValidate()
        {
            Value = new BigInteger(_value);
            Price = new BigInteger(_price);
        }

        public abstract UpgradeType UpgradeType { get; }

        public int Id => _id;
        
        public string Icon => _icon;

        public string Name => _name;

        public BigInteger Value { get; private set; }

        public BigInteger Price { get; private set; }

        public int Level => _level;
    }
}