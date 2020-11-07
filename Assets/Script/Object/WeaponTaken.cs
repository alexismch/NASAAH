using System;
using Script.Manager;
using UnityEngine;

namespace Script.Object
{
    public class WeaponTaken : MonoBehaviour
    {
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.TakeWeapon();
                Destroy(gameObject);
            }
        }
    }
}