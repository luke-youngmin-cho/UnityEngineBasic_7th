using System;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree
{
    public BlackBoard blackBoard;
    public Root root;
    public bool isSleeping;

    public Status Tick()
    {
        return isSleeping ? Status.Running : root.Invoke();
    }


    private Node _current;
    private Stack<Composite> _compositeStack = new Stack<Composite>();

    public BehaviourTree StartBuild(GameObject owner)
    {
        blackBoard = new BlackBoard(owner);
        root = new Root(this);
        _current = root;
        return this;
    }

    public BehaviourTree ExitCurrentComposite()
    {
        if (_compositeStack.Count > 1)
        {
            _compositeStack.Pop();
            _current = _compositeStack.Peek();
        }
        else if (_compositeStack.Count == 1)
        {
            _compositeStack.Pop();
            _current = null;
        }
        else
        {
            throw new Exception($"[BehaviourTree.ExitCurrentComposite()] : 컴포지트 스택이 비어있으므로 탈출할 수 없습니다.");
        }

        return this;
    }


    public BehaviourTree Condition(Func<bool> condition)
    {
        Node node = new Condition(this, condition);
        AttachAsChild(_current, node);
        _current = node;
        return this;
    }

    public BehaviourTree Execution(Func<Status> execute)
    {
        Node node = new Execution(this,execute);
        AttachAsChild(_current, node);

        if (_compositeStack.Count > 0)
            _current = _compositeStack.Peek();
        else
            _current = null;

        return this;
    }

    public BehaviourTree Patrol(float radius)
    {
        Node node = new Patrol(this, radius);
        AttachAsChild(_current, node);

        if (_compositeStack.Count > 0)
            _current = _compositeStack.Peek();
        else
            _current = null;

        return this;
    }

    public BehaviourTree RandomSleep(float min, float max)
    {
        Node node = new RandomSleep(this, min, max);
        AttachAsChild(_current, node);

        if (_compositeStack.Count > 0)
            _current = _compositeStack.Peek();
        else
            _current = null;

        return this;
    }


    public BehaviourTree Seek(float radius, float angle, float deltaAngle, LayerMask targetMask, Vector3 offset)
    {
        Node node = new Seek(this, radius, angle, deltaAngle, targetMask, offset);
        AttachAsChild(_current, node);

        if (_compositeStack.Count > 0)
            _current = _compositeStack.Peek();
        else
            _current = null;

        return this;
    }

    public BehaviourTree Sequence()
    {
        Composite node = new Sequence(this);
        AttachAsChild(_current, node);
        _current = node;
        _compositeStack.Push(node);
        return this;
    }

    public BehaviourTree Selector()
    {
        Composite node = new Selector(this);
        AttachAsChild(_current, node);
        _current = node;
        _compositeStack.Push(node);
        return this;
    }

    public BehaviourTree Parallel(Parallel.Policy successPolicy)
    {
        Composite node = new Parallel(this,successPolicy);
        AttachAsChild(_current, node);
        _current = node;
        _compositeStack.Push(node);
        return this;
    }
    private void AttachAsChild(Node parent, Node child)
    {
        if (parent is IParentOfChild)
        {
            ((IParentOfChild)parent).child = child;
        }
        else if (parent is IParentOfChildren)
        {
            ((IParentOfChildren)parent).children.Add(child);
        }
        else
        {
            throw new Exception($"[BehaviourTree] :  {parent.GetType()} 에다가는 자식 노드를 붙일 수 없습니다. ");
        }
    }
}
