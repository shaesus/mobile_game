using System.Collections;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    public Weapon Weapon { get; set; }

    private Coroutine _attackingCoroutine;

    private PlayerAimer _playerAimer;

    private void Awake()
    {
        _playerAimer = GetComponent<PlayerAimer>();
    }

    private void OnEnable()
    {
        if (Weapon != null)
            _attackingCoroutine = StartCoroutine(StartShooting());
    }

    private void OnDisable()
    {
        if (_attackingCoroutine != null)
            StopCoroutine(_attackingCoroutine);
    }

    private IEnumerator StartShooting()
    {
        while (true)
        {
            if (_playerAimer.FollowTarget != null)
                Weapon.Attack(_playerAimer.FollowTarget);

            //Debug.Log($"{Weapon} attacked");

            yield return new WaitForSeconds(1f / Weapon.AttackSpeed);
        }
    }

    private void OnDrawGizmos()
    {
        if (Weapon == null)
            return;

        if (Weapon is MeleeWeapon)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(Weapon.AttackPoint.position, Weapon.AttackDistance);
        }
    }
}
