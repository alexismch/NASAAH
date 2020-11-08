using UnityEngine.Events;
using UnityEngine;

namespace Script.Collisions
{
    public class OnCollisionWithDiamond : MonoBehaviour

    {
        [SerializeField] private UnityEvent onDestroyed = null;
        [SerializeField] private LayerMask layerMask = new LayerMask();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
            {
                onDestroyed?.Invoke();
                Destroy(transform.gameObject);
            }
        }
    }
}