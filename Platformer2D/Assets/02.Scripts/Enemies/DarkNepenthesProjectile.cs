using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DarkNepenthesProjectile : MonoBehaviour
{
    private GameObject owner;
    private Vector2 velocity;
    private float damage;
    private LayerMask targetMask;

    public void SetUp(GameObject owner, Vector2 velocity, float damage, LayerMask targetMask)
    {
        this.owner = owner;
        this.velocity = velocity;
        this.damage = damage;
        this.targetMask = targetMask;
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)velocity * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & targetMask) > 0)
        {
            if (collision.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(owner, damage);
            }
        }
    }
}
