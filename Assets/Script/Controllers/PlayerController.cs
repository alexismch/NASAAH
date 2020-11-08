using Script.Animation;
using Script.Manager;
using UnityEngine;

namespace Script.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Movement movement;
        [SerializeField] private bool _isInvincible = false;
        [SerializeField] private ArrowController arrowController;
        [SerializeField] private bool _isArmed;
        [SerializeField] private int force;

        public int Force
        {
            get => force;
            set => force = value;
        }


        private void Awake()
        {
            var o = this.gameObject;
            o.tag = "Player";
            force = 1;
            _isArmed = GameManager.PlayerIsArmed;
            GameManager.SetPlayer(o);
            AudioManager.PlaySpawn();
        }

        // Update is called once per frame
        void Update()
        {
            var hInput = Input.GetAxisRaw("Horizontal");
            var vInput = Input.GetAxisRaw("Vertical");
            movement.Move(hInput, vInput);
            PlayerAnimation.Walk(Mathf.Abs(hInput) , Mathf.Abs(vInput),Mathf.Abs(hInput) + Mathf.Abs(vInput));
            
            //Tire vers la positin de la souris si arme equipée
            if (Input.GetButtonDown("Fire1") && _isArmed)
            {
                PlayerAnimation.Attack();
                var pos = Input.mousePosition;
                pos.z = transform.position.z - Camera.main.transform.position.z;
                pos = Camera.main.ScreenToWorldPoint(pos);
                var q = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
                arrowController.Fire(q, force);
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