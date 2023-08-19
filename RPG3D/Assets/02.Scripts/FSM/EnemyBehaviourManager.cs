using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyBehaviourManager : BehaviourManager
{
    private BehaviourTree _behaviourTree;

    [Header("AI")]
    [SerializeField] private float _seek_radius;
    [SerializeField] private float _seek_angle;
    [SerializeField] private float _seek_deltaAngle;
    [SerializeField] private LayerMask _seek_targetMask;
    [SerializeField] private Vector3 _seek_offset;
    [SerializeField] private float _attack_range;
    [SerializeField] private float _patrol_range = 10.0f;
    [SerializeField] private float _patrol_timeMin = 2.0f;
    [SerializeField] private float _patrol_timeMax = 4.0f;
    protected override void Awake()
    {
        base.Awake();
        _behaviourTree = new BehaviourTree();
        _behaviourTree.StartBuild(gameObject)
            .Selector()
                .Parallel(Parallel.Policy.RequireOne)
                    .Condition(() => _behaviourTree.blackBoard.agent.remainingDistance <= 
                                             _behaviourTree.blackBoard.agent.stoppingDistance)   
                        .Patrol(_patrol_range)
                    .Seek(_seek_radius, _seek_angle, _seek_deltaAngle, _seek_targetMask, _seek_offset)
                    .Condition(() => _behaviourTree.blackBoard.target != null &&
                                             Vector3.Distance(_behaviourTree.blackBoard.target.position, transform.position) < _attack_range)
                        .Execution(() => ChangeState(StateID.Attack) ? Status.Success : Status.Failure)
                    .ExitCurrentComposite();
                //.Sequence()
                //    .Patrol(_patrol_range)
                //    .RandomSleep(_patrol_timeMin, _patrol_timeMax);
                    
    }

    private void Update()
    {
        _behaviourTree.Tick();
    }
}
