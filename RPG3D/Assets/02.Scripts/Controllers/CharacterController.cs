using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float gain = Input.GetKey(KeyCode.LeftShift) ? 1.0f : 0.5f;
        _animator.SetFloat("horizontal", Input.GetAxis("Horizontal") * gain);
        _animator.SetFloat("vertical", Input.GetAxis("Vertical") * gain);
    }
}
