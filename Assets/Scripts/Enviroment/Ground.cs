using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ground : MonoBehaviour, IInterectable
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        _animator.enabled = false;
    }

    private void Reset()
    {
        _animator.enabled = true;
    }
}