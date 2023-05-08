using UnityEngine;

public class WeaponInfo : ScriptableObject
{
    [SerializeField] protected float _attackSpeed;
    [SerializeField] protected float _damage;
    [SerializeField] protected float _attackDistance;
    [SerializeField] protected GameObject _weaponModel;
    [SerializeField] private Transform _attackPoint;

    public float AttackSpeed => _attackSpeed;
    public float Damage => _damage;
    public float AttackDistance => _attackDistance;
    public GameObject WeaponModel => _weaponModel;
    public Transform AttackPoint => _attackPoint;
}

