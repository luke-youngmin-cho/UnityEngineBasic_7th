using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected StateMachine stateMachine;
    protected Movement movement;

    private void Awake()
    {
        stateMachine = gameObject.AddComponent<StateMachine>();
        movement = GetComponent<Movement>();

        movement.onHorizontalChanged += (value) =>
        {
            stateMachine.ChangeState(value == 0.0f ? StateType.Idle : StateType.Move);
        };
    }
}
