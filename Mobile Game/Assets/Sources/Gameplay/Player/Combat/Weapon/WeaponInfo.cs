using UnityEngine;

public class WeaponInfo : ScriptableObject
{
    [SerializeField] protected float _attackSpeed;
    [SerializeField] protected float _damage;
    [SerializeField] protected float _attackDistance;
    [SerializeField] protected GameObject _weaponModel;
    [SerializeField] protected GameObject _pickupPrefab;
    [SerializeField] protected Transform _attackPoint;

    public float AttackSpeed => _attackSpeed;
    public float Damage => _damage;
    public float AttackDistance => _attackDistance;
    public GameObject WeaponModel => _weaponModel;
    public GameObject PickupPrefab => _pickupPrefab;
    public Transform AttackPoint => _attackPoint;
}

