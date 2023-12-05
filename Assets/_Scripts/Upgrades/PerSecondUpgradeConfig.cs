using _Scripts._Enums.Upgrades;
using UnityEngine;

namespace _Scripts.Upgrades
{
    [CreateAssetMenu(menuName = "Upgrades/New per second upgrade", fileName = "New Upgrade Config")]
    public class PerSecondUpgradeConfig : UpgradeConfig
    {
        public override UpgradeType UpgradeType => UpgradeType.PerSecond;

        [Header("Type")] 
        [SerializeField] private PerSecondUpgradeType _perSecondUpgradeType;

        public PerSecondUpgradeType PerSecondUpgradeType => _perSecondUpgradeType;
    }
}