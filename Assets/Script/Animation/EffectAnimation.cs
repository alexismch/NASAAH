using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Animation
{
    public class EffectAnimation : MonoBehaviour
    {
        [SerializeField] private List<SpriteEffect> sprites = null;
        [SerializeField] private new SpriteRenderer renderer;
        [SerializeField] private AnimationCurve curve = null;
        private Transform _transform;

        private void Awake()
        {
            renderer = GetComponentInChildren<SpriteRenderer>();
            _transform = transform;
        }

        public void AnnounceEffect(string effect)
        {
            foreach (var spriteEffect in sprites)
            {
                if (spriteEffect.effect.Equals(effect))
                {
                    renderer.sprite = spriteEffect.sprite;
                    StartCoroutine(ShowEffect());
                    return;
                }
            }
        }

        private IEnumerator ShowEffect()
        {
            float duration = 2f;
            float elapsed = 0;
            var size = _transform.localScale;
            while (elapsed < duration)
            {
                yield return null;
                elapsed += Time.deltaTime;
                size.x = curve.Evaluate(elapsed / duration);
                size.y = curve.Evaluate(elapsed / duration);
                _transform.localScale = size;
            }

            renderer.sprite = null;
        }
    }


    [System.Serializable]
    public struct SpriteEffect
    {
        public string effect;
        public Sprite sprite;
    }
}