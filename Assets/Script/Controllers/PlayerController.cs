using UnityEngine;

namespace Script.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Movement movement;
        private bool _isInvincible = false;

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
