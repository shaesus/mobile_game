using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float ContactDamage { get { return _contactDamage; } }

    private Weapon _weapon;

    private PlayerShooter _shooter;

    [SerializeField] private float _contactDamage = 20f;

    private void Awake()
    {
        _shooter = GetComponent<PlayerShooter>();

        _weapon = new Pistol();

        if (_weapon is Gun)
        {
            _shooter.Gun = _weapon as Pistol;
            _shooter.enabled = true;
        }
        else
            _shooter.enabled = false;
    }
}
