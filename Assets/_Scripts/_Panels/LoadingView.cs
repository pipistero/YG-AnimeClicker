using System;
using System.Threading.Tasks;
using _Enums.Panels;
using PS.LocalizationFeature.Controller;
using PS.PanelsFeature.Panels;
using TMPro;
using UnityEngine;
using Zenject;
using DG.Tweening;
using UnityEngine.UI;

namespace _Scripts._Panels
{
    public class LoadingView : MonoBehaviour
    {
        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _gameName;

        [Header("Delay")] 
        [SerializeField] private int _delay;
        
        [Header("Open animation settings")]
        [SerializeField] private float _scaleDuration;
        [SerializeField] private float _scaleValue;
        [SerializeField] private Ease _scaleEasing;
        [SerializeField] private float _fadeDuration;
        [SerializeField] private Ease _fadeEasing;

        private void Awake()
        {
            _gameName.gameObject.SetActive(false);
        }

        public async Task Open()
        {
            await Task.Delay(_delay);

            _gameName.gameObject.SetActive(true);
            
            _gameName.color = new Color(1f, 1f, 1f, 0f);
            _gameName.transform.localScale = Vector3.one;

            _gameName.transform.DOScale(_scaleValue, _scaleDuration).SetEase(_scaleEasing);
            _gameName.DOFade(1f, _fadeDuration).SetEase(_fadeEasing);

            await Task.Delay((int)(_scaleDuration * 1000f));
        }

        public void Close()
        {
        }
    }
}