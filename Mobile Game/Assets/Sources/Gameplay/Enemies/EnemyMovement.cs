using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody _rb;

    private Transform _playerTransform;
    private Vector3 _directionToPlayer;
    private float _distanceToPlayer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _playerTransform = Player.Instance.gameObject.transform;
    }

    private void Update()
    {
        _directionToPlayer = _playerTransform.position - transform.position;
        _distanceToPlayer = _directionToPlayer.magnitude;
        ClosestEnemySeeker.DistancesToEnemies[transform] = _distanceToPlayer;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _directionToPlayer.normalized * _moveSpeed * Time.fixedDeltaTime);
    }
}
