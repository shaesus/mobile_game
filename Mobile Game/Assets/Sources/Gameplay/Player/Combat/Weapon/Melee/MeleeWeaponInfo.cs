using UnityEngine;

[CreateAssetMenu(fileName = "MeleeWeaponInfo", menuName = "WeaponInfos/MeleeWeaponInfo")]
public class MeleeWeaponInfo : WeaponInfo
{
    [SerializeField] private LayerMask _enemyLayers;

    [SerializeField] private float _knockbackForce;
    [SerializeField] private float _attackAngle;

    public LayerMask EnemyLayers => _enemyLayers;
    public float KnockbackForce => _knockbackForce;
    public float AttackAngle => _attackAngle;
}

