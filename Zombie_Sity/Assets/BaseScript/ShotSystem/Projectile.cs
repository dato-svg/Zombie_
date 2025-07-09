using UnityEngine;

namespace BaseScript.ShotSystem
{
    public class Projectile : MonoBehaviour
    {
       [SerializeField] public int damage;
      
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<IEnemyTarget>(out var enemy))
            {
              var health = enemy.Health;
              health.Died += () => Destroy(enemy.Transform.gameObject);
              enemy.Health.TakeDamage(damage);
              Destroy(gameObject);
            }
        }

        private void Start() => 
            Destroy(gameObject, 5f);

        
    }
}