using UnityEngine;

public class PlayerAimer : Rotator
{
    private void Update()
    {
        FollowTarget = ClosestEnemySeeker.FindTheClosestEnemy();
    }

    private void OnDrawGizmos()
    {
        if (FollowTarget == null) 
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right * ClosestEnemySeeker.DistancesToEnemies[FollowTarget]);
    }
}
