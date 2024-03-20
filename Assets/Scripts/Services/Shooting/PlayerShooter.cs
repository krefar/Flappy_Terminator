using UnityEngine;

namespace Assets.Scripts.Services.Shooting
{
    public class PlayerShooter : ShooterBase
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }

        protected override Vector2 GetShootDirection()
        {
            return new Vector2(transform.right.x, transform.right.y);
        }
    }
}