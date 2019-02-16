using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    [CreateAssetMenu (menuName = "AI/DecideEvents/HaveEnemy")]
    public class HaveEnemy : DecideEvents
    {

        public override bool MatchedChangeCondition(AICharacterBrain _Brain)
        {
            if(_Brain.m_SensorManager.m_SensorData.m_NeedEvade)
            {
                //Debug.Log("Need Evade");
                return true;
            }
            return false;
        }
    }

}
