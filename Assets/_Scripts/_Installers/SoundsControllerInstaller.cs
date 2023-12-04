using _Scripts._Enums.Sounds;
using PS.SoundsFeature.Controller;
using PS.SoundsFeature.Data;
using UnityEngine;
using Zenject;

namespace _Installers
{
    public class SoundsControllerInstaller : MonoInstaller
    {
        [SerializeField] private SoundsFactory _soundsFactory;
        [SerializeField] private AudioClipData<SoundType>[] _audioClipsData;

        public override void InstallBindings()
        {
            Container
                .Bind<SoundsController<SoundType>>()
                .FromInstance(new SoundsController<SoundType>(_soundsFactory, _audioClipsData))
                .AsSingle()
                .NonLazy();
        }
    }
}