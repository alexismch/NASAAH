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

        //Ralenti et applique un effet transparent sur le mob
        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
            {
                _dynamicMovement.Speed /= 2;
                var color = gameObject.GetComponentInParent<Rigidbody2D>().GetComponentInChildren<SpriteRenderer>()
                    .color;
                color.a = 0.5f;
                gameObject.GetComponentInParent<Rigidbody2D>().GetComponentInChildren<SpriteRenderer>().color = color;
            }
        }

        //Reinitialise la vitesse et apparence de départ
        private void OnTriggerExit2D(Collider2D other)
        {
            if (((layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer))
            {
                _dynamicMovement.Speed *= 2;
                var color = gameObject.GetComponentInParent<Rigidbody2D>().GetComponentInChildren<SpriteRenderer>()
                    .color;
                color.a = 1f;
                gameObject.GetComponentInParent<Rigidbody2D>().GetComponentInChildren<SpriteRenderer>().color = color;
            }
        }
    }
}