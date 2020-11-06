
using UnityEngine;

namespace Script.Collisions
{
    public class OnCollisionDestroy : MonoBehaviour
    {

        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("yo");
        }
        
    }
}