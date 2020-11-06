using Script.Manager;
using UnityEngine;

namespace Script.Effects
{
    public class Effects : MonoBehaviour
    {
        [SerializeField] private EffectsTable effectsTable;

        public void ChooseEffect()
        {
            string effect = effectsTable.ChooseEffect();
            if (effect != null)
                GameManager.SetEffect(effect);
        }
    }
}
