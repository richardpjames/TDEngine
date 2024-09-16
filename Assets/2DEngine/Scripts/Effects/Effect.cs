using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]

public class Effect : MonoBehaviour
{
    // Must be overridden in other effects
    public virtual void Play() { }

}
