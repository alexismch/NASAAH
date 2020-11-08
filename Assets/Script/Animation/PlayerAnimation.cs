using System;
using Script.Manager;
using UnityEngine;

namespace Script.Animation
{
    public class PlayerAnimation : MonoBehaviour
    {
        private static Animator _animator;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Take1 = Animator.StringToHash("Take");
        private static readonly int Death1 = Animator.StringToHash("Death");
        private static readonly int Attack1 = Animator.StringToHash("Attack");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public static void Walk(float movement)
        {
            if (movement > 0)
                GameManager.StartWalk();
            else
                GameManager.StopWalk();
            _animator.SetFloat(Speed, movement);
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