using UnityEngine;

namespace ObjectPool
{
    public sealed class PooledObject : MonoBehaviour, IPooledObject
    {

        public PooledObjectType PoolType { get; set; }
        public ObjectPooler Pooler { get; private set; }
        
        public void Construct(ObjectPooler pooler)
        {
            Pooler = pooler;
        }
    
        public void OnObjectSpawn()
        {

        }

        public void OnObjectDespawn()
        {

        }

        public void Despawn()
        {
            Pooler.Despawn(gameObject);
        }


    }
}
