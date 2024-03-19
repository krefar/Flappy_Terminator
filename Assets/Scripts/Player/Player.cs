using Assets.Scripts.Services.Shooting;
using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(ShooterBase))]
[RequireComponent(typeof(PlayerCollisionHandler))]
[RequireComponent(typeof(BulletTarget))]

public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private ShooterBase _shooter;
    private PlayerCollisionHandler _playerCollisionHandler;
    private BulletTarget _bulletTarget;
    
    public event Action OnPlayerTouchGround;
    public event Action OnPlayerDie;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _shooter = GetComponent<ShooterBase>();
        _playerCollisionHandler = GetComponent<PlayerCollisionHandler>();
        _bulletTarget = GetComponent<BulletTarget>();
    }

    private void OnEnable()
    {
        _playerMover.enabled = true;
        _shooter.enabled = true;
        _playerCollisionHandler.CollisionDetected += ProcessCollision;
        _bulletTarget.OnHitByBullet += Die;
    }

    private void OnDisable()
    {
        _playerMover.enabled = false;
        _shooter.enabled = false;
        _playerCollisionHandler.CollisionDetected -= ProcessCollision;
        _bulletTarget.OnHitByBullet -= Die;
    }

    private void ProcessCollision(IInterectable interectable)
    {
        if (interectable is Ground)
        {
            OnPlayerTouchGround?.Invoke();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        OnPlayerDie?.Invoke();
    }
}