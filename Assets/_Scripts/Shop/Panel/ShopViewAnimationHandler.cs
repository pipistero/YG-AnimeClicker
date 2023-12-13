using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Shop.Panel
{
    //TODO: разделить настройку анимации на две
    public class ShopViewAnimationHandler : MonoBehaviour
    {
        [Header("Setup")] 
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private float _closedXPosition;
        [SerializeField] private float _openedXPosition;
        [SerializeField] private float _animationDuration;
        [SerializeField] private Ease _ease;

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
                .DOAnchorPosX(_openedXPosition, _animationDuration)
                .SetEase(_ease);

            await Task.Delay(TimeSpan.FromSeconds(_animationDuration));
        }

        private async Task PlayCloseAnimation()
        {
            _rectTransform
                .DOAnchorPosX(_closedXPosition, _animationDuration)
                .SetEase(_ease);

            await Task.Delay(TimeSpan.FromSeconds(_animationDuration));
        }
    }
}