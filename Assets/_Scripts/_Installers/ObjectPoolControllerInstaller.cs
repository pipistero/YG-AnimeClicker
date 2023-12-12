using System.Collections.Generic;
using _Scripts.Clicker.UI;
using _Scripts.Shop.Item;
using PS.ObjectPool.Controller;
using PS.ObjectPool.Factory;
using PS.ObjectPool.Interfaces;
using UnityEngine;
using Zenject;

namespace _Installers
{
    public class ObjectPoolControllerInstaller : MonoInstaller
    {
        [Header("Factory")] 
        [SerializeField] private ObjectPoolFactory _objectPoolFactory;

        [Header("Holder")] 
        [SerializeField] private Transform _objectsHolder;

        [Header("Prefabs")] 
        [SerializeField] private ClickView _clickViewPrefab;
        [SerializeField] private ShopItemView _shopItemViewPrefab;

        public override void InstallBindings()
        {
            Container
                .BindInstance(new ObjectPoolController(_objectPoolFactory, _objectsHolder, GetPoolPrefabs()))
                .AsSingle()
                .NonLazy();
        }

        private List<IPoolObject> GetPoolPrefabs()
        {
            var result = new List<IPoolObject>();

            result.Add(_clickViewPrefab);
            result.Add(_shopItemViewPrefab);
            
            return result;
        }
    }
}