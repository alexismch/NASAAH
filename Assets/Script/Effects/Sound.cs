using Script.Manager;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Effects
{
    public class Sound : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip audioClip;

        public void StartClip()
        {
            audioSource.PlayOneShot(audioClip, 1f);
            Debug.Log(audioClip);
        }
    }
}