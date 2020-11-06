using Script.Score;
using UnityEngine;

namespace Script.GameManager
{
    public class GameManager : SingletonMb<GameManager>
    {
        [SerializeField] private ScoreManager scoreManager;
        public ScoreManager ScoreManager => scoreManager;

        protected override void Initialize()
        {
        }
        protected override void Cleanup()
        {
        }
        
    }
}

