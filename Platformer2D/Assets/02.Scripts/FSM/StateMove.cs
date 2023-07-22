using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMove : State
{
    public override bool canExecute => true;
    private GroundDetector _groundDetector;
    public StateMove(StateMachine machine) : base(machine)
    {
        _groundDetector = machine.GetComponent<GroundDetector>();
    }

    public override StateType MoveNext()
    {
        StateType destination = StateType.Move;

        switch (currentStep)
        {
            case IState<StateType>.Step.None:
                {
                    movement.isMovable = true;
                    movement.isDirectionChangeable = true;
                    rigidbody.bodyType = RigidbodyType2D.Dynamic;
                    animator.speed = 1.0f;
                    animator.Play("Move");
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
                    currentStep++;
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
