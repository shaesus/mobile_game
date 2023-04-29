using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rotator : MonoBehaviour
{
    public Transform FollowTarget { get; protected set; }

    protected Rigidbody Rb;

    protected Vector3 RotationDirection;

    protected float AngleToTarget;

    protected virtual void Awake()
    {
        Rb = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        if (FollowTarget == null) 
            return;

        var unfixedDirection = FollowTarget.position - Rb.position;
        RotationDirection = new Vector3(unfixedDirection.x, 0, unfixedDirection.z); //Fixed direction

        AngleToTarget = Vector3.Angle(RotationDirection, Vector3.right);
        if (FollowTarget.position.z > Rb.position.z)
            AngleToTarget *= -1;

        Rb.rotation = Quaternion.Euler(0, AngleToTarget, 0); //Rotating only around Y-axis
    }
}
