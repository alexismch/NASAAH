using UnityEngine;

namespace Script.Controllers
{
    
    public class MoveToTarget : MonoBehaviour
    {
        [SerializeField] Movement movement;
        [SerializeField] private GameObject target;
        [SerializeField] private GameManager.GameManager gameManager;
        
        // Update is called once per frame
        void Update()
        {
            if (!target)
                target = gameManager.Player;
            var direction = ((Vector2)(target.transform.position - gameObject.transform.position)).normalized;

            //récupération de la position horizontale du player
            var hInput = direction.x;
            //récupération de la position verticale du player
            var vInput = direction.y;
            movement.Move(hInput, vInput);
        }

        public void SetTarget(GameObject newTarget)
        {
            target = newTarget;
        }
    }
}
