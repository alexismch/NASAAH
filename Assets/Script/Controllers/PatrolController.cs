using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Controllers
{
    public class PatrolController : MonoBehaviour
    {
        [SerializeField] private GameObject[] targetList;
        [SerializeField] private MoveToTarget moveToTarget;

        private GameObject _actualTarget;
        private int _indexListTarget = 0;

        private void Awake()
        {
            _actualTarget = targetList[_indexListTarget];
            moveToTarget.SetTarget(_actualTarget);
        }

        private void Update()
        {
            if ((gameObject.transform.position - _actualTarget.transform.position).magnitude <= 10)
            {
                _indexListTarget++;
                _actualTarget = targetList[(_indexListTarget%targetList.Length)];
                moveToTarget.SetTarget(_actualTarget);
            }
        }
    }
}
