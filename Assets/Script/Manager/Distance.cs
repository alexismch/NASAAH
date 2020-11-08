using UnityEngine;

namespace Script.Manager
{
    public class Distance : MonoBehaviour
    {
        private Vector3 _lastPosition;


        void Start()
        {
            _lastPosition = transform.position;
        }


        void Update()
        {
            var position = transform.position;
            GameManager.Instance.DistanceManager.AddDistance(Vector3.Distance(position, _lastPosition));
            _lastPosition = position;
        }
    }
}
