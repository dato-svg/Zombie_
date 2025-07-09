using System;
using System.Collections;
using BaseScript.Services;
using UnityEngine;

namespace BaseScript.Enemy
{
    public class EnemyFollow : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private Transform targetTransform;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        private void Start()
        {
            var player = ServiceLocator.Get<PlayerTarget>();
            SetTarget(player.Target);
        }
        
        
        private void FixedUpdate()
        {
            if (targetTransform == null) return;

            Vector2 direction = ((Vector2)targetTransform.position - _rb.position).normalized;
            Vector2 newPosition = _rb.position + direction * moveSpeed * Time.fixedDeltaTime;
            _rb.MovePosition(newPosition);
            SetRotation(targetTransform);
        }
        
        private void SetTarget(Transform target)
        {
            targetTransform = target;
        }

        private void SetRotation(Transform target)
        {
            if (target.transform.position.x > transform.position.x)
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            
            else
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}

