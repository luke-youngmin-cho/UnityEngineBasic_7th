using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCrouch : State
{
    public override bool canExecute => true;
    private GroundDetector _groundDetector;
    public StateCrouch(StateMachine machine) : base(machine)
    {
        _groundDetector = machine.GetComponent<GroundDetector>();
    }

    public override StateType MoveNext()
    {
        StateType destination = StateType.Crouch;

        switch (currentStep)
        {
            case IState<StateType>.Step.None:
                {
                    movement.isMovable = false;
                    movement.isDirectionChangeable = true;
                    rigidbody.bodyType = RigidbodyType2D.Dynamic;
                    animator.speed = 1.0f;
                    animator.Play("CrouchStart");
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.Start:
                {
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.Casting:
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                    {
                        animator.Play("CrouchIdle");
                        currentStep++;
                    }
                }
                break;
            case IState<StateType>.Step.OnAction:
                {
                    if (_groundDetector.isDetected == false)
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
