using System;
using _Scripts.Clicker;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Shop.Panel
{
    public class ShopButton : MonoBehaviour
    {
        public event Action Clicked; 

        [Header("Button")] 
        [SerializeField] private Button _button;
        
        [Header("Arrow")]
        [SerializeField] private GameObject _arrow;

        [Header("Notification")] 
        [SerializeField] private GameObject _notification;

        public bool Interactable
        {
            get => _button.interactable;
            set => _button.interactable = value;
        }
        
        private readonly Vector3 _arrowClosedState = new Vector3(-1f, 1f, 1f);
        private readonly Vector3 _arrowOpenedState = new Vector3(1f, 1f, 1f);

        private ClickerData _clickerData;

        [Inject]
        private void Construct(ClickerData clickerData)
        {
            _clickerData = clickerData;
        }
        
        #region Events work

        private void OnEnable()
        {
            _button.onClick.AddListener(() => Clicked?.Invoke());
            _clickerData.LevelUpdated += OnLevelUpdated;
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(() => Clicked?.Invoke());
            _clickerData.LevelUpdated -= OnLevelUpdated;
        }

        #endregion

        public void SetNotificationState(bool state)
        {
            _notification.SetActive(state);
        }

        public void SetState(bool state)
        {
            _arrow.transform.localScale = state ? _arrowOpenedState : _arrowClosedState;
        }

        private void OnLevelUpdated(int level)
        {
            SetNotificationState(true);
        }
    }
}