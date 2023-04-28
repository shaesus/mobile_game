using UnityEngine;

public abstract class Weapon
{
    public float AttackSpeed { get; protected set; }
    public float Damage { get; protected set; }

    public abstract void Attack(Transform attackPoint, Transform target);
}
