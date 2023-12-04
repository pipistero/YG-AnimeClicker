using System;

namespace PS.SoundsFeature.Settings
{
    public class SoundSettings
    {
        private int _priority = 128;
        public int Priority
        {
            get => _priority;
            set => _priority = Math.Clamp(value, 0, 256);
        }

        private float _volume = 1f;
        public float Volume
        {
            get => _volume;
            set => _volume = Math.Clamp(value, 0f, 1f);
        }

        private float _pitch = 1f;
        public float Pitch
        {
            get => _pitch;
            set => _pitch = Math.Clamp(value, -3f, 3f);
        }

        private float _stereoPan = 0f;
        public float StereoPan
        {
            get => _stereoPan;
            set => _stereoPan = Math.Clamp(value, -1f, 1f);
        }
    }
}