using UnityEngine;

namespace Script.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Movement movement;

        // Update is called once per frame
        void Update()
        {
            var hInput = Input.GetAxisRaw("Horizontal");
            var vInput = Input.GetAxisRaw("Vertical");
            movement.Move(hInput, vInput);
        }
    }
}
