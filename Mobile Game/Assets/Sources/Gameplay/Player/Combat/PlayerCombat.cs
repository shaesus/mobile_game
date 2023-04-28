using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float ContactDamage { get { return _contactDamage; } }

    private Weapon _weapon;

    private PlayerShooter _shooter;

    private BuffContainer _buffContainer;

    [SerializeField] private float _contactDamage = 20f;

    private void Awake()
    {
        _shooter = GetComponent<PlayerShooter>();

        _buffContainer = new BuffContainer();

        _weapon = new AssaultRifle();

        if (_weapon is Gun)
        {
            _shooter.Gun = _weapon as AssaultRifle;
            _shooter.enabled = true;
        }
        else
            _shooter.enabled = false;
    }
}
