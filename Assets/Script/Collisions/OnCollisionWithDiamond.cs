using UnityEngine.Events;
using UnityEngine;

namespace Script.Collisions
{
    public class OnCollisionWithDiamond : MonoBehaviour
    
    {
        [SerializeField] private UnityEvent onDestroyed;
        [SerializeField] private LayerMask layerMask;

        
        private void OnTriggerEnter2D(Collider2D other)
        {
            
            Debug.Log("yo");
            if ((layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
            {
                onDestroyed?.Invoke();
                Destroy(transform.gameObject);
            }
            
        }

        public enum Effects
        {
            
        }
        
        
    }
}