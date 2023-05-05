using UnityEngine;

[CreateAssetMenu(fileName = "GunInfo", menuName = "WeaponInfos/GunInfo")]
public class GunInfo : WeaponInfo
{
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _shootPoint;

    public float ProjectileSpeed => _projectileSpeed;
    public GameObject ProjectilePrefab => _projectilePrefab;
    public Transform ShootPoint => _shootPoint;
}
