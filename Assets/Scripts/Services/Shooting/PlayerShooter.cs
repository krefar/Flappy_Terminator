using UnityEngine;

namespace Assets.Scripts.Services.Shooting
{
    public class PlayerShooter : ShooterBase
    {
        protected override Vector2 GetShootDirection()
        {
            return new Vector2(transform.right.x, transform.right.y);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
    }
}