using System;
using _Scripts.Clicker;
using PS.LocalizationFeature.Controller;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Zenject;

namespace _Scripts.LevelTransition
{
    public class LevelTransitionView : MonoBehaviour 
    {
        [Header("Animation")] 
        [SerializeField] private LevelTransitionAnimationHandler _animationHandler;

        private ClickerData _clickerData;

        [Inject]
        private void Construct(ClickerData clickerData, LocalizationController localizationController)
        {
            _clickerData = clickerData;
        }

        private void Start()
        {
            _clickerData.LevelUpdated += OnLevelUpdated;
        }

        private async void OnLevelUpdated(int level)
        {
            await _animationHandler.PlayAnimation();
        }
    }
}