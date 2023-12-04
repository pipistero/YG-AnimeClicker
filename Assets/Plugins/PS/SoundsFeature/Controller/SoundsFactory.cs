using PS.SoundsFeature.Objects;
using UnityEngine;

namespace PS.SoundsFeature.Controller
{
    public class SoundsFactory : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private OneShotSoundObject _oneShotSoundPrefab;
        [SerializeField] private LoopSoundObject _loopSoundPrefab;
        
        [Header("Holder")]
        [SerializeField] private Transform _soundsHolder;
        
        public OneShotSoundObject CreateOneShotSoundObject()
        {
            return Instantiate(_oneShotSoundPrefab, _soundsHolder);
        }

        public LoopSoundObject CreateLoopSoundObject()
        {
            return Instantiate(_loopSoundPrefab, _soundsHolder);
        }
    }
}