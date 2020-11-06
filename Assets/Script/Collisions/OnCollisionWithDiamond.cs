using UnityEngine.Events;
using UnityEngine;

namespace Script.Collisions
{
    public class OnCollisionWithDiamond : MonoBehaviour
    {
        [SerializeField] private UnityEvent onDestroyed;

        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("yo");
            onDestroyed?.Invoke();
            Destroy(transform.gameObject);
        }

        public enum Effects
        {
            SpeedBoost,
            SpeedDebuf,
            ForceBoost,
            ForceDebuf,
            Invisibility,
            Invincibility,
            InstantDie,
    }
        
        
    }
}