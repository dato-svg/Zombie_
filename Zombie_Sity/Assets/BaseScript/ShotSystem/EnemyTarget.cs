using BaseScript.Component;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BaseScript.ShotSystem
{
    public class EnemyTarget : MonoBehaviour, IEnemyTarget
    {
        public Transform Transform => transform;
        public bool IsAlive => gameObject.activeInHierarchy;
        [field: SerializeField] public Health Health { get; set; }

        [SerializeField] private Image healthBar;
        [SerializeField] private GameObject takeDamageEffect;

        private void Awake()
        {
            Health.OnHealthChanged += UpdateHealthBar;
            Health.OnDamageTaken += ShowDamageEffect;
            Health.Init();
        }

        private void OnEnable()
        {
            EnemyTracker.Register(this);
        }

        private void OnDisable()
        {
            EnemyTracker.Unregister(this);
        }

        private void UpdateHealthBar(float percent)
        {
            if (healthBar != null)
                healthBar.fillAmount = percent;
            
        }
        
        
        private void ShowDamageEffect(int damage)
        {
            if (takeDamageEffect == null) return;

            var effect = Instantiate(takeDamageEffect, transform.GetChild(0));
            var textComponent = effect.GetComponent<TextMeshProUGUI>();

            if (textComponent != null)
                textComponent.text = damage.ToString();

            Destroy(effect, 1.5f);
        }
    }
}