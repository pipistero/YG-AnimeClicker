using System;
using System.Numerics;
using System.Threading.Tasks;
using _Scripts.Extensions;
using DG.Tweening;
using PS.ObjectPool.Interfaces;
using TMPro;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace _Scripts.Clicker.UI
{
    public class ClickView : MonoBehaviour, IPoolObject
    {
        [Header("Container")] 
        [SerializeField] private Transform _container;
        
        [Header("Texts")] 
        [SerializeField] private TextMeshProUGUI _value;

        [Header("Animation")] 
        [SerializeField] private Ease _easing;
        [SerializeField] private float _animationDuration;
        [SerializeField] private float _localMoveValue;
        [SerializeField] private float _endScaleValue;

        public async Task Play(BigInteger value)
        {
            _value.text = $"+{value.ToShortString()}";

            await StartAnimation();
        }

        private async Task StartAnimation()
        {
            _container.localPosition = Vector3.zero;
            _container.localScale = Vector3.one;

            _container.DOLocalMoveY(30f, _animationDuration).SetEase(_easing);
            _container.DOScale(_endScaleValue, _animationDuration).SetEase(_easing);

            await Task.Delay(TimeSpan.FromSeconds(_animationDuration));
        }
        
        #region Pool Work

        public GameObject GameObject => gameObject;
        public Type Type => typeof(ClickView);

        public void OnGetFromPool()
        {
            gameObject.SetActive(true);
        }

        public void OnReturnToPool()
        {
            gameObject.SetActive(false);
        }
        
        #endregion
    }
}