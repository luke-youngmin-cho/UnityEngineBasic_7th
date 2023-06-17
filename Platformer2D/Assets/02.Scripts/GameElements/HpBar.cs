using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Slider _hp;

    public static HpBar Create(IDamageable damageable, IDirectionChangeable directionChangeable, Transform target, Vector3 offset)
    {
        HpBar hpBar = Instantiate(Resources.Load<HpBar>("HpBar"),
                                                target.transform.position + offset,
                                                Quaternion.identity,
                                                target);
        hpBar._hp.minValue = damageable.hpMin;
        hpBar._hp.maxValue = damageable.hpMax;
        hpBar._hp.value = damageable.hp;
        damageable.onHpChanged += (value) =>
        {
            hpBar._hp.value = value;
        };
        directionChangeable.onDirectionChanged += (value) =>
        {
            hpBar.transform.eulerAngles = value > 0 ? Vector3.zero : new Vector3(0.0f, 180.0f, 0.0f);
        };
        return hpBar;
    }
}
