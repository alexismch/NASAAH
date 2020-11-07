using System;
using Script.Manager;
using UnityEngine;
using UnityEngine.Serialization;

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

        // Update is called once per frame
        void Update()
        {
            if (target)
            {
                var direction = ((Vector2) (target.transform.position - gameObject.transform.position)).normalized;
                //récupération de la position horizontale du player
                var hInput = direction.x;
                //récupération de la position verticale du player
                var vInput = direction.y;
                movement.Move(hInput, vInput);
            }
        }
    }
}