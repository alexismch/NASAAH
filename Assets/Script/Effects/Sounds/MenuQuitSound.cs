using System.Collections;
using Script.Manager;
using UnityEngine;

namespace Script.Effects.Sounds
{
    public class MenuQuitSound : Sound
    {
        public new void StartClip()
        {
            base.StartClip();
            StartCoroutine(quit(base.audioClip.length));
        }

        private IEnumerator quit(float duration)
        {
            yield return new WaitForSeconds(duration + 0.2f);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().ExitGame();
        }
    }
}