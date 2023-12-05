using System;
using _Enums.Panels;
using _Scripts._Panels;
using PS.PanelsFeature.Controller;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Scripts._Bootstrap
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private LoadingView _loadingView;

        private void Start()
        {
            _loadingView.Open();
        }
    }
}