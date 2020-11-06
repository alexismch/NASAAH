using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Controllers
{
    public class PatrolController : MonoBehaviour
    {
        [SerializeField] private GameObject[] targetList;
        [SerializeField] private MoveToTarget moveToTarget;

        private GameObject _currentTarget;
        private int _indexListTarget = 0;

        private void Awake()
        {
            _currentTarget = targetList[_indexListTarget];
            moveToTarget.SetTarget(_currentTarget);
        }

        private void Update()
        {
            if (((Vector2)(_currentTarget.transform.position - gameObject.transform.position)).magnitude <= 2)
            {
                _indexListTarget++;
                _currentTarget = targetList[_indexListTarget%targetList.Length];
                moveToTarget.SetTarget(_currentTarget);

            }
        }
    }
}
