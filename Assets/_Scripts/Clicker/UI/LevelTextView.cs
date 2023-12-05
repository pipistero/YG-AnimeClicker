using System;
using PS.LocalizationFeature.Controller;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Scripts.Clicker.UI
{
    public class LevelTextView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private ClickerData _clickerData;
        private LocalizationController _localizationController;

        [Inject]
        public void Construct(ClickerData clickerData, LocalizationController localizationController)
        {
            _clickerData = clickerData;
            _localizationController = localizationController;
        }

        private void Start()
        {
            OnLevelUpdated(_clickerData.Level);
        }

        private void OnLevelUpdated(int level)
        {
            _text.text =
                $"{_localizationController.Get("ChapterText")} {level}. {_localizationController.Get($"ChapterName{level}")}";
        }

        #region Events work

        private void OnEnable()
        {
            _clickerData.LevelUpdated += OnLevelUpdated;
        }

        private void OnDisable()
        {
            _clickerData.LevelUpdated -= OnLevelUpdated;
        }

        #endregion
    }
}