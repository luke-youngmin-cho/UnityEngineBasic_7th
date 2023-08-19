using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status
{
    Success,
    Failure,
    Running
}

public abstract class Node
{
    public BehaviourTree tree;
    public BlackBoard blackBoard;
    public Node(BehaviourTree tree)
    {
        this.tree = tree;
        this.blackBoard = tree.blackBoard;
    }
    public abstract Status Invoke();
}
