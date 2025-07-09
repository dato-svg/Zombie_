using BaseScript.Component;
using UnityEngine;

namespace BaseScript.ShotSystem
{
    public interface IEnemyTarget
    {
        Transform Transform { get; }
        bool IsAlive { get; }
        Health  Health { get; set; }
    }
}