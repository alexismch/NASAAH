using System;
using UnityEngine;

namespace Script.Manager
{
    public class DistanceManager : MonoBehaviour
    {
        [SerializeField] private float currentDistance;
        public Action<float> OnDistanceChange;

        public float Distance => currentDistance;

        private void Awake()
        {
            currentDistance = 0;
        }

        public void ResetDistance()
        {
            currentDistance = 0;
        }

        public void SetDistance(float distance)
        {
            currentDistance = distance;
            OnDistanceChange(currentDistance);
        }

        public void AddDistance(float value)
        {
            SetDistance(currentDistance + value);
        }
    }
}
