using UnityEngine;

public class Bat : MeleeWeapon
{
    public Bat() : base(@"MeleeWeaponInfos/BatInfo") { }

    public override void Attack(Transform target)
    {
        throw new System.NotImplementedException();
    }
}
