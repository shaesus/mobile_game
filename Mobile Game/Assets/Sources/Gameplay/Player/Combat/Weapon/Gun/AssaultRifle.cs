using UnityEngine;

public class AssaultRifle : Gun
{
    public AssaultRifle()
    {
        var assaultRifleInfo = Resources.Load(@"GunInfos/AssaultRifleInfo", typeof(GunInfo)) as GunInfo;
        if (assaultRifleInfo != null)
        {
            AttackSpeed = assaultRifleInfo.AttackSpeed;
            Damage = assaultRifleInfo.Damage;
            ProjectileSpeed = assaultRifleInfo.ProjectileSpeed;
            ProjectilePrefab = assaultRifleInfo.ProjectilePrefab;
        }
    }
}
