using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]

public class CharacterAICondition : MonoBehaviour, ICondition
{
    public virtual bool Evaluate()
    {
        return true;
    }
}
