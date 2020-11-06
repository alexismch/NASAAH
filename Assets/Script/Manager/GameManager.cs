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
                    ChangeSpeed(1);
                    break;
                case "SpeedDebuf":
                    ChangeSpeed(-1);
                    break;
                case "ForceBoost":
                    ChangeForce(1);
                    break;
                case "ForceDebuf":
                    ChangeForce(-1);
                    break;
                case "Invincibility":
                    Invincibility();
                    break;
                case "Invisibility":
                    Invisibility();
                    break;
                case "InstantDie":
                    Kill();
                    break;
            }
        }

        private static void Kill()
        {
            Debug.Log("Kill");
        }

        private static void Invisibility()
        {
            Debug.Log("Invisible");
        }

        private static void Invincibility()
        {
            Debug.Log("Invincible");
        }

        private static void ChangeForce(int value)
        {
            Debug.Log("Force " + value);
        }

        private static void ChangeSpeed(int value)
        {
            Debug.Log("Speed " + value);
        }
    }
}

