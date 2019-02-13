using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    /// <summary>
    /// aiCharacter的感知
    /// </summary>
    public class Sensor : ScriptableObject
    {

        public virtual void InitializeSensor(AICharacterBrain _Brain) { }
        public virtual void DetectTheWorld() { }

    }
}

