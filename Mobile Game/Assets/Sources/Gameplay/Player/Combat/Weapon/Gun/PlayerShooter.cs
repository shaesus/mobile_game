using System.Collections;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Gun Gun { get; set; }

    public Transform ShootPoint => _shootPoint;
    public Transform Target { get; private set; }

    [SerializeField] private Transform _shootPoint;

    private Coroutine _shootingCoroutine;

    private void OnEnable()
    {
        if (Gun != null)
            _shootingCoroutine = StartCoroutine(StartShooting());
    }

    private void OnDisable()
    {
        StopCoroutine(_shootingCoroutine);
    }

    private void Update()
    {
        if (enabled == false)
            return;

        Target = ClosestEnemySeeker.FindTheClosestEnemy();
    }

    private IEnumerator StartShooting()
    {
        while (true)
        {
            if (Target != null)
                Gun.Attack(_shootPoint, Target);

            yield return new WaitForSeconds(Gun.AttackSpeed);
        }
    }
}
