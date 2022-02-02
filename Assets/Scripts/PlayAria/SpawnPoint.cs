using UnityEngine;

namespace PlayAria
{
    public class SpawnPoint : MonoBehaviour
    {
        public float Delay
        {
            get => _delay;
            set => _delay = value;
        }

        public bool IsSpawnTime => _lastSpawnTime + _delay < Time.time;
    

        private float _lastSpawnTime,_delay;

        public Vector3 GetPosition()
        {
            _lastSpawnTime = Time.time;

            return transform.position;
        }
    }
}