﻿using System;

public class Condition : Node, IParentOfChild
{
    public Node child { get; set; }
    private Func<bool> _condition;

    public Condition(Func<bool> condition) => _condition = condition;

    public override Status Invoke()
    {
        if (_condition.Invoke())
            return child.Invoke();

        return Status.Failure;
    }
}