using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    public bool doMove;
    [SerializeField] private float _speed;
    [Range(0.0f, 1.0f)] [SerializeField] private float _stability;
    [Range(0.0f, 1.0f)] [SerializeField] private float _stamina;
    private float _speedRefreshTimeMark;
    private float _staminaRefreshTimeMark;
    private float _speedModified;
    private float _staminaModified;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _speedModified = _speed;
        _staminaModified = _stamina;
    }

    private void FixedUpdate()
    {
        if (doMove)
        {
            RefreshSpeed();
            RefreshStamina();
            Move();
        }
    }

    private void Move()
    {
        // RigidBody 를 가지는 GameObject 의 Transform 을 런타임에 직접 수정하면
        // speed 값과 같은 물리 연산을 다시 수행해야하기 때문에 
        // RigidBody.MovePosition 등을 이용해서 수정해야함.
        // (읽는것은 RigidBody.position 이나 Transform.position 이나 별 차이없음)
        _rb.MovePosition(transform.position + Vector3.forward * _speedModified * Time.fixedDeltaTime);

        //transform.Translate(Vector3.forward * _speedModified * Time.fixedDeltaTime);
    }

    private void RefreshSpeed()
    {
        if (Time.time - _speedRefreshTimeMark > (0.1f / (_staminaModified + 0.001f))) 
        {
            _speedModified = Random.Range(_stability, 1.0f) 
                                        * _speed 
                                        * (_staminaModified / _stamina);
            _speedRefreshTimeMark = Time.time;
        }
    }

    private void RefreshStamina()
    {
        if (Time.time - _staminaRefreshTimeMark > ((_staminaModified + 0.1f) / (1.0f + 0.1f)))
        {
            if (_staminaModified > 0.1f)
                _staminaModified -= 0.01f;
            _staminaRefreshTimeMark = Time.time;
        }
    }
}
