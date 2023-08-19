using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Patrol : Node
{
    private float _radius;

    public Patrol(BehaviourTree tree, float radius)
        : base(tree)
    {
        _radius = radius;
    }

    public override Status Invoke()
    {
        float l = Random.Range(0, _radius);
        float theta = Random.Range(0.0f, 2 * Mathf.PI); // PI (rad) == 180 (deg)
        float x = l * Mathf.Sin(theta);
        float z = l * Mathf.Cos(theta);
        Vector3 expected = blackBoard.transform.position + new Vector3(x, 0.0f, z);

        if (NavMesh.SamplePosition(expected, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
        {
            blackBoard.agent.destination = hit.position;
            return Status.Success;
        }

        return Status.Failure;
    }
}