using System;
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
            _moveToTarget.Target = GameManager.Player;
        }
    }
}
