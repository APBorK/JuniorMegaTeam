﻿

namespace ObjectPool
{
    public interface IPooledObject
    {
        PooledObjectType PoolType { get; set; }

        ObjectPooler Pooler { get; }
     
        
        void Construct(ObjectPooler pooler);
        void OnObjectSpawn();
        void OnObjectDespawn();
        void Despawn();
    }
}
