using UnityEngine;

namespace Script.Controllers
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class DynamicMovement : Movement
    {
        private float _horizontal;
        private float _vertical;
        private Rigidbody2D _rigidbody;
        
        [SerializeField] private float speed;

        public float Speed
        {
            get => speed;
            set => speed = value;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        public override void Move(float horizontal, float vertical)
        {
            _horizontal = horizontal;
            _vertical = vertical;
        }
        
        private void FixedUpdate()
        {
            var velocity = _rigidbody.velocity;
            velocity.x = _horizontal * speed;
            velocity.y = _vertical * speed;
            _rigidbody.velocity = velocity;
        }
    }
}
