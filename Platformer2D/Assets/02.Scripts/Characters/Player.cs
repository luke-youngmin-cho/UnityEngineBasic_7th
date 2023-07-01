using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character
{
    private PlayerInput _input;
   
    protected override void Awake()
    {
        base.Awake();
        _input = GetComponent<PlayerInput>();

        InputAction jumpAction = _input.currentActionMap.FindAction("Jump");
        jumpAction.performed += ctx => stateMachine.ChangeState(StateType.Jump);

        InputAction crouchAction = _input.currentActionMap.FindAction("Crouch");
        crouchAction.performed += ctx => stateMachine.ChangeState(StateType.Crouch);
        crouchAction.canceled += ctx => stateMachine.ChangeState(StateType.StandUp);

    }

    private void Start()
    {
        stateMachine.InitStates(new Dictionary<StateType, IState<StateType>>()
        {
            { StateType.Idle, new StateIdle(stateMachine) },
            { StateType.Move, new StateMove(stateMachine) },
            { StateType.Jump, new StateJump(stateMachine) },
            { StateType.Fall, new StateFall(stateMachine) },
            { StateType.Land, new StateLand(stateMachine) },
            { StateType.Crouch, new StateCrouch(stateMachine) },
            { StateType.StandUp, new StateStandUp(stateMachine) },
        });
    }
}
