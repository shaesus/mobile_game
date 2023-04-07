public class EnemyRotator : Rotator
{
    private void Start()
    {
        _followTarget = Player.Instance.gameObject.transform;
    }
}
