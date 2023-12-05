using System;
using _Scripts._Enums.Upgrades;

namespace _Scripts.Levels
{
    [Serializable]
    public class LevelCondition
    {
        public PerSecondUpgradeType UpgradeType;
        public int Value;
    }
}