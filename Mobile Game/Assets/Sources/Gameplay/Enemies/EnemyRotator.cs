public class EnemyRotator : Rotator
{
    private void Start()
    {
        FollowTarget = Player.Instance.gameObject.transform;
    }
}
