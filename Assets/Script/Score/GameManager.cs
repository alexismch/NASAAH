using Script.Score;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Score
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
        public void NextLevel2()
        {
            Debug.Log("Helelo");
            LoadScene("Level2");
            ScoreManager.SetScore(0);
        }
        
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            var asyncload = SceneManager.LoadSceneAsync(sceneName);
        }
        
    }
}

