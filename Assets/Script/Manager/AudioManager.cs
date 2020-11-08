using System;
using Script.Effects;
using UnityEngine;

namespace Script.Controllers
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager _instance;
        
        private void Start()
        {
            _instance = this;
        }

        public static void PlayLevelReached()
        {
            _instance.GetComponent<LevelReachedSound>().StartClip();
        }

        public static void PlayDead()
        {
            _instance.GetComponent<DeadSound>().StartClip();
        }

        public static void PlaySpawn()
        {
            _instance.GetComponent<SpawnSound>().StartClip();
        }
    }
}