using System;
using _Enums.Currencies;
using _Enums.Panels;
using PS.PanelsFeature.Controller;
using PS.PanelsFeature.Panels;
using PS.ResourcesFeature.Controller;
using UnityEngine;
using Zenject;

namespace _Installers
{
    public class PanelsControllerInstaller : MonoInstaller
    {
        [SerializeField] private int _panelsSortingOrderStep;
        
        public override void InstallBindings()
        {
            var panels = FindObjectsOfType<AbstractPanel<PanelType>>();
            
            Container.Bind<PanelsController<PanelType>>()
                .FromInstance(new PanelsController<PanelType>(panels, _panelsSortingOrderStep))
                .AsSingle()
                .NonLazy();
        }
    }
}
