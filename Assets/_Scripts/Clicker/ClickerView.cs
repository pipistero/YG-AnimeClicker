using System;
using System.Numerics;
using _Enums.Currencies;
using _Scripts.Currencies;
using PS.ResourcesFeature.Controller;
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

        [Header("Texts")] 
        [SerializeField] private TextMeshProUGUI _level;
        
        [Header("Currency")] 
        [SerializeField] private CurrencyView _currencyView;

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
            UpdateView();
        }

        public void UpdateView()
        {
            _level.text = $"Level {_clickerData.Level}";
        }
        
        private void OnButtonClick()
        {
            //Animation etc.
            _resourcesController.AddAmount(CurrencyType.Gold, _perClickValue, this);            
        }
        
        #region Events

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
            
            _clickerData.PerSecondValueUpdated += OnPerSecondValueUpdated;
            _clickerData.PerClickValueUpdated += OnPerClickValueUpdated;
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);

            _clickerData.PerSecondValueUpdated -= OnPerSecondValueUpdated;
            _clickerData.PerClickValueUpdated -= OnPerClickValueUpdated;
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