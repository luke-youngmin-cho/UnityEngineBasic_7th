using System.Collections.Generic;

public abstract class Composite : Node, IParentOfChildren
{
    public List<Node> children { get; set; }
}