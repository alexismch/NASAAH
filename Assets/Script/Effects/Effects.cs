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
            GameManager.SetEffect(effect);
        }
    }
}