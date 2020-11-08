using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Animation
{
    public class EffectAnimation : MonoBehaviour
    {
        [SerializeField] private List<SpriteEffect> sprites;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private AnimationCurve curve;
        private Transform _transform;

        private void Awake()
        {
            _renderer = GetComponentInChildren<SpriteRenderer>();
            _transform = transform;
        }

        public void AnnounceEffect(string effect)
        {
            foreach (var spriteEffect in sprites)
            {
                if (spriteEffect.effect.Equals(effect))
                {
                    _renderer.sprite = spriteEffect.sprite;
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
            _renderer.sprite = null;
        }
    }

    
    [System.Serializable]
    public struct SpriteEffect
    {
        public string effect;
        public Sprite sprite;
    }
}
