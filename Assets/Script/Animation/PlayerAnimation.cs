using UnityEngine;

namespace Script.Animation
{
    public class PlayerAnimation : MonoBehaviour
    {
        private static Animator _animator;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Take1 = Animator.StringToHash("Take");
        private static readonly int Death1 = Animator.StringToHash("Death");
        private static readonly int Attack1 = Animator.StringToHash("Attack");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public static void Walk(float x,float y, float speed)
        {
            _animator.SetFloat(Horizontal, x);
            _animator.SetFloat(Vertical, y);
            _animator.SetFloat(Speed, speed);
        }

        public static void Attack()
        {
            _animator.SetTrigger(Attack1);
        }

        public static void Death()
        {
            _animator.SetTrigger(Death1);
        }

        public static void Take()
        {
            _animator.SetTrigger(Take1);
        }
    }
}