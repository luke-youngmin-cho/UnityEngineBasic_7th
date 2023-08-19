using System;
using UnityEngine;

public class Seek : Node
{
    private float _radius;
    private float _angle;
    private float _deltaAngle;
    private LayerMask _targetMask;
    private Vector3 _offset;

    public Seek(BehaviourTree tree, float radius, float angle, float deltaAngle, LayerMask targetMask, Vector3 offset)
        : base(tree)
    {
        _radius = radius;
        _angle = angle;
        _deltaAngle = deltaAngle;
        _targetMask = targetMask;
        _offset = offset;
    }

    public override Status Invoke()
    {
        bool result = false;
        Ray ray;
        RaycastHit hit;

        for (float theta = 0; theta < _angle * 0.5f; theta += _deltaAngle)
        {
            ray = new Ray(blackBoard.transform.position + _offset,
                                   Quaternion.Euler(Vector3.up * theta) * blackBoard.transform.forward);

            if (Physics.Raycast(ray, out hit, _radius, _targetMask))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                blackBoard.target = hit.transform;
                result = true;
            }
            else
            {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * _radius, Color.yellow);
            }

            ray = new Ray(blackBoard.transform.position + _offset,
                              Quaternion.Euler(Vector3.down * theta) * blackBoard.transform.forward);

            if (Physics.Raycast(ray, out hit, _radius, _targetMask))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                blackBoard.target = hit.transform;
                result = true;
            }
            else
            {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * _radius, Color.yellow);
            }
        }

        if (result)
            blackBoard.agent.destination = blackBoard.target.position;

        return result ? Status.Success : Status.Failure;
    }
}