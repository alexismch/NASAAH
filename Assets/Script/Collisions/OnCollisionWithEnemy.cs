using System;
using Script.Manager;
using UnityEngine;

namespace Script.Collisions
{
    public class OnCollisionWithEnemy : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                GameManager.Kill();
            }
        }
    }
}