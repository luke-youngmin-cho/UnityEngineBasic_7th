using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBehaviour : BehaviourBase
{
    [SerializeField] private float _landingHeight = 1.5f;
    private float _startPosY;

    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        base.OnStateMachineEnter(animator, stateMachinePathHash);
        _startPosY = rigidbody.position.y;
    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (manager.isGrounded)
        {
            if (_startPosY - rigidbody.position.y > _landingHeight)
                manager.ChangeState(StateID.Land);
            else
                manager.ChangeState(StateID.Move);
        }
    }
}
