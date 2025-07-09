using BaseScript.Enemy;
using UnityEngine;

namespace BaseScript.Services
{
    public class PlayerRegister : MonoBehaviour
    {
        [SerializeField] private PlayerTarget target;
        private void Awake()
        {
            if (target != null)
                ServiceLocator.Register<PlayerTarget>(target);
            
            else
                Debug.LogError("На объекте отсутствует компонент PlayerTarget!");
        }
    }
}