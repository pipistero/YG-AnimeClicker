using _Scripts._Enums.Upgrades;
using UnityEngine;

namespace _Scripts.Upgrades
{
    [CreateAssetMenu(menuName = "Upgrades/New per click upgrade", fileName = "New Upgrade Config")]
    public class PerClickUpgradeConfig : UpgradeConfig
    {
        public override UpgradeType UpgradeType => UpgradeType.PerClick;

        [Header("Type")] 
        [SerializeField] private PerClickUpgradeType _perClickUpgradeType;

        public PerClickUpgradeType PerClickUpgradeType => _perClickUpgradeType;
    }
}