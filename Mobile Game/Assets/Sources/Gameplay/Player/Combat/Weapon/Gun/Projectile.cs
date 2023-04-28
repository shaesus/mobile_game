using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public float Damage { get; set; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.TakeDamage(Damage);
            Debug.Log($"Enemy took {Damage} damage");
            Destroy(gameObject);
        }
    }
}
