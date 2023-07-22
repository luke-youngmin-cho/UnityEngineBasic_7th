using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public abstract class Character : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float ladderSpeed = 1.0f;
    public float jumpForce = 3.5f;
    public float landDistance = 0.5f;
    protected StateMachine stateMachine;
    protected Movement movement;

    protected virtual void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        movement = GetComponent<Movement>();

        movement.onHorizontalChanged += (value) =>
        {
            stateMachine.ChangeState(value == 0.0f ? StateType.Idle : StateType.Move);
        };
    }
}
