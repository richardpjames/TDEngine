using richardpjames.com.TDEngine.Characters;
using richardpjames.com.TDEngine.Effects;
using richardpjames.com.TDEngine.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace richardpjames.com.TDEngine.Weapons
{
    [AddComponentMenu("TD Engine/Weapons/Weapon Pickup")]

    public class WeaponPickup : MonoBehaviour, IInteractable
    {
        [SerializeField] private Weapon weaponPrefab;
        [SerializeField] private EffectsContainer pickUpEffects;

        public void Interact(Character character)
        {
            // Get the weapon slot for the character (return if none present)
            CharacterWeaponSlot weaponSlot = character.GetComponent<CharacterWeaponSlot>();
            if (weaponSlot == null) return;
            // Equip the weapon
            weaponSlot.EquipWeapon(weaponPrefab);
            // Play any effects if required
            if(pickUpEffects != null)
            {
                Instantiate(pickUpEffects, transform.position, Quaternion.identity);
            }
            // Destroy the pickup
            Destroy(gameObject);
        }
    }
}
