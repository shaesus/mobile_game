using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public abstract class Pickup : MonoBehaviour
{
    protected abstract void ApplyPickup();

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            ApplyPickup();
            Destroy(gameObject);
        }
    }
}
