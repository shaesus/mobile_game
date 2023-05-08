using UnityEngine;

public class Knife : MeleeWeapon
{
    public Knife() : base(@"MeleeWeaponInfos/KnifeInfo") { }

    public override void Attack(Transform target)
    {
        var overlappedEnemies = Physics.OverlapSphere(AttackPoint.position, AttackDistance, EnemyLayers);
        foreach(var enemy in overlappedEnemies)
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
