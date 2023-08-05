using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator _animator;
    private BehaviourManager _behaviourManager;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _behaviourManager = GetComponent<BehaviourManager>();
    }

    private void Update()
    {
        float gain = Input.GetKey(KeyCode.LeftShift) ? 1.0f : 0.5f;
        _animator.SetFloat("horizontal", Input.GetAxis("Horizontal") * gain);
        _animator.SetFloat("vertical", Input.GetAxis("Vertical") * gain);

        if (Input.GetMouseButtonDown(0))
        {
            if (_behaviourManager.hasAttacked)
            {
                _behaviourManager.ChangeStateForcely(StateID.Attack);
            }
            else
                _behaviourManager.ChangeState(StateID.Attack);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_behaviourManager.isGrounded)
            {
                if (_behaviourManager.hasJumped == false)
                {
                    _behaviourManager.ChangeState(StateID.Jump);
                }
            }
            else
            {
                if (_behaviourManager.hasSomersaulted == false)
                {
                    _behaviourManager.ChangeState(StateID.Somersault);
                }
            }
        }
    }

    private void Hit() { }
}
