using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboStackingStateBehaviour : StateMachineBehaviour
{
    private BehaviourManager _manager;
    [SerializeField] private string _comboStackParamName;
    private int _comboStackParamID;
    [SerializeField] private int _maxCombo;
    [SerializeField] private float _resetTime = 0.5f;
    private int _comboStack;
    private bool _isCorouting;
    private Coroutine _coroutine;
    private WaitForSeconds _waitForResetTime;

    public void Initialize(BehaviourManager manager)
    {
        _manager = manager;
        _comboStackParamID = Animator.StringToHash(_comboStackParamName);
        _waitForResetTime = new WaitForSeconds(_resetTime);
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        Debug.Log($"Combo Enter");
        // 콤보 유효시간 타이머 정지
        if (_isCorouting)
        {
            _manager.StopCoroutine(_coroutine);
            _isCorouting = false;
            _coroutine = null;
        }

        animator.SetFloat(_comboStackParamID, _comboStack);
        _comboStack = _comboStack < _maxCombo ? _comboStack + 1 : 0;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        if (_isCorouting == false)
        {
            _isCorouting = true;
            _coroutine = _manager.StartCoroutine(E_ResetComboStack());
        }
    }

    IEnumerator E_ResetComboStack()
    {
        yield return _waitForResetTime;
        _comboStack = 0;
        _isCorouting = false;
        _coroutine = null;
    }
}
