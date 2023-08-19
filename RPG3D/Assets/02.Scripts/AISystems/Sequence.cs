
public class Sequence : Composite
{
    public Sequence(BehaviourTree tree) : base(tree)
    {
    }

    public override Status Invoke()
    {
        foreach (Node child in children)
        {
            if (child.Invoke() == Status.Failure)
                return Status.Failure;
        }

        return Status.Success;
    }
}