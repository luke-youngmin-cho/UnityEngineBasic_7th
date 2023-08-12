using System;

public class Execution : Node
{
    private Func<Status> _execute;

    public Execution(Func<Status> execute)
    {
        _execute = execute;
    }

    public override Status Invoke()
    {
        return _execute.Invoke();
    }
}