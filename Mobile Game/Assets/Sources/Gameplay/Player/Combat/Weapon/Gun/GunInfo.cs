using UnityEngine;

[CreateAssetMenu(fileName = "GunInfo")]
public class GunInfo : ScriptableObject
{
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private GameObject _projectilePrefab;

    public float AttackSpeed => _attackSpeed;
    public float Damage => _damage;
    public float ProjectileSpeed => _projectileSpeed;
    public GameObject ProjectilePrefab => _projectilePrefab;
}
