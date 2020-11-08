using UnityEngine;

namespace Script.Manager
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private int points = 0;

        public void ScorePoints()
        {
            GameManager.Instance.ScoreManager.AddScore(points);
        }
    }
}