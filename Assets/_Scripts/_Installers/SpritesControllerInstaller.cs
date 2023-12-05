using System;
using System.Collections.Generic;
using PS.SpritesFeature.Controller;
using UnityEngine;
using Zenject;

namespace _Installers
{
    public class SpritesControllerInstaller : MonoInstaller
    {
        [SerializeField] private Sprite[] _images;
        
        public override void InstallBindings()
        {
            Container
                .BindInstance(new SpritesStorage(GetImages()))
                .AsSingle()
                .NonLazy();
        }

        private List<Sprite> GetImages()
        {
            var result = new List<Sprite>();

            result.AddRange(_images);
            
            return result;
        }
    }
}