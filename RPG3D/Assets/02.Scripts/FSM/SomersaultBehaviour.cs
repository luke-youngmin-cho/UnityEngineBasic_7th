using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomersaultBehaviour : BehaviourBase
{
    public float jumpForce = 5.0f;

    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        base.OnStateMachineEnter(animator, stateMachinePathHash);
        rigidbody.velocity = new Vector3(rigidbody.velocity.x,
                                                           0.0f,
                                                           rigidbody.velocity.z);
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        manager.hasSomersaulted = true;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (rigidbody.velocity.y <= 0.0f)
        {
            manager.ChangeState(StateID.Fall);
        }
    }
}
