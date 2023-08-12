public class Root : Node, IParentOfChild
{
    public Node child { get; set; }

    public override Status Invoke()
    {
        return child.Invoke();
    }
}