using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Scripts.Shop.Item;
using _Scripts.Upgrades;
using DG.Tweening;
using PS.LocalizationFeature.Controller;
using PS.ObjectPool.Controller;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Shop.Panel
{
    public class ShopView : MonoBehaviour
    {
        [Header("Animation")] 
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private float _closedXPosition;
        [SerializeField] private float _openedXPosition;
        [SerializeField] private float _animationDuration;
        [SerializeField] private Ease _ease;

        [Header("Texts")] 
        [SerializeField] private TextMeshProUGUI _title;

        [Header("Items")]
        [SerializeField] private ShopItemView[] _views;

        [Header("Buttons")] 
        [SerializeField] private Button _button;
        [SerializeField] private ShopButton _shopButton;
        
        private UpgradesStorage _upgradesStorage;
        private LocalizationController _localizationController;

        private bool _state;
        
        [Inject]
        private void Construct(
            UpgradesStorage upgradesStorage, 
            LocalizationController localizationController)
        {
            _upgradesStorage = upgradesStorage;
            _localizationController = localizationController;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener((() =>
            {
                OnButtonClicked();
            }));    
        }

        private async Task OnButtonClicked()
        {
            _button.interactable = false;

            _state = !_state;
            _shopButton.SetState(_state);

            _rectTransform
                .DOAnchorPosX(_state ? _openedXPosition : _closedXPosition, _animationDuration)
                .SetEase(_ease);

            await Task.Delay(TimeSpan.FromSeconds(_animationDuration));
            
            _button.interactable = true;
        }

        private void Start()
        {
            _shopButton.SetState(_state);
            
            InitializeViews();
        }

        private void InitializeViews()
        {
            var allUpgrades = _upgradesStorage.GetAllUpgrades();

            if (allUpgrades.Count != _views.Length)
            {
                Debug.LogError("ShopItemViews count is not equal upgrades count!");
                return;
            }

            for (int i = 0; i < _views.Length; i++)
            {
                _views[i].Initialize(allUpgrades[i]);
            }
        }
    }
}