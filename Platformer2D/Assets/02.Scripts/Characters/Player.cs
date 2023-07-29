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

        InputAction downArrowAction = _input.currentActionMap.FindAction("DownArrow");
        downArrowAction.performed += ctx =>
        {
            stateMachine.ChangeState(StateType.LadderDown);
            stateMachine.ChangeState(StateType.Crouch);
        };
        downArrowAction.canceled += ctx => stateMachine.ChangeState(StateType.StandUp);

        InputAction upArrowAction = _input.currentActionMap.FindAction("UpArrow");
        upArrowAction.performed += ctx => stateMachine.ChangeState(StateType.LadderUp);
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
            { StateType.LadderUp, new StateLadderUp(stateMachine) },
            { StateType.LadderDown, new StateLadderDown(stateMachine) },
        });
    }
}
