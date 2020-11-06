using UnityEngine;

namespace Script.Controllers
{
    
    public class MoveToTarget : MonoBehaviour
    {
        [SerializeField] Movement movement;
        [SerializeField] private GameObject target;

        // Update is called once per frame
        void Update()
        {
            var direction = (target.transform.position - gameObject.transform.position).normalized;

            //récupération de la position horizontale du player
            var hInput = direction.x;
            //récupération de la position verticale du player
            var vInput = direction.y;
            movement.Move(hInput, vInput);
        }

        void SetTarget(GameObject newTarget)
        {
            target = newTarget;
        }
    }
}
