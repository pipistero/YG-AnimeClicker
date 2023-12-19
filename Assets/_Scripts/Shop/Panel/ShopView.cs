using System.Threading.Tasks;
using _Scripts.Shop.Item;
using _Scripts.Upgrades;
using PS.LocalizationFeature.Controller;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Scripts.Shop.Panel
{
    //TODO: check bugs with level change
    //TODO: add notification on unlocked shop items
    //TODO: add scroll
    public class ShopView : MonoBehaviour
    {
        [Header("Animation")] 
        [SerializeField] private ShopViewAnimationHandler _animationHandler;

        [Header("Texts")] 
        [SerializeField] private TextMeshProUGUI _title;

        [Header("Items")]
        [SerializeField] private ShopItemView[] _views;

        [Header("Buttons")]
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

        private async Task OnButtonClicked()
        {
            _shopButton.Interactable = false;

            _state = !_state;
            
            _shopButton.SetState(_state);
            _shopButton.SetNotificationState(false);
            
            await _animationHandler.SetState(_state);
            
            _shopButton.Interactable = true;
        }

        private void Start()
        {
            _shopButton.SetState(_state);
            _shopButton.SetNotificationState(false);
            
            _shopButton.Clicked += () =>
            {
                OnButtonClicked();
            };
            
            InitializeViews();
            InitializeLocalization();
        }

        private void InitializeLocalization()
        {
            _title.text = _localizationController.Get("ShopTitle");
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