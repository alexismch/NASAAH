using UnityEngine;

namespace Script.Score
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private int points;

        public void ScorePoints()
        {
            GameManager.GameManager.Instance.ScoreManager.AddScore();
        }
    }
}