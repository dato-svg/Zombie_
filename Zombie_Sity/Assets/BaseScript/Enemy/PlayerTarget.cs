using UnityEngine;

namespace BaseScript.Enemy
{
    public class PlayerTarget : MonoBehaviour, ITargetProvider
    {
        public Transform Target => transform;
    }
}
