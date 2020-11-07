using UnityEngine;

namespace Script.Effects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Knockback : MonoBehaviour
    {
        public void Push(int force, Vector3 OGPos)
        {
            Debug.Log("dans le knock");
            var t = gameObject.transform;
            var dir = ((Vector2) ((t.position - OGPos)*0.05f*force));
            gameObject.GetComponent<Rigidbody2D>().AddForce(dir);
        }
    }
}
