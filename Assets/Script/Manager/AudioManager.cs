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
            StartClip(typeof(LevelReachedSound));
        }

        public static void PlayDead()
        {
            StartClip(typeof(DeadSound));
        }

        public static void PlaySpawn()
        {
            StartClip(typeof(SpawnSound));
        }

        public static void PlayArrowFired()
        {
            StartClip(typeof(ArrowFiredSound));
        }

        public static void Kamikaze()
        {
            StartClip(typeof(KamikazeSound));
        }

        private static void StartClip(Type soundType)
        {
            Sound sound;
            _sounds.TryGetValue(soundType.Name, out sound);
            if (!sound)
            {
                sound = (Sound) _instance.GetComponent(soundType);
                _sounds.Add(soundType.Name, sound);
            }

            sound.StartClip();
        }
    }
}