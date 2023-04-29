public abstract class DamageBuff : Buff
{
    protected Weapon Weapon;

    public DamageBuff(Weapon weapon, BuffQuality quality) : base(quality)
    {
        Weapon = weapon;
    }
}
