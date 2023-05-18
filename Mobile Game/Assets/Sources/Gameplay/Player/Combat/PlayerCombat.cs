using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float ContactDamage { get { return _contactDamage; } }

    public Weapon CurrentWeapon { get; private set; }

    private PlayerAttacker _attacker;

    private BuffContainer _buffContainer;

    [SerializeField] private float _contactDamage = 20f;

    private void Start()
    {
        _attacker = GetComponent<PlayerAttacker>();

        _buffContainer = new BuffContainer();

        SetWeapon(new Pistol());
    }

    public void SetWeapon(Weapon weapon)
    {
        _attacker.enabled = false;

        if (CurrentWeapon != null)
            CurrentWeapon.DropWeapon();

        CurrentWeapon = weapon;
        Debug.Log($"Weapon is {CurrentWeapon}");
        _attacker.Weapon = CurrentWeapon;

        _attacker.enabled = true;

        _buffContainer.UpdateBuffs();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _buffContainer.AddBuff(new PercentDamageBuff(BuffQuality.Legendary));
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            _buffContainer.RemoveBuff(new PercentDamageBuff(BuffQuality.Legendary));
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            _buffContainer.AddBuff(new PureDamageBuff(BuffQuality.Legendary));
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            _buffContainer.RemoveBuff(new PureDamageBuff(BuffQuality.Legendary));
        }
    }
}
