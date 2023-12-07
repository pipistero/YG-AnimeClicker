using PS.ObjectPool.Interfaces;
using UnityEngine;

namespace PS.ObjectPool.Factory
{
    public class ObjectPoolFactory : MonoBehaviour
    {
        public T CreateObject<T>(IPoolObject prefab, Transform holder)
        {
            var createdGameObject = Instantiate(prefab.GameObject, holder);
            
            createdGameObject.SetActive(false);
            
            return createdGameObject.GetComponent<T>();
        }
    }
}