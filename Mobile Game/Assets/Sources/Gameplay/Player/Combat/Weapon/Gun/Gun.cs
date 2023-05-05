using UnityEngine;

public abstract class Gun : Weapon
{
    protected float ProjectileSpeed;

    protected GameObject ProjectilePrefab;

    protected Transform ShootPoint;

    protected Gun(string gunInfoPath)
    {
        var gunInfo = Resources.Load(gunInfoPath, typeof(GunInfo)) as GunInfo;
        if (gunInfo != null)
        {
            AttackSpeed = gunInfo.AttackSpeed;
            PureDamage = gunInfo.Damage;
            AttackDistance = gunInfo.AttackDistance;
            ProjectileSpeed = gunInfo.ProjectileSpeed;
            ProjectilePrefab = gunInfo.ProjectilePrefab;
            AdditionalDamagePercents = 0;

            var playerTransform = Player.Instance.transform;

            ShootPoint = Transform.Instantiate(gunInfo.ShootPoint, playerTransform);
            ShootPoint.parent = playerTransform;

            WeaponModel = GameObject.Instantiate(gunInfo.WeaponModel, playerTransform);
            WeaponModel.transform.parent = playerTransform;
        }
    }

    public override void Attack(Transform target)
    {
        if (ClosestEnemySeeker.DistancesToEnemies[target] > AttackDistance)
            return;

        var projectileGO = GameObject.Instantiate(ProjectilePrefab, ShootPoint.position, Quaternion.identity);

        projectileGO.TryGetComponent<Projectile>(out var projectile);
        projectile.Damage = Damage;

        projectileGO.TryGetComponent<Rigidbody>(out var projectileRb);
        var direction = target.position - projectileRb.position;
        var fixedDirection = new Vector3(direction.x, 0, direction.z).normalized;
        projectileRb.AddForce(fixedDirection * ProjectileSpeed, ForceMode.Impulse);
    }
}
