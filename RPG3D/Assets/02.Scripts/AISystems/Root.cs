public class Root : Node, IParentOfChild
{
    public Root(BehaviourTree tree) : base(tree)
    {
    }

    public Node child { get; set; }

    public override Status Invoke()
    {
        return child.Invoke();
    }
}