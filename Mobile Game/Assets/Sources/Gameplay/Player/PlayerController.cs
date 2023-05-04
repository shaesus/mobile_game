using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody _rb;

    private bool _isJoystickActive = false;

    private Vector3 _moveDirection;

    private Vector2 _joystickCenter;
    private Vector2 _fingerPoint;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _joystickCenter = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                Camera.main.transform.position.z);
        }

        if (Input.GetMouseButton(0))
        {
            _isJoystickActive = true;
            _fingerPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                Camera.main.transform.position.z);
        }
        else
        {
            _isJoystickActive = false;
        }
    }

    private void FixedUpdate()
    {
        if (_isJoystickActive)
        {
            var offset = _fingerPoint - _joystickCenter;
            _moveDirection = new Vector3(offset.x, 0, offset.y).normalized;
            _rb.MovePosition(_rb.position + _moveDirection * _moveSpeed * Time.fixedDeltaTime);
        }
    }
}
