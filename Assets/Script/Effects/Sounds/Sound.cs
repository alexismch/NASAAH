using UnityEngine;

namespace Script.Effects
{
    public delegate void CallBack();
    
    public class Sound : MonoBehaviour
    {
        [SerializeField] protected AudioSource audioSource;
        [SerializeField] protected AudioClip audioClip;

        public void StartClip()
        {
            audioSource.PlayOneShot(audioClip, 1f);
            Debug.Log(audioClip);
        }
    }
}