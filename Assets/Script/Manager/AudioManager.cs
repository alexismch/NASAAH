using System;
using System.Collections.Generic;
using Script.Effects;
using UnityEngine;

namespace Script.Controllers
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager _instance;
        private static Dictionary<String, Sound> _sounds = new Dictionary<string, Sound>();

        private void Start()
        {
            _instance = this;
        }

        public static void PlayLevelReached()
        {
            Sound levelReachedSound;
            _sounds.TryGetValue("LevelReachedSound", out levelReachedSound);
            if (!levelReachedSound)
            {
                levelReachedSound = _instance.GetComponent<LevelReachedSound>();
                _sounds.Add("LevelReachedSound", levelReachedSound);
            }

            levelReachedSound.StartClip();
        }

        public static void PlayDead()
        {
            Sound deadSound;
            _sounds.TryGetValue("DeadSound", out deadSound);
            if (!deadSound)
            {
                deadSound = _instance.GetComponent<DeadSound>();
                _sounds.Add("DeadSound", deadSound);
            }

            deadSound.StartClip();
        }

        public static void PlaySpawn()
        {
            Sound spawnSound;
            _sounds.TryGetValue("SpawnSound", out spawnSound);
            if (!spawnSound)
            {
                spawnSound = _instance.GetComponent<SpawnSound>();
                _sounds.Add("SpawnSound", spawnSound);
            }

            spawnSound.StartClip();
        }

        public static void PlayArrowFired()
        {
            Sound arrowFiredSound;
            _sounds.TryGetValue("ArrowFiredSound", out arrowFiredSound);
            if (!arrowFiredSound)
            {
                arrowFiredSound = _instance.GetComponent<ArrowFiredSound>();
                _sounds.Add("ArrowFiredSound", arrowFiredSound);
            }
            arrowFiredSound.StartClip();
        }
    }
}