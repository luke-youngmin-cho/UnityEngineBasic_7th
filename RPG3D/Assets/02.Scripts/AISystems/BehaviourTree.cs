public class BehaviourTree
{
    public Root root;

    public BehaviourTree()
    {
        root = new Root();
    }

    public Status Tick()
    {
        return root.Invoke();
    }
}