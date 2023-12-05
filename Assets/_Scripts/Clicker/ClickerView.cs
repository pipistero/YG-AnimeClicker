using System;
using System.Numerics;
using _Enums.Currencies;
using _Scripts.Currencies;
using PS.ResourcesFeature.Controller;
using PS.TimerFeature.TimeInvoker;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Clicker
{
    public class ClickerView : MonoBehaviour
    {
        [Header("Buttons")] 
        [SerializeField] private Button _button;

        private BigInteger _perClickValue;
        private BigInteger _perSecondValue;

        private ClickerData _clickerData;
        private ResourcesController<CurrencyType> _resourcesController;

        [Inject]
        public void Construct(ClickerData clickerData, ResourcesController<CurrencyType> resourcesController)
        {
            _clickerData = clickerData;
            _resourcesController = resourcesController;
        }

        private void Start()
        {
            _perClickValue = _clickerData.PerClickValue;
            _perSecondValue = _clickerData.PerSecondValue;
            
            UpdateView();
        }

        public void UpdateView()
        {
            
        }
        
        private void OnButtonClick()
        {
            //Animation etc.
            _resourcesController.AddAmount(CurrencyType.Gold, _perClickValue, this);            
        }

        private void OnSecondTicked()
        {
            _resourcesController.AddAmount(CurrencyType.Gold, _perSecondValue, this);
        }
        
        #region Events

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
            
            _clickerData.PerSecondValueUpdated += OnPerSecondValueUpdated;
            _clickerData.PerClickValueUpdated += OnPerClickValueUpdated;

            TimeInvoker.Instance.SecondTickedUnscaled += OnSecondTicked;
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);

            _clickerData.PerSecondValueUpdated -= OnPerSecondValueUpdated;
            _clickerData.PerClickValueUpdated -= OnPerClickValueUpdated;
            
            TimeInvoker.Instance.SecondTickedUnscaled -= OnSecondTicked;
        }

        #endregion

        #region Upgrade Events

        private void OnPerSecondValueUpdated(BigInteger value)
        {
            _perSecondValue = value;
        }

        private void OnPerClickValueUpdated(BigInteger value)
        {
            _perClickValue = value;
        }

        #endregion
    }
}