using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMove : State
{
    public StateMove(StateMachine machine) : base(machine)
    {
    }

    public override StateType MoveNext()
    {
        StateType destination = StateType.Move;

        switch (currentStep)
        {
            case IState<StateType>.Step.None:
                {
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.Start:
                {
                    animator.Play("Move");
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
                    // looping...
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
