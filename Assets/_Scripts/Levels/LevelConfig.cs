using UnityEngine;

namespace _Scripts.Levels
{
    [CreateAssetMenu(menuName = "Levels/New Level Config", fileName = "New Level Config")]
    public class LevelConfig : ScriptableObject
    {
        [Header("Level")]
        [SerializeField, Range(1, 10)] private int _level;

        [Header("Images")] 
        [SerializeField] private Sprite _background;

        [Header("Texts")] 
        [SerializeField] private string _name;

        public int Level => _level;

        public Sprite Background => _background;

        public string Name => _name;
    }
}