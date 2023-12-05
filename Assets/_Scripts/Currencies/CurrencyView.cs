using System;
using System.Numerics;
using _Enums.Currencies;
using PS.ResourcesFeature.Controller;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Currencies
{
    public class CurrencyView : MonoBehaviour
    {
        [Header("Type")] 
        [SerializeField] private CurrencyType _type;
        
        [Header("Texts")] 
        [SerializeField] private TextMeshProUGUI _value;

        [Header("Images")] 
        [SerializeField] private Image _icon;

        private ResourcesController<CurrencyType> _resourcesController;

        [Inject]
        public void Construct(ResourcesController<CurrencyType> resourcesController)
        {
            _resourcesController = resourcesController;
        }

        private void OnResourceUpdated(CurrencyType type, BigInteger oldValue, BigInteger newValue, object sender)
        {
            UpdateView(oldValue, newValue);
        }

        private void UpdateView(BigInteger oldValue, BigInteger newValue)
        {
            _value.text = newValue.ToString();
        }

        #region Events work

        private void OnEnable()
        {
            _resourcesController.ResourceBigIntegerUpdated += OnResourceUpdated;
        }

        private void OnDisable()
        {
            _resourcesController.ResourceBigIntegerUpdated -= OnResourceUpdated;
        }

        #endregion
    }
}