using Script.Effects;
using Script.Pooling;
using UnityEngine;

namespace Script.Collisions
{
    public class OnCollisionWithArrow : MonoBehaviour

    {
        //Force de la flèche ainsi que sa position de départ
        private int _force = 0;
        private Vector3 _ogPos;

        public int Force
        {
            get => _force;
            set => _force = value;
        }

        public Vector3 OgPos
        {
            get => _ogPos;
            set => _ogPos = value;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            gameObject.TryRelease();
            if (!other.gameObject.CompareTag("Enemy")) return;
            other.GetComponent<Knockback>().Push(_force, _ogPos);
        }
    }
}