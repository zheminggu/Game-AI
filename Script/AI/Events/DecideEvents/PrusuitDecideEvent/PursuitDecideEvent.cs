using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu (menuName = "AI/DecideEvents/PursuitEvents")]
    public class PursuitDecideEvent : DecideEvents
    {
       
        public override bool MatchedChangeCondition(AICharacterBrain _Brain)
        {
            if (_Brain.m_SensorManager.m_SensorData.m_HaveEnemy)
            {
                return true;
            }
            return false;
        }
    }
}

