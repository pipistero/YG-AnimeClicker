using _Scripts._Enums.Upgrades;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Levels
{
    [CreateAssetMenu(menuName = "Levels/New Level Config", fileName = "New Level Config")]
    public class LevelConfig : ScriptableObject
    {
        [Header("Level")]
        [SerializeField, Range(1, 10)] private int _level;

        [Header("Images")] 
        [SerializeField] private string _background;

        [Header("Texts")] 
        [SerializeField] private string _name;
        
        [Header("Conditions")] 
        [SerializeField] private LevelCondition _condition;
        
        public int Level => _level;

        public string Background => _background;

        public string Name => _name;

        public LevelCondition Condition => _condition;
    }
}