using System;
using UnityEngine;

namespace Script.Animation
{
    public class PlayerAnimation : MonoBehaviour
    {
        private static Animator _animator;
        private static readonly int Speed = Animator.StringToHash("Speed");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public static void Walk(float movement)
        {
            _animator.SetFloat(Speed, movement);
        }

        public static void Attack()
        {
            _animator.SetTrigger("Attack");
        }

        public static void Death()
        {
            _animator.SetTrigger("Death");
        }
    }
}
