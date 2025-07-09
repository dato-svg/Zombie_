using System;
using UnityEngine;

namespace BaseScript.Component
{
    [Serializable]
    public class Health
    {
        [field: SerializeField] public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }

        public Action Died;
        public Action<float> OnHealthChanged;
        public Action<int> OnDamageTaken;

        public Health()
        {
            CurrentHealth = MaxHealth;
        }

        public void TakeDamage(int amount)
        {
            CurrentHealth -= amount;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
            
            OnHealthChanged?.Invoke((float)CurrentHealth / MaxHealth);
            OnDamageTaken?.Invoke(amount);

            if (CurrentHealth <= 0)
            {
                Died?.Invoke();
            }
        }
        
        public void Init()
        {
            CurrentHealth = MaxHealth;
            OnHealthChanged?.Invoke(1f);
        }
    }
}