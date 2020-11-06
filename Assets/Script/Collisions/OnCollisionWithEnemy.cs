using System;
using Script.Manager;
using UnityEngine;

namespace Script.Collisions
{
    public class OnCollisionWithEnemy : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if ((layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
            {
                GameManager.Kill();
            }
        }
        
        
    }
}
