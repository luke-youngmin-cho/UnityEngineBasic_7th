
public class Sequence : Composite
{
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