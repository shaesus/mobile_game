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

        var distanceToTarget = ClosestEnemySeeker.DistancesToEnemies[FollowTarget];

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right * distanceToTarget);

        //Debug.Log($"Distance to target: {distanceToTarget}");
    }
}
