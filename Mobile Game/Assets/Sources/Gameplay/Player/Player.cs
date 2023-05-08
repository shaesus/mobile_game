using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public event Action PlayerDied;
    public event Action PlayerTookDamage;

    [SerializeField] private float _maxHp = 100f;
    private float _currentHp;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _currentHp = _maxHp;

        PlayerDied += () => Instance = null;
    }

    private void Die()
    {
        PlayerDied?.Invoke();

        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        _currentHp -= damage;
        PlayerTookDamage?.Invoke();

        if (_currentHp <= 0)
            Die();
    }
}
