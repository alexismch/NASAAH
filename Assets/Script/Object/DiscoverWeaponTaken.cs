using TMPro;
using UnityEngine;

namespace Script.Object
{
    public class DiscoverWeaponTaken : WeaponTaken
    {
        [SerializeField] private GameObject diamond = null;
        [SerializeField] private TMP_Text text = null;

        private new void OnTriggerEnter2D(Collider2D other)
        {
            diamond.SetActive(true);
            base.OnTriggerEnter2D(other);
            text.text = "Pour réussir les divers niveaux, vous devez ramasser 10 diamands, touvez les !";
        }
    }
}