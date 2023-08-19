using System;

public class Execution : Node
{
    private Func<Status> _execute;

    public Execution(BehaviourTree tree, Func<Status> execute) : base(tree)
    {
        _execute = execute;
    }

    public override Status Invoke()
    {
        return _execute.Invoke();
    }
}