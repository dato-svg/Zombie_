using UnityEngine;

namespace BaseScript.Component
{
    public class MoverUp : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 2f;

        private Vector2 _moveDirection;

        private void Start()
        {
            float xDirection = Random.value < 0.5f ? -3f : 3f;
            float yDirection = Random.value < 0.5f ? 1f : 3f;
            
            _moveDirection = new Vector2(xDirection, yDirection).normalized;
        }

        private void Update()
        {
            transform.Translate(_moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}