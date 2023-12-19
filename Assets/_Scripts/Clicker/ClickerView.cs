using System;
using System.Numerics;
using System.Threading.Tasks;
using _Enums.Currencies;
using _Scripts.Clicker.UI;
using _Scripts.Currencies;
using PS.ObjectPool.Controller;
using PS.ResourcesFeature.Controller;
using PS.SpritesFeature.Controller;
using PS.TimerFeature.TimeInvoker;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;
using Vector3 = UnityEngine.Vector3;

namespace _Scripts.Clicker
{
    public class ClickerView : MonoBehaviour
    {
        [Header("Buttons")] 
        [SerializeField] private ClickerButton _button;

        [Header("Images")] 
        [SerializeField] private Image _background;
        
        [Header("Click view holder")] 
        [SerializeField] private Transform _clickViewHolder;

        private BigInteger _perClickValue;
        private BigInteger _perSecondValue;

        private ClickerData _clickerData;
        private ResourcesController<CurrencyType> _resourcesController;
        private ObjectPoolController _objectPoolController;
        private SpritesStorage _spritesStorage;
        
        [Inject]
        public void Construct(
            ClickerData clickerData, 
            ResourcesController<CurrencyType> resourcesController,
            ObjectPoolController objectPoolController,
            SpritesStorage spritesStorage)
        {
            _clickerData = clickerData;
            _resourcesController = resourcesController;
            _objectPoolController = objectPoolController;
            _spritesStorage = spritesStorage;
        }

        private void Start()
        {
            _perClickValue = _clickerData.PerClickValue;
            _perSecondValue = _clickerData.PerSecondValue;
            
            UpdateView();
        }

        public void UpdateView()
        {
            _background.sprite = _spritesStorage.GetSprite($"Level{_clickerData.Level}Background");
        }
        
        private async void OnLevelUpdated(int level)
        {
            await Task.Delay(1000);
            
            UpdateView();
        }
        
        private void OnButtonClick(PointerEventData eventData)
        {
            PlayClickAnimation(_clickViewHolder.InverseTransformVector(eventData.pointerPressRaycast.worldPosition));
            
            _resourcesController.AddAmount(CurrencyType.Gold, _perClickValue, this);            
        }

        private void OnSecondTicked()
        {
            _resourcesController.AddAmount(CurrencyType.Gold, _perSecondValue, this);
        }

        private async Task PlayClickAnimation(Vector3 position)
        {
            var clickView = _objectPoolController.CreateObject<ClickView>(_clickViewHolder);
            clickView.transform.localPosition = position;
            
            await clickView.Play(_perClickValue);
            
            _objectPoolController.ReturnToPool(clickView);
        }
        
        #region Events

        private void OnEnable()
        {
            _button.Clicked += OnButtonClick;
            
            _clickerData.PerSecondValueUpdated += OnPerSecondValueUpdated;
            _clickerData.PerClickValueUpdated += OnPerClickValueUpdated;
            _clickerData.LevelUpdated += OnLevelUpdated;

            TimeInvoker.Instance.SecondTickedUnscaled += OnSecondTicked;
        }

        private void OnDisable()
        {
            _button.Clicked -= OnButtonClick;

            _clickerData.PerSecondValueUpdated -= OnPerSecondValueUpdated;
            _clickerData.PerClickValueUpdated -= OnPerClickValueUpdated;
            _clickerData.LevelUpdated -= OnLevelUpdated;
            
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