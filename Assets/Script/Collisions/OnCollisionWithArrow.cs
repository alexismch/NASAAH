using Script.Effects;
using Script.Pooling;
using UnityEngine;

namespace Script.Collisions
{
    public class OnCollisionWithArrow : MonoBehaviour

    {
        private int force = 0;
        private Vector3 OGPos;

        public void SetForce(int force)
        {
            this.force = force;
        }

        public void SetOGPos(Vector3 OGPos)
        {
            this.OGPos = OGPos;
        }

        // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D other)
        {
            gameObject.TryRelease();
            var gameObjectBody = other.attachedRigidbody.gameObject;
            if (!gameObjectBody.CompareTag("Enemy")) return;
            Debug.Log("je passe");
            gameObjectBody.GetComponent<Knockback>().Push(force, OGPos);
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}