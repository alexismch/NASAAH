using Script.Manager;
using UnityEngine;

namespace Script.Object
{
    public class DiscoverWeaponTaken : WeaponTaken
    {
        [SerializeField] private GameObject diamond;
        
        private new void OnTriggerEnter2D(Collider2D other)
        {
            diamond.SetActive(true);
            base.OnTriggerEnter2D(other);
        }
    }
}