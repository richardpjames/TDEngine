using richardpjames.com.TDEngine.Weapons;
using UnityEditor;
using UnityEngine;

namespace richardpjames.com.TDEngine.Characters
{
    [AddComponentMenu("TD Engine/Characters/Character Weapon Slot")]

    public class CharacterWeaponSlot : MonoBehaviour
    {
        [SerializeField] private Weapon defaultWeapon;
        [SerializeField] private Transform weaponPosition;
        [SerializeField] private LayerMask excludeLayers;
        private Weapon equippedWeapon;
        // Start is called before the first frame update
        private void Start()
        {
            // If there is a default weapon then spawn it at the right place
            if (defaultWeapon != null && weaponPosition)
            {
                // Take the default weapon and make it a child of the weapon position
                equippedWeapon = Instantiate(defaultWeapon, weaponPosition);
            }
        }

        public void EquipWeapon(Weapon weapon)
        {
            // If a weapon is supplied and is a prefab
            if(weapon != null)
            {
                // If there is already a weapon equipped destroy it
                equippedWeapon?.Destroy();
                // Equip the new weapon
                equippedWeapon = Instantiate(weapon, weaponPosition);
            }
        }

        // Attack with the weapon if equipped
        public void SetFiring(bool newFiringValue)
        {
            // Check that a weapon is equipped
            if (equippedWeapon != null)
            {
                // Then set whether that weapon is firing
                equippedWeapon.SetFiring(newFiringValue);
                equippedWeapon.SetExcludeLayers(excludeLayers);
            }
        }

    }
}