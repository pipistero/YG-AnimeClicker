using PS.LocalizationFeature.Assets;
using PS.LocalizationFeature.Controller;
using PS.LocalizationFeature.Types;
using UnityEngine;
using Zenject;

namespace _Installers
{
    public class LocalizationControllerInstaller : MonoInstaller
    {
        [SerializeField] private LanguageAsset[] _languageAssets;
        
        public override void InstallBindings()
        {
            Container
                .BindInstance(new LocalizationController(_languageAssets, LanguageType.English))
                .AsSingle()
                .NonLazy();
        }
    }
}