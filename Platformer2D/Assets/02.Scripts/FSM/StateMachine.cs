using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public StateType currentType;
    public IState<StateType> current;
    private Dictionary<StateType, IState<StateType>> states;
    private bool _isDirty;

    public void InitStates(Dictionary<StateType, IState<StateType>> states)
    {
        this.states = states;
        current = states[currentType];
    }

    public bool ChangeState(StateType newType)
    {
        if (_isDirty)
            return false;

        if (currentType == newType)
            return false;

        if (states[newType].canExecute == false)
            return false;

        Debug.Log($"{currentType} -> {newType}");
        current.Reset();
        current = states[newType];
        currentType = newType;
        _isDirty = true;
        return true;
    }

    private void Update()
    {
        ChangeState(current.MoveNext());
        _isDirty = false;
    }
}
