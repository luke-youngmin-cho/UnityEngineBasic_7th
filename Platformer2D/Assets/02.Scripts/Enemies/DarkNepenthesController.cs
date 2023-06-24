using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkNepenthesController : EnemyController
{
    [SerializeField] private float _attackPower;
    [SerializeField] private DarkNepenthesProjectile _projectilePrefab;
    [SerializeField] private float _projectileSpeed = 3.0f;

    protected override void Hit()
    {
        base.Hit();
        Instantiate(_projectilePrefab,
                        transform.position + new Vector3(direction * 0.1f, 0.2f, 0.0f),
                        Quaternion.identity)
            .SetUp(gameObject,
                        new Vector2(direction * _projectileSpeed, 0.0f),
                        _attackPower,
                        aiDetectMask);
    }
}
