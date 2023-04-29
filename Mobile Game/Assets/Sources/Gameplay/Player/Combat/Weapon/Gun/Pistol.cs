using UnityEngine;

public sealed class Pistol : Gun
{
    public Pistol()
    {
        var pistolInfo = Resources.Load(@"GunInfos/PistolInfo", typeof(GunInfo)) as GunInfo;
        if (pistolInfo != null)
        {
            AttackSpeed = pistolInfo.AttackSpeed;
            PureDamage = pistolInfo.Damage;
            ProjectileSpeed = pistolInfo.ProjectileSpeed;
            ProjectilePrefab = pistolInfo.ProjectilePrefab;

            AdditionalDamagePercents = 0;
        }
    }
}
