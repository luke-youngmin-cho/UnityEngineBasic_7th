using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateLand : State
{
    public override bool canExecute => true;
    public StateLand(StateMachine machine) : base(machine)
    {
    }

    public override StateType MoveNext()
    {
        StateType destination = StateType.Land;

        switch (currentStep)
        {
            case IState<StateType>.Step.None:
                {
                    movement.isMovable = false;
                    movement.isDirectionChangeable = true;
                    rigidbody.bodyType = RigidbodyType2D.Dynamic;
                    animator.speed = 1.0f;
                    animator.Play("Land");
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
                    // normalizedTime : ǥ��ȭ �ð� ( 0.0 ~ 1.0 ���� ǥ��ȭ, ���� ����ð� / ��ü ����) 
                    // ex) 0.3�� Ŭ���� �ִϸ��̼��� 0.1�� ��� 
                    // -> nomalizedTime = 0.1 / 0.3 = 0.3333...
                    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                    {
                        destination = movement.horizontal == 0.0f ? StateType.Idle : StateType.Move;
                    }
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
