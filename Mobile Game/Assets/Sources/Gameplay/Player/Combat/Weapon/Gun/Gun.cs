using UnityEngine;

public abstract class Gun : Weapon
{
    public float ProjectileSpeed { get; protected set; }

    public GameObject ProjectilePrefab { get; protected set; }

    public override void Attack(Transform shootPoint, Transform target)
    {
        GameObject.Instantiate(ProjectilePrefab, shootPoint.position, Quaternion.identity)
            .TryGetComponent<Rigidbody>(out var projectileRb);
        var direction = target.position - projectileRb.position;
        var fixedDirection = new Vector3(direction.x, 0, direction.z).normalized;

        projectileRb.AddForce(fixedDirection * ProjectileSpeed, ForceMode.Impulse);
    }
}
