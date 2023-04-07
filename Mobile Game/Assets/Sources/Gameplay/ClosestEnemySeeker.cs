using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ClosestEnemySeeker
{
    public static Dictionary<Transform, float> DistancesToEnemies = new Dictionary<Transform, float>();

    public static Transform FindTheClosestEnemy()
    {
        if (DistancesToEnemies.Count != 0)
            return DistancesToEnemies.KeyByValue(DistancesToEnemies.Values.Min());
        else return null;
    }
}
