using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public event Action PlayerDie;

    [SerializeField] private float _maxHp = 100f;
    private float _currentHp;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _currentHp = _maxHp;

        PlayerDie += () => Instance = null;
    }

    private void Die()
    {
        PlayerDie?.Invoke();

        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        _currentHp -= damage;
        if (_currentHp <= 0)
            Die();
    }
}
