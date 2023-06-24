using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public StateType currentType;
    public IState<StateType> current;
    private Dictionary<StateType, IState<StateType>> states;

    public void InitStates(Dictionary<StateType, IState<StateType>> states)
    {
        this.states = states;
        current = states[currentType];
    }

    public bool ChangeState(StateType newType)
    {
        if (currentType == newType)
            return false;

        current.Reset();
        current = states[newType];
        currentType = newType;
        return true;
    }

    private void Update()
    {
        ChangeState(current.MoveNext());
    }
}
