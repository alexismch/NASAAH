using System;
using Script.Controllers;
using UnityEngine;

namespace Script.Collisions
{
    public class OnCollisionWithDecor : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        
        private DynamicMovement _dynamicMovement;

        private void Awake()
        {
            _dynamicMovement = GetComponent<DynamicMovement>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if ((layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
            {
                _dynamicMovement.SetSpeed(_dynamicMovement.Speed/2);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if ((layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
            {
                _dynamicMovement.SetSpeed(_dynamicMovement.Speed*2);
            }
        }
    }
}
