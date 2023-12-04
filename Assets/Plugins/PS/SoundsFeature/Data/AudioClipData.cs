using System;
using UnityEngine;

namespace PS.SoundsFeature.Data
{
    [Serializable]
    public class AudioClipData<T>
        where T : Enum
    {
        public T Type;
        public AudioClip AudioClip;
    }
}