using System.Linq;
using BaseScript.ShotSystem;
using UnityEngine;

namespace BaseScript.Weapon
{
    public class WeaponAim : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;

        private void Update()
        {
            var nearest = GetNearestEnemy();
            if (nearest != null)
            {
                Vector2 direction = nearest.Transform.position - playerTransform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
        
        private IEnemyTarget GetNearestEnemy()
        {
            return EnemyTracker.Enemies
                .Where(e => e != null && e.IsAlive)
                .OrderBy(e => Vector2.Distance(playerTransform.position, e.Transform.position))
                .FirstOrDefault();
        }
    }
}