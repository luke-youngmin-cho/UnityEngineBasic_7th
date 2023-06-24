using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool isMovable;
    public bool isDirectionChangeable;

    public const int DIRECTION_RIGHT = 1;
    public const int DIRECTION_LEFT = -1;

    public int direction
    {
        get => _direction;
        set
        {
            if (value < 0)
            {
                transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
                _direction= DIRECTION_LEFT;
            }
            else
            {
                transform.eulerAngles = Vector3.zero;
                _direction= DIRECTION_RIGHT;
            }
        }
    }
    private int _direction;

    public float horizontal
    {
        get => _horizontal;
        set
        {
            if (_horizontal == value)
                return;

            _horizontal = value;
            onHorizontalChanged?.Invoke(value);
        }
    }
    private float _horizontal;
    public event Action<float> onHorizontalChanged;
    [SerializeField] private float _speed = 1.0f;
    private Rigidbody2D _rigidbody;
    private Vector2 _move;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        _move = isMovable ? new Vector2(horizontal, 0.0f) : Vector2.zero;

        if (isDirectionChangeable)
        {
            if (horizontal > 0)
                direction = DIRECTION_RIGHT;
            else if (horizontal < 0)
                direction = DIRECTION_LEFT;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.position += _move * _speed * Time.fixedDeltaTime;
    }
}
