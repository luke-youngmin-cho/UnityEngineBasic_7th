using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateJump : State
{
    public override bool canExecute => _groundDetector.isDetected &&
                                                          (machine.currentType == StateType.Idle ||
                                                           machine.currentType == StateType.Move);
    private GroundDetector _groundDetector;

    public StateJump(StateMachine machine) : base(machine)
    {
        _groundDetector = machine.GetComponent<GroundDetector>();
    }

    public override StateType MoveNext()
    {
        StateType destination = StateType.Jump;

        switch (currentStep)
        {
            case IState<StateType>.Step.None:
                {
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.Start:
                {
                    rigidbody.AddForce(Vector2.up * character.jumpForce, ForceMode2D.Impulse);
                    animator.Play("Jump");
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.Casting:
                {
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.OnAction:
                {
                    if (_groundDetector.isDetected)
                        destination = movement.horizontal == 0.0f ? StateType.Idle : StateType.Move;
                    else if (rigidbody.velocity.y <= 0)
                        destination = StateType.Fall;
                }
                break;
            case IState<StateType>.Step.Finish:
                break;
            default:
                break;
        }

        return destination;
    }
}
