using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float ContactDamage { get { return _contactDamage; } }

    private Weapon _weapon;

    private PlayerShooter _shooter;

    private BuffContainer _buffContainer;

    [SerializeField] private float _contactDamage = 20f;

    private void Start()
    {
        _shooter = GetComponent<PlayerShooter>();

        _buffContainer = new BuffContainer();

        _weapon = new Spear();
        Debug.Log($"Weapon is {_weapon}");

        if (_weapon is Gun)
        {
            _shooter.Gun = _weapon as AssaultRifle;
            _shooter.enabled = true;
        }
        else
        {
            _shooter.enabled = false;
        }
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
