using Script.Score;
using UnityEngine;

namespace Script.GameManager
{
    public class GameManager : SingletonMb<GameManager>
    {
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private GameObject player;
        public ScoreManager ScoreManager => scoreManager;
        public GameObject Player => player;

        protected override void Initialize()
        {
        }
        protected override void Cleanup()
        {
        }
        
    }
}

