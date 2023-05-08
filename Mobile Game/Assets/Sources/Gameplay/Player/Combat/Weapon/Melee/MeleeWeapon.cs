using UnityEngine;

public abstract class MeleeWeapon : Weapon
{
    protected LayerMask EnemyLayers;

    protected float KnockbackForce;
    protected float AttackAngle;

    protected MeleeWeapon(string meleeWeaponInfoPath) : base(meleeWeaponInfoPath)
    {
        var weaponInfo = Resources.Load(meleeWeaponInfoPath, typeof(MeleeWeaponInfo)) as MeleeWeaponInfo;
        if (weaponInfo == null)
            return;

        EnemyLayers = weaponInfo.EnemyLayers;
        KnockbackForce = weaponInfo.KnockbackForce;
        AttackAngle = weaponInfo.AttackAngle;
    }
}
