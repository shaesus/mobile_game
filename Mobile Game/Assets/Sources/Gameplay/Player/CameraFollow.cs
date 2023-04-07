using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;

    private Vector3 _offset;

    private void Awake()
    {
        _offset = transform.position;
    }

    private void LateUpdate()
    {
        transform.position = _followTarget.position + _offset;
    }
}
