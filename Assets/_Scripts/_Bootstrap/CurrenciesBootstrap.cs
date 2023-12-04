using _Enums.Currencies;
using PS.ResourcesFeature.Controller;
using PS.ResourcesFeature.Resources;
using UnityEngine;
using Zenject;

namespace _Scripts._Bootstrap
{
    public class CurrenciesBootstrap : MonoBehaviour
    {
        private ResourcesController<CurrencyType> _resourcesController;

        [Inject]
        private void Construct(ResourcesController<CurrencyType> resourcesController)
        {
            _resourcesController = resourcesController;
            
            InitializeResourcesController();
        }

        private void InitializeResourcesController()
        {
            ResourceInteger<CurrencyType>[] integerResources = new[]
            {
                new ResourceInteger<CurrencyType>(CurrencyType.Gold, 0)
            };
            
            _resourcesController.InitializeResources(integerResources);
        }
    }
}