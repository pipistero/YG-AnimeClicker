using System;
using UnityEngine;

namespace PS.ObjectPool.Interfaces
{
    public interface IPoolObject
    {
        GameObject GameObject { get; }
        Type Type { get; }
        
        void OnGetFromPool();
        void OnReturnToPool();
    }
}