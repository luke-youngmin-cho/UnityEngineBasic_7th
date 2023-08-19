using UnityEngine;
using UnityEngine.AI;

public class BlackBoard
{
    // Owner
    public GameObject owner;
    public Transform transform;
    public Rigidbody rigidbody;
    public NavMeshAgent agent;
    public BehaviourManager behaviourManager;

    // Target
    public Transform target;

    public BlackBoard(GameObject owner)
    {
        this.owner = owner;
        transform = owner.transform;
        rigidbody = owner.GetComponent<Rigidbody>();
        agent = owner.GetComponent<NavMeshAgent>();
        behaviourManager = owner.GetComponent<BehaviourManager>();
    }
}