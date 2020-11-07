using Script.Controllers;
using Script.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Manager
{
    public class GameManager : SingletonMb<GameManager>
    {
        [SerializeField] private ScoreManager scoreManager;
        public ScoreManager ScoreManager => scoreManager;
        private static GameObject _player;
        public GameObject Player => _player;

        protected override void Initialize()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
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

        public static void Kill()
        {
            if (_player.GetComponent<PlayerController>().IsInvincible)
            {
                Debug.Log("No Killed");

                return;
            }

            Destroy(_player);
            Debug.Log("Killed");
        }

        private static void Invisibility()
        {
            Debug.Log("Invisible");
            _player.layer = 12;
        }

        private static void Invincibility()
        {
            Debug.Log("Invincibility");
            _player.GetComponent<PlayerController>().IsInvincible = true;
        }

        private static void ChangeForce(int value)
        {
            Debug.Log("Force " + value);
        }

        private static void ChangeSpeed(float value)
        {
            Debug.Log("Speed " + value);
            DynamicMovement dynamicMovement = _player.GetComponent<DynamicMovement>();
            dynamicMovement.Speed += value;
        }
    }
}