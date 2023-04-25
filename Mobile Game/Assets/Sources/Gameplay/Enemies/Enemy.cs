using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public event Action EnemyDie;

    [SerializeField] private float _moveSpeed = 5f;

    [SerializeField] private float _maxHp = 100f;
    private float _currentHp;

    [SerializeField] private float _damage = 30f;

    private Rigidbody _rb;

    private Transform _playerTransform;
    private Vector3 _directionToPlayer;
    private float _distanceToPlayer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _currentHp = _maxHp;

        EnemyDie += () => 
        { 
            if (ClosestEnemySeeker.DistancesToEnemies.ContainsKey(transform))
                ClosestEnemySeeker.DistancesToEnemies.Remove(transform);
        };
    }

    private void Start()
    {
        _playerTransform = Player.Instance.gameObject.transform;
    }

    private void Update()
    {
        _directionToPlayer = _playerTransform.position - transform.position;
        _distanceToPlayer = _directionToPlayer.magnitude;
        ClosestEnemySeeker.DistancesToEnemies[transform] = _distanceToPlayer;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _directionToPlayer.normalized * _moveSpeed * Time.fixedDeltaTime);
    }

    private void Die()
    {
        EnemyDie?.Invoke();

        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        _currentHp -= damage;
        if (_currentHp <= 0) 
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out var player))
        {
            TakeDamage(player.ContactDamage);
            player.TakeDamage(_damage);
        }
    }
}
