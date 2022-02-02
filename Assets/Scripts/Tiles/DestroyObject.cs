using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    /// <summary>
    /// Removing game objects on click
    /// </summary>
    public class DestroyObject : MonoBehaviour
    {
        public event Action OnDead;

        public List<CapsuleCollider2D> Capsule
        {
            get => _capsule;
            set => _capsule = value;
        }

        public float DestroyTime
        {
            get => _destroyTime;
            set => _destroyTime = value;
        }
        [SerializeField] private List<CapsuleCollider2D> _capsule;
        private float _destroyTime;

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            for (int i = 0; i < _capsule.Count; i++)
            {
                _capsule[i].isTrigger = true;
            }

            _spriteRenderer.sortingOrder = 5;
            
            var localScale = gameObject.transform.localScale;
            localScale = Vector3.Lerp(localScale,
                new Vector3(localScale.x + 0.01f, localScale.y + 0.01f), (10 - _destroyTime) * Time.deltaTime);
            gameObject.transform.localScale = localScale;
            
            var color = _spriteRenderer.color;
            _spriteRenderer.color = Color.Lerp(color,new Color(color.r, color.g,color.b,color.a - 0.2f), (10 - _destroyTime) * Time.deltaTime);
            
            if (gameObject.transform.localScale.x > 0.2f)
            {
                OnDead?.Invoke();
                gameObject.SetActive(false);
                enabled = false;
                
            }
        }

        void DestroyObj(RaycastHit2D[] hit)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                var collider = hit[i].collider;

                if (collider.name == gameObject.name && collider.transform.position != gameObject.transform.position)
                {
                    var destroyObj = collider.GetComponent<DestroyObject>();
                    if (destroyObj != null)
                    {
                        // immediately trigger out destruction (must be done before calling down to the
                        // neighbor, to avoid infinite recursion)
                        enabled = true;

                        // propagate destruction to neighbor
                        destroyObj.CheckMatch();
                    }
                }

            }
       
        }

        public void CheckMatch()
        {
            if (enabled) 
            {
                // we are already being destroyed, so nothing more to search
                return;
            }

            var distance = 0.5f;
            var sq3 = Mathf.Sqrt(3);
            var hitRight =     Physics2D.RaycastAll(transform.position, new Vector2( 1,    0), distance);
            var hitLeft =      Physics2D.RaycastAll(transform.position, new Vector2(-1,    0), distance);
            var hitUpRight =   Physics2D.RaycastAll(transform.position, new Vector2( 1,  sq3), distance);
            var hitUpLeft =    Physics2D.RaycastAll(transform.position, new Vector2(-1,  sq3), distance);
            var hitDownLeft =  Physics2D.RaycastAll(transform.position, new Vector2(-1, -sq3), distance);
            var hitDownRight = Physics2D.RaycastAll(transform.position, new Vector2( 1, -sq3), distance);

            DestroyObj(hitLeft);
            DestroyObj(hitUpLeft);
            DestroyObj(hitUpRight);
            DestroyObj(hitRight);
            DestroyObj(hitDownRight);
            DestroyObj(hitDownLeft);
        }

        protected virtual void OnOnDead()
        {
            OnDead?.Invoke();
        }
    }
}
