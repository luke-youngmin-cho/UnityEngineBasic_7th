using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle,
    Move,
    Jump,
    Fall,
    Land,
    Crouch,
    StandUp,
    Attack,
    Hurt,
    Die
}

public abstract class State : IState<StateType>
{
    public abstract bool canExecute { get; }
    public IState<StateType>.Step step => currentStep;
    protected IState<StateType>.Step currentStep;
    protected StateMachine machine;
    protected Animator animator;
    protected Rigidbody2D rigidbody;
    protected CapsuleCollider2D collider;
    protected Transform transform;
    protected Character character;
    protected Movement movement;

    public State(StateMachine machine)
    {
        this.machine = machine;
        this.animator = machine.GetComponentInChildren<Animator>();
        this.rigidbody = machine.GetComponent<Rigidbody2D>();
        this.collider = machine.GetComponent<CapsuleCollider2D>();
        this.transform = machine.GetComponent<Transform>();
        this.character = machine.GetComponent<Character>();
        this.movement = machine.GetComponent<Movement>();
    }


    public abstract StateType MoveNext();

    public void Reset()
    {
        currentStep = IState<StateType>.Step.None;
    }
}
