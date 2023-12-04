using System.Threading.Tasks;
using UnityEngine;

namespace PS.SoundsFeature.Objects
{
    public class OneShotSoundObject : AbstractSoundObject
    {
        public override async Task Play(AudioClip audioClip)
        {
            _audioSource.loop = false;
            _audioSource.clip = audioClip;
            
            _audioSource.Play();

            await Task.Delay(Mathf.CeilToInt(audioClip.length * 1000f));

            Dispose();
        }

        public override void Stop()
        {
            _audioSource.Stop();
            
            Dispose();
        }
    }
}