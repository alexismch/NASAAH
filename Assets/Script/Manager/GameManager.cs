using Script.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Manager{
    public class GameManager : SingletonMb<GameManager>
    {
        [SerializeField] private ScoreManager scoreManager;
        public ScoreManager ScoreManager => scoreManager;
        [SerializeField] private GameObject player;
        public GameObject Player => player;

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

        public static void SetEffect(string effect)
        {
            //
        }
    }
}

