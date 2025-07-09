using System.Collections;
using System.Linq;
using BaseScript.Weapon;
using UnityEngine;
using UnityEngine.UI;

namespace BaseScript.ShotSystem
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform firePoint;
        [SerializeField] private float shootInterval = 0.5f;
        
        [SerializeField] private float bulletSpeed = 15f;
        [SerializeField] private int bulletDamage = 10;
        
        [SerializeField] private float activeShootingDuration = 5f;
        [SerializeField] private float cooldownDuration = 3f;
        
        [SerializeField] private bool isTurret = false;
        [SerializeField] private WeaponAim weaponAim;
        [SerializeField] private Image sliderImage;
        
        [SerializeField] private GameObject effect;
        
        private void Start()
        {
            effect = transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
            if (sliderImage != null)
                sliderImage.fillAmount = 0f;

            StartCoroutine(ShootingCycle());
        }

        private IEnumerator ShootingCycle()
        {
            while (true)
            {
                float activeTime = 0f;
                
                while (activeTime < activeShootingDuration)
                {
                    var nearest = GetNearestEnemy();
                    if (nearest != null)
                        Shoot(nearest.Transform.position);

                    yield return new WaitForSeconds(shootInterval);
                    activeTime += shootInterval;
                }
                
                if (isTurret)
                    weaponAim.enabled = false;

                if (sliderImage != null)
                    StartCoroutine(FillSliderOverTime(cooldownDuration));

                yield return new WaitForSeconds(cooldownDuration);
                
                if (isTurret)
                    weaponAim.enabled = true;
            }
        }

        private IEnumerator FillSliderOverTime(float duration)
        {
            float elapsed = 0f;
            sliderImage.fillAmount = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                sliderImage.fillAmount = Mathf.Clamp01(elapsed / duration);
                yield return null;
            }

            sliderImage.fillAmount = 0f;
        }

        private IEnemyTarget GetNearestEnemy()
        {
            var enemies = EnemyTracker.Enemies
                .Where(e => e != null && e.IsAlive)
                .ToList();

            if (enemies.Count == 0) return null;

            return enemies
                .OrderBy(e => Vector2.Distance(transform.position, e.Transform.position))
                .FirstOrDefault();
        }
        
        private void Shoot(Vector2 targetPosition)
        {
            var projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().damage = bulletDamage;

            var direction = (targetPosition - (Vector2)firePoint.position).normalized;
            projectile.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;

            if (effect != null)
                StartCoroutine(PlayShootEffect());
        }

        private IEnumerator PlayShootEffect()
        {
            effect.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            effect.SetActive(false);
        }
    }
}
