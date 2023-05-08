using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public event Action EnemyDie;

    [SerializeField] private float _maxHp = 100f;
    private float _currentHp;

    [SerializeField] private float _damage = 30f;

    private void Awake()
    {
        _currentHp = _maxHp;

        EnemyDie += () => 
        { 
            if (ClosestEnemySeeker.DistancesToEnemies.ContainsKey(transform))
                ClosestEnemySeeker.DistancesToEnemies.Remove(transform);
        };
    }

    private void Die()
    {
        EnemyDie?.Invoke();

        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        _currentHp -= damage;
        Debug.Log($"Enemy took {damage} damage");

        if (_currentHp <= 0) 
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerCombat>(out var playerCombat))
        {
            TakeDamage(playerCombat.ContactDamage);
            Player.Instance.TakeDamage(_damage);
        }
    }
}
