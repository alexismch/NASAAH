using System;
using System.Collections;
using UnityEngine;

namespace Script.Manager
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private string nextLevel;
        [SerializeField] private int currentScore;
        public Action<int> ONScoreChange;

        public int Score => currentScore;

        private void Awake()
        {
            currentScore = 0;
        }

        private void OnDisable()
        {
            currentScore = 0;
        }

        private void Update()
        {
            if (currentScore == 1)
            {
                currentScore = 0;
                GameManager.Instance.EndOfLevel();
                StartCoroutine(WaitToChangeLevel());
            }
        }

        private IEnumerator WaitToChangeLevel()
        {
            yield return new WaitForSeconds(3);
            GameManager.Instance.NextLevel(nextLevel);
        }


        public void SetScore(int score)
        {
            currentScore = score;
            ONScoreChange(currentScore);
        }

        public void AddScore(int value)
        {
            SetScore(currentScore + value);
        }
    }
}