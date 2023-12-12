using System;
using System.Numerics;
using _Enums.Currencies;
using _Scripts._Enums.Upgrades;
using _Scripts._UI;
using _Scripts.Clicker;
using _Scripts.Extensions;
using _Scripts.Upgrades;
using PS.LocalizationFeature.Controller;
using PS.ObjectPool.Interfaces;
using PS.ResourcesFeature.Controller;
using PS.SpritesFeature.Controller;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Shop.Item
{
    public class ShopItemView : MonoBehaviour, IPoolObject
    {
        [Header("Texts")] 
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _description;

        [Header("Images")] 
        [SerializeField] private Image _icon;
        
        [Header("Button")] 
        [SerializeField] private SimpleButton _buyButton;
        [SerializeField] private TextMeshProUGUI _price;
        
        [Header("Level")]
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private GameObject _levelGameObject;
        
        private SpritesStorage _spritesStorage;
        private ResourcesController<CurrencyType> _resourcesController;
        private LocalizationController _localizationController;
        private ClickerData _clickerData;

        private UpgradeConfig _upgradeConfig;
        private PerClickUpgradeType _perClickUpgradeType;
        private PerSecondUpgradeType _perSecondUpgradeType;

        [Inject]
        private void Construct(
            SpritesStorage spritesStorage, 
            ResourcesController<CurrencyType> resourcesController,
            LocalizationController localizationController,
            ClickerData clickerData)
        {
            _spritesStorage = spritesStorage;
            _resourcesController = resourcesController;
            _localizationController = localizationController;
            _clickerData = clickerData;
        }
        public void Initialize(UpgradeConfig upgradeConfig)
        {
            _upgradeConfig = upgradeConfig;

            if (_upgradeConfig.UpgradeType == UpgradeType.PerClick)
                _perClickUpgradeType = (_upgradeConfig as PerClickUpgradeConfig).PerClickUpgradeType; 
            else
                _perSecondUpgradeType = (_upgradeConfig as PerSecondUpgradeConfig).PerSecondUpgradeType; 
            
            UpdateView();
        }

        private void UpdateView()
        {
            _name.text = _localizationController.Get(_upgradeConfig.Name);
            _price.text = _upgradeConfig.Price.ToShortString();
            
            //_icon.sprite = _spritesStorage.GetSprite(_upgradeConfig.Icon);

            UpdateLevelText();
            UpdateDescription();
            UpdateBuyButton();
        }

        private void UpdateLevelText()
        {
            #region Internal methods

            void SetLevelText(int level)
            {
                _level.text = $"{level} {_localizationController.Get("Lvl")}";
            }

            void DisableLevelObject()
            {
                _levelGameObject.SetActive(false);
            }

            void EnableLevelObject()
            {
                _levelGameObject.SetActive(true);
            }

            #endregion

            DisableLevelObject();

            int level;

            if (_upgradeConfig.UpgradeType == UpgradeType.PerClick)
                level = _clickerData.GetPerClickUpgradeLevel(_perClickUpgradeType);
            else
                level = _clickerData.GetPerSecondUpgradeLevel(_perSecondUpgradeType);

            if (level == 0) return;
            
            EnableLevelObject();
            SetLevelText(level);
        }

        private void UpdateBuyButton()
        {
            if (_upgradeConfig != null)
                _buyButton.interactable = _resourcesController.HasAmount(CurrencyType.Gold, _upgradeConfig.Price);
        }

        private void UpdateDescription()
        {
            var description = $"+{_upgradeConfig.Value.ToShortString()}";

            if (_upgradeConfig.UpgradeType == UpgradeType.PerClick)
                description += $" {_localizationController.Get("PerClickUpgradeDescription")}";
            else
                description += $" {_localizationController.Get("PerSecondUpgradeDescription")}";

            _description.text = description;
        }

        private void OnResourceBigIntegerUpdated(CurrencyType type, BigInteger oldValue, BigInteger newValue, object sender)
        {
            UpdateBuyButton();
        }
        
        #region Events work

        private void OnEnable()
        {
            _resourcesController.ResourceBigIntegerUpdated += OnResourceBigIntegerUpdated;
        }

        private void OnDisable()
        {
            _resourcesController.ResourceBigIntegerUpdated -= OnResourceBigIntegerUpdated;
        }

        #endregion

        #region Pool work

        public GameObject GameObject => gameObject;
        public Type Type => typeof(ShopItemView);
        public void OnGetFromPool() { }
        public void OnReturnToPool() { }

        #endregion
    }
}