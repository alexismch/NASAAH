using Script.Manager;
using UnityEngine;

namespace Script.Controllers
{
    public class FollowController : MonoBehaviour
    {
        private MoveToTarget _moveToTarget;

        private void Awake()
        {
            _moveToTarget = GetComponent<MoveToTarget>();
        }

        private void Start()
        {
            if (!_moveToTarget.Target)
                _moveToTarget.Target = GameManager.Player;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _moveToTarget.Target = GameManager.Player;
            }
        }
    }
}