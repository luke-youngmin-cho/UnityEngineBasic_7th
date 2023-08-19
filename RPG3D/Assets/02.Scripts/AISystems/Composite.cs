using System.Collections.Generic;

public abstract class Composite : Node, IParentOfChildren
{
    protected Composite(BehaviourTree tree) : base(tree)
    {
        children = new List<Node>();
    }

    public List<Node> children { get; set; }
}