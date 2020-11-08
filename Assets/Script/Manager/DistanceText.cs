using TMPro;
using UnityEngine;

namespace Script.Manager
{
    public class DistanceText : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            UpdateDistance(GameManager.Instance.DistanceManager.Distance);
            GameManager.Instance.DistanceManager.OnDistanceChange += UpdateDistance;
        }

        private void UpdateDistance(float value)
        {
            text.text = ((int) value).ToString();
        }
    }
}