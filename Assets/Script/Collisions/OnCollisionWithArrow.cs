using Script.Pooling;
using UnityEngine;

namespace Script.Collisions
{
    public class OnCollisionWithArrow : MonoBehaviour

    {
        // Start is called before the first frame update
        [SerializeField] private LayerMask layerMask;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
            {
                gameObject.TryRelease();
                //other.TryRelease();
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
