using System;
using _Enums.Panels;
using _Scripts._Panels;
using _Scripts.Shop.Item;
using _Scripts.Upgrades;
using PS.ObjectPool.Controller;
using PS.PanelsFeature.Controller;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Scripts._Bootstrap
{
    public class GameBootstrap : MonoBehaviour
    {
        private ObjectPoolController _objectPoolController;
        private UpgradesStorage _upgradesStorage;

        [Inject]
        private void Construct(ObjectPoolController objectPoolController, UpgradesStorage upgradesStorage)
        {
            _objectPoolController = objectPoolController;
            _upgradesStorage = upgradesStorage;
        }
        
        private void Awake()
        {
        }
    }
}