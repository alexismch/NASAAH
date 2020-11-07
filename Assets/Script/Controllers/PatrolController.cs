using System;
using UnityEngine;
using Script.Manager;

namespace Script.Controllers
{
    public class PatrolController : MonoBehaviour
    {
        [SerializeField] private GameObject[] targetList;
        [SerializeField] private MoveToTarget moveToTarget;
        [SerializeField] private GameManager gameManager;

        private GameObject _currentTarget;
        private int _indexListTarget = 0;
        private Transform _currentTargetTransform;
        private Transform _selfTransform;
        private Boolean _isInPatrol = true;

        private void Awake()
        {
            _currentTarget = targetList[_indexListTarget];
            moveToTarget.SetTarget(_currentTarget);
            _currentTargetTransform = _currentTarget.transform;
            _selfTransform = gameObject.transform;
        }

        private void Update()
        {
            if (_isInPatrol && ((Vector2) (_currentTargetTransform.position - _selfTransform.position)).magnitude <= 2)
            {
                _indexListTarget = (_indexListTarget + 1) % targetList.Length;
                _currentTarget = targetList[_indexListTarget];
                moveToTarget.SetTarget(_currentTarget);
                _currentTargetTransform = _currentTarget.transform;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _isInPatrol = false;
                moveToTarget.SetTarget(gameManager.Player);
            }
        }
    }
}