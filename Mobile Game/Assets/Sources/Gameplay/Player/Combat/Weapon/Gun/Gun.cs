using UnityEngine;

public abstract class Gun : Weapon
{
    protected float ProjectileSpeed;

    protected GameObject ProjectilePrefab;

    protected Transform ShootPoint;

    protected Gun(string gunInfoPath) : base(gunInfoPath)
    {
        var gunInfo = Resources.Load(gunInfoPath, typeof(GunInfo)) as GunInfo;
        if (gunInfo == null)
            return;

        ProjectileSpeed = gunInfo.ProjectileSpeed;
        ProjectilePrefab = gunInfo.ProjectilePrefab;

        var playerTransform = Player.Instance.transform;

        ShootPoint = Transform.Instantiate(gunInfo.ShootPoint, playerTransform);
        ShootPoint.parent = playerTransform;
    }

    public override void Attack(Transform target)
    {
        if (ClosestEnemySeeker.DistancesToEnemies[target] > AttackDistance)
            return;

        var playerRotation = Player.Instance.transform.rotation;
        var projectileGO = GameObject.Instantiate(ProjectilePrefab, ShootPoint.position, playerRotation);

        projectileGO.TryGetComponent<Projectile>(out var projectile);
        projectile.Damage = Damage;

        projectileGO.TryGetComponent<Rigidbody>(out var projectileRb);
        var direction = target.position - projectileRb.position;
        var fixedDirection = new Vector3(direction.x, 0, direction.z).normalized;
        projectileRb.AddForce(fixedDirection * ProjectileSpeed, ForceMode.Impulse);
    }
}
