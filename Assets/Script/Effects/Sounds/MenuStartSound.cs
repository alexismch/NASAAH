using System.Collections;
using Script.Manager;
using UnityEngine;

namespace Script.Effects.Sounds
{
    public class MenuStartSound : Sound
    {
        public new void StartClip()
        {
            base.StartClip();
            StartCoroutine(nextLvl(base.audioClip.length));
        }

        private IEnumerator nextLvl(float duration)
        {
            yield return new WaitForSeconds(duration + 0.2f);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().NextLevel();
        }
    }
}