using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("2D Engine/Characters/AI Actions/Start Firing")]

public class StartFiring : CharacterAIAction, IAction
{
    public override void Perform()
    {
        // Get the character weapon, and return if not present
        CharacterWeaponSlot weaponSlot = GetComponent<CharacterWeaponSlot>();
        if (weaponSlot == null) return;
        // Start firing
        weaponSlot.SetFiring(true);
    }
}
