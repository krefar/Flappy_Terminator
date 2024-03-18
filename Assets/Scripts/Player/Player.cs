using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private PlayerCollisionHandler _playerCollisionHandler;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _playerCollisionHandler = GetComponent<PlayerCollisionHandler>();
    }

    private void OnEnable()
    {
        _playerCollisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _playerCollisionHandler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInterectable interectable)
    {
        if (interectable is Ground)
        {
            _playerMover.enabled = false;
        }
    }
}
