using System.Collections;
using System.Collections.Generic;
using Script.Manager;
using UnityEngine;

namespace Script.Effects
{
    public class MenuRestartSound : Sound
    {
        public new void StartClip()
        {
            base.StartClip();
            StartCoroutine(nextLvl(base.audioClip.length));
        }

        private IEnumerator nextLvl(float duration)
        {
            yield return new WaitForSeconds(duration + 0.2f);
            GameManager gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            gameManager.ResetLevels();
            gameManager.NextLevel();
        }
    }
}