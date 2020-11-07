using System;
using UnityEngine;

namespace Script.Animation
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int Speed = Animator.StringToHash("Speed");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Walk(float movement)
        {
            _animator.SetFloat(Speed, movement);
        }

        public void Attack()
        {
            _animator.SetTrigger("Attack");
        }
    }
}
