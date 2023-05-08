using UnityEngine;

public abstract class Weapon
{
    public float AttackSpeed { get; protected set; }

    public float Damage => PureDamage * (1 + AdditionalDamagePercents / 100);
    public Transform AttackPoint { get; protected set; }
    public float AttackDistance { get; protected set; }

    protected float PureDamage;
    protected float AdditionalDamagePercents;

    protected GameObject WeaponModel;

    protected Weapon(string weaponInfoPath)
    {
        var weaponInfo = Resources.Load(weaponInfoPath, typeof(WeaponInfo)) as WeaponInfo;
        if (weaponInfo == null)
            return;

        AttackSpeed = weaponInfo.AttackSpeed;
        PureDamage = weaponInfo.Damage;
        AttackDistance = weaponInfo.AttackDistance;
        AdditionalDamagePercents = 0;

        var playerTransform = Player.Instance.transform;

        WeaponModel = GameObject.Instantiate(weaponInfo.WeaponModel, playerTransform);
        WeaponModel.transform.parent = playerTransform;

        AttackPoint = Transform.Instantiate(weaponInfo.AttackPoint, playerTransform);
        AttackPoint.parent = playerTransform;
    }

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
