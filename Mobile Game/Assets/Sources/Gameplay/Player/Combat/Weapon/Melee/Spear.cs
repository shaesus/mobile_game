using UnityEngine;

public class Spear : MeleeWeapon
{
    public Spear() : base(@"MeleeWeaponInfos/SpearInfo") { }

    public override void Attack(Transform target)
    {
        throw new System.NotImplementedException();
    }
}
