using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

[AddComponentMenu("2D Engine/Weapons/Weapon")]

public class Weapon : MonoBehaviour
{
    private bool firing = false;
    // Begin and stop firing (allows for holding controls)
    public virtual void SetFiring(bool newFiringValue)
    {
        firing = newFiringValue;
    }

}
