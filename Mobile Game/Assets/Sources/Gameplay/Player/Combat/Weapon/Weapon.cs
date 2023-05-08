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

    protected GameObject PickupPrefab;

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

        PickupPrefab = weaponInfo.PickupPrefab;
    }

    public abstract void Attack(Transform target);

    public void DropWeapon()
    {
        var playerTransform = Player.Instance.transform;
        var pickupPos = new Vector3(playerTransform.position.x, PickupPrefab.transform.position.y,
            playerTransform.position.z) + playerTransform.right * 2;

        GameObject.Instantiate(PickupPrefab, pickupPos, Quaternion.identity);

        GameObject.Destroy(WeaponModel);
        GameObject.Destroy(AttackPoint.gameObject);
    }

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
