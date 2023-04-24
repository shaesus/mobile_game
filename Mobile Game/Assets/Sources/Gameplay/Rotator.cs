using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rotator : MonoBehaviour
{
    public Transform FollowTarget { get; protected set; }

    protected Rigidbody _rb;

    protected Vector3 _rotationDirection;

    protected float _angleToTarget;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        if (FollowTarget == null) return;

        var unfixedDirection = FollowTarget.position - _rb.position;
        _rotationDirection = new Vector3(unfixedDirection.x, 0, unfixedDirection.z); //Fixed direction

        _angleToTarget = Vector3.Angle(_rotationDirection, Vector3.right);
        if (FollowTarget.position.z > _rb.position.z)
            _angleToTarget *= -1;

        _rb.rotation = Quaternion.Euler(0, _angleToTarget, 0); //Rotating only around Y-axis
    }
}
