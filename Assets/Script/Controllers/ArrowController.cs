using Script.Collisions;
using Script.Manager;
using Script.Pooling;
using UnityEngine;

namespace Script.Controllers
{
    public class ArrowController : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform projectileSpawner;

        
        //Tire une flèche de la pool avec une force et un angle
        public void Fire(Quaternion q, int force)
        {
            if (projectilePrefab.TryAcquire(out var projectile) == false)
                return;

            var t = projectile.transform;
            t.position = projectileSpawner.position;
            t.rotation = q;
            projectile.GetComponent<OnCollisionWithArrow>().Force = force;
            projectile.GetComponent<OnCollisionWithArrow>().OgPos = t.position;
            var rb = projectile.GetComponent<Rigidbody2D>();
            rb.AddForce(projectile.transform.up * 500);
            AudioManager.PlayArrowFired();
        }
    }
}