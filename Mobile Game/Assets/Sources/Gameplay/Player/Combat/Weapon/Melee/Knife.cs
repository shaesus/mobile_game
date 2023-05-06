using UnityEngine;

public class Knife : MeleeWeapon
{
    public Knife() : base(@"MeleeWeaponInfos/KnifeInfo") { }

    public override void Attack(Transform target)
    {
        throw new System.NotImplementedException();
    }
}
