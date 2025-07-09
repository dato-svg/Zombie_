using UnityEngine;

namespace BaseScript.Enemy
{
    public interface ITargetProvider
    {
        Transform Target { get; }
    }
}
