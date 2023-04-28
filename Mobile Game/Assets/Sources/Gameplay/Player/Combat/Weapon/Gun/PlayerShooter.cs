using System.Collections;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Gun Gun { get; set; }

    public Transform ShootPoint => _shootPoint;

    [SerializeField] private Transform _shootPoint;

    private Coroutine _shootingCoroutine;

    private PlayerAimer _playerAimer;

    private void Awake()
    {
        _playerAimer = GetComponent<PlayerAimer>();
    }

    private void OnEnable()
    {
        if (Gun != null)
            _shootingCoroutine = StartCoroutine(StartShooting());
    }

    private void OnDisable()
    {
        if (_shootingCoroutine != null)
            StopCoroutine(_shootingCoroutine);
    }

    private IEnumerator StartShooting()
    {
        while (true)
        {
            if (_playerAimer.FollowTarget != null)
                Gun.Attack(_shootPoint, _playerAimer.FollowTarget);

            yield return new WaitForSeconds(1f / Gun.AttackSpeed);
        }
    }
}
