using PS.LocalizationFeature.Controller;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Scripts.Shop.Item
{
    public class ShopItemViewStatesHandler : MonoBehaviour
    {
        [Header("States")] 
        [SerializeField] private GameObject _unlockedState;
        [SerializeField] private GameObject _lockedState;

        [Header("Texts")] 
        [SerializeField] private TextMeshProUGUI _text;

        private LocalizationController _localizationController;
        
        [Inject]
        private void Construct(LocalizationController localizationController)
        {
            _localizationController = localizationController;
        }
        
        public void SetState(bool state, int level)
        {
            _unlockedState.SetActive(state);    
            _lockedState.SetActive(!state);

            _text.text = $"{_localizationController.Get("ShopItemLocked")} {level}";
        }
    }
}