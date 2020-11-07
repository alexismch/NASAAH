using System;
using UnityEngine;

namespace Script.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Movement movement;
        [SerializeField] private bool _isInvincible = false;

        private void Awake()
        {
            gameObject.tag = "Player";
        }

        // Update is called once per frame
        void Update()
        {
            var hInput = Input.GetAxisRaw("Horizontal");
            var vInput = Input.GetAxisRaw("Vertical");
            movement.Move(hInput, vInput);
        }

        public bool IsInvincible
        {
            get => _isInvincible;
            set => _isInvincible = value;
        }
    }
}