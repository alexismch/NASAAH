using UnityEngine;

namespace Script.Effects.Sounds
{
    public delegate void CallBack();
    
    public class Sound : MonoBehaviour
    {
        [SerializeField] protected AudioSource audioSource;
        [SerializeField] protected AudioClip audioClip;

        public void StartClip()
        {
            audioSource.PlayOneShot(audioClip, 1f);
        }
    }
}