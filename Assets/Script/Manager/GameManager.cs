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
            Debug.Log(effect);
            switch (effect)
            {
                case "SpeedBoost":
                    changeSpeed(1);
                    break;
                case "SpeedDebuf":
                    changeSpeed(-1);
                    break;
                case "ForceBoost":
                    changeForce(1);
                    break;
                case "ForceDebuf":
                    changeForce(-1);
                    break;
                case "Invincibility":
                    invincibility();
                    break;
                case "Invisibility":
                    invisibility();
                    break;
                case "InstantDie":
                    kill();
                    break;
            }
        }

        private static void kill()
        {
            Debug.Log("Kill");
        }

        private static void invisibility()
        {
            Debug.Log("Invisible");
        }

        private static void invincibility()
        {
            Debug.Log("Invincible");
        }

        private static void changeForce(int value)
        {
            Debug.Log("Force " + value);
        }

        private static void changeSpeed(int value)
        {
            Debug.Log("Speed " + value);
        }
    }
}

