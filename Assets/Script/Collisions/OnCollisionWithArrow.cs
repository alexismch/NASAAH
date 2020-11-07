using Script.Effects;
using Script.Pooling;
using UnityEngine;

namespace Script.Collisions
{
    public class OnCollisionWithArrow : MonoBehaviour

    {
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

        // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D other)
        {
            gameObject.TryRelease();
            if (!other.gameObject.CompareTag("Enemy")) return;
            Debug.Log("je passe");
            other.GetComponent<Knockback>().Push(_force, _ogPos);
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}