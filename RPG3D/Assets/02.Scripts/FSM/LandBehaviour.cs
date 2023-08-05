using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandBehaviour : BehaviourBase
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (stateInfo.normalizedTime > 0.9f)
            manager.ChangeState(StateID.Move);
    }
}
