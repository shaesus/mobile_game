public abstract class DamageBuff : Buff
{
    protected Weapon Weapon;

    protected PlayerCombat PlayerCombat;

    public DamageBuff(BuffQuality quality) : base(quality)
    {
        PlayerCombat = Player.Instance.GetComponent<PlayerCombat>();
        Weapon = PlayerCombat.CurrentWeapon;
    }

    public override void UpdateBuff()
    {
        if (Weapon == PlayerCombat.CurrentWeapon)
            return;

        Weapon = PlayerCombat.CurrentWeapon;
        IsEnabled = false;
        EnableBuff();
    }
}
