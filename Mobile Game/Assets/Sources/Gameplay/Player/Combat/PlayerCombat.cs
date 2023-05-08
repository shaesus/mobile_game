using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float ContactDamage { get { return _contactDamage; } }

    private Weapon _weapon;

    private PlayerAttacker _attacker;

    private BuffContainer _buffContainer;

    [SerializeField] private float _contactDamage = 20f;

    private void Start()
    {
        _attacker = GetComponent<PlayerAttacker>();

        _buffContainer = new BuffContainer();

        _weapon = new Pistol();
        Debug.Log($"Weapon is {_weapon}");
        _attacker.Weapon = _weapon;
        _attacker.enabled = true;
    }

    public void SetWeapon(Weapon weapon)
    {
        _attacker.enabled = false;

        _weapon.DropWeapon();
        _weapon = weapon;
        _attacker.Weapon = _weapon;

        _attacker.enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _buffContainer.AddBuff(new PercentDamageBuff(_weapon, BuffQuality.Legendary));
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            _buffContainer.RemoveBuff(new PercentDamageBuff(_weapon, BuffQuality.Legendary));
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            _buffContainer.AddBuff(new PureDamageBuff(_weapon, BuffQuality.Legendary));
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            _buffContainer.RemoveBuff(new PureDamageBuff(_weapon, BuffQuality.Legendary));
        }
    }
}
