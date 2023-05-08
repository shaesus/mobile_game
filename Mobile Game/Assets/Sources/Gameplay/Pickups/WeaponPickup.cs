using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField] private string _weaponName;

    private PlayerCombat _playerCombat;

    private void Start()
    {
        _playerCombat = Player.Instance.GetComponent<PlayerCombat>();
    }

    protected override void ApplyPickup()
    {
        _playerCombat.SetWeapon(GetWeaponByName(_weaponName));
    }

    private static Weapon GetWeaponByName(string name)
    {
        if (name == "SniperRifle")
            return new SniperRifle();
        else if (name == "Pistol")
            return new Pistol();
        else if (name == "AssaultRifle")
            return new AssaultRifle();
        else if (name == "Knife")
            return new Knife();
        else
            return null;
    }
}
