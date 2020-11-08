using System;
using System.Collections;
using UnityEngine;

namespace Script.Manager
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private int currentScore;
        public Action<int> ONScoreChange;
        private string[] levels = {"Discover", "Discover Enemy","DesertCity","BeachPeanutMap","CityMap"};
        private int lvl = 0;

        public int Score => currentScore;

        public string GetLevel()
        {
            return levels[lvl];
        }
        
        public string GetLevel(int num)
        {
            return levels[num];
        }

        public void IncLvl()
        {
            lvl++;
        }

        public void ResetLevels()
        {
            lvl = 0;
        }

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
            if (currentScore == 10)
            {
                currentScore = 0;
                GameManager.Instance.EndOfLevel();
                StartCoroutine(WaitToChangeLevel());
            }
        }

        private IEnumerator WaitToChangeLevel()
        {
            yield return new WaitForSeconds(3);
            GameManager.Instance.NextLevel();
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