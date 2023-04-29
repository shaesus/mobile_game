using UnityEngine;

public sealed class PureDamageBuff : DamageBuff
{
    private readonly float _additionalDamage;

    public PureDamageBuff(Weapon weapon, BuffQuality quality) : base(weapon, quality)
    {
        if (Quality == BuffQuality.Common)
            _additionalDamage = 1f;
        else if (Quality == BuffQuality.Uncommon)
            _additionalDamage = 2f;
        else if (Quality == BuffQuality.Rare)
            _additionalDamage = 4f;
        else
            _additionalDamage = 8f;
    }

    public override void EnableBuff()
    {
        if (!IsEnabled)
        {
            Weapon.IncreasePureDamage(_additionalDamage);
            IsEnabled = true;
            Debug.Log($"{this} enabled. Weapon damage = {Weapon.Damage}");
        }
    }

    public override void DisableBuff()
    {
        if (IsEnabled)
        {
            Weapon.DecreasePureDamage(_additionalDamage);
            IsEnabled = false;
            Debug.Log($"{this} disabled. Weapon damage = {Weapon.Damage}");
        }
    }

    public override bool Equals(object obj)
    {
        var buff = obj as PureDamageBuff;
        if (buff == null) return false;

        return _additionalDamage == buff._additionalDamage && Quality == buff.Quality;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
