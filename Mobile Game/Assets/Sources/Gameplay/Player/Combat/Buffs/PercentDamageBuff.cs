using UnityEngine;

public sealed class PercentDamageBuff : DamageBuff
{
    private readonly float _additionalDamagePercent;

    public PercentDamageBuff(BuffQuality quality) : base(quality)
    {
        if (Quality == BuffQuality.Common)
            _additionalDamagePercent = 5f;
        else if (Quality == BuffQuality.Uncommon)
            _additionalDamagePercent = 10f;
        else if (Quality == BuffQuality.Rare)
            _additionalDamagePercent = 20f;
        else
            _additionalDamagePercent = 40f;
    }

    public override void EnableBuff()
    {
        if (IsEnabled) 
            return;

        Weapon.IncreaseDamagePercents(_additionalDamagePercent);
        IsEnabled = true;
        Debug.Log($"{this} enabled. Weapon damage = {Weapon.Damage}");
    }

    public override void DisableBuff() 
    {
        if (!IsEnabled)
            return;

        Weapon.DecreaseDamagePercents(_additionalDamagePercent);
        IsEnabled = false;
        Debug.Log($"{this} disabled. Weapon damage = {Weapon.Damage}");
    }

    public override bool Equals(object obj)
    {
        var buff = obj as PercentDamageBuff;
        if (buff == null) return false;

        return _additionalDamagePercent == buff._additionalDamagePercent && Quality == buff.Quality;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
