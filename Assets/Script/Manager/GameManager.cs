using System.Collections;
using Cinemachine;
using Script.Animation;
using Script.Controllers;
using Script.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Manager
{
    public class GameManager : SingletonMb<GameManager>
    {
        private static GameManager _instance;
        [SerializeField] private ScoreManager scoreManager;
        public ScoreManager ScoreManager => scoreManager;
        private static GameObject _player;

        public static GameObject Player => _player;

        protected override void Initialize()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _instance = this;
        }

        protected override void Cleanup()
        {
        }

        public void NextLevel(string nextLevel)
        {
            Debug.Log("Helelo");
            LoadScene(nextLevel);
            ScoreManager.SetScore(0);
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            var asyncload = SceneManager.LoadSceneAsync(sceneName);
        }

        public static void SetEffect(string effect)
        {
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

            PlayerAnimation.Death();
            Destroy(_player);
            Debug.Log("Killed");
        }

        private static void Invisibility()
        {
            Debug.Log("Invisible");
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var o in gameObjects)
            {
                MoveToTarget moveToTarget = o.GetComponent<MoveToTarget>();
                if (moveToTarget.Target != null && moveToTarget.Target.CompareTag("Player"))
                    moveToTarget.Target = o;
            }
            _player.tag = "PlayerInvisible";
            var color = _player.GetComponentInChildren<SpriteRenderer>().color;
            color.a = 0.5f;
            _player.GetComponentInChildren<SpriteRenderer>().color = color;
            _instance.StartCoroutine(CancelInvisibility());
        }

        private static IEnumerator CancelInvisibility()
        {
            yield return new WaitForSeconds(10);
            _player.tag = "Player";
            var color = _player.GetComponentInChildren<SpriteRenderer>().color;
            color.a = 1f;
            _player.GetComponentInChildren<SpriteRenderer>().color = color;
            Debug.Log("Visible");
        }


        private static void Invincibility()
        {
            Debug.Log("Invincibility");
            _player.GetComponent<PlayerController>().IsInvincible = true;
            _instance.StartCoroutine(CancelInvincibility());
        }

        private static IEnumerator CancelInvincibility()
        {
            yield return new WaitForSeconds(5);
            _player.GetComponent<PlayerController>().IsInvincible = false;
            Debug.Log("Killable");
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

        public void EndOfLevel()
        {
            GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCMDezoom");
            mainCamera.GetComponent<CinemachineVirtualCamera>().enabled = true;
        }
    }
}