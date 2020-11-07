using Script.Pooling;
using UnityEngine;

namespace Script.Controllers
{
    public class ArrowController : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform projectileSpawner;
    
    

        public void Fire(Quaternion q)
        {
            if (projectilePrefab.TryAcquire(out var projectile) == false)
                return;
            var t = projectile.transform;
            t.position = projectileSpawner.position;
            t.rotation = q;
            var rb = projectile.GetComponent<Rigidbody2D>();
            rb.AddForce(projectile.transform.up * 500);
            projectile.layer = gameObject.layer;
       
        }
    }
}
