public class PlayerAimer : Rotator
{
    private void Update()
    {
        FollowTarget = ClosestEnemySeeker.FindTheClosestEnemy();
    }
}
