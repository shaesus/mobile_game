using UnityEngine;

public sealed class AssaultRifle : Gun
{
    public AssaultRifle()
    {
        var assaultRifleInfo = Resources.Load(@"GunInfos/AssaultRifleInfo", typeof(GunInfo)) as GunInfo;
        if (assaultRifleInfo != null)
        {
            AttackSpeed = assaultRifleInfo.AttackSpeed;
            PureDamage = assaultRifleInfo.Damage;
            ProjectileSpeed = assaultRifleInfo.ProjectileSpeed;
            ProjectilePrefab = assaultRifleInfo.ProjectilePrefab;

            AdditionalDamagePercents = 0;
        }
    }
}
