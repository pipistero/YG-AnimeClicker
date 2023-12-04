using System.Threading.Tasks;
using UnityEngine;

namespace PS.SoundsFeature.Objects
{
    public class LoopSoundObject : AbstractSoundObject
    {
        public override Task Play(AudioClip audioClip)
        {
            _audioSource.loop = true;
            _audioSource.clip = audioClip;
            
            _audioSource.Play();

            return Task.CompletedTask;
        }

        public override void Stop()
        {
            _audioSource.Stop();
        }

        public void Pause()
        {
            _audioSource.Pause();
        }

        public void Unpause()
        {
            _audioSource.UnPause();
        }
    }
}