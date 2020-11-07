using System;
using Script.Animation;
using UnityEngine;

namespace Script.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Movement movement;
        [SerializeField] private bool _isInvincible = false;
        [SerializeField] private ArrowController arrowController;
        private Vector3 _worldPosition;
        [SerializeField] private bool _isArmed;

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
            PlayerAnimation.Walk(Mathf.Abs(hInput)+Mathf.Abs(vInput));
            if (Input.GetButtonDown("Fire1") && _isArmed)
            {
                PlayerAnimation.Attack();
                
                
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

        public void TakeWeapon()
        {
            _isArmed = true;
            PlayerAnimation.Take();
        }
    }
}