using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourBase : StateMachineBehaviour
{
    protected Rigidbody rigidbody;
    protected BehaviourManager manager;

    public void Initialize(BehaviourManager manager, Rigidbody rigidbody)
    {
        this.manager = manager;
        this.rigidbody = rigidbody;
    }

    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        base.OnStateMachineEnter(animator, stateMachinePathHash);
        manager.currentMachineBehaviour = this;
        animator.SetBool("isDirty", false);
    }
}
