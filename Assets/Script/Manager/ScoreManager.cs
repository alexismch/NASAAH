﻿using System;
using System.Collections;
using UnityEngine;

namespace Script.Manager
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private int _currentScore;
        public Action<int> onScoreChange;
        public int Score => _currentScore;

        private void Awake()
        {
            _currentScore = 0;
        }

        private void OnDisable()
        {
            _currentScore = 0;
        }

        private void Update()
        {
            if (_currentScore == 1)
            {
                GameManager.Instance.EndOfLevel();
                _currentScore = 0;
                StartCoroutine(ChangeLevel());
            }
        }

        private IEnumerator ChangeLevel()
        {
            yield return new WaitForSeconds(3);
            GameManager.Instance.NextLevel2();
        }


        public void SetScore(int score)
        {
            _currentScore = score;
            onScoreChange(_currentScore);
        }

        public void AddScore(int value)
        {
            SetScore(_currentScore + value);
        }
    }
}