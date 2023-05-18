public enum BuffQuality
{
    Common, 
    Uncommon,
    Rare,
    Epic,
    Legendary
}

public abstract class Buff
{
    public readonly BuffQuality Quality;

    public bool IsEnabled { get; protected set; }

    public Buff(BuffQuality quality)
    {
        Quality = quality;

        IsEnabled = false;
    }

    public abstract void EnableBuff();
    public abstract void DisableBuff();
    public abstract void UpdateBuff();

    public override string ToString()
    {
        return GetType().Name + ": " + Quality.ToString();
    }
}
