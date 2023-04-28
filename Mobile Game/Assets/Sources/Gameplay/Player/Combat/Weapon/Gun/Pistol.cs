using UnityEngine;

public class Pistol : Gun
{
    public Pistol()
    {
        var pistolInfo = Resources.Load(@"GunInfos/PistolInfo", typeof(GunInfo)) as GunInfo;
        if (pistolInfo != null)
        {
            AttackSpeed = pistolInfo.AttackSpeed;
            Damage = pistolInfo.Damage;
            ProjectileSpeed = pistolInfo.ProjectileSpeed;
            ProjectilePrefab = pistolInfo.ProjectilePrefab;
        }
    }
}
