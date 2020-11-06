using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Effects
{
    [CreateAssetMenu(menuName = "Effect Table")]
    public class EffectsTable : ScriptableObject
    {
        [SerializeField] private List<WeightedObject> table;
        private int _totalWeight;
        private void Awake()
        {
            _totalWeight = 0;
            foreach (var item in table)
            {
                _totalWeight += item.weight;
            }
        }
        public string ChooseEffect()
        {
            string result = null;
            var roll = Random.Range(0, _totalWeight+1);
            var cursor = 0;
            for (int i = 0; i < table.Count; i++)
            {
                cursor += table[i].weight;
                if (cursor < roll) continue;
                result = table[i].effect;
                break;
            }
            return result;
        }
    }
}

[System.Serializable]
public struct WeightedObject
{
    public int weight;
    public string effect;
}