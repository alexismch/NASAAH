using System;
using System.Collections;
using Script.Manager;
using UnityEngine;

namespace Script.Controllers
{
    public class TurretController : MonoBehaviour
    {
        private MoveToTarget _moveToTarget;
        private bool _isMoving;

        private void Awake()
        {
            _moveToTarget = GetComponent<MoveToTarget>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _isMoving = true;
                var player = GameManager.Player;
                _moveToTarget.SetTarget(player);
            }
        }

        private void Update()
        {
            if (!_isMoving)
            {
                transform.Rotate(0, 0, 50 * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}