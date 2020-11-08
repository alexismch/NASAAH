using System;
using System.Collections;
using Cinemachine;
using Script.Animation;
using Script.Controllers;
using Script.Manager;
using Script.Pooling;
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
        private static bool _playerIsArmed = false;

        public static bool PlayerIsArmed => _playerIsArmed;

        public static void SetPlayer(GameObject player)
        {
            _player = player;
        }

        public static GameObject Player => _player;

        protected override void Initialize()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _instance = this;
        }

        protected override void Cleanup()
        {
        }

        public void NextLevel()
        {
            NextLevel(scoreManager.GetLevel());
        }

        public void NextLevel(string lvl)
        {
            LoadScene(lvl);
            if (!lvl.Equals(scoreManager.GetLevel(0)))
                ScoreManager.SetScore(0);
            scoreManager.IncLvl();
            ObjectPool.ResetPools();
        }
        
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            var asyncload = SceneManager.LoadSceneAsync(sceneName);
        }


        public void ExitGame()
        {
            Application.Quit();
        }

        public static void SetEffect(string effect)
        {
            switch (effect)
            {
                case "SpeedBoost":
                    ChangeSpeed(1);
                    AnnounceEffect(effect);
                    break;
                case "SpeedDebuf":
                    ChangeSpeed(-1);
                    AnnounceEffect(effect);
                    break;
                case "ForceBoost":
                    ChangeForce(1);
                    AnnounceEffect(effect);
                    break;
                case "ForceDebuf":
                    ChangeForce(-1);
                    AnnounceEffect(effect);
                    break;
                case "Invincibility":
                    Invincibility();
                    AnnounceEffect(effect);
                    break;
                case "Invisibility":
                    Invisibility();
                    AnnounceEffect(effect);
                    break;
                case "InstantDie":
                    Kill();
                    AnnounceEffect(effect);
                    break;
            }
        }

        public static void AnnounceEffect(string effect)
        {
            var announcer = GameObject.FindWithTag("Announcer");
            announcer.GetComponent<EffectAnimation>()?.AnnounceEffect(effect);
        }

        public static void Kill()
        {
            if (_player.GetComponent<PlayerController>().IsInvincible)
            {
                Debug.Log("No Killed");
                return;
            }

            PlayerAnimation.Death();
            _instance.StartCoroutine(KillPlayer());
            Debug.Log("Killed");
        }

        private static IEnumerator KillPlayer()
        {
            yield return new WaitForSeconds(30 / 60f);
            Destroy(_player);
            _instance.NextLevel("Game Over");
        }

        private static void Invisibility()
        {
            Debug.Log("Invisible");
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var o in gameObjects)
            {
                Debug.Log(o.name);
                MoveToTarget moveToTarget = o.GetComponent<MoveToTarget>();
                if(moveToTarget == null)
                    continue;
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
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var o in gameObjects)
                o.SetActive(false);
            GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCMDezoom");
            mainCamera.GetComponent<CinemachineVirtualCamera>().enabled = true;
        }

        public static void TakeWeapon()
        {
            _playerIsArmed = true;
            Debug.Log(_player);
            _player.GetComponent<PlayerController>().TakeWeapon();
        }

        public void ResetLevels()
        {
            scoreManager.ResetLevels();
        }
    }
}