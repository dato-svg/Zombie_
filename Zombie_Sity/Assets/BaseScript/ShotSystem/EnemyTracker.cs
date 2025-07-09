using System.Collections.Generic;
using UnityEngine;

namespace BaseScript.ShotSystem
{
    public class EnemyTracker : MonoBehaviour
    {
        public static readonly List<IEnemyTarget> Enemies = new();

        public static void Register(IEnemyTarget enemy)
        {
            if (!Enemies.Contains(enemy))
                Enemies.Add(enemy);
        }

        public static void Unregister(IEnemyTarget enemy)
        {
            Enemies.Remove(enemy);
        }
    }
}