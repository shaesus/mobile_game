using UnityEngine;

public class Gun
{
    public float ShootCd { get; private set; }
    public float Damage { get; private set; }
    public float ProjectileSpeed { get; private set; }

    private GameObject _projectilePrefab;

    protected PlayerShooter _playerShooter;

    public Gun(float shootCd, float damage, float projectileSpeed, GameObject projectilePrefab, PlayerShooter playerShooter)
    {
        ShootCd = shootCd;
        Damage = damage;
        ProjectileSpeed = projectileSpeed;

        _projectilePrefab = projectilePrefab;

        _playerShooter = playerShooter;
    }

    public void Shoot()
    {
        MonoBehaviour.Instantiate(_projectilePrefab, _playerShooter.ShootPoint.position, Quaternion.identity)
            .TryGetComponent<Rigidbody>(out var projectileRb);
        var direction = _playerShooter.Target.position - projectileRb.position;
        var fixedDirection = new Vector3(direction.x, 0, direction.z);

        projectileRb.AddForce(fixedDirection * ProjectileSpeed, ForceMode.Impulse);
    }
}
