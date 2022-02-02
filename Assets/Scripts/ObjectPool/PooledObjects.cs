using UnityEngine;

namespace ObjectPool
{
    [System.Serializable]
    public class PoolObjects
    {
        public PooledObjectType Tag;
        public GameObject Prefab;
        public int Size;
    }
}
