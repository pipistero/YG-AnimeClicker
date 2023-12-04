using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PS.SoundsFeature.Data;
using PS.SoundsFeature.Objects;
using PS.SoundsFeature.Settings;
using UnityEngine;

namespace PS.SoundsFeature.Controller
{
    public class SoundsController<T> where T : Enum
    {
        private readonly SoundsFactory _soundsFactory;
        
        private readonly Dictionary<T, AudioClip> _soundClipsMap;
        private readonly Dictionary<T, LoopSoundObject> _activeLoopSounds;

        public SoundsController(SoundsFactory soundsFactory, IEnumerable<AudioClipData<T>> audioClipsData)
        {
            _soundsFactory = soundsFactory;
            
            _soundClipsMap = new Dictionary<T, AudioClip>();
            _activeLoopSounds = new Dictionary<T, LoopSoundObject>();
            
            foreach (var data in audioClipsData)
            {
                if (data.AudioClip == null)
                    throw new Exception($"Audio clip missing; Sound ({data.Type})");
                
                _soundClipsMap.Add(data.Type, data.AudioClip);
            }
        }

        #region One shot sound methods

        public async Task PlayOneShotSound(T soundType, SoundSettings soundSettings = default)
        {
            ValidateSoundType(soundType);

            soundSettings ??= new SoundSettings();
            
            var soundObject = _soundsFactory.CreateOneShotSoundObject();
            var audioClip = _soundClipsMap[soundType];
            
            soundObject.SetSettings(soundSettings);
            soundObject.gameObject.name = $"OneShot sound {soundType}";
            
            await soundObject.Play(audioClip);
        }

        #endregion

        #region Loop sound methods

        public void PlayLoopSound(T soundType, SoundSettings soundSettings = default)
        {
            ValidateSoundType(soundType);

            soundSettings ??= new SoundSettings();
            var audioClip = _soundClipsMap[soundType];

            if (_activeLoopSounds.TryGetValue(soundType, out var activeSoundObject))
            {
                activeSoundObject.gameObject.name = $"Loop sound {soundType}";
                activeSoundObject.SetSettings(soundSettings);
                activeSoundObject.Play(audioClip);
            }
            else
            {
                var soundObject = _soundsFactory.CreateLoopSoundObject();
            
                soundObject.gameObject.name = $"Loop sound {soundType}";
                soundObject.SetSettings(soundSettings);
                soundObject.Play(audioClip);
                
                _activeLoopSounds.Add(soundType, soundObject);
            }
        }

        public void PauseLoopSound(T soundType)
        {
            if (_activeLoopSounds.TryGetValue(soundType, out var activeSoundObject))
                activeSoundObject.Pause();
            else
                Debug.Log($"There is no active sound ({soundType})");
        }
        
        public void UnpauseLoopSound(T soundType)
        {
            if (_activeLoopSounds.TryGetValue(soundType, out var activeSoundObject))
                activeSoundObject.Unpause();
            else
                Debug.Log($"There is no active sound ({soundType})");
        }
        
        public void StopLoopSound(T soundType)
        {
            if (_activeLoopSounds.TryGetValue(soundType, out var activeSoundObject))
            {
                activeSoundObject.Stop();
                activeSoundObject.Dispose();

                _activeLoopSounds.Remove(soundType);
            }
            else
            {
                Debug.Log($"There is no active sound ({soundType})");
            }
        }

        #endregion

        #region Internal methods

        private void ValidateSoundType(T soundType)
        {
            if (_soundClipsMap.ContainsKey(soundType) == false)
                throw new Exception($"There is no audio clip for sound ({soundType})");
        }

        #endregion
    }
}