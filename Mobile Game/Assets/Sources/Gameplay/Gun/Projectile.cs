using UnityEditor.SceneManagement;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    private PlayerShooter _playerShooter;

    private void Awake()
    {
        _playerShooter = Player.Instance.GetComponent<PlayerShooter>();

        var boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(0, Player.Instance.GetComponent<CapsuleCollider>().height, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.TakeDamage(_playerShooter.Gun.Damage);
            Destroy(gameObject);
        }
    }
}
