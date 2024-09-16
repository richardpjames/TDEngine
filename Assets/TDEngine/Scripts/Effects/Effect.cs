using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace richardpjames.com.TDEngine.Effects
{
    [AddComponentMenu("")]

    public class Effect : MonoBehaviour
    {
        // Must be overridden in other effects
        public virtual void Play() { }

    }
}