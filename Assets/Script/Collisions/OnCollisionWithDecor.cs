using System;
using Script.Controllers;
using Script.Pooling;
using UnityEngine;
using UnityEngine.Events;

namespace Script.Collisions
{
    public class OnCollisionWithDecor : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private UnityEvent onDestroyed;
        [SerializeField] private AffectedObject affectedObject;

        private DynamicMovement _dynamicMovement;

        private void Awake()
        {
            _dynamicMovement = GetComponentInParent<DynamicMovement>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
            {
                switch (affectedObject)
                {
                    case(AffectedObject.Arrow):
                        Debug.Log("Dois se detruire");
                        DestroyObjects(other.attachedRigidbody.gameObject);
                        break;
                    case(AffectedObject.Diamond):
                        onDestroyed?.Invoke();
                        Destroy(transform.gameObject);
                        break;
                    case(AffectedObject.Enemy):
                        _dynamicMovement.Speed /= 2;
                        var color = gameObject.GetComponentInParent<Rigidbody2D>().GetComponentInChildren<SpriteRenderer>().color;
                        color.a = 0.5f;
                        gameObject.GetComponentInParent<Rigidbody2D>().GetComponentInChildren<SpriteRenderer>().color = color;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (((layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer) && affectedObject == AffectedObject.Enemy)
            {
                _dynamicMovement.Speed *= 2;
                var color = gameObject.GetComponentInParent<Rigidbody2D>().GetComponentInChildren<SpriteRenderer>().color;
                color.a = 1f;
                gameObject.GetComponentInParent<Rigidbody2D>().GetComponentInChildren<SpriteRenderer>().color = color;
            }
        }
        private void DestroyObjects(GameObject other)
        {
            gameObject.TryRelease();
            //other.TryRelease();
        }
        public enum AffectedObject
        {
            Arrow,
            Diamond,
            Enemy,
        }
        
    }
}