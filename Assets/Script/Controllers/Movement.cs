using UnityEngine;

namespace Script.Controllers
{
    public abstract class Movement : MonoBehaviour
    {
        public abstract void Move(float horizontal, float vertical);
    }
}
