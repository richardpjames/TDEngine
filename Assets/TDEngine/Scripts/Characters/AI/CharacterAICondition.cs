using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace richardpjames.com.TDEngine.Characters.AI
{
    [AddComponentMenu("")]

    public class CharacterAICondition : MonoBehaviour, ICondition
    {
        public virtual bool Evaluate()
        {
            return true;
        }
    }
}