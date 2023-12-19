using System;
using UnityEngine;
using UnityEngine.UI;

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

        #region Events work

        private void OnEnable()
        {
            _button.onClick.AddListener(() => Clicked?.Invoke());
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(() => Clicked?.Invoke());
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
    }
}