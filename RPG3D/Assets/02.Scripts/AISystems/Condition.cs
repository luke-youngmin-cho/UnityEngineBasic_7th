using System;

public class Condition : Node, IParentOfChild
{
    public Node child { get; set; }
    private Func<bool> _condition;

    public Condition(BehaviourTree tree, Func<bool> condition) : base(tree)
    {
        _condition = condition;
    }

    public override Status Invoke()
    {
        if (_condition.Invoke())
            return child.Invoke();

        return Status.Failure;
    }
}