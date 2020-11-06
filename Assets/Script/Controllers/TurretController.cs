using System;
using System.Collections;
using Script.Manager;
using UnityEngine;

namespace Script.Controllers
{
    public class TurretController : MonoBehaviour
    {
        [SerializeField] private MoveToTarget moveToTarget;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float maxAngleRotation;

        private Transform _transform;
        private int clockwiseRotation = 1;
        private float _initialRotation;

        private void Awake()
        {
            _transform = transform;
            _initialRotation = _transform.rotation.z;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            moveToTarget.SetTarget(gameManager.Player);
        }

        private void Update()
        {
            //Définir le sens de rotation. Quand on arrive au bout, on fait clockwiseRotation = -clockwiseRotation
            //détecter quand on est au bout de la rotation
            
            if (Math.Abs(_transform.rotation.z - (_initialRotation + maxAngleRotation)) == 0 || Math.Abs(_transform.rotation.z - (_initialRotation - maxAngleRotation)) == 0)
            {
                clockwiseRotation = -clockwiseRotation;
            }
            //Tourner auto de maxAngleRotation jusqu'à -maxAngleRotation
        }
    }
}
