using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;

    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        transform.position = _followTarget.position + _offset;
    }
}
