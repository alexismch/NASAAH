using System;
using UnityEngine;

namespace Script.Score
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private int _currentScore;
        [SerializeField] private int _maxScore;
        public Action<int> onScoreChange;
        public int Score => _currentScore;
    
        private void Awake()
        {
            _currentScore = 0;
        }
        public void AddScore()
        {
            _currentScore++ ;
        
        }
    }
}