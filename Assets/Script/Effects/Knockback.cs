using UnityEngine;

namespace Script.Effects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Knockback : MonoBehaviour
    {
        //Pousse le monstre en fonction de la force du joueur
        public void Push(int force, Vector3 OGPos)
        {
            var t = gameObject.transform;
            var dir = ((Vector2) ((t.position - OGPos)).normalized) * 0.1f * force;
            gameObject.GetComponent<Rigidbody2D>().AddForce(dir);
        }
    }
}