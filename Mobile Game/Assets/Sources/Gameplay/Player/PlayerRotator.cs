using UnityEngine;

public class PlayerRotator : Rotator
{
    private void Update()
    {
        _followTarget = ClosestEnemySeeker.FindTheClosestEnemy();
    }
}
