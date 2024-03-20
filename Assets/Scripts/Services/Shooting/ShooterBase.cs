using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Services.Shooting
{
    [RequireComponent(typeof(Animator))]
    public abstract class ShooterBase : MonoBehaviour
    {
        private const string ShootTriggerName = "Shoot";

        [SerializeField] private Bullet _bulletPrefab;

        private ObjectPool<Bullet> _bulletPool;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();

            _bulletPool = new ObjectPool<Bullet>(
            createFunc: () => CreateBullet(),
            actionOnGet: (bullet) => ActionOnGet(bullet),
            actionOnRelease: (bullet) => bullet.gameObject.SetActive(false),
            actionOnDestroy: (bullet) => Destroy(bullet),
            collectionCheck: true,
            defaultCapacity: 10,
            maxSize: 30
            );
        }

        protected void Shoot()
        {
            var bullet = _bulletPool.Get();
            Vector2 direction = GetShootDirection();
            bullet.Init(direction, transform.rotation, gameObject.GetInstanceID());
            bullet.OnTriggerEnter += Release;

            _animator.SetTrigger(ShootTriggerName);
        }

        protected abstract Vector2 GetShootDirection();

        private void ActionOnGet(Bullet bullet)
        {
            bullet.gameObject.SetActive(true);
            bullet.transform.position = transform.position;
            bullet.OnTriggerEnter += Release;
        }

        private Bullet CreateBullet()
        {
            return Instantiate(_bulletPrefab);
        }

        private void Release(Bullet bullet)
        {
            bullet.OnTriggerEnter -= Release;
            _bulletPool.Release(bullet);
        }
    }
}
