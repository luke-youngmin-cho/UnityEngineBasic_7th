using System;

public class Decorator : Node, IParentOfChild
{
    public Node child { get; set; }
    private Func<Status, Status> _decorate;

    public Decorator(Func<Status, Status> decorate)
    {
        _decorate = decorate;
    }

    public override Status Invoke()
    {
        return _decorate.Invoke(child.Invoke());
    }
}