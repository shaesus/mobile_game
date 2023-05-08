using UnityEngine;

public abstract class MeleeWeapon : Weapon
{
    public float AttackAngle { get; protected set; }

    protected LayerMask EnemyLayers;

    protected float KnockbackForce;

    protected MeleeWeapon(string meleeWeaponInfoPath) : base(meleeWeaponInfoPath)
    {
        var weaponInfo = Resources.Load(meleeWeaponInfoPath, typeof(MeleeWeaponInfo)) as MeleeWeaponInfo;
        if (weaponInfo == null)
            return;

        EnemyLayers = weaponInfo.EnemyLayers;
        KnockbackForce = weaponInfo.KnockbackForce;
        AttackAngle = weaponInfo.AttackAngle;
    }

    public override void Attack(Transform target)
    {
        var overlappedEnemies = Physics.OverlapSphere(AttackPoint.position, AttackDistance, EnemyLayers);
        foreach (var enemy in overlappedEnemies)
        {
            var enemyRb = enemy.GetComponent<Rigidbody>();

            var directionToEnemy = enemyRb.position - Player.Instance.transform.position;
            var fixedDirection = new Vector3(directionToEnemy.x, 0, directionToEnemy.z).normalized;

            var angleToEnemy = Vector3.Angle(Player.Instance.transform.right, fixedDirection);
            //Debug.Log(angleToEnemy);
            if (Mathf.Abs(angleToEnemy) > AttackAngle)
                return;

            enemyRb.AddForce(enemyRb.mass * KnockbackForce * fixedDirection, ForceMode.Impulse);
            enemy.GetComponent<Enemy>().TakeDamage(Damage);
        }
    }
}
