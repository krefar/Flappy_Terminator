using System;
using UnityEngine;

namespace Assets.Scripts.Services.Shooting
{
    [RequireComponent(typeof(Collider2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Vector2 _direction;
        private int _parentInstanceId;

        public int ParentInstanceId => _parentInstanceId;

        public event Action<Bullet> OnTriggerEnter;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetInstanceID() != _parentInstanceId)
            {
                OnTriggerEnter?.Invoke(this);
            }
        }

        private void Update()
        {
            if (_speed > 0)
            {
                transform.Translate(_direction * _speed * Time.deltaTime);
            }
        }

        public void Init(Vector2 direction, Quaternion rotation, int parentInstanceId)
        {
            _direction = direction;
            _parentInstanceId = parentInstanceId;
            transform.rotation = rotation;
        }
    }
}