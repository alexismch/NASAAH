using Script.Manager;
using UnityEngine;

namespace Script.Effects
{
    public class Effects : MonoBehaviour
    {
        [SerializeField] private EffectsTable effectsTable = null;

        public void ChooseEffect()
        {
            string effect = effectsTable.ChooseEffect();
            if (effect != null)
                Debug.Log("Launch effect : " + effect);
            GameManager.SetEffect(effect);
        }
    }
}