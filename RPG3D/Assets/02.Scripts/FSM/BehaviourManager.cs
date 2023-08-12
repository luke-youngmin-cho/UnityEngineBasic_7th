using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public enum StateID
{
    None,
    Move,
    Jump,
    Fall,
    Somersault,
    Land,
    Attack = 10,
}


public class BehaviourManager : MonoBehaviour
{
    public bool isGrounded => Physics.SphereCast(transform.position + Vector3.up,
                                                                            0.1f,
                                                                            Vector3.down,
                                                                            out RaycastHit hit,
                                                                            _groundDetectionMaxDistance + 1.0f,
                                                                            _groundMask);
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _groundDetectionMaxDistance;

    public bool hasJumped;
    public bool hasSomersaulted;
    public bool hasAttacked;

    public StateMachineBehaviour currentMachineBehaviour;
    public StateID currentStateID;
    private Animator _currentAnimator;
    private Vector3 _inertia;
    private float _drag;
    private Vector3 _prevPos;
    private bool _isRootMotion;
    public float horizontal
    {
        get => _horizontal;
        set
        {
            _horizontal = value;
            _currentAnimator.SetFloat("Horizontal", value);
        }
    }
    private float _horizontal;

    public float vertical
    {
        get => _vertical;
        set
        {
            _vertical = value;
            _currentAnimator.SetFloat("Vertical", value);
        }
    }
    private float _vertical;
    private NavMeshAgent _agent;
    public float speed;

    public bool ChangeState(StateID newStateID)
    {
        if (currentStateID == newStateID)
            return false;

        _currentAnimator.SetBool("isDirty", true);
        _currentAnimator.SetInteger("stateID", (int)newStateID);
        currentStateID = newStateID;
        return true;
    }
    public void ChangeStateForcely(StateID newStateID)
    {
        _currentAnimator.SetBool("isDirty", true);
        _currentAnimator.SetInteger("stateID", (int)newStateID);
        currentStateID = newStateID;
    }

    private void Awake()
    {
         _currentAnimator= GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        _drag = rigidbody.drag;

        BehaviourBase[] behaviours = _currentAnimator.GetBehaviours<BehaviourBase>();

        for (int i = 0; i < behaviours.Length; i++)
        {
            behaviours[i].Initialize(this, rigidbody);
        }

        ComboStackingStateBehaviour[] comboStackingStateBehaviours = _currentAnimator.GetBehaviours<ComboStackingStateBehaviour>();

        for (int i = 0; i < comboStackingStateBehaviours.Length; i++)
        {
            comboStackingStateBehaviours[i].Initialize(this);
        }

        ChangeState(StateID.Move);
    }

    private void Update()
    {
        if (_agent.enabled)
        {
            Vector3 velocity = (_agent.destination - transform.position).normalized * speed;

            horizontal = Vector3.Dot(velocity, transform.right);
            vertical = Vector3.Dot(velocity, transform.forward);
        }
    }

    private void FixedUpdate()
    {
        if (isGrounded)
        {
            _inertia = (transform.position - _prevPos) / Time.fixedDeltaTime;
        }
        else
        {
            transform.position += new Vector3(_inertia.x, 0.0f, _inertia.z) * Time.fixedDeltaTime;
            _inertia = Vector3.Lerp(_inertia, Vector3.zero, _drag * Time.fixedDeltaTime);
        }

        _prevPos = transform.position;
    }
}
