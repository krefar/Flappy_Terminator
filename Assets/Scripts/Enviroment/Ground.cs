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

    private void Reset()
    {
        _animator.enabled = true;
    }

    public void StopAnimation()
    {
        _animator.enabled = false;
    }
}