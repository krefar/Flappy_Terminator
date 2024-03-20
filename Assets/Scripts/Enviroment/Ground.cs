using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ground : MonoBehaviour, IInterectable
{
    private Animator _animator;

    private void Reset()
    {
        _animator.enabled = true;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StopAnimation()
    {
        _animator.enabled = false;
    }
}