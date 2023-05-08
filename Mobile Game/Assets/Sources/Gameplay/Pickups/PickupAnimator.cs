using UnityEngine;

public class PickupAnimator : MonoBehaviour
{
    [SerializeField] private float _amplitude = 1f;
    [SerializeField] private float _rotationAngle = 1f;

    private float _time;
    private float _startY;

    private void Awake()
    {
        _time = 0f;

        _startY = transform.position.y;
    }

    private void Update()
    {
        var yOffset = Mathf.Sin(_time) * _amplitude;

        transform.SetYPos(_startY + yOffset);

        transform.Rotate(transform.up, _rotationAngle);

        _time += Time.deltaTime;
    }
}
