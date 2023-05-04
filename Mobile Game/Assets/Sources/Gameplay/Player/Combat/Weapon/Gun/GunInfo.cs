using UnityEngine;

[CreateAssetMenu(fileName = "GunInfo")]
public class GunInfo : ScriptableObject
{
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private GameObject _gunModel;
    [SerializeField] private Transform _shootPoint;

    public float AttackSpeed => _attackSpeed;
    public float Damage => _damage;
    public float ProjectileSpeed => _projectileSpeed;
    public GameObject ProjectilePrefab => _projectilePrefab;
    public GameObject GunModel => _gunModel;
    public Transform ShootPoint => _shootPoint;
}
