public class PlayerRotator : Rotator
{
    private PlayerShooter _playerShooter;

    private void Start()
    {
        _playerShooter = Player.Instance.GetComponent<PlayerShooter>();
    }

    private void Update()
    {
        FollowTarget = _playerShooter.Target;
    }
}
