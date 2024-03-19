using Assets.Scripts.Services.Shooting;
using System;
using UnityEngine;

[RequireComponent(typeof(BulletTarget))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(EnemyShooter))]
public class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnEnemyDie;

    private BulletTarget _bulletTarget;
    private Rigidbody2D _rigidbody;
    private EnemyMover _enemyMover;
    private EnemyShooter _enemyShooter;

    private Vector3 _moveTo;

    private void Awake()
    {
        _bulletTarget = GetComponent<BulletTarget>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyMover = GetComponent<EnemyMover>();
        _enemyShooter = GetComponent<EnemyShooter>();

        _rigidbody.simulated = true;
        _rigidbody.gravityScale = 0;
    }

    private void OnEnable()
    {
        _bulletTarget.OnHitByBullet += Die;
        _enemyMover.enabled = true;
        _enemyShooter.enabled = true;
    }

    private void OnDisable()
    {
        _bulletTarget.OnHitByBullet -= Die;
        _enemyMover.enabled = false;
        _enemyShooter.enabled = false;
    }

    private void Die()
    {
        OnEnemyDie?.Invoke(this);
    }
}