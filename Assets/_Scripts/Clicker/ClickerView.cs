using System;
using System.Numerics;
using _Scripts.Currencies;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Clicker
{
    public class ClickerView : MonoBehaviour
    {
        [Header("Buttons")] 
        [SerializeField] private Button _button;

        [Header("Currency")] 
        [SerializeField] private CurrencyView _currencyView;

        private BigInteger _perClickValue;
        private BigInteger _perSecondValue;

        private ClickerData _clickerData;
        
        [Inject]
        public void Construct()
        {
            
        }

        #region Events

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }
        
        #endregion
        
        private void OnButtonClick()
        {
            
        }
    }
}