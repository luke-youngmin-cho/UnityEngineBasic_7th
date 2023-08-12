
public class Selector : Composite
{
    public override Status Invoke()
    {
        foreach (Node child in children)
        {
            if (child.Invoke() == Status.Success)
                return Status.Success;
        }

        return Status.Failure;
    }
}