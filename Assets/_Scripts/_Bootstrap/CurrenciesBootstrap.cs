using _Enums.Currencies;
using PS.ResourcesFeature.Controller;
using PS.ResourcesFeature.Resources;
using UnityEngine;
using Zenject;

namespace _Scripts._Bootstrap
{
    public class CurrenciesBootstrap : MonoBehaviour
    {
        [Inject]
        private void Construct(ResourcesController<CurrencyType> resourcesController)
        {
            InitializeResourcesController(resourcesController);
        }

        private void InitializeResourcesController(ResourcesController<CurrencyType> resourcesController)
        {
            ResourceInteger<CurrencyType>[] integerResources = new[]
            {
                new ResourceInteger<CurrencyType>(CurrencyType.Gold, 0)
            };
            
            resourcesController.InitializeResources(integerResources);
        }
    }
}