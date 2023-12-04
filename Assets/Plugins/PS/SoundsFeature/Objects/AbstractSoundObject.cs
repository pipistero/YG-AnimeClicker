using System.Threading.Tasks;
using PS.SoundsFeature.Settings;
using UnityEngine;

namespace PS.SoundsFeature.Objects
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class AbstractSoundObject : MonoBehaviour
    {
        [SerializeField] protected AudioSource _audioSource;

        public abstract Task Play(AudioClip audioClip);
        public abstract void Stop();

        public void SetSettings(SoundSettings settings)
        {
            _audioSource.priority = settings.Priority;
            _audioSource.volume = settings.Volume;
            _audioSource.pitch = settings.Pitch;
            _audioSource.panStereo = settings.StereoPan;
        }
        
        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}