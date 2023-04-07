using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rotator : MonoBehaviour
{
    protected Transform _followTarget;

    protected Rigidbody _rb;

    protected Vector3 _rotationDirection;

    protected float _angleToTarget;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        if (_followTarget == null) return;

        var unfixedDirection = _followTarget.position - _rb.position;
        _rotationDirection = new Vector3(unfixedDirection.x, 0, unfixedDirection.z); //Fixed direction

        _angleToTarget = Vector3.Angle(_rotationDirection, Vector3.right);
        if (_followTarget.position.z > _rb.position.z)
            _angleToTarget *= -1;

        _rb.rotation = Quaternion.Euler(0, _angleToTarget, 0); //Rotating only around Y-axis
    }
}
