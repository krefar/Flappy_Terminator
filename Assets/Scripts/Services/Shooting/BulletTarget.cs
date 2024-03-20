using System;
using UnityEngine;

namespace Assets.Scripts.Services.Shooting
{
    [RequireComponent(typeof(Collider2D))]
    public class BulletTarget : MonoBehaviour
    {
        public Action OnHitByBullet;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var isBullet = other.TryGetComponent(out Bullet bullet);

            if (isBullet && bullet.ParentInstanceId != gameObject.GetInstanceID())
            {
                OnHitByBullet?.Invoke();
            }
        }
    }
}