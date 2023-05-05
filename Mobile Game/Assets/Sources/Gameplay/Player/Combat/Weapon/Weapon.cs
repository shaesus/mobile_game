using UnityEngine;

public abstract class Weapon
{
    public float AttackSpeed { get; protected set; }

    public float Damage => PureDamage * (1 + AdditionalDamagePercents / 100);

    protected float PureDamage;
    protected float AdditionalDamagePercents;

    protected float AttackDistance;

    protected GameObject WeaponModel;

    public abstract void Attack(Transform target);

    public void IncreaseDamagePercents(float percent)
    {
        AdditionalDamagePercents += percent;
    }

    public void DecreaseDamagePercents(float percent) 
    {  
        AdditionalDamagePercents -= percent;
    }

    public void IncreasePureDamage(float damage)
    {
        PureDamage += damage;
    }

    public void DecreasePureDamage(float damage)
    {
        PureDamage -= damage;
    }
}
