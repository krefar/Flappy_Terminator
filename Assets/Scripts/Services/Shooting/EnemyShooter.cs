using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Services.Shooting
{
    public class EnemyShooter : ShooterBase
    {
        [SerializeField] float _shootInreval = 1f;

        private void OnEnable()
        {
            StartCoroutine(ShootCoroutine());
        }

        private IEnumerator ShootCoroutine()
        {
            var wait = new WaitForSeconds(_shootInreval);

            while (gameObject.activeInHierarchy)
            {
                Shoot();

                yield return wait;
            }
        }

        protected override Vector2 GetShootDirection()
        {
            return new Vector2(-transform.right.x, transform.right.y);
        }
    }
}