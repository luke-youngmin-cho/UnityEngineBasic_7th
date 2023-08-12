
public class Parallel : Composite
{
    public enum Policy
    {
        RequireOne,
        RequireAll,
    }
    private Policy _successPolicy;

    public Parallel(Policy successPolicy)
    {
        _successPolicy = successPolicy;
    }

    public override Status Invoke()
    {
        int successCount = 0;
        foreach (Node child in children)
        {
            if (child.Invoke() == Status.Success)
                successCount++;
        }

        switch (_successPolicy)
        {
            case Policy.RequireOne:
                return successCount > 0 ? Status.Success : Status.Failure;
            case Policy.RequireAll:
                return successCount == children.Count ? Status.Success : Status.Failure;
            default:
                throw new System.Exception("[BehaviourTree.Parallel] : Wrong policy");
        }
    }
}