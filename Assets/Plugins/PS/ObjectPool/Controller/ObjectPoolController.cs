using System;
using System.Collections.Generic;
using System.Linq;
using PS.ObjectPool.Factory;
using PS.ObjectPool.Interfaces;
using UnityEngine;

namespace PS.ObjectPool.Controller
{
    public class ObjectPoolController
    {
        private readonly ObjectPoolFactory _objectPoolFactory;
        
        private readonly Transform _poolObjectsHolder;
        private readonly Dictionary<Type, IPoolObject> _prefabs;
        
        private readonly Dictionary<Type, Stack<IPoolObject>> _poolObjects;

        public ObjectPoolController(
            ObjectPoolFactory objectPoolFactory,
            Transform poolObjectsHolder,
            IEnumerable<IPoolObject> prefabs
            )
        {
            _objectPoolFactory = objectPoolFactory;
            _poolObjectsHolder = poolObjectsHolder;
            _prefabs = prefabs.ToDictionary(prefab => prefab.Type);
            _poolObjects = new Dictionary<Type, Stack<IPoolObject>>();
        }

        public void InitializeObject<T>(int objectsCount) where T : IPoolObject
        {
            for (int i = 0; i < objectsCount; i++)
            {
                CreatePoolObject<T>();
            }
        }

        public T CreateObject<T>(Transform holder) where T : IPoolObject
        {
            var obj = GetObject<T>();
            
            obj.GameObject.transform.SetParent(holder);
            obj.GameObject.transform.localScale = Vector3.one;
            obj.GameObject.SetActive(true);

            return obj;
        }

        public void ReturnToPool(IPoolObject objectToReturn)
        {
            AddObjectToPool(objectToReturn);
        }

        #region Internal methods

        private IPoolObject GetPrefab<T>()
        {
            if (_prefabs.ContainsKey(typeof(T)) == false)
                throw new ArgumentException($"There is no such prefab ({typeof(T)}) in object pool");
            
            return _prefabs[typeof(T)];
        }

        private void AddObjectToPool(IPoolObject objectToAdd)
        {
            objectToAdd.GameObject.transform.SetParent(_poolObjectsHolder);
            objectToAdd.GameObject.SetActive(false);

            if (_poolObjects.ContainsKey(objectToAdd.Type))
            {
                _poolObjects[objectToAdd.Type].Push(objectToAdd);
            }
            else
            {
                _poolObjects.Add(objectToAdd.Type, new Stack<IPoolObject>());
                _poolObjects[objectToAdd.Type].Push(objectToAdd);
            }
        }

        private T CreatePoolObject<T>() where T : IPoolObject
        {
            var obj = _objectPoolFactory.CreateObject<T>(GetPrefab<T>(), _poolObjectsHolder);

            AddObjectToPool(obj);

            return obj;
        }

        private T CreateOutsidePoolObject<T>() where T : IPoolObject
        {
            return _objectPoolFactory.CreateObject<T>(GetPrefab<T>(), _poolObjectsHolder);
        }

        private T GetObject<T>() where T : IPoolObject
        {
            if (_poolObjects.ContainsKey(typeof(T)) == false)
                return CreateOutsidePoolObject<T>();

            var objects = _poolObjects[typeof(T)];

            if (objects != null && objects.Count != 0)
                return objects.Pop().GameObject.GetComponent<T>();

            return CreateOutsidePoolObject<T>();
        }

        #endregion
    }
}