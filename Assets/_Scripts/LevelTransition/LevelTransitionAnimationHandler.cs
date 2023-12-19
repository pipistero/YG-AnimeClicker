using System;
using System.Threading.Tasks;
using _Scripts.Clicker.UI;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.LevelTransition
{
    public class LevelTransitionAnimationHandler : MonoBehaviour
    {
        [Header("Targets")]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private CanvasGroup _textCanvasGroup;
        [SerializeField] private LevelTextView _levelText;

        [Header("Canvas group fade settings")]
        [SerializeField] private float _fadeOutDelay;
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private float _fadeOutDuration;
        [SerializeField] private Ease _fadeInEase;
        [SerializeField] private Ease _fadeOutEase;
        
        [Header("Text scale settings")] 
        [SerializeField] private float _textScaleDelay;
        [SerializeField] private float _startScale;
        [SerializeField] private float _endScale;
        [SerializeField] private float _scaleDuration;
        [SerializeField] private float _textFadeDuration;
        [SerializeField] private Ease _scaleEase;
        [SerializeField] private Ease _textFadeEase;

        private void Start()
        {
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.alpha = 0f;
        }

        public async Task PlayAnimation()
        {
            _canvasGroup.blocksRaycasts = true;
            _textCanvasGroup.alpha = 0f;
            
            _levelText.transform.localScale = Vector3.one * _startScale;
            
            _canvasGroup
                .DOFade(1f, _fadeInDuration)
                .SetEase(_fadeInEase);
            
            await Task.Delay(TimeSpan.FromSeconds(_textScaleDelay));

            _textCanvasGroup
                .DOFade(1f, _textFadeDuration)
                .SetEase(_textFadeEase);
                
            _levelText.transform
                .DOScale(_endScale, _scaleDuration)
                .SetEase(_scaleEase);
            
            await Task.Delay(TimeSpan.FromSeconds(_fadeOutDelay));
            
            _canvasGroup
                .DOFade(0f, _fadeOutDuration)
                .SetEase(_fadeOutEase);
            
            await Task.Delay(TimeSpan.FromSeconds(_fadeInDuration + _scaleDuration + _fadeOutDuration));

            _canvasGroup.blocksRaycasts = false;
        }
    }
}