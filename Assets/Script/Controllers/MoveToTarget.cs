using UnityEngine;

namespace Script.Controllers
{
    public class MoveToTarget : MonoBehaviour
    {
        [SerializeField] Movement movement;
        [SerializeField] private GameObject target;

        public GameObject Target
        {
            get => target;
            set => target = value;
        }

        private void Awake()
        {
            gameObject.tag = "Enemy";
        }

        void Update()
        {
            //récupération de la position du player et deplacement vers cette position
            if (target)
            {
                var direction = ((Vector2) (target.transform.position - gameObject.transform.position)).normalized;
                var hInput = direction.x;
                var vInput = direction.y;
                movement.Move(hInput, vInput);
            }
        }
    }
}