using System;
using Script.Animation;
using UnityEngine;

namespace Script.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Movement movement;
        [SerializeField] private bool _isInvincible = false;
        private PlayerAnimation _playerAnimation;
        [SerializeField] private ArrowController arrowController;
        private Vector3 _worldPosition;

        private void Awake()
        {
            gameObject.tag = "Player";
            _playerAnimation = GetComponent<PlayerAnimation>();
        }

        // Update is called once per frame
        void Update()
        {
            var hInput = Input.GetAxisRaw("Horizontal");
            var vInput = Input.GetAxisRaw("Vertical");
            movement.Move(hInput, vInput);
            _playerAnimation.Walk(Mathf.Abs(hInput)+Mathf.Abs(vInput));
            if (Input.GetButtonDown("Fire1"))
            {
                _playerAnimation.Attack();
                
                
                var pos = Input.mousePosition;
                pos.z = transform.position.z - Camera.main.transform.position.z;
                pos = Camera.main.ScreenToWorldPoint(pos);
                var q = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
                arrowController.Fire(q);
                
                
               
            }
                

        }

        public bool IsInvincible
        {
            get => _isInvincible;
            set => _isInvincible = value;
        }
    }
}