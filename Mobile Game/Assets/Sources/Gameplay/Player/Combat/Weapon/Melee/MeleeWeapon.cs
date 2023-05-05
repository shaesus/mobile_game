using UnityEditor.PackageManager;
using UnityEngine;

public abstract class MeleeWeapon : Weapon
{
    protected MeleeWeapon(string meleeWeaponInfoPath) 
    {
        var meleeWeaponInfo = Resources.Load(meleeWeaponInfoPath, typeof(MeleeWeaponInfo)) as MeleeWeaponInfo;
        if (meleeWeaponInfo != null)
        {
            AttackSpeed = meleeWeaponInfo.AttackSpeed;
            PureDamage = meleeWeaponInfo.Damage;
            AttackDistance = meleeWeaponInfo.AttackDistance;
            AdditionalDamagePercents = 0;

            var playerTransform = Player.Instance.transform;

            if (meleeWeaponInfo.WeaponModel == null)
                return;//Remove soon

            WeaponModel = GameObject.Instantiate(meleeWeaponInfo.WeaponModel, playerTransform);
            WeaponModel.transform.parent = playerTransform;
        }
    }
}
