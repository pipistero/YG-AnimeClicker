using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Shop.Panel
{
    //TODO: разделить настройку анимации на две
    public class ShopViewAnimationHandler : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] private RectTransform _rectTransform;

        [Header("Open animation settings")]
        [SerializeField] private float _openedXPosition;
        [SerializeField] private float _openAnimationDuration;
        [SerializeField] private Ease _openAnimationEase;
        
        [Header("Close animation settings")]
        [SerializeField] private float _closedXPosition;
        [SerializeField] private float _closeAnimationDuration;
        [SerializeField] private Ease _closeAnimationEase;
        
        public async Task SetState(bool state)
        {
            if (state)
                await PlayOpenAnimation();
            else
                await PlayCloseAnimation();
        }

        private async Task PlayOpenAnimation()
        {
            _rectTransform
                .DOAnchorPosX(_openedXPosition, _openAnimationDuration)
                .SetEase(_openAnimationEase);

            await Task.Delay(TimeSpan.FromSeconds(_openAnimationDuration));
        }

        private async Task PlayCloseAnimation()
        {
            _rectTransform
                .DOAnchorPosX(_closedXPosition, _closeAnimationDuration)
                .SetEase(_closeAnimationEase);

            await Task.Delay(TimeSpan.FromSeconds(_closeAnimationDuration));
        }
    }
}