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
        [Header("States")] 
        [SerializeField] private ShopItemViewStatesHandler _statesHandler;
        
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
        private UpgradeType _upgradeType;
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

        private void Awake()
        {
            _buyButton.AddListener(() => OnBuyButtonClicked());
        }

        private void OnBuyButtonClicked()
        {
            if (_upgradeType == UpgradeType.PerSecond)
                _clickerData.AddPerSecondUpgrade(_perSecondUpgradeType);
            else
                _clickerData.AddPerClickUpgrade(_perClickUpgradeType);
        }

        public void Initialize(UpgradeConfig upgradeConfig)
        {
            _upgradeConfig = upgradeConfig;
            _upgradeType = _upgradeConfig.UpgradeType;

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
            UpdateState();
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

        private void UpdateState()
        {
            _statesHandler.SetState(_upgradeConfig.Level <= _clickerData.Level, _upgradeConfig.Level);
        }

        private void OnResourceBigIntegerUpdated(CurrencyType type, BigInteger oldValue, BigInteger newValue, object sender)
        {
            UpdateBuyButton();
        }

        private void OnLevelUpdated(int level)
        {
            UpdateState();
        }

        private void OnUpgradeAdded(UpgradeConfig config, int level)
        {
            if (config != _upgradeConfig)
                return;
            
            _levelGameObject.SetActive(true);
            _level.text = level.ToString();
        }

        #region Events work

        private void OnEnable()
        {
            _resourcesController.ResourceBigIntegerUpdated += OnResourceBigIntegerUpdated;
            
            _clickerData.LevelUpdated += OnLevelUpdated;
            _clickerData.UpgradeAdded += OnUpgradeAdded;
        }

        private void OnDisable()
        {
            _resourcesController.ResourceBigIntegerUpdated -= OnResourceBigIntegerUpdated;
            
            _clickerData.LevelUpdated -= OnLevelUpdated;
            _clickerData.UpgradeAdded -= OnUpgradeAdded;
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