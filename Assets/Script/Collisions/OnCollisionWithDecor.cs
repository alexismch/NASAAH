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
            _dynamicMovement = GetComponentInParent<DynamicMovement>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
            {
                _dynamicMovement.Speed /= 2;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if ((layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
            {
                _dynamicMovement.Speed *= 2;
            }
        }
    }
}
