using Script.Pooling;
using UnityEngine;

namespace Script.Collisions
{
    public class OnCollisionWithArrow : MonoBehaviour

    {
        private int force = 0;
        private Quaternion q;

        public void SetForce(int force)
        {
            this.force = force;
        }
        // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D other)
        {
          gameObject.TryRelease();
          var gameObjectBody = other.attachedRigidbody.gameObject;
          if(!gameObjectBody.CompareTag("Enemy")) return;
          

        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
