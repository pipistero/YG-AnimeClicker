using System.Collections.Generic;
using System.Linq;

namespace _Scripts.Levels
{
    public class LevelStorage
    {
        private readonly Dictionary<int, LevelConfig> _levelConfigs;

        public LevelStorage(IEnumerable<LevelConfig> configs)
        {
            _levelConfigs = configs.ToDictionary(c => c.Level);
        }

        public LevelConfig GetConfig(int level)
        {
            return _levelConfigs[level];
        }
    }
}