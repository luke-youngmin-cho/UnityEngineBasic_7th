using System;

public class Decorator : Node, IParentOfChild
{
    public Node child { get; set; }
    private Func<Status, Status> _decorate;

    public Decorator(BehaviourTree tree, Func<Status, Status> decorate) : base(tree)
    {
        _decorate = decorate;
    }

    public override Status Invoke()
    {
        return _decorate.Invoke(child.Invoke());
    }
}