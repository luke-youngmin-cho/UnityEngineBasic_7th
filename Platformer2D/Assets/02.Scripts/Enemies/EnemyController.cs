using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour, IDamageable, IDirectionChangeable
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private CapsuleCollider2D _col;

    public int direction
    {
        get => _direction;
        set
        {
            if (_direction == value)
                return;

            if (value > 0)
            {
                _direction = DIRECTION_RIGHT;
                transform.eulerAngles = Vector3.zero;
            }
            else if (value < 0)
            {
                _direction = DIRECTION_LEFT;
                transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
            }

            onDirectionChanged?.Invoke(value);
        }
    }

    public float hp 
    { 
        get => _hp; 
        set
        {
            float prev = _hp;
            _hp = value;

            if (prev != value)
            {
                onHpChanged?.Invoke(value);
                if (prev > value)
                    onHpDecreased?.Invoke(prev - value);
                else
                    onHpIncreased?.Invoke(value - prev);
            }

            if (value >= _hpMax)
                onHpMax?.Invoke();
            else if (value <= _hpMin)
                onHpMin?.Invoke();
        }
    }

    public float hpMax => _hpMax;

    public float hpMin => _hpMin;

    private int _direction = DIRECTION_RIGHT;
    public const int DIRECTION_RIGHT = 1;
    public const int DIRECTION_LEFT = -1;
    [SerializeField] private bool _moveEnable = true; // �����̴� ��� Ȱ��ȭ �Ұ���
    [SerializeField] private float _moveSpeed;
    private bool _movable; // ���� �����ϼ� �ִ� ��������

    private float _hp;
    [SerializeField] private float _hpMax = 100.0f;
    [SerializeField] private float _hpMin = 0.0f;

    public enum StateType
    {
        Idle,
        Move,
        Attack,
        Hurt,
        Die,
    }
    public StateType current;

    // � �����϶� � ������ �����ؾ��ϴ����� ���� ����
    private Dictionary<StateType, IEnumerator<int>> _workflows = new Dictionary<StateType, IEnumerator<int>>();

    // � ���¸� �����ϱ����ؼ��� � ������ ����Ǿ�� �ϴ����� ���� ����
    private Dictionary<StateType, Func<bool>> _conditions = new Dictionary<StateType, Func<bool>>();

    #region Workflows
    /// <summary>
    /// +a 
    /// IEnumerator �������̽� ��ſ� ���ο� �������̽��� ���� 
    /// �� �� ȿ�������� �߻�ȭ �غ��°Ÿ� �����غ�����
    /// </summary>
    public struct IdleWorkflow : IEnumerator<int>
    {
        public int Current => _current;

        object IEnumerator.Current => _current;
        private int _current;
        private EnemyController _controller;

        public IdleWorkflow(EnemyController controller)
        {
            _current = 0;
            _controller = controller;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            switch (_current)
            {
                case 0:
                    {
                        _controller._movable = false;
                        _controller._animator.Play("Idle");
                        _current++;
                    }
                    break;
                default:
                    break;
            }

            return true;
        }

        public void Reset()
        {
            _current = 0;
        }
    }
    public struct MoveWorkflow : IEnumerator<int>
    {
        public int Current => _current;

        object IEnumerator.Current => _current;
        private int _current;
        private EnemyController _controller;

        public MoveWorkflow(EnemyController controller)
        {
            _current = 0;
            _controller = controller;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            switch (_current)
            {
                case 0:
                    {
                        _controller._movable = true;
                        _controller._animator.Play("Move");
                        _current++;
                    }
                    break;
                default:
                    break;
            }

            return true;
        }

        public void Reset()
        {
            _current = 0;
        }
    }
    public struct AttackWorkflow : IEnumerator<int>
    {
        public int Current => _current;

        object IEnumerator.Current => _current;
        private int _current;
        private EnemyController _controller;

        public AttackWorkflow(EnemyController controller)
        {
            _current = 0;
            _controller = controller;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            switch (_current)
            {
                case 0:
                    {
                        _controller._movable = false;
                        _controller._animator.Play("Attack");
                        _current++;
                    }
                    return true;
                case 1:
                    {
                        if (_controller._animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                        {
                            if (_controller.ChangeState(StateType.Idle))
                            {
                                _current++;
                            }
                        }
                    }
                    return true;
                default:
                    return false;
            }
        }

        public void Reset()
        {
            _current = 0;
        }
    }
    public struct HurtWorkflow : IEnumerator<int>
    {
        public int Current => _current;

        object IEnumerator.Current => _current;
        private int _current;
        private EnemyController _controller;

        public HurtWorkflow(EnemyController controller)
        {
            _current = 0;
            _controller = controller;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            switch (_current)
            {
                case 0:
                    {
                        _controller._movable = false;
                        _controller._animator.Play("Hurt");
                        _current++;
                    }
                    return true;
                case 1:
                    {
                        if (_controller._animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                        {
                            if (_controller.ChangeState(StateType.Idle))
                            {
                                _current++;
                            }
                        }
                    }
                    return true;
                default:
                    return false;
            }
        }

        public void Reset()
        {
            _current = 0;
        }
    }
    public struct DieWorkflow : IEnumerator<int>
    {
        public int Current => _current;

        object IEnumerator.Current => _current;
        private int _current;
        private EnemyController _controller;

        public DieWorkflow(EnemyController controller)
        {
            _current = 0;
            _controller = controller;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            switch (_current)
            {
                case 0:
                    {
                        _controller._movable = false;
                        _controller._animator.Play("Die");
                        _current++;
                    }
                    return true;
                case 1:
                    {
                        if (_controller._animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                        {
                            _current++;
                            Destroy(_controller.gameObject);
                        }
                    }
                    return true;
                default:
                    return false;
            }
        }

        public void Reset()
        {
            _current = 0;
        }
    }
    #endregion

    #region AI
    private enum AI
    {
        Idle,
        Think,
        TakeARest,
        MoveLeft,
        MoveRight,
        StartFollow,
        Follow,
        StartAttack,
        Attack
    }
    [SerializeField] private AI _ai;
    [SerializeField] private bool _aiAutoFollow;
    [SerializeField] protected LayerMask aiDetectMask;
    [SerializeField] private float _aiDetectRange = 2.0f;
    [SerializeField] private bool _aiAttackEnable = false;
    [SerializeField] private float _aiAttackRange = 0.5f;
    [SerializeField] private float _aiThinkTimeMin = 0.1f;
    [SerializeField] private float _aiThinkTimeMax = 2.0f;
    [SerializeField] private float _aiThinkTimer;
    public GameObject target;

    public event Action<float> onHpChanged;
    public event Action<float> onHpIncreased;
    public event Action<float> onHpDecreased;
    public event Action onHpMax;
    public event Action onHpMin;
    public event Action<int> onDirectionChanged;

    #endregion
    public bool ChangeState(StateType newState)
    {
        if (current == newState)
            return false;

        if (_conditions[newState].Invoke())
        {
            current = newState;
            _workflows[newState].Reset();
            return true;
        }

        return false;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<CapsuleCollider2D>();
        InitializeWorkflows();
    }

    private void Start()
    {
        hp = hpMax;
        onHpMin += () => ChangeState(StateType.Die);
        HpBar.Create(this, this, transform, new Vector3(0.0f, _col.size.y + 0.1f, 0.0f));
        _ai = AI.Think;
    }

    private void Update()
    {
        UpdateAI();

        if (_workflows[current].MoveNext() == false)
            _workflows[current].Reset();
    }

    private void FixedUpdate()
    {
        if (_moveEnable && _movable)
            _rb.MovePosition(_rb.position + _direction * Vector2.right * _moveSpeed * Time.fixedDeltaTime);
    }

    private void InitializeWorkflows()
    {
        _workflows.Add(StateType.Idle, new IdleWorkflow(this));
        _workflows.Add(StateType.Move, new MoveWorkflow(this));
        _workflows.Add(StateType.Attack, new AttackWorkflow(this));
        _workflows.Add(StateType.Hurt, new HurtWorkflow(this));
        _workflows.Add(StateType.Die, new DieWorkflow(this));

        _conditions.Add(StateType.Idle, () => true);
        _conditions.Add(StateType.Move, () => true);
        _conditions.Add(StateType.Attack, () => current == StateType.Idle || current == StateType.Move);
        _conditions.Add(StateType.Hurt, () => true);
        _conditions.Add(StateType.Die, () => true);
    }

    private void UpdateAI()
    {
        Collider2D detected = Physics2D.OverlapCircle(_rb.position, _aiDetectRange, aiDetectMask);
        target = detected ? detected.gameObject : null;

        if (_aiAutoFollow &&
            _ai < AI.StartFollow &&
            target)
        {
            _ai = AI.StartFollow;
        }

        switch (_ai)
        {
            case AI.Idle:
                break;
            case AI.Think:
                {
                    _ai = (AI)Random.Range((int)AI.TakeARest, (int)AI.MoveRight + 1);
                    _aiThinkTimer = Random.Range(_aiThinkTimeMin, _aiThinkTimeMax);

                    if (_ai == AI.TakeARest)
                        ChangeState(StateType.Idle);
                    else
                        ChangeState(StateType.Move);
                }
                break;
            case AI.TakeARest:
                {
                    if (_aiThinkTimer > 0)
                        _aiThinkTimer -= Time.deltaTime;
                    else
                        _ai = AI.Think;
                }
                break;
            case AI.MoveLeft:
                {
                    direction = DIRECTION_LEFT;
                    if (_aiThinkTimer > 0)
                        _aiThinkTimer -= Time.deltaTime;
                    else
                        _ai = AI.Think;
                }
                break;
            case AI.MoveRight:
                {
                    direction = DIRECTION_RIGHT;
                    if (_aiThinkTimer > 0)
                        _aiThinkTimer -= Time.deltaTime;
                    else
                        _ai = AI.Think;
                }
                break;
            case AI.StartFollow:
                {
                    ChangeState(StateType.Move);
                    _ai = AI.Follow;
                }
                break;
            case AI.Follow:
                {
                    if (target == null)
                    {
                        _ai = AI.Think;
                        return;
                    }

                    if (_rb.position.x < target.transform.position.x - _col.size.x)
                    {
                        direction = DIRECTION_RIGHT;
                    }
                    else if (_rb.position.x > target.transform.position.x + _col.size.x)
                    {
                        direction = DIRECTION_LEFT;
                    }

                    if (_aiAttackEnable &&
                        Vector2.Distance(_rb.position, target.transform.position) < _aiAttackRange)
                    {
                        _ai = AI.StartAttack;
                    }
                }
                break;
            case AI.StartAttack:
                {
                    if (ChangeState(StateType.Attack))
                    {
                        _ai = AI.Attack;
                    }
                    else
                    {
                        _ai = AI.Think;
                    }
                }
                break;
            case AI.Attack:
                {
                    // wait until attack is finished
                    if (current != StateType.Attack)
                        _ai = AI.Think;
                }
                break;
            default:
                break;
        }
    }

    public void Damage(GameObject damager, float amout)
    {
        target = damager;
        hp = _hp - amout;
    }
    protected virtual void Hit() { }

    protected virtual void OnDrawGizmos()
    {
        if (_aiAutoFollow)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _aiDetectRange);
        }

        if (_aiAttackEnable)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _aiAttackRange);
        }
    }
}
