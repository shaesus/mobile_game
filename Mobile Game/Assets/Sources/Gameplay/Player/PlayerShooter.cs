using System.Collections;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Gun Gun { get; private set; }

    public Transform ShootPoint { get { return _shootPoint; } }
    public Transform Target { get; private set; }

    [SerializeField] private GameObject _projectilePrefab;

    [SerializeField] private float _gunShootCd = 1;
    [SerializeField] private float _gunDamage = 15;
    [SerializeField] private float _gunProjectileSpeed = 5f;

    [SerializeField] private Transform _shootPoint;

    private void Start()
    {
        Gun = new Gun(_gunShootCd, _gunDamage, _gunProjectileSpeed, _projectilePrefab, this);

        StartCoroutine(StartShooting());
    }

    private void Update()
    {
        Target = ClosestEnemySeeker.FindTheClosestEnemy();
    }

    private IEnumerator StartShooting()
    {
        while (true)
        {
            if (Target != null)
                Gun.Shoot();

            yield return new WaitForSeconds(Gun.ShootCd);
        }
    }
}
