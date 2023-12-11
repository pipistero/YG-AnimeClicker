using System;
using System.Numerics;
using _Enums.Currencies;
using _Scripts.Extensions;
using PS.ResourcesFeature.Controller;
using PS.SpritesFeature.Controller;
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
        private SpritesStorage _spritesStorage;

        [Inject]
        public void Construct(ResourcesController<CurrencyType> resourcesController, SpritesStorage spritesStorage)
        {
            _resourcesController = resourcesController;
            _spritesStorage = spritesStorage;
        }

        private void Start()
        {
            _icon.sprite = _spritesStorage.GetSprite(_type.ToString());
            
            UpdateValue(BigInteger.Zero, _resourcesController.GetBigIntegerAmount(_type));
        }

        private void OnResourceUpdated(CurrencyType type, BigInteger oldValue, BigInteger newValue, object sender)
        {
            if (_type != type)
                return;
            
            UpdateValue(oldValue, newValue);
        }

        private void UpdateValue(BigInteger oldValue, BigInteger newValue)
        {
            _value.text = newValue.ToShortString();
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